﻿namespace Aardvark.Application.Slim

open Aardvark.Rendering
open global.WebGPU
open Aardvark.Base
open Aardvark.Rendering.WebGPU
open Silk.NET.GLFW
open System.Runtime.InteropServices
open System.Runtime.CompilerServices


type private GetSurfaceDescriptorNSWindowDelegate = delegate of nativeint -> nativeint

type GLFWSurfaceDescriptor = 
    {
        Glfw : Glfw
        Label : string
        Window : nativeptr<Silk.NET.GLFW.WindowHandle>
    }

[<AbstractClass; Sealed>]
type WebGPUGlfwExtensions private() =
    
    static let GetSurfaceDescriptorNSWindow =
        lazy (
            let lib = Aardvark.LoadLibrary(typeof<WebGPU>.Assembly, "libWebGPUNative.dylib")
            let ptr = Aardvark.GetProcAddress(lib, "GetSurfaceDescriptorNSWindow")
            Marshal.GetDelegateForFunctionPointer<GetSurfaceDescriptorNSWindowDelegate> ptr
        )
    
    [<Extension>]
    static member CreateGLFWSurface(this : Instance, descriptor : GLFWSurfaceDescriptor) =
        let win = Silk.NET.GLFW.GlfwNativeWindow(descriptor.Glfw, descriptor.Window)
        let next = 
            if win.Win32.HasValue then
                let struct(hwnd, _, hinstance) = win.Win32.Value
                { Next = null; Hinstance = hinstance; Hwnd = hwnd } :> ISurfaceDescriptorExtension
            elif win.Cocoa.HasValue then
                let layer = GetSurfaceDescriptorNSWindow.Value.Invoke(win.Cocoa.Value)
                { Next = null; Layer = layer } :> ISurfaceDescriptorExtension
            elif win.X11.HasValue then
                let struct(display, window) = win.X11.Value
                { Next = null; Display = display; Window = int64 window } :> ISurfaceDescriptorExtension
            elif win.Wayland.HasValue then
                let struct(display, surface) = win.Wayland.Value
                { Next = null; Display = display; Surface = surface } :> ISurfaceDescriptorExtension
            else
                failwith $"bad platform"
                
        let surfaceDesc =
            {
                SurfaceDescriptor.Label = descriptor.Label
                Next = next
            }
        
        this.CreateSurface surfaceDesc
             

