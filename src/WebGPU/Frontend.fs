namespace rec WebGPU
open System
open System.Text
open System.Diagnostics
open System.Runtime.InteropServices
open Microsoft.FSharp.NativeInterop
#nowarn "9"
#nowarn "26"
#nowarn "1182"
[<AllowNullLiteral>]
type IExtension =
    abstract member Pin<'r> : action : (nativeint -> 'r) -> 'r
[<AllowNullLiteral>]
type IAdapterInfoExtension = inherit IExtension
[<AllowNullLiteral>]
type IBindGroupEntryExtension = inherit IExtension
[<AllowNullLiteral>]
type IBindGroupLayoutEntryExtension = inherit IExtension
[<AllowNullLiteral>]
type IBufferDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type IColorTargetStateExtension = inherit IExtension
[<AllowNullLiteral>]
type ICommandEncoderDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type ICompilationMessageExtension = inherit IExtension
[<AllowNullLiteral>]
type IDawnFormatCapabilitiesExtension = inherit IExtension
[<AllowNullLiteral>]
type IDeviceDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type IInstanceDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type ILimitsExtension = inherit IExtension
[<AllowNullLiteral>]
type IPipelineLayoutDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type IRenderPassColorAttachmentExtension = inherit IExtension
[<AllowNullLiteral>]
type IRenderPassDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type IRequestAdapterOptionsExtension = inherit IExtension
[<AllowNullLiteral>]
type ISamplerDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type IShaderModuleDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type ISharedFenceDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type ISharedFenceExportInfoExtension = inherit IExtension
[<AllowNullLiteral>]
type ISharedTextureMemoryBeginAccessDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type ISharedTextureMemoryDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type ISharedTextureMemoryEndAccessStateExtension = inherit IExtension
[<AllowNullLiteral>]
type ISharedTextureMemoryPropertiesExtension = inherit IExtension
[<AllowNullLiteral>]
type ISurfaceDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type ITextureDescriptorExtension = inherit IExtension
[<AllowNullLiteral>]
type ITextureViewDescriptorExtension = inherit IExtension
module private ExtensionDecoder =
    let decode<'a when 'a :> IExtension> (device : Device) (ptr : nativeint) : 'a =
        if ptr = 0n then
            Unchecked.defaultof<'a>
        else
            let sType = NativePtr.read (NativePtr.ofNativeInt<SType> (ptr + nativeint sizeof<nativeint>))
            if typeof<'a> = typeof<IAdapterInfoExtension> then
                match sType with
                | SType.DawnAdapterPropertiesPowerPreference ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnAdapterPropertiesPowerPreference> (ptr))
                    DawnAdapterPropertiesPowerPreference.Read(device, &rr) :> obj :?> 'a
                | SType.AdapterPropertiesMemoryHeaps ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.AdapterPropertiesMemoryHeaps> (ptr))
                    AdapterPropertiesMemoryHeaps.Read(device, &rr) :> obj :?> 'a
                | SType.AdapterPropertiesD3D ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.AdapterPropertiesD3D> (ptr))
                    AdapterPropertiesD3D.Read(device, &rr) :> obj :?> 'a
                | SType.AdapterPropertiesVk ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.AdapterPropertiesVk> (ptr))
                    AdapterPropertiesVk.Read(device, &rr) :> obj :?> 'a
                | SType.AdapterPropertiesSubgroupMatrixConfigs ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.AdapterPropertiesSubgroupMatrixConfigs> (ptr))
                    AdapterPropertiesSubgroupMatrixConfigs.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IBindGroupEntryExtension> then
                match sType with
                | SType.ExternalTextureBindingEntry ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.ExternalTextureBindingEntry> (ptr))
                    ExternalTextureBindingEntry.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IBindGroupLayoutEntryExtension> then
                match sType with
                | SType.StaticSamplerBindingLayout ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.StaticSamplerBindingLayout> (ptr))
                    StaticSamplerBindingLayout.Read(device, &rr) :> obj :?> 'a
                | SType.ExternalTextureBindingLayout ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.ExternalTextureBindingLayout> (ptr))
                    ExternalTextureBindingLayout.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IBufferDescriptorExtension> then
                match sType with
                | SType.BufferHostMappedPointer ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.BufferHostMappedPointer> (ptr))
                    BufferHostMappedPointer.Read(device, &rr) :> obj :?> 'a
                | SType.DawnFakeBufferOOMForTesting ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnFakeBufferOOMForTesting> (ptr))
                    DawnFakeBufferOOMForTesting.Read(device, &rr) :> obj :?> 'a
                | SType.DawnBufferDescriptorErrorInfoFromWireClient ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnBufferDescriptorErrorInfoFromWireClient> (ptr))
                    DawnBufferDescriptorErrorInfoFromWireClient.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IColorTargetStateExtension> then
                match sType with
                | SType.ColorTargetStateExpandResolveTextureDawn ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.ColorTargetStateExpandResolveTextureDawn> (ptr))
                    ColorTargetStateExpandResolveTextureDawn.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ICommandEncoderDescriptorExtension> then
                match sType with
                | SType.DawnEncoderInternalUsageDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnEncoderInternalUsageDescriptor> (ptr))
                    DawnEncoderInternalUsageDescriptor.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ICompilationMessageExtension> then
                match sType with
                | SType.DawnCompilationMessageUtf16 ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnCompilationMessageUtf16> (ptr))
                    DawnCompilationMessageUtf16.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IDawnFormatCapabilitiesExtension> then
                match sType with
                | SType.DawnDrmFormatCapabilities ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnDrmFormatCapabilities> (ptr))
                    DawnDrmFormatCapabilities.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IDeviceDescriptorExtension> then
                match sType with
                | SType.DawnTogglesDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnTogglesDescriptor> (ptr))
                    DawnTogglesDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.DawnCacheDeviceDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnCacheDeviceDescriptor> (ptr))
                    DawnCacheDeviceDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.DawnDeviceAllocatorControl ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnDeviceAllocatorControl> (ptr))
                    DawnDeviceAllocatorControl.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IInstanceDescriptorExtension> then
                match sType with
                | SType.DawnTogglesDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnTogglesDescriptor> (ptr))
                    DawnTogglesDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.DawnWGSLBlocklist ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnWGSLBlocklist> (ptr))
                    DawnWGSLBlocklist.Read(device, &rr) :> obj :?> 'a
                | SType.DawnWireWGSLControl ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnWireWGSLControl> (ptr))
                    DawnWireWGSLControl.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ILimitsExtension> then
                match sType with
                | SType.DawnTexelCopyBufferRowAlignmentLimits ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnTexelCopyBufferRowAlignmentLimits> (ptr))
                    DawnTexelCopyBufferRowAlignmentLimits.Read(device, &rr) :> obj :?> 'a
                | SType.DawnHostMappedPointerLimits ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnHostMappedPointerLimits> (ptr))
                    DawnHostMappedPointerLimits.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IPipelineLayoutDescriptorExtension> then
                match sType with
                | SType.PipelineLayoutPixelLocalStorage ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.PipelineLayoutPixelLocalStorage> (ptr))
                    PipelineLayoutPixelLocalStorage.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IRenderPassColorAttachmentExtension> then
                match sType with
                | SType.DawnRenderPassColorAttachmentRenderToSingleSampled ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnRenderPassColorAttachmentRenderToSingleSampled> (ptr))
                    DawnRenderPassColorAttachmentRenderToSingleSampled.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IRenderPassDescriptorExtension> then
                match sType with
                | SType.RenderPassMaxDrawCount ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.RenderPassMaxDrawCount> (ptr))
                    RenderPassMaxDrawCount.Read(device, &rr) :> obj :?> 'a
                | SType.RenderPassDescriptorExpandResolveRect ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.RenderPassDescriptorExpandResolveRect> (ptr))
                    RenderPassDescriptorExpandResolveRect.Read(device, &rr) :> obj :?> 'a
                | SType.RenderPassDescriptorResolveRect ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.RenderPassDescriptorResolveRect> (ptr))
                    RenderPassDescriptorResolveRect.Read(device, &rr) :> obj :?> 'a
                | SType.RenderPassPixelLocalStorage ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.RenderPassPixelLocalStorage> (ptr))
                    RenderPassPixelLocalStorage.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IRequestAdapterOptionsExtension> then
                match sType with
                | SType.RequestAdapterWebXROptions ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.RequestAdapterWebXROptions> (ptr))
                    RequestAdapterWebXROptions.Read(device, &rr) :> obj :?> 'a
                | SType.RequestAdapterWebGPUBackendOptions ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.RequestAdapterWebGPUBackendOptions> (ptr))
                    RequestAdapterWebGPUBackendOptions.Read(device, &rr) :> obj :?> 'a
                | SType.DawnTogglesDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnTogglesDescriptor> (ptr))
                    DawnTogglesDescriptor.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ISamplerDescriptorExtension> then
                match sType with
                | SType.YCbCrVkDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.YCbCrVkDescriptor> (ptr))
                    YCbCrVkDescriptor.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IShaderModuleDescriptorExtension> then
                match sType with
                | SType.ShaderSourceSPIRV ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.ShaderSourceSPIRV> (ptr))
                    ShaderSourceSPIRV.Read(device, &rr) :> obj :?> 'a
                | SType.ShaderSourceWGSL ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.ShaderSourceWGSL> (ptr))
                    ShaderSourceWGSL.Read(device, &rr) :> obj :?> 'a
                | SType.DawnShaderModuleSPIRVOptionsDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnShaderModuleSPIRVOptionsDescriptor> (ptr))
                    DawnShaderModuleSPIRVOptionsDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.ShaderModuleCompilationOptions ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.ShaderModuleCompilationOptions> (ptr))
                    ShaderModuleCompilationOptions.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ISharedFenceDescriptorExtension> then
                match sType with
                | SType.SharedFenceVkSemaphoreOpaqueFDDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDDescriptor> (ptr))
                    SharedFenceVkSemaphoreOpaqueFDDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceSyncFDDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceSyncFDDescriptor> (ptr))
                    SharedFenceSyncFDDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceVkSemaphoreZirconHandleDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleDescriptor> (ptr))
                    SharedFenceVkSemaphoreZirconHandleDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceDXGISharedHandleDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceDXGISharedHandleDescriptor> (ptr))
                    SharedFenceDXGISharedHandleDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceMTLSharedEventDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceMTLSharedEventDescriptor> (ptr))
                    SharedFenceMTLSharedEventDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceEGLSyncDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceEGLSyncDescriptor> (ptr))
                    SharedFenceEGLSyncDescriptor.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ISharedFenceExportInfoExtension> then
                match sType with
                | SType.SharedFenceVkSemaphoreOpaqueFDExportInfo ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDExportInfo> (ptr))
                    SharedFenceVkSemaphoreOpaqueFDExportInfo.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceSyncFDExportInfo ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceSyncFDExportInfo> (ptr))
                    SharedFenceSyncFDExportInfo.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceVkSemaphoreZirconHandleExportInfo ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleExportInfo> (ptr))
                    SharedFenceVkSemaphoreZirconHandleExportInfo.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceDXGISharedHandleExportInfo ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceDXGISharedHandleExportInfo> (ptr))
                    SharedFenceDXGISharedHandleExportInfo.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceMTLSharedEventExportInfo ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceMTLSharedEventExportInfo> (ptr))
                    SharedFenceMTLSharedEventExportInfo.Read(device, &rr) :> obj :?> 'a
                | SType.SharedFenceEGLSyncExportInfo ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedFenceEGLSyncExportInfo> (ptr))
                    SharedFenceEGLSyncExportInfo.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ISharedTextureMemoryBeginAccessDescriptorExtension> then
                match sType with
                | SType.SharedTextureMemoryVkImageLayoutBeginState ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryVkImageLayoutBeginState> (ptr))
                    SharedTextureMemoryVkImageLayoutBeginState.Read(device, &rr) :> obj :?> 'a
                | SType.SharedTextureMemoryD3DSwapchainBeginState ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryD3DSwapchainBeginState> (ptr))
                    SharedTextureMemoryD3DSwapchainBeginState.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ISharedTextureMemoryDescriptorExtension> then
                match sType with
                | SType.SharedTextureMemoryVkDedicatedAllocationDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryVkDedicatedAllocationDescriptor> (ptr))
                    SharedTextureMemoryVkDedicatedAllocationDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedTextureMemoryAHardwareBufferDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryAHardwareBufferDescriptor> (ptr))
                    SharedTextureMemoryAHardwareBufferDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedTextureMemoryDmaBufDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryDmaBufDescriptor> (ptr))
                    SharedTextureMemoryDmaBufDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedTextureMemoryOpaqueFDDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryOpaqueFDDescriptor> (ptr))
                    SharedTextureMemoryOpaqueFDDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedTextureMemoryZirconHandleDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryZirconHandleDescriptor> (ptr))
                    SharedTextureMemoryZirconHandleDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedTextureMemoryDXGISharedHandleDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryDXGISharedHandleDescriptor> (ptr))
                    SharedTextureMemoryDXGISharedHandleDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedTextureMemoryIOSurfaceDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryIOSurfaceDescriptor> (ptr))
                    SharedTextureMemoryIOSurfaceDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.SharedTextureMemoryEGLImageDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryEGLImageDescriptor> (ptr))
                    SharedTextureMemoryEGLImageDescriptor.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ISharedTextureMemoryEndAccessStateExtension> then
                match sType with
                | SType.SharedTextureMemoryVkImageLayoutEndState ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryVkImageLayoutEndState> (ptr))
                    SharedTextureMemoryVkImageLayoutEndState.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ISharedTextureMemoryPropertiesExtension> then
                match sType with
                | SType.SharedTextureMemoryAHardwareBufferProperties ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SharedTextureMemoryAHardwareBufferProperties> (ptr))
                    SharedTextureMemoryAHardwareBufferProperties.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ISurfaceDescriptorExtension> then
                match sType with
                | SType.SurfaceSourceAndroidNativeWindow ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceSourceAndroidNativeWindow> (ptr))
                    SurfaceSourceAndroidNativeWindow.Read(device, &rr) :> obj :?> 'a
                | SType.EmscriptenSurfaceSourceCanvasHTMLSelector ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.EmscriptenSurfaceSourceCanvasHTMLSelector> (ptr))
                    EmscriptenSurfaceSourceCanvasHTMLSelector.Read(device, &rr) :> obj :?> 'a
                | SType.SurfaceSourceMetalLayer ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceSourceMetalLayer> (ptr))
                    SurfaceSourceMetalLayer.Read(device, &rr) :> obj :?> 'a
                | SType.SurfaceSourceWindowsHWND ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceSourceWindowsHWND> (ptr))
                    SurfaceSourceWindowsHWND.Read(device, &rr) :> obj :?> 'a
                | SType.SurfaceSourceXCBWindow ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceSourceXCBWindow> (ptr))
                    SurfaceSourceXCBWindow.Read(device, &rr) :> obj :?> 'a
                | SType.SurfaceSourceXlibWindow ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceSourceXlibWindow> (ptr))
                    SurfaceSourceXlibWindow.Read(device, &rr) :> obj :?> 'a
                | SType.SurfaceSourceWaylandSurface ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceSourceWaylandSurface> (ptr))
                    SurfaceSourceWaylandSurface.Read(device, &rr) :> obj :?> 'a
                | SType.SurfaceDescriptorFromWindowsCoreWindow ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceDescriptorFromWindowsCoreWindow> (ptr))
                    SurfaceDescriptorFromWindowsCoreWindow.Read(device, &rr) :> obj :?> 'a
                | SType.SurfaceDescriptorFromWindowsUWPSwapChainPanel ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceDescriptorFromWindowsUWPSwapChainPanel> (ptr))
                    SurfaceDescriptorFromWindowsUWPSwapChainPanel.Read(device, &rr) :> obj :?> 'a
                | SType.SurfaceDescriptorFromWindowsWinUISwapChainPanel ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceDescriptorFromWindowsWinUISwapChainPanel> (ptr))
                    SurfaceDescriptorFromWindowsWinUISwapChainPanel.Read(device, &rr) :> obj :?> 'a
                | SType.SurfaceColorManagement ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.SurfaceColorManagement> (ptr))
                    SurfaceColorManagement.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ITextureDescriptorExtension> then
                match sType with
                | SType.TextureBindingViewDimensionDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.TextureBindingViewDimensionDescriptor> (ptr))
                    TextureBindingViewDimensionDescriptor.Read(device, &rr) :> obj :?> 'a
                | SType.DawnTextureInternalUsageDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.DawnTextureInternalUsageDescriptor> (ptr))
                    DawnTextureInternalUsageDescriptor.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<ITextureViewDescriptorExtension> then
                match sType with
                | SType.YCbCrVkDescriptor ->
                    let rr = NativePtr.toByRef (NativePtr.ofNativeInt<WebGPU.Raw.YCbCrVkDescriptor> (ptr))
                    YCbCrVkDescriptor.Read(device, &rr) :> obj :?> 'a
                | _ -> failwithf "bad s type: %A" sType
            elif typeof<'a> = typeof<IExtension> then
                Unchecked.defaultof<'a> // TODO
            else
                failwithf "bad extension type: %A" typeof<'a>
[<AbstractClass; Sealed>]
type private PinHelper() =
    static member inline PinNullable<'r>(x : IExtension, action : nativeint -> 'r) = 
        if isNull x then action 0n
        else x.Pin action
type Proc = delegate of IDisposable -> unit
type RequestAdapterOptions = 
    {
        Next : IRequestAdapterOptionsExtension
        FeatureLevel : FeatureLevel
        PowerPreference : PowerPreference
        ForceFallbackAdapter : bool
        BackendType : BackendType
        CompatibleSurface : Surface
    }
    static member Null = Unchecked.defaultof<RequestAdapterOptions>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RequestAdapterOptions> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let mutable value =
                    new WebGPU.Raw.RequestAdapterOptions(
                        nextInChain,
                        this.FeatureLevel,
                        this.PowerPreference,
                        (if this.ForceFallbackAdapter then 1 else 0),
                        this.BackendType,
                        this.CompatibleSurface.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RequestAdapterOptions> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RequestAdapterOptions>) = 
        {
            Next = ExtensionDecoder.decode<IRequestAdapterOptionsExtension> device backend.NextInChain
            FeatureLevel = backend.FeatureLevel
            PowerPreference = backend.PowerPreference
            ForceFallbackAdapter = (backend.ForceFallbackAdapter <> 0)
            BackendType = backend.BackendType
            CompatibleSurface = new Surface(backend.CompatibleSurface)
        }
type RequestAdapterWebXROptions = 
    {
        Next : IRequestAdapterOptionsExtension
        XrCompatible : bool
    }
    static member Null = Unchecked.defaultof<RequestAdapterWebXROptions>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RequestAdapterWebXROptions> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.RequestAdapterWebXROptions
                let mutable value =
                    new WebGPU.Raw.RequestAdapterWebXROptions(
                        nextInChain,
                        sType,
                        (if this.XrCompatible then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IRequestAdapterOptionsExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RequestAdapterWebXROptions> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RequestAdapterWebXROptions>) = 
        {
            Next = ExtensionDecoder.decode<IRequestAdapterOptionsExtension> device backend.NextInChain
            XrCompatible = (backend.XrCompatible <> 0)
        }
type RequestAdapterWebGPUBackendOptions = 
    {
        Next : IRequestAdapterOptionsExtension
    }
    static member Null = Unchecked.defaultof<RequestAdapterWebGPUBackendOptions>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RequestAdapterWebGPUBackendOptions> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.RequestAdapterWebGPUBackendOptions
                let mutable value =
                    new WebGPU.Raw.RequestAdapterWebGPUBackendOptions(
                        nextInChain,
                        sType
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IRequestAdapterOptionsExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RequestAdapterWebGPUBackendOptions> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RequestAdapterWebGPUBackendOptions>) = 
        {
            Next = ExtensionDecoder.decode<IRequestAdapterOptionsExtension> device backend.NextInChain
        }
type RequestAdapterCallback = delegate of IDisposable * status : RequestAdapterStatus * adapter : Adapter * message : string -> unit
type RequestAdapterCallbackInfo = 
    {
        Mode : CallbackMode
        Callback : RequestAdapterCallback
    }
    static member Null = Unchecked.defaultof<RequestAdapterCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RequestAdapterCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.RequestAdapterCallback>
                _callbackDel <- WebGPU.Raw.RequestAdapterCallback(fun status adapter message userdata1 userdata2 ->
                    let _status = status
                    let _adapter = new Adapter(adapter)
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _status, _adapter, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.RequestAdapterCallbackInfo(
                    nextInChain,
                    this.Mode,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RequestAdapterCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RequestAdapterCallbackInfo>) = 
        {
            Mode = backend.Mode
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (mode, backend.Mode); (next in chain, backend.NextInChain); ... ]
        }
type Adapter internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new Adapter(Unchecked.defaultof<_>)
    let instance =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.AdapterGetInstance(handle)
            new Instance(res)
        )
    member x.Handle = handle
    override x.ToString() = $"Adapter(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? Adapter as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.Instance : Instance =
        instance.Value
    member this.Limits : Limits =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        let status = WebGPU.Raw.WebGPU.AdapterGetLimits(handle, ptr)
        if status <> Status.Success then failwith "GetLimits failed"
        Limits.Read(device, &res)
    member this.Info : AdapterInfo =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        let status = WebGPU.Raw.WebGPU.AdapterGetInfo(handle, ptr)
        if status <> Status.Success then failwith "GetInfo failed"
        AdapterInfo.Read(device, &res)
    member this.HasFeature(feature : FeatureName) : bool =
        let res = WebGPU.Raw.WebGPU.AdapterHasFeature(handle, feature)
        (res <> 0)
    member this.Features : SupportedFeatures =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        WebGPU.Raw.WebGPU.AdapterGetFeatures(handle, ptr)
        SupportedFeatures.Read(device, &res)
    member this.RequestDevice(options : DeviceDescriptor, callbackInfo : RequestDeviceCallbackInfo) : Future =
        options.Pin(device, fun _optionsPtr ->
            callbackInfo.Pin(device, fun _callbackInfoPtr ->
                let res = WebGPU.Raw.WebGPU.AdapterRequestDevice(handle, _optionsPtr, (if NativePtr.toNativeInt _callbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _callbackInfoPtr))
                Future.Read(device, &res)
            )
        )
    member this.CreateDevice(descriptor : DeviceDescriptor) : Device =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.AdapterCreateDevice(handle, _descriptorPtr)
            new Device(res)
        )
    member this.GetFormatCapabilities(format : TextureFormat, capabilities : byref<DawnFormatCapabilities>) : Status =
        let mutable capabilitiesCopy = capabilities
        try
            capabilities.Pin(device, fun _capabilitiesPtr ->
                if NativePtr.toNativeInt _capabilitiesPtr = 0n then
                    let mutable capabilitiesNative = Unchecked.defaultof<WebGPU.Raw.DawnFormatCapabilities>
                    use _capabilitiesPtr = fixed &capabilitiesNative
                    let res = WebGPU.Raw.WebGPU.AdapterGetFormatCapabilities(handle, format, _capabilitiesPtr)
                    let _ret = res
                    capabilitiesCopy <- DawnFormatCapabilities.Read(device, &capabilitiesNative)
                    _ret
                else
                    let res = WebGPU.Raw.WebGPU.AdapterGetFormatCapabilities(handle, format, _capabilitiesPtr)
                    let _ret = res
                    let capabilitiesResult = NativePtr.toByRef _capabilitiesPtr
                    capabilitiesCopy <- DawnFormatCapabilities.Read(device, &capabilitiesResult)
                    _ret
            )
        finally
            capabilities <- capabilitiesCopy
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.AdapterRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.AdapterAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type AdapterInfo = 
    {
        Next : IAdapterInfoExtension
        Vendor : string
        Architecture : string
        Device : string
        Description : string
        BackendType : BackendType
        AdapterType : AdapterType
        VendorID : int
        DeviceID : int
        SubgroupMinSize : int
        SubgroupMaxSize : int
    }
    static member Null = Unchecked.defaultof<AdapterInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.AdapterInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _vendorArr = if isNull this.Vendor then null else Encoding.UTF8.GetBytes(this.Vendor)
                use _vendorPtr = fixed _vendorArr
                let _vendorLen = WebGPU.Raw.StringView(_vendorPtr, if isNull _vendorArr then 0un else unativeint _vendorArr.Length)
                let _architectureArr = if isNull this.Architecture then null else Encoding.UTF8.GetBytes(this.Architecture)
                use _architecturePtr = fixed _architectureArr
                let _architectureLen = WebGPU.Raw.StringView(_architecturePtr, if isNull _architectureArr then 0un else unativeint _architectureArr.Length)
                let _deviceArr = if isNull this.Device then null else Encoding.UTF8.GetBytes(this.Device)
                use _devicePtr = fixed _deviceArr
                let _deviceLen = WebGPU.Raw.StringView(_devicePtr, if isNull _deviceArr then 0un else unativeint _deviceArr.Length)
                let _descriptionArr = if isNull this.Description then null else Encoding.UTF8.GetBytes(this.Description)
                use _descriptionPtr = fixed _descriptionArr
                let _descriptionLen = WebGPU.Raw.StringView(_descriptionPtr, if isNull _descriptionArr then 0un else unativeint _descriptionArr.Length)
                let mutable value =
                    new WebGPU.Raw.AdapterInfo(
                        nextInChain,
                        _vendorLen,
                        _architectureLen,
                        _deviceLen,
                        _descriptionLen,
                        this.BackendType,
                        this.AdapterType,
                        uint32(this.VendorID),
                        uint32(this.DeviceID),
                        uint32(this.SubgroupMinSize),
                        uint32(this.SubgroupMaxSize)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.AdapterInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.AdapterInfo>) = 
        {
            Next = ExtensionDecoder.decode<IAdapterInfoExtension> device backend.NextInChain
            Vendor = let _vendorPtr = NativePtr.toNativeInt(backend.Vendor.Data) in if _vendorPtr = 0n then null else Marshal.PtrToStringUTF8(_vendorPtr, int(backend.Vendor.Length))
            Architecture = let _architecturePtr = NativePtr.toNativeInt(backend.Architecture.Data) in if _architecturePtr = 0n then null else Marshal.PtrToStringUTF8(_architecturePtr, int(backend.Architecture.Length))
            Device = let _devicePtr = NativePtr.toNativeInt(backend.Device.Data) in if _devicePtr = 0n then null else Marshal.PtrToStringUTF8(_devicePtr, int(backend.Device.Length))
            Description = let _descriptionPtr = NativePtr.toNativeInt(backend.Description.Data) in if _descriptionPtr = 0n then null else Marshal.PtrToStringUTF8(_descriptionPtr, int(backend.Description.Length))
            BackendType = backend.BackendType
            AdapterType = backend.AdapterType
            VendorID = int(backend.VendorID)
            DeviceID = int(backend.DeviceID)
            SubgroupMinSize = int(backend.SubgroupMinSize)
            SubgroupMaxSize = int(backend.SubgroupMaxSize)
        }
type DeviceDescriptor = 
    {
        Next : IDeviceDescriptorExtension
        Label : string
        RequiredFeatures : array<FeatureName>
        RequiredLimits : Limits
        DefaultQueue : QueueDescriptor
        DeviceLostCallbackInfo : DeviceLostCallbackInfo
        UncapturedErrorCallbackInfo : UncapturedErrorCallbackInfo
    }
    static member Null = Unchecked.defaultof<DeviceDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DeviceDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                use requiredFeaturesPtr = fixed (this.RequiredFeatures)
                let requiredFeaturesLen = unativeint this.RequiredFeatures.Length
                this.RequiredLimits.Pin(device, fun _requiredLimitsPtr ->
                    this.DefaultQueue.Pin(device, fun _defaultQueuePtr ->
                        this.DeviceLostCallbackInfo.Pin(device, fun _deviceLostCallbackInfoPtr ->
                            this.UncapturedErrorCallbackInfo.Pin(device, fun _uncapturedErrorCallbackInfoPtr ->
                                let mutable value =
                                    new WebGPU.Raw.DeviceDescriptor(
                                        nextInChain,
                                        _labelLen,
                                        requiredFeaturesLen,
                                        requiredFeaturesPtr,
                                        _requiredLimitsPtr,
                                        (if NativePtr.toNativeInt _defaultQueuePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _defaultQueuePtr),
                                        (if NativePtr.toNativeInt _deviceLostCallbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _deviceLostCallbackInfoPtr),
                                        (if NativePtr.toNativeInt _uncapturedErrorCallbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _uncapturedErrorCallbackInfoPtr)
                                    )
                                use ptr = fixed &value
                                action ptr
                            )
                        )
                    )
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DeviceDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DeviceDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<IDeviceDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            RequiredFeatures = let ptr = backend.RequiredFeatures in Array.init (int backend.RequiredFeatureCount) (fun i -> NativePtr.get ptr i)
            RequiredLimits = let m = NativePtr.toByRef backend.RequiredLimits in Limits.Read(device, &m)
            DefaultQueue = QueueDescriptor.Read(device, &backend.DefaultQueue)
            DeviceLostCallbackInfo = DeviceLostCallbackInfo.Read(device, &backend.DeviceLostCallbackInfo)
            UncapturedErrorCallbackInfo = UncapturedErrorCallbackInfo.Read(device, &backend.UncapturedErrorCallbackInfo)
        }
