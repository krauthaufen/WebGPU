open System.Text.Json
open System.IO
open System.Collections.Generic

let doc = JsonDocument.Parse (File.ReadAllText(Path.Combine(__SOURCE_DIRECTORY__, "dawn.json")))

let toOption ((exists : bool, value : 'a)) =
    if exists then Some value
    else None
let toOptionString ((exists : bool, value : JsonElement)) =
    if exists && value.ValueKind = JsonValueKind.String then Some (value.GetString())
    else None
           
module List =
    let mapOption (mapping : 'a -> option<'b>) (l : list<'a>) =
        let r = l |> List.map mapping
        if r |> List.forall Option.isSome then
            r |> List.map Option.get |> Some
        else
            None
type TypeRef = { TypeName : string; Annotation : option<string> }

module TypeRef =
    let isFloat (t : TypeRef) =
        match t.Annotation with
        | None ->
            t.TypeName = "float" || t.TypeName = "double"
        | _ ->
            false
            
    let is64Bit (t : TypeRef) =
        match t.Annotation with
        | None ->
            t.TypeName = "double" || t.TypeName = "int64_t"  || t.TypeName = "uint64_t"
        | _ ->
            false
            
type FieldDef =
    {
        Type : TypeRef
        Name : string
        Default : option<JsonElement>
        Optional : bool
        Length : option<string>
        Tags : list<string>
    }

module FieldDef =
    
    let isUserData (a : FieldDef) =
        (a.Type.TypeName = "void *" || (a.Type.TypeName = "void" && a.Type.Annotation = Some "*")) && a.Name.ToLower().Contains "userdata"

    let tryParse (name : string) (e : JsonElement) =
        match e.TryGetProperty("type") with
        | (true, typ) when typ.ValueKind = JsonValueKind.String ->
            let typ = typ.GetString()
            let def = e.TryGetProperty("default") |> toOption
            let annotation = e.TryGetProperty("annotation") |> toOptionString
            let optional = e.TryGetProperty("optional") |> toOption |> Option.map (fun v -> v.GetBoolean()) |> Option.defaultValue false
            let length =
                match e.TryGetProperty("length") with
                | (true, l) when l.ValueKind = JsonValueKind.String -> l.GetString() |> Some
                | _ -> None
                
            let tags =
                match e.TryGetProperty "tags" with
                | (true, t) -> List.init (t.GetArrayLength()) (fun i -> t[i].GetString())
                | _ -> []
                
            Some { Type = { TypeName = typ; Annotation = annotation }; Tags = tags; Name = name; Default = def; Optional = optional; Length = length }
        | _ ->
            None

[<RequireQualifiedAccess>]
type Direction =
    | In
    | Out

type StructDef =
    {
        Name : string
        Extensible : option<Direction>
        ChainRoots : list<string>
        Chained : option<Direction>
        Fields : list<FieldDef>
        Tags : list<string>
    }

type FunctionDef =
    {
        Name : string
        Tags : list<string>
        Return : TypeRef
        Args : list<FieldDef>
    }

module FunctionDef =
    let tryParse (name : string) (obj : JsonElement) =
        let args = 
            match obj.TryGetProperty("args") with
            | (true, a) when a.ValueKind = JsonValueKind.Array ->
                let len = a.GetArrayLength()
                List.init len (fun i -> a.[i])
            | _ ->
                []
                
        let args = 
            args |> List.mapOption (fun a ->
                match a.TryGetProperty "name" with
                | (true, name) when name.ValueKind = JsonValueKind.String ->
                    FieldDef.tryParse (name.GetString()) a
                | _ ->
                    None
            )
               
        let returns =
            match obj.TryGetProperty("returns") with
            | (true, r) when r.ValueKind = JsonValueKind.String ->
                r.GetString()
            | _ ->
                "void"
        
        let tags =
            match obj.TryGetProperty "tags" with
            | (true, r) when r.ValueKind = JsonValueKind.Array ->
                List.init (r.GetArrayLength()) (fun i -> r[i].GetString())
            | _ ->
                []
               
        match args with
        | Some args ->
            // TODO annotation??
            Some { Name = name; Tags = tags; Return = { TypeName = returns; Annotation = None }; Args = args }
        | None ->
            None

    let isBadWasmFunction (f : FunctionDef) =
        f.Args.Length > 5 ||
        f.Args |> List.exists (fun a -> TypeRef.is64Bit a.Type || TypeRef.isFloat a.Type)

type Enum =
    {
        Name : string
        Values : list<string * int>
        Flags : bool
    }
    
type Alias =
    {
        Name : string
        Type : TypeRef
    }

type Native =
    {
        Name : string
        WasmType : option<string>
    }

type Object =
    {
        Name : string
        Tags : list<string>
        Methods : list<FunctionDef>
    }


type Definition =
    | Enum of Enum
    | Delegate of FunctionDef
    | Struct of StructDef
    | Function of FunctionDef
    | Alias of Alias
    | Native of Native
    | Object of Object
    | CallbackInfo of StructDef
    
    
    member x.Name =
        match x with
        | Enum { Name = n } -> n
        | Delegate { Name = n } -> n
        | Struct { Name = n } -> n
        | Function { Name = n } -> n
        | Alias { Name = n } -> n
        | Native { Name = n } -> n
        | Object { Name = n } -> n
        | CallbackInfo { Name = n } -> n
        
    member x.ReferencedTypes =
        match x with
        | Enum _ | Native _ ->
            Seq.empty
        | Delegate { Args = a; Return = r } | Function { Args = a; Return = r } ->
            Seq.append (Seq.singleton r) (a |> Seq.map (fun a -> a.Type))
        | Struct { Fields = f } | CallbackInfo { Fields = f } ->
            f |> Seq.map (fun f -> f.Type)
        | Alias { Type = t } -> Seq.singleton t
        | Object { Methods = ms } ->
            ms |> Seq.collect (fun m ->
                m.Args |> Seq.map (fun a -> a.Type)    
            )
        
    
    


let allList = ResizeArray()

module StructDef =
    let parse (name : string) (obj : JsonElement) =
        let extensible =
            match obj.TryGetProperty "extensible" with
            | (true, e) when e.ValueKind = JsonValueKind.String ->
                match e.GetString() with
                | "in" -> Some Direction.In
                | "out" -> Some Direction.Out
                | e -> failwithf "bad direction: %A" e
            | _ ->
                None
        let tags =
            match obj.TryGetProperty("tags") with
            | (true, t) when t.ValueKind = JsonValueKind.Array ->
                List.init (t.GetArrayLength()) (fun i -> t[i].GetString())
            | _ ->
                []
        let fields =
            match obj.TryGetProperty("members") with
            | (true, mems) ->
                let len = mems.GetArrayLength()
                List.init len (fun i ->
                    let mem = mems[i]
                    let name = mem.GetProperty("name").GetString()
                    
                    FieldDef.tryParse name mem
                    // let typName = mem.GetProperty("type").GetString()
                    // let name = mem.GetProperty("name").GetString()
                    // let def = mem.TryGetProperty("default") |> toOption
                    // let annotation = mem.TryGetProperty("annotation") |> toOptionString
                    // let optional = mem.TryGetProperty("optional") |> toOption |> Option.map (fun v -> v.GetBoolean()) |> Option.defaultValue false
                    // let length = mem.TryGetProperty("length") |> toOptionString
                    //
                    // let tags =
                    //     match mem.TryGetProperty("tags") with
                    //     | (true, t) when t.ValueKind = JsonValueKind.Array ->
                    //         List.init (t.GetArrayLength()) (fun i -> t[i].GetString())
                    //     | _ ->
                    //         []
                    //
                    // // if tags |> List.exists (fun t -> t = "deprecated") then
                    // //     None
                    // // else
                    // let typRef = { TypeName = typName; Annotation = annotation }
                    // Some { Type = typRef; Name = name; Default = def; Optional = optional; Length = length }
                )
                |> List.choose id
            | _ ->
                []
        
        let chainRoots =
            match obj.TryGetProperty "chain roots" with
            | (true, roots) when roots.ValueKind = JsonValueKind.Array ->
                List.init (roots.GetArrayLength()) (fun i -> roots[i].GetString())
            | _ ->
                []
                
        let chained =
            match obj.TryGetProperty "chained" with
            | (true, c) when c.ValueKind = JsonValueKind.String ->
                match c.GetString() with
                | "in" -> Some Direction.In
                | "out" -> Some Direction.Out
                | e -> failwithf "bad direction: %A" e
            | _ ->
                None
                
        {
            Extensible = extensible
            Chained = chained
            Name = name
            ChainRoots = chainRoots 
            Fields = fields
            Tags = tags
        }

for kv in doc.RootElement.EnumerateObject() do
    let obj = kv.Value
    if obj.ValueKind = JsonValueKind.Object then
        match obj.TryGetProperty "category" with
        | (true, cat) ->
            match cat.GetString() with
            | "callback info" ->
                let name = kv.Name
                let s = StructDef.parse name obj

                let s = 
                    { s with 
                        Extensible = Some Direction.In
                        Fields = 
                            s.Fields @ [
                                { Name = "userdata1"; Default = None; Optional = false; Length = None; Tags = []; Type = { TypeName = "void *"; Annotation = None}}
                                { Name = "userdata2"; Default = None; Optional = false; Length = None; Tags = []; Type = { TypeName = "void *"; Annotation = None}}
                            ] 
                    }

                allList.Add (CallbackInfo s)
                
            | "object" ->
                
                let tags =
                    match obj.TryGetProperty "tags" with
                    | (true, t) when t.ValueKind = JsonValueKind.Array ->
                        List.init (t.GetArrayLength()) (fun i -> t[i].GetString())
                    | _ ->
                        []
                match obj.TryGetProperty "methods" with
                | (true, ms) when ms.ValueKind = JsonValueKind.Array ->
                    let meths = 
                        List.init (ms.GetArrayLength()) (fun i ->
                            match ms.[i].TryGetProperty "name" with
                            | (true, n) when n.ValueKind = JsonValueKind.String ->
                                match FunctionDef.tryParse (n.GetString()) ms.[i] with
                                | Some f -> Some f
                                | None -> None
                            | _ ->
                                None
                        )
                        
                    let meth =
                        {
                            FunctionDef.Name = "release"
                            Tags = []
                            Return = { TypeName = "void"; Annotation = None }
                            Args = []
                        }

                    match meths |> List.mapOption id with
                    | Some meths ->
                        let meths = meths @ [meth]
                        allList.Add (Object { Name = kv.Name; Tags = tags; Methods = meths })
                    | None ->
                        ()
                | _ ->
                    allList.Add (Object { Name = kv.Name; Tags = tags; Methods = [] })
                    
                () // TODO
                
            | "native" ->
                let w = 
                    match obj.TryGetProperty "wasm type" with
                    | (true, w) when w.ValueKind = JsonValueKind.String ->
                        let w = w.GetString()
                        Some w
                    | _ ->
                        None
                allList.Add(Native { Name = kv.Name; WasmType =  w })
                
            | "typedef" ->
                match obj.TryGetProperty "type" with
                | (true, t) when t.ValueKind = JsonValueKind.String ->
                    let annotation = obj.TryGetProperty("annotation") |> toOptionString
                    allList.Add(Alias { Name = kv.Name; Type = { TypeName = t.GetString(); Annotation = annotation } })
                | _ ->
                    ()
                
            | "constant" ->
                () // simple
                
            | "enum" | "bitmask" ->
                let values =
                    match obj.TryGetProperty "values" with
                    | (true, vs) when vs.ValueKind = JsonValueKind.Array ->
                        List.init (vs.GetArrayLength()) (fun i ->
                            let v = vs.[i]
                            let name = v.GetProperty("name").GetString()
                            let v = v.GetProperty("value").GetInt32()
                            name, v
                        )
                    | _ ->
                        []
                let e = { Name = kv.Name; Values = values; Flags = cat.GetString() = "bitmask" }
                allList.Add (Enum e)
            
            | "function" -> 
                match FunctionDef.tryParse kv.Name obj with
                | Some f ->
                    allList.Add (Function f)
                | None ->
                    ()
            
            | "function pointer" ->
                match FunctionDef.tryParse kv.Name obj with
                | Some f ->
                    allList.Add (Delegate f)
                | None ->
                    ()
            | "callback function"  ->
                match FunctionDef.tryParse kv.Name obj with
                | Some f ->
                    let f =
                        { f with
                            Args =
                                f.Args @ [
                                    { Name = "userdata1"; Tags = []; Type = { TypeName = "void *"; Annotation = None }; Default = None; Optional = false; Length = None }
                                    { Name = "userdata2"; Tags = []; Type = { TypeName = "void *"; Annotation = None }; Default = None; Optional = false; Length = None }
                                ]
                        }
                    allList.Add (Delegate f)
                | None ->
                    ()
            | "structure" ->
                let name = kv.Name
                let s = StructDef.parse name obj
                allList.Add (Struct s)
            
            | cat ->
                failwithf "UNKNOWN CATEGORY: %A" cat
            
        | _ ->
            ()
    

let nonExistentTypes = Set.empty //Set.ofList ["external texture binding layout"; "logging callback"; "external texture"; "image copy external texture"; "copy texture for browser options"]


let all =
    Seq.toArray allList
    |> Array.choose (fun a ->
        match a with
        | Object o ->
            let meths = 
                o.Methods |> List.filter (fun m ->
                    let deprecated = m.Tags |> List.exists (fun t -> t = "deprecated")
         
                    let bad =
                        Set.contains m.Return.TypeName nonExistentTypes ||
                        m.Args |> Seq.exists (fun a -> Set.contains a.Type.TypeName nonExistentTypes)
                    not deprecated && not bad
                )
            Some (Object { o with Methods = meths })
            // else
            //     None
        | _ ->
            Some a
    )
   
let table = Dictionary()
for a in all do
    table.[a.Name] <- a
    
let tryResolveType (t : TypeRef) =
    match table.TryGetValue t.TypeName with
    | (true, entry) ->
        Some entry
    | _ ->
        None
    


let childTypes, parentTypes =
    let mutable res = Map.empty
    let mutable parents = Map.empty
    for a in all do
        match a with
        | Object o ->
            for meth in o.Methods do
                if meth.Name.StartsWith "create " then
                    let parent = o.Name
                    let child = meth.Return.TypeName
                    match tryResolveType meth.Return with
                    | Some (Object _) ->
                        let mutable otherParent = None
                        let mutable isChild = true
                        match Map.tryFind child parents with
                        | Some (Some p) ->
                            if p <> parent then
                                parents <- Map.add child None parents
                                otherParent <- Some p
                                isChild <- false
                        | Some None ->
                            isChild <- false
                        | None ->
                            parents <- Map.add child (Some parent) parents
                        
                        match otherParent with
                        | Some other ->
                            match Map.tryFind other res with
                            | Some l ->
                                res <- Map.add other (Map.remove child l) res
                            | None ->
                                ()
                        | None ->
                            ()
                        if isChild then
                            match Map.tryFind o.Name res with
                            | Some l ->
                                res <- Map.add o.Name (Map.add meth.Return.TypeName meth.Name l) res
                            | None ->
                                res <- Map.add o.Name (Map.ofList [meth.Return.TypeName, meth.Name]) res
                    | _ ->
                        ()
                    
                    
        | _ ->
            ()
            
    let mutable pp = Map.empty
    for KeyValue(c, p) in parents do
        match p with
        | Some p -> pp <- Map.add c p pp
        | None -> ()
            
    res, pp

let rx = System.Text.RegularExpressions.Regex "^[0-9]+.*$"
              
// print native wrapper
let pascalCase (str : string) =
    let res = 
        str.Split(" ")
        |> Array.map (fun str -> str.Substring(0, 1).ToUpper() + str.Substring(1))
        |> String.concat ""

    if rx.IsMatch res then "D" + res
    else res

let camelCase (str : string) =
    let res = 
        str.Split(" ")
        |> Array.mapi (fun i str -> if i > 0 then str.Substring(0, 1).ToUpper() + str.Substring(1) else str)
        |> String.concat ""

    if res = "type" then "typ"
    elif res = "module" then "moodule"
    elif rx.IsMatch res then "d" + res
    else res

    
for (KeyValue(c, p)) in parentTypes do
    printfn $"{pascalCase p} -> {pascalCase c}"

    
for (KeyValue(p, cs)) in childTypes do
    printfn $"{pascalCase p}"
    for (KeyValue(c, m)) in cs do
        printfn $"    .{pascalCase m} : {pascalCase c}"


//
// let deviceChild =
//     let device = 
//         allList |> Seq.pick (fun d -> 
//             match d with
//             | Object o when o.Name = "device" -> Some o
//             | _ -> None
//         )
//
//     device.Methods 
//     |> Seq.choose (fun m -> 
//         if m.Name.StartsWith "create " then 
//             match tryResolveType m.Return with
//             | Some (Object o) ->
//                 Some o.Name
//             | _ ->
//                 None
//         else
//             None
//     )
//     |> Set.ofSeq
//
// for c in deviceChild do
//     printfn "%0A" c

  
    
let isDawn (tags : list<string>) =
    tags = [] || tags |> List.exists (fun t -> t = "dawn" || t = "native")

let isEmscripten (tags : list<string>) =
    tags = [] || tags |> List.exists (fun t -> t = "emscripten")


module Native =
        
    let rec nativeTypeName (t : TypeRef) =
        let def = table.[t.TypeName]
        
        let baseType = 
            match def with
            | Object o -> "WGPU" + pascalCase o.Name
            | Enum e -> "WGPU" + pascalCase e.Name
            | Delegate d -> "WGPU" + pascalCase d.Name
            | Alias a -> nativeTypeName a.Type
            | Struct a -> "WGPU" + pascalCase a.Name
            | Function _ -> failwith "not a type"
            | CallbackInfo c -> "WGPU" + pascalCase c.Name
            | Native n -> n.Name
            
            
        match t.Annotation with
        | None -> baseType
        | Some a ->
            match a with
            | "*" -> baseType + "*"
            | "const*" -> "const " + baseType + "*"
            | "const*const*" -> "const " + baseType + "* const*"
            | _ -> failwith "asdasdsad"
        
    let print (fileName : string) (emscripten : bool) =
        let b = System.Text.StringBuilder()
        let printfn fmt = fmt |> Printf.kprintf (fun str -> b.AppendLine str |> ignore)
        
        let functionFormat =
            if emscripten then "EMSCRIPTEN_KEEPALIVE {0}"
            else "DllExport({0})"
            
        let checkTags =
            if emscripten then isEmscripten
            else isDawn
        
        if emscripten then
            printfn "#include <emscripten.h>"
            printfn "#include <emscripten/html5.h>"
            printfn "#include <SDL/SDL_image.h>"
            printfn "typedef void* WGPUExternalTexture;"
        else
            printfn "#include \"dllexport.h\""
        printfn "#include <string.h>"
        printfn "#include <stdlib.h>"
        printfn "#include <stdio.h>"
        printfn "#include <stdint.h>"
        printfn "#include \"webgpu.h\""
        printfn " "
        if not emscripten then
            printfn "#include \"webgpu_glfw.h\""


            printfn "DllExport(WGPUSurface) gpuInstanceCreateGLFWSurface(WGPUInstance self, const void* window) {"
            printfn "    auto instance = wgpu::Instance(self);"
            printfn "    auto surf = wgpu::glfw::CreateSurfaceForWindow(instance, (GLFWwindow*)window);"
            printfn "    auto handle = surf.Get();"
            printfn "    wgpuSurfaceAddRef(handle);"
            printfn "    return handle;"
            printfn "}"

        for a in all do
            let functions = 
                match a with
                | Enum _ | Delegate _ | Alias _ | Native _ | CallbackInfo _ | Struct _ ->
                    []
                | Function f -> 
                    if checkTags f.Tags then [f]
                    else []
                | Object o ->
                    if checkTags o.Tags then
                        o.Methods |> List.choose (fun m ->
                            if checkTags m.Tags then
                                let name = o.Name + " " + m.Name
                                
                                let args = { Name = "self"; Tags = []; Type = { TypeName = o.Name; Annotation = None }; Default = None; Optional = false; Length = None } :: m.Args
                                Some { m with Name = name; Args = args }
                            else
                                None
                        )
                    else
                        []
            for m in functions do
                let name = m.Name
                let args = m.Args
                if FunctionDef.isBadWasmFunction m then
                    printfn "typedef struct { "
                    for a in args do
                        printfn "   %s %s;" (nativeTypeName a.Type) (pascalCase a.Name)
                    printfn "} WGPU%sArgs;" (pascalCase name)
                    
                    
                    let argdef = sprintf "const WGPU%sArgs* args" (pascalCase name)
                    let argref = args |> List.map (fun a -> sprintf "args->%s" (pascalCase a.Name)) |> String.concat ", "
                    
                    printfn $"{System.String.Format(functionFormat, nativeTypeName m.Return)} gpu{pascalCase name}({argdef}) {{"
                    printfn $"    return wgpu{pascalCase name}({argref});"
                    printfn $"}}"
                else
                            
                    let argdef = args |> List.map (fun a -> nativeTypeName a.Type + " " + camelCase a.Name) |> String.concat ", "
                    let argref = args |> List.map (fun a -> camelCase a.Name) |> String.concat ", "
                    
                    printfn $"{System.String.Format(functionFormat, nativeTypeName m.Return)} gpu{pascalCase name}({argdef}) {{"
                    printfn $"    return wgpu{pascalCase name}({argref});"
                    printfn $"}}"
                    
                    ()
                        
                    ()
        File.WriteAllText(fileName, b.ToString())

module Enums =
    
    let print() =
        let b = System.Text.StringBuilder()
        let printfn fmt = fmt |> Printf.kprintf (fun str -> b.AppendLine str |> ignore)
        
        
        printfn "namespace rec WebGPU"
        printfn "open System"
        printfn "#nowarn \"9\""
        
        for a in all do
            match a with
            | Enum e ->
                
                if e.Flags then printfn "[<Flags>]"
                printfn "type %s =" (pascalCase e.Name)
                for (name, value) in e.Values do
                    let value =
                        if e.Flags then sprintf "%dL" value
                        else sprintf "%d" value
                    printfn "    | %s = %s" (pascalCase name) value
            | _ ->
                ()
        File.WriteAllText(Path.Combine(__SOURCE_DIRECTORY__, "src", "WebGPU", "Enums.fs"), b.ToString())


module RawWrapper =
    
    let rec externName (t : TypeRef) =
        let def = table.[t.TypeName]
        
        let baseType = 
            match def with
            | Object o -> "nativeint"
            | Enum e -> pascalCase e.Name
            | Delegate d -> "nativeint" //pascalCase d.Name
            | Alias a -> externName a.Type
            | Struct a -> pascalCase a.Name
            | Function _ -> failwith "not a type"
            | CallbackInfo c -> pascalCase c.Name
            | Native n ->
                match n.Name with
                | "int8_t" -> "int8"
                | "uint8_t" -> "uint8"
                | "int16_t" -> "int16"
                | "uint16_t" -> "uint16"
                | "int32_t" | "int" -> "int"
                | "uint32_t" -> "uint32"
                | "int64_t" -> "int64"
                | "uint64_t" -> "uint64"
                | "void" -> "void"
                | "bool" -> "int"
                | "char" -> "byte"
                | "float" -> "float32"
                | "double" -> "double"
                | "size_t" -> "unativeint"
                | "void *" | "void const *" -> "nativeint"
                | _ -> failwithf "bad native type: %A" n.Name
            
            
        match t.Annotation with
        | None -> baseType
        | Some a ->
            match a with
            | "*" -> baseType + "*"
            | "const*" -> baseType + "*"
            | "const*const*" -> baseType + "**"
            | _ -> failwith "asdasdsad"
      
    let rec fsharpName (t : TypeRef) =
        
        let def = table.[t.TypeName]
        
        let baseType = 
            match def with
            | Object o -> "nativeint"
            | Enum e -> pascalCase e.Name
            | Delegate d -> "nativeint" //pascalCase d.Name
            | Alias a -> fsharpName a.Type
            | Struct a -> pascalCase a.Name
            | Function _ -> failwith "not a type"
            | CallbackInfo c -> pascalCase c.Name
            | Native n ->
                match n.Name with
                | "int8_t" -> "int8"
                | "uint8_t" -> "uint8"
                | "int16_t" -> "int16"
                | "uint16_t" -> "uint16"
                | "int32_t" | "int"  -> "int"
                | "uint32_t" -> "uint32"
                | "int64_t" -> "int64"
                | "uint64_t" -> "uint64"
                | "void" -> "unit"
                | "bool" -> "int"
                | "char" -> "byte"
                | "float" -> "float32"
                | "double" -> "double"
                | "size_t" -> "unativeint"
                | "void *" | "void const *" -> "nativeint"
                | _ -> failwithf "bad native type: %A" n.Name
            
            
        match t.Annotation with
        | None -> baseType
        | Some a ->
            if baseType = "unit" then
                "nativeint"
            else
                match a with
                | "*" -> $"nativeptr<{baseType}>"
                | "const*" -> $"nativeptr<{baseType}>"
                | "const*const*" -> $"nativeptr<nativeptr<{baseType}>>"
                | _ -> failwith "asdasdsad"
      
    
    let print() =
        let b = System.Text.StringBuilder()
        let printfn fmt = fmt |> Printf.kprintf (fun str -> b.AppendLine str |> ignore)
        
        
        printfn "namespace rec WebGPU.Raw"
        printfn "open System.Collections.Generic"
        printfn "open System"
        printfn "open System.Runtime.InteropServices"
        printfn "open WebGPU"
        printfn "#nowarn \"9\""
        
        
        
        for a in all do
            match a with
            | Enum e ->
                ()
                //
                // if e.Flags then printfn "[<Flags>]"
                // printfn "type %s =" (pascalCase e.Name)
                // for (name, value) in e.Values do
                //     
                //     printfn "    | %s = %d" (pascalCase name) value
            | Alias a ->
                printfn "type %s = %s" (pascalCase a.Name) (fsharpName a.Type)
        
            | Delegate d ->
                let ret = fsharpName d.Return
                match d.Args with
                | [] ->
                    printfn "type %s = delegate of unit -> %s" (pascalCase d.Name) ret
                    
                | _ -> 
                    let args = d.Args |> List.map (fun a -> sprintf "%s : %s" (camelCase a.Name) (fsharpName a.Type)) |> String.concat " * "
                    printfn "type %s = delegate of %s -> %s" (pascalCase d.Name) args ret
            | Struct s | CallbackInfo s ->
                if s.Fields.IsEmpty && Option.isNone s.Extensible && List.isEmpty s.ChainRoots then
                    printfn "[<StructLayout(LayoutKind.Explicit, Size = 4)>]"
                    printfn "type %s = struct end" (pascalCase s.Name)
                else
                    
                    
                    let fields = s.Fields
                    
                    let fields =
                        if Option.isSome s.Chained then { Name = "s type"; Tags = []; Type = { TypeName = "s type"; Annotation = None }; Default = None; Optional = false; Length = None } :: fields
                        else fields
                    
                    let fields =
                        if Option.isSome s.Extensible || Option.isSome s.Chained then { Name = "next in chain"; Tags = []; Type = { TypeName = "void"; Annotation = Some "const*" }; Optional = true; Default = None; Length = None } :: fields
                        else fields
                        
                    let args = 
                        fields |> List.map (fun f ->
                            let typ = fsharpName f.Type
                            let name = camelCase f.Name
                            $"{name} : {typ}"
                        )
                        |> String.concat ", "
                    
                    printfn "[<Struct; StructLayout(LayoutKind.Sequential)>]"
                    printfn "type %s = " (pascalCase s.Name)
                    printfn "    struct"
                    for f in fields do
                        printfn $"        val mutable public {pascalCase f.Name} : {fsharpName f.Type}"
                        // let typ = fsharpName f.Type
                        // let name = pascalCase f.Name
                        // printfn $"    member _.{pascalCase f.Name} : {typ} = {camelCase f.Name}"
                        
                    let ctorArgs = 
                        fields |> List.map (fun f ->
                            let typ = fsharpName f.Type
                            let name = camelCase f.Name
                            $"{name} : {typ}"
                        )
                        |> String.concat ", "
                        
                    let ass = fields |> List.map (fun f -> $"{pascalCase f.Name} = {camelCase f.Name}") |> String.concat "; "
                    printfn $"        new({ctorArgs}) = {{ {ass} }}"
                        
                    if not (List.isEmpty s.Fields) && (Option.isSome s.Extensible || Option.isSome s.Chained) then
                        let ctorArgs = 
                            s.Fields |> List.map (fun f ->
                                let typ = fsharpName f.Type
                                let name = camelCase f.Name
                                $"{name} : {typ}"
                            )
                            |> String.concat ", "
                            
                        let ctoruse =
                            let u = s.Fields |> List.map (fun f -> camelCase f.Name)
                            let args = 
                                if Option.isSome s.Chained then
                                    "0n" :: "Unchecked.defaultof<SType>" :: u
                                elif Option.isSome s.Extensible then
                                    "0n" :: u
                                else
                                    u
                            String.concat ", " args
                        printfn $"        new({ctorArgs}) = {pascalCase s.Name}({ctoruse})"
                        
                    printfn "    end"
            | Function _ | Native _ | Object _ ->
                () // TODO
        
        let methods =
            all |> Seq.collect (fun d ->
                match d with
                | Object o ->
                    o.Methods |> Seq.map (fun m ->
                        { m with Name = o.Name + " " + m.Name; Args = { Name = "self"; Tags = []; Type = { TypeName = o.Name; Annotation = None }; Default = None; Optional = false; Length = None } :: m.Args }    
                    )
                | Function d ->
                    Seq.singleton d
                | _ ->
                    Seq.empty
            )
        
        
        printfn "module WebGPU = "
        printfn ""

        printfn $"    [<DllImport(\"WebGPU\", EntryPoint=\"gpuInstanceCreateGLFWSurface\")>]"
        printfn $"    extern nativeint InstanceCreateGLFWSurface(void* self, void* window)"

        for m in methods do
            if FunctionDef.isBadWasmFunction m then
                let structName = $"{(pascalCase m.Name)}Args"
                printfn "    [<Struct; StructLayout(LayoutKind.Sequential)>]"
                printfn "    type %sArgs = " (pascalCase m.Name)
                printfn "        {"
                for a in m.Args do
                    printfn "            %s : %s" (pascalCase a.Name) (fsharpName a.Type)
                printfn "        }"
                printfn ""
                printfn $"    [<DllImport(\"WebGPU\", EntryPoint=\"gpu{pascalCase m.Name}\")>]"
                printfn $"    extern {externName m.Return} _{pascalCase m.Name}({(pascalCase m.Name)}Args& args)"
            
                let argdef = m.Args |> Seq.map (fun a -> $"{camelCase a.Name} : {fsharpName a.Type}") |> String.concat ", "
                let argref = m.Args |> Seq.map (fun a -> $"{camelCase a.Name}") |> String.concat ", "
                printfn $"    let {pascalCase m.Name}({argdef}) ="
                printfn $"        let mutable args = {{"
                for a in m.Args do
                    printfn $"            {structName}.{pascalCase a.Name} = {camelCase a.Name};"
                printfn $"        }}"
                printfn $"        _{pascalCase m.Name}(&args)"
            else
                let args = m.Args |> Seq.map (fun a -> $"{externName a.Type} {camelCase a.Name}") |> String.concat ", "
                printfn $"    [<DllImport(\"WebGPU\", EntryPoint=\"gpu{pascalCase m.Name}\")>]"
                printfn $"    extern {externName m.Return} {pascalCase m.Name}({args})"
        
        let delegates =
            all |> Seq.choose (fun v ->
                match v with
                | Delegate d ->
                    if d.Args |> List.exists FieldDef.isUserData then
                        Some d
                    else
                        None
                | _ ->
                    None
            )
        
        printfn "type WebGPUCallbacks() ="
        for d in delegates do
            printfn $"    static let {camelCase d.Name}Callbacks = Dictionary<nativeint, {pascalCase d.Name}>()"
            printfn $"    static let mutable {camelCase d.Name}Current = 0n"
            printfn $"    static let {camelCase d.Name}Delegate = System.Delegate.CreateDelegate(typeof<{pascalCase d.Name}>, typeof<WebGPUCallbacks>.GetMethod \"{pascalCase d.Name}\")"
            printfn $"    static let {camelCase d.Name}GC = GCHandle.Alloc({camelCase d.Name}Delegate)"
            printfn $"    static let {camelCase d.Name}Ptr = Marshal.GetFunctionPointerForDelegate({camelCase d.Name}Delegate)"
        for d in delegates do
            let dictName = $"{camelCase d.Name}Callbacks"
            let currentName = $"{camelCase d.Name}Current"
            let ptrName = $"{camelCase d.Name}Ptr"
            let args = d.Args |> List.map (fun a -> $"{camelCase a.Name} : {fsharpName a.Type}") |> String.concat ", "
            let arguse = d.Args |> List.map (fun a -> if FieldDef.isUserData a then "0n" else camelCase a.Name) |> String.concat ", "
            
            let userData =
                d.Args |> List.tryPick (fun a -> if FieldDef.isUserData a then Some (camelCase a.Name) else None) |> Option.defaultValue "userdata"
            //printfn $"    [<UnmanagedCallersOnly>]"
            printfn $"    static member {pascalCase d.Name}({args}) ="
            printfn $"        let callback = "
            printfn $"            lock {dictName} (fun () ->"
            printfn $"                match {dictName}.TryGetValue({userData}) with"
            printfn $"                | (true, cb) ->"
            printfn $"                    Some cb"
            printfn $"                | _ ->"
            printfn $"                    None"
            printfn $"            )"
            printfn $"        match callback with"
            printfn $"        | Some cb -> cb.Invoke({arguse})"
            printfn $"        | None -> Unchecked.defaultof<_>"
            printfn $""
            printfn $"    static member Register(cb : {pascalCase d.Name}) ="
            printfn $"        lock {dictName} (fun () ->"
            printfn $"            let id = {currentName}"
            printfn $"            {currentName} <- {currentName} + 1n"
            printfn $"            {dictName}.[id] <- cb"
            printfn $"            let disp = {{ new System.IDisposable with member x.Dispose() = {dictName}.Remove(id) |> ignore }}"
            printfn $"            struct({ptrName}, id, disp)"
            printfn $"        )"
        
        File.WriteAllText(Path.Combine(__SOURCE_DIRECTORY__, "src", "WebGPU", "Wrapper.fs"), b.ToString())

module Frontend =
     
    let rec frontendName (moreThanOne : bool) (t : TypeRef) =
        match table.TryGetValue t.TypeName with
        | (true, def) ->
            let baseType = 
                match def with
                | Object o -> pascalCase o.Name
                | Enum e -> pascalCase e.Name
                | Delegate d -> pascalCase d.Name
                | Alias a -> frontendName moreThanOne a.Type
                | Struct a -> pascalCase a.Name
                | Function _ -> failwith "not a type"
                | CallbackInfo c -> pascalCase c.Name
                | Native n ->
                    match n.Name with
                    | "int8_t" -> "int8"
                    | "uint8_t" -> "uint8"
                    | "int16_t" -> "int16"
                    | "uint16_t" -> "uint16"
                    | "int32_t" | "int" -> "int"
                    | "uint32_t" -> "uint32"
                    | "int64_t" -> "int64"
                    | "uint64_t" -> "uint64"
                    | "void" -> "unit"
                    | "bool" -> "bool"
                    | "char" -> "byte"
                    | "float" -> "float32"
                    | "double" -> "double"
                    | "size_t" -> "unativeint"
                    | "void *" | "void const *" -> "nativeint"
                    | _ -> failwithf "bad native type: %A" n.Name
                
                
            match t.Annotation with
            | None -> baseType
            | Some a ->
                if baseType = "unit" then
                    "nativeint"
                else
                    match def with
                    | Object _ | Struct _ ->
                        if moreThanOne then
                            match a with
                            | "*" -> $"array<{baseType}>"
                            | "const*" -> $"array<{baseType}>"
                            | "const*const*" -> $"array<array<{baseType}>>"
                            | _ -> failwith "asdasdsad"
                        else
                            match a with
                            | "*" -> $"byref<{baseType}>"
                            | "const*" -> $"{baseType}"
                            | _ -> failwith "asdasdsad"
                            
                    | _ ->
                        match a with
                        | "*" -> $"nativeptr<{baseType}>"
                        | "const*" -> $"nativeptr<{baseType}>"
                        | "const*const*" -> $"nativeptr<nativeptr<{baseType}>>"
                        | _ -> failwith "asdasdsad"
        | _ ->
            t.TypeName
            
    type FieldTrafo =
        {
            FrontendField   : FieldDef
            PinFrontend     : string -> list<string> -> list<string>
            BackendFields   : string -> Map<string, string>
            Read                : Map<string, string> -> string
        }
                
    module Map =
        let union (a : Map<'a, 'b>) (b : Map<'a, 'b>) =
            let mutable res = a
            for KeyValue(k, v) in b do res <- Map.add k v res
            res
                
    let pinStruct (valueName : string) (trafo : list<FieldTrafo>) (innercode : Map<string, string> -> list<string>) =
        let rec pin (pinned : Map<string, string>) (trafo : list<FieldTrafo>) (innercode : Map<string, string> -> list<string>) =
            match trafo with
            | [] -> innercode pinned
            | h :: t ->
                let access = $"{valueName}.{pascalCase h.FrontendField.Name}"
                let p = Map.union pinned (h.BackendFields access)
                let innercode = pin p t innercode
                h.PinFrontend access innercode
        pin Map.empty trafo innercode
                  
    let pinArgs (trafo : list<FieldTrafo>) (innercode : Map<string, string> -> list<string>) =
        let rec pin (pinned : Map<string, string>) (trafo : list<FieldTrafo>) (innercode : Map<string, string> -> list<string>) =
            match trafo with
            | [] -> innercode pinned
            | h :: t ->
                let access = $"{camelCase h.FrontendField.Name}"
                let p = Map.union pinned (h.BackendFields access)
                let innercode = pin p t innercode
                h.PinFrontend access innercode
        pin Map.empty trafo innercode
         
    let (|FieldOfType|_|) (d : FieldDef) =
        match tryResolveType d.Type with
        | Some t -> Some(t, d)
        | None -> None
               
    let (|Ptr|_|) (d : FieldDef) =
        match d.Type.Annotation with
        | Some "*" -> Some (Ptr(true, d))
        | Some "const*" -> Some(Ptr(false, d))
        | _ -> None
    let rec marshalInternal (allFields : list<FieldDef>) (acc : list<FieldTrafo>) (a : list<FieldDef>) =
        
        match a with
        | h :: t when h.Tags |> List.exists (fun t -> t = "deprecated") ->
            marshalInternal allFields acc t
        | _ ->
            
            match a with
            | Ptr(mut, ptr) :: t when Option.isSome ptr.Length && ptr.Type.TypeName <> "void" ->
                
                let acc, cntName, cntType =
                    let f = allFields |> List.find (fun f -> f.Name = ptr.Length.Value)
                    let acc = acc |> List.filter (fun m -> m.FrontendField.Name <> f.Name)
                    acc, f.Name, f.Type
                
                
                
                let innerType = frontendName true { TypeName = ptr.Type.TypeName; Annotation = None }
                
                let handleField = $"{camelCase ptr.Name}Handles"
                let ptrField = $"{camelCase ptr.Name}Ptr"
                let lenField = $"{camelCase ptr.Name}Len"
                
                let cntTypeStr = cntType |> RawWrapper.fsharpName
                
                let self =
                    {
                        FrontendField = { Name = ptr.Name; Tags = []; Type = { TypeName = $"array<{innerType}>"; Annotation = None } ; Default = None; Optional = false; Length = None }
                        BackendFields = fun var -> Map.ofList [cntName, lenField; ptr.Name, ptrField]
                        PinFrontend = fun var code ->
                            [
                                match ptr with
                                | FieldOfType(Object _, _) ->
                                    yield $"let {handleField} = {var} |> Array.map (fun a -> a.Handle)"
                                    yield $"use {ptrField} = fixed ({handleField})"
                                    yield $"let {lenField} = {cntTypeStr} {var}.Length"
                                    yield! code
                                | FieldOfType(Struct _, _) ->
                                    yield $"WebGPU.Raw.Pinnable.pinArray {var} (fun {ptrField} ->"
                                    yield $"    let {lenField} = {cntTypeStr} {var}.Length"
                                    for c in code do
                                        yield $"    {c}"
                                    yield ")"
                                | _ ->
                                    yield $"use {ptrField} = fixed ({var})"
                                    yield $"let {lenField} = {cntTypeStr} {var}.Length"
                                    yield! code
                            ]
                        Read = fun vars ->
                            let lenField = vars.[cntName]
                            let ptrField = vars.[ptr.Name]
                            match ptr with
                            | FieldOfType(Object _, _) ->
                                $"let ptr = {ptrField} in Array.init (int {lenField}) (fun i -> new {innerType}(NativePtr.get ptr i))"//TODO3 {lenField} {ptrField}"
                            | FieldOfType(Struct _, _) ->
                                $"let ptr = {ptrField} in Array.init (int {lenField}) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in {innerType}.Read(&r))"
                            | _ ->
                                $"let ptr = {ptrField} in Array.init (int {lenField}) (fun i -> NativePtr.get ptr i)"
                    }
                    
                marshalInternal allFields (self :: acc) t

            | h :: t ->
                let inline simple() =
                    if FieldDef.isUserData h then
                        marshalInternal allFields acc t

                    else
                        match h with
                        | Ptr(mut, ptr)when ptr.Type.TypeName <> "void" && ptr.Type.TypeName <> "char" ->
                            
                            let innerType = frontendName true { TypeName = ptr.Type.TypeName; Annotation = None }
                            let handleField = $"{camelCase ptr.Name}Handle"
                            let ptrField = $"{camelCase ptr.Name}Ptr"
                            
                            let self =
                                {
                                    FrontendField = { Name = ptr.Name; Tags = []; Type = { TypeName = $"{innerType}"; Annotation = None } ; Default = None; Optional = false; Length = None }
                                    BackendFields = fun var -> Map.ofList [ptr.Name, ptrField]
                                    PinFrontend = fun var code ->
                                        [
                                            match ptr with
                                            | FieldOfType(Object _, _) ->
                                                yield $"let mutable {handleField} = {var}.Handle"
                                                yield $"use {ptrField} = fixed (&{handleField})"
                                                yield! code
                                            | FieldOfType(Struct _, _) ->
                                                yield $"WebGPU.Raw.Pinnable.pinArray [| {var} |] (fun {ptrField} ->"
                                                for c in code do
                                                    yield $"    {c}"
                                                yield $"    let {var}Result = NativePtr.toByRef {ptrField}"
                                                yield $"    {var} <- {innerType}.Read(&{var}Result)"
                                                yield ")"
                                            | _ ->
                                                yield $"let mutable {handleField} = {var}"
                                                yield $"use {ptrField} = fixed (&{handleField})"
                                                yield! code
                                        ]
                                    Read = fun vars ->
                                        let ptrField = vars.[ptr.Name]
                                        match ptr with
                                        | FieldOfType(Object _, _) ->
                                            $"let ptr = {ptrField} in new {innerType}(NativePtr.read ptr)"
                                        | FieldOfType(Struct _, _) ->
                                            $"let ptr = {ptrField} in let r = NativePtr.toByRef ptr in {innerType}.Read(&r)"
                                        | _ ->
                                            $"let ptr = {ptrField} in NativePtr.read ptr"
                                }
                                
                            marshalInternal allFields (self :: acc) t
                        | _ ->
                            let self =
                                {
                                    FrontendField = h
                                    BackendFields = fun var -> Map.ofList [h.Name, var]
                                    PinFrontend = fun _ code -> code
                                    Read = fun var -> var.[h.Name]
                                }
                            marshalInternal allFields (self :: acc) t
                    
                

                if h.Type.TypeName = "char" && h.Type.Annotation = Some "const*" then
                    let varName = $"_{camelCase h.Name}Ptr"
                    let self = 
                        {
                            FrontendField = { FieldDef.Name = h.Name; Tags = h.Tags; Type = { TypeName = "string"; Annotation = None }; Default = None; Optional = false; Length = None }
                            BackendFields = fun _var -> Map.ofList [h.Name, varName]
                            PinFrontend = fun var code -> $"use {varName} = fixed (Encoding.UTF8.GetBytes({var}))" :: code
                            Read = fun var -> $"Marshal.PtrToStringAnsi(NativePtr.toNativeInt {var.[h.Name]})"
                        }
                    marshalInternal allFields (self :: acc) t
                elif h.Type.TypeName = "bool" then
                    let self = 
                        {
                            FrontendField = h
                            BackendFields = fun var -> Map.ofList [h.Name, $"(if {var} then 1 else 0)"]
                            PinFrontend = fun _ code -> code
                            Read = fun var -> $"({var.[h.Name]} <> 0)"
                        }
                    marshalInternal allFields (self :: acc) t
                    
                elif h.Type.TypeName = "size_t" then
                    let self = 
                        {
                            FrontendField = { h with Type = { h.Type with TypeName = "int64" } }
                            BackendFields = fun var -> Map.ofList [h.Name, $"unativeint({var})"]
                            PinFrontend = fun _ code -> code
                            Read = fun var -> $"int64({var.[h.Name]})"
                        }
                    marshalInternal allFields (self :: acc) t
                    
                elif h.Type.TypeName = "uint64_t" then
                    let self = 
                        {
                            FrontendField = { h with Type = { h.Type with TypeName = "int64" } }
                            BackendFields = fun var -> Map.ofList [h.Name, $"uint64({var})"]
                            PinFrontend = fun _ code -> code
                            Read = fun var -> $"int64({var.[h.Name]})"
                        }
                    marshalInternal allFields (self :: acc) t
                    
                elif h.Type.TypeName = "uint32_t" then
                    let self = 
                        {
                            FrontendField = { h with Type = { h.Type with TypeName = "int" } }
                            BackendFields = fun var -> Map.ofList [h.Name, $"uint32({var})"]
                            PinFrontend = fun _ code -> code
                            Read = fun var -> $"int({var.[h.Name]})"
                        }
                    marshalInternal allFields (self :: acc) t
                else
                    match tryResolveType h.Type with
                    | Some (Object _) when Option.isNone h.Type.Annotation->
                        let self =
                            {
                                FrontendField = h
                                BackendFields = fun var -> Map.ofList [h.Name, $"{var}.Handle"]
                                PinFrontend = fun _ code -> code
                                Read = fun var -> $"new {frontendName false h.Type}({var.[h.Name]})"
                            }
                        marshalInternal allFields (self :: acc) t
                    | Some (Struct s | CallbackInfo s) ->
                        if s.Name = "string view" then

                            let arrName = $"_{camelCase h.Name}Arr"
                            let ptrName = $"_{camelCase h.Name}Ptr"
                            let structName = $"_{camelCase h.Name}Len"

                            let wrap (var : string) (code : list<string>) =
                                [
                                    yield $"let {arrName} = Encoding.UTF8.GetBytes({var})"
                                    yield $"use {ptrName} = fixed {arrName}"
                                    yield $"let {structName} = WebGPU.Raw.StringView({ptrName}, unativeint {arrName}.Length)"
                                    yield! code
                                ]

                            let self =
                                {
                                    FrontendField = { h with Type = { TypeName = "string"; Annotation = None } }
                                    BackendFields = fun var -> Map.ofList [h.Name, structName]
                                    PinFrontend = wrap
                                    Read = fun var ->
                                        $"let {ptrName} = NativePtr.toNativeInt({var.[h.Name]}.Data) in if {ptrName} = 0n then null else Marshal.PtrToStringUTF8({ptrName}, int({var.[h.Name]}.Length))"
                                        // match h.Type.Annotation with
                                        // | Some ("*" | "const*") ->
                                        //     $"let m = NativePtr.toByRef {var.[h.Name]} in {frontendName false h.Type}.Read(&m)" //$"//TODO1 {var}"
                                        // | _ ->
                                        //     $"{frontendName false h.Type}.Read(&{var.[h.Name]})"
                                }
                            marshalInternal allFields (self :: acc) t
                        else
                            let varName = $"_{camelCase h.Name}Ptr"
                            
                            let wrap (var : string) (code : list<string>) =
                                match h.Type.Annotation with
                                | Some "*" ->
                                    [
                                        yield $"let mutable {var}Copy = {var}"
                                        yield "try"
                                        yield $"    {var}.Pin(fun {varName} ->"
                                        yield $"        if NativePtr.toNativeInt {varName} = 0n then"
                                        let len = List.length code
                                        yield $"            let mutable {var}Native = Unchecked.defaultof<WebGPU.Raw.{pascalCase h.Type.TypeName}>"
                                        yield $"            use {varName} = fixed &{var}Native"
                                        for i,c in List.indexed code do
                                            if i < len - 1 then
                                                yield $"            {c}"
                                            else
                                                yield $"            let _ret = {c}"
                                                yield $"            {var}Copy <- {pascalCase h.Type.TypeName}.Read(&{var}Native)"
                                                yield $"            _ret"
                                        
                                        yield $"        else"
                                        let len = List.length code
                                        for i,c in List.indexed code do
                                            if i < len - 1 then
                                                yield $"            {c}"
                                            else
                                                yield $"            let _ret = {c}"
                                                yield $"            let {var}Result = NativePtr.toByRef {varName}"
                                                yield $"            {var}Copy <- {pascalCase h.Type.TypeName}.Read(&{var}Result)"
                                                yield $"            _ret"
                                        yield $"    )"
                                        yield "finally"
                                        yield $"    {var} <- {var}Copy"
                                    ]
                                          
                                | _ -> 
                                    [
                                        yield $"{var}.Pin(fun {varName} ->"
                                        for c in code do
                                            yield $"    {c}"
                                        yield $")"
                                    ]
                            
                            let access = 
                                match h.Type.Annotation with
                                | Some ("*" | "const*") ->
                                    varName
                                | _ ->
                                    $"(if NativePtr.toNativeInt {varName} = 0n then Unchecked.defaultof<_> else NativePtr.read {varName})"
                            
                            let self =
                                {
                                    FrontendField = h
                                    BackendFields = fun var -> Map.ofList [h.Name, access]
                                    PinFrontend = wrap
                                    Read = fun var ->
                                        match h.Type.Annotation with
                                        | Some ("*" | "const*") ->
                                            $"let m = NativePtr.toByRef {var.[h.Name]} in {frontendName false h.Type}.Read(&m)" //$"//TODO1 {var}"
                                        | _ ->
                                            $"{frontendName false h.Type}.Read(&{var.[h.Name]})"
                                }
                            marshalInternal allFields (self :: acc) t
                    | Some (Delegate d) ->
                        match t with
                        | h1 :: t when FieldDef.isUserData h1 && false ->
                            let delName = $"_{camelCase h.Name}Del"
                            let varName = $"_{camelCase h.Name}Ptr"
                            let userDataName = $"_{camelCase h.Name}UserData"
                            let subName = $"_{camelCase h.Name}Sub"
                            let mm = marshalInternal allFields [] d.Args
                    
                            let backendArgDef =
                                let all =
                                    (Map.empty, mm)
                                    ||> List.fold (fun s m -> Map.union s (m.BackendFields(camelCase m.FrontendField.Name))) 
                                
                                d.Args |> List.map (fun d -> camelCase d.Name)
                                //     all.[d.Name]    
                                // )
                                // mm |> List.collect (fun m ->
                                //     m.BackendFields (camelCase m.FrontendField.Name)
                                //     |> List.map snd
                                //     |> List.map (fun f -> $"{camelCase f.Name}")
                                // )
                                |> String.concat " "
                            
                            let realArgs =
                                let args = mm |> List.map (fun m -> $"_{camelCase m.FrontendField.Name}")
                                subName :: args
                                |> String.concat ", "
                            
                            let wrap (var : string) (code : list<string>) =
                                [
                                    yield $"let mutable {subName} = {{ new IDisposable with member __.Dispose() = () }}"
                                    yield $"let {delName} = WebGPU.Raw.{frontendName false h.Type}(fun {backendArgDef} ->"
                                    let names = d.Args |> List.map (fun a -> a.Name, camelCase a.Name) |> Map.ofList
                                    for a in mm do
                                        let name = camelCase a.FrontendField.Name
                                        let code = names |> a.Read
                                        yield $"    let _{name} = {code}"
                                    yield $"    {var}.Invoke({realArgs})"
                                    yield $")"
                                    yield $"let struct({varName}, {userDataName}, {subName}1) = WebGPU.Raw.WebGPUCallbacks.Register({delName})"
                                    yield $"{subName} <- {subName}1"
                                    // yield $"let {gcName} = GCHandle.Alloc({delName})"
                                    // yield $"let {varName} = Marshal.GetFunctionPointerForDelegate({delName})"
                                    yield! code
                                ]
                            let self =
                                {
                                    FrontendField = h
                                    BackendFields = fun var -> Map.ofList [h.Name, varName; h1.Name, userDataName]
                                    PinFrontend = wrap
                                    Read = fun var -> $"failwith \"cannot read callbacks\"//TODO2 {var}"
                                }
                            marshalInternal allFields (self :: acc) t
                            
                        | _ ->
                            let gcName = $"_{camelCase h.Name}GC"
                            let delName = $"_{camelCase h.Name}Del"
                            let varName = $"_{camelCase h.Name}Ptr"
                            let mm = marshalInternal allFields [] d.Args
                    
                            let backendArgDef =
                                let all =
                                    (Map.empty, mm)
                                    ||> List.fold (fun s m -> Map.union s (m.BackendFields(camelCase m.FrontendField.Name))) 
                                
                                d.Args |> List.map (fun d -> camelCase d.Name)
                                |> String.concat " "
                            
                            let realArgs =
                                let args = mm |> List.map (fun m -> $"_{camelCase m.FrontendField.Name}")
                                let a0 = $"{{ new IDisposable with member __.Dispose() = {gcName}.Free() }}"
                                a0 :: args |> String.concat ", "
                            
                            let wrap (var : string) (code : list<string>) =
                                [
                                    yield $"let mutable {gcName} = Unchecked.defaultof<GCHandle>"
                                    yield $"let mutable {delName} = Unchecked.defaultof<WebGPU.Raw.{frontendName false h.Type}>"
                                    yield $"{delName} <- WebGPU.Raw.{frontendName false h.Type}(fun {backendArgDef} ->"
                                    //yield $"    {gcName}.Free()"
                                    let names = d.Args |> List.map (fun a -> a.Name, camelCase a.Name) |> Map.ofList
                                    for a in mm do
                                        let name = camelCase a.FrontendField.Name
                                        let code = names |> a.Read
                                        yield $"    let _{name} = {code}"
                                    yield $"    {var}.Invoke({realArgs})"
                                    yield $")"
                                    yield $"{gcName} <- GCHandle.Alloc({delName})"
                                    
                                    yield $"let {varName} = Marshal.GetFunctionPointerForDelegate({delName})"
                                    // yield $"let {gcName} = GCHandle.Alloc({delName})"
                                    // yield $"let {varName} = Marshal.GetFunctionPointerForDelegate({delName})"
                                    for c in code do
                                        yield $"{c}"
                                ]
                            let self =
                                {
                                    FrontendField = h
                                    BackendFields = fun var -> Map.ofList [h.Name, varName]
                                    PinFrontend = wrap
                                    Read = fun var -> $"failwith \"cannot read callbacks\"//TODO2 {var}"
                                }
                            marshalInternal allFields (self :: acc) t
                    | _ ->
                        simple()
            | [] ->
                List.rev acc
           
    let rec marshal (a : list<FieldDef>) =
        marshalInternal a [] a
        
    let print() =
        
        let b = System.Text.StringBuilder()
        let printfn fmt = fmt |> Printf.kprintf (fun str -> b.AppendLine str |> ignore)
        
        
        printfn "namespace rec WebGPU"
        printfn "open System"
        printfn "open System.Text"
        printfn "open System.Runtime.InteropServices"
        printfn "open Microsoft.FSharp.NativeInterop"
        printfn "#nowarn \"9\""
        printfn "#nowarn \"26\""
        printfn "#nowarn \"1182\""
        
        printfn "[<AllowNullLiteral>]"
        printfn "type IExtension ="
        printfn "    abstract member Pin<'r> : action : (nativeint -> 'r) -> 'r"
        let chainRootTypes =
            all |> Seq.collect (fun a ->
                match a with
                | Struct def -> def.ChainRoots
                | _ -> []
            ) |> Set.ofSeq
            
        for c in chainRootTypes do
            printfn "[<AllowNullLiteral>]"
            printfn $"type I{pascalCase c}Extension = inherit IExtension"
            
        let sTypes = 
            match tryResolveType { TypeName = "s type"; Annotation = None } with
            | Some (Enum e) -> e.Values
            | _ -> failwith "bad s type"

        printfn "module private ExtensionDecoder ="
        printfn "    let decode<'a when 'a :> IExtension> (ptr : nativeint) : 'a ="
        printfn "        if ptr = 0n then"
        printfn "            Unchecked.defaultof<'a>"
        printfn "        else"
        printfn "            let sType = NativePtr.read (NativePtr.ofNativeInt<SType> (ptr + nativeint sizeof<nativeint>))"
        let getSubTypes (chainRootType : string) =
            all |> Array.choose (fun t ->
                match t with
                | Struct s | CallbackInfo s ->
                    let isValid = s.ChainRoots |> List.exists (fun r -> r = chainRootType)
                    if isValid then Some s.Name
                    else None
                | _ ->
                    None
            )
        
        let mutable isFirst = true
        for root in chainRootTypes do
            let ii = if isFirst then "if" else "elif"
            printfn $"            {ii} typeof<'a> = typeof<I{pascalCase root}Extension> then"
            printfn "                match sType with"
            for s in getSubTypes root do
                match tryResolveType { TypeName = s; Annotation = None } with
                | Some (Struct sd) when not (List.isEmpty sd.ChainRoots) ->
                    printfn $"                | SType.{pascalCase s} ->"
                    printfn $"                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.{pascalCase s}> (ptr))"
                    printfn $"                    {pascalCase s}.Read(&rr) :> obj :?> 'a"
                | _ ->
                    ()
            printfn "                | _ -> failwithf \"bad s type: %%A\" sType" 
            isFirst <- false
        printfn $"            elif typeof<'a> = typeof<IExtension> then"
        printfn $"                Unchecked.defaultof<'a> // TODO"
        printfn $"            else"
        printfn $"                failwithf \"bad extension type: %%A\" typeof<'a>"
        
        printfn "[<AbstractClass; Sealed>]"
        printfn "type private PinHelper() ="
        printfn $"    static member inline PinNullable<'r>(x : IExtension, action : nativeint -> 'r) = "
        printfn $"        if isNull x then action 0n"
        printfn $"        else x.Pin action"
        
        
        for a in all do
            match a with
            | Enum e ->
                ()
            | Alias a ->
                printfn $"type {pascalCase a.Name} = {frontendName false a.Type}"
            | Delegate d ->
                let marshal = marshal d.Args
                let types =
                    match marshal with
                    | [] -> "IDisposable"
                    | _ -> 
                        let args = marshal |> List.map (fun m -> $"{camelCase m.FrontendField.Name} : {frontendName false m.FrontendField.Type}") 
                        "IDisposable" :: args |> String.concat " * "
                let ret = frontendName false d.Return
                printfn $"type {pascalCase d.Name} = delegate of {types} -> {ret}"
                
            | Native _ | Function _  ->
                ()
            | Struct s | CallbackInfo s ->
                let marshal = marshal s.Fields
                
                let extensible = Option.isSome s.Extensible //&& Set.contains s.Name chainRootTypes
                    
                let chained =
                    Option.isSome s.Chained 
                
                let fields =
                    if chained then
                        { Name = "next in chain"; Tags = []; Type = { TypeName = "void *"; Annotation = None }; Default = None; Optional = false; Length = None } ::
                        { Name = "s type"; Tags = []; Type = { TypeName = "s type"; Annotation = None }; Default = None; Optional = false; Length = None } ::
                        s.Fields
                    elif extensible then
                        { Name = "next in chain"; Tags = []; Type = { TypeName = "void *"; Annotation = None }; Default = None; Optional = false; Length = None } ::
                        s.Fields
                    else
                        s.Fields
            
                match marshal with
                | [] when not extensible && not chained ->
                    printfn $"type {pascalCase s.Name}() ="
                    printfn $"    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]"
                    printfn $"    member this.Pin<'r>(action : nativeptr<WebGPU.Raw.{pascalCase s.Name}> -> 'r) : 'r = "
                    printfn $"        action (NativePtr.ofNativeInt 0n)"
                | _ ->
                    let fielddef =
                        marshal |> List.map (fun m ->
                            let f = m.FrontendField
                            let name = pascalCase f.Name
                            $"{name} : {frontendName false f.Type}"
                        )
                        
                    printfn $"type {pascalCase s.Name} = "
                    printfn "    {"
                    if extensible || chained then
                        let rootName = 
                            if chained then
                                match s.ChainRoots with
                                | [a] -> a
                                | roots -> List.head roots //failwithf "bad roots: %A" roots
                            else s.Name
                            
                        if Set.contains rootName chainRootTypes then
                            printfn $"        Next : I{pascalCase rootName}Extension"
                        else
                            printfn $"        Next : IExtension"

                    
                    for d in fielddef do
                        printfn $"        {d}"
                    printfn "    }"
                    
                    printfn $"    static member Null = Unchecked.defaultof<{pascalCase s.Name}>"
                    
                    printfn $"    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]"
                    printfn $"    member this.Pin<'r>(action : nativeptr<WebGPU.Raw.{pascalCase s.Name}> -> 'r) : 'r = "
                    printfn $"        if isNull (this :> obj) then"
                    // printfn $"            let mutable v = Unchecked.defaultof<WebGPU.Raw.{pascalCase s.Name}>"
                    // printfn $"            use ptr = fixed &v"
                    printfn $"            action (NativePtr.ofNativeInt 0n)"
                    printfn $"        else"
                    
                    let marshal =
                        if chained then
                            {
                                BackendFields = fun _ ->
                                    Map.ofList [
                                        "next in chain", "nextInChain"
                                        "s type", "sType"
                                    ]
                                FrontendField = { Name = "Next"; Tags = []; Type = { TypeName = ""; Annotation = None }; Default = None; Optional = false; Length = None }
                                Read = fun a -> a.["next in chain"]
                                PinFrontend = fun a b ->
                                    [
                                        yield $"PinHelper.PinNullable({a}, fun nextInChain ->"
                                        yield $"    let sType = SType.{pascalCase s.Name}"
                                        for b in b do yield $"    {b}"
                                        yield ")"
                                    ]
                            } :: marshal
                        elif extensible then
                            {
                                BackendFields = fun _ ->
                                    Map.ofList [
                                        "next in chain", "nextInChain"
                                    ]
                                FrontendField = { Name = "Next"; Tags = []; Type = { TypeName = ""; Annotation = None }; Default = None; Optional = false; Length = None }
                                Read = fun a -> a.["next in chain"]
                                PinFrontend = fun a b ->
                                    [
                                        yield $"PinHelper.PinNullable({a}, fun nextInChain ->"
                                        for b in b do yield $"    {b}"
                                        yield ")"
                                    ]
                            } :: marshal
                        else
                            marshal
                    
                    
                        
                    let body = 
                        pinStruct "this" marshal (fun pinned ->
                            let backendName = $"WebGPU.Raw.{pascalCase s.Name}"
                            let args =
                                fields |> List.map (fun f ->
                                    match Map.tryFind f.Name pinned with
                                    | Some v -> v
                                    | None -> "Unchecked.defaultof<_>"
                                )
                            //let args = List.map fst pinned 
                            [
                                yield $"let mutable value ="
                                yield $"    new {backendName}("
                                for i, a in List.indexed args do
                                    if i < args.Length - 1 then
                                        yield $"        {a},"
                                    else
                                        yield $"        {a}"
                                yield $"    )"
                                yield "use ptr = fixed &value"
                                yield "action ptr"
                            ]
                        )
                        
                    for b in body do
                        printfn "            %s" b
                        
                    if not (List.isEmpty s.ChainRoots) then
                        printfn $"    interface IExtension with"
                        printfn $"        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(fun ptr -> action(NativePtr.toNativeInt ptr))"
                    for r in s.ChainRoots do
                        if Set.contains r chainRootTypes then
                            printfn $"    interface I{pascalCase r}Extension"
                
                        
                    // printfn $"        use ptr ="
                    // printfn "            fixed [| {"
                    // for (f, real) in realAndFields do
                    //     
                    //     printfn "                WebGPU.Raw.%s.%s = %s" (pascalCase s.Name) (pascalCase f.Name) real
                    // printfn "            } |]"
                    // printfn "        action ptr"
                    () // TODO
                    
                    
                printfn $"    interface WebGPU.Raw.IPinnable<WebGPU.Raw.{pascalCase s.Name}> with"
                printfn $"        member x.Pin(action) = x.Pin(action)"
                    
                printfn $"    static member Read(backend : inref<WebGPU.Raw.{pascalCase s.Name}>) = "
                
                match marshal with
                | [] when not extensible && not chained ->
                    printfn $"        {pascalCase s.Name}()"
                | _ -> 
                    let values =
                        let all =
                            fields
                            |> List.map (fun f -> f.Name, $"backend.{pascalCase f.Name}")
                            |> Map.ofList
                            // (Map.empty, marshal)
                            // ||> List.fold (fun s m ->
                            //     let k = m.BackendFields "hansi"
                            //     Map.union s (m.BackendFields($"backend.{pascalCase m.FrontendField.Name}")))
                            //|> Map.map (fun _ v -> $"backend.{pascalCase v}")
                            
                        marshal |> List.map (fun m ->
                            pascalCase m.FrontendField.Name, m.Read all
                        )
                    
                    printfn "        {"
                    if extensible || chained then
                        let rootName = 
                            if chained then
                                match s.ChainRoots with
                                | [a] -> a
                                | roots -> List.head roots //failwithf "bad roots: %A" roots
                            else s.Name
                        if Set.contains rootName chainRootTypes then
                            printfn $"            Next = ExtensionDecoder.decode<I{pascalCase rootName}Extension> backend.NextInChain"
                        else
                            printfn $"            Next = ExtensionDecoder.decode<IExtension> backend.NextInChain"
                        
                    for (name, value) in values do
                        
                        printfn $"            {name} = {value}"
                    printfn "        }"
                    
            | Object o ->
                printfn $"type {pascalCase o.Name} internal(handle : nativeint) ="
                printfn "    member x.Handle = handle"
                
                printfn $"    override x.ToString() = $\"{pascalCase o.Name}(0x%%08X{{handle}})\""
                printfn "    override x.GetHashCode() = hash handle"
                printfn "    override x.Equals(obj) ="
                printfn "        match obj with"
                printfn $"        | :? {pascalCase o.Name} as other -> other.Handle = x.Handle"
                printfn "        | _ -> false"
                
                printfn $"    static member Null = new {pascalCase o.Name}(0n)"
                
                let (|SimpleGetter|_|) (m : FunctionDef) =
                    match m.Args with
                    | [] when m.Name.StartsWith "get " ->
                        Some ()
                    | _ ->
                        None
                        
                let (|Getter|_|) (m : FunctionDef) =
                    match m.Args with
                    | [arg] when arg.Type.Annotation = Some "*" && m.Name.StartsWith "get " ->
                        let arg1 = { arg with Type = { arg.Type with Annotation = None } }
                        match tryResolveType m.Return with
                        | Some (Native { Name = "bool" }) ->
                            Some (Some "true", arg1)
                        | Some (Native { Name = "void" }) ->
                            Some (None, arg1)
                        | Some t when t.Name = "status" ->
                            Some (Some "Status.Success", arg1)
                        | _ ->
                            None
                    | _ ->
                        None
                
                for m in o.Methods do
                    match m with
                    | SimpleGetter ->
                        let ret =
                            marshal [
                                { Name = "result"; Type = m.Return; Tags = []; Default = None; Optional = false; Length = None }
                            ] |> List.head
                        let methName = o.Name + " " + m.Name
                        let read = ret.Read (Map.ofList ["result", "res"])
                        
                        let propertyName =
                            if m.Name.StartsWith "get " then m.Name.Substring 4
                            else m.Name
                        
                        printfn $"    member this.{pascalCase propertyName} : {frontendName false ret.FrontendField.Type} ="
                        printfn $"        let mutable res = WebGPU.Raw.WebGPU.{pascalCase methName}(handle)"
                        printfn $"        {read}"
                        
                    | Getter(goodStatus, arg) ->
                        let ret = marshal [arg] |> List.head
                        let methName = o.Name + " " + m.Name
                        let read = ret.Read (Map.ofList [arg.Name, "res"])
                        
                        let propertyName =
                            if m.Name.StartsWith "get " then m.Name.Substring 4
                            else m.Name
                        
                        printfn $"    member _.{pascalCase propertyName} : {frontendName false ret.FrontendField.Type} ="
                        printfn "        let mutable res = Unchecked.defaultof<_>"
                        printfn "        let ptr = fixed &res"
                        if Option.isSome goodStatus then
                            printfn $"        let status = WebGPU.Raw.WebGPU.{pascalCase methName}(handle, ptr)"
                            printfn $"        if status <> {goodStatus.Value} then failwith \"{pascalCase m.Name} failed\""
                        else
                            printfn $"        WebGPU.Raw.WebGPU.{pascalCase methName}(handle, ptr)"
                            
                        printfn $"        {read}"
                    | _ -> 
                        let ret =
                            marshal [{ Name = "result"; Tags = []; Type = m.Return; Default = None; Optional = false; Length = None }]
                            |> List.head
                            
                        let mm = marshal m.Args

                        let argdef =
                            mm |> List.map (fun m ->
                                $"{camelCase m.FrontendField.Name} : {frontendName false m.FrontendField.Type}" 
                            )
                            |> String.concat ", "
                                    
                        let methName = o.Name + " " + m.Name
                        printfn $"    member _.{pascalCase m.Name}({argdef}) : {frontendName false ret.FrontendField.Type} ="
                        
                        let body = 
                            pinArgs mm (fun pinned ->
                                let argNames = 
                                    m.Args |> List.map (fun a -> 
                                        match Map.tryFind a.Name pinned with
                                        | Some v -> v
                                        | None -> "Unchecked.defaultof<_>"
                                    )
                                let arguse =
                                    "handle" :: argNames
                                    |> String.concat ", "
                                
                                
                                let call = $"WebGPU.Raw.WebGPU.{pascalCase methName}({arguse})"
                                
                                [
                                    $"let res = {call}"
                                    ret.Read (Map.ofList ["result", "res"])
                                ]
                                //
                                // match tryResolveType m.Return with
                                // | Some (Object _) ->
                                //     [$"new {frontendName false m.Return}({call})"]
                                // | _ ->
                                //     [call]
                            )
                        
                        for b in body do
                            printfn "        %s" b
                
                let hasRelease = o.Methods |> List.exists (fun m -> m.Name = "release")
                if hasRelease then
                    printfn "    member private x.Dispose(disposing : bool) ="
                    printfn "        if disposing then System.GC.SuppressFinalize(x)"
                    printfn "        x.Release()"
                    printfn "    member x.Dispose() = x.Dispose(true)"
                    printfn "    override x.Finalize() = x.Dispose(false)"
                    printfn "    interface System.IDisposable with"
                    printfn "        member x.Dispose() = x.Dispose(true)"
                    
        File.WriteAllText(Path.Combine(__SOURCE_DIRECTORY__, "src", "WebGPU", "Frontend.fs"), b.ToString())

        
open Frontend

Enums.print()
Native.print (Path.Combine(__SOURCE_DIRECTORY__, "src", "WebGPU", "WebGPU.cpp")) true
Native.print (Path.Combine(__SOURCE_DIRECTORY__, "src", "WebGPUNative", "WebGPU.cpp")) false
RawWrapper.print()
Frontend.print()
//     
// let referenced = HashSet()
// for a in all do
//     referenced.UnionWith a.ReferencedTypes
//     
// let annotations = referenced |> Seq.choose (fun t -> t.Annotation) |> Set.ofSeq
//
// for a in annotations do
//     printfn "%s" a
//     
// for a in referenced do
//     if not (table.ContainsKey a.TypeName) then
//         failwithf "MISSING TYPE: %A" a.TypeName
//     
//         
// let countPointers (a : option<string>) =
//     match a with
//     | Some a -> a.ToCharArray() |> Array.sumBy(fun c -> if c = '*' then 1 else 0)
//     | None -> 0
//     

//               
//         
// let nativeTypeName (t : TypeRef) (annotation : option<string>) =
//     let mutable res = 
//         match t.TypeName with
//         | "size_t" -> "nativeint"
//         | "void *" -> "nativeint"
//         | "string view" -> "nativeptr<byte>"
//         | _ -> pascalCase t.TypeName
//     let ptr = countPointers annotation
//     for i in 1 .. ptr do
//         res <- sprintf "nativeptr<%s>" res
//     res
//     
//
//     
// let printStruct (s : StructDef) =
//     printfn "[<Struct; StructLayout(LayoutKind.Sequential)>]"
//     printfn "type %s =" s.Name
//     printfn "    {"
//     for f in s.Fields do
//         let typ = nativeTypeName f.Type f.Annotation
//         let name = f.Name
//         
//         printfn "        %s : %s" name typ
//     printfn "    }"
//     printfn ""
//     
// for KeyValue(name, ptr) in functionPointers do
//     let args =
//         ptr.Args |> List.map (fun f ->
//             let typ = nativeTypeName f.Type f.Annotation
//             let name = f.Name
//             sprintf "%s : %s" name typ
//         ) |> String.concat " * "
//     
//     printfn "type %s = delegate of %s -> unit" (pascalCase name) args
//     
//     
//         
// printStruct  structs.["DeviceDescriptor"]
//