type WebGPUApplication(debug : bool, instance : Instance, adapter : Adapter, device : Device, runtime : Runtime) =
    inherit Aardvark.Application.Slim.Application(runtime, WebGPUApplication.Interop(instance, adapter, device), false)
    
    static member private Interop(instance : Instance, adapter : Adapter, device : Device) =
        { new Aardvark.Glfw.IWindowInterop with
            
            member this.Dispose() = ()
            member this.Boot(glfw) =
                ()
                
            member this.CreateSurface(runtime,config,glfw,window) =
                let surf = 
                    instance.CreateGLFWSurface {
                        Glfw = glfw
                        Label = null
                        Window = window
                    }
                    
                let cap = surf.GetCapabilities(adapter)
                let (w, h) = glfw.GetWindowSize(window)
                
                let format =
                    let formats = 
                        cap.Formats |> Array.sortBy (fun f ->
                            match f with
                            | TextureFormat.BGRA8Unorm
                            | TextureFormat.RGBA8Unorm -> 0
                            | _ -> 1
                        )
                    formats.[0]
                
                let alphaMode =
                    let modes = 
                        cap.AlphaModes |> Array.sortBy (fun m ->
                            if m = CompositeAlphaMode.Opaque then 0 else 1
                        )
                    modes.[0]
                
                let presentMode =
                    let modes = 
                        cap.PresentModes |> Array.sortBy (function
                            | PresentMode.Fifo -> if config.vsync then 0 else 5
                            | PresentMode.FifoRelaxed -> if config.vsync then 1 else 6
                            | PresentMode.Mailbox -> 2
                            | PresentMode.Immediate -> if config.vsync then 3 else 0
                            | _ -> 4
                        )
                    modes.[0]
                    
                Log.start "Creating surface"
                
                Log.line "Format: %A" format
                Log.line "Usage: %A" cap.Usages
                Log.line "AlphaMode: %A" alphaMode
                Log.line "PresentMode: %A" presentMode
                Log.stop()
                    
                let aardFormat = Translations.TextureFormat.toAardvark format
                
                surf.Configure {
                    SurfaceConfiguration.Device = device
                    Format = format
                    Usage = cap.Usages
                    ViewFormats = [| format |]
                    AlphaMode = alphaMode
                    Width = w
                    Height = h
                    PresentMode = presentMode
                }
                
                
                
                let signature =
                    device.CreateFramebufferSignature(
                        1, Map.ofList [0, { Name = DefaultSemantic.Colors; Format = aardFormat }], Some Aardvark.Rendering.TextureFormat.Depth24Stencil8
                    )
                
                
                { new Aardvark.Glfw.IWindowSurface with
                    member x.Dispose() = ()
                    member this.CreateSwapchain(size) =
                        
                        let depth =
                            device.CreateTexture {
                                Next = null
                                Label = null
                                Usage = TextureUsage.RenderAttachment
                                Dimension = TextureDimension.D2D
                                Size = { Width = size.X; Height = size.Y; DepthOrArrayLayers = 1 }
                                Format = WebGPU.TextureFormat.Depth24PlusStencil8
                                MipLevelCount = 1
                                SampleCount = 1
                                ViewFormats = [| TextureFormat.Depth24PlusStencil8 |]
                            }
                        
                        let depthView =
                            depth.CreateView {
                                Next = null
                                Label = null
                                Format = TextureFormat.Depth24PlusStencil8
                                Dimension = TextureViewDimension.D2D
                                BaseMipLevel = 0
                                MipLevelCount = 1
                                BaseArrayLayer = 0
                                ArrayLayerCount = 1
                                Aspect = WebGPU.TextureAspect.All
                                Usage = TextureUsage.RenderAttachment
                            }
                        
                        let viewCache = Dict<Texture, TextureView>()
                        
                        { new Aardvark.Glfw.ISwapchain with
                            member x.Dispose() =
                                depthView.Dispose()
                                depth.Dispose()
                                for t in viewCache.Values do
                                    t.Dispose()
                                viewCache.Clear()
                                    
                            member x.Size = size
                            member x.Run(task, _) =
                                use color = surf.CurrentTexture.Texture
                                let colorView =
                                    viewCache.GetOrCreate(color, fun color ->
                                        color.CreateView {
                                            Next = null
                                            Label = "Vernon"
                                            Format = format
                                            Dimension = TextureViewDimension.D2D
                                            BaseMipLevel = 0
                                            MipLevelCount = 1
                                            BaseArrayLayer = 0
                                            ArrayLayerCount = 1
                                            Aspect = TextureAspect.Undefined
                                            Usage = cap.Usages
                                        }
                                    )
                                    
                                
                                let fbo =
                                    new Framebuffer(signature, size, [| colorView |], Some depthView, [|color|], Some depth)
                                
                                
                                task.Run(fbo)
                                surf.Present()
                                true
                        }
                            
                    member this.Handle = null
                    member this.Signature = signature
                }
            member this.WindowHints(config,glfw) =
                glfw.WindowHint(WindowHintClientApi.ClientApi, ClientApi.NoApi)
        }
    
    override x.Destroy() =
        ()
    
    static member Create(debug : bool) =
        task {
            let instance = WebGPU.CreateInstance()
            
            let thread = 
                startThread <| fun () ->
                    while true do
                        instance.ProcessEvents()
            
            let! adapter = instance.CreateAdapter()
                
            Log.start "WebGPUApplication"
            Log.line "Vendor:            %s" adapter.Info.Vendor
            Log.line "Architecture:      %s" adapter.Info.Architecture
            Log.line "Device:            %s" adapter.Info.Device
            Log.line "Description:       %s" adapter.Info.Description
            Log.line "BackendType:       %A" adapter.Info.BackendType
            Log.line "AdapterType:       %A" adapter.Info.AdapterType
            Log.line "VendorID:          0x%08X" adapter.Info.VendorID
            Log.line "DeviceID:          0x%08X" adapter.Info.DeviceID
            
            Log.start "Features"
            
            let mutable unknown = ResizeArray()
            for f in adapter.Features.Features do
                let str = string f
                match System.Int32.TryParse str with
                | (true, v) -> unknown.Add (sprintf "0x%X" v)
                | _ -> Log.line "%s" str
            
            if unknown.Count > 0 then
                Log.line "+%d Unknown Features" unknown.Count
            
            Log.stop()
            
            Log.stop()
                
            
                
            let! device =
                adapter.RequestDeviceAsync {
                    Next = null
                    Label = "WebGPUApplication"
                    DebugOutput = debug
                    RequiredFeatures = adapter.Features.Features
                    RequiredLimits = adapter.Limits
                    DefaultQueue = { Label = "DefaultQueue" }
                }
                
            
                
            let runtime = new Runtime(device)
            return new WebGPUApplication(debug, instance, adapter, device, runtime)
        }
    
    member x.Debug = debug
    member x.Runtime = runtime
    member x.Instance = instance
    member x.Adapter = adapter
    member x.Device = device
    
    