type DawnTogglesDescriptor = 
    {
        Next : IInstanceDescriptorExtension
        EnabledToggleCount : int64
        EnabledToggles : nativeptr<nativeptr<byte>>
        DisabledToggleCount : int64
        DisabledToggles : nativeptr<nativeptr<byte>>
    }
    static member Null = Unchecked.defaultof<DawnTogglesDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnTogglesDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnTogglesDescriptor
                let mutable value =
                    new WebGPU.Raw.DawnTogglesDescriptor(
                        nextInChain,
                        sType,
                        unativeint(this.EnabledToggleCount),
                        this.EnabledToggles,
                        unativeint(this.DisabledToggleCount),
                        this.DisabledToggles
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IInstanceDescriptorExtension
    interface IRequestAdapterOptionsExtension
    interface IDeviceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnTogglesDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnTogglesDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<IInstanceDescriptorExtension> device backend.NextInChain
            EnabledToggleCount = int64(backend.EnabledToggleCount)
            EnabledToggles = backend.EnabledToggles
            DisabledToggleCount = int64(backend.DisabledToggleCount)
            DisabledToggles = backend.DisabledToggles
        }
type DawnLoadCacheDataFunction = delegate of IDisposable * key : nativeint * keySize : int64 * value : nativeint * valueSize : int64 -> unativeint
type DawnStoreCacheDataFunction = delegate of IDisposable * key : nativeint * keySize : int64 * value : nativeint * valueSize : int64 -> unit
type DawnCacheDeviceDescriptor = 
    {
        Next : IDeviceDescriptorExtension
        IsolationKey : string
        LoadDataFunction : DawnLoadCacheDataFunction
        StoreDataFunction : DawnStoreCacheDataFunction
    }
    static member Null = Unchecked.defaultof<DawnCacheDeviceDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnCacheDeviceDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnCacheDeviceDescriptor
                let _isolationKeyArr = if isNull this.IsolationKey then null else Encoding.UTF8.GetBytes(this.IsolationKey)
                use _isolationKeyPtr = fixed _isolationKeyArr
                let _isolationKeyLen = WebGPU.Raw.StringView(_isolationKeyPtr, if isNull _isolationKeyArr then 0un else unativeint _isolationKeyArr.Length)
                let mutable _loadDataFunctionPtr = 0n
                if not (isNull (this.LoadDataFunction :> obj)) then
                    let mutable _loadDataFunctionGC = Unchecked.defaultof<GCHandle>
                    let mutable _loadDataFunctionDel = Unchecked.defaultof<WebGPU.Raw.DawnLoadCacheDataFunction>
                    _loadDataFunctionDel <- WebGPU.Raw.DawnLoadCacheDataFunction(fun key keySize value valueSize userdata ->
                        let _key = key
                        let _keySize = int64(keySize)
                        let _value = value
                        let _valueSize = int64(valueSize)
                        this.LoadDataFunction.Invoke({ new IDisposable with member __.Dispose() = _loadDataFunctionGC.Free() }, _key, _keySize, _value, _valueSize)
                    )
                    _loadDataFunctionGC <- GCHandle.Alloc(_loadDataFunctionDel)
                    _loadDataFunctionPtr <- Marshal.GetFunctionPointerForDelegate(_loadDataFunctionDel)
                let mutable _storeDataFunctionPtr = 0n
                if not (isNull (this.StoreDataFunction :> obj)) then
                    let mutable _storeDataFunctionGC = Unchecked.defaultof<GCHandle>
                    let mutable _storeDataFunctionDel = Unchecked.defaultof<WebGPU.Raw.DawnStoreCacheDataFunction>
                    _storeDataFunctionDel <- WebGPU.Raw.DawnStoreCacheDataFunction(fun key keySize value valueSize userdata ->
                        let _key = key
                        let _keySize = int64(keySize)
                        let _value = value
                        let _valueSize = int64(valueSize)
                        this.StoreDataFunction.Invoke({ new IDisposable with member __.Dispose() = _storeDataFunctionGC.Free() }, _key, _keySize, _value, _valueSize)
                    )
                    _storeDataFunctionGC <- GCHandle.Alloc(_storeDataFunctionDel)
                    _storeDataFunctionPtr <- Marshal.GetFunctionPointerForDelegate(_storeDataFunctionDel)
                let mutable value =
                    new WebGPU.Raw.DawnCacheDeviceDescriptor(
                        nextInChain,
                        sType,
                        _isolationKeyLen,
                        _loadDataFunctionPtr,
                        _storeDataFunctionPtr,
                        Unchecked.defaultof<_>
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IDeviceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnCacheDeviceDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnCacheDeviceDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<IDeviceDescriptorExtension> device backend.NextInChain
            IsolationKey = let _isolationKeyPtr = NativePtr.toNativeInt(backend.IsolationKey.Data) in if _isolationKeyPtr = 0n then null else Marshal.PtrToStringUTF8(_isolationKeyPtr, int(backend.IsolationKey.Length))
            LoadDataFunction = failwith "cannot read callbacks"//TODO2 map [(function userdata, backend.FunctionUserdata); (isolation key, backend.IsolationKey); (load data function, backend.LoadDataFunction); ... ]
            StoreDataFunction = failwith "cannot read callbacks"//TODO2 map [(function userdata, backend.FunctionUserdata); (isolation key, backend.IsolationKey); (load data function, backend.LoadDataFunction); ... ]
        }
type DawnDeviceAllocatorControl = 
    {
        Next : IDeviceDescriptorExtension
        AllocatorHeapBlockSize : int64
    }
    static member Null = Unchecked.defaultof<DawnDeviceAllocatorControl>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnDeviceAllocatorControl> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnDeviceAllocatorControl
                let mutable value =
                    new WebGPU.Raw.DawnDeviceAllocatorControl(
                        nextInChain,
                        sType,
                        unativeint(this.AllocatorHeapBlockSize)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IDeviceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnDeviceAllocatorControl> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnDeviceAllocatorControl>) = 
        {
            Next = ExtensionDecoder.decode<IDeviceDescriptorExtension> device backend.NextInChain
            AllocatorHeapBlockSize = int64(backend.AllocatorHeapBlockSize)
        }
type DawnWGSLBlocklist = 
    {
        Next : IInstanceDescriptorExtension
        BlocklistedFeatureCount : int64
        BlocklistedFeatures : nativeptr<nativeptr<byte>>
    }
    static member Null = Unchecked.defaultof<DawnWGSLBlocklist>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnWGSLBlocklist> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnWGSLBlocklist
                let mutable value =
                    new WebGPU.Raw.DawnWGSLBlocklist(
                        nextInChain,
                        sType,
                        unativeint(this.BlocklistedFeatureCount),
                        this.BlocklistedFeatures
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IInstanceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnWGSLBlocklist> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnWGSLBlocklist>) = 
        {
            Next = ExtensionDecoder.decode<IInstanceDescriptorExtension> device backend.NextInChain
            BlocklistedFeatureCount = int64(backend.BlocklistedFeatureCount)
            BlocklistedFeatures = backend.BlocklistedFeatures
        }
