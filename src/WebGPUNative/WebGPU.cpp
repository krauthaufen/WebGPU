#include "dllexport.h"
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
#include <stdint.h>
#include "webgpu.h"
 
#include "webgpu_glfw.h"
DllExport(WGPUSurface) gpuInstanceCreateGLFWSurface(WGPUInstance self, const void* window) {
    auto instance = wgpu::Instance(self);
    auto surf = wgpu::glfw::CreateSurfaceForWindow(instance, (GLFWwindow*)window);
    auto handle = surf.Get();
    wgpuSurfaceAddRef(handle);
    return handle;
}
DllExport(WGPUInstance) gpuCreateInstance(const WGPUInstanceDescriptor* descriptor) {
    return wgpuCreateInstance(descriptor);
}
DllExport(WGPUProc) gpuGetProcAddress(WGPUStringView procName) {
    return wgpuGetProcAddress(procName);
}
DllExport(WGPUInstance) gpuAdapterGetInstance(WGPUAdapter self) {
    return wgpuAdapterGetInstance(self);
}
DllExport(WGPUStatus) gpuAdapterGetLimits(WGPUAdapter self, WGPUSupportedLimits* limits) {
    return wgpuAdapterGetLimits(self, limits);
}
DllExport(WGPUStatus) gpuAdapterGetInfo(WGPUAdapter self, WGPUAdapterInfo* info) {
    return wgpuAdapterGetInfo(self, info);
}
DllExport(bool) gpuAdapterHasFeature(WGPUAdapter self, WGPUFeatureName feature) {
    return wgpuAdapterHasFeature(self, feature);
}
DllExport(void) gpuAdapterGetFeatures(WGPUAdapter self, WGPUSupportedFeatures* features) {
    return wgpuAdapterGetFeatures(self, features);
}
DllExport(void) gpuAdapterRequestDevice(WGPUAdapter self, const WGPUDeviceDescriptor* descriptor, WGPURequestDeviceCallback callback, void * userdata) {
    return wgpuAdapterRequestDevice(self, descriptor, callback, userdata);
}
DllExport(WGPUFuture) gpuAdapterRequestDeviceF(WGPUAdapter self, const WGPUDeviceDescriptor* options, WGPURequestDeviceCallbackInfo callbackInfo) {
    return wgpuAdapterRequestDeviceF(self, options, callbackInfo);
}
DllExport(WGPUFuture) gpuAdapterRequestDevice2(WGPUAdapter self, const WGPUDeviceDescriptor* options, WGPURequestDeviceCallbackInfo2 callbackInfo) {
    return wgpuAdapterRequestDevice2(self, options, callbackInfo);
}
DllExport(WGPUDevice) gpuAdapterCreateDevice(WGPUAdapter self, const WGPUDeviceDescriptor* descriptor) {
    return wgpuAdapterCreateDevice(self, descriptor);
}
DllExport(WGPUStatus) gpuAdapterGetFormatCapabilities(WGPUAdapter self, WGPUTextureFormat format, WGPUFormatCapabilities* capabilities) {
    return wgpuAdapterGetFormatCapabilities(self, format, capabilities);
}
DllExport(void) gpuAdapterRelease(WGPUAdapter self) {
    return wgpuAdapterRelease(self);
}
DllExport(void) gpuBindGroupSetLabel(WGPUBindGroup self, WGPUStringView label) {
    return wgpuBindGroupSetLabel(self, label);
}
DllExport(void) gpuBindGroupRelease(WGPUBindGroup self) {
    return wgpuBindGroupRelease(self);
}
DllExport(void) gpuBindGroupLayoutSetLabel(WGPUBindGroupLayout self, WGPUStringView label) {
    return wgpuBindGroupLayoutSetLabel(self, label);
}
DllExport(void) gpuBindGroupLayoutRelease(WGPUBindGroupLayout self) {
    return wgpuBindGroupLayoutRelease(self);
}
typedef struct { 
   WGPUBuffer Self;
   WGPUMapMode Mode;
   size_t Offset;
   size_t Size;
   WGPUBufferMapCallback Callback;
   void * Userdata;
} WGPUBufferMapAsyncArgs;
DllExport(void) gpuBufferMapAsync(const WGPUBufferMapAsyncArgs* args) {
    return wgpuBufferMapAsync(args->Self, args->Mode, args->Offset, args->Size, args->Callback, args->Userdata);
}
DllExport(WGPUFuture) gpuBufferMapAsyncF(WGPUBuffer self, WGPUMapMode mode, size_t offset, size_t size, WGPUBufferMapCallbackInfo callbackInfo) {
    return wgpuBufferMapAsyncF(self, mode, offset, size, callbackInfo);
}
DllExport(WGPUFuture) gpuBufferMapAsync2(WGPUBuffer self, WGPUMapMode mode, size_t offset, size_t size, WGPUBufferMapCallbackInfo2 callbackInfo) {
    return wgpuBufferMapAsync2(self, mode, offset, size, callbackInfo);
}
DllExport(void *) gpuBufferGetMappedRange(WGPUBuffer self, size_t offset, size_t size) {
    return wgpuBufferGetMappedRange(self, offset, size);
}
DllExport(void const *) gpuBufferGetConstMappedRange(WGPUBuffer self, size_t offset, size_t size) {
    return wgpuBufferGetConstMappedRange(self, offset, size);
}
DllExport(void) gpuBufferSetLabel(WGPUBuffer self, WGPUStringView label) {
    return wgpuBufferSetLabel(self, label);
}
DllExport(WGPUBufferUsage) gpuBufferGetUsage(WGPUBuffer self) {
    return wgpuBufferGetUsage(self);
}
DllExport(uint64_t) gpuBufferGetSize(WGPUBuffer self) {
    return wgpuBufferGetSize(self);
}
DllExport(WGPUBufferMapState) gpuBufferGetMapState(WGPUBuffer self) {
    return wgpuBufferGetMapState(self);
}
DllExport(void) gpuBufferUnmap(WGPUBuffer self) {
    return wgpuBufferUnmap(self);
}
DllExport(void) gpuBufferDestroy(WGPUBuffer self) {
    return wgpuBufferDestroy(self);
}
DllExport(void) gpuBufferRelease(WGPUBuffer self) {
    return wgpuBufferRelease(self);
}
DllExport(void) gpuCommandBufferSetLabel(WGPUCommandBuffer self, WGPUStringView label) {
    return wgpuCommandBufferSetLabel(self, label);
}
DllExport(void) gpuCommandBufferRelease(WGPUCommandBuffer self) {
    return wgpuCommandBufferRelease(self);
}
DllExport(WGPUCommandBuffer) gpuCommandEncoderFinish(WGPUCommandEncoder self, const WGPUCommandBufferDescriptor* descriptor) {
    return wgpuCommandEncoderFinish(self, descriptor);
}
DllExport(WGPUComputePassEncoder) gpuCommandEncoderBeginComputePass(WGPUCommandEncoder self, const WGPUComputePassDescriptor* descriptor) {
    return wgpuCommandEncoderBeginComputePass(self, descriptor);
}
DllExport(WGPURenderPassEncoder) gpuCommandEncoderBeginRenderPass(WGPUCommandEncoder self, const WGPURenderPassDescriptor* descriptor) {
    return wgpuCommandEncoderBeginRenderPass(self, descriptor);
}
typedef struct { 
   WGPUCommandEncoder Self;
   WGPUBuffer Source;
   uint64_t SourceOffset;
   WGPUBuffer Destination;
   uint64_t DestinationOffset;
   uint64_t Size;
} WGPUCommandEncoderCopyBufferToBufferArgs;
DllExport(void) gpuCommandEncoderCopyBufferToBuffer(const WGPUCommandEncoderCopyBufferToBufferArgs* args) {
    return wgpuCommandEncoderCopyBufferToBuffer(args->Self, args->Source, args->SourceOffset, args->Destination, args->DestinationOffset, args->Size);
}
DllExport(void) gpuCommandEncoderCopyBufferToTexture(WGPUCommandEncoder self, const WGPUImageCopyBuffer* source, const WGPUImageCopyTexture* destination, const WGPUExtent3D* copySize) {
    return wgpuCommandEncoderCopyBufferToTexture(self, source, destination, copySize);
}
DllExport(void) gpuCommandEncoderCopyTextureToBuffer(WGPUCommandEncoder self, const WGPUImageCopyTexture* source, const WGPUImageCopyBuffer* destination, const WGPUExtent3D* copySize) {
    return wgpuCommandEncoderCopyTextureToBuffer(self, source, destination, copySize);
}
DllExport(void) gpuCommandEncoderCopyTextureToTexture(WGPUCommandEncoder self, const WGPUImageCopyTexture* source, const WGPUImageCopyTexture* destination, const WGPUExtent3D* copySize) {
    return wgpuCommandEncoderCopyTextureToTexture(self, source, destination, copySize);
}
typedef struct { 
   WGPUCommandEncoder Self;
   WGPUBuffer Buffer;
   uint64_t Offset;
   uint64_t Size;
} WGPUCommandEncoderClearBufferArgs;
DllExport(void) gpuCommandEncoderClearBuffer(const WGPUCommandEncoderClearBufferArgs* args) {
    return wgpuCommandEncoderClearBuffer(args->Self, args->Buffer, args->Offset, args->Size);
}
DllExport(void) gpuCommandEncoderInjectValidationError(WGPUCommandEncoder self, WGPUStringView message) {
    return wgpuCommandEncoderInjectValidationError(self, message);
}
DllExport(void) gpuCommandEncoderInsertDebugMarker(WGPUCommandEncoder self, WGPUStringView markerLabel) {
    return wgpuCommandEncoderInsertDebugMarker(self, markerLabel);
}
DllExport(void) gpuCommandEncoderPopDebugGroup(WGPUCommandEncoder self) {
    return wgpuCommandEncoderPopDebugGroup(self);
}
DllExport(void) gpuCommandEncoderPushDebugGroup(WGPUCommandEncoder self, WGPUStringView groupLabel) {
    return wgpuCommandEncoderPushDebugGroup(self, groupLabel);
}
typedef struct { 
   WGPUCommandEncoder Self;
   WGPUQuerySet QuerySet;
   uint32_t FirstQuery;
   uint32_t QueryCount;
   WGPUBuffer Destination;
   uint64_t DestinationOffset;
} WGPUCommandEncoderResolveQuerySetArgs;
DllExport(void) gpuCommandEncoderResolveQuerySet(const WGPUCommandEncoderResolveQuerySetArgs* args) {
    return wgpuCommandEncoderResolveQuerySet(args->Self, args->QuerySet, args->FirstQuery, args->QueryCount, args->Destination, args->DestinationOffset);
}
typedef struct { 
   WGPUCommandEncoder Self;
   WGPUBuffer Buffer;
   uint64_t BufferOffset;
   const uint8_t* Data;
   uint64_t Size;
} WGPUCommandEncoderWriteBufferArgs;
DllExport(void) gpuCommandEncoderWriteBuffer(const WGPUCommandEncoderWriteBufferArgs* args) {
    return wgpuCommandEncoderWriteBuffer(args->Self, args->Buffer, args->BufferOffset, args->Data, args->Size);
}
DllExport(void) gpuCommandEncoderWriteTimestamp(WGPUCommandEncoder self, WGPUQuerySet querySet, uint32_t queryIndex) {
    return wgpuCommandEncoderWriteTimestamp(self, querySet, queryIndex);
}
DllExport(void) gpuCommandEncoderSetLabel(WGPUCommandEncoder self, WGPUStringView label) {
    return wgpuCommandEncoderSetLabel(self, label);
}
DllExport(void) gpuCommandEncoderRelease(WGPUCommandEncoder self) {
    return wgpuCommandEncoderRelease(self);
}
DllExport(void) gpuComputePassEncoderInsertDebugMarker(WGPUComputePassEncoder self, WGPUStringView markerLabel) {
    return wgpuComputePassEncoderInsertDebugMarker(self, markerLabel);
}
DllExport(void) gpuComputePassEncoderPopDebugGroup(WGPUComputePassEncoder self) {
    return wgpuComputePassEncoderPopDebugGroup(self);
}
DllExport(void) gpuComputePassEncoderPushDebugGroup(WGPUComputePassEncoder self, WGPUStringView groupLabel) {
    return wgpuComputePassEncoderPushDebugGroup(self, groupLabel);
}
DllExport(void) gpuComputePassEncoderSetPipeline(WGPUComputePassEncoder self, WGPUComputePipeline pipeline) {
    return wgpuComputePassEncoderSetPipeline(self, pipeline);
}
DllExport(void) gpuComputePassEncoderSetBindGroup(WGPUComputePassEncoder self, uint32_t groupIndex, WGPUBindGroup group, size_t dynamicOffsetCount, const uint32_t* dynamicOffsets) {
    return wgpuComputePassEncoderSetBindGroup(self, groupIndex, group, dynamicOffsetCount, dynamicOffsets);
}
DllExport(void) gpuComputePassEncoderWriteTimestamp(WGPUComputePassEncoder self, WGPUQuerySet querySet, uint32_t queryIndex) {
    return wgpuComputePassEncoderWriteTimestamp(self, querySet, queryIndex);
}
DllExport(void) gpuComputePassEncoderDispatchWorkgroups(WGPUComputePassEncoder self, uint32_t workgroupCountX, uint32_t workgroupCountY, uint32_t workgroupCountZ) {
    return wgpuComputePassEncoderDispatchWorkgroups(self, workgroupCountX, workgroupCountY, workgroupCountZ);
}
typedef struct { 
   WGPUComputePassEncoder Self;
   WGPUBuffer IndirectBuffer;
   uint64_t IndirectOffset;
} WGPUComputePassEncoderDispatchWorkgroupsIndirectArgs;
DllExport(void) gpuComputePassEncoderDispatchWorkgroupsIndirect(const WGPUComputePassEncoderDispatchWorkgroupsIndirectArgs* args) {
    return wgpuComputePassEncoderDispatchWorkgroupsIndirect(args->Self, args->IndirectBuffer, args->IndirectOffset);
}
DllExport(void) gpuComputePassEncoderEnd(WGPUComputePassEncoder self) {
    return wgpuComputePassEncoderEnd(self);
}
DllExport(void) gpuComputePassEncoderSetLabel(WGPUComputePassEncoder self, WGPUStringView label) {
    return wgpuComputePassEncoderSetLabel(self, label);
}
DllExport(void) gpuComputePassEncoderRelease(WGPUComputePassEncoder self) {
    return wgpuComputePassEncoderRelease(self);
}
DllExport(WGPUBindGroupLayout) gpuComputePipelineGetBindGroupLayout(WGPUComputePipeline self, uint32_t groupIndex) {
    return wgpuComputePipelineGetBindGroupLayout(self, groupIndex);
}
DllExport(void) gpuComputePipelineSetLabel(WGPUComputePipeline self, WGPUStringView label) {
    return wgpuComputePipelineSetLabel(self, label);
}
DllExport(void) gpuComputePipelineRelease(WGPUComputePipeline self) {
    return wgpuComputePipelineRelease(self);
}
DllExport(WGPUBindGroup) gpuDeviceCreateBindGroup(WGPUDevice self, const WGPUBindGroupDescriptor* descriptor) {
    return wgpuDeviceCreateBindGroup(self, descriptor);
}
DllExport(WGPUBindGroupLayout) gpuDeviceCreateBindGroupLayout(WGPUDevice self, const WGPUBindGroupLayoutDescriptor* descriptor) {
    return wgpuDeviceCreateBindGroupLayout(self, descriptor);
}
DllExport(WGPUBuffer) gpuDeviceCreateBuffer(WGPUDevice self, const WGPUBufferDescriptor* descriptor) {
    return wgpuDeviceCreateBuffer(self, descriptor);
}
DllExport(WGPUBuffer) gpuDeviceCreateErrorBuffer(WGPUDevice self, const WGPUBufferDescriptor* descriptor) {
    return wgpuDeviceCreateErrorBuffer(self, descriptor);
}
DllExport(WGPUCommandEncoder) gpuDeviceCreateCommandEncoder(WGPUDevice self, const WGPUCommandEncoderDescriptor* descriptor) {
    return wgpuDeviceCreateCommandEncoder(self, descriptor);
}
DllExport(WGPUComputePipeline) gpuDeviceCreateComputePipeline(WGPUDevice self, const WGPUComputePipelineDescriptor* descriptor) {
    return wgpuDeviceCreateComputePipeline(self, descriptor);
}
DllExport(void) gpuDeviceCreateComputePipelineAsync(WGPUDevice self, const WGPUComputePipelineDescriptor* descriptor, WGPUCreateComputePipelineAsyncCallback callback, void * userdata) {
    return wgpuDeviceCreateComputePipelineAsync(self, descriptor, callback, userdata);
}
DllExport(WGPUFuture) gpuDeviceCreateComputePipelineAsyncF(WGPUDevice self, const WGPUComputePipelineDescriptor* descriptor, WGPUCreateComputePipelineAsyncCallbackInfo callbackInfo) {
    return wgpuDeviceCreateComputePipelineAsyncF(self, descriptor, callbackInfo);
}
DllExport(WGPUFuture) gpuDeviceCreateComputePipelineAsync2(WGPUDevice self, const WGPUComputePipelineDescriptor* descriptor, WGPUCreateComputePipelineAsyncCallbackInfo2 callbackInfo) {
    return wgpuDeviceCreateComputePipelineAsync2(self, descriptor, callbackInfo);
}
DllExport(WGPUExternalTexture) gpuDeviceCreateExternalTexture(WGPUDevice self, const WGPUExternalTextureDescriptor* externalTextureDescriptor) {
    return wgpuDeviceCreateExternalTexture(self, externalTextureDescriptor);
}
DllExport(WGPUExternalTexture) gpuDeviceCreateErrorExternalTexture(WGPUDevice self) {
    return wgpuDeviceCreateErrorExternalTexture(self);
}
DllExport(WGPUPipelineLayout) gpuDeviceCreatePipelineLayout(WGPUDevice self, const WGPUPipelineLayoutDescriptor* descriptor) {
    return wgpuDeviceCreatePipelineLayout(self, descriptor);
}
DllExport(WGPUQuerySet) gpuDeviceCreateQuerySet(WGPUDevice self, const WGPUQuerySetDescriptor* descriptor) {
    return wgpuDeviceCreateQuerySet(self, descriptor);
}
DllExport(void) gpuDeviceCreateRenderPipelineAsync(WGPUDevice self, const WGPURenderPipelineDescriptor* descriptor, WGPUCreateRenderPipelineAsyncCallback callback, void * userdata) {
    return wgpuDeviceCreateRenderPipelineAsync(self, descriptor, callback, userdata);
}
DllExport(WGPUFuture) gpuDeviceCreateRenderPipelineAsyncF(WGPUDevice self, const WGPURenderPipelineDescriptor* descriptor, WGPUCreateRenderPipelineAsyncCallbackInfo callbackInfo) {
    return wgpuDeviceCreateRenderPipelineAsyncF(self, descriptor, callbackInfo);
}
DllExport(WGPUFuture) gpuDeviceCreateRenderPipelineAsync2(WGPUDevice self, const WGPURenderPipelineDescriptor* descriptor, WGPUCreateRenderPipelineAsyncCallbackInfo2 callbackInfo) {
    return wgpuDeviceCreateRenderPipelineAsync2(self, descriptor, callbackInfo);
}
DllExport(WGPURenderBundleEncoder) gpuDeviceCreateRenderBundleEncoder(WGPUDevice self, const WGPURenderBundleEncoderDescriptor* descriptor) {
    return wgpuDeviceCreateRenderBundleEncoder(self, descriptor);
}
DllExport(WGPURenderPipeline) gpuDeviceCreateRenderPipeline(WGPUDevice self, const WGPURenderPipelineDescriptor* descriptor) {
    return wgpuDeviceCreateRenderPipeline(self, descriptor);
}
DllExport(WGPUSampler) gpuDeviceCreateSampler(WGPUDevice self, const WGPUSamplerDescriptor* descriptor) {
    return wgpuDeviceCreateSampler(self, descriptor);
}
DllExport(WGPUShaderModule) gpuDeviceCreateShaderModule(WGPUDevice self, const WGPUShaderModuleDescriptor* descriptor) {
    return wgpuDeviceCreateShaderModule(self, descriptor);
}
DllExport(WGPUShaderModule) gpuDeviceCreateErrorShaderModule(WGPUDevice self, const WGPUShaderModuleDescriptor* descriptor, WGPUStringView errorMessage) {
    return wgpuDeviceCreateErrorShaderModule(self, descriptor, errorMessage);
}
DllExport(WGPUTexture) gpuDeviceCreateTexture(WGPUDevice self, const WGPUTextureDescriptor* descriptor) {
    return wgpuDeviceCreateTexture(self, descriptor);
}
DllExport(WGPUSharedBufferMemory) gpuDeviceImportSharedBufferMemory(WGPUDevice self, const WGPUSharedBufferMemoryDescriptor* descriptor) {
    return wgpuDeviceImportSharedBufferMemory(self, descriptor);
}
DllExport(WGPUSharedTextureMemory) gpuDeviceImportSharedTextureMemory(WGPUDevice self, const WGPUSharedTextureMemoryDescriptor* descriptor) {
    return wgpuDeviceImportSharedTextureMemory(self, descriptor);
}
DllExport(WGPUSharedFence) gpuDeviceImportSharedFence(WGPUDevice self, const WGPUSharedFenceDescriptor* descriptor) {
    return wgpuDeviceImportSharedFence(self, descriptor);
}
DllExport(WGPUTexture) gpuDeviceCreateErrorTexture(WGPUDevice self, const WGPUTextureDescriptor* descriptor) {
    return wgpuDeviceCreateErrorTexture(self, descriptor);
}
DllExport(void) gpuDeviceDestroy(WGPUDevice self) {
    return wgpuDeviceDestroy(self);
}
DllExport(WGPUStatus) gpuDeviceGetAHardwareBufferProperties(WGPUDevice self, void * handle, WGPUAHardwareBufferProperties* properties) {
    return wgpuDeviceGetAHardwareBufferProperties(self, handle, properties);
}
DllExport(WGPUStatus) gpuDeviceGetLimits(WGPUDevice self, WGPUSupportedLimits* limits) {
    return wgpuDeviceGetLimits(self, limits);
}
DllExport(bool) gpuDeviceHasFeature(WGPUDevice self, WGPUFeatureName feature) {
    return wgpuDeviceHasFeature(self, feature);
}
DllExport(void) gpuDeviceGetFeatures(WGPUDevice self, WGPUSupportedFeatures* features) {
    return wgpuDeviceGetFeatures(self, features);
}
DllExport(WGPUStatus) gpuDeviceGetAdapterInfo(WGPUDevice self, WGPUAdapterInfo* adapterInfo) {
    return wgpuDeviceGetAdapterInfo(self, adapterInfo);
}
DllExport(WGPUAdapter) gpuDeviceGetAdapter(WGPUDevice self) {
    return wgpuDeviceGetAdapter(self);
}
DllExport(WGPUQueue) gpuDeviceGetQueue(WGPUDevice self) {
    return wgpuDeviceGetQueue(self);
}
DllExport(void) gpuDeviceInjectError(WGPUDevice self, WGPUErrorType typ, WGPUStringView message) {
    return wgpuDeviceInjectError(self, typ, message);
}
DllExport(void) gpuDeviceForceLoss(WGPUDevice self, WGPUDeviceLostReason typ, WGPUStringView message) {
    return wgpuDeviceForceLoss(self, typ, message);
}
DllExport(void) gpuDeviceTick(WGPUDevice self) {
    return wgpuDeviceTick(self);
}
DllExport(void) gpuDeviceSetUncapturedErrorCallback(WGPUDevice self, WGPUErrorCallback callback, void * userdata) {
    return wgpuDeviceSetUncapturedErrorCallback(self, callback, userdata);
}
DllExport(void) gpuDeviceSetLoggingCallback(WGPUDevice self, WGPULoggingCallback callback, void * userdata) {
    return wgpuDeviceSetLoggingCallback(self, callback, userdata);
}
DllExport(void) gpuDevicePushErrorScope(WGPUDevice self, WGPUErrorFilter filter) {
    return wgpuDevicePushErrorScope(self, filter);
}
DllExport(void) gpuDevicePopErrorScope(WGPUDevice self, WGPUErrorCallback oldCallback, void * userdata) {
    return wgpuDevicePopErrorScope(self, oldCallback, userdata);
}
DllExport(WGPUFuture) gpuDevicePopErrorScopeF(WGPUDevice self, WGPUPopErrorScopeCallbackInfo callbackInfo) {
    return wgpuDevicePopErrorScopeF(self, callbackInfo);
}
DllExport(WGPUFuture) gpuDevicePopErrorScope2(WGPUDevice self, WGPUPopErrorScopeCallbackInfo2 callbackInfo) {
    return wgpuDevicePopErrorScope2(self, callbackInfo);
}
DllExport(void) gpuDeviceSetLabel(WGPUDevice self, WGPUStringView label) {
    return wgpuDeviceSetLabel(self, label);
}
DllExport(void) gpuDeviceValidateTextureDescriptor(WGPUDevice self, const WGPUTextureDescriptor* descriptor) {
    return wgpuDeviceValidateTextureDescriptor(self, descriptor);
}
DllExport(void) gpuDeviceRelease(WGPUDevice self) {
    return wgpuDeviceRelease(self);
}
DllExport(void) gpuExternalTextureSetLabel(WGPUExternalTexture self, WGPUStringView label) {
    return wgpuExternalTextureSetLabel(self, label);
}
DllExport(void) gpuExternalTextureDestroy(WGPUExternalTexture self) {
    return wgpuExternalTextureDestroy(self);
}
DllExport(void) gpuExternalTextureExpire(WGPUExternalTexture self) {
    return wgpuExternalTextureExpire(self);
}
DllExport(void) gpuExternalTextureRefresh(WGPUExternalTexture self) {
    return wgpuExternalTextureRefresh(self);
}
DllExport(void) gpuExternalTextureRelease(WGPUExternalTexture self) {
    return wgpuExternalTextureRelease(self);
}
DllExport(void) gpuSharedBufferMemorySetLabel(WGPUSharedBufferMemory self, WGPUStringView label) {
    return wgpuSharedBufferMemorySetLabel(self, label);
}
DllExport(WGPUStatus) gpuSharedBufferMemoryGetProperties(WGPUSharedBufferMemory self, WGPUSharedBufferMemoryProperties* properties) {
    return wgpuSharedBufferMemoryGetProperties(self, properties);
}
DllExport(WGPUBuffer) gpuSharedBufferMemoryCreateBuffer(WGPUSharedBufferMemory self, const WGPUBufferDescriptor* descriptor) {
    return wgpuSharedBufferMemoryCreateBuffer(self, descriptor);
}
DllExport(WGPUStatus) gpuSharedBufferMemoryBeginAccess(WGPUSharedBufferMemory self, WGPUBuffer buffer, const WGPUSharedBufferMemoryBeginAccessDescriptor* descriptor) {
    return wgpuSharedBufferMemoryBeginAccess(self, buffer, descriptor);
}
DllExport(WGPUStatus) gpuSharedBufferMemoryEndAccess(WGPUSharedBufferMemory self, WGPUBuffer buffer, WGPUSharedBufferMemoryEndAccessState* descriptor) {
    return wgpuSharedBufferMemoryEndAccess(self, buffer, descriptor);
}
DllExport(bool) gpuSharedBufferMemoryIsDeviceLost(WGPUSharedBufferMemory self) {
    return wgpuSharedBufferMemoryIsDeviceLost(self);
}
DllExport(void) gpuSharedBufferMemoryRelease(WGPUSharedBufferMemory self) {
    return wgpuSharedBufferMemoryRelease(self);
}
DllExport(void) gpuSharedTextureMemorySetLabel(WGPUSharedTextureMemory self, WGPUStringView label) {
    return wgpuSharedTextureMemorySetLabel(self, label);
}
DllExport(WGPUStatus) gpuSharedTextureMemoryGetProperties(WGPUSharedTextureMemory self, WGPUSharedTextureMemoryProperties* properties) {
    return wgpuSharedTextureMemoryGetProperties(self, properties);
}
DllExport(WGPUTexture) gpuSharedTextureMemoryCreateTexture(WGPUSharedTextureMemory self, const WGPUTextureDescriptor* descriptor) {
    return wgpuSharedTextureMemoryCreateTexture(self, descriptor);
}
DllExport(WGPUStatus) gpuSharedTextureMemoryBeginAccess(WGPUSharedTextureMemory self, WGPUTexture texture, const WGPUSharedTextureMemoryBeginAccessDescriptor* descriptor) {
    return wgpuSharedTextureMemoryBeginAccess(self, texture, descriptor);
}
DllExport(WGPUStatus) gpuSharedTextureMemoryEndAccess(WGPUSharedTextureMemory self, WGPUTexture texture, WGPUSharedTextureMemoryEndAccessState* descriptor) {
    return wgpuSharedTextureMemoryEndAccess(self, texture, descriptor);
}
DllExport(bool) gpuSharedTextureMemoryIsDeviceLost(WGPUSharedTextureMemory self) {
    return wgpuSharedTextureMemoryIsDeviceLost(self);
}
DllExport(void) gpuSharedTextureMemoryRelease(WGPUSharedTextureMemory self) {
    return wgpuSharedTextureMemoryRelease(self);
}
DllExport(void) gpuSharedFenceExportInfo(WGPUSharedFence self, WGPUSharedFenceExportInfo* info) {
    return wgpuSharedFenceExportInfo(self, info);
}
DllExport(void) gpuSharedFenceRelease(WGPUSharedFence self) {
    return wgpuSharedFenceRelease(self);
}
DllExport(WGPUSurface) gpuInstanceCreateSurface(WGPUInstance self, const WGPUSurfaceDescriptor* descriptor) {
    return wgpuInstanceCreateSurface(self, descriptor);
}
DllExport(void) gpuInstanceProcessEvents(WGPUInstance self) {
    return wgpuInstanceProcessEvents(self);
}
typedef struct { 
   WGPUInstance Self;
   size_t FutureCount;
   WGPUFutureWaitInfo* Futures;
   uint64_t TimeoutNS;
} WGPUInstanceWaitAnyArgs;
DllExport(WGPUWaitStatus) gpuInstanceWaitAny(const WGPUInstanceWaitAnyArgs* args) {
    return wgpuInstanceWaitAny(args->Self, args->FutureCount, args->Futures, args->TimeoutNS);
}
DllExport(void) gpuInstanceRequestAdapter(WGPUInstance self, const WGPURequestAdapterOptions* options, WGPURequestAdapterCallback callback, void * userdata) {
    return wgpuInstanceRequestAdapter(self, options, callback, userdata);
}
DllExport(WGPUFuture) gpuInstanceRequestAdapterF(WGPUInstance self, const WGPURequestAdapterOptions* options, WGPURequestAdapterCallbackInfo callbackInfo) {
    return wgpuInstanceRequestAdapterF(self, options, callbackInfo);
}
DllExport(WGPUFuture) gpuInstanceRequestAdapter2(WGPUInstance self, const WGPURequestAdapterOptions* options, WGPURequestAdapterCallbackInfo2 callbackInfo) {
    return wgpuInstanceRequestAdapter2(self, options, callbackInfo);
}
DllExport(bool) gpuInstanceHasWGSLLanguageFeature(WGPUInstance self, WGPUWGSLFeatureName feature) {
    return wgpuInstanceHasWGSLLanguageFeature(self, feature);
}
DllExport(size_t) gpuInstanceEnumerateWGSLLanguageFeatures(WGPUInstance self, WGPUWGSLFeatureName* features) {
    return wgpuInstanceEnumerateWGSLLanguageFeatures(self, features);
}
DllExport(void) gpuInstanceRelease(WGPUInstance self) {
    return wgpuInstanceRelease(self);
}
DllExport(WGPUStatus) gpuGetInstanceFeatures(WGPUInstanceFeatures* features) {
    return wgpuGetInstanceFeatures(features);
}
DllExport(void) gpuPipelineLayoutSetLabel(WGPUPipelineLayout self, WGPUStringView label) {
    return wgpuPipelineLayoutSetLabel(self, label);
}
DllExport(void) gpuPipelineLayoutRelease(WGPUPipelineLayout self) {
    return wgpuPipelineLayoutRelease(self);
}
DllExport(void) gpuQuerySetSetLabel(WGPUQuerySet self, WGPUStringView label) {
    return wgpuQuerySetSetLabel(self, label);
}
DllExport(WGPUQueryType) gpuQuerySetGetType(WGPUQuerySet self) {
    return wgpuQuerySetGetType(self);
}
DllExport(uint32_t) gpuQuerySetGetCount(WGPUQuerySet self) {
    return wgpuQuerySetGetCount(self);
}
DllExport(void) gpuQuerySetDestroy(WGPUQuerySet self) {
    return wgpuQuerySetDestroy(self);
}
DllExport(void) gpuQuerySetRelease(WGPUQuerySet self) {
    return wgpuQuerySetRelease(self);
}
DllExport(void) gpuQueueSubmit(WGPUQueue self, size_t commandCount, const WGPUCommandBuffer* commands) {
    return wgpuQueueSubmit(self, commandCount, commands);
}
DllExport(void) gpuQueueOnSubmittedWorkDone(WGPUQueue self, WGPUQueueWorkDoneCallback callback, void * userdata) {
    return wgpuQueueOnSubmittedWorkDone(self, callback, userdata);
}
DllExport(WGPUFuture) gpuQueueOnSubmittedWorkDoneF(WGPUQueue self, WGPUQueueWorkDoneCallbackInfo callbackInfo) {
    return wgpuQueueOnSubmittedWorkDoneF(self, callbackInfo);
}
DllExport(WGPUFuture) gpuQueueOnSubmittedWorkDone2(WGPUQueue self, WGPUQueueWorkDoneCallbackInfo2 callbackInfo) {
    return wgpuQueueOnSubmittedWorkDone2(self, callbackInfo);
}
typedef struct { 
   WGPUQueue Self;
   WGPUBuffer Buffer;
   uint64_t BufferOffset;
   const void* Data;
   size_t Size;
} WGPUQueueWriteBufferArgs;
DllExport(void) gpuQueueWriteBuffer(const WGPUQueueWriteBufferArgs* args) {
    return wgpuQueueWriteBuffer(args->Self, args->Buffer, args->BufferOffset, args->Data, args->Size);
}
typedef struct { 
   WGPUQueue Self;
   const WGPUImageCopyTexture* Destination;
   const void* Data;
   size_t DataSize;
   const WGPUTextureDataLayout* DataLayout;
   const WGPUExtent3D* WriteSize;
} WGPUQueueWriteTextureArgs;
DllExport(void) gpuQueueWriteTexture(const WGPUQueueWriteTextureArgs* args) {
    return wgpuQueueWriteTexture(args->Self, args->Destination, args->Data, args->DataSize, args->DataLayout, args->WriteSize);
}
DllExport(void) gpuQueueCopyTextureForBrowser(WGPUQueue self, const WGPUImageCopyTexture* source, const WGPUImageCopyTexture* destination, const WGPUExtent3D* copySize, const WGPUCopyTextureForBrowserOptions* options) {
    return wgpuQueueCopyTextureForBrowser(self, source, destination, copySize, options);
}
DllExport(void) gpuQueueCopyExternalTextureForBrowser(WGPUQueue self, const WGPUImageCopyExternalTexture* source, const WGPUImageCopyTexture* destination, const WGPUExtent3D* copySize, const WGPUCopyTextureForBrowserOptions* options) {
    return wgpuQueueCopyExternalTextureForBrowser(self, source, destination, copySize, options);
}
DllExport(void) gpuQueueSetLabel(WGPUQueue self, WGPUStringView label) {
    return wgpuQueueSetLabel(self, label);
}
DllExport(void) gpuQueueRelease(WGPUQueue self) {
    return wgpuQueueRelease(self);
}
DllExport(void) gpuRenderBundleSetLabel(WGPURenderBundle self, WGPUStringView label) {
    return wgpuRenderBundleSetLabel(self, label);
}
DllExport(void) gpuRenderBundleRelease(WGPURenderBundle self) {
    return wgpuRenderBundleRelease(self);
}
DllExport(void) gpuRenderBundleEncoderSetPipeline(WGPURenderBundleEncoder self, WGPURenderPipeline pipeline) {
    return wgpuRenderBundleEncoderSetPipeline(self, pipeline);
}
DllExport(void) gpuRenderBundleEncoderSetBindGroup(WGPURenderBundleEncoder self, uint32_t groupIndex, WGPUBindGroup group, size_t dynamicOffsetCount, const uint32_t* dynamicOffsets) {
    return wgpuRenderBundleEncoderSetBindGroup(self, groupIndex, group, dynamicOffsetCount, dynamicOffsets);
}
DllExport(void) gpuRenderBundleEncoderDraw(WGPURenderBundleEncoder self, uint32_t vertexCount, uint32_t instanceCount, uint32_t firstVertex, uint32_t firstInstance) {
    return wgpuRenderBundleEncoderDraw(self, vertexCount, instanceCount, firstVertex, firstInstance);
}
typedef struct { 
   WGPURenderBundleEncoder Self;
   uint32_t IndexCount;
   uint32_t InstanceCount;
   uint32_t FirstIndex;
   int32_t BaseVertex;
   uint32_t FirstInstance;
} WGPURenderBundleEncoderDrawIndexedArgs;
DllExport(void) gpuRenderBundleEncoderDrawIndexed(const WGPURenderBundleEncoderDrawIndexedArgs* args) {
    return wgpuRenderBundleEncoderDrawIndexed(args->Self, args->IndexCount, args->InstanceCount, args->FirstIndex, args->BaseVertex, args->FirstInstance);
}
typedef struct { 
   WGPURenderBundleEncoder Self;
   WGPUBuffer IndirectBuffer;
   uint64_t IndirectOffset;
} WGPURenderBundleEncoderDrawIndirectArgs;
DllExport(void) gpuRenderBundleEncoderDrawIndirect(const WGPURenderBundleEncoderDrawIndirectArgs* args) {
    return wgpuRenderBundleEncoderDrawIndirect(args->Self, args->IndirectBuffer, args->IndirectOffset);
}
typedef struct { 
   WGPURenderBundleEncoder Self;
   WGPUBuffer IndirectBuffer;
   uint64_t IndirectOffset;
} WGPURenderBundleEncoderDrawIndexedIndirectArgs;
DllExport(void) gpuRenderBundleEncoderDrawIndexedIndirect(const WGPURenderBundleEncoderDrawIndexedIndirectArgs* args) {
    return wgpuRenderBundleEncoderDrawIndexedIndirect(args->Self, args->IndirectBuffer, args->IndirectOffset);
}
DllExport(void) gpuRenderBundleEncoderInsertDebugMarker(WGPURenderBundleEncoder self, WGPUStringView markerLabel) {
    return wgpuRenderBundleEncoderInsertDebugMarker(self, markerLabel);
}
DllExport(void) gpuRenderBundleEncoderPopDebugGroup(WGPURenderBundleEncoder self) {
    return wgpuRenderBundleEncoderPopDebugGroup(self);
}
DllExport(void) gpuRenderBundleEncoderPushDebugGroup(WGPURenderBundleEncoder self, WGPUStringView groupLabel) {
    return wgpuRenderBundleEncoderPushDebugGroup(self, groupLabel);
}
typedef struct { 
   WGPURenderBundleEncoder Self;
   uint32_t Slot;
   WGPUBuffer Buffer;
   uint64_t Offset;
   uint64_t Size;
} WGPURenderBundleEncoderSetVertexBufferArgs;
DllExport(void) gpuRenderBundleEncoderSetVertexBuffer(const WGPURenderBundleEncoderSetVertexBufferArgs* args) {
    return wgpuRenderBundleEncoderSetVertexBuffer(args->Self, args->Slot, args->Buffer, args->Offset, args->Size);
}
typedef struct { 
   WGPURenderBundleEncoder Self;
   WGPUBuffer Buffer;
   WGPUIndexFormat Format;
   uint64_t Offset;
   uint64_t Size;
} WGPURenderBundleEncoderSetIndexBufferArgs;
DllExport(void) gpuRenderBundleEncoderSetIndexBuffer(const WGPURenderBundleEncoderSetIndexBufferArgs* args) {
    return wgpuRenderBundleEncoderSetIndexBuffer(args->Self, args->Buffer, args->Format, args->Offset, args->Size);
}
DllExport(WGPURenderBundle) gpuRenderBundleEncoderFinish(WGPURenderBundleEncoder self, const WGPURenderBundleDescriptor* descriptor) {
    return wgpuRenderBundleEncoderFinish(self, descriptor);
}
DllExport(void) gpuRenderBundleEncoderSetLabel(WGPURenderBundleEncoder self, WGPUStringView label) {
    return wgpuRenderBundleEncoderSetLabel(self, label);
}
DllExport(void) gpuRenderBundleEncoderRelease(WGPURenderBundleEncoder self) {
    return wgpuRenderBundleEncoderRelease(self);
}
DllExport(void) gpuRenderPassEncoderSetPipeline(WGPURenderPassEncoder self, WGPURenderPipeline pipeline) {
    return wgpuRenderPassEncoderSetPipeline(self, pipeline);
}
DllExport(void) gpuRenderPassEncoderSetBindGroup(WGPURenderPassEncoder self, uint32_t groupIndex, WGPUBindGroup group, size_t dynamicOffsetCount, const uint32_t* dynamicOffsets) {
    return wgpuRenderPassEncoderSetBindGroup(self, groupIndex, group, dynamicOffsetCount, dynamicOffsets);
}
DllExport(void) gpuRenderPassEncoderDraw(WGPURenderPassEncoder self, uint32_t vertexCount, uint32_t instanceCount, uint32_t firstVertex, uint32_t firstInstance) {
    return wgpuRenderPassEncoderDraw(self, vertexCount, instanceCount, firstVertex, firstInstance);
}
typedef struct { 
   WGPURenderPassEncoder Self;
   uint32_t IndexCount;
   uint32_t InstanceCount;
   uint32_t FirstIndex;
   int32_t BaseVertex;
   uint32_t FirstInstance;
} WGPURenderPassEncoderDrawIndexedArgs;
DllExport(void) gpuRenderPassEncoderDrawIndexed(const WGPURenderPassEncoderDrawIndexedArgs* args) {
    return wgpuRenderPassEncoderDrawIndexed(args->Self, args->IndexCount, args->InstanceCount, args->FirstIndex, args->BaseVertex, args->FirstInstance);
}
typedef struct { 
   WGPURenderPassEncoder Self;
   WGPUBuffer IndirectBuffer;
   uint64_t IndirectOffset;
} WGPURenderPassEncoderDrawIndirectArgs;
DllExport(void) gpuRenderPassEncoderDrawIndirect(const WGPURenderPassEncoderDrawIndirectArgs* args) {
    return wgpuRenderPassEncoderDrawIndirect(args->Self, args->IndirectBuffer, args->IndirectOffset);
}
typedef struct { 
   WGPURenderPassEncoder Self;
   WGPUBuffer IndirectBuffer;
   uint64_t IndirectOffset;
} WGPURenderPassEncoderDrawIndexedIndirectArgs;
DllExport(void) gpuRenderPassEncoderDrawIndexedIndirect(const WGPURenderPassEncoderDrawIndexedIndirectArgs* args) {
    return wgpuRenderPassEncoderDrawIndexedIndirect(args->Self, args->IndirectBuffer, args->IndirectOffset);
}
typedef struct { 
   WGPURenderPassEncoder Self;
   WGPUBuffer IndirectBuffer;
   uint64_t IndirectOffset;
   uint32_t MaxDrawCount;
   WGPUBuffer DrawCountBuffer;
   uint64_t DrawCountBufferOffset;
} WGPURenderPassEncoderMultiDrawIndirectArgs;
DllExport(void) gpuRenderPassEncoderMultiDrawIndirect(const WGPURenderPassEncoderMultiDrawIndirectArgs* args) {
    return wgpuRenderPassEncoderMultiDrawIndirect(args->Self, args->IndirectBuffer, args->IndirectOffset, args->MaxDrawCount, args->DrawCountBuffer, args->DrawCountBufferOffset);
}
typedef struct { 
   WGPURenderPassEncoder Self;
   WGPUBuffer IndirectBuffer;
   uint64_t IndirectOffset;
   uint32_t MaxDrawCount;
   WGPUBuffer DrawCountBuffer;
   uint64_t DrawCountBufferOffset;
} WGPURenderPassEncoderMultiDrawIndexedIndirectArgs;
DllExport(void) gpuRenderPassEncoderMultiDrawIndexedIndirect(const WGPURenderPassEncoderMultiDrawIndexedIndirectArgs* args) {
    return wgpuRenderPassEncoderMultiDrawIndexedIndirect(args->Self, args->IndirectBuffer, args->IndirectOffset, args->MaxDrawCount, args->DrawCountBuffer, args->DrawCountBufferOffset);
}
DllExport(void) gpuRenderPassEncoderExecuteBundles(WGPURenderPassEncoder self, size_t bundleCount, const WGPURenderBundle* bundles) {
    return wgpuRenderPassEncoderExecuteBundles(self, bundleCount, bundles);
}
DllExport(void) gpuRenderPassEncoderInsertDebugMarker(WGPURenderPassEncoder self, WGPUStringView markerLabel) {
    return wgpuRenderPassEncoderInsertDebugMarker(self, markerLabel);
}
DllExport(void) gpuRenderPassEncoderPopDebugGroup(WGPURenderPassEncoder self) {
    return wgpuRenderPassEncoderPopDebugGroup(self);
}
DllExport(void) gpuRenderPassEncoderPushDebugGroup(WGPURenderPassEncoder self, WGPUStringView groupLabel) {
    return wgpuRenderPassEncoderPushDebugGroup(self, groupLabel);
}
DllExport(void) gpuRenderPassEncoderSetStencilReference(WGPURenderPassEncoder self, uint32_t reference) {
    return wgpuRenderPassEncoderSetStencilReference(self, reference);
}
DllExport(void) gpuRenderPassEncoderSetBlendConstant(WGPURenderPassEncoder self, const WGPUColor* color) {
    return wgpuRenderPassEncoderSetBlendConstant(self, color);
}
typedef struct { 
   WGPURenderPassEncoder Self;
   float X;
   float Y;
   float Width;
   float Height;
   float MinDepth;
   float MaxDepth;
} WGPURenderPassEncoderSetViewportArgs;
DllExport(void) gpuRenderPassEncoderSetViewport(const WGPURenderPassEncoderSetViewportArgs* args) {
    return wgpuRenderPassEncoderSetViewport(args->Self, args->X, args->Y, args->Width, args->Height, args->MinDepth, args->MaxDepth);
}
DllExport(void) gpuRenderPassEncoderSetScissorRect(WGPURenderPassEncoder self, uint32_t x, uint32_t y, uint32_t width, uint32_t height) {
    return wgpuRenderPassEncoderSetScissorRect(self, x, y, width, height);
}
typedef struct { 
   WGPURenderPassEncoder Self;
   uint32_t Slot;
   WGPUBuffer Buffer;
   uint64_t Offset;
   uint64_t Size;
} WGPURenderPassEncoderSetVertexBufferArgs;
DllExport(void) gpuRenderPassEncoderSetVertexBuffer(const WGPURenderPassEncoderSetVertexBufferArgs* args) {
    return wgpuRenderPassEncoderSetVertexBuffer(args->Self, args->Slot, args->Buffer, args->Offset, args->Size);
}
typedef struct { 
   WGPURenderPassEncoder Self;
   WGPUBuffer Buffer;
   WGPUIndexFormat Format;
   uint64_t Offset;
   uint64_t Size;
} WGPURenderPassEncoderSetIndexBufferArgs;
DllExport(void) gpuRenderPassEncoderSetIndexBuffer(const WGPURenderPassEncoderSetIndexBufferArgs* args) {
    return wgpuRenderPassEncoderSetIndexBuffer(args->Self, args->Buffer, args->Format, args->Offset, args->Size);
}
DllExport(void) gpuRenderPassEncoderBeginOcclusionQuery(WGPURenderPassEncoder self, uint32_t queryIndex) {
    return wgpuRenderPassEncoderBeginOcclusionQuery(self, queryIndex);
}
DllExport(void) gpuRenderPassEncoderEndOcclusionQuery(WGPURenderPassEncoder self) {
    return wgpuRenderPassEncoderEndOcclusionQuery(self);
}
DllExport(void) gpuRenderPassEncoderWriteTimestamp(WGPURenderPassEncoder self, WGPUQuerySet querySet, uint32_t queryIndex) {
    return wgpuRenderPassEncoderWriteTimestamp(self, querySet, queryIndex);
}
DllExport(void) gpuRenderPassEncoderPixelLocalStorageBarrier(WGPURenderPassEncoder self) {
    return wgpuRenderPassEncoderPixelLocalStorageBarrier(self);
}
DllExport(void) gpuRenderPassEncoderEnd(WGPURenderPassEncoder self) {
    return wgpuRenderPassEncoderEnd(self);
}
DllExport(void) gpuRenderPassEncoderSetLabel(WGPURenderPassEncoder self, WGPUStringView label) {
    return wgpuRenderPassEncoderSetLabel(self, label);
}
DllExport(void) gpuRenderPassEncoderRelease(WGPURenderPassEncoder self) {
    return wgpuRenderPassEncoderRelease(self);
}
DllExport(WGPUBindGroupLayout) gpuRenderPipelineGetBindGroupLayout(WGPURenderPipeline self, uint32_t groupIndex) {
    return wgpuRenderPipelineGetBindGroupLayout(self, groupIndex);
}
DllExport(void) gpuRenderPipelineSetLabel(WGPURenderPipeline self, WGPUStringView label) {
    return wgpuRenderPipelineSetLabel(self, label);
}
DllExport(void) gpuRenderPipelineRelease(WGPURenderPipeline self) {
    return wgpuRenderPipelineRelease(self);
}
DllExport(void) gpuSamplerSetLabel(WGPUSampler self, WGPUStringView label) {
    return wgpuSamplerSetLabel(self, label);
}
DllExport(void) gpuSamplerRelease(WGPUSampler self) {
    return wgpuSamplerRelease(self);
}
DllExport(void) gpuShaderModuleGetCompilationInfo(WGPUShaderModule self, WGPUCompilationInfoCallback callback, void * userdata) {
    return wgpuShaderModuleGetCompilationInfo(self, callback, userdata);
}
DllExport(WGPUFuture) gpuShaderModuleGetCompilationInfoF(WGPUShaderModule self, WGPUCompilationInfoCallbackInfo callbackInfo) {
    return wgpuShaderModuleGetCompilationInfoF(self, callbackInfo);
}
DllExport(WGPUFuture) gpuShaderModuleGetCompilationInfo2(WGPUShaderModule self, WGPUCompilationInfoCallbackInfo2 callbackInfo) {
    return wgpuShaderModuleGetCompilationInfo2(self, callbackInfo);
}
DllExport(void) gpuShaderModuleSetLabel(WGPUShaderModule self, WGPUStringView label) {
    return wgpuShaderModuleSetLabel(self, label);
}
DllExport(void) gpuShaderModuleRelease(WGPUShaderModule self) {
    return wgpuShaderModuleRelease(self);
}
DllExport(void) gpuSurfaceConfigure(WGPUSurface self, const WGPUSurfaceConfiguration* config) {
    return wgpuSurfaceConfigure(self, config);
}
DllExport(WGPUStatus) gpuSurfaceGetCapabilities(WGPUSurface self, WGPUAdapter adapter, WGPUSurfaceCapabilities* capabilities) {
    return wgpuSurfaceGetCapabilities(self, adapter, capabilities);
}
DllExport(void) gpuSurfaceGetCurrentTexture(WGPUSurface self, WGPUSurfaceTexture* surfaceTexture) {
    return wgpuSurfaceGetCurrentTexture(self, surfaceTexture);
}
DllExport(void) gpuSurfacePresent(WGPUSurface self) {
    return wgpuSurfacePresent(self);
}
DllExport(void) gpuSurfaceUnconfigure(WGPUSurface self) {
    return wgpuSurfaceUnconfigure(self);
}
DllExport(void) gpuSurfaceSetLabel(WGPUSurface self, WGPUStringView label) {
    return wgpuSurfaceSetLabel(self, label);
}
DllExport(void) gpuSurfaceRelease(WGPUSurface self) {
    return wgpuSurfaceRelease(self);
}
DllExport(WGPUTextureView) gpuTextureCreateView(WGPUTexture self, const WGPUTextureViewDescriptor* descriptor) {
    return wgpuTextureCreateView(self, descriptor);
}
DllExport(WGPUTextureView) gpuTextureCreateErrorView(WGPUTexture self, const WGPUTextureViewDescriptor* descriptor) {
    return wgpuTextureCreateErrorView(self, descriptor);
}
DllExport(void) gpuTextureSetLabel(WGPUTexture self, WGPUStringView label) {
    return wgpuTextureSetLabel(self, label);
}
DllExport(uint32_t) gpuTextureGetWidth(WGPUTexture self) {
    return wgpuTextureGetWidth(self);
}
DllExport(uint32_t) gpuTextureGetHeight(WGPUTexture self) {
    return wgpuTextureGetHeight(self);
}
DllExport(uint32_t) gpuTextureGetDepthOrArrayLayers(WGPUTexture self) {
    return wgpuTextureGetDepthOrArrayLayers(self);
}
DllExport(uint32_t) gpuTextureGetMipLevelCount(WGPUTexture self) {
    return wgpuTextureGetMipLevelCount(self);
}
DllExport(uint32_t) gpuTextureGetSampleCount(WGPUTexture self) {
    return wgpuTextureGetSampleCount(self);
}
DllExport(WGPUTextureDimension) gpuTextureGetDimension(WGPUTexture self) {
    return wgpuTextureGetDimension(self);
}
DllExport(WGPUTextureFormat) gpuTextureGetFormat(WGPUTexture self) {
    return wgpuTextureGetFormat(self);
}
DllExport(WGPUTextureUsage) gpuTextureGetUsage(WGPUTexture self) {
    return wgpuTextureGetUsage(self);
}
DllExport(void) gpuTextureDestroy(WGPUTexture self) {
    return wgpuTextureDestroy(self);
}
DllExport(void) gpuTextureRelease(WGPUTexture self) {
    return wgpuTextureRelease(self);
}
DllExport(void) gpuTextureViewSetLabel(WGPUTextureView self, WGPUStringView label) {
    return wgpuTextureViewSetLabel(self, label);
}
DllExport(void) gpuTextureViewRelease(WGPUTextureView self) {
    return wgpuTextureViewRelease(self);
}