type BindGroup internal(device : Device, handle : nativeint) =
    static let nullptr = new BindGroup(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"BindGroup(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? BindGroup as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.BindGroupSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.BindGroupRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.BindGroupAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type BindGroupEntry = 
    {
        Next : IBindGroupEntryExtension
        Binding : int
        Buffer : Buffer
        Offset : int64
        Size : int64
        Sampler : Sampler
        TextureView : TextureView
    }
    static member Null = Unchecked.defaultof<BindGroupEntry>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BindGroupEntry> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let mutable value =
                    new WebGPU.Raw.BindGroupEntry(
                        nextInChain,
                        uint32(this.Binding),
                        this.Buffer.Handle,
                        uint64(this.Offset),
                        uint64(this.Size),
                        this.Sampler.Handle,
                        this.TextureView.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BindGroupEntry> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BindGroupEntry>) = 
        {
            Next = ExtensionDecoder.decode<IBindGroupEntryExtension> device backend.NextInChain
            Binding = int(backend.Binding)
            Buffer = new Buffer(device, backend.Buffer)
            Offset = int64(backend.Offset)
            Size = int64(backend.Size)
            Sampler = new Sampler(device, backend.Sampler)
            TextureView = new TextureView(backend.TextureView)
        }
type BindGroupDescriptor = 
    {
        Label : string
        Layout : BindGroupLayout
        Entries : array<BindGroupEntry>
    }
    static member Null = Unchecked.defaultof<BindGroupDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BindGroupDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            WebGPU.Raw.Pinnable.pinArray device this.Entries (fun entriesPtr ->
                let entriesLen = unativeint this.Entries.Length
                let mutable value =
                    new WebGPU.Raw.BindGroupDescriptor(
                        nextInChain,
                        _labelLen,
                        this.Layout.Handle,
                        entriesLen,
                        entriesPtr
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BindGroupDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BindGroupDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            Layout = new BindGroupLayout(backend.Layout)
            Entries = let ptr = backend.Entries in Array.init (int backend.EntryCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in BindGroupEntry.Read(device, &r))
        }
type BindGroupLayout internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new BindGroupLayout(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"BindGroupLayout(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? BindGroupLayout as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.BindGroupLayoutSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.BindGroupLayoutRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.BindGroupLayoutAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type BufferBindingLayout = 
    {
        Type : BufferBindingType
        HasDynamicOffset : bool
        MinBindingSize : int64
    }
    static member Null = Unchecked.defaultof<BufferBindingLayout>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BufferBindingLayout> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.BufferBindingLayout(
                    nextInChain,
                    this.Type,
                    (if this.HasDynamicOffset then 1 else 0),
                    uint64(this.MinBindingSize)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BufferBindingLayout> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BufferBindingLayout>) = 
        {
            Type = backend.Type
            HasDynamicOffset = (backend.HasDynamicOffset <> 0)
            MinBindingSize = int64(backend.MinBindingSize)
        }
type SamplerBindingLayout = 
    {
        Type : SamplerBindingType
    }
    static member Null = Unchecked.defaultof<SamplerBindingLayout>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SamplerBindingLayout> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.SamplerBindingLayout(
                    nextInChain,
                    this.Type
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SamplerBindingLayout> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SamplerBindingLayout>) = 
        {
            Type = backend.Type
        }
type StaticSamplerBindingLayout = 
    {
        Next : IBindGroupLayoutEntryExtension
        Sampler : Sampler
        SampledTextureBinding : int
    }
    static member Null = Unchecked.defaultof<StaticSamplerBindingLayout>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.StaticSamplerBindingLayout> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.StaticSamplerBindingLayout
                let mutable value =
                    new WebGPU.Raw.StaticSamplerBindingLayout(
                        nextInChain,
                        sType,
                        this.Sampler.Handle,
                        uint32(this.SampledTextureBinding)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IBindGroupLayoutEntryExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.StaticSamplerBindingLayout> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.StaticSamplerBindingLayout>) = 
        {
            Next = ExtensionDecoder.decode<IBindGroupLayoutEntryExtension> device backend.NextInChain
            Sampler = new Sampler(device, backend.Sampler)
            SampledTextureBinding = int(backend.SampledTextureBinding)
        }
type TextureBindingLayout = 
    {
        SampleType : TextureSampleType
        ViewDimension : TextureViewDimension
        Multisampled : bool
    }
    static member Null = Unchecked.defaultof<TextureBindingLayout>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.TextureBindingLayout> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.TextureBindingLayout(
                    nextInChain,
                    this.SampleType,
                    this.ViewDimension,
                    (if this.Multisampled then 1 else 0)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.TextureBindingLayout> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.TextureBindingLayout>) = 
        {
            SampleType = backend.SampleType
            ViewDimension = backend.ViewDimension
            Multisampled = (backend.Multisampled <> 0)
        }
type SurfaceCapabilities = 
    {
        Usages : TextureUsage
        Formats : array<TextureFormat>
        PresentModes : array<PresentMode>
        AlphaModes : array<CompositeAlphaMode>
    }
    static member Null = Unchecked.defaultof<SurfaceCapabilities>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceCapabilities> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            use formatsPtr = fixed (this.Formats)
            let formatsLen = unativeint this.Formats.Length
            use presentModesPtr = fixed (this.PresentModes)
            let presentModesLen = unativeint this.PresentModes.Length
            use alphaModesPtr = fixed (this.AlphaModes)
            let alphaModesLen = unativeint this.AlphaModes.Length
            let mutable value =
                new WebGPU.Raw.SurfaceCapabilities(
                    nextInChain,
                    this.Usages,
                    formatsLen,
                    formatsPtr,
                    presentModesLen,
                    presentModesPtr,
                    alphaModesLen,
                    alphaModesPtr
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceCapabilities> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceCapabilities>) = 
        {
            Usages = backend.Usages
            Formats = let ptr = backend.Formats in Array.init (int backend.FormatCount) (fun i -> NativePtr.get ptr i)
            PresentModes = let ptr = backend.PresentModes in Array.init (int backend.PresentModeCount) (fun i -> NativePtr.get ptr i)
            AlphaModes = let ptr = backend.AlphaModes in Array.init (int backend.AlphaModeCount) (fun i -> NativePtr.get ptr i)
        }
type SurfaceConfiguration = 
    {
        Device : Device
        Format : TextureFormat
        Usage : TextureUsage
        Width : int
        Height : int
        ViewFormats : array<TextureFormat>
        AlphaMode : CompositeAlphaMode
        PresentMode : PresentMode
    }
    static member Null = Unchecked.defaultof<SurfaceConfiguration>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceConfiguration> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            use viewFormatsPtr = fixed (this.ViewFormats)
            let viewFormatsLen = unativeint this.ViewFormats.Length
            let mutable value =
                new WebGPU.Raw.SurfaceConfiguration(
                    nextInChain,
                    this.Device.Handle,
                    this.Format,
                    this.Usage,
                    uint32(this.Width),
                    uint32(this.Height),
                    viewFormatsLen,
                    viewFormatsPtr,
                    this.AlphaMode,
                    this.PresentMode
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceConfiguration> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceConfiguration>) = 
        {
            Device = new Device(backend.Device)
            Format = backend.Format
            Usage = backend.Usage
            Width = int(backend.Width)
            Height = int(backend.Height)
            ViewFormats = let ptr = backend.ViewFormats in Array.init (int backend.ViewFormatCount) (fun i -> NativePtr.get ptr i)
            AlphaMode = backend.AlphaMode
            PresentMode = backend.PresentMode
        }
type ExternalTextureBindingEntry = 
    {
        Next : IBindGroupEntryExtension
        ExternalTexture : ExternalTexture
    }
    static member Null = Unchecked.defaultof<ExternalTextureBindingEntry>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ExternalTextureBindingEntry> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.ExternalTextureBindingEntry
                let mutable value =
                    new WebGPU.Raw.ExternalTextureBindingEntry(
                        nextInChain,
                        sType,
                        this.ExternalTexture.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IBindGroupEntryExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ExternalTextureBindingEntry> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ExternalTextureBindingEntry>) = 
        {
            Next = ExtensionDecoder.decode<IBindGroupEntryExtension> device backend.NextInChain
            ExternalTexture = new ExternalTexture(device, backend.ExternalTexture)
        }
type ExternalTextureBindingLayout = 
    {
        Next : IBindGroupLayoutEntryExtension
    }
    static member Null = Unchecked.defaultof<ExternalTextureBindingLayout>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ExternalTextureBindingLayout> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.ExternalTextureBindingLayout
                let mutable value =
                    new WebGPU.Raw.ExternalTextureBindingLayout(
                        nextInChain,
                        sType
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IBindGroupLayoutEntryExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ExternalTextureBindingLayout> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ExternalTextureBindingLayout>) = 
        {
            Next = ExtensionDecoder.decode<IBindGroupLayoutEntryExtension> device backend.NextInChain
        }
type StorageTextureBindingLayout = 
    {
        Access : StorageTextureAccess
        Format : TextureFormat
        ViewDimension : TextureViewDimension
    }
    static member Null = Unchecked.defaultof<StorageTextureBindingLayout>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.StorageTextureBindingLayout> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.StorageTextureBindingLayout(
                    nextInChain,
                    this.Access,
                    this.Format,
                    this.ViewDimension
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.StorageTextureBindingLayout> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.StorageTextureBindingLayout>) = 
        {
            Access = backend.Access
            Format = backend.Format
            ViewDimension = backend.ViewDimension
        }
type BindGroupLayoutEntry = 
    {
        Next : IBindGroupLayoutEntryExtension
        Binding : int
        Visibility : ShaderStage
        BindingArraySize : int
        Buffer : BufferBindingLayout
        Sampler : SamplerBindingLayout
        Texture : TextureBindingLayout
        StorageTexture : StorageTextureBindingLayout
    }
    static member Null = Unchecked.defaultof<BindGroupLayoutEntry>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BindGroupLayoutEntry> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                this.Buffer.Pin(device, fun _bufferPtr ->
                    this.Sampler.Pin(device, fun _samplerPtr ->
                        this.Texture.Pin(device, fun _texturePtr ->
                            this.StorageTexture.Pin(device, fun _storageTexturePtr ->
                                let mutable value =
                                    new WebGPU.Raw.BindGroupLayoutEntry(
                                        nextInChain,
                                        uint32(this.Binding),
                                        this.Visibility,
                                        uint32(this.BindingArraySize),
                                        (if NativePtr.toNativeInt _bufferPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _bufferPtr),
                                        (if NativePtr.toNativeInt _samplerPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _samplerPtr),
                                        (if NativePtr.toNativeInt _texturePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _texturePtr),
                                        (if NativePtr.toNativeInt _storageTexturePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _storageTexturePtr)
                                    )
                                use ptr = fixed &value
                                action ptr
                            )
                        )
                    )
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BindGroupLayoutEntry> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BindGroupLayoutEntry>) = 
        {
            Next = ExtensionDecoder.decode<IBindGroupLayoutEntryExtension> device backend.NextInChain
            Binding = int(backend.Binding)
            Visibility = backend.Visibility
            BindingArraySize = int(backend.BindingArraySize)
            Buffer = BufferBindingLayout.Read(device, &backend.Buffer)
            Sampler = SamplerBindingLayout.Read(device, &backend.Sampler)
            Texture = TextureBindingLayout.Read(device, &backend.Texture)
            StorageTexture = StorageTextureBindingLayout.Read(device, &backend.StorageTexture)
        }
type BindGroupLayoutDescriptor = 
    {
        Label : string
        Entries : array<BindGroupLayoutEntry>
    }
    static member Null = Unchecked.defaultof<BindGroupLayoutDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BindGroupLayoutDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            WebGPU.Raw.Pinnable.pinArray device this.Entries (fun entriesPtr ->
                let entriesLen = unativeint this.Entries.Length
                let mutable value =
                    new WebGPU.Raw.BindGroupLayoutDescriptor(
                        nextInChain,
                        _labelLen,
                        entriesLen,
                        entriesPtr
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BindGroupLayoutDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BindGroupLayoutDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            Entries = let ptr = backend.Entries in Array.init (int backend.EntryCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in BindGroupLayoutEntry.Read(device, &r))
        }
type BlendComponent = 
    {
        Operation : BlendOperation
        SrcFactor : BlendFactor
        DstFactor : BlendFactor
    }
    static member Null = Unchecked.defaultof<BlendComponent>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BlendComponent> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.BlendComponent(
                    this.Operation,
                    this.SrcFactor,
                    this.DstFactor
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BlendComponent> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BlendComponent>) = 
        {
            Operation = backend.Operation
            SrcFactor = backend.SrcFactor
            DstFactor = backend.DstFactor
        }
type StringView = 
    {
        Data : string
        Length : int64
    }
    static member Null = Unchecked.defaultof<StringView>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.StringView> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            use _dataPtr = fixed (if isNull this.Data then null else Encoding.UTF8.GetBytes(this.Data))
            let mutable value =
                new WebGPU.Raw.StringView(
                    _dataPtr,
                    unativeint(this.Length)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.StringView> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.StringView>) = 
        {
            Data = Marshal.PtrToStringAnsi(NativePtr.toNativeInt backend.Data)
            Length = int64(backend.Length)
        }
[<DebuggerTypeProxy(typeof<BufferProxy>)>]
type Buffer internal(device : Device, handle : nativeint) =
    static let nullptr = new Buffer(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    let usage =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.BufferGetUsage(handle)
            res
        )
    let size =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.BufferGetSize(handle)
            int64(res)
        )
    let mapState =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.BufferGetMapState(handle)
            res
        )
    let mutable name : string = null
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"Buffer(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? Buffer as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    interface Aardvark.Rendering.IBufferRange with
        member x.Buffer = x
        member x.Offset = 0UL
        member x.SizeInBytes = uint64 x.Size
    
    interface Aardvark.Rendering.IBackendBuffer with
        member x.Handle = uint64 handle
        member x.Runtime = device.Runtime
        member x.Name
            with get() = name
            and set(v) = name <- v
    member this.MapAsync(mode : MapMode, offset : int64, size : int64, callbackInfo : BufferMapCallbackInfo) : Future =
        callbackInfo.Pin(device, fun _callbackInfoPtr ->
            let res = WebGPU.Raw.WebGPU.BufferMapAsync(handle, mode, unativeint(offset), unativeint(size), (if NativePtr.toNativeInt _callbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _callbackInfoPtr))
            Future.Read(device, &res)
        )
    member this.GetMappedRange(offset : int64, size : int64) : nativeint =
        let res = WebGPU.Raw.WebGPU.BufferGetMappedRange(handle, unativeint(offset), unativeint(size))
        res
    member this.GetConstMappedRange(offset : int64, size : int64) : nativeint =
        let res = WebGPU.Raw.WebGPU.BufferGetConstMappedRange(handle, unativeint(offset), unativeint(size))
        res
    member this.WriteMappedRange(offset : int64, data : nativeint, size : int64) : Status =
        let res = WebGPU.Raw.WebGPU.BufferWriteMappedRange(handle, unativeint(offset), data, unativeint(size))
        res
    member this.ReadMappedRange(offset : int64, data : nativeint, size : int64) : Status =
        let res = WebGPU.Raw.WebGPU.BufferReadMappedRange(handle, unativeint(offset), data, unativeint(size))
        res
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.BufferSetLabel(handle, _labelLen)
        res
    member this.Usage : BufferUsage =
        usage.Value
    member this.Size : int64 =
        size.Value
    member this.MapState : BufferMapState =
        mapState.Value
    member this.Unmap() : unit =
        let res = WebGPU.Raw.WebGPU.BufferUnmap(handle)
        res
    member this.Destroy() : unit =
        let res = WebGPU.Raw.WebGPU.BufferDestroy(handle)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.BufferRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.BufferAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
    member buffer.ToByteArray(offset : int64, size : int64) : byte[] =
        let device = buffer.Device
        let queue = device.Queue
        let arr = Array.zeroCreate<byte> (int size)
        use tmp = device.CreateBuffer { Next = null; Label = null; Size = size; MappedAtCreation = false; Usage = BufferUsage.MapRead ||| BufferUsage.CopyDst }
        use enc = buffer.Device.CreateCommandEncoder { Label = null; Next = null }
        enc.CopyBufferToBuffer(buffer, offset, tmp, 0L, size)
        use cmd = enc.Finish { Label = null }
        queue.Submit [| cmd |] |> ignore
        let f = queue.OnSubmittedWorkDone { Mode = CallbackMode.WaitAnyOnly; Callback = QueueWorkDoneCallback (fun _ _ _ -> ()) }
        device.Instance.WaitAny([| { FutureWaitInfo.Future = f; Completed = false } |], 1000000000L) |> ignore
        let info : BufferMapCallbackInfo =
           {
               Mode = CallbackMode.WaitAnyOnly
               Callback = BufferMapCallback(fun d status msg -> ())
           }
        let f = tmp.MapAsync(MapMode.Read, 0L, size, info)
        device.Instance.WaitAny([| { FutureWaitInfo.Future = f; Completed = false } |], 1000000000L) |> ignore
        let ptr = tmp.GetConstMappedRange(0L, size)
        System.Runtime.InteropServices.Marshal.Copy(ptr, arr, 0, arr.Length)
        tmp.Unmap()
        arr
type BufferDescriptor = 
    {
        Next : IBufferDescriptorExtension
        Label : string
        Usage : BufferUsage
        Size : int64
        MappedAtCreation : bool
    }
    static member Null = Unchecked.defaultof<BufferDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BufferDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                let mutable value =
                    new WebGPU.Raw.BufferDescriptor(
                        nextInChain,
                        _labelLen,
                        this.Usage,
                        uint64(this.Size),
                        (if this.MappedAtCreation then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BufferDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BufferDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<IBufferDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            Usage = backend.Usage
            Size = int64(backend.Size)
            MappedAtCreation = (backend.MappedAtCreation <> 0)
        }
type BufferHostMappedPointer = 
    {
        Next : IBufferDescriptorExtension
        Pointer : nativeint
        DisposeCallback : Callback
    }
    static member Null = Unchecked.defaultof<BufferHostMappedPointer>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BufferHostMappedPointer> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.BufferHostMappedPointer
                let mutable _disposeCallbackPtr = 0n
                if not (isNull (this.DisposeCallback :> obj)) then
                    let mutable _disposeCallbackGC = Unchecked.defaultof<GCHandle>
                    let mutable _disposeCallbackDel = Unchecked.defaultof<WebGPU.Raw.Callback>
                    _disposeCallbackDel <- WebGPU.Raw.Callback(fun userdata ->
                        this.DisposeCallback.Invoke({ new IDisposable with member __.Dispose() = _disposeCallbackGC.Free() })
                    )
                    _disposeCallbackGC <- GCHandle.Alloc(_disposeCallbackDel)
                    _disposeCallbackPtr <- Marshal.GetFunctionPointerForDelegate(_disposeCallbackDel)
                let mutable value =
                    new WebGPU.Raw.BufferHostMappedPointer(
                        nextInChain,
                        sType,
                        this.Pointer,
                        _disposeCallbackPtr,
                        Unchecked.defaultof<_>
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IBufferDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BufferHostMappedPointer> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BufferHostMappedPointer>) = 
        {
            Next = ExtensionDecoder.decode<IBufferDescriptorExtension> device backend.NextInChain
            Pointer = backend.Pointer
            DisposeCallback = failwith "cannot read callbacks"//TODO2 map [(dispose callback, backend.DisposeCallback); (next in chain, backend.NextInChain); (pointer, backend.Pointer); ... ]
        }
type Callback = delegate of IDisposable -> unit
type BufferMapCallback = delegate of IDisposable * status : MapAsyncStatus * message : string -> unit
type BufferMapCallbackInfo = 
    {
        Mode : CallbackMode
        Callback : BufferMapCallback
    }
    static member Null = Unchecked.defaultof<BufferMapCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BufferMapCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.BufferMapCallback>
                _callbackDel <- WebGPU.Raw.BufferMapCallback(fun status message userdata1 userdata2 ->
                    let _status = status
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _status, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.BufferMapCallbackInfo(
                    nextInChain,
                    this.Mode,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BufferMapCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BufferMapCallbackInfo>) = 
        {
            Mode = backend.Mode
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (mode, backend.Mode); (next in chain, backend.NextInChain); ... ]
        }
type Color = 
    {
        R : double
        G : double
        B : double
        A : double
    }
    static member Null = Unchecked.defaultof<Color>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.Color> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.Color(
                    this.R,
                    this.G,
                    this.B,
                    this.A
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.Color> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.Color>) = 
        {
            R = backend.R
            G = backend.G
            B = backend.B
            A = backend.A
        }
type ConstantEntry = 
    {
        Key : string
        Value : double
    }
    static member Null = Unchecked.defaultof<ConstantEntry>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ConstantEntry> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _keyArr = if isNull this.Key then null else Encoding.UTF8.GetBytes(this.Key)
            use _keyPtr = fixed _keyArr
            let _keyLen = WebGPU.Raw.StringView(_keyPtr, if isNull _keyArr then 0un else unativeint _keyArr.Length)
            let mutable value =
                new WebGPU.Raw.ConstantEntry(
                    nextInChain,
                    _keyLen,
                    this.Value
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ConstantEntry> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ConstantEntry>) = 
        {
            Key = let _keyPtr = NativePtr.toNativeInt(backend.Key.Data) in if _keyPtr = 0n then null else Marshal.PtrToStringUTF8(_keyPtr, int(backend.Key.Length))
            Value = backend.Value
        }
type CommandBuffer internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new CommandBuffer(Unchecked.defaultof<_>)
    let mutable cleanup : ResizeArray<unit -> unit> = null
    let mutable afterRun : ResizeArray<unit -> System.Threading.Tasks.Task> = null
    member internal x.Cleanup
        with get() = cleanup
        and set(v) = cleanup <- v
    member internal x.AfterRun
        with get() = afterRun
        and set(v) = afterRun <- v
    member internal x.RunCleanup() = 
        if not (isNull cleanup) then
            for a in cleanup do a()
            cleanup <- null
    member internal x.RunCompleted() = 
        task {
            if not (isNull afterRun) then
                for a in afterRun do do! a()
                afterRun <- null
        }
    member x.Handle = handle
    override x.ToString() = $"CommandBuffer(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? CommandBuffer as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.CommandBufferSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.CommandBufferRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.CommandBufferAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.RunCleanup()
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type CommandBufferDescriptor = 
    {
        Label : string
    }
    static member Null = Unchecked.defaultof<CommandBufferDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.CommandBufferDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            let mutable value =
                new WebGPU.Raw.CommandBufferDescriptor(
                    nextInChain,
                    _labelLen
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.CommandBufferDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.CommandBufferDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
        }
type CommandEncoder internal(device : Device, handle : nativeint) =
    static let nullptr = new CommandEncoder(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    let mutable afterRun : ResizeArray<unit -> System.Threading.Tasks.Task> = null
    let mutable cleanup : ResizeArray<unit -> unit> = null
    member x.AddCleanup(action : unit -> unit) =
        if isNull cleanup then cleanup <- ResizeArray()
        cleanup.Add(action)
    member x.AddAfterRun(action : unit -> System.Threading.Tasks.Task) =
        if isNull afterRun then afterRun <- ResizeArray()
        afterRun.Add(action)
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"CommandEncoder(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? CommandEncoder as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.Finish(descriptor : CommandBufferDescriptor) : CommandBuffer =
        let res =
            descriptor.Pin(device, fun _descriptorPtr ->
                let res = WebGPU.Raw.WebGPU.CommandEncoderFinish(handle, _descriptorPtr)
                new CommandBuffer(res)
            )
        res.Cleanup <- cleanup
        res.AfterRun <- afterRun
        cleanup <- null
        afterRun <- null
        res
    member this.BeginComputePass(descriptor : ComputePassDescriptor) : ComputePassEncoder =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.CommandEncoderBeginComputePass(handle, _descriptorPtr)
            new ComputePassEncoder(res)
        )
    member this.BeginRenderPass(descriptor : RenderPassDescriptor) : RenderPassEncoder =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.CommandEncoderBeginRenderPass(handle, _descriptorPtr)
            new RenderPassEncoder(res)
        )
    member this.CopyBufferToBuffer(source : Buffer, sourceOffset : int64, destination : Buffer, destinationOffset : int64, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.CommandEncoderCopyBufferToBuffer(handle, source.Handle, uint64(sourceOffset), destination.Handle, uint64(destinationOffset), uint64(size))
        res
    member this.CopyBufferToTexture(source : TexelCopyBufferInfo, destination : TexelCopyTextureInfo, copySize : Extent3D) : unit =
        source.Pin(device, fun _sourcePtr ->
            destination.Pin(device, fun _destinationPtr ->
                copySize.Pin(device, fun _copySizePtr ->
                    let res = WebGPU.Raw.WebGPU.CommandEncoderCopyBufferToTexture(handle, _sourcePtr, _destinationPtr, _copySizePtr)
                    res
                )
            )
        )
    member this.CopyTextureToBuffer(source : TexelCopyTextureInfo, destination : TexelCopyBufferInfo, copySize : Extent3D) : unit =
        source.Pin(device, fun _sourcePtr ->
            destination.Pin(device, fun _destinationPtr ->
                copySize.Pin(device, fun _copySizePtr ->
                    let res = WebGPU.Raw.WebGPU.CommandEncoderCopyTextureToBuffer(handle, _sourcePtr, _destinationPtr, _copySizePtr)
                    res
                )
            )
        )
    member this.CopyTextureToTexture(source : TexelCopyTextureInfo, destination : TexelCopyTextureInfo, copySize : Extent3D) : unit =
        source.Pin(device, fun _sourcePtr ->
            destination.Pin(device, fun _destinationPtr ->
                copySize.Pin(device, fun _copySizePtr ->
                    let res = WebGPU.Raw.WebGPU.CommandEncoderCopyTextureToTexture(handle, _sourcePtr, _destinationPtr, _copySizePtr)
                    res
                )
            )
        )
    member this.ClearBuffer(buffer : Buffer, offset : int64, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.CommandEncoderClearBuffer(handle, buffer.Handle, uint64(offset), uint64(size))
        res
    member this.InjectValidationError(message : string) : unit =
        let _messageArr = if isNull message then null else Encoding.UTF8.GetBytes(message)
        use _messagePtr = fixed _messageArr
        let _messageLen = WebGPU.Raw.StringView(_messagePtr, if isNull _messageArr then 0un else unativeint _messageArr.Length)
        let res = WebGPU.Raw.WebGPU.CommandEncoderInjectValidationError(handle, _messageLen)
        res
    member this.InsertDebugMarker(markerLabel : string) : unit =
        let _markerLabelArr = if isNull markerLabel then null else Encoding.UTF8.GetBytes(markerLabel)
        use _markerLabelPtr = fixed _markerLabelArr
        let _markerLabelLen = WebGPU.Raw.StringView(_markerLabelPtr, if isNull _markerLabelArr then 0un else unativeint _markerLabelArr.Length)
        let res = WebGPU.Raw.WebGPU.CommandEncoderInsertDebugMarker(handle, _markerLabelLen)
        res
    member this.PopDebugGroup() : unit =
        let res = WebGPU.Raw.WebGPU.CommandEncoderPopDebugGroup(handle)
        res
    member this.PushDebugGroup(groupLabel : string) : unit =
        let _groupLabelArr = if isNull groupLabel then null else Encoding.UTF8.GetBytes(groupLabel)
        use _groupLabelPtr = fixed _groupLabelArr
        let _groupLabelLen = WebGPU.Raw.StringView(_groupLabelPtr, if isNull _groupLabelArr then 0un else unativeint _groupLabelArr.Length)
        let res = WebGPU.Raw.WebGPU.CommandEncoderPushDebugGroup(handle, _groupLabelLen)
        res
    member this.ResolveQuerySet(querySet : QuerySet, firstQuery : int, queryCount : int, destination : Buffer, destinationOffset : int64) : unit =
        let res = WebGPU.Raw.WebGPU.CommandEncoderResolveQuerySet(handle, querySet.Handle, uint32(firstQuery), uint32(queryCount), destination.Handle, uint64(destinationOffset))
        res
    member this.WriteBuffer(buffer : Buffer, bufferOffset : int64, data : array<uint8>, size : int64) : unit =
        use dataPtr = fixed (data)
        let dataLen = uint64 data.Length
        let res = WebGPU.Raw.WebGPU.CommandEncoderWriteBuffer(handle, buffer.Handle, uint64(bufferOffset), dataPtr, uint64(size))
        res
    member this.WriteTimestamp(querySet : QuerySet, queryIndex : int) : unit =
        let res = WebGPU.Raw.WebGPU.CommandEncoderWriteTimestamp(handle, querySet.Handle, uint32(queryIndex))
        res
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.CommandEncoderSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.CommandEncoderRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.CommandEncoderAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type CommandEncoderDescriptor = 
    {
        Next : ICommandEncoderDescriptorExtension
        Label : string
    }
    static member Null = Unchecked.defaultof<CommandEncoderDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.CommandEncoderDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                let mutable value =
                    new WebGPU.Raw.CommandEncoderDescriptor(
                        nextInChain,
                        _labelLen
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.CommandEncoderDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.CommandEncoderDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ICommandEncoderDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
        }
type CompilationInfo = 
    {
        Messages : array<CompilationMessage>
    }
    static member Null = Unchecked.defaultof<CompilationInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.CompilationInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            WebGPU.Raw.Pinnable.pinArray device this.Messages (fun messagesPtr ->
                let messagesLen = unativeint this.Messages.Length
                let mutable value =
                    new WebGPU.Raw.CompilationInfo(
                        nextInChain,
                        messagesLen,
                        messagesPtr
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.CompilationInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.CompilationInfo>) = 
        {
            Messages = let ptr = backend.Messages in Array.init (int backend.MessageCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in CompilationMessage.Read(device, &r))
        }
type CompilationInfoCallback = delegate of IDisposable * status : CompilationInfoRequestStatus * compilationInfo : CompilationInfo -> unit
type CompilationInfoCallbackInfo = 
    {
        Mode : CallbackMode
        Callback : CompilationInfoCallback
    }
    static member Null = Unchecked.defaultof<CompilationInfoCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.CompilationInfoCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.CompilationInfoCallback>
                _callbackDel <- WebGPU.Raw.CompilationInfoCallback(fun status compilationInfo userdata1 userdata2 ->
                    let _status = status
                    let _compilationInfo = let m = NativePtr.toByRef compilationInfo in CompilationInfo.Read(device, &m)
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _status, _compilationInfo)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.CompilationInfoCallbackInfo(
                    nextInChain,
                    this.Mode,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.CompilationInfoCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.CompilationInfoCallbackInfo>) = 
        {
            Mode = backend.Mode
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (mode, backend.Mode); (next in chain, backend.NextInChain); ... ]
        }
type CompilationMessage = 
    {
        Next : ICompilationMessageExtension
        Message : string
        Type : CompilationMessageType
        LineNum : int64
        LinePos : int64
        Offset : int64
        Length : int64
    }
    static member Null = Unchecked.defaultof<CompilationMessage>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.CompilationMessage> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _messageArr = if isNull this.Message then null else Encoding.UTF8.GetBytes(this.Message)
                use _messagePtr = fixed _messageArr
                let _messageLen = WebGPU.Raw.StringView(_messagePtr, if isNull _messageArr then 0un else unativeint _messageArr.Length)
                let mutable value =
                    new WebGPU.Raw.CompilationMessage(
                        nextInChain,
                        _messageLen,
                        this.Type,
                        uint64(this.LineNum),
                        uint64(this.LinePos),
                        uint64(this.Offset),
                        uint64(this.Length)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.CompilationMessage> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.CompilationMessage>) = 
        {
            Next = ExtensionDecoder.decode<ICompilationMessageExtension> device backend.NextInChain
            Message = let _messagePtr = NativePtr.toNativeInt(backend.Message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(backend.Message.Length))
            Type = backend.Type
            LineNum = int64(backend.LineNum)
            LinePos = int64(backend.LinePos)
            Offset = int64(backend.Offset)
            Length = int64(backend.Length)
        }
type DawnCompilationMessageUtf16 = 
    {
        Next : ICompilationMessageExtension
        LinePos : int64
        Offset : int64
        Length : int64
    }
    static member Null = Unchecked.defaultof<DawnCompilationMessageUtf16>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnCompilationMessageUtf16> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnCompilationMessageUtf16
                let mutable value =
                    new WebGPU.Raw.DawnCompilationMessageUtf16(
                        nextInChain,
                        sType,
                        uint64(this.LinePos),
                        uint64(this.Offset),
                        uint64(this.Length)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ICompilationMessageExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnCompilationMessageUtf16> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnCompilationMessageUtf16>) = 
        {
            Next = ExtensionDecoder.decode<ICompilationMessageExtension> device backend.NextInChain
            LinePos = int64(backend.LinePos)
            Offset = int64(backend.Offset)
            Length = int64(backend.Length)
        }
type ComputePassDescriptor = 
    {
        Label : string
        TimestampWrites : PassTimestampWrites
    }
    static member Null = Unchecked.defaultof<ComputePassDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ComputePassDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            this.TimestampWrites.Pin(device, fun _timestampWritesPtr ->
                let mutable value =
                    new WebGPU.Raw.ComputePassDescriptor(
                        nextInChain,
                        _labelLen,
                        _timestampWritesPtr
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ComputePassDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ComputePassDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            TimestampWrites = let m = NativePtr.toByRef backend.TimestampWrites in PassTimestampWrites.Read(device, &m)
        }
type ComputePassEncoder internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new ComputePassEncoder(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"ComputePassEncoder(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? ComputePassEncoder as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.InsertDebugMarker(markerLabel : string) : unit =
        let _markerLabelArr = if isNull markerLabel then null else Encoding.UTF8.GetBytes(markerLabel)
        use _markerLabelPtr = fixed _markerLabelArr
        let _markerLabelLen = WebGPU.Raw.StringView(_markerLabelPtr, if isNull _markerLabelArr then 0un else unativeint _markerLabelArr.Length)
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderInsertDebugMarker(handle, _markerLabelLen)
        res
    member this.PopDebugGroup() : unit =
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderPopDebugGroup(handle)
        res
    member this.PushDebugGroup(groupLabel : string) : unit =
        let _groupLabelArr = if isNull groupLabel then null else Encoding.UTF8.GetBytes(groupLabel)
        use _groupLabelPtr = fixed _groupLabelArr
        let _groupLabelLen = WebGPU.Raw.StringView(_groupLabelPtr, if isNull _groupLabelArr then 0un else unativeint _groupLabelArr.Length)
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderPushDebugGroup(handle, _groupLabelLen)
        res
    member this.SetPipeline(pipeline : ComputePipeline) : unit =
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderSetPipeline(handle, pipeline.Handle)
        res
    member this.SetBindGroup(groupIndex : int, group : BindGroup, dynamicOffsets : array<uint32>) : unit =
        use dynamicOffsetsPtr = fixed (dynamicOffsets)
        let dynamicOffsetsLen = unativeint dynamicOffsets.Length
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderSetBindGroup(handle, uint32(groupIndex), group.Handle, dynamicOffsetsLen, dynamicOffsetsPtr)
        res
    member this.WriteTimestamp(querySet : QuerySet, queryIndex : int) : unit =
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderWriteTimestamp(handle, querySet.Handle, uint32(queryIndex))
        res
    member this.DispatchWorkgroups(workgroupCountX : int, workgroupCountY : int, workgroupCountZ : int) : unit =
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderDispatchWorkgroups(handle, uint32(workgroupCountX), uint32(workgroupCountY), uint32(workgroupCountZ))
        res
    member this.DispatchWorkgroupsIndirect(indirectBuffer : Buffer, indirectOffset : int64) : unit =
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderDispatchWorkgroupsIndirect(handle, indirectBuffer.Handle, uint64(indirectOffset))
        res
    member this.End() : unit =
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderEnd(handle)
        res
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderSetLabel(handle, _labelLen)
        res
    member this.SetImmediateData(offset : int, data : nativeint, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderSetImmediateData(handle, uint32(offset), data, unativeint(size))
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.ComputePassEncoderAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type ComputePipeline internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new ComputePipeline(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"ComputePipeline(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? ComputePipeline as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.GetBindGroupLayout(groupIndex : int) : BindGroupLayout =
        let res = WebGPU.Raw.WebGPU.ComputePipelineGetBindGroupLayout(handle, uint32(groupIndex))
        new BindGroupLayout(res)
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.ComputePipelineSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.ComputePipelineRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.ComputePipelineAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type ComputePipelineDescriptor = 
    {
        Label : string
        Layout : PipelineLayout
        Compute : ComputeState
    }
    static member Null = Unchecked.defaultof<ComputePipelineDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ComputePipelineDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            this.Compute.Pin(device, fun _computePtr ->
                let mutable value =
                    new WebGPU.Raw.ComputePipelineDescriptor(
                        nextInChain,
                        _labelLen,
                        this.Layout.Handle,
                        (if NativePtr.toNativeInt _computePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _computePtr)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ComputePipelineDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ComputePipelineDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            Layout = new PipelineLayout(device, backend.Layout)
            Compute = ComputeState.Read(device, &backend.Compute)
        }
type CopyTextureForBrowserOptions = 
    {
        FlipY : bool
        NeedsColorSpaceConversion : bool
        SrcAlphaMode : AlphaMode
        SrcTransferFunctionParameters : float32
        ConversionMatrix : float32
        DstTransferFunctionParameters : float32
        DstAlphaMode : AlphaMode
        InternalUsage : bool
    }
    static member Null = Unchecked.defaultof<CopyTextureForBrowserOptions>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.CopyTextureForBrowserOptions> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable srcTransferFunctionParametersHandle = this.SrcTransferFunctionParameters
            use srcTransferFunctionParametersPtr = fixed (&srcTransferFunctionParametersHandle)
            let mutable conversionMatrixHandle = this.ConversionMatrix
            use conversionMatrixPtr = fixed (&conversionMatrixHandle)
            let mutable dstTransferFunctionParametersHandle = this.DstTransferFunctionParameters
            use dstTransferFunctionParametersPtr = fixed (&dstTransferFunctionParametersHandle)
            let mutable value =
                new WebGPU.Raw.CopyTextureForBrowserOptions(
                    nextInChain,
                    (if this.FlipY then 1 else 0),
                    (if this.NeedsColorSpaceConversion then 1 else 0),
                    this.SrcAlphaMode,
                    srcTransferFunctionParametersPtr,
                    conversionMatrixPtr,
                    dstTransferFunctionParametersPtr,
                    this.DstAlphaMode,
                    (if this.InternalUsage then 1 else 0)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.CopyTextureForBrowserOptions> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.CopyTextureForBrowserOptions>) = 
        {
            FlipY = (backend.FlipY <> 0)
            NeedsColorSpaceConversion = (backend.NeedsColorSpaceConversion <> 0)
            SrcAlphaMode = backend.SrcAlphaMode
            SrcTransferFunctionParameters = let ptr = backend.SrcTransferFunctionParameters in NativePtr.read ptr
            ConversionMatrix = let ptr = backend.ConversionMatrix in NativePtr.read ptr
            DstTransferFunctionParameters = let ptr = backend.DstTransferFunctionParameters in NativePtr.read ptr
            DstAlphaMode = backend.DstAlphaMode
            InternalUsage = (backend.InternalUsage <> 0)
        }
type CreateComputePipelineAsyncCallback = delegate of IDisposable * status : CreatePipelineAsyncStatus * pipeline : ComputePipeline * message : string -> unit
type CreateComputePipelineAsyncCallbackInfo = 
    {
        Mode : CallbackMode
        Callback : CreateComputePipelineAsyncCallback
    }
    static member Null = Unchecked.defaultof<CreateComputePipelineAsyncCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.CreateComputePipelineAsyncCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.CreateComputePipelineAsyncCallback>
                _callbackDel <- WebGPU.Raw.CreateComputePipelineAsyncCallback(fun status pipeline message userdata1 userdata2 ->
                    let _status = status
                    let _pipeline = new ComputePipeline(pipeline)
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _status, _pipeline, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.CreateComputePipelineAsyncCallbackInfo(
                    nextInChain,
                    this.Mode,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.CreateComputePipelineAsyncCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.CreateComputePipelineAsyncCallbackInfo>) = 
        {
            Mode = backend.Mode
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (mode, backend.Mode); (next in chain, backend.NextInChain); ... ]
        }
type CreateRenderPipelineAsyncCallback = delegate of IDisposable * status : CreatePipelineAsyncStatus * pipeline : RenderPipeline * message : string -> unit
type CreateRenderPipelineAsyncCallbackInfo = 
    {
        Mode : CallbackMode
        Callback : CreateRenderPipelineAsyncCallback
    }
    static member Null = Unchecked.defaultof<CreateRenderPipelineAsyncCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.CreateRenderPipelineAsyncCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.CreateRenderPipelineAsyncCallback>
                _callbackDel <- WebGPU.Raw.CreateRenderPipelineAsyncCallback(fun status pipeline message userdata1 userdata2 ->
                    let _status = status
                    let _pipeline = new RenderPipeline(pipeline)
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _status, _pipeline, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.CreateRenderPipelineAsyncCallbackInfo(
                    nextInChain,
                    this.Mode,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.CreateRenderPipelineAsyncCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.CreateRenderPipelineAsyncCallbackInfo>) = 
        {
            Mode = backend.Mode
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (mode, backend.Mode); (next in chain, backend.NextInChain); ... ]
        }
type AHardwareBufferProperties = 
    {
        YCbCrInfo : YCbCrVkDescriptor
    }
    static member Null = Unchecked.defaultof<AHardwareBufferProperties>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.AHardwareBufferProperties> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            this.YCbCrInfo.Pin(device, fun _yCbCrInfoPtr ->
                let mutable value =
                    new WebGPU.Raw.AHardwareBufferProperties(
                        (if NativePtr.toNativeInt _yCbCrInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _yCbCrInfoPtr)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.AHardwareBufferProperties> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.AHardwareBufferProperties>) = 
        {
            YCbCrInfo = YCbCrVkDescriptor.Read(device, &backend.YCbCrInfo)
        }
type Device internal(handle : nativeint) as device =
    static let nullptr = new Device(Unchecked.defaultof<_>)
    let mutable runtime : Aardvark.Rendering.IRuntime = Unchecked.defaultof<_>
    let adapter =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.DeviceGetAdapter(handle)
            new Adapter(res)
        )
    let queue =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.DeviceGetQueue(handle)
            new Queue(device, res)
        )
    member x.Handle = handle
    override x.ToString() = $"Device(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? Device as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member x.Runtime
        with get() : Aardvark.Rendering.IRuntime = runtime
        and set (v : Aardvark.Rendering.IRuntime) = runtime <- v
    member device.CreateBindGroup(descriptor : BindGroupDescriptor) : BindGroup =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateBindGroup(handle, _descriptorPtr)
            new BindGroup(device, res)
        )
    member device.CreateBindGroupLayout(descriptor : BindGroupLayoutDescriptor) : BindGroupLayout =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateBindGroupLayout(handle, _descriptorPtr)
            new BindGroupLayout(res)
        )
    member device.CreateBuffer(descriptor : BufferDescriptor) : Buffer =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateBuffer(handle, _descriptorPtr)
            new Buffer(device, res)
        )
    member device.CreateErrorBuffer(descriptor : BufferDescriptor) : Buffer =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateErrorBuffer(handle, _descriptorPtr)
            new Buffer(device, res)
        )
    member device.CreateCommandEncoder(descriptor : CommandEncoderDescriptor) : CommandEncoder =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateCommandEncoder(handle, _descriptorPtr)
            new CommandEncoder(device, res)
        )
    member device.CreateComputePipeline(descriptor : ComputePipelineDescriptor) : ComputePipeline =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateComputePipeline(handle, _descriptorPtr)
            new ComputePipeline(res)
        )
    member device.CreateComputePipelineAsync(descriptor : ComputePipelineDescriptor, callbackInfo : CreateComputePipelineAsyncCallbackInfo) : Future =
        descriptor.Pin(device, fun _descriptorPtr ->
            callbackInfo.Pin(device, fun _callbackInfoPtr ->
                let res = WebGPU.Raw.WebGPU.DeviceCreateComputePipelineAsync(handle, _descriptorPtr, (if NativePtr.toNativeInt _callbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _callbackInfoPtr))
                Future.Read(device, &res)
            )
        )
    member device.CreateExternalTexture(externalTextureDescriptor : ExternalTextureDescriptor) : ExternalTexture =
        externalTextureDescriptor.Pin(device, fun _externalTextureDescriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateExternalTexture(handle, _externalTextureDescriptorPtr)
            new ExternalTexture(device, res)
        )
    member device.CreateErrorExternalTexture() : ExternalTexture =
        let res = WebGPU.Raw.WebGPU.DeviceCreateErrorExternalTexture(handle)
        new ExternalTexture(device, res)
    member device.CreatePipelineLayout(descriptor : PipelineLayoutDescriptor) : PipelineLayout =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreatePipelineLayout(handle, _descriptorPtr)
            new PipelineLayout(device, res)
        )
    member device.CreateQuerySet(descriptor : QuerySetDescriptor) : QuerySet =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateQuerySet(handle, _descriptorPtr)
            new QuerySet(device, res)
        )
    member device.CreateRenderPipelineAsync(descriptor : RenderPipelineDescriptor, callbackInfo : CreateRenderPipelineAsyncCallbackInfo) : Future =
        descriptor.Pin(device, fun _descriptorPtr ->
            callbackInfo.Pin(device, fun _callbackInfoPtr ->
                let res = WebGPU.Raw.WebGPU.DeviceCreateRenderPipelineAsync(handle, _descriptorPtr, (if NativePtr.toNativeInt _callbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _callbackInfoPtr))
                Future.Read(device, &res)
            )
        )
    member device.CreateRenderBundleEncoder(descriptor : RenderBundleEncoderDescriptor) : RenderBundleEncoder =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateRenderBundleEncoder(handle, _descriptorPtr)
            new RenderBundleEncoder(device, res)
        )
    member device.CreateRenderPipeline(descriptor : RenderPipelineDescriptor) : RenderPipeline =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateRenderPipeline(handle, _descriptorPtr)
            new RenderPipeline(res)
        )
    member device.CreateSampler(descriptor : SamplerDescriptor) : Sampler =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateSampler(handle, _descriptorPtr)
            new Sampler(device, res)
        )
    member device.CreateShaderModule(descriptor : ShaderModuleDescriptor) : ShaderModule =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateShaderModule(handle, _descriptorPtr)
            new ShaderModule(device, res)
        )
    member device.CreateErrorShaderModule(descriptor : ShaderModuleDescriptor, errorMessage : string) : ShaderModule =
        descriptor.Pin(device, fun _descriptorPtr ->
            let _errorMessageArr = if isNull errorMessage then null else Encoding.UTF8.GetBytes(errorMessage)
            use _errorMessagePtr = fixed _errorMessageArr
            let _errorMessageLen = WebGPU.Raw.StringView(_errorMessagePtr, if isNull _errorMessageArr then 0un else unativeint _errorMessageArr.Length)
            let res = WebGPU.Raw.WebGPU.DeviceCreateErrorShaderModule(handle, _descriptorPtr, _errorMessageLen)
            new ShaderModule(device, res)
        )
    member device.CreateTexture(descriptor : TextureDescriptor) : Texture =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateTexture(handle, _descriptorPtr)
            new Texture(device, res)
        )
    member device.ImportSharedBufferMemory(descriptor : SharedBufferMemoryDescriptor) : SharedBufferMemory =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceImportSharedBufferMemory(handle, _descriptorPtr)
            new SharedBufferMemory(device, res)
        )
    member device.ImportSharedTextureMemory(descriptor : SharedTextureMemoryDescriptor) : SharedTextureMemory =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceImportSharedTextureMemory(handle, _descriptorPtr)
            new SharedTextureMemory(res)
        )
    member device.ImportSharedFence(descriptor : SharedFenceDescriptor) : SharedFence =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceImportSharedFence(handle, _descriptorPtr)
            new SharedFence(res)
        )
    member device.CreateErrorTexture(descriptor : TextureDescriptor) : Texture =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceCreateErrorTexture(handle, _descriptorPtr)
            new Texture(device, res)
        )
    member device.Destroy() : unit =
        let res = WebGPU.Raw.WebGPU.DeviceDestroy(handle)
        res
    member device.GetAHardwareBufferProperties(handle : nativeint, properties : byref<AHardwareBufferProperties>) : Status =
        let mutable propertiesCopy = properties
        try
            properties.Pin(device, fun _propertiesPtr ->
                if NativePtr.toNativeInt _propertiesPtr = 0n then
                    let mutable propertiesNative = Unchecked.defaultof<WebGPU.Raw.AHardwareBufferProperties>
                    use _propertiesPtr = fixed &propertiesNative
                    let res = WebGPU.Raw.WebGPU.DeviceGetAHardwareBufferProperties(handle, handle, _propertiesPtr)
                    let _ret = res
                    propertiesCopy <- AHardwareBufferProperties.Read(device, &propertiesNative)
                    _ret
                else
                    let res = WebGPU.Raw.WebGPU.DeviceGetAHardwareBufferProperties(handle, handle, _propertiesPtr)
                    let _ret = res
                    let propertiesResult = NativePtr.toByRef _propertiesPtr
                    propertiesCopy <- AHardwareBufferProperties.Read(device, &propertiesResult)
                    _ret
            )
        finally
            properties <- propertiesCopy
    member device.Limits : Limits =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        let status = WebGPU.Raw.WebGPU.DeviceGetLimits(handle, ptr)
        if status <> Status.Success then failwith "GetLimits failed"
        Limits.Read(device, &res)
    member device.GetLostFuture() : Future =
        let res = WebGPU.Raw.WebGPU.DeviceGetLostFuture(handle)
        Future.Read(device, &res)
    member device.HasFeature(feature : FeatureName) : bool =
        let res = WebGPU.Raw.WebGPU.DeviceHasFeature(handle, feature)
        (res <> 0)
    member device.Features : SupportedFeatures =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        WebGPU.Raw.WebGPU.DeviceGetFeatures(handle, ptr)
        SupportedFeatures.Read(device, &res)
    member device.AdapterInfo : AdapterInfo =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        let status = WebGPU.Raw.WebGPU.DeviceGetAdapterInfo(handle, ptr)
        if status <> Status.Success then failwith "GetAdapterInfo failed"
        AdapterInfo.Read(device, &res)
    member device.Adapter : Adapter =
        adapter.Value
    member device.Queue : Queue =
        queue.Value
    member device.InjectError(typ : ErrorType, message : string) : unit =
        let _messageArr = if isNull message then null else Encoding.UTF8.GetBytes(message)
        use _messagePtr = fixed _messageArr
        let _messageLen = WebGPU.Raw.StringView(_messagePtr, if isNull _messageArr then 0un else unativeint _messageArr.Length)
        let res = WebGPU.Raw.WebGPU.DeviceInjectError(handle, typ, _messageLen)
        res
    member device.ForceLoss(typ : DeviceLostReason, message : string) : unit =
        let _messageArr = if isNull message then null else Encoding.UTF8.GetBytes(message)
        use _messagePtr = fixed _messageArr
        let _messageLen = WebGPU.Raw.StringView(_messagePtr, if isNull _messageArr then 0un else unativeint _messageArr.Length)
        let res = WebGPU.Raw.WebGPU.DeviceForceLoss(handle, typ, _messageLen)
        res
    member device.Tick() : unit =
        let res = WebGPU.Raw.WebGPU.DeviceTick(handle)
        res
    member device.SetLoggingCallback(callbackInfo : LoggingCallbackInfo) : unit =
        callbackInfo.Pin(device, fun _callbackInfoPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceSetLoggingCallback(handle, (if NativePtr.toNativeInt _callbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _callbackInfoPtr))
            res
        )
    member device.PushErrorScope(filter : ErrorFilter) : unit =
        let res = WebGPU.Raw.WebGPU.DevicePushErrorScope(handle, filter)
        res
    member device.PopErrorScope(callbackInfo : PopErrorScopeCallbackInfo) : Future =
        callbackInfo.Pin(device, fun _callbackInfoPtr ->
            let res = WebGPU.Raw.WebGPU.DevicePopErrorScope(handle, (if NativePtr.toNativeInt _callbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _callbackInfoPtr))
            Future.Read(device, &res)
        )
    member device.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.DeviceSetLabel(handle, _labelLen)
        res
    member device.ValidateTextureDescriptor(descriptor : TextureDescriptor) : unit =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.DeviceValidateTextureDescriptor(handle, _descriptorPtr)
            res
        )
    member device.Release() : unit =
        let res = WebGPU.Raw.WebGPU.DeviceRelease(handle)
        res
    member device.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.DeviceAddRef(handle)
        res
    member x.Instance : Instance = x.Adapter.Instance
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type DeviceLostCallback = delegate of IDisposable * device : Device * reason : DeviceLostReason * message : string -> unit
type DeviceLostCallbackInfo = 
    {
        Mode : CallbackMode
        Callback : DeviceLostCallback
    }
    static member Null = Unchecked.defaultof<DeviceLostCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DeviceLostCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.DeviceLostCallback>
                _callbackDel <- WebGPU.Raw.DeviceLostCallback(fun device reason message userdata1 userdata2 ->
                    let _device = let ptr = device in new Device(NativePtr.read ptr)
                    let _reason = reason
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _device, _reason, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.DeviceLostCallbackInfo(
                    nextInChain,
                    this.Mode,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DeviceLostCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DeviceLostCallbackInfo>) = 
        {
            Mode = backend.Mode
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (mode, backend.Mode); (next in chain, backend.NextInChain); ... ]
        }
type UncapturedErrorCallback = delegate of IDisposable * device : Device * typ : ErrorType * message : string -> unit
type UncapturedErrorCallbackInfo = 
    {
        Callback : UncapturedErrorCallback
    }
    static member Null = Unchecked.defaultof<UncapturedErrorCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.UncapturedErrorCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.UncapturedErrorCallback>
                _callbackDel <- WebGPU.Raw.UncapturedErrorCallback(fun device typ message userdata1 userdata2 ->
                    let _device = let ptr = device in new Device(NativePtr.read ptr)
                    let _typ = typ
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _device, _typ, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.UncapturedErrorCallbackInfo(
                    nextInChain,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.UncapturedErrorCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.UncapturedErrorCallbackInfo>) = 
        {
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (next in chain, backend.NextInChain); (userdata1, backend.Userdata1); ... ]
        }
type PopErrorScopeCallback = delegate of IDisposable * status : PopErrorScopeStatus * typ : ErrorType * message : string -> unit
type PopErrorScopeCallbackInfo = 
    {
        Mode : CallbackMode
        Callback : PopErrorScopeCallback
    }
    static member Null = Unchecked.defaultof<PopErrorScopeCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.PopErrorScopeCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.PopErrorScopeCallback>
                _callbackDel <- WebGPU.Raw.PopErrorScopeCallback(fun status typ message userdata1 userdata2 ->
                    let _status = status
                    let _typ = typ
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _status, _typ, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.PopErrorScopeCallbackInfo(
                    nextInChain,
                    this.Mode,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.PopErrorScopeCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.PopErrorScopeCallbackInfo>) = 
        {
            Mode = backend.Mode
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (mode, backend.Mode); (next in chain, backend.NextInChain); ... ]
        }
type Limits = 
    {
        Next : ILimitsExtension
        MaxTextureDimension1D : int
        MaxTextureDimension2D : int
        MaxTextureDimension3D : int
        MaxTextureArrayLayers : int
        MaxBindGroups : int
        MaxBindGroupsPlusVertexBuffers : int
        MaxBindingsPerBindGroup : int
        MaxDynamicUniformBuffersPerPipelineLayout : int
        MaxDynamicStorageBuffersPerPipelineLayout : int
        MaxSampledTexturesPerShaderStage : int
        MaxSamplersPerShaderStage : int
        MaxStorageBuffersPerShaderStage : int
        MaxStorageTexturesPerShaderStage : int
        MaxUniformBuffersPerShaderStage : int
        MaxUniformBufferBindingSize : int64
        MaxStorageBufferBindingSize : int64
        MinUniformBufferOffsetAlignment : int
        MinStorageBufferOffsetAlignment : int
        MaxVertexBuffers : int
        MaxBufferSize : int64
        MaxVertexAttributes : int
        MaxVertexBufferArrayStride : int
        MaxInterStageShaderVariables : int
        MaxColorAttachments : int
        MaxColorAttachmentBytesPerSample : int
        MaxComputeWorkgroupStorageSize : int
        MaxComputeInvocationsPerWorkgroup : int
        MaxComputeWorkgroupSizeX : int
        MaxComputeWorkgroupSizeY : int
        MaxComputeWorkgroupSizeZ : int
        MaxComputeWorkgroupsPerDimension : int
        MaxImmediateSize : int
        MaxStorageBuffersInVertexStage : int
        MaxStorageTexturesInVertexStage : int
        MaxStorageBuffersInFragmentStage : int
        MaxStorageTexturesInFragmentStage : int
    }
    static member Null = Unchecked.defaultof<Limits>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.Limits> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let mutable value =
                    new WebGPU.Raw.Limits(
                        nextInChain,
                        uint32(this.MaxTextureDimension1D),
                        uint32(this.MaxTextureDimension2D),
                        uint32(this.MaxTextureDimension3D),
                        uint32(this.MaxTextureArrayLayers),
                        uint32(this.MaxBindGroups),
                        uint32(this.MaxBindGroupsPlusVertexBuffers),
                        uint32(this.MaxBindingsPerBindGroup),
                        uint32(this.MaxDynamicUniformBuffersPerPipelineLayout),
                        uint32(this.MaxDynamicStorageBuffersPerPipelineLayout),
                        uint32(this.MaxSampledTexturesPerShaderStage),
                        uint32(this.MaxSamplersPerShaderStage),
                        uint32(this.MaxStorageBuffersPerShaderStage),
                        uint32(this.MaxStorageTexturesPerShaderStage),
                        uint32(this.MaxUniformBuffersPerShaderStage),
                        uint64(this.MaxUniformBufferBindingSize),
                        uint64(this.MaxStorageBufferBindingSize),
                        uint32(this.MinUniformBufferOffsetAlignment),
                        uint32(this.MinStorageBufferOffsetAlignment),
                        uint32(this.MaxVertexBuffers),
                        uint64(this.MaxBufferSize),
                        uint32(this.MaxVertexAttributes),
                        uint32(this.MaxVertexBufferArrayStride),
                        uint32(this.MaxInterStageShaderVariables),
                        uint32(this.MaxColorAttachments),
                        uint32(this.MaxColorAttachmentBytesPerSample),
                        uint32(this.MaxComputeWorkgroupStorageSize),
                        uint32(this.MaxComputeInvocationsPerWorkgroup),
                        uint32(this.MaxComputeWorkgroupSizeX),
                        uint32(this.MaxComputeWorkgroupSizeY),
                        uint32(this.MaxComputeWorkgroupSizeZ),
                        uint32(this.MaxComputeWorkgroupsPerDimension),
                        uint32(this.MaxImmediateSize),
                        uint32(this.MaxStorageBuffersInVertexStage),
                        uint32(this.MaxStorageTexturesInVertexStage),
                        uint32(this.MaxStorageBuffersInFragmentStage),
                        uint32(this.MaxStorageTexturesInFragmentStage)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.Limits> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.Limits>) = 
        {
            Next = ExtensionDecoder.decode<ILimitsExtension> device backend.NextInChain
            MaxTextureDimension1D = int(backend.MaxTextureDimension1D)
            MaxTextureDimension2D = int(backend.MaxTextureDimension2D)
            MaxTextureDimension3D = int(backend.MaxTextureDimension3D)
            MaxTextureArrayLayers = int(backend.MaxTextureArrayLayers)
            MaxBindGroups = int(backend.MaxBindGroups)
            MaxBindGroupsPlusVertexBuffers = int(backend.MaxBindGroupsPlusVertexBuffers)
            MaxBindingsPerBindGroup = int(backend.MaxBindingsPerBindGroup)
            MaxDynamicUniformBuffersPerPipelineLayout = int(backend.MaxDynamicUniformBuffersPerPipelineLayout)
            MaxDynamicStorageBuffersPerPipelineLayout = int(backend.MaxDynamicStorageBuffersPerPipelineLayout)
            MaxSampledTexturesPerShaderStage = int(backend.MaxSampledTexturesPerShaderStage)
            MaxSamplersPerShaderStage = int(backend.MaxSamplersPerShaderStage)
            MaxStorageBuffersPerShaderStage = int(backend.MaxStorageBuffersPerShaderStage)
            MaxStorageTexturesPerShaderStage = int(backend.MaxStorageTexturesPerShaderStage)
            MaxUniformBuffersPerShaderStage = int(backend.MaxUniformBuffersPerShaderStage)
            MaxUniformBufferBindingSize = int64(backend.MaxUniformBufferBindingSize)
            MaxStorageBufferBindingSize = int64(backend.MaxStorageBufferBindingSize)
            MinUniformBufferOffsetAlignment = int(backend.MinUniformBufferOffsetAlignment)
            MinStorageBufferOffsetAlignment = int(backend.MinStorageBufferOffsetAlignment)
            MaxVertexBuffers = int(backend.MaxVertexBuffers)
            MaxBufferSize = int64(backend.MaxBufferSize)
            MaxVertexAttributes = int(backend.MaxVertexAttributes)
            MaxVertexBufferArrayStride = int(backend.MaxVertexBufferArrayStride)
            MaxInterStageShaderVariables = int(backend.MaxInterStageShaderVariables)
            MaxColorAttachments = int(backend.MaxColorAttachments)
            MaxColorAttachmentBytesPerSample = int(backend.MaxColorAttachmentBytesPerSample)
            MaxComputeWorkgroupStorageSize = int(backend.MaxComputeWorkgroupStorageSize)
            MaxComputeInvocationsPerWorkgroup = int(backend.MaxComputeInvocationsPerWorkgroup)
            MaxComputeWorkgroupSizeX = int(backend.MaxComputeWorkgroupSizeX)
            MaxComputeWorkgroupSizeY = int(backend.MaxComputeWorkgroupSizeY)
            MaxComputeWorkgroupSizeZ = int(backend.MaxComputeWorkgroupSizeZ)
            MaxComputeWorkgroupsPerDimension = int(backend.MaxComputeWorkgroupsPerDimension)
            MaxImmediateSize = int(backend.MaxImmediateSize)
            MaxStorageBuffersInVertexStage = int(backend.MaxStorageBuffersInVertexStage)
            MaxStorageTexturesInVertexStage = int(backend.MaxStorageTexturesInVertexStage)
            MaxStorageBuffersInFragmentStage = int(backend.MaxStorageBuffersInFragmentStage)
            MaxStorageTexturesInFragmentStage = int(backend.MaxStorageTexturesInFragmentStage)
        }
type DawnTexelCopyBufferRowAlignmentLimits = 
    {
        Next : ILimitsExtension
        MinTexelCopyBufferRowAlignment : int
    }
    static member Null = Unchecked.defaultof<DawnTexelCopyBufferRowAlignmentLimits>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnTexelCopyBufferRowAlignmentLimits> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnTexelCopyBufferRowAlignmentLimits
                let mutable value =
                    new WebGPU.Raw.DawnTexelCopyBufferRowAlignmentLimits(
                        nextInChain,
                        sType,
                        uint32(this.MinTexelCopyBufferRowAlignment)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ILimitsExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnTexelCopyBufferRowAlignmentLimits> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnTexelCopyBufferRowAlignmentLimits>) = 
        {
            Next = ExtensionDecoder.decode<ILimitsExtension> device backend.NextInChain
            MinTexelCopyBufferRowAlignment = int(backend.MinTexelCopyBufferRowAlignment)
        }
type DawnHostMappedPointerLimits = 
    {
        Next : ILimitsExtension
        HostMappedPointerAlignment : int
    }
    static member Null = Unchecked.defaultof<DawnHostMappedPointerLimits>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnHostMappedPointerLimits> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnHostMappedPointerLimits
                let mutable value =
                    new WebGPU.Raw.DawnHostMappedPointerLimits(
                        nextInChain,
                        sType,
                        uint32(this.HostMappedPointerAlignment)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ILimitsExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnHostMappedPointerLimits> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnHostMappedPointerLimits>) = 
        {
            Next = ExtensionDecoder.decode<ILimitsExtension> device backend.NextInChain
            HostMappedPointerAlignment = int(backend.HostMappedPointerAlignment)
        }
type SupportedFeatures = 
    {
        Features : array<FeatureName>
    }
    static member Null = Unchecked.defaultof<SupportedFeatures>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SupportedFeatures> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            use featuresPtr = fixed (this.Features)
            let featuresLen = unativeint this.Features.Length
            let mutable value =
                new WebGPU.Raw.SupportedFeatures(
                    featuresLen,
                    featuresPtr
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SupportedFeatures> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SupportedFeatures>) = 
        {
            Features = let ptr = backend.Features in Array.init (int backend.FeatureCount) (fun i -> NativePtr.get ptr i)
        }
type SupportedWGSLLanguageFeatures = 
    {
        Features : array<WGSLLanguageFeatureName>
    }
    static member Null = Unchecked.defaultof<SupportedWGSLLanguageFeatures>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SupportedWGSLLanguageFeatures> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            use featuresPtr = fixed (this.Features)
            let featuresLen = unativeint this.Features.Length
            let mutable value =
                new WebGPU.Raw.SupportedWGSLLanguageFeatures(
                    featuresLen,
                    featuresPtr
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SupportedWGSLLanguageFeatures> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SupportedWGSLLanguageFeatures>) = 
        {
            Features = let ptr = backend.Features in Array.init (int backend.FeatureCount) (fun i -> NativePtr.get ptr i)
        }
type LoggingCallback = delegate of IDisposable * typ : LoggingType * message : string -> unit
type LoggingCallbackInfo = 
    {
        Callback : LoggingCallback
    }
    static member Null = Unchecked.defaultof<LoggingCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.LoggingCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.LoggingCallback>
                _callbackDel <- WebGPU.Raw.LoggingCallback(fun typ message userdata1 userdata2 ->
                    let _typ = typ
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _typ, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.LoggingCallbackInfo(
                    nextInChain,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.LoggingCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.LoggingCallbackInfo>) = 
        {
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (next in chain, backend.NextInChain); (userdata1, backend.Userdata1); ... ]
        }
type Extent2D = 
    {
        Width : int
        Height : int
    }
    static member Null = Unchecked.defaultof<Extent2D>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.Extent2D> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.Extent2D(
                    uint32(this.Width),
                    uint32(this.Height)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.Extent2D> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.Extent2D>) = 
        {
            Width = int(backend.Width)
            Height = int(backend.Height)
        }
type Extent3D = 
    {
        Width : int
        Height : int
        DepthOrArrayLayers : int
    }
    static member Null = Unchecked.defaultof<Extent3D>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.Extent3D> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.Extent3D(
                    uint32(this.Width),
                    uint32(this.Height),
                    uint32(this.DepthOrArrayLayers)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.Extent3D> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.Extent3D>) = 
        {
            Width = int(backend.Width)
            Height = int(backend.Height)
            DepthOrArrayLayers = int(backend.DepthOrArrayLayers)
        }
type ExternalTexture internal(device : Device, handle : nativeint) =
    static let nullptr = new ExternalTexture(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"ExternalTexture(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? ExternalTexture as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.ExternalTextureSetLabel(handle, _labelLen)
        res
    member this.Destroy() : unit =
        let res = WebGPU.Raw.WebGPU.ExternalTextureDestroy(handle)
        res
    member this.Expire() : unit =
        let res = WebGPU.Raw.WebGPU.ExternalTextureExpire(handle)
        res
    member this.Refresh() : unit =
        let res = WebGPU.Raw.WebGPU.ExternalTextureRefresh(handle)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.ExternalTextureRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.ExternalTextureAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type ExternalTextureDescriptor = 
    {
        Label : string
        Plane0 : TextureView
        Plane1 : TextureView
        CropOrigin : Origin2D
        CropSize : Extent2D
        ApparentSize : Extent2D
        DoYuvToRgbConversionOnly : bool
        YuvToRgbConversionMatrix : float32
        SrcTransferFunctionParameters : float32
        DstTransferFunctionParameters : float32
        GamutConversionMatrix : float32
        Mirrored : bool
        Rotation : ExternalTextureRotation
    }
    static member Null = Unchecked.defaultof<ExternalTextureDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ExternalTextureDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            this.CropOrigin.Pin(device, fun _cropOriginPtr ->
                this.CropSize.Pin(device, fun _cropSizePtr ->
                    this.ApparentSize.Pin(device, fun _apparentSizePtr ->
                        let mutable yuvToRgbConversionMatrixHandle = this.YuvToRgbConversionMatrix
                        use yuvToRgbConversionMatrixPtr = fixed (&yuvToRgbConversionMatrixHandle)
                        let mutable srcTransferFunctionParametersHandle = this.SrcTransferFunctionParameters
                        use srcTransferFunctionParametersPtr = fixed (&srcTransferFunctionParametersHandle)
                        let mutable dstTransferFunctionParametersHandle = this.DstTransferFunctionParameters
                        use dstTransferFunctionParametersPtr = fixed (&dstTransferFunctionParametersHandle)
                        let mutable gamutConversionMatrixHandle = this.GamutConversionMatrix
                        use gamutConversionMatrixPtr = fixed (&gamutConversionMatrixHandle)
                        let mutable value =
                            new WebGPU.Raw.ExternalTextureDescriptor(
                                nextInChain,
                                _labelLen,
                                this.Plane0.Handle,
                                this.Plane1.Handle,
                                (if NativePtr.toNativeInt _cropOriginPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _cropOriginPtr),
                                (if NativePtr.toNativeInt _cropSizePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _cropSizePtr),
                                (if NativePtr.toNativeInt _apparentSizePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _apparentSizePtr),
                                (if this.DoYuvToRgbConversionOnly then 1 else 0),
                                yuvToRgbConversionMatrixPtr,
                                srcTransferFunctionParametersPtr,
                                dstTransferFunctionParametersPtr,
                                gamutConversionMatrixPtr,
                                (if this.Mirrored then 1 else 0),
                                this.Rotation
                            )
                        use ptr = fixed &value
                        action ptr
                    )
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ExternalTextureDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ExternalTextureDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            Plane0 = new TextureView(backend.Plane0)
            Plane1 = new TextureView(backend.Plane1)
            CropOrigin = Origin2D.Read(device, &backend.CropOrigin)
            CropSize = Extent2D.Read(device, &backend.CropSize)
            ApparentSize = Extent2D.Read(device, &backend.ApparentSize)
            DoYuvToRgbConversionOnly = (backend.DoYuvToRgbConversionOnly <> 0)
            YuvToRgbConversionMatrix = let ptr = backend.YuvToRgbConversionMatrix in NativePtr.read ptr
            SrcTransferFunctionParameters = let ptr = backend.SrcTransferFunctionParameters in NativePtr.read ptr
            DstTransferFunctionParameters = let ptr = backend.DstTransferFunctionParameters in NativePtr.read ptr
            GamutConversionMatrix = let ptr = backend.GamutConversionMatrix in NativePtr.read ptr
            Mirrored = (backend.Mirrored <> 0)
            Rotation = backend.Rotation
        }
type SharedBufferMemory internal(device : Device, handle : nativeint) =
    static let nullptr = new SharedBufferMemory(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"SharedBufferMemory(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? SharedBufferMemory as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.SharedBufferMemorySetLabel(handle, _labelLen)
        res
    member this.Properties : SharedBufferMemoryProperties =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        let status = WebGPU.Raw.WebGPU.SharedBufferMemoryGetProperties(handle, ptr)
        if status <> Status.Success then failwith "GetProperties failed"
        SharedBufferMemoryProperties.Read(device, &res)
    member this.CreateBuffer(descriptor : BufferDescriptor) : Buffer =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.SharedBufferMemoryCreateBuffer(handle, _descriptorPtr)
            new Buffer(device, res)
        )
    member this.BeginAccess(buffer : Buffer, descriptor : SharedBufferMemoryBeginAccessDescriptor) : Status =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.SharedBufferMemoryBeginAccess(handle, buffer.Handle, _descriptorPtr)
            res
        )
    member this.EndAccess(buffer : Buffer, descriptor : byref<SharedBufferMemoryEndAccessState>) : Status =
        let mutable descriptorCopy = descriptor
        try
            descriptor.Pin(device, fun _descriptorPtr ->
                if NativePtr.toNativeInt _descriptorPtr = 0n then
                    let mutable descriptorNative = Unchecked.defaultof<WebGPU.Raw.SharedBufferMemoryEndAccessState>
                    use _descriptorPtr = fixed &descriptorNative
                    let res = WebGPU.Raw.WebGPU.SharedBufferMemoryEndAccess(handle, buffer.Handle, _descriptorPtr)
                    let _ret = res
                    descriptorCopy <- SharedBufferMemoryEndAccessState.Read(device, &descriptorNative)
                    _ret
                else
                    let res = WebGPU.Raw.WebGPU.SharedBufferMemoryEndAccess(handle, buffer.Handle, _descriptorPtr)
                    let _ret = res
                    let descriptorResult = NativePtr.toByRef _descriptorPtr
                    descriptorCopy <- SharedBufferMemoryEndAccessState.Read(device, &descriptorResult)
                    _ret
            )
        finally
            descriptor <- descriptorCopy
    member this.IsDeviceLost() : bool =
        let res = WebGPU.Raw.WebGPU.SharedBufferMemoryIsDeviceLost(handle)
        (res <> 0)
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.SharedBufferMemoryRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.SharedBufferMemoryAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type SharedBufferMemoryProperties = 
    {
        Usage : BufferUsage
        Size : int64
    }
    static member Null = Unchecked.defaultof<SharedBufferMemoryProperties>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedBufferMemoryProperties> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.SharedBufferMemoryProperties(
                    nextInChain,
                    this.Usage,
                    uint64(this.Size)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedBufferMemoryProperties> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedBufferMemoryProperties>) = 
        {
            Usage = backend.Usage
            Size = int64(backend.Size)
        }
type SharedBufferMemoryDescriptor = 
    {
        Label : string
    }
    static member Null = Unchecked.defaultof<SharedBufferMemoryDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedBufferMemoryDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            let mutable value =
                new WebGPU.Raw.SharedBufferMemoryDescriptor(
                    nextInChain,
                    _labelLen
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedBufferMemoryDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedBufferMemoryDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
        }
type SharedTextureMemory internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new SharedTextureMemory(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"SharedTextureMemory(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? SharedTextureMemory as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.SharedTextureMemorySetLabel(handle, _labelLen)
        res
    member this.Properties : SharedTextureMemoryProperties =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        let status = WebGPU.Raw.WebGPU.SharedTextureMemoryGetProperties(handle, ptr)
        if status <> Status.Success then failwith "GetProperties failed"
        SharedTextureMemoryProperties.Read(device, &res)
    member this.CreateTexture(descriptor : TextureDescriptor) : Texture =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.SharedTextureMemoryCreateTexture(handle, _descriptorPtr)
            new Texture(device, res)
        )
    member this.BeginAccess(texture : Texture, descriptor : SharedTextureMemoryBeginAccessDescriptor) : Status =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.SharedTextureMemoryBeginAccess(handle, texture.Handle, _descriptorPtr)
            res
        )
    member this.EndAccess(texture : Texture, descriptor : byref<SharedTextureMemoryEndAccessState>) : Status =
        let mutable descriptorCopy = descriptor
        try
            descriptor.Pin(device, fun _descriptorPtr ->
                if NativePtr.toNativeInt _descriptorPtr = 0n then
                    let mutable descriptorNative = Unchecked.defaultof<WebGPU.Raw.SharedTextureMemoryEndAccessState>
                    use _descriptorPtr = fixed &descriptorNative
                    let res = WebGPU.Raw.WebGPU.SharedTextureMemoryEndAccess(handle, texture.Handle, _descriptorPtr)
                    let _ret = res
                    descriptorCopy <- SharedTextureMemoryEndAccessState.Read(device, &descriptorNative)
                    _ret
                else
                    let res = WebGPU.Raw.WebGPU.SharedTextureMemoryEndAccess(handle, texture.Handle, _descriptorPtr)
                    let _ret = res
                    let descriptorResult = NativePtr.toByRef _descriptorPtr
                    descriptorCopy <- SharedTextureMemoryEndAccessState.Read(device, &descriptorResult)
                    _ret
            )
        finally
            descriptor <- descriptorCopy
    member this.IsDeviceLost() : bool =
        let res = WebGPU.Raw.WebGPU.SharedTextureMemoryIsDeviceLost(handle)
        (res <> 0)
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.SharedTextureMemoryRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.SharedTextureMemoryAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type SharedTextureMemoryProperties = 
    {
        Next : ISharedTextureMemoryPropertiesExtension
        Usage : TextureUsage
        Size : Extent3D
        Format : TextureFormat
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryProperties>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryProperties> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                this.Size.Pin(device, fun _sizePtr ->
                    let mutable value =
                        new WebGPU.Raw.SharedTextureMemoryProperties(
                            nextInChain,
                            this.Usage,
                            (if NativePtr.toNativeInt _sizePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _sizePtr),
                            this.Format
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryProperties> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryProperties>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryPropertiesExtension> device backend.NextInChain
            Usage = backend.Usage
            Size = Extent3D.Read(device, &backend.Size)
            Format = backend.Format
        }
type SharedTextureMemoryAHardwareBufferProperties = 
    {
        Next : ISharedTextureMemoryPropertiesExtension
        YCbCrInfo : YCbCrVkDescriptor
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryAHardwareBufferProperties>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryAHardwareBufferProperties> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryAHardwareBufferProperties
                this.YCbCrInfo.Pin(device, fun _yCbCrInfoPtr ->
                    let mutable value =
                        new WebGPU.Raw.SharedTextureMemoryAHardwareBufferProperties(
                            nextInChain,
                            sType,
                            (if NativePtr.toNativeInt _yCbCrInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _yCbCrInfoPtr)
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryPropertiesExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryAHardwareBufferProperties> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryAHardwareBufferProperties>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryPropertiesExtension> device backend.NextInChain
            YCbCrInfo = YCbCrVkDescriptor.Read(device, &backend.YCbCrInfo)
        }
type SharedTextureMemoryDescriptor = 
    {
        Next : ISharedTextureMemoryDescriptorExtension
        Label : string
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryDescriptor(
                        nextInChain,
                        _labelLen
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
        }
type SharedBufferMemoryBeginAccessDescriptor = 
    {
        Initialized : bool
        Fences : array<SharedFence>
        SignaledValues : array<uint64>
    }
    static member Null = Unchecked.defaultof<SharedBufferMemoryBeginAccessDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedBufferMemoryBeginAccessDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let fencesHandles = this.Fences |> Array.map (fun a -> a.Handle)
            use fencesPtr = fixed (fencesHandles)
            let fencesLen = unativeint this.Fences.Length
            use signaledValuesPtr = fixed (this.SignaledValues)
            let signaledValuesLen = unativeint this.SignaledValues.Length
            let mutable value =
                new WebGPU.Raw.SharedBufferMemoryBeginAccessDescriptor(
                    nextInChain,
                    (if this.Initialized then 1 else 0),
                    signaledValuesLen,
                    fencesPtr,
                    signaledValuesPtr
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedBufferMemoryBeginAccessDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedBufferMemoryBeginAccessDescriptor>) = 
        {
            Initialized = (backend.Initialized <> 0)
            Fences = let ptr = backend.Fences in Array.init (int backend.FenceCount) (fun i -> new SharedFence(NativePtr.get ptr i))
            SignaledValues = let ptr = backend.SignaledValues in Array.init (int backend.FenceCount) (fun i -> NativePtr.get ptr i)
        }
type SharedBufferMemoryEndAccessState = 
    {
        Initialized : bool
        Fences : array<SharedFence>
        SignaledValues : array<uint64>
    }
    static member Null = Unchecked.defaultof<SharedBufferMemoryEndAccessState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedBufferMemoryEndAccessState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let fencesHandles = this.Fences |> Array.map (fun a -> a.Handle)
            use fencesPtr = fixed (fencesHandles)
            let fencesLen = unativeint this.Fences.Length
            use signaledValuesPtr = fixed (this.SignaledValues)
            let signaledValuesLen = unativeint this.SignaledValues.Length
            let mutable value =
                new WebGPU.Raw.SharedBufferMemoryEndAccessState(
                    nextInChain,
                    (if this.Initialized then 1 else 0),
                    signaledValuesLen,
                    fencesPtr,
                    signaledValuesPtr
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedBufferMemoryEndAccessState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedBufferMemoryEndAccessState>) = 
        {
            Initialized = (backend.Initialized <> 0)
            Fences = let ptr = backend.Fences in Array.init (int backend.FenceCount) (fun i -> new SharedFence(NativePtr.get ptr i))
            SignaledValues = let ptr = backend.SignaledValues in Array.init (int backend.FenceCount) (fun i -> NativePtr.get ptr i)
        }
type SharedTextureMemoryVkDedicatedAllocationDescriptor = 
    {
        Next : ISharedTextureMemoryDescriptorExtension
        DedicatedAllocation : bool
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryVkDedicatedAllocationDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryVkDedicatedAllocationDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryVkDedicatedAllocationDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryVkDedicatedAllocationDescriptor(
                        nextInChain,
                        sType,
                        (if this.DedicatedAllocation then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryVkDedicatedAllocationDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryVkDedicatedAllocationDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryDescriptorExtension> device backend.NextInChain
            DedicatedAllocation = (backend.DedicatedAllocation <> 0)
        }
type SharedTextureMemoryAHardwareBufferDescriptor = 
    {
        Next : ISharedTextureMemoryDescriptorExtension
        Handle : nativeint
        UseExternalFormat : bool
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryAHardwareBufferDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryAHardwareBufferDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryAHardwareBufferDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryAHardwareBufferDescriptor(
                        nextInChain,
                        sType,
                        this.Handle,
                        (if this.UseExternalFormat then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryAHardwareBufferDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryAHardwareBufferDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryDescriptorExtension> device backend.NextInChain
            Handle = backend.Handle
            UseExternalFormat = (backend.UseExternalFormat <> 0)
        }
type SharedTextureMemoryDmaBufPlane = 
    {
        Fd : int
        Offset : int64
        Stride : int
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryDmaBufPlane>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryDmaBufPlane> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.SharedTextureMemoryDmaBufPlane(
                    this.Fd,
                    uint64(this.Offset),
                    uint32(this.Stride)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryDmaBufPlane> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryDmaBufPlane>) = 
        {
            Fd = backend.Fd
            Offset = int64(backend.Offset)
            Stride = int(backend.Stride)
        }
type SharedTextureMemoryDmaBufDescriptor = 
    {
        Next : ISharedTextureMemoryDescriptorExtension
        Size : Extent3D
        DrmFormat : int
        DrmModifier : int64
        Planes : array<SharedTextureMemoryDmaBufPlane>
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryDmaBufDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryDmaBufDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryDmaBufDescriptor
                this.Size.Pin(device, fun _sizePtr ->
                    WebGPU.Raw.Pinnable.pinArray device this.Planes (fun planesPtr ->
                        let planesLen = unativeint this.Planes.Length
                        let mutable value =
                            new WebGPU.Raw.SharedTextureMemoryDmaBufDescriptor(
                                nextInChain,
                                sType,
                                (if NativePtr.toNativeInt _sizePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _sizePtr),
                                uint32(this.DrmFormat),
                                uint64(this.DrmModifier),
                                planesLen,
                                planesPtr
                            )
                        use ptr = fixed &value
                        action ptr
                    )
                )
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryDmaBufDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryDmaBufDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryDescriptorExtension> device backend.NextInChain
            Size = Extent3D.Read(device, &backend.Size)
            DrmFormat = int(backend.DrmFormat)
            DrmModifier = int64(backend.DrmModifier)
            Planes = let ptr = backend.Planes in Array.init (int backend.PlaneCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in SharedTextureMemoryDmaBufPlane.Read(device, &r))
        }
type SharedTextureMemoryOpaqueFDDescriptor = 
    {
        Next : ISharedTextureMemoryDescriptorExtension
        VkImageCreateInfo : nativeint
        MemoryFD : int
        MemoryTypeIndex : int
        AllocationSize : int64
        DedicatedAllocation : bool
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryOpaqueFDDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryOpaqueFDDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryOpaqueFDDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryOpaqueFDDescriptor(
                        nextInChain,
                        sType,
                        this.VkImageCreateInfo,
                        this.MemoryFD,
                        uint32(this.MemoryTypeIndex),
                        uint64(this.AllocationSize),
                        (if this.DedicatedAllocation then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryOpaqueFDDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryOpaqueFDDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryDescriptorExtension> device backend.NextInChain
            VkImageCreateInfo = backend.VkImageCreateInfo
            MemoryFD = backend.MemoryFD
            MemoryTypeIndex = int(backend.MemoryTypeIndex)
            AllocationSize = int64(backend.AllocationSize)
            DedicatedAllocation = (backend.DedicatedAllocation <> 0)
        }
type SharedTextureMemoryZirconHandleDescriptor = 
    {
        Next : ISharedTextureMemoryDescriptorExtension
        MemoryFD : int
        AllocationSize : int64
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryZirconHandleDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryZirconHandleDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryZirconHandleDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryZirconHandleDescriptor(
                        nextInChain,
                        sType,
                        uint32(this.MemoryFD),
                        uint64(this.AllocationSize)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryZirconHandleDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryZirconHandleDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryDescriptorExtension> device backend.NextInChain
            MemoryFD = int(backend.MemoryFD)
            AllocationSize = int64(backend.AllocationSize)
        }
type SharedTextureMemoryDXGISharedHandleDescriptor = 
    {
        Next : ISharedTextureMemoryDescriptorExtension
        Handle : nativeint
        UseKeyedMutex : bool
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryDXGISharedHandleDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryDXGISharedHandleDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryDXGISharedHandleDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryDXGISharedHandleDescriptor(
                        nextInChain,
                        sType,
                        this.Handle,
                        (if this.UseKeyedMutex then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryDXGISharedHandleDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryDXGISharedHandleDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryDescriptorExtension> device backend.NextInChain
            Handle = backend.Handle
            UseKeyedMutex = (backend.UseKeyedMutex <> 0)
        }
type SharedTextureMemoryIOSurfaceDescriptor = 
    {
        Next : ISharedTextureMemoryDescriptorExtension
        IoSurface : nativeint
        AllowStorageBinding : bool
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryIOSurfaceDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryIOSurfaceDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryIOSurfaceDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryIOSurfaceDescriptor(
                        nextInChain,
                        sType,
                        this.IoSurface,
                        (if this.AllowStorageBinding then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryIOSurfaceDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryIOSurfaceDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryDescriptorExtension> device backend.NextInChain
            IoSurface = backend.IoSurface
            AllowStorageBinding = (backend.AllowStorageBinding <> 0)
        }
type SharedTextureMemoryEGLImageDescriptor = 
    {
        Next : ISharedTextureMemoryDescriptorExtension
        Image : nativeint
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryEGLImageDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryEGLImageDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryEGLImageDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryEGLImageDescriptor(
                        nextInChain,
                        sType,
                        this.Image
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryEGLImageDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryEGLImageDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryDescriptorExtension> device backend.NextInChain
            Image = backend.Image
        }
type SharedTextureMemoryBeginAccessDescriptor = 
    {
        Next : ISharedTextureMemoryBeginAccessDescriptorExtension
        ConcurrentRead : bool
        Initialized : bool
        Fences : array<SharedFence>
        SignaledValues : array<uint64>
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryBeginAccessDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryBeginAccessDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let fencesHandles = this.Fences |> Array.map (fun a -> a.Handle)
                use fencesPtr = fixed (fencesHandles)
                let fencesLen = unativeint this.Fences.Length
                use signaledValuesPtr = fixed (this.SignaledValues)
                let signaledValuesLen = unativeint this.SignaledValues.Length
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryBeginAccessDescriptor(
                        nextInChain,
                        (if this.ConcurrentRead then 1 else 0),
                        (if this.Initialized then 1 else 0),
                        signaledValuesLen,
                        fencesPtr,
                        signaledValuesPtr
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryBeginAccessDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryBeginAccessDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryBeginAccessDescriptorExtension> device backend.NextInChain
            ConcurrentRead = (backend.ConcurrentRead <> 0)
            Initialized = (backend.Initialized <> 0)
            Fences = let ptr = backend.Fences in Array.init (int backend.FenceCount) (fun i -> new SharedFence(NativePtr.get ptr i))
            SignaledValues = let ptr = backend.SignaledValues in Array.init (int backend.FenceCount) (fun i -> NativePtr.get ptr i)
        }
type SharedTextureMemoryEndAccessState = 
    {
        Next : ISharedTextureMemoryEndAccessStateExtension
        Initialized : bool
        Fences : array<SharedFence>
        SignaledValues : array<uint64>
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryEndAccessState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryEndAccessState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let fencesHandles = this.Fences |> Array.map (fun a -> a.Handle)
                use fencesPtr = fixed (fencesHandles)
                let fencesLen = unativeint this.Fences.Length
                use signaledValuesPtr = fixed (this.SignaledValues)
                let signaledValuesLen = unativeint this.SignaledValues.Length
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryEndAccessState(
                        nextInChain,
                        (if this.Initialized then 1 else 0),
                        signaledValuesLen,
                        fencesPtr,
                        signaledValuesPtr
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryEndAccessState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryEndAccessState>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryEndAccessStateExtension> device backend.NextInChain
            Initialized = (backend.Initialized <> 0)
            Fences = let ptr = backend.Fences in Array.init (int backend.FenceCount) (fun i -> new SharedFence(NativePtr.get ptr i))
            SignaledValues = let ptr = backend.SignaledValues in Array.init (int backend.FenceCount) (fun i -> NativePtr.get ptr i)
        }
type SharedTextureMemoryVkImageLayoutBeginState = 
    {
        Next : ISharedTextureMemoryBeginAccessDescriptorExtension
        OldLayout : int
        NewLayout : int
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryVkImageLayoutBeginState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryVkImageLayoutBeginState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryVkImageLayoutBeginState
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryVkImageLayoutBeginState(
                        nextInChain,
                        sType,
                        this.OldLayout,
                        this.NewLayout
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryBeginAccessDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryVkImageLayoutBeginState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryVkImageLayoutBeginState>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryBeginAccessDescriptorExtension> device backend.NextInChain
            OldLayout = backend.OldLayout
            NewLayout = backend.NewLayout
        }
type SharedTextureMemoryVkImageLayoutEndState = 
    {
        Next : ISharedTextureMemoryEndAccessStateExtension
        OldLayout : int
        NewLayout : int
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryVkImageLayoutEndState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryVkImageLayoutEndState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryVkImageLayoutEndState
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryVkImageLayoutEndState(
                        nextInChain,
                        sType,
                        this.OldLayout,
                        this.NewLayout
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryEndAccessStateExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryVkImageLayoutEndState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryVkImageLayoutEndState>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryEndAccessStateExtension> device backend.NextInChain
            OldLayout = backend.OldLayout
            NewLayout = backend.NewLayout
        }
type SharedTextureMemoryD3DSwapchainBeginState = 
    {
        Next : ISharedTextureMemoryBeginAccessDescriptorExtension
        IsSwapchain : bool
    }
    static member Null = Unchecked.defaultof<SharedTextureMemoryD3DSwapchainBeginState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedTextureMemoryD3DSwapchainBeginState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedTextureMemoryD3DSwapchainBeginState
                let mutable value =
                    new WebGPU.Raw.SharedTextureMemoryD3DSwapchainBeginState(
                        nextInChain,
                        sType,
                        (if this.IsSwapchain then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedTextureMemoryBeginAccessDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedTextureMemoryD3DSwapchainBeginState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedTextureMemoryD3DSwapchainBeginState>) = 
        {
            Next = ExtensionDecoder.decode<ISharedTextureMemoryBeginAccessDescriptorExtension> device backend.NextInChain
            IsSwapchain = (backend.IsSwapchain <> 0)
        }
type SharedFence internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new SharedFence(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"SharedFence(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? SharedFence as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.ExportInfo(info : byref<SharedFenceExportInfo>) : unit =
        let mutable infoCopy = info
        try
            info.Pin(device, fun _infoPtr ->
                if NativePtr.toNativeInt _infoPtr = 0n then
                    let mutable infoNative = Unchecked.defaultof<WebGPU.Raw.SharedFenceExportInfo>
                    use _infoPtr = fixed &infoNative
                    let res = WebGPU.Raw.WebGPU.SharedFenceExportInfo(handle, _infoPtr)
                    let _ret = res
                    infoCopy <- SharedFenceExportInfo.Read(device, &infoNative)
                    _ret
                else
                    let res = WebGPU.Raw.WebGPU.SharedFenceExportInfo(handle, _infoPtr)
                    let _ret = res
                    let infoResult = NativePtr.toByRef _infoPtr
                    infoCopy <- SharedFenceExportInfo.Read(device, &infoResult)
                    _ret
            )
        finally
            info <- infoCopy
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.SharedFenceRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.SharedFenceAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type SharedFenceDescriptor = 
    {
        Next : ISharedFenceDescriptorExtension
        Label : string
    }
    static member Null = Unchecked.defaultof<SharedFenceDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                let mutable value =
                    new WebGPU.Raw.SharedFenceDescriptor(
                        nextInChain,
                        _labelLen
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
        }
type SharedFenceVkSemaphoreOpaqueFDDescriptor = 
    {
        Next : ISharedFenceDescriptorExtension
        Handle : int
    }
    static member Null = Unchecked.defaultof<SharedFenceVkSemaphoreOpaqueFDDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceVkSemaphoreOpaqueFDDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDDescriptor(
                        nextInChain,
                        sType,
                        this.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceDescriptorExtension> device backend.NextInChain
            Handle = backend.Handle
        }
type SharedFenceSyncFDDescriptor = 
    {
        Next : ISharedFenceDescriptorExtension
        Handle : int
    }
    static member Null = Unchecked.defaultof<SharedFenceSyncFDDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceSyncFDDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceSyncFDDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedFenceSyncFDDescriptor(
                        nextInChain,
                        sType,
                        this.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceSyncFDDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceSyncFDDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceDescriptorExtension> device backend.NextInChain
            Handle = backend.Handle
        }
type SharedFenceVkSemaphoreZirconHandleDescriptor = 
    {
        Next : ISharedFenceDescriptorExtension
        Handle : int
    }
    static member Null = Unchecked.defaultof<SharedFenceVkSemaphoreZirconHandleDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceVkSemaphoreZirconHandleDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleDescriptor(
                        nextInChain,
                        sType,
                        uint32(this.Handle)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceDescriptorExtension> device backend.NextInChain
            Handle = int(backend.Handle)
        }
type SharedFenceDXGISharedHandleDescriptor = 
    {
        Next : ISharedFenceDescriptorExtension
        Handle : nativeint
    }
    static member Null = Unchecked.defaultof<SharedFenceDXGISharedHandleDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceDXGISharedHandleDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceDXGISharedHandleDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedFenceDXGISharedHandleDescriptor(
                        nextInChain,
                        sType,
                        this.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceDXGISharedHandleDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceDXGISharedHandleDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceDescriptorExtension> device backend.NextInChain
            Handle = backend.Handle
        }
type SharedFenceMTLSharedEventDescriptor = 
    {
        Next : ISharedFenceDescriptorExtension
        SharedEvent : nativeint
    }
    static member Null = Unchecked.defaultof<SharedFenceMTLSharedEventDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceMTLSharedEventDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceMTLSharedEventDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedFenceMTLSharedEventDescriptor(
                        nextInChain,
                        sType,
                        this.SharedEvent
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceMTLSharedEventDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceMTLSharedEventDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceDescriptorExtension> device backend.NextInChain
            SharedEvent = backend.SharedEvent
        }
type SharedFenceEGLSyncDescriptor = 
    {
        Next : ISharedFenceDescriptorExtension
        Sync : nativeint
    }
    static member Null = Unchecked.defaultof<SharedFenceEGLSyncDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceEGLSyncDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceEGLSyncDescriptor
                let mutable value =
                    new WebGPU.Raw.SharedFenceEGLSyncDescriptor(
                        nextInChain,
                        sType,
                        this.Sync
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceEGLSyncDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceEGLSyncDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceDescriptorExtension> device backend.NextInChain
            Sync = backend.Sync
        }
type DawnFakeBufferOOMForTesting = 
    {
        Next : IBufferDescriptorExtension
        FakeOOMAtWireClientMap : bool
        FakeOOMAtNativeMap : bool
        FakeOOMAtDevice : bool
    }
    static member Null = Unchecked.defaultof<DawnFakeBufferOOMForTesting>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnFakeBufferOOMForTesting> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnFakeBufferOOMForTesting
                let mutable value =
                    new WebGPU.Raw.DawnFakeBufferOOMForTesting(
                        nextInChain,
                        sType,
                        (if this.FakeOOMAtWireClientMap then 1 else 0),
                        (if this.FakeOOMAtNativeMap then 1 else 0),
                        (if this.FakeOOMAtDevice then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IBufferDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnFakeBufferOOMForTesting> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnFakeBufferOOMForTesting>) = 
        {
            Next = ExtensionDecoder.decode<IBufferDescriptorExtension> device backend.NextInChain
            FakeOOMAtWireClientMap = (backend.FakeOOMAtWireClientMap <> 0)
            FakeOOMAtNativeMap = (backend.FakeOOMAtNativeMap <> 0)
            FakeOOMAtDevice = (backend.FakeOOMAtDevice <> 0)
        }
type SharedFenceExportInfo = 
    {
        Next : ISharedFenceExportInfoExtension
        Type : SharedFenceType
    }
    static member Null = Unchecked.defaultof<SharedFenceExportInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceExportInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let mutable value =
                    new WebGPU.Raw.SharedFenceExportInfo(
                        nextInChain,
                        this.Type
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceExportInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceExportInfo>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceExportInfoExtension> device backend.NextInChain
            Type = backend.Type
        }
type SharedFenceVkSemaphoreOpaqueFDExportInfo = 
    {
        Next : ISharedFenceExportInfoExtension
        Handle : int
    }
    static member Null = Unchecked.defaultof<SharedFenceVkSemaphoreOpaqueFDExportInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDExportInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceVkSemaphoreOpaqueFDExportInfo
                let mutable value =
                    new WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDExportInfo(
                        nextInChain,
                        sType,
                        this.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceExportInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDExportInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceVkSemaphoreOpaqueFDExportInfo>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceExportInfoExtension> device backend.NextInChain
            Handle = backend.Handle
        }
type SharedFenceSyncFDExportInfo = 
    {
        Next : ISharedFenceExportInfoExtension
        Handle : int
    }
    static member Null = Unchecked.defaultof<SharedFenceSyncFDExportInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceSyncFDExportInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceSyncFDExportInfo
                let mutable value =
                    new WebGPU.Raw.SharedFenceSyncFDExportInfo(
                        nextInChain,
                        sType,
                        this.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceExportInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceSyncFDExportInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceSyncFDExportInfo>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceExportInfoExtension> device backend.NextInChain
            Handle = backend.Handle
        }
type SharedFenceVkSemaphoreZirconHandleExportInfo = 
    {
        Next : ISharedFenceExportInfoExtension
        Handle : int
    }
    static member Null = Unchecked.defaultof<SharedFenceVkSemaphoreZirconHandleExportInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleExportInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceVkSemaphoreZirconHandleExportInfo
                let mutable value =
                    new WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleExportInfo(
                        nextInChain,
                        sType,
                        uint32(this.Handle)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceExportInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleExportInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceVkSemaphoreZirconHandleExportInfo>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceExportInfoExtension> device backend.NextInChain
            Handle = int(backend.Handle)
        }
type SharedFenceDXGISharedHandleExportInfo = 
    {
        Next : ISharedFenceExportInfoExtension
        Handle : nativeint
    }
    static member Null = Unchecked.defaultof<SharedFenceDXGISharedHandleExportInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceDXGISharedHandleExportInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceDXGISharedHandleExportInfo
                let mutable value =
                    new WebGPU.Raw.SharedFenceDXGISharedHandleExportInfo(
                        nextInChain,
                        sType,
                        this.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceExportInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceDXGISharedHandleExportInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceDXGISharedHandleExportInfo>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceExportInfoExtension> device backend.NextInChain
            Handle = backend.Handle
        }
type SharedFenceMTLSharedEventExportInfo = 
    {
        Next : ISharedFenceExportInfoExtension
        SharedEvent : nativeint
    }
    static member Null = Unchecked.defaultof<SharedFenceMTLSharedEventExportInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceMTLSharedEventExportInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceMTLSharedEventExportInfo
                let mutable value =
                    new WebGPU.Raw.SharedFenceMTLSharedEventExportInfo(
                        nextInChain,
                        sType,
                        this.SharedEvent
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceExportInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceMTLSharedEventExportInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceMTLSharedEventExportInfo>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceExportInfoExtension> device backend.NextInChain
            SharedEvent = backend.SharedEvent
        }
type SharedFenceEGLSyncExportInfo = 
    {
        Next : ISharedFenceExportInfoExtension
        Sync : nativeint
    }
    static member Null = Unchecked.defaultof<SharedFenceEGLSyncExportInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SharedFenceEGLSyncExportInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SharedFenceEGLSyncExportInfo
                let mutable value =
                    new WebGPU.Raw.SharedFenceEGLSyncExportInfo(
                        nextInChain,
                        sType,
                        this.Sync
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISharedFenceExportInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SharedFenceEGLSyncExportInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SharedFenceEGLSyncExportInfo>) = 
        {
            Next = ExtensionDecoder.decode<ISharedFenceExportInfoExtension> device backend.NextInChain
            Sync = backend.Sync
        }
type DawnFormatCapabilities = 
    {
        Next : IDawnFormatCapabilitiesExtension
    }
    static member Null = Unchecked.defaultof<DawnFormatCapabilities>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnFormatCapabilities> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let mutable value =
                    new WebGPU.Raw.DawnFormatCapabilities(
                        nextInChain
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnFormatCapabilities> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnFormatCapabilities>) = 
        {
            Next = ExtensionDecoder.decode<IDawnFormatCapabilitiesExtension> device backend.NextInChain
        }
type DawnDrmFormatCapabilities = 
    {
        Next : IDawnFormatCapabilitiesExtension
        Properties : array<DawnDrmFormatProperties>
    }
    static member Null = Unchecked.defaultof<DawnDrmFormatCapabilities>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnDrmFormatCapabilities> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnDrmFormatCapabilities
                WebGPU.Raw.Pinnable.pinArray device this.Properties (fun propertiesPtr ->
                    let propertiesLen = unativeint this.Properties.Length
                    let mutable value =
                        new WebGPU.Raw.DawnDrmFormatCapabilities(
                            nextInChain,
                            sType,
                            propertiesLen,
                            propertiesPtr
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IDawnFormatCapabilitiesExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnDrmFormatCapabilities> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnDrmFormatCapabilities>) = 
        {
            Next = ExtensionDecoder.decode<IDawnFormatCapabilitiesExtension> device backend.NextInChain
            Properties = let ptr = backend.Properties in Array.init (int backend.PropertiesCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in DawnDrmFormatProperties.Read(device, &r))
        }
type DawnDrmFormatProperties = 
    {
        Modifier : int64
        ModifierPlaneCount : int
    }
    static member Null = Unchecked.defaultof<DawnDrmFormatProperties>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnDrmFormatProperties> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.DawnDrmFormatProperties(
                    uint64(this.Modifier),
                    uint32(this.ModifierPlaneCount)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnDrmFormatProperties> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnDrmFormatProperties>) = 
        {
            Modifier = int64(backend.Modifier)
            ModifierPlaneCount = int(backend.ModifierPlaneCount)
        }
type TexelCopyBufferInfo = 
    {
        Layout : TexelCopyBufferLayout
        Buffer : Buffer
    }
    static member Null = Unchecked.defaultof<TexelCopyBufferInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.TexelCopyBufferInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            this.Layout.Pin(device, fun _layoutPtr ->
                let mutable value =
                    new WebGPU.Raw.TexelCopyBufferInfo(
                        (if NativePtr.toNativeInt _layoutPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _layoutPtr),
                        this.Buffer.Handle
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.TexelCopyBufferInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.TexelCopyBufferInfo>) = 
        {
            Layout = TexelCopyBufferLayout.Read(device, &backend.Layout)
            Buffer = new Buffer(device, backend.Buffer)
        }
type TexelCopyBufferLayout = 
    {
        Offset : int64
        BytesPerRow : int
        RowsPerImage : int
    }
    static member Null = Unchecked.defaultof<TexelCopyBufferLayout>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.TexelCopyBufferLayout> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.TexelCopyBufferLayout(
                    uint64(this.Offset),
                    uint32(this.BytesPerRow),
                    uint32(this.RowsPerImage)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.TexelCopyBufferLayout> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.TexelCopyBufferLayout>) = 
        {
            Offset = int64(backend.Offset)
            BytesPerRow = int(backend.BytesPerRow)
            RowsPerImage = int(backend.RowsPerImage)
        }
type TexelCopyTextureInfo = 
    {
        Texture : Texture
        MipLevel : int
        Origin : Origin3D
        Aspect : TextureAspect
    }
    static member Null = Unchecked.defaultof<TexelCopyTextureInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.TexelCopyTextureInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            this.Origin.Pin(device, fun _originPtr ->
                let mutable value =
                    new WebGPU.Raw.TexelCopyTextureInfo(
                        this.Texture.Handle,
                        uint32(this.MipLevel),
                        (if NativePtr.toNativeInt _originPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _originPtr),
                        this.Aspect
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.TexelCopyTextureInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.TexelCopyTextureInfo>) = 
        {
            Texture = new Texture(device, backend.Texture)
            MipLevel = int(backend.MipLevel)
            Origin = Origin3D.Read(device, &backend.Origin)
            Aspect = backend.Aspect
        }
type ImageCopyExternalTexture = 
    {
        ExternalTexture : ExternalTexture
        Origin : Origin3D
        NaturalSize : Extent2D
    }
    static member Null = Unchecked.defaultof<ImageCopyExternalTexture>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ImageCopyExternalTexture> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            this.Origin.Pin(device, fun _originPtr ->
                this.NaturalSize.Pin(device, fun _naturalSizePtr ->
                    let mutable value =
                        new WebGPU.Raw.ImageCopyExternalTexture(
                            nextInChain,
                            this.ExternalTexture.Handle,
                            (if NativePtr.toNativeInt _originPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _originPtr),
                            (if NativePtr.toNativeInt _naturalSizePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _naturalSizePtr)
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ImageCopyExternalTexture> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ImageCopyExternalTexture>) = 
        {
            ExternalTexture = new ExternalTexture(device, backend.ExternalTexture)
            Origin = Origin3D.Read(device, &backend.Origin)
            NaturalSize = Extent2D.Read(device, &backend.NaturalSize)
        }
type Instance internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new Instance(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"Instance(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? Instance as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.CreateSurface(descriptor : SurfaceDescriptor) : Surface =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.InstanceCreateSurface(handle, _descriptorPtr)
            new Surface(res)
        )
    member this.ProcessEvents() : unit =
        let res = WebGPU.Raw.WebGPU.InstanceProcessEvents(handle)
        res
    member this.WaitAny(futures : array<FutureWaitInfo>, timeoutNS : int64) : WaitStatus =
        WebGPU.Raw.Pinnable.pinArray device futures (fun futuresPtr ->
            let futuresLen = unativeint futures.Length
            let res = WebGPU.Raw.WebGPU.InstanceWaitAny(handle, futuresLen, futuresPtr, uint64(timeoutNS))
            res
        )
    member this.RequestAdapter(options : RequestAdapterOptions, callbackInfo : RequestAdapterCallbackInfo) : Future =
        options.Pin(device, fun _optionsPtr ->
            callbackInfo.Pin(device, fun _callbackInfoPtr ->
                let res = WebGPU.Raw.WebGPU.InstanceRequestAdapter(handle, _optionsPtr, (if NativePtr.toNativeInt _callbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _callbackInfoPtr))
                Future.Read(device, &res)
            )
        )
    member this.HasWGSLLanguageFeature(feature : WGSLLanguageFeatureName) : bool =
        let res = WebGPU.Raw.WebGPU.InstanceHasWGSLLanguageFeature(handle, feature)
        (res <> 0)
    member this.WGSLLanguageFeatures : SupportedWGSLLanguageFeatures =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        let status = WebGPU.Raw.WebGPU.InstanceGetWGSLLanguageFeatures(handle, ptr)
        if status <> Status.Success then failwith "GetWGSLLanguageFeatures failed"
        SupportedWGSLLanguageFeatures.Read(device, &res)
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.InstanceRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.InstanceAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type Future = 
    {
        Id : int64
    }
    static member Null = Unchecked.defaultof<Future>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.Future> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.Future(
                    uint64(this.Id)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.Future> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.Future>) = 
        {
            Id = int64(backend.Id)
        }
type FutureWaitInfo = 
    {
        Future : Future
        Completed : bool
    }
    static member Null = Unchecked.defaultof<FutureWaitInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.FutureWaitInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            this.Future.Pin(device, fun _futurePtr ->
                let mutable value =
                    new WebGPU.Raw.FutureWaitInfo(
                        (if NativePtr.toNativeInt _futurePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _futurePtr),
                        (if this.Completed then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.FutureWaitInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.FutureWaitInfo>) = 
        {
            Future = Future.Read(device, &backend.Future)
            Completed = (backend.Completed <> 0)
        }
type InstanceCapabilities = 
    {
        TimedWaitAnyEnable : bool
        TimedWaitAnyMaxCount : int64
    }
    static member Null = Unchecked.defaultof<InstanceCapabilities>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.InstanceCapabilities> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.InstanceCapabilities(
                    nextInChain,
                    (if this.TimedWaitAnyEnable then 1 else 0),
                    unativeint(this.TimedWaitAnyMaxCount)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.InstanceCapabilities> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.InstanceCapabilities>) = 
        {
            TimedWaitAnyEnable = (backend.TimedWaitAnyEnable <> 0)
            TimedWaitAnyMaxCount = int64(backend.TimedWaitAnyMaxCount)
        }
type InstanceDescriptor = 
    {
        Next : IInstanceDescriptorExtension
        Capabilities : InstanceCapabilities
    }
    static member Null = Unchecked.defaultof<InstanceDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.InstanceDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                this.Capabilities.Pin(device, fun _capabilitiesPtr ->
                    let mutable value =
                        new WebGPU.Raw.InstanceDescriptor(
                            nextInChain,
                            (if NativePtr.toNativeInt _capabilitiesPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _capabilitiesPtr)
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.InstanceDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.InstanceDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<IInstanceDescriptorExtension> device backend.NextInChain
            Capabilities = InstanceCapabilities.Read(device, &backend.Capabilities)
        }
type DawnWireWGSLControl = 
    {
        Next : IInstanceDescriptorExtension
        EnableExperimental : bool
        EnableUnsafe : bool
        EnableTesting : bool
    }
    static member Null = Unchecked.defaultof<DawnWireWGSLControl>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnWireWGSLControl> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnWireWGSLControl
                let mutable value =
                    new WebGPU.Raw.DawnWireWGSLControl(
                        nextInChain,
                        sType,
                        (if this.EnableExperimental then 1 else 0),
                        (if this.EnableUnsafe then 1 else 0),
                        (if this.EnableTesting then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IInstanceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnWireWGSLControl> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnWireWGSLControl>) = 
        {
            Next = ExtensionDecoder.decode<IInstanceDescriptorExtension> device backend.NextInChain
            EnableExperimental = (backend.EnableExperimental <> 0)
            EnableUnsafe = (backend.EnableUnsafe <> 0)
            EnableTesting = (backend.EnableTesting <> 0)
        }
type DawnInjectedInvalidSType = 
    {
        InvalidSType : SType
    }
    static member Null = Unchecked.defaultof<DawnInjectedInvalidSType>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnInjectedInvalidSType> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let sType = SType.DawnInjectedInvalidSType
            let mutable value =
                new WebGPU.Raw.DawnInjectedInvalidSType(
                    nextInChain,
                    sType,
                    this.InvalidSType
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnInjectedInvalidSType> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnInjectedInvalidSType>) = 
        {
            InvalidSType = backend.InvalidSType
        }
type VertexAttribute = 
    {
        Format : VertexFormat
        Offset : int64
        ShaderLocation : int
    }
    static member Null = Unchecked.defaultof<VertexAttribute>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.VertexAttribute> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.VertexAttribute(
                    nextInChain,
                    this.Format,
                    uint64(this.Offset),
                    uint32(this.ShaderLocation)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.VertexAttribute> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.VertexAttribute>) = 
        {
            Format = backend.Format
            Offset = int64(backend.Offset)
            ShaderLocation = int(backend.ShaderLocation)
        }
type VertexBufferLayout = 
    {
        StepMode : VertexStepMode
        ArrayStride : int64
        Attributes : array<VertexAttribute>
    }
    static member Null = Unchecked.defaultof<VertexBufferLayout>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.VertexBufferLayout> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            WebGPU.Raw.Pinnable.pinArray device this.Attributes (fun attributesPtr ->
                let attributesLen = unativeint this.Attributes.Length
                let mutable value =
                    new WebGPU.Raw.VertexBufferLayout(
                        nextInChain,
                        this.StepMode,
                        uint64(this.ArrayStride),
                        attributesLen,
                        attributesPtr
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.VertexBufferLayout> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.VertexBufferLayout>) = 
        {
            StepMode = backend.StepMode
            ArrayStride = int64(backend.ArrayStride)
            Attributes = let ptr = backend.Attributes in Array.init (int backend.AttributeCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in VertexAttribute.Read(device, &r))
        }
type Origin3D = 
    {
        X : int
        Y : int
        Z : int
    }
    static member Null = Unchecked.defaultof<Origin3D>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.Origin3D> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.Origin3D(
                    uint32(this.X),
                    uint32(this.Y),
                    uint32(this.Z)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.Origin3D> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.Origin3D>) = 
        {
            X = int(backend.X)
            Y = int(backend.Y)
            Z = int(backend.Z)
        }
type Origin2D = 
    {
        X : int
        Y : int
    }
    static member Null = Unchecked.defaultof<Origin2D>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.Origin2D> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.Origin2D(
                    uint32(this.X),
                    uint32(this.Y)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.Origin2D> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.Origin2D>) = 
        {
            X = int(backend.X)
            Y = int(backend.Y)
        }
type PassTimestampWrites = 
    {
        QuerySet : QuerySet
        BeginningOfPassWriteIndex : int
        EndOfPassWriteIndex : int
    }
    static member Null = Unchecked.defaultof<PassTimestampWrites>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.PassTimestampWrites> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.PassTimestampWrites(
                    nextInChain,
                    this.QuerySet.Handle,
                    uint32(this.BeginningOfPassWriteIndex),
                    uint32(this.EndOfPassWriteIndex)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.PassTimestampWrites> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.PassTimestampWrites>) = 
        {
            QuerySet = new QuerySet(device, backend.QuerySet)
            BeginningOfPassWriteIndex = int(backend.BeginningOfPassWriteIndex)
            EndOfPassWriteIndex = int(backend.EndOfPassWriteIndex)
        }
type PipelineLayout internal(device : Device, handle : nativeint) =
    static let nullptr = new PipelineLayout(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"PipelineLayout(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? PipelineLayout as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.PipelineLayoutSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.PipelineLayoutRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.PipelineLayoutAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type PipelineLayoutDescriptor = 
    {
        Next : IPipelineLayoutDescriptorExtension
        Label : string
        BindGroupLayouts : array<BindGroupLayout>
        ImmediateSize : int
    }
    static member Null = Unchecked.defaultof<PipelineLayoutDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.PipelineLayoutDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                let bindGroupLayoutsHandles = this.BindGroupLayouts |> Array.map (fun a -> a.Handle)
                use bindGroupLayoutsPtr = fixed (bindGroupLayoutsHandles)
                let bindGroupLayoutsLen = unativeint this.BindGroupLayouts.Length
                let mutable value =
                    new WebGPU.Raw.PipelineLayoutDescriptor(
                        nextInChain,
                        _labelLen,
                        bindGroupLayoutsLen,
                        bindGroupLayoutsPtr,
                        uint32(this.ImmediateSize)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.PipelineLayoutDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.PipelineLayoutDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<IPipelineLayoutDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            BindGroupLayouts = let ptr = backend.BindGroupLayouts in Array.init (int backend.BindGroupLayoutCount) (fun i -> new BindGroupLayout(NativePtr.get ptr i))
            ImmediateSize = int(backend.ImmediateSize)
        }
type PipelineLayoutPixelLocalStorage = 
    {
        Next : IPipelineLayoutDescriptorExtension
        TotalPixelLocalStorageSize : int64
        StorageAttachments : array<PipelineLayoutStorageAttachment>
    }
    static member Null = Unchecked.defaultof<PipelineLayoutPixelLocalStorage>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.PipelineLayoutPixelLocalStorage> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.PipelineLayoutPixelLocalStorage
                WebGPU.Raw.Pinnable.pinArray device this.StorageAttachments (fun storageAttachmentsPtr ->
                    let storageAttachmentsLen = unativeint this.StorageAttachments.Length
                    let mutable value =
                        new WebGPU.Raw.PipelineLayoutPixelLocalStorage(
                            nextInChain,
                            sType,
                            uint64(this.TotalPixelLocalStorageSize),
                            storageAttachmentsLen,
                            storageAttachmentsPtr
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IPipelineLayoutDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.PipelineLayoutPixelLocalStorage> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.PipelineLayoutPixelLocalStorage>) = 
        {
            Next = ExtensionDecoder.decode<IPipelineLayoutDescriptorExtension> device backend.NextInChain
            TotalPixelLocalStorageSize = int64(backend.TotalPixelLocalStorageSize)
            StorageAttachments = let ptr = backend.StorageAttachments in Array.init (int backend.StorageAttachmentCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in PipelineLayoutStorageAttachment.Read(device, &r))
        }
type PipelineLayoutStorageAttachment = 
    {
        Offset : int64
        Format : TextureFormat
    }
    static member Null = Unchecked.defaultof<PipelineLayoutStorageAttachment>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.PipelineLayoutStorageAttachment> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.PipelineLayoutStorageAttachment(
                    nextInChain,
                    uint64(this.Offset),
                    this.Format
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.PipelineLayoutStorageAttachment> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.PipelineLayoutStorageAttachment>) = 
        {
            Offset = int64(backend.Offset)
            Format = backend.Format
        }
type ComputeState = 
    {
        Module : ShaderModule
        EntryPoint : string
        Constants : array<ConstantEntry>
    }
    static member Null = Unchecked.defaultof<ComputeState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ComputeState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _entryPointArr = if isNull this.EntryPoint then null else Encoding.UTF8.GetBytes(this.EntryPoint)
            use _entryPointPtr = fixed _entryPointArr
            let _entryPointLen = WebGPU.Raw.StringView(_entryPointPtr, if isNull _entryPointArr then 0un else unativeint _entryPointArr.Length)
            WebGPU.Raw.Pinnable.pinArray device this.Constants (fun constantsPtr ->
                let constantsLen = unativeint this.Constants.Length
                let mutable value =
                    new WebGPU.Raw.ComputeState(
                        nextInChain,
                        this.Module.Handle,
                        _entryPointLen,
                        constantsLen,
                        constantsPtr
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ComputeState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ComputeState>) = 
        {
            Module = new ShaderModule(device, backend.Module)
            EntryPoint = let _entryPointPtr = NativePtr.toNativeInt(backend.EntryPoint.Data) in if _entryPointPtr = 0n then null else Marshal.PtrToStringUTF8(_entryPointPtr, int(backend.EntryPoint.Length))
            Constants = let ptr = backend.Constants in Array.init (int backend.ConstantCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in ConstantEntry.Read(device, &r))
        }
type QuerySet internal(device : Device, handle : nativeint) =
    static let nullptr = new QuerySet(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    let typ =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.QuerySetGetType(handle)
            res
        )
    let count =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.QuerySetGetCount(handle)
            int(res)
        )
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"QuerySet(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? QuerySet as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.QuerySetSetLabel(handle, _labelLen)
        res
    member this.Type : QueryType =
        typ.Value
    member this.Count : int =
        count.Value
    member this.Destroy() : unit =
        let res = WebGPU.Raw.WebGPU.QuerySetDestroy(handle)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.QuerySetRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.QuerySetAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type QuerySetDescriptor = 
    {
        Label : string
        Type : QueryType
        Count : int
    }
    static member Null = Unchecked.defaultof<QuerySetDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.QuerySetDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            let mutable value =
                new WebGPU.Raw.QuerySetDescriptor(
                    nextInChain,
                    _labelLen,
                    this.Type,
                    uint32(this.Count)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.QuerySetDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.QuerySetDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            Type = backend.Type
            Count = int(backend.Count)
        }
type Queue internal(device : Device, handle : nativeint) =
    static let nullptr = new Queue(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"Queue(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? Queue as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.Submit(commands : array<CommandBuffer>) : System.Threading.Tasks.Task =
        let commandsHandles = commands |> Array.map (fun a -> a.Handle)
        use commandsPtr = fixed (commandsHandles)
        let commandsLen = unativeint commands.Length
        let res = WebGPU.Raw.WebGPU.QueueSubmit(handle, commandsLen, commandsPtr)
        res
        let tcs = System.Threading.Tasks.TaskCompletionSource<unit>()
        this.OnSubmittedWorkDone { Mode = CallbackMode.AllowProcessEvents; Callback = QueueWorkDoneCallback(fun d _ _ -> d.Dispose(); tcs.SetResult()) } |> ignore
        task {
            do! tcs.Task
            for c in commands do do! c.RunCompleted()
        } :> System.Threading.Tasks.Task
    member this.OnSubmittedWorkDone(callbackInfo : QueueWorkDoneCallbackInfo) : Future =
        callbackInfo.Pin(device, fun _callbackInfoPtr ->
            let res = WebGPU.Raw.WebGPU.QueueOnSubmittedWorkDone(handle, (if NativePtr.toNativeInt _callbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _callbackInfoPtr))
            Future.Read(device, &res)
        )
    member this.WriteBuffer(buffer : Buffer, bufferOffset : int64, data : nativeint, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.QueueWriteBuffer(handle, buffer.Handle, uint64(bufferOffset), data, unativeint(size))
        res
    member this.WriteTexture(destination : TexelCopyTextureInfo, data : nativeint, dataSize : int64, dataLayout : TexelCopyBufferLayout, writeSize : Extent3D) : unit =
        destination.Pin(device, fun _destinationPtr ->
            dataLayout.Pin(device, fun _dataLayoutPtr ->
                writeSize.Pin(device, fun _writeSizePtr ->
                    let res = WebGPU.Raw.WebGPU.QueueWriteTexture(handle, _destinationPtr, data, unativeint(dataSize), _dataLayoutPtr, _writeSizePtr)
                    res
                )
            )
        )
    member this.CopyTextureForBrowser(source : TexelCopyTextureInfo, destination : TexelCopyTextureInfo, copySize : Extent3D, options : CopyTextureForBrowserOptions) : unit =
        source.Pin(device, fun _sourcePtr ->
            destination.Pin(device, fun _destinationPtr ->
                copySize.Pin(device, fun _copySizePtr ->
                    options.Pin(device, fun _optionsPtr ->
                        let res = WebGPU.Raw.WebGPU.QueueCopyTextureForBrowser(handle, _sourcePtr, _destinationPtr, _copySizePtr, _optionsPtr)
                        res
                    )
                )
            )
        )
    member this.CopyExternalTextureForBrowser(source : ImageCopyExternalTexture, destination : TexelCopyTextureInfo, copySize : Extent3D, options : CopyTextureForBrowserOptions) : unit =
        source.Pin(device, fun _sourcePtr ->
            destination.Pin(device, fun _destinationPtr ->
                copySize.Pin(device, fun _copySizePtr ->
                    options.Pin(device, fun _optionsPtr ->
                        let res = WebGPU.Raw.WebGPU.QueueCopyExternalTextureForBrowser(handle, _sourcePtr, _destinationPtr, _copySizePtr, _optionsPtr)
                        res
                    )
                )
            )
        )
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.QueueSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.QueueRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.QueueAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type QueueDescriptor = 
    {
        Label : string
    }
    static member Null = Unchecked.defaultof<QueueDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.QueueDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            let mutable value =
                new WebGPU.Raw.QueueDescriptor(
                    nextInChain,
                    _labelLen
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.QueueDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.QueueDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
        }
type QueueWorkDoneCallback = delegate of IDisposable * status : QueueWorkDoneStatus * message : string -> unit
type QueueWorkDoneCallbackInfo = 
    {
        Mode : CallbackMode
        Callback : QueueWorkDoneCallback
    }
    static member Null = Unchecked.defaultof<QueueWorkDoneCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.QueueWorkDoneCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.QueueWorkDoneCallback>
                _callbackDel <- WebGPU.Raw.QueueWorkDoneCallback(fun status message userdata1 userdata2 ->
                    let _status = status
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _status, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.QueueWorkDoneCallbackInfo(
                    nextInChain,
                    this.Mode,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.QueueWorkDoneCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.QueueWorkDoneCallbackInfo>) = 
        {
            Mode = backend.Mode
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (mode, backend.Mode); (next in chain, backend.NextInChain); ... ]
        }
type RenderBundle internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new RenderBundle(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"RenderBundle(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? RenderBundle as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.RenderBundleSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type RenderBundleEncoder internal(device : Device, handle : nativeint) =
    static let nullptr = new RenderBundleEncoder(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"RenderBundleEncoder(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? RenderBundleEncoder as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetPipeline(pipeline : RenderPipeline) : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderSetPipeline(handle, pipeline.Handle)
        res
    member this.SetBindGroup(groupIndex : int, group : BindGroup, dynamicOffsets : array<uint32>) : unit =
        use dynamicOffsetsPtr = fixed (dynamicOffsets)
        let dynamicOffsetsLen = unativeint dynamicOffsets.Length
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderSetBindGroup(handle, uint32(groupIndex), group.Handle, dynamicOffsetsLen, dynamicOffsetsPtr)
        res
    member this.Draw(vertexCount : int, instanceCount : int, firstVertex : int, firstInstance : int) : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderDraw(handle, uint32(vertexCount), uint32(instanceCount), uint32(firstVertex), uint32(firstInstance))
        res
    member this.DrawIndexed(indexCount : int, instanceCount : int, firstIndex : int, baseVertex : int, firstInstance : int) : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderDrawIndexed(handle, uint32(indexCount), uint32(instanceCount), uint32(firstIndex), baseVertex, uint32(firstInstance))
        res
    member this.DrawIndirect(indirectBuffer : Buffer, indirectOffset : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderDrawIndirect(handle, indirectBuffer.Handle, uint64(indirectOffset))
        res
    member this.DrawIndexedIndirect(indirectBuffer : Buffer, indirectOffset : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderDrawIndexedIndirect(handle, indirectBuffer.Handle, uint64(indirectOffset))
        res
    member this.InsertDebugMarker(markerLabel : string) : unit =
        let _markerLabelArr = if isNull markerLabel then null else Encoding.UTF8.GetBytes(markerLabel)
        use _markerLabelPtr = fixed _markerLabelArr
        let _markerLabelLen = WebGPU.Raw.StringView(_markerLabelPtr, if isNull _markerLabelArr then 0un else unativeint _markerLabelArr.Length)
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderInsertDebugMarker(handle, _markerLabelLen)
        res
    member this.PopDebugGroup() : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderPopDebugGroup(handle)
        res
    member this.PushDebugGroup(groupLabel : string) : unit =
        let _groupLabelArr = if isNull groupLabel then null else Encoding.UTF8.GetBytes(groupLabel)
        use _groupLabelPtr = fixed _groupLabelArr
        let _groupLabelLen = WebGPU.Raw.StringView(_groupLabelPtr, if isNull _groupLabelArr then 0un else unativeint _groupLabelArr.Length)
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderPushDebugGroup(handle, _groupLabelLen)
        res
    member this.SetVertexBuffer(slot : int, buffer : Buffer, offset : int64, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderSetVertexBuffer(handle, uint32(slot), buffer.Handle, uint64(offset), uint64(size))
        res
    member this.SetIndexBuffer(buffer : Buffer, format : IndexFormat, offset : int64, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderSetIndexBuffer(handle, buffer.Handle, format, uint64(offset), uint64(size))
        res
    member this.Finish(descriptor : RenderBundleDescriptor) : RenderBundle =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.RenderBundleEncoderFinish(handle, _descriptorPtr)
            new RenderBundle(res)
        )
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderSetLabel(handle, _labelLen)
        res
    member this.SetImmediateData(offset : int, data : nativeint, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderSetImmediateData(handle, uint32(offset), data, unativeint(size))
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.RenderBundleEncoderAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type RenderBundleDescriptor = 
    {
        Label : string
    }
    static member Null = Unchecked.defaultof<RenderBundleDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderBundleDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            let mutable value =
                new WebGPU.Raw.RenderBundleDescriptor(
                    nextInChain,
                    _labelLen
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderBundleDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderBundleDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
        }
type RenderBundleEncoderDescriptor = 
    {
        Label : string
        ColorFormats : array<TextureFormat>
        DepthStencilFormat : TextureFormat
        SampleCount : int
        DepthReadOnly : bool
        StencilReadOnly : bool
    }
    static member Null = Unchecked.defaultof<RenderBundleEncoderDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderBundleEncoderDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            use colorFormatsPtr = fixed (this.ColorFormats)
            let colorFormatsLen = unativeint this.ColorFormats.Length
            let mutable value =
                new WebGPU.Raw.RenderBundleEncoderDescriptor(
                    nextInChain,
                    _labelLen,
                    colorFormatsLen,
                    colorFormatsPtr,
                    this.DepthStencilFormat,
                    uint32(this.SampleCount),
                    (if this.DepthReadOnly then 1 else 0),
                    (if this.StencilReadOnly then 1 else 0)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderBundleEncoderDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderBundleEncoderDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            ColorFormats = let ptr = backend.ColorFormats in Array.init (int backend.ColorFormatCount) (fun i -> NativePtr.get ptr i)
            DepthStencilFormat = backend.DepthStencilFormat
            SampleCount = int(backend.SampleCount)
            DepthReadOnly = (backend.DepthReadOnly <> 0)
            StencilReadOnly = (backend.StencilReadOnly <> 0)
        }
type RenderPassColorAttachment = 
    {
        Next : IRenderPassColorAttachmentExtension
        View : TextureView
        DepthSlice : int
        ResolveTarget : TextureView
        LoadOp : LoadOp
        StoreOp : StoreOp
        ClearValue : Color
    }
    static member Null = Unchecked.defaultof<RenderPassColorAttachment>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderPassColorAttachment> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                this.ClearValue.Pin(device, fun _clearValuePtr ->
                    let mutable value =
                        new WebGPU.Raw.RenderPassColorAttachment(
                            nextInChain,
                            this.View.Handle,
                            uint32(this.DepthSlice),
                            this.ResolveTarget.Handle,
                            this.LoadOp,
                            this.StoreOp,
                            (if NativePtr.toNativeInt _clearValuePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _clearValuePtr)
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderPassColorAttachment> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderPassColorAttachment>) = 
        {
            Next = ExtensionDecoder.decode<IRenderPassColorAttachmentExtension> device backend.NextInChain
            View = new TextureView(backend.View)
            DepthSlice = int(backend.DepthSlice)
            ResolveTarget = new TextureView(backend.ResolveTarget)
            LoadOp = backend.LoadOp
            StoreOp = backend.StoreOp
            ClearValue = Color.Read(device, &backend.ClearValue)
        }
type DawnRenderPassColorAttachmentRenderToSingleSampled = 
    {
        Next : IRenderPassColorAttachmentExtension
        ImplicitSampleCount : int
    }
    static member Null = Unchecked.defaultof<DawnRenderPassColorAttachmentRenderToSingleSampled>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnRenderPassColorAttachmentRenderToSingleSampled> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnRenderPassColorAttachmentRenderToSingleSampled
                let mutable value =
                    new WebGPU.Raw.DawnRenderPassColorAttachmentRenderToSingleSampled(
                        nextInChain,
                        sType,
                        uint32(this.ImplicitSampleCount)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IRenderPassColorAttachmentExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnRenderPassColorAttachmentRenderToSingleSampled> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnRenderPassColorAttachmentRenderToSingleSampled>) = 
        {
            Next = ExtensionDecoder.decode<IRenderPassColorAttachmentExtension> device backend.NextInChain
            ImplicitSampleCount = int(backend.ImplicitSampleCount)
        }
type RenderPassDepthStencilAttachment = 
    {
        View : TextureView
        DepthLoadOp : LoadOp
        DepthStoreOp : StoreOp
        DepthClearValue : float32
        DepthReadOnly : bool
        StencilLoadOp : LoadOp
        StencilStoreOp : StoreOp
        StencilClearValue : int
        StencilReadOnly : bool
    }
    static member Null = Unchecked.defaultof<RenderPassDepthStencilAttachment>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderPassDepthStencilAttachment> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.RenderPassDepthStencilAttachment(
                    nextInChain,
                    this.View.Handle,
                    this.DepthLoadOp,
                    this.DepthStoreOp,
                    this.DepthClearValue,
                    (if this.DepthReadOnly then 1 else 0),
                    this.StencilLoadOp,
                    this.StencilStoreOp,
                    uint32(this.StencilClearValue),
                    (if this.StencilReadOnly then 1 else 0)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderPassDepthStencilAttachment> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderPassDepthStencilAttachment>) = 
        {
            View = new TextureView(backend.View)
            DepthLoadOp = backend.DepthLoadOp
            DepthStoreOp = backend.DepthStoreOp
            DepthClearValue = backend.DepthClearValue
            DepthReadOnly = (backend.DepthReadOnly <> 0)
            StencilLoadOp = backend.StencilLoadOp
            StencilStoreOp = backend.StencilStoreOp
            StencilClearValue = int(backend.StencilClearValue)
            StencilReadOnly = (backend.StencilReadOnly <> 0)
        }
type RenderPassDescriptor = 
    {
        Next : IRenderPassDescriptorExtension
        Label : string
        ColorAttachments : array<RenderPassColorAttachment>
        DepthStencilAttachment : RenderPassDepthStencilAttachment
        OcclusionQuerySet : QuerySet
        TimestampWrites : PassTimestampWrites
    }
    static member Null = Unchecked.defaultof<RenderPassDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderPassDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                WebGPU.Raw.Pinnable.pinArray device this.ColorAttachments (fun colorAttachmentsPtr ->
                    let colorAttachmentsLen = unativeint this.ColorAttachments.Length
                    this.DepthStencilAttachment.Pin(device, fun _depthStencilAttachmentPtr ->
                        this.TimestampWrites.Pin(device, fun _timestampWritesPtr ->
                            let mutable value =
                                new WebGPU.Raw.RenderPassDescriptor(
                                    nextInChain,
                                    _labelLen,
                                    colorAttachmentsLen,
                                    colorAttachmentsPtr,
                                    _depthStencilAttachmentPtr,
                                    this.OcclusionQuerySet.Handle,
                                    _timestampWritesPtr
                                )
                            use ptr = fixed &value
                            action ptr
                        )
                    )
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderPassDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderPassDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<IRenderPassDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            ColorAttachments = let ptr = backend.ColorAttachments in Array.init (int backend.ColorAttachmentCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in RenderPassColorAttachment.Read(device, &r))
            DepthStencilAttachment = let m = NativePtr.toByRef backend.DepthStencilAttachment in RenderPassDepthStencilAttachment.Read(device, &m)
            OcclusionQuerySet = new QuerySet(device, backend.OcclusionQuerySet)
            TimestampWrites = let m = NativePtr.toByRef backend.TimestampWrites in PassTimestampWrites.Read(device, &m)
        }
type RenderPassDescriptorMaxDrawCount = RenderPassMaxDrawCount
type RenderPassMaxDrawCount = 
    {
        Next : IRenderPassDescriptorExtension
        MaxDrawCount : int64
    }
    static member Null = Unchecked.defaultof<RenderPassMaxDrawCount>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderPassMaxDrawCount> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.RenderPassMaxDrawCount
                let mutable value =
                    new WebGPU.Raw.RenderPassMaxDrawCount(
                        nextInChain,
                        sType,
                        uint64(this.MaxDrawCount)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IRenderPassDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderPassMaxDrawCount> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderPassMaxDrawCount>) = 
        {
            Next = ExtensionDecoder.decode<IRenderPassDescriptorExtension> device backend.NextInChain
            MaxDrawCount = int64(backend.MaxDrawCount)
        }
type RenderPassDescriptorExpandResolveRect = 
    {
        Next : IRenderPassDescriptorExtension
        X : int
        Y : int
        Width : int
        Height : int
    }
    static member Null = Unchecked.defaultof<RenderPassDescriptorExpandResolveRect>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderPassDescriptorExpandResolveRect> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.RenderPassDescriptorExpandResolveRect
                let mutable value =
                    new WebGPU.Raw.RenderPassDescriptorExpandResolveRect(
                        nextInChain,
                        sType,
                        uint32(this.X),
                        uint32(this.Y),
                        uint32(this.Width),
                        uint32(this.Height)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IRenderPassDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderPassDescriptorExpandResolveRect> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderPassDescriptorExpandResolveRect>) = 
        {
            Next = ExtensionDecoder.decode<IRenderPassDescriptorExtension> device backend.NextInChain
            X = int(backend.X)
            Y = int(backend.Y)
            Width = int(backend.Width)
            Height = int(backend.Height)
        }
type RenderPassDescriptorResolveRect = 
    {
        Next : IRenderPassDescriptorExtension
        ColorOffsetX : int
        ColorOffsetY : int
        ResolveOffsetX : int
        ResolveOffsetY : int
        Width : int
        Height : int
    }
    static member Null = Unchecked.defaultof<RenderPassDescriptorResolveRect>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderPassDescriptorResolveRect> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.RenderPassDescriptorResolveRect
                let mutable value =
                    new WebGPU.Raw.RenderPassDescriptorResolveRect(
                        nextInChain,
                        sType,
                        uint32(this.ColorOffsetX),
                        uint32(this.ColorOffsetY),
                        uint32(this.ResolveOffsetX),
                        uint32(this.ResolveOffsetY),
                        uint32(this.Width),
                        uint32(this.Height)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IRenderPassDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderPassDescriptorResolveRect> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderPassDescriptorResolveRect>) = 
        {
            Next = ExtensionDecoder.decode<IRenderPassDescriptorExtension> device backend.NextInChain
            ColorOffsetX = int(backend.ColorOffsetX)
            ColorOffsetY = int(backend.ColorOffsetY)
            ResolveOffsetX = int(backend.ResolveOffsetX)
            ResolveOffsetY = int(backend.ResolveOffsetY)
            Width = int(backend.Width)
            Height = int(backend.Height)
        }
type RenderPassPixelLocalStorage = 
    {
        Next : IRenderPassDescriptorExtension
        TotalPixelLocalStorageSize : int64
        StorageAttachments : array<RenderPassStorageAttachment>
    }
    static member Null = Unchecked.defaultof<RenderPassPixelLocalStorage>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderPassPixelLocalStorage> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.RenderPassPixelLocalStorage
                WebGPU.Raw.Pinnable.pinArray device this.StorageAttachments (fun storageAttachmentsPtr ->
                    let storageAttachmentsLen = unativeint this.StorageAttachments.Length
                    let mutable value =
                        new WebGPU.Raw.RenderPassPixelLocalStorage(
                            nextInChain,
                            sType,
                            uint64(this.TotalPixelLocalStorageSize),
                            storageAttachmentsLen,
                            storageAttachmentsPtr
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IRenderPassDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderPassPixelLocalStorage> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderPassPixelLocalStorage>) = 
        {
            Next = ExtensionDecoder.decode<IRenderPassDescriptorExtension> device backend.NextInChain
            TotalPixelLocalStorageSize = int64(backend.TotalPixelLocalStorageSize)
            StorageAttachments = let ptr = backend.StorageAttachments in Array.init (int backend.StorageAttachmentCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in RenderPassStorageAttachment.Read(device, &r))
        }
type RenderPassStorageAttachment = 
    {
        Offset : int64
        Storage : TextureView
        LoadOp : LoadOp
        StoreOp : StoreOp
        ClearValue : Color
    }
    static member Null = Unchecked.defaultof<RenderPassStorageAttachment>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderPassStorageAttachment> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            this.ClearValue.Pin(device, fun _clearValuePtr ->
                let mutable value =
                    new WebGPU.Raw.RenderPassStorageAttachment(
                        nextInChain,
                        uint64(this.Offset),
                        this.Storage.Handle,
                        this.LoadOp,
                        this.StoreOp,
                        (if NativePtr.toNativeInt _clearValuePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _clearValuePtr)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderPassStorageAttachment> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderPassStorageAttachment>) = 
        {
            Offset = int64(backend.Offset)
            Storage = new TextureView(backend.Storage)
            LoadOp = backend.LoadOp
            StoreOp = backend.StoreOp
            ClearValue = Color.Read(device, &backend.ClearValue)
        }
type RenderPassEncoder internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new RenderPassEncoder(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"RenderPassEncoder(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? RenderPassEncoder as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetPipeline(pipeline : RenderPipeline) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetPipeline(handle, pipeline.Handle)
        res
    member this.SetBindGroup(groupIndex : int, group : BindGroup, dynamicOffsets : array<uint32>) : unit =
        use dynamicOffsetsPtr = fixed (dynamicOffsets)
        let dynamicOffsetsLen = unativeint dynamicOffsets.Length
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetBindGroup(handle, uint32(groupIndex), group.Handle, dynamicOffsetsLen, dynamicOffsetsPtr)
        res
    member this.Draw(vertexCount : int, instanceCount : int, firstVertex : int, firstInstance : int) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderDraw(handle, uint32(vertexCount), uint32(instanceCount), uint32(firstVertex), uint32(firstInstance))
        res
    member this.DrawIndexed(indexCount : int, instanceCount : int, firstIndex : int, baseVertex : int, firstInstance : int) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderDrawIndexed(handle, uint32(indexCount), uint32(instanceCount), uint32(firstIndex), baseVertex, uint32(firstInstance))
        res
    member this.DrawIndirect(indirectBuffer : Buffer, indirectOffset : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderDrawIndirect(handle, indirectBuffer.Handle, uint64(indirectOffset))
        res
    member this.DrawIndexedIndirect(indirectBuffer : Buffer, indirectOffset : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderDrawIndexedIndirect(handle, indirectBuffer.Handle, uint64(indirectOffset))
        res
    member this.MultiDrawIndirect(indirectBuffer : Buffer, indirectOffset : int64, maxDrawCount : int, drawCountBuffer : Buffer, drawCountBufferOffset : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderMultiDrawIndirect(handle, indirectBuffer.Handle, uint64(indirectOffset), uint32(maxDrawCount), drawCountBuffer.Handle, uint64(drawCountBufferOffset))
        res
    member this.MultiDrawIndexedIndirect(indirectBuffer : Buffer, indirectOffset : int64, maxDrawCount : int, drawCountBuffer : Buffer, drawCountBufferOffset : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderMultiDrawIndexedIndirect(handle, indirectBuffer.Handle, uint64(indirectOffset), uint32(maxDrawCount), drawCountBuffer.Handle, uint64(drawCountBufferOffset))
        res
    member this.ExecuteBundles(bundles : array<RenderBundle>) : unit =
        let bundlesHandles = bundles |> Array.map (fun a -> a.Handle)
        use bundlesPtr = fixed (bundlesHandles)
        let bundlesLen = unativeint bundles.Length
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderExecuteBundles(handle, bundlesLen, bundlesPtr)
        res
    member this.InsertDebugMarker(markerLabel : string) : unit =
        let _markerLabelArr = if isNull markerLabel then null else Encoding.UTF8.GetBytes(markerLabel)
        use _markerLabelPtr = fixed _markerLabelArr
        let _markerLabelLen = WebGPU.Raw.StringView(_markerLabelPtr, if isNull _markerLabelArr then 0un else unativeint _markerLabelArr.Length)
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderInsertDebugMarker(handle, _markerLabelLen)
        res
    member this.PopDebugGroup() : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderPopDebugGroup(handle)
        res
    member this.PushDebugGroup(groupLabel : string) : unit =
        let _groupLabelArr = if isNull groupLabel then null else Encoding.UTF8.GetBytes(groupLabel)
        use _groupLabelPtr = fixed _groupLabelArr
        let _groupLabelLen = WebGPU.Raw.StringView(_groupLabelPtr, if isNull _groupLabelArr then 0un else unativeint _groupLabelArr.Length)
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderPushDebugGroup(handle, _groupLabelLen)
        res
    member this.SetStencilReference(reference : int) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetStencilReference(handle, uint32(reference))
        res
    member this.SetBlendConstant(color : Color) : unit =
        color.Pin(device, fun _colorPtr ->
            let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetBlendConstant(handle, _colorPtr)
            res
        )
    member this.SetViewport(x : float32, y : float32, width : float32, height : float32, minDepth : float32, maxDepth : float32) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetViewport(handle, x, y, width, height, minDepth, maxDepth)
        res
    member this.SetScissorRect(x : int, y : int, width : int, height : int) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetScissorRect(handle, uint32(x), uint32(y), uint32(width), uint32(height))
        res
    member this.SetVertexBuffer(slot : int, buffer : Buffer, offset : int64, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetVertexBuffer(handle, uint32(slot), buffer.Handle, uint64(offset), uint64(size))
        res
    member this.SetIndexBuffer(buffer : Buffer, format : IndexFormat, offset : int64, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetIndexBuffer(handle, buffer.Handle, format, uint64(offset), uint64(size))
        res
    member this.BeginOcclusionQuery(queryIndex : int) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderBeginOcclusionQuery(handle, uint32(queryIndex))
        res
    member this.EndOcclusionQuery() : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderEndOcclusionQuery(handle)
        res
    member this.WriteTimestamp(querySet : QuerySet, queryIndex : int) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderWriteTimestamp(handle, querySet.Handle, uint32(queryIndex))
        res
    member this.PixelLocalStorageBarrier() : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderPixelLocalStorageBarrier(handle)
        res
    member this.End() : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderEnd(handle)
        res
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetLabel(handle, _labelLen)
        res
    member this.SetImmediateData(offset : int, data : nativeint, size : int64) : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderSetImmediateData(handle, uint32(offset), data, unativeint(size))
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.RenderPassEncoderAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type RenderPipeline internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new RenderPipeline(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"RenderPipeline(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? RenderPipeline as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.GetBindGroupLayout(groupIndex : int) : BindGroupLayout =
        let res = WebGPU.Raw.WebGPU.RenderPipelineGetBindGroupLayout(handle, uint32(groupIndex))
        new BindGroupLayout(res)
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.RenderPipelineSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.RenderPipelineRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.RenderPipelineAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type RequestDeviceCallback = delegate of IDisposable * status : RequestDeviceStatus * device : Device * message : string -> unit
type RequestDeviceCallbackInfo = 
    {
        Mode : CallbackMode
        Callback : RequestDeviceCallback
    }
    static member Null = Unchecked.defaultof<RequestDeviceCallbackInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RequestDeviceCallbackInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable _callbackPtr = 0n
            if not (isNull (this.Callback :> obj)) then
                let mutable _callbackGC = Unchecked.defaultof<GCHandle>
                let mutable _callbackDel = Unchecked.defaultof<WebGPU.Raw.RequestDeviceCallback>
                _callbackDel <- WebGPU.Raw.RequestDeviceCallback(fun status device message userdata1 userdata2 ->
                    let _status = status
                    let _device = new Device(device)
                    let _message = let _messagePtr = NativePtr.toNativeInt(message.Data) in if _messagePtr = 0n then null else Marshal.PtrToStringUTF8(_messagePtr, int(message.Length))
                    this.Callback.Invoke({ new IDisposable with member __.Dispose() = _callbackGC.Free() }, _status, _device, _message)
                )
                _callbackGC <- GCHandle.Alloc(_callbackDel)
                _callbackPtr <- Marshal.GetFunctionPointerForDelegate(_callbackDel)
            let mutable value =
                new WebGPU.Raw.RequestDeviceCallbackInfo(
                    nextInChain,
                    this.Mode,
                    _callbackPtr,
                    Unchecked.defaultof<_>,
                    Unchecked.defaultof<_>
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RequestDeviceCallbackInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RequestDeviceCallbackInfo>) = 
        {
            Mode = backend.Mode
            Callback = failwith "cannot read callbacks"//TODO2 map [(callback, backend.Callback); (mode, backend.Mode); (next in chain, backend.NextInChain); ... ]
        }
type VertexState = 
    {
        Module : ShaderModule
        EntryPoint : string
        Constants : array<ConstantEntry>
        Buffers : array<VertexBufferLayout>
    }
    static member Null = Unchecked.defaultof<VertexState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.VertexState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _entryPointArr = if isNull this.EntryPoint then null else Encoding.UTF8.GetBytes(this.EntryPoint)
            use _entryPointPtr = fixed _entryPointArr
            let _entryPointLen = WebGPU.Raw.StringView(_entryPointPtr, if isNull _entryPointArr then 0un else unativeint _entryPointArr.Length)
            WebGPU.Raw.Pinnable.pinArray device this.Constants (fun constantsPtr ->
                let constantsLen = unativeint this.Constants.Length
                WebGPU.Raw.Pinnable.pinArray device this.Buffers (fun buffersPtr ->
                    let buffersLen = unativeint this.Buffers.Length
                    let mutable value =
                        new WebGPU.Raw.VertexState(
                            nextInChain,
                            this.Module.Handle,
                            _entryPointLen,
                            constantsLen,
                            constantsPtr,
                            buffersLen,
                            buffersPtr
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.VertexState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.VertexState>) = 
        {
            Module = new ShaderModule(device, backend.Module)
            EntryPoint = let _entryPointPtr = NativePtr.toNativeInt(backend.EntryPoint.Data) in if _entryPointPtr = 0n then null else Marshal.PtrToStringUTF8(_entryPointPtr, int(backend.EntryPoint.Length))
            Constants = let ptr = backend.Constants in Array.init (int backend.ConstantCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in ConstantEntry.Read(device, &r))
            Buffers = let ptr = backend.Buffers in Array.init (int backend.BufferCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in VertexBufferLayout.Read(device, &r))
        }
type PrimitiveState = 
    {
        Topology : PrimitiveTopology
        StripIndexFormat : IndexFormat
        FrontFace : FrontFace
        CullMode : CullMode
        UnclippedDepth : bool
    }
    static member Null = Unchecked.defaultof<PrimitiveState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.PrimitiveState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.PrimitiveState(
                    nextInChain,
                    this.Topology,
                    this.StripIndexFormat,
                    this.FrontFace,
                    this.CullMode,
                    (if this.UnclippedDepth then 1 else 0)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.PrimitiveState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.PrimitiveState>) = 
        {
            Topology = backend.Topology
            StripIndexFormat = backend.StripIndexFormat
            FrontFace = backend.FrontFace
            CullMode = backend.CullMode
            UnclippedDepth = (backend.UnclippedDepth <> 0)
        }
type DepthStencilState = 
    {
        Format : TextureFormat
        DepthWriteEnabled : OptionalBool
        DepthCompare : CompareFunction
        StencilFront : StencilFaceState
        StencilBack : StencilFaceState
        StencilReadMask : int
        StencilWriteMask : int
        DepthBias : int
        DepthBiasSlopeScale : float32
        DepthBiasClamp : float32
    }
    static member Null = Unchecked.defaultof<DepthStencilState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DepthStencilState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            this.StencilFront.Pin(device, fun _stencilFrontPtr ->
                this.StencilBack.Pin(device, fun _stencilBackPtr ->
                    let mutable value =
                        new WebGPU.Raw.DepthStencilState(
                            nextInChain,
                            this.Format,
                            this.DepthWriteEnabled,
                            this.DepthCompare,
                            (if NativePtr.toNativeInt _stencilFrontPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _stencilFrontPtr),
                            (if NativePtr.toNativeInt _stencilBackPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _stencilBackPtr),
                            uint32(this.StencilReadMask),
                            uint32(this.StencilWriteMask),
                            this.DepthBias,
                            this.DepthBiasSlopeScale,
                            this.DepthBiasClamp
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DepthStencilState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DepthStencilState>) = 
        {
            Format = backend.Format
            DepthWriteEnabled = backend.DepthWriteEnabled
            DepthCompare = backend.DepthCompare
            StencilFront = StencilFaceState.Read(device, &backend.StencilFront)
            StencilBack = StencilFaceState.Read(device, &backend.StencilBack)
            StencilReadMask = int(backend.StencilReadMask)
            StencilWriteMask = int(backend.StencilWriteMask)
            DepthBias = backend.DepthBias
            DepthBiasSlopeScale = backend.DepthBiasSlopeScale
            DepthBiasClamp = backend.DepthBiasClamp
        }
type MultisampleState = 
    {
        Count : int
        Mask : int
        AlphaToCoverageEnabled : bool
    }
    static member Null = Unchecked.defaultof<MultisampleState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.MultisampleState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.MultisampleState(
                    nextInChain,
                    uint32(this.Count),
                    uint32(this.Mask),
                    (if this.AlphaToCoverageEnabled then 1 else 0)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.MultisampleState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.MultisampleState>) = 
        {
            Count = int(backend.Count)
            Mask = int(backend.Mask)
            AlphaToCoverageEnabled = (backend.AlphaToCoverageEnabled <> 0)
        }
type FragmentState = 
    {
        Module : ShaderModule
        EntryPoint : string
        Constants : array<ConstantEntry>
        Targets : array<ColorTargetState>
    }
    static member Null = Unchecked.defaultof<FragmentState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.FragmentState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _entryPointArr = if isNull this.EntryPoint then null else Encoding.UTF8.GetBytes(this.EntryPoint)
            use _entryPointPtr = fixed _entryPointArr
            let _entryPointLen = WebGPU.Raw.StringView(_entryPointPtr, if isNull _entryPointArr then 0un else unativeint _entryPointArr.Length)
            WebGPU.Raw.Pinnable.pinArray device this.Constants (fun constantsPtr ->
                let constantsLen = unativeint this.Constants.Length
                WebGPU.Raw.Pinnable.pinArray device this.Targets (fun targetsPtr ->
                    let targetsLen = unativeint this.Targets.Length
                    let mutable value =
                        new WebGPU.Raw.FragmentState(
                            nextInChain,
                            this.Module.Handle,
                            _entryPointLen,
                            constantsLen,
                            constantsPtr,
                            targetsLen,
                            targetsPtr
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.FragmentState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.FragmentState>) = 
        {
            Module = new ShaderModule(device, backend.Module)
            EntryPoint = let _entryPointPtr = NativePtr.toNativeInt(backend.EntryPoint.Data) in if _entryPointPtr = 0n then null else Marshal.PtrToStringUTF8(_entryPointPtr, int(backend.EntryPoint.Length))
            Constants = let ptr = backend.Constants in Array.init (int backend.ConstantCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in ConstantEntry.Read(device, &r))
            Targets = let ptr = backend.Targets in Array.init (int backend.TargetCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in ColorTargetState.Read(device, &r))
        }
type ColorTargetState = 
    {
        Next : IColorTargetStateExtension
        Format : TextureFormat
        Blend : BlendState
        WriteMask : ColorWriteMask
    }
    static member Null = Unchecked.defaultof<ColorTargetState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ColorTargetState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                this.Blend.Pin(device, fun _blendPtr ->
                    let mutable value =
                        new WebGPU.Raw.ColorTargetState(
                            nextInChain,
                            this.Format,
                            _blendPtr,
                            this.WriteMask
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ColorTargetState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ColorTargetState>) = 
        {
            Next = ExtensionDecoder.decode<IColorTargetStateExtension> device backend.NextInChain
            Format = backend.Format
            Blend = let m = NativePtr.toByRef backend.Blend in BlendState.Read(device, &m)
            WriteMask = backend.WriteMask
        }
type ColorTargetStateExpandResolveTextureDawn = 
    {
        Next : IColorTargetStateExtension
        Enabled : bool
    }
    static member Null = Unchecked.defaultof<ColorTargetStateExpandResolveTextureDawn>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ColorTargetStateExpandResolveTextureDawn> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.ColorTargetStateExpandResolveTextureDawn
                let mutable value =
                    new WebGPU.Raw.ColorTargetStateExpandResolveTextureDawn(
                        nextInChain,
                        sType,
                        (if this.Enabled then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IColorTargetStateExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ColorTargetStateExpandResolveTextureDawn> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ColorTargetStateExpandResolveTextureDawn>) = 
        {
            Next = ExtensionDecoder.decode<IColorTargetStateExtension> device backend.NextInChain
            Enabled = (backend.Enabled <> 0)
        }
type BlendState = 
    {
        Color : BlendComponent
        Alpha : BlendComponent
    }
    static member Null = Unchecked.defaultof<BlendState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.BlendState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            this.Color.Pin(device, fun _colorPtr ->
                this.Alpha.Pin(device, fun _alphaPtr ->
                    let mutable value =
                        new WebGPU.Raw.BlendState(
                            (if NativePtr.toNativeInt _colorPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _colorPtr),
                            (if NativePtr.toNativeInt _alphaPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _alphaPtr)
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.BlendState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.BlendState>) = 
        {
            Color = BlendComponent.Read(device, &backend.Color)
            Alpha = BlendComponent.Read(device, &backend.Alpha)
        }
type RenderPipelineDescriptor = 
    {
        Label : string
        Layout : PipelineLayout
        Vertex : VertexState
        Primitive : PrimitiveState
        DepthStencil : DepthStencilState
        Multisample : MultisampleState
        Fragment : FragmentState
    }
    static member Null = Unchecked.defaultof<RenderPipelineDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.RenderPipelineDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
            use _labelPtr = fixed _labelArr
            let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
            this.Vertex.Pin(device, fun _vertexPtr ->
                this.Primitive.Pin(device, fun _primitivePtr ->
                    this.DepthStencil.Pin(device, fun _depthStencilPtr ->
                        this.Multisample.Pin(device, fun _multisamplePtr ->
                            this.Fragment.Pin(device, fun _fragmentPtr ->
                                let mutable value =
                                    new WebGPU.Raw.RenderPipelineDescriptor(
                                        nextInChain,
                                        _labelLen,
                                        this.Layout.Handle,
                                        (if NativePtr.toNativeInt _vertexPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _vertexPtr),
                                        (if NativePtr.toNativeInt _primitivePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _primitivePtr),
                                        _depthStencilPtr,
                                        (if NativePtr.toNativeInt _multisamplePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _multisamplePtr),
                                        _fragmentPtr
                                    )
                                use ptr = fixed &value
                                action ptr
                            )
                        )
                    )
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.RenderPipelineDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.RenderPipelineDescriptor>) = 
        {
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            Layout = new PipelineLayout(device, backend.Layout)
            Vertex = VertexState.Read(device, &backend.Vertex)
            Primitive = PrimitiveState.Read(device, &backend.Primitive)
            DepthStencil = let m = NativePtr.toByRef backend.DepthStencil in DepthStencilState.Read(device, &m)
            Multisample = MultisampleState.Read(device, &backend.Multisample)
            Fragment = let m = NativePtr.toByRef backend.Fragment in FragmentState.Read(device, &m)
        }
type Sampler internal(device : Device, handle : nativeint) =
    static let nullptr = new Sampler(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"Sampler(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? Sampler as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.SamplerSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.SamplerRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.SamplerAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type SamplerDescriptor = 
    {
        Next : ISamplerDescriptorExtension
        Label : string
        AddressModeU : AddressMode
        AddressModeV : AddressMode
        AddressModeW : AddressMode
        MagFilter : FilterMode
        MinFilter : FilterMode
        MipmapFilter : MipmapFilterMode
        LodMinClamp : float32
        LodMaxClamp : float32
        Compare : CompareFunction
        MaxAnisotropy : uint16
    }
    static member Null = Unchecked.defaultof<SamplerDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SamplerDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                let mutable value =
                    new WebGPU.Raw.SamplerDescriptor(
                        nextInChain,
                        _labelLen,
                        this.AddressModeU,
                        this.AddressModeV,
                        this.AddressModeW,
                        this.MagFilter,
                        this.MinFilter,
                        this.MipmapFilter,
                        this.LodMinClamp,
                        this.LodMaxClamp,
                        this.Compare,
                        this.MaxAnisotropy
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SamplerDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SamplerDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISamplerDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            AddressModeU = backend.AddressModeU
            AddressModeV = backend.AddressModeV
            AddressModeW = backend.AddressModeW
            MagFilter = backend.MagFilter
            MinFilter = backend.MinFilter
            MipmapFilter = backend.MipmapFilter
            LodMinClamp = backend.LodMinClamp
            LodMaxClamp = backend.LodMaxClamp
            Compare = backend.Compare
            MaxAnisotropy = backend.MaxAnisotropy
        }
type ShaderModule internal(device : Device, handle : nativeint) =
    static let nullptr = new ShaderModule(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"ShaderModule(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? ShaderModule as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.GetCompilationInfo(callbackInfo : CompilationInfoCallbackInfo) : Future =
        callbackInfo.Pin(device, fun _callbackInfoPtr ->
            let res = WebGPU.Raw.WebGPU.ShaderModuleGetCompilationInfo(handle, (if NativePtr.toNativeInt _callbackInfoPtr = 0n then Unchecked.defaultof<_> else NativePtr.read _callbackInfoPtr))
            Future.Read(device, &res)
        )
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.ShaderModuleSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.ShaderModuleRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.ShaderModuleAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type ShaderModuleDescriptor = 
    {
        Next : IShaderModuleDescriptorExtension
        Label : string
    }
    static member Null = Unchecked.defaultof<ShaderModuleDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ShaderModuleDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                let mutable value =
                    new WebGPU.Raw.ShaderModuleDescriptor(
                        nextInChain,
                        _labelLen
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ShaderModuleDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ShaderModuleDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<IShaderModuleDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
        }
type ShaderModuleSPIRVDescriptor = ShaderSourceSPIRV
type ShaderSourceSPIRV = 
    {
        Next : IShaderModuleDescriptorExtension
        Code : array<uint32>
    }
    static member Null = Unchecked.defaultof<ShaderSourceSPIRV>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ShaderSourceSPIRV> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.ShaderSourceSPIRV
                use codePtr = fixed (this.Code)
                let codeLen = uint32 this.Code.Length
                let mutable value =
                    new WebGPU.Raw.ShaderSourceSPIRV(
                        nextInChain,
                        sType,
                        codeLen,
                        codePtr
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IShaderModuleDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ShaderSourceSPIRV> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ShaderSourceSPIRV>) = 
        {
            Next = ExtensionDecoder.decode<IShaderModuleDescriptorExtension> device backend.NextInChain
            Code = let ptr = backend.Code in Array.init (int backend.CodeSize) (fun i -> NativePtr.get ptr i)
        }
type ShaderModuleWGSLDescriptor = ShaderSourceWGSL
type ShaderSourceWGSL = 
    {
        Next : IShaderModuleDescriptorExtension
        Code : string
    }
    static member Null = Unchecked.defaultof<ShaderSourceWGSL>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ShaderSourceWGSL> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.ShaderSourceWGSL
                let _codeArr = if isNull this.Code then null else Encoding.UTF8.GetBytes(this.Code)
                use _codePtr = fixed _codeArr
                let _codeLen = WebGPU.Raw.StringView(_codePtr, if isNull _codeArr then 0un else unativeint _codeArr.Length)
                let mutable value =
                    new WebGPU.Raw.ShaderSourceWGSL(
                        nextInChain,
                        sType,
                        _codeLen
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IShaderModuleDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ShaderSourceWGSL> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ShaderSourceWGSL>) = 
        {
            Next = ExtensionDecoder.decode<IShaderModuleDescriptorExtension> device backend.NextInChain
            Code = let _codePtr = NativePtr.toNativeInt(backend.Code.Data) in if _codePtr = 0n then null else Marshal.PtrToStringUTF8(_codePtr, int(backend.Code.Length))
        }
type DawnShaderModuleSPIRVOptionsDescriptor = 
    {
        Next : IShaderModuleDescriptorExtension
        AllowNonUniformDerivatives : bool
    }
    static member Null = Unchecked.defaultof<DawnShaderModuleSPIRVOptionsDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnShaderModuleSPIRVOptionsDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnShaderModuleSPIRVOptionsDescriptor
                let mutable value =
                    new WebGPU.Raw.DawnShaderModuleSPIRVOptionsDescriptor(
                        nextInChain,
                        sType,
                        (if this.AllowNonUniformDerivatives then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IShaderModuleDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnShaderModuleSPIRVOptionsDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnShaderModuleSPIRVOptionsDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<IShaderModuleDescriptorExtension> device backend.NextInChain
            AllowNonUniformDerivatives = (backend.AllowNonUniformDerivatives <> 0)
        }
type ShaderModuleCompilationOptions = 
    {
        Next : IShaderModuleDescriptorExtension
        StrictMath : bool
    }
    static member Null = Unchecked.defaultof<ShaderModuleCompilationOptions>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.ShaderModuleCompilationOptions> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.ShaderModuleCompilationOptions
                let mutable value =
                    new WebGPU.Raw.ShaderModuleCompilationOptions(
                        nextInChain,
                        sType,
                        (if this.StrictMath then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IShaderModuleDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.ShaderModuleCompilationOptions> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.ShaderModuleCompilationOptions>) = 
        {
            Next = ExtensionDecoder.decode<IShaderModuleDescriptorExtension> device backend.NextInChain
            StrictMath = (backend.StrictMath <> 0)
        }
type StencilFaceState = 
    {
        Compare : CompareFunction
        FailOp : StencilOperation
        DepthFailOp : StencilOperation
        PassOp : StencilOperation
    }
    static member Null = Unchecked.defaultof<StencilFaceState>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.StencilFaceState> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.StencilFaceState(
                    this.Compare,
                    this.FailOp,
                    this.DepthFailOp,
                    this.PassOp
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.StencilFaceState> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.StencilFaceState>) = 
        {
            Compare = backend.Compare
            FailOp = backend.FailOp
            DepthFailOp = backend.DepthFailOp
            PassOp = backend.PassOp
        }
type Surface internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new Surface(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"Surface(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? Surface as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.Configure(config : SurfaceConfiguration) : unit =
        config.Pin(device, fun _configPtr ->
            let res = WebGPU.Raw.WebGPU.SurfaceConfigure(handle, _configPtr)
            res
        )
    member this.GetCapabilities(adapter : Adapter, capabilities : byref<SurfaceCapabilities>) : Status =
        let mutable capabilitiesCopy = capabilities
        try
            capabilities.Pin(device, fun _capabilitiesPtr ->
                if NativePtr.toNativeInt _capabilitiesPtr = 0n then
                    let mutable capabilitiesNative = Unchecked.defaultof<WebGPU.Raw.SurfaceCapabilities>
                    use _capabilitiesPtr = fixed &capabilitiesNative
                    let res = WebGPU.Raw.WebGPU.SurfaceGetCapabilities(handle, adapter.Handle, _capabilitiesPtr)
                    let _ret = res
                    capabilitiesCopy <- SurfaceCapabilities.Read(device, &capabilitiesNative)
                    _ret
                else
                    let res = WebGPU.Raw.WebGPU.SurfaceGetCapabilities(handle, adapter.Handle, _capabilitiesPtr)
                    let _ret = res
                    let capabilitiesResult = NativePtr.toByRef _capabilitiesPtr
                    capabilitiesCopy <- SurfaceCapabilities.Read(device, &capabilitiesResult)
                    _ret
            )
        finally
            capabilities <- capabilitiesCopy
    member this.CurrentTexture : SurfaceTexture =
        let mutable res = Unchecked.defaultof<_>
        let ptr = fixed &res
        WebGPU.Raw.WebGPU.SurfaceGetCurrentTexture(handle, ptr)
        SurfaceTexture.Read(device, &res)
    member this.Present() : unit =
        let res = WebGPU.Raw.WebGPU.SurfacePresent(handle)
        res
    member this.Unconfigure() : unit =
        let res = WebGPU.Raw.WebGPU.SurfaceUnconfigure(handle)
        res
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.SurfaceSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.SurfaceRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.SurfaceAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type SurfaceDescriptor = 
    {
        Next : ISurfaceDescriptorExtension
        Label : string
    }
    static member Null = Unchecked.defaultof<SurfaceDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                let mutable value =
                    new WebGPU.Raw.SurfaceDescriptor(
                        nextInChain,
                        _labelLen
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
        }
type SurfaceDescriptorFromAndroidNativeWindow = SurfaceSourceAndroidNativeWindow
type SurfaceSourceAndroidNativeWindow = 
    {
        Next : ISurfaceDescriptorExtension
        Window : nativeint
    }
    static member Null = Unchecked.defaultof<SurfaceSourceAndroidNativeWindow>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceSourceAndroidNativeWindow> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceSourceAndroidNativeWindow
                let mutable value =
                    new WebGPU.Raw.SurfaceSourceAndroidNativeWindow(
                        nextInChain,
                        sType,
                        this.Window
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceSourceAndroidNativeWindow> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceSourceAndroidNativeWindow>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            Window = backend.Window
        }
type EmscriptenSurfaceSourceCanvasHTMLSelector = 
    {
        Next : ISurfaceDescriptorExtension
        Selector : string
    }
    static member Null = Unchecked.defaultof<EmscriptenSurfaceSourceCanvasHTMLSelector>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.EmscriptenSurfaceSourceCanvasHTMLSelector> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.EmscriptenSurfaceSourceCanvasHTMLSelector
                let _selectorArr = if isNull this.Selector then null else Encoding.UTF8.GetBytes(this.Selector)
                use _selectorPtr = fixed _selectorArr
                let _selectorLen = WebGPU.Raw.StringView(_selectorPtr, if isNull _selectorArr then 0un else unativeint _selectorArr.Length)
                let mutable value =
                    new WebGPU.Raw.EmscriptenSurfaceSourceCanvasHTMLSelector(
                        nextInChain,
                        sType,
                        _selectorLen
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.EmscriptenSurfaceSourceCanvasHTMLSelector> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.EmscriptenSurfaceSourceCanvasHTMLSelector>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            Selector = let _selectorPtr = NativePtr.toNativeInt(backend.Selector.Data) in if _selectorPtr = 0n then null else Marshal.PtrToStringUTF8(_selectorPtr, int(backend.Selector.Length))
        }
type SurfaceDescriptorFromMetalLayer = SurfaceSourceMetalLayer
type SurfaceSourceMetalLayer = 
    {
        Next : ISurfaceDescriptorExtension
        Layer : nativeint
    }
    static member Null = Unchecked.defaultof<SurfaceSourceMetalLayer>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceSourceMetalLayer> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceSourceMetalLayer
                let mutable value =
                    new WebGPU.Raw.SurfaceSourceMetalLayer(
                        nextInChain,
                        sType,
                        this.Layer
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceSourceMetalLayer> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceSourceMetalLayer>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            Layer = backend.Layer
        }
type SurfaceDescriptorFromWindowsHWND = SurfaceSourceWindowsHWND
type SurfaceSourceWindowsHWND = 
    {
        Next : ISurfaceDescriptorExtension
        Hinstance : nativeint
        Hwnd : nativeint
    }
    static member Null = Unchecked.defaultof<SurfaceSourceWindowsHWND>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceSourceWindowsHWND> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceSourceWindowsHWND
                let mutable value =
                    new WebGPU.Raw.SurfaceSourceWindowsHWND(
                        nextInChain,
                        sType,
                        this.Hinstance,
                        this.Hwnd
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceSourceWindowsHWND> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceSourceWindowsHWND>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            Hinstance = backend.Hinstance
            Hwnd = backend.Hwnd
        }
type SurfaceDescriptorFromXcbWindow = SurfaceSourceXCBWindow
type SurfaceSourceXCBWindow = 
    {
        Next : ISurfaceDescriptorExtension
        Connection : nativeint
        Window : int
    }
    static member Null = Unchecked.defaultof<SurfaceSourceXCBWindow>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceSourceXCBWindow> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceSourceXCBWindow
                let mutable value =
                    new WebGPU.Raw.SurfaceSourceXCBWindow(
                        nextInChain,
                        sType,
                        this.Connection,
                        uint32(this.Window)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceSourceXCBWindow> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceSourceXCBWindow>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            Connection = backend.Connection
            Window = int(backend.Window)
        }
type SurfaceDescriptorFromXlibWindow = SurfaceSourceXlibWindow
type SurfaceSourceXlibWindow = 
    {
        Next : ISurfaceDescriptorExtension
        Display : nativeint
        Window : int64
    }
    static member Null = Unchecked.defaultof<SurfaceSourceXlibWindow>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceSourceXlibWindow> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceSourceXlibWindow
                let mutable value =
                    new WebGPU.Raw.SurfaceSourceXlibWindow(
                        nextInChain,
                        sType,
                        this.Display,
                        uint64(this.Window)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceSourceXlibWindow> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceSourceXlibWindow>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            Display = backend.Display
            Window = int64(backend.Window)
        }
type SurfaceDescriptorFromWaylandSurface = SurfaceSourceWaylandSurface
type SurfaceSourceWaylandSurface = 
    {
        Next : ISurfaceDescriptorExtension
        Display : nativeint
        Surface : nativeint
    }
    static member Null = Unchecked.defaultof<SurfaceSourceWaylandSurface>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceSourceWaylandSurface> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceSourceWaylandSurface
                let mutable value =
                    new WebGPU.Raw.SurfaceSourceWaylandSurface(
                        nextInChain,
                        sType,
                        this.Display,
                        this.Surface
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceSourceWaylandSurface> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceSourceWaylandSurface>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            Display = backend.Display
            Surface = backend.Surface
        }
type SurfaceDescriptorFromWindowsCoreWindow = 
    {
        Next : ISurfaceDescriptorExtension
        CoreWindow : nativeint
    }
    static member Null = Unchecked.defaultof<SurfaceDescriptorFromWindowsCoreWindow>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceDescriptorFromWindowsCoreWindow> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceDescriptorFromWindowsCoreWindow
                let mutable value =
                    new WebGPU.Raw.SurfaceDescriptorFromWindowsCoreWindow(
                        nextInChain,
                        sType,
                        this.CoreWindow
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceDescriptorFromWindowsCoreWindow> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceDescriptorFromWindowsCoreWindow>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            CoreWindow = backend.CoreWindow
        }
type SurfaceDescriptorFromWindowsUWPSwapChainPanel = 
    {
        Next : ISurfaceDescriptorExtension
        SwapChainPanel : nativeint
    }
    static member Null = Unchecked.defaultof<SurfaceDescriptorFromWindowsUWPSwapChainPanel>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceDescriptorFromWindowsUWPSwapChainPanel> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceDescriptorFromWindowsUWPSwapChainPanel
                let mutable value =
                    new WebGPU.Raw.SurfaceDescriptorFromWindowsUWPSwapChainPanel(
                        nextInChain,
                        sType,
                        this.SwapChainPanel
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceDescriptorFromWindowsUWPSwapChainPanel> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceDescriptorFromWindowsUWPSwapChainPanel>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            SwapChainPanel = backend.SwapChainPanel
        }
type SurfaceDescriptorFromWindowsWinUISwapChainPanel = 
    {
        Next : ISurfaceDescriptorExtension
        SwapChainPanel : nativeint
    }
    static member Null = Unchecked.defaultof<SurfaceDescriptorFromWindowsWinUISwapChainPanel>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceDescriptorFromWindowsWinUISwapChainPanel> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceDescriptorFromWindowsWinUISwapChainPanel
                let mutable value =
                    new WebGPU.Raw.SurfaceDescriptorFromWindowsWinUISwapChainPanel(
                        nextInChain,
                        sType,
                        this.SwapChainPanel
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceDescriptorFromWindowsWinUISwapChainPanel> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceDescriptorFromWindowsWinUISwapChainPanel>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            SwapChainPanel = backend.SwapChainPanel
        }
type SurfaceColorManagement = 
    {
        Next : ISurfaceDescriptorExtension
        ColorSpace : PredefinedColorSpace
        ToneMappingMode : ToneMappingMode
    }
    static member Null = Unchecked.defaultof<SurfaceColorManagement>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceColorManagement> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.SurfaceColorManagement
                let mutable value =
                    new WebGPU.Raw.SurfaceColorManagement(
                        nextInChain,
                        sType,
                        this.ColorSpace,
                        this.ToneMappingMode
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISurfaceDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceColorManagement> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceColorManagement>) = 
        {
            Next = ExtensionDecoder.decode<ISurfaceDescriptorExtension> device backend.NextInChain
            ColorSpace = backend.ColorSpace
            ToneMappingMode = backend.ToneMappingMode
        }
type SurfaceTexture = 
    {
        Texture : Texture
        Status : SurfaceGetCurrentTextureStatus
    }
    static member Null = Unchecked.defaultof<SurfaceTexture>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SurfaceTexture> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let nextInChain = 0n
            let mutable value =
                new WebGPU.Raw.SurfaceTexture(
                    nextInChain,
                    this.Texture.Handle,
                    this.Status
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SurfaceTexture> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SurfaceTexture>) = 
        {
            Texture = new Texture(device, backend.Texture)
            Status = backend.Status
        }
type Texture internal(device : Device, handle : nativeint) =
    static let nullptr = new Texture(Unchecked.defaultof<_>, Unchecked.defaultof<_>)
    let width =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.TextureGetWidth(handle)
            int(res)
        )
    let height =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.TextureGetHeight(handle)
            int(res)
        )
    let depthOrArrayLayers =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.TextureGetDepthOrArrayLayers(handle)
            int(res)
        )
    let mipLevelCount =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.TextureGetMipLevelCount(handle)
            int(res)
        )
    let sampleCount =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.TextureGetSampleCount(handle)
            int(res)
        )
    let dimension =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.TextureGetDimension(handle)
            res
        )
    let format =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.TextureGetFormat(handle)
            res
        )
    let usage =
        lazy (
            let mutable res = WebGPU.Raw.WebGPU.TextureGetUsage(handle)
            res
        )
    member x.Handle = handle
    member x.Device = device
    override x.ToString() = $"Texture(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? Texture as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    interface Aardvark.Rendering.IBackendTexture with
        member x.Name
            with get() = null
            and set _ = ()
        member x.WantMipMaps = x.MipLevelCount > 1
        member x.Runtime = x.Device.Runtime
        member x.Dimension = Unchecked.defaultof<_>
        member x.Format = Unchecked.defaultof<_>
        member x.Samples = x.SampleCount
        member x.Count = x.DepthOrArrayLayers
        member x.MipMapLevels = x.MipLevelCount
        member x.Size = Aardvark.Base.V3i(x.Width, x.Height, x.DepthOrArrayLayers)
        member x.Handle = uint64 handle
    member this.CreateView(descriptor : TextureViewDescriptor) : TextureView =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.TextureCreateView(handle, _descriptorPtr)
            new TextureView(res)
        )
    member this.CreateErrorView(descriptor : TextureViewDescriptor) : TextureView =
        descriptor.Pin(device, fun _descriptorPtr ->
            let res = WebGPU.Raw.WebGPU.TextureCreateErrorView(handle, _descriptorPtr)
            new TextureView(res)
        )
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.TextureSetLabel(handle, _labelLen)
        res
    member this.Width : int =
        width.Value
    member this.Height : int =
        height.Value
    member this.DepthOrArrayLayers : int =
        depthOrArrayLayers.Value
    member this.MipLevelCount : int =
        mipLevelCount.Value
    member this.SampleCount : int =
        sampleCount.Value
    member this.Dimension : TextureDimension =
        dimension.Value
    member this.Format : TextureFormat =
        format.Value
    member this.Usage : TextureUsage =
        usage.Value
    member this.Destroy() : unit =
        let res = WebGPU.Raw.WebGPU.TextureDestroy(handle)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.TextureRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.TextureAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type TextureDescriptor = 
    {
        Next : ITextureDescriptorExtension
        Label : string
        Usage : TextureUsage
        Dimension : TextureDimension
        Size : Extent3D
        Format : TextureFormat
        MipLevelCount : int
        SampleCount : int
        ViewFormats : array<TextureFormat>
    }
    static member Null = Unchecked.defaultof<TextureDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.TextureDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                this.Size.Pin(device, fun _sizePtr ->
                    use viewFormatsPtr = fixed (this.ViewFormats)
                    let viewFormatsLen = unativeint this.ViewFormats.Length
                    let mutable value =
                        new WebGPU.Raw.TextureDescriptor(
                            nextInChain,
                            _labelLen,
                            this.Usage,
                            this.Dimension,
                            (if NativePtr.toNativeInt _sizePtr = 0n then Unchecked.defaultof<_> else NativePtr.read _sizePtr),
                            this.Format,
                            uint32(this.MipLevelCount),
                            uint32(this.SampleCount),
                            viewFormatsLen,
                            viewFormatsPtr
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.TextureDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.TextureDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ITextureDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            Usage = backend.Usage
            Dimension = backend.Dimension
            Size = Extent3D.Read(device, &backend.Size)
            Format = backend.Format
            MipLevelCount = int(backend.MipLevelCount)
            SampleCount = int(backend.SampleCount)
            ViewFormats = let ptr = backend.ViewFormats in Array.init (int backend.ViewFormatCount) (fun i -> NativePtr.get ptr i)
        }
type TextureBindingViewDimensionDescriptor = 
    {
        Next : ITextureDescriptorExtension
        TextureBindingViewDimension : TextureViewDimension
    }
    static member Null = Unchecked.defaultof<TextureBindingViewDimensionDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.TextureBindingViewDimensionDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.TextureBindingViewDimensionDescriptor
                let mutable value =
                    new WebGPU.Raw.TextureBindingViewDimensionDescriptor(
                        nextInChain,
                        sType,
                        this.TextureBindingViewDimension
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ITextureDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.TextureBindingViewDimensionDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.TextureBindingViewDimensionDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ITextureDescriptorExtension> device backend.NextInChain
            TextureBindingViewDimension = backend.TextureBindingViewDimension
        }
type TextureViewDescriptor = 
    {
        Next : ITextureViewDescriptorExtension
        Label : string
        Format : TextureFormat
        Dimension : TextureViewDimension
        BaseMipLevel : int
        MipLevelCount : int
        BaseArrayLayer : int
        ArrayLayerCount : int
        Aspect : TextureAspect
        Usage : TextureUsage
    }
    static member Null = Unchecked.defaultof<TextureViewDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.TextureViewDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let _labelArr = if isNull this.Label then null else Encoding.UTF8.GetBytes(this.Label)
                use _labelPtr = fixed _labelArr
                let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
                let mutable value =
                    new WebGPU.Raw.TextureViewDescriptor(
                        nextInChain,
                        _labelLen,
                        this.Format,
                        this.Dimension,
                        uint32(this.BaseMipLevel),
                        uint32(this.MipLevelCount),
                        uint32(this.BaseArrayLayer),
                        uint32(this.ArrayLayerCount),
                        this.Aspect,
                        this.Usage
                    )
                use ptr = fixed &value
                action ptr
            )
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.TextureViewDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.TextureViewDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ITextureViewDescriptorExtension> device backend.NextInChain
            Label = let _labelPtr = NativePtr.toNativeInt(backend.Label.Data) in if _labelPtr = 0n then null else Marshal.PtrToStringUTF8(_labelPtr, int(backend.Label.Length))
            Format = backend.Format
            Dimension = backend.Dimension
            BaseMipLevel = int(backend.BaseMipLevel)
            MipLevelCount = int(backend.MipLevelCount)
            BaseArrayLayer = int(backend.BaseArrayLayer)
            ArrayLayerCount = int(backend.ArrayLayerCount)
            Aspect = backend.Aspect
            Usage = backend.Usage
        }
type TextureView internal(handle : nativeint) =
    static let device = Unchecked.defaultof<Device>
    static let nullptr = new TextureView(Unchecked.defaultof<_>)
    member x.Handle = handle
    override x.ToString() = $"TextureView(0x%08X{handle})"
    override x.GetHashCode() = hash handle
    override x.Equals(obj) =
        match obj with
        | :? TextureView as other -> other.Handle = x.Handle
        | _ -> false
    static member Null = nullptr
    member this.SetLabel(label : string) : unit =
        let _labelArr = if isNull label then null else Encoding.UTF8.GetBytes(label)
        use _labelPtr = fixed _labelArr
        let _labelLen = WebGPU.Raw.StringView(_labelPtr, if isNull _labelArr then 0un else unativeint _labelArr.Length)
        let res = WebGPU.Raw.WebGPU.TextureViewSetLabel(handle, _labelLen)
        res
    member this.Release() : unit =
        let res = WebGPU.Raw.WebGPU.TextureViewRelease(handle)
        res
    member this.AddRef() : unit =
        let res = WebGPU.Raw.WebGPU.TextureViewAddRef(handle)
        res
    member private x.Dispose(disposing : bool) =
        if disposing then System.GC.SuppressFinalize(x)
        x.Release()
    member x.Dispose() = x.Dispose(true)
    override x.Finalize() = x.Dispose(false)
    interface System.IDisposable with
        member x.Dispose() = x.Dispose(true)
type YCbCrVkDescriptor = 
    {
        Next : ISamplerDescriptorExtension
        VkFormat : int
        VkYCbCrModel : int
        VkYCbCrRange : int
        VkComponentSwizzleRed : int
        VkComponentSwizzleGreen : int
        VkComponentSwizzleBlue : int
        VkComponentSwizzleAlpha : int
        VkXChromaOffset : int
        VkYChromaOffset : int
        VkChromaFilter : FilterMode
        ForceExplicitReconstruction : bool
        ExternalFormat : int64
    }
    static member Null = Unchecked.defaultof<YCbCrVkDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.YCbCrVkDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.YCbCrVkDescriptor
                let mutable value =
                    new WebGPU.Raw.YCbCrVkDescriptor(
                        nextInChain,
                        sType,
                        uint32(this.VkFormat),
                        uint32(this.VkYCbCrModel),
                        uint32(this.VkYCbCrRange),
                        uint32(this.VkComponentSwizzleRed),
                        uint32(this.VkComponentSwizzleGreen),
                        uint32(this.VkComponentSwizzleBlue),
                        uint32(this.VkComponentSwizzleAlpha),
                        uint32(this.VkXChromaOffset),
                        uint32(this.VkYChromaOffset),
                        this.VkChromaFilter,
                        (if this.ForceExplicitReconstruction then 1 else 0),
                        uint64(this.ExternalFormat)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ISamplerDescriptorExtension
    interface ITextureViewDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.YCbCrVkDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.YCbCrVkDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ISamplerDescriptorExtension> device backend.NextInChain
            VkFormat = int(backend.VkFormat)
            VkYCbCrModel = int(backend.VkYCbCrModel)
            VkYCbCrRange = int(backend.VkYCbCrRange)
            VkComponentSwizzleRed = int(backend.VkComponentSwizzleRed)
            VkComponentSwizzleGreen = int(backend.VkComponentSwizzleGreen)
            VkComponentSwizzleBlue = int(backend.VkComponentSwizzleBlue)
            VkComponentSwizzleAlpha = int(backend.VkComponentSwizzleAlpha)
            VkXChromaOffset = int(backend.VkXChromaOffset)
            VkYChromaOffset = int(backend.VkYChromaOffset)
            VkChromaFilter = backend.VkChromaFilter
            ForceExplicitReconstruction = (backend.ForceExplicitReconstruction <> 0)
            ExternalFormat = int64(backend.ExternalFormat)
        }
type DawnTextureInternalUsageDescriptor = 
    {
        Next : ITextureDescriptorExtension
        InternalUsage : TextureUsage
    }
    static member Null = Unchecked.defaultof<DawnTextureInternalUsageDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnTextureInternalUsageDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnTextureInternalUsageDescriptor
                let mutable value =
                    new WebGPU.Raw.DawnTextureInternalUsageDescriptor(
                        nextInChain,
                        sType,
                        this.InternalUsage
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ITextureDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnTextureInternalUsageDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnTextureInternalUsageDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ITextureDescriptorExtension> device backend.NextInChain
            InternalUsage = backend.InternalUsage
        }
type DawnEncoderInternalUsageDescriptor = 
    {
        Next : ICommandEncoderDescriptorExtension
        UseInternalUsages : bool
    }
    static member Null = Unchecked.defaultof<DawnEncoderInternalUsageDescriptor>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnEncoderInternalUsageDescriptor> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnEncoderInternalUsageDescriptor
                let mutable value =
                    new WebGPU.Raw.DawnEncoderInternalUsageDescriptor(
                        nextInChain,
                        sType,
                        (if this.UseInternalUsages then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface ICommandEncoderDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnEncoderInternalUsageDescriptor> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnEncoderInternalUsageDescriptor>) = 
        {
            Next = ExtensionDecoder.decode<ICommandEncoderDescriptorExtension> device backend.NextInChain
            UseInternalUsages = (backend.UseInternalUsages <> 0)
        }
type DawnAdapterPropertiesPowerPreference = 
    {
        Next : IAdapterInfoExtension
        PowerPreference : PowerPreference
    }
    static member Null = Unchecked.defaultof<DawnAdapterPropertiesPowerPreference>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnAdapterPropertiesPowerPreference> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnAdapterPropertiesPowerPreference
                let mutable value =
                    new WebGPU.Raw.DawnAdapterPropertiesPowerPreference(
                        nextInChain,
                        sType,
                        this.PowerPreference
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IAdapterInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnAdapterPropertiesPowerPreference> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnAdapterPropertiesPowerPreference>) = 
        {
            Next = ExtensionDecoder.decode<IAdapterInfoExtension> device backend.NextInChain
            PowerPreference = backend.PowerPreference
        }
type MemoryHeapInfo = 
    {
        Properties : HeapProperty
        Size : int64
    }
    static member Null = Unchecked.defaultof<MemoryHeapInfo>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.MemoryHeapInfo> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.MemoryHeapInfo(
                    this.Properties,
                    uint64(this.Size)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.MemoryHeapInfo> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.MemoryHeapInfo>) = 
        {
            Properties = backend.Properties
            Size = int64(backend.Size)
        }
type AdapterPropertiesMemoryHeaps = 
    {
        Next : IAdapterInfoExtension
        HeapInfo : array<MemoryHeapInfo>
    }
    static member Null = Unchecked.defaultof<AdapterPropertiesMemoryHeaps>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.AdapterPropertiesMemoryHeaps> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.AdapterPropertiesMemoryHeaps
                WebGPU.Raw.Pinnable.pinArray device this.HeapInfo (fun heapInfoPtr ->
                    let heapInfoLen = unativeint this.HeapInfo.Length
                    let mutable value =
                        new WebGPU.Raw.AdapterPropertiesMemoryHeaps(
                            nextInChain,
                            sType,
                            heapInfoLen,
                            heapInfoPtr
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IAdapterInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.AdapterPropertiesMemoryHeaps> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.AdapterPropertiesMemoryHeaps>) = 
        {
            Next = ExtensionDecoder.decode<IAdapterInfoExtension> device backend.NextInChain
            HeapInfo = let ptr = backend.HeapInfo in Array.init (int backend.HeapCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in MemoryHeapInfo.Read(device, &r))
        }
type AdapterPropertiesD3D = 
    {
        Next : IAdapterInfoExtension
        ShaderModel : int
    }
    static member Null = Unchecked.defaultof<AdapterPropertiesD3D>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.AdapterPropertiesD3D> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.AdapterPropertiesD3D
                let mutable value =
                    new WebGPU.Raw.AdapterPropertiesD3D(
                        nextInChain,
                        sType,
                        uint32(this.ShaderModel)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IAdapterInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.AdapterPropertiesD3D> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.AdapterPropertiesD3D>) = 
        {
            Next = ExtensionDecoder.decode<IAdapterInfoExtension> device backend.NextInChain
            ShaderModel = int(backend.ShaderModel)
        }
type AdapterPropertiesVk = 
    {
        Next : IAdapterInfoExtension
        DriverVersion : int
    }
    static member Null = Unchecked.defaultof<AdapterPropertiesVk>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.AdapterPropertiesVk> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.AdapterPropertiesVk
                let mutable value =
                    new WebGPU.Raw.AdapterPropertiesVk(
                        nextInChain,
                        sType,
                        uint32(this.DriverVersion)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IAdapterInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.AdapterPropertiesVk> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.AdapterPropertiesVk>) = 
        {
            Next = ExtensionDecoder.decode<IAdapterInfoExtension> device backend.NextInChain
            DriverVersion = int(backend.DriverVersion)
        }
type DawnBufferDescriptorErrorInfoFromWireClient = 
    {
        Next : IBufferDescriptorExtension
        OutOfMemory : bool
    }
    static member Null = Unchecked.defaultof<DawnBufferDescriptorErrorInfoFromWireClient>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.DawnBufferDescriptorErrorInfoFromWireClient> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.DawnBufferDescriptorErrorInfoFromWireClient
                let mutable value =
                    new WebGPU.Raw.DawnBufferDescriptorErrorInfoFromWireClient(
                        nextInChain,
                        sType,
                        (if this.OutOfMemory then 1 else 0)
                    )
                use ptr = fixed &value
                action ptr
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IBufferDescriptorExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.DawnBufferDescriptorErrorInfoFromWireClient> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.DawnBufferDescriptorErrorInfoFromWireClient>) = 
        {
            Next = ExtensionDecoder.decode<IBufferDescriptorExtension> device backend.NextInChain
            OutOfMemory = (backend.OutOfMemory <> 0)
        }
type SubgroupMatrixConfig = 
    {
        ComponentType : SubgroupMatrixComponentType
        ResultComponentType : SubgroupMatrixComponentType
        M : int
        N : int
        K : int
    }
    static member Null = Unchecked.defaultof<SubgroupMatrixConfig>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.SubgroupMatrixConfig> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            let mutable value =
                new WebGPU.Raw.SubgroupMatrixConfig(
                    this.ComponentType,
                    this.ResultComponentType,
                    uint32(this.M),
                    uint32(this.N),
                    uint32(this.K)
                )
            use ptr = fixed &value
            action ptr
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.SubgroupMatrixConfig> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.SubgroupMatrixConfig>) = 
        {
            ComponentType = backend.ComponentType
            ResultComponentType = backend.ResultComponentType
            M = int(backend.M)
            N = int(backend.N)
            K = int(backend.K)
        }
type AdapterPropertiesSubgroupMatrixConfigs = 
    {
        Next : IAdapterInfoExtension
        Configs : array<SubgroupMatrixConfig>
    }
    static member Null = Unchecked.defaultof<AdapterPropertiesSubgroupMatrixConfigs>
    [<CompilationRepresentation(CompilationRepresentationFlags.Static)>]
    member this.Pin<'r>(device : Device, action : nativeptr<WebGPU.Raw.AdapterPropertiesSubgroupMatrixConfigs> -> 'r) : 'r = 
        if isNull (this :> obj) then
            action (NativePtr.ofNativeInt 0n)
        else
            PinHelper.PinNullable(this.Next, fun nextInChain ->
                let sType = SType.AdapterPropertiesSubgroupMatrixConfigs
                WebGPU.Raw.Pinnable.pinArray device this.Configs (fun configsPtr ->
                    let configsLen = unativeint this.Configs.Length
                    let mutable value =
                        new WebGPU.Raw.AdapterPropertiesSubgroupMatrixConfigs(
                            nextInChain,
                            sType,
                            configsLen,
                            configsPtr
                        )
                    use ptr = fixed &value
                    action ptr
                )
            )
    interface IExtension with
        member x.Pin<'r>(action : nativeint -> 'r) = x.Pin(Unchecked.defaultof<_>, fun ptr -> action(NativePtr.toNativeInt ptr))
    interface IAdapterInfoExtension
    interface WebGPU.Raw.IPinnable<Device, WebGPU.Raw.AdapterPropertiesSubgroupMatrixConfigs> with
        member x.Pin(device, action) = x.Pin(device, action)
    static member Read(device : Device, backend : inref<WebGPU.Raw.AdapterPropertiesSubgroupMatrixConfigs>) = 
        {
            Next = ExtensionDecoder.decode<IAdapterInfoExtension> device backend.NextInChain
            Configs = let ptr = backend.Configs in Array.init (int backend.ConfigCount) (fun i -> let r = NativePtr.toByRef (NativePtr.add ptr i) in SubgroupMatrixConfig.Read(device, &r))
        }
type BufferProxy(buffer : Buffer) =
    let size = buffer.Size
    
    let content = buffer.ToByteArray(0L, buffer.Size)
    member x.UInt8Array = content
    member x.UInt16Array = 
        use ptr = fixed content
        let ptr = NativePtr.ofNativeInt<uint16> (NativePtr.toNativeInt ptr)
        Array.init (content.Length / 2) (fun i -> NativePtr.get ptr i)
    member x.UInt32Array = 
        use ptr = fixed content
        let ptr = NativePtr.ofNativeInt<uint32> (NativePtr.toNativeInt ptr)
        Array.init (content.Length / 4) (fun i -> NativePtr.get ptr i)
    member x.UInt64Array = 
        use ptr = fixed content
        let ptr = NativePtr.ofNativeInt<uint64> (NativePtr.toNativeInt ptr)
        Array.init (content.Length / 8) (fun i -> NativePtr.get ptr i)
    member x.Int8Array = 
        use ptr = fixed content
        let ptr = NativePtr.ofNativeInt<int8> (NativePtr.toNativeInt ptr)
        Array.init (content.Length) (fun i -> NativePtr.get ptr i)
    member x.Int16Array = 
        use ptr = fixed content
        let ptr = NativePtr.ofNativeInt<int16> (NativePtr.toNativeInt ptr)
        Array.init (content.Length / 2) (fun i -> NativePtr.get ptr i)
    member x.Int32Array = 
        use ptr = fixed content
        let ptr = NativePtr.ofNativeInt<int32> (NativePtr.toNativeInt ptr)
        Array.init (content.Length / 4) (fun i -> NativePtr.get ptr i)
    member x.Int64Array = 
        use ptr = fixed content
        let ptr = NativePtr.ofNativeInt<int64> (NativePtr.toNativeInt ptr)
        Array.init (content.Length / 8) (fun i -> NativePtr.get ptr i)
    member x.Float32Array = 
        use ptr = fixed content
        let ptr = NativePtr.ofNativeInt<float32> (NativePtr.toNativeInt ptr)
        Array.init (content.Length / 4) (fun i -> NativePtr.get ptr i)
    member x.Float64Array = 
        use ptr = fixed content
        let ptr = NativePtr.ofNativeInt<double> (NativePtr.toNativeInt ptr)
        Array.init (content.Length / 8) (fun i -> NativePtr.get ptr i)
