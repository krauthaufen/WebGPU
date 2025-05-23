// BSD 3-Clause License
//
// Copyright (c) 2019, "WebGPU native" developers
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
// 1. Redistributions of source code must retain the above copyright notice, this
//    list of conditions and the following disclaimer.
//
// 2. Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
//
// 3. Neither the name of the copyright holder nor the names of its
//    contributors may be used to endorse or promote products derived from
//    this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.


#ifndef WEBGPU_H_
#define WEBGPU_H_

#define WGPU_BREAKING_CHANGE_STRING_VIEW_LABELS
#define WGPU_BREAKING_CHANGE_STRING_VIEW_OUTPUT_STRUCTS
#define WGPU_BREAKING_CHANGE_STRING_VIEW_CALLBACKS

#if defined(WGPU_SHARED_LIBRARY)
#    if defined(_WIN32)
#        if defined(WGPU_IMPLEMENTATION)
#            define WGPU_EXPORT __declspec(dllexport)
#        else
#            define WGPU_EXPORT __declspec(dllimport)
#        endif
#    else  // defined(_WIN32)
#        if defined(WGPU_IMPLEMENTATION)
#            define WGPU_EXPORT __attribute__((visibility("default")))
#        else
#            define WGPU_EXPORT
#        endif
#    endif  // defined(_WIN32)
#else       // defined(WGPU_SHARED_LIBRARY)
#    define WGPU_EXPORT
#endif  // defined(WGPU_SHARED_LIBRARY)

#if !defined(WGPU_OBJECT_ATTRIBUTE)
#define WGPU_OBJECT_ATTRIBUTE
#endif
#if !defined(WGPU_ENUM_ATTRIBUTE)
#define WGPU_ENUM_ATTRIBUTE
#endif
#if !defined(WGPU_STRUCTURE_ATTRIBUTE)
#define WGPU_STRUCTURE_ATTRIBUTE
#endif
#if !defined(WGPU_FUNCTION_ATTRIBUTE)
#define WGPU_FUNCTION_ATTRIBUTE
#endif
#if !defined(WGPU_NULLABLE)
#define WGPU_NULLABLE
#endif

#define WGPU_BREAKING_CHANGE_DROP_DESCRIPTOR

#include <stdint.h>
#include <stddef.h>

#if defined(__cplusplus)
#  if __cplusplus >= 201103L
#    define WGPU_MAKE_INIT_STRUCT(type, value) (type value)
#  else
#    define WGPU_MAKE_INIT_STRUCT(type, value) value
#  endif
#elif defined(__STDC_VERSION__) && __STDC_VERSION__ >= 199901L
#  define WGPU_MAKE_INIT_STRUCT(type, value) ((type) value)
#else
#  define WGPU_MAKE_INIT_STRUCT(type, value) value
#endif

#define WGPU_ARRAY_LAYER_COUNT_UNDEFINED UINT32_MAX
#define WGPU_COPY_STRIDE_UNDEFINED UINT32_MAX
#define WGPU_DEPTH_SLICE_UNDEFINED UINT32_MAX
#define WGPU_LIMIT_U32_UNDEFINED UINT32_MAX
#define WGPU_LIMIT_U64_UNDEFINED UINT64_MAX
#define WGPU_MIP_LEVEL_COUNT_UNDEFINED UINT32_MAX
#define WGPU_QUERY_SET_INDEX_UNDEFINED UINT32_MAX
#define WGPU_STRLEN SIZE_MAX
#define WGPU_WHOLE_MAP_SIZE SIZE_MAX
#define WGPU_WHOLE_SIZE UINT64_MAX

typedef uint64_t WGPUFlags;
typedef uint32_t WGPUBool;

typedef struct WGPUAdapterImpl* WGPUAdapter WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUBindGroupImpl* WGPUBindGroup WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUBindGroupLayoutImpl* WGPUBindGroupLayout WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUBufferImpl* WGPUBuffer WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUCommandBufferImpl* WGPUCommandBuffer WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUCommandEncoderImpl* WGPUCommandEncoder WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUComputePassEncoderImpl* WGPUComputePassEncoder WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUComputePipelineImpl* WGPUComputePipeline WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUDeviceImpl* WGPUDevice WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUInstanceImpl* WGPUInstance WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUPipelineLayoutImpl* WGPUPipelineLayout WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUQuerySetImpl* WGPUQuerySet WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUQueueImpl* WGPUQueue WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPURenderBundleImpl* WGPURenderBundle WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPURenderBundleEncoderImpl* WGPURenderBundleEncoder WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPURenderPassEncoderImpl* WGPURenderPassEncoder WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPURenderPipelineImpl* WGPURenderPipeline WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUSamplerImpl* WGPUSampler WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUShaderModuleImpl* WGPUShaderModule WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUSurfaceImpl* WGPUSurface WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUTextureImpl* WGPUTexture WGPU_OBJECT_ATTRIBUTE;
typedef struct WGPUTextureViewImpl* WGPUTextureView WGPU_OBJECT_ATTRIBUTE;

// Structure forward declarations
struct WGPUINTERNAL__HAVE_EMDAWNWEBGPU_HEADER;
struct WGPUBindGroupEntry;
struct WGPUBlendComponent;
struct WGPUBufferBindingLayout;
struct WGPUBufferMapCallbackInfo;
struct WGPUColor;
struct WGPUCompilationInfoCallbackInfo;
struct WGPUComputePassTimestampWrites;
struct WGPUCreateComputePipelineAsyncCallbackInfo;
struct WGPUCreateRenderPipelineAsyncCallbackInfo;
struct WGPUDeviceLostCallbackInfo;
struct WGPUExtent3D;
struct WGPUFuture;
struct WGPUInstanceFeatures;
struct WGPULimits;
struct WGPUMultisampleState;
struct WGPUOrigin3D;
struct WGPUPopErrorScopeCallbackInfo;
struct WGPUPrimitiveState;
struct WGPUQueueWorkDoneCallbackInfo;
struct WGPURenderPassDepthStencilAttachment;
struct WGPURenderPassMaxDrawCount;
struct WGPURenderPassTimestampWrites;
struct WGPURequestAdapterCallbackInfo;
struct WGPURequestAdapterOptions;
struct WGPURequestDeviceCallbackInfo;
struct WGPUSamplerBindingLayout;
struct WGPUShaderSourceSPIRV;
struct WGPUStencilFaceState;
struct WGPUStorageTextureBindingLayout;
struct WGPUStringView;
struct WGPUSupportedFeatures;
struct WGPUSurfaceCapabilities;
struct WGPUSurfaceConfiguration;
struct WGPUSurfaceTexture;
struct WGPUTextureBindingLayout;
struct WGPUTextureBindingViewDimensionDescriptor;
struct WGPUTextureDataLayout;
struct WGPUUncapturedErrorCallbackInfo;
struct WGPUVertexAttribute;
struct WGPUAdapterInfo;
struct WGPUBindGroupDescriptor;
struct WGPUBindGroupLayoutEntry;
struct WGPUBlendState;
struct WGPUBufferDescriptor;
struct WGPUCommandBufferDescriptor;
struct WGPUCommandEncoderDescriptor;
struct WGPUCompilationMessage;
struct WGPUComputePassDescriptor;
struct WGPUConstantEntry;
struct WGPUDepthStencilState;
struct WGPUFutureWaitInfo;
struct WGPUImageCopyBuffer;
struct WGPUImageCopyTexture;
struct WGPUInstanceDescriptor;
struct WGPUPipelineLayoutDescriptor;
struct WGPUQuerySetDescriptor;
struct WGPUQueueDescriptor;
struct WGPURenderBundleDescriptor;
struct WGPURenderBundleEncoderDescriptor;
struct WGPURenderPassColorAttachment;
struct WGPURequiredLimits;
struct WGPUSamplerDescriptor;
struct WGPUShaderModuleDescriptor;
struct WGPUShaderSourceWGSL;
struct WGPUSupportedLimits;
struct WGPUSurfaceDescriptor;
struct WGPUSurfaceSourceCanvasHTMLSelector_Emscripten;
struct WGPUTextureDescriptor;
struct WGPUTextureViewDescriptor;
struct WGPUVertexBufferLayout;
struct WGPUBindGroupLayoutDescriptor;
struct WGPUColorTargetState;
struct WGPUCompilationInfo;
struct WGPUDeviceDescriptor;
struct WGPUProgrammableStageDescriptor;
struct WGPURenderPassDescriptor;
struct WGPUVertexState;
struct WGPUComputePipelineDescriptor;
struct WGPUFragmentState;
struct WGPURenderPipelineDescriptor;

typedef enum WGPUWGSLFeatureName {
    WGPUWGSLFeatureName_ReadonlyAndReadwriteStorageTextures = 0x00000001,
    WGPUWGSLFeatureName_Packed4x8IntegerDotProduct = 0x00000002,
    WGPUWGSLFeatureName_UnrestrictedPointerParameters = 0x00000003,
    WGPUWGSLFeatureName_PointerCompositeAccess = 0x00000004,
    WGPUWGSLFeatureName_Force32 = 0x7FFFFFFF
} WGPUWGSLFeatureName WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUAdapterType {
    WGPUAdapterType_DiscreteGPU = 0x00000001,
    WGPUAdapterType_IntegratedGPU = 0x00000002,
    WGPUAdapterType_CPU = 0x00000003,
    WGPUAdapterType_Unknown = 0x00000004,
    WGPUAdapterType_Force32 = 0x7FFFFFFF
} WGPUAdapterType WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUAddressMode {
    WGPUAddressMode_Undefined = 0x00000000,
    WGPUAddressMode_ClampToEdge = 0x00000001,
    WGPUAddressMode_Repeat = 0x00000002,
    WGPUAddressMode_MirrorRepeat = 0x00000003,
    WGPUAddressMode_Force32 = 0x7FFFFFFF
} WGPUAddressMode WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUBackendType {
    WGPUBackendType_Undefined = 0x00000000,
    WGPUBackendType_Null = 0x00000001,
    WGPUBackendType_WebGPU = 0x00000002,
    WGPUBackendType_D3D11 = 0x00000003,
    WGPUBackendType_D3D12 = 0x00000004,
    WGPUBackendType_Metal = 0x00000005,
    WGPUBackendType_Vulkan = 0x00000006,
    WGPUBackendType_OpenGL = 0x00000007,
    WGPUBackendType_OpenGLES = 0x00000008,
    WGPUBackendType_Force32 = 0x7FFFFFFF
} WGPUBackendType WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUBlendFactor {
    WGPUBlendFactor_Undefined = 0x00000000,
    WGPUBlendFactor_Zero = 0x00000001,
    WGPUBlendFactor_One = 0x00000002,
    WGPUBlendFactor_Src = 0x00000003,
    WGPUBlendFactor_OneMinusSrc = 0x00000004,
    WGPUBlendFactor_SrcAlpha = 0x00000005,
    WGPUBlendFactor_OneMinusSrcAlpha = 0x00000006,
    WGPUBlendFactor_Dst = 0x00000007,
    WGPUBlendFactor_OneMinusDst = 0x00000008,
    WGPUBlendFactor_DstAlpha = 0x00000009,
    WGPUBlendFactor_OneMinusDstAlpha = 0x0000000A,
    WGPUBlendFactor_SrcAlphaSaturated = 0x0000000B,
    WGPUBlendFactor_Constant = 0x0000000C,
    WGPUBlendFactor_OneMinusConstant = 0x0000000D,
    WGPUBlendFactor_Src1 = 0x0000000E,
    WGPUBlendFactor_OneMinusSrc1 = 0x0000000F,
    WGPUBlendFactor_Src1Alpha = 0x00000010,
    WGPUBlendFactor_OneMinusSrc1Alpha = 0x00000011,
    WGPUBlendFactor_Force32 = 0x7FFFFFFF
} WGPUBlendFactor WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUBlendOperation {
    WGPUBlendOperation_Undefined = 0x00000000,
    WGPUBlendOperation_Add = 0x00000001,
    WGPUBlendOperation_Subtract = 0x00000002,
    WGPUBlendOperation_ReverseSubtract = 0x00000003,
    WGPUBlendOperation_Min = 0x00000004,
    WGPUBlendOperation_Max = 0x00000005,
    WGPUBlendOperation_Force32 = 0x7FFFFFFF
} WGPUBlendOperation WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUBufferBindingType {
    WGPUBufferBindingType_Undefined = 0x00000000,
    WGPUBufferBindingType_Uniform = 0x00000001,
    WGPUBufferBindingType_Storage = 0x00000002,
    WGPUBufferBindingType_ReadOnlyStorage = 0x00000003,
    WGPUBufferBindingType_Force32 = 0x7FFFFFFF
} WGPUBufferBindingType WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUBufferMapAsyncStatus {
    WGPUBufferMapAsyncStatus_Success = 0x00000001,
    WGPUBufferMapAsyncStatus_InstanceDropped = 0x00000002,
    WGPUBufferMapAsyncStatus_ValidationError = 0x00000003,
    WGPUBufferMapAsyncStatus_Unknown = 0x00000004,
    WGPUBufferMapAsyncStatus_DeviceLost = 0x00000005,
    WGPUBufferMapAsyncStatus_DestroyedBeforeCallback = 0x00000006,
    WGPUBufferMapAsyncStatus_UnmappedBeforeCallback = 0x00000007,
    WGPUBufferMapAsyncStatus_MappingAlreadyPending = 0x00000008,
    WGPUBufferMapAsyncStatus_OffsetOutOfRange = 0x00000009,
    WGPUBufferMapAsyncStatus_SizeOutOfRange = 0x0000000A,
    WGPUBufferMapAsyncStatus_Force32 = 0x7FFFFFFF
} WGPUBufferMapAsyncStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUBufferMapState {
    WGPUBufferMapState_Unmapped = 0x00000001,
    WGPUBufferMapState_Pending = 0x00000002,
    WGPUBufferMapState_Mapped = 0x00000003,
    WGPUBufferMapState_Force32 = 0x7FFFFFFF
} WGPUBufferMapState WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUCallbackMode {
    WGPUCallbackMode_WaitAnyOnly = 0x00000001,
    WGPUCallbackMode_AllowProcessEvents = 0x00000002,
    WGPUCallbackMode_AllowSpontaneous = 0x00000003,
    WGPUCallbackMode_Force32 = 0x7FFFFFFF
} WGPUCallbackMode WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUCompareFunction {
    WGPUCompareFunction_Undefined = 0x00000000,
    WGPUCompareFunction_Never = 0x00000001,
    WGPUCompareFunction_Less = 0x00000002,
    WGPUCompareFunction_Equal = 0x00000003,
    WGPUCompareFunction_LessEqual = 0x00000004,
    WGPUCompareFunction_Greater = 0x00000005,
    WGPUCompareFunction_NotEqual = 0x00000006,
    WGPUCompareFunction_GreaterEqual = 0x00000007,
    WGPUCompareFunction_Always = 0x00000008,
    WGPUCompareFunction_Force32 = 0x7FFFFFFF
} WGPUCompareFunction WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUCompilationInfoRequestStatus {
    WGPUCompilationInfoRequestStatus_Success = 0x00000001,
    WGPUCompilationInfoRequestStatus_InstanceDropped = 0x00000002,
    WGPUCompilationInfoRequestStatus_Error = 0x00000003,
    WGPUCompilationInfoRequestStatus_DeviceLost = 0x00000004,
    WGPUCompilationInfoRequestStatus_Unknown = 0x00000005,
    WGPUCompilationInfoRequestStatus_Force32 = 0x7FFFFFFF
} WGPUCompilationInfoRequestStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUCompilationMessageType {
    WGPUCompilationMessageType_Error = 0x00000001,
    WGPUCompilationMessageType_Warning = 0x00000002,
    WGPUCompilationMessageType_Info = 0x00000003,
    WGPUCompilationMessageType_Force32 = 0x7FFFFFFF
} WGPUCompilationMessageType WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUCompositeAlphaMode {
    WGPUCompositeAlphaMode_Auto = 0x00000000,
    WGPUCompositeAlphaMode_Opaque = 0x00000001,
    WGPUCompositeAlphaMode_Premultiplied = 0x00000002,
    WGPUCompositeAlphaMode_Unpremultiplied = 0x00000003,
    WGPUCompositeAlphaMode_Inherit = 0x00000004,
    WGPUCompositeAlphaMode_Force32 = 0x7FFFFFFF
} WGPUCompositeAlphaMode WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUCreatePipelineAsyncStatus {
    WGPUCreatePipelineAsyncStatus_Success = 0x00000001,
    WGPUCreatePipelineAsyncStatus_InstanceDropped = 0x00000002,
    WGPUCreatePipelineAsyncStatus_ValidationError = 0x00000003,
    WGPUCreatePipelineAsyncStatus_InternalError = 0x00000004,
    WGPUCreatePipelineAsyncStatus_DeviceLost = 0x00000005,
    WGPUCreatePipelineAsyncStatus_DeviceDestroyed = 0x00000006,
    WGPUCreatePipelineAsyncStatus_Unknown = 0x00000007,
    WGPUCreatePipelineAsyncStatus_Force32 = 0x7FFFFFFF
} WGPUCreatePipelineAsyncStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUCullMode {
    WGPUCullMode_Undefined = 0x00000000,
    WGPUCullMode_None = 0x00000001,
    WGPUCullMode_Front = 0x00000002,
    WGPUCullMode_Back = 0x00000003,
    WGPUCullMode_Force32 = 0x7FFFFFFF
} WGPUCullMode WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUDeviceLostReason {
    WGPUDeviceLostReason_Unknown = 0x00000001,
    WGPUDeviceLostReason_Destroyed = 0x00000002,
    WGPUDeviceLostReason_InstanceDropped = 0x00000003,
    WGPUDeviceLostReason_FailedCreation = 0x00000004,
    WGPUDeviceLostReason_Force32 = 0x7FFFFFFF
} WGPUDeviceLostReason WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUErrorFilter {
    WGPUErrorFilter_Validation = 0x00000001,
    WGPUErrorFilter_OutOfMemory = 0x00000002,
    WGPUErrorFilter_Internal = 0x00000003,
    WGPUErrorFilter_Force32 = 0x7FFFFFFF
} WGPUErrorFilter WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUErrorType {
    WGPUErrorType_NoError = 0x00000001,
    WGPUErrorType_Validation = 0x00000002,
    WGPUErrorType_OutOfMemory = 0x00000003,
    WGPUErrorType_Internal = 0x00000004,
    WGPUErrorType_Unknown = 0x00000005,
    WGPUErrorType_DeviceLost = 0x00000006,
    WGPUErrorType_Force32 = 0x7FFFFFFF
} WGPUErrorType WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUFeatureName {
    WGPUFeatureName_DepthClipControl = 0x00000001,
    WGPUFeatureName_Depth32FloatStencil8 = 0x00000002,
    WGPUFeatureName_TimestampQuery = 0x00000003,
    WGPUFeatureName_TextureCompressionBC = 0x00000004,
    WGPUFeatureName_TextureCompressionETC2 = 0x00000005,
    WGPUFeatureName_TextureCompressionASTC = 0x00000006,
    WGPUFeatureName_IndirectFirstInstance = 0x00000007,
    WGPUFeatureName_ShaderF16 = 0x00000008,
    WGPUFeatureName_RG11B10UfloatRenderable = 0x00000009,
    WGPUFeatureName_BGRA8UnormStorage = 0x0000000A,
    WGPUFeatureName_Float32Filterable = 0x0000000B,
    WGPUFeatureName_Float32Blendable = 0x0000000C,
    WGPUFeatureName_Subgroups = 0x0000000D,
    WGPUFeatureName_SubgroupsF16 = 0x0000000E,
    WGPUFeatureName_Force32 = 0x7FFFFFFF
} WGPUFeatureName WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUFilterMode {
    WGPUFilterMode_Undefined = 0x00000000,
    WGPUFilterMode_Nearest = 0x00000001,
    WGPUFilterMode_Linear = 0x00000002,
    WGPUFilterMode_Force32 = 0x7FFFFFFF
} WGPUFilterMode WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUFrontFace {
    WGPUFrontFace_Undefined = 0x00000000,
    WGPUFrontFace_CCW = 0x00000001,
    WGPUFrontFace_CW = 0x00000002,
    WGPUFrontFace_Force32 = 0x7FFFFFFF
} WGPUFrontFace WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUIndexFormat {
    WGPUIndexFormat_Undefined = 0x00000000,
    WGPUIndexFormat_Uint16 = 0x00000001,
    WGPUIndexFormat_Uint32 = 0x00000002,
    WGPUIndexFormat_Force32 = 0x7FFFFFFF
} WGPUIndexFormat WGPU_ENUM_ATTRIBUTE;
typedef enum WGPULoadOp {
    WGPULoadOp_Undefined = 0x00000000,
    WGPULoadOp_Load = 0x00000001,
    WGPULoadOp_Clear = 0x00000002,
    WGPULoadOp_Force32 = 0x7FFFFFFF
} WGPULoadOp WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUMapAsyncStatus {
    WGPUMapAsyncStatus_Success = 0x00000001,
    WGPUMapAsyncStatus_InstanceDropped = 0x00000002,
    WGPUMapAsyncStatus_Error = 0x00000003,
    WGPUMapAsyncStatus_Aborted = 0x00000004,
    WGPUMapAsyncStatus_Unknown = 0x00000005,
    WGPUMapAsyncStatus_Force32 = 0x7FFFFFFF
} WGPUMapAsyncStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUMipmapFilterMode {
    WGPUMipmapFilterMode_Undefined = 0x00000000,
    WGPUMipmapFilterMode_Nearest = 0x00000001,
    WGPUMipmapFilterMode_Linear = 0x00000002,
    WGPUMipmapFilterMode_Force32 = 0x7FFFFFFF
} WGPUMipmapFilterMode WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUOptionalBool {
    WGPUOptionalBool_False = 0x00000000,
    WGPUOptionalBool_True = 0x00000001,
    WGPUOptionalBool_Undefined = 0x00000002,
    WGPUOptionalBool_Force32 = 0x7FFFFFFF
} WGPUOptionalBool WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUPopErrorScopeStatus {
    WGPUPopErrorScopeStatus_Success = 0x00000001,
    WGPUPopErrorScopeStatus_InstanceDropped = 0x00000002,
    WGPUPopErrorScopeStatus_Force32 = 0x7FFFFFFF
} WGPUPopErrorScopeStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUPowerPreference {
    WGPUPowerPreference_Undefined = 0x00000000,
    WGPUPowerPreference_LowPower = 0x00000001,
    WGPUPowerPreference_HighPerformance = 0x00000002,
    WGPUPowerPreference_Force32 = 0x7FFFFFFF
} WGPUPowerPreference WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUPresentMode {
    WGPUPresentMode_Fifo = 0x00000001,
    WGPUPresentMode_FifoRelaxed = 0x00000002,
    WGPUPresentMode_Immediate = 0x00000003,
    WGPUPresentMode_Mailbox = 0x00000004,
    WGPUPresentMode_Force32 = 0x7FFFFFFF
} WGPUPresentMode WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUPrimitiveTopology {
    WGPUPrimitiveTopology_Undefined = 0x00000000,
    WGPUPrimitiveTopology_PointList = 0x00000001,
    WGPUPrimitiveTopology_LineList = 0x00000002,
    WGPUPrimitiveTopology_LineStrip = 0x00000003,
    WGPUPrimitiveTopology_TriangleList = 0x00000004,
    WGPUPrimitiveTopology_TriangleStrip = 0x00000005,
    WGPUPrimitiveTopology_Force32 = 0x7FFFFFFF
} WGPUPrimitiveTopology WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUQueryType {
    WGPUQueryType_Occlusion = 0x00000001,
    WGPUQueryType_Timestamp = 0x00000002,
    WGPUQueryType_Force32 = 0x7FFFFFFF
} WGPUQueryType WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUQueueWorkDoneStatus {
    WGPUQueueWorkDoneStatus_Success = 0x00000001,
    WGPUQueueWorkDoneStatus_InstanceDropped = 0x00000002,
    WGPUQueueWorkDoneStatus_Error = 0x00000003,
    WGPUQueueWorkDoneStatus_Unknown = 0x00000004,
    WGPUQueueWorkDoneStatus_DeviceLost = 0x00000005,
    WGPUQueueWorkDoneStatus_Force32 = 0x7FFFFFFF
} WGPUQueueWorkDoneStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPURequestAdapterStatus {
    WGPURequestAdapterStatus_Success = 0x00000001,
    WGPURequestAdapterStatus_InstanceDropped = 0x00000002,
    WGPURequestAdapterStatus_Unavailable = 0x00000003,
    WGPURequestAdapterStatus_Error = 0x00000004,
    WGPURequestAdapterStatus_Unknown = 0x00000005,
    WGPURequestAdapterStatus_Force32 = 0x7FFFFFFF
} WGPURequestAdapterStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPURequestDeviceStatus {
    WGPURequestDeviceStatus_Success = 0x00000001,
    WGPURequestDeviceStatus_InstanceDropped = 0x00000002,
    WGPURequestDeviceStatus_Error = 0x00000003,
    WGPURequestDeviceStatus_Unknown = 0x00000004,
    WGPURequestDeviceStatus_Force32 = 0x7FFFFFFF
} WGPURequestDeviceStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUSType {
    WGPUSType_ShaderSourceSPIRV = 0x00000001,
    WGPUSType_ShaderSourceWGSL = 0x00000002,
    WGPUSType_RenderPassMaxDrawCount = 0x00000003,
    WGPUSType_SurfaceSourceMetalLayer = 0x00000004,
    WGPUSType_SurfaceSourceWindowsHWND = 0x00000005,
    WGPUSType_SurfaceSourceXlibWindow = 0x00000006,
    WGPUSType_SurfaceSourceWaylandSurface = 0x00000007,
    WGPUSType_SurfaceSourceAndroidNativeWindow = 0x00000008,
    WGPUSType_SurfaceSourceXCBWindow = 0x00000009,
    WGPUSType_TextureBindingViewDimensionDescriptor = 0x00020000,
    WGPUSType_SurfaceSourceCanvasHTMLSelector_Emscripten = 0x00040000,
    WGPUSType_Force32 = 0x7FFFFFFF
} WGPUSType WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUSamplerBindingType {
    WGPUSamplerBindingType_Undefined = 0x00000000,
    WGPUSamplerBindingType_Filtering = 0x00000001,
    WGPUSamplerBindingType_NonFiltering = 0x00000002,
    WGPUSamplerBindingType_Comparison = 0x00000003,
    WGPUSamplerBindingType_Force32 = 0x7FFFFFFF
} WGPUSamplerBindingType WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUStatus {
    WGPUStatus_Success = 0x00000001,
    WGPUStatus_Error = 0x00000002,
    WGPUStatus_Force32 = 0x7FFFFFFF
} WGPUStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUStencilOperation {
    WGPUStencilOperation_Undefined = 0x00000000,
    WGPUStencilOperation_Keep = 0x00000001,
    WGPUStencilOperation_Zero = 0x00000002,
    WGPUStencilOperation_Replace = 0x00000003,
    WGPUStencilOperation_Invert = 0x00000004,
    WGPUStencilOperation_IncrementClamp = 0x00000005,
    WGPUStencilOperation_DecrementClamp = 0x00000006,
    WGPUStencilOperation_IncrementWrap = 0x00000007,
    WGPUStencilOperation_DecrementWrap = 0x00000008,
    WGPUStencilOperation_Force32 = 0x7FFFFFFF
} WGPUStencilOperation WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUStorageTextureAccess {
    WGPUStorageTextureAccess_Undefined = 0x00000000,
    WGPUStorageTextureAccess_WriteOnly = 0x00000001,
    WGPUStorageTextureAccess_ReadOnly = 0x00000002,
    WGPUStorageTextureAccess_ReadWrite = 0x00000003,
    WGPUStorageTextureAccess_Force32 = 0x7FFFFFFF
} WGPUStorageTextureAccess WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUStoreOp {
    WGPUStoreOp_Undefined = 0x00000000,
    WGPUStoreOp_Store = 0x00000001,
    WGPUStoreOp_Discard = 0x00000002,
    WGPUStoreOp_Force32 = 0x7FFFFFFF
} WGPUStoreOp WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUSurfaceGetCurrentTextureStatus {
    WGPUSurfaceGetCurrentTextureStatus_Success = 0x00000001,
    WGPUSurfaceGetCurrentTextureStatus_Timeout = 0x00000002,
    WGPUSurfaceGetCurrentTextureStatus_Outdated = 0x00000003,
    WGPUSurfaceGetCurrentTextureStatus_Lost = 0x00000004,
    WGPUSurfaceGetCurrentTextureStatus_OutOfMemory = 0x00000005,
    WGPUSurfaceGetCurrentTextureStatus_DeviceLost = 0x00000006,
    WGPUSurfaceGetCurrentTextureStatus_Error = 0x00000007,
    WGPUSurfaceGetCurrentTextureStatus_Force32 = 0x7FFFFFFF
} WGPUSurfaceGetCurrentTextureStatus WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUTextureAspect {
    WGPUTextureAspect_Undefined = 0x00000000,
    WGPUTextureAspect_All = 0x00000001,
    WGPUTextureAspect_StencilOnly = 0x00000002,
    WGPUTextureAspect_DepthOnly = 0x00000003,
    WGPUTextureAspect_Force32 = 0x7FFFFFFF
} WGPUTextureAspect WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUTextureDimension {
    WGPUTextureDimension_Undefined = 0x00000000,
    WGPUTextureDimension_1D = 0x00000001,
    WGPUTextureDimension_2D = 0x00000002,
    WGPUTextureDimension_3D = 0x00000003,
    WGPUTextureDimension_Force32 = 0x7FFFFFFF
} WGPUTextureDimension WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUTextureFormat {
    WGPUTextureFormat_Undefined = 0x00000000,
    WGPUTextureFormat_R8Unorm = 0x00000001,
    WGPUTextureFormat_R8Snorm = 0x00000002,
    WGPUTextureFormat_R8Uint = 0x00000003,
    WGPUTextureFormat_R8Sint = 0x00000004,
    WGPUTextureFormat_R16Uint = 0x00000005,
    WGPUTextureFormat_R16Sint = 0x00000006,
    WGPUTextureFormat_R16Float = 0x00000007,
    WGPUTextureFormat_RG8Unorm = 0x00000008,
    WGPUTextureFormat_RG8Snorm = 0x00000009,
    WGPUTextureFormat_RG8Uint = 0x0000000A,
    WGPUTextureFormat_RG8Sint = 0x0000000B,
    WGPUTextureFormat_R32Float = 0x0000000C,
    WGPUTextureFormat_R32Uint = 0x0000000D,
    WGPUTextureFormat_R32Sint = 0x0000000E,
    WGPUTextureFormat_RG16Uint = 0x0000000F,
    WGPUTextureFormat_RG16Sint = 0x00000010,
    WGPUTextureFormat_RG16Float = 0x00000011,
    WGPUTextureFormat_RGBA8Unorm = 0x00000012,
    WGPUTextureFormat_RGBA8UnormSrgb = 0x00000013,
    WGPUTextureFormat_RGBA8Snorm = 0x00000014,
    WGPUTextureFormat_RGBA8Uint = 0x00000015,
    WGPUTextureFormat_RGBA8Sint = 0x00000016,
    WGPUTextureFormat_BGRA8Unorm = 0x00000017,
    WGPUTextureFormat_BGRA8UnormSrgb = 0x00000018,
    WGPUTextureFormat_RGB10A2Uint = 0x00000019,
    WGPUTextureFormat_RGB10A2Unorm = 0x0000001A,
    WGPUTextureFormat_RG11B10Ufloat = 0x0000001B,
    WGPUTextureFormat_RGB9E5Ufloat = 0x0000001C,
    WGPUTextureFormat_RG32Float = 0x0000001D,
    WGPUTextureFormat_RG32Uint = 0x0000001E,
    WGPUTextureFormat_RG32Sint = 0x0000001F,
    WGPUTextureFormat_RGBA16Uint = 0x00000020,
    WGPUTextureFormat_RGBA16Sint = 0x00000021,
    WGPUTextureFormat_RGBA16Float = 0x00000022,
    WGPUTextureFormat_RGBA32Float = 0x00000023,
    WGPUTextureFormat_RGBA32Uint = 0x00000024,
    WGPUTextureFormat_RGBA32Sint = 0x00000025,
    WGPUTextureFormat_Stencil8 = 0x00000026,
    WGPUTextureFormat_Depth16Unorm = 0x00000027,
    WGPUTextureFormat_Depth24Plus = 0x00000028,
    WGPUTextureFormat_Depth24PlusStencil8 = 0x00000029,
    WGPUTextureFormat_Depth32Float = 0x0000002A,
    WGPUTextureFormat_Depth32FloatStencil8 = 0x0000002B,
    WGPUTextureFormat_BC1RGBAUnorm = 0x0000002C,
    WGPUTextureFormat_BC1RGBAUnormSrgb = 0x0000002D,
    WGPUTextureFormat_BC2RGBAUnorm = 0x0000002E,
    WGPUTextureFormat_BC2RGBAUnormSrgb = 0x0000002F,
    WGPUTextureFormat_BC3RGBAUnorm = 0x00000030,
    WGPUTextureFormat_BC3RGBAUnormSrgb = 0x00000031,
    WGPUTextureFormat_BC4RUnorm = 0x00000032,
    WGPUTextureFormat_BC4RSnorm = 0x00000033,
    WGPUTextureFormat_BC5RGUnorm = 0x00000034,
    WGPUTextureFormat_BC5RGSnorm = 0x00000035,
    WGPUTextureFormat_BC6HRGBUfloat = 0x00000036,
    WGPUTextureFormat_BC6HRGBFloat = 0x00000037,
    WGPUTextureFormat_BC7RGBAUnorm = 0x00000038,
    WGPUTextureFormat_BC7RGBAUnormSrgb = 0x00000039,
    WGPUTextureFormat_ETC2RGB8Unorm = 0x0000003A,
    WGPUTextureFormat_ETC2RGB8UnormSrgb = 0x0000003B,
    WGPUTextureFormat_ETC2RGB8A1Unorm = 0x0000003C,
    WGPUTextureFormat_ETC2RGB8A1UnormSrgb = 0x0000003D,
    WGPUTextureFormat_ETC2RGBA8Unorm = 0x0000003E,
    WGPUTextureFormat_ETC2RGBA8UnormSrgb = 0x0000003F,
    WGPUTextureFormat_EACR11Unorm = 0x00000040,
    WGPUTextureFormat_EACR11Snorm = 0x00000041,
    WGPUTextureFormat_EACRG11Unorm = 0x00000042,
    WGPUTextureFormat_EACRG11Snorm = 0x00000043,
    WGPUTextureFormat_ASTC4x4Unorm = 0x00000044,
    WGPUTextureFormat_ASTC4x4UnormSrgb = 0x00000045,
    WGPUTextureFormat_ASTC5x4Unorm = 0x00000046,
    WGPUTextureFormat_ASTC5x4UnormSrgb = 0x00000047,
    WGPUTextureFormat_ASTC5x5Unorm = 0x00000048,
    WGPUTextureFormat_ASTC5x5UnormSrgb = 0x00000049,
    WGPUTextureFormat_ASTC6x5Unorm = 0x0000004A,
    WGPUTextureFormat_ASTC6x5UnormSrgb = 0x0000004B,
    WGPUTextureFormat_ASTC6x6Unorm = 0x0000004C,
    WGPUTextureFormat_ASTC6x6UnormSrgb = 0x0000004D,
    WGPUTextureFormat_ASTC8x5Unorm = 0x0000004E,
    WGPUTextureFormat_ASTC8x5UnormSrgb = 0x0000004F,
    WGPUTextureFormat_ASTC8x6Unorm = 0x00000050,
    WGPUTextureFormat_ASTC8x6UnormSrgb = 0x00000051,
    WGPUTextureFormat_ASTC8x8Unorm = 0x00000052,
    WGPUTextureFormat_ASTC8x8UnormSrgb = 0x00000053,
    WGPUTextureFormat_ASTC10x5Unorm = 0x00000054,
    WGPUTextureFormat_ASTC10x5UnormSrgb = 0x00000055,
    WGPUTextureFormat_ASTC10x6Unorm = 0x00000056,
    WGPUTextureFormat_ASTC10x6UnormSrgb = 0x00000057,
    WGPUTextureFormat_ASTC10x8Unorm = 0x00000058,
    WGPUTextureFormat_ASTC10x8UnormSrgb = 0x00000059,
    WGPUTextureFormat_ASTC10x10Unorm = 0x0000005A,
    WGPUTextureFormat_ASTC10x10UnormSrgb = 0x0000005B,
    WGPUTextureFormat_ASTC12x10Unorm = 0x0000005C,
    WGPUTextureFormat_ASTC12x10UnormSrgb = 0x0000005D,
    WGPUTextureFormat_ASTC12x12Unorm = 0x0000005E,
    WGPUTextureFormat_ASTC12x12UnormSrgb = 0x0000005F,
    WGPUTextureFormat_Force32 = 0x7FFFFFFF
} WGPUTextureFormat WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUTextureSampleType {
    WGPUTextureSampleType_Undefined = 0x00000000,
    WGPUTextureSampleType_Float = 0x00000001,
    WGPUTextureSampleType_UnfilterableFloat = 0x00000002,
    WGPUTextureSampleType_Depth = 0x00000003,
    WGPUTextureSampleType_Sint = 0x00000004,
    WGPUTextureSampleType_Uint = 0x00000005,
    WGPUTextureSampleType_Force32 = 0x7FFFFFFF
} WGPUTextureSampleType WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUTextureViewDimension {
    WGPUTextureViewDimension_Undefined = 0x00000000,
    WGPUTextureViewDimension_1D = 0x00000001,
    WGPUTextureViewDimension_2D = 0x00000002,
    WGPUTextureViewDimension_2DArray = 0x00000003,
    WGPUTextureViewDimension_Cube = 0x00000004,
    WGPUTextureViewDimension_CubeArray = 0x00000005,
    WGPUTextureViewDimension_3D = 0x00000006,
    WGPUTextureViewDimension_Force32 = 0x7FFFFFFF
} WGPUTextureViewDimension WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUVertexFormat {
    WGPUVertexFormat_Uint8 = 0x00000001,
    WGPUVertexFormat_Uint8x2 = 0x00000002,
    WGPUVertexFormat_Uint8x4 = 0x00000003,
    WGPUVertexFormat_Sint8 = 0x00000004,
    WGPUVertexFormat_Sint8x2 = 0x00000005,
    WGPUVertexFormat_Sint8x4 = 0x00000006,
    WGPUVertexFormat_Unorm8 = 0x00000007,
    WGPUVertexFormat_Unorm8x2 = 0x00000008,
    WGPUVertexFormat_Unorm8x4 = 0x00000009,
    WGPUVertexFormat_Snorm8 = 0x0000000A,
    WGPUVertexFormat_Snorm8x2 = 0x0000000B,
    WGPUVertexFormat_Snorm8x4 = 0x0000000C,
    WGPUVertexFormat_Uint16 = 0x0000000D,
    WGPUVertexFormat_Uint16x2 = 0x0000000E,
    WGPUVertexFormat_Uint16x4 = 0x0000000F,
    WGPUVertexFormat_Sint16 = 0x00000010,
    WGPUVertexFormat_Sint16x2 = 0x00000011,
    WGPUVertexFormat_Sint16x4 = 0x00000012,
    WGPUVertexFormat_Unorm16 = 0x00000013,
    WGPUVertexFormat_Unorm16x2 = 0x00000014,
    WGPUVertexFormat_Unorm16x4 = 0x00000015,
    WGPUVertexFormat_Snorm16 = 0x00000016,
    WGPUVertexFormat_Snorm16x2 = 0x00000017,
    WGPUVertexFormat_Snorm16x4 = 0x00000018,
    WGPUVertexFormat_Float16 = 0x00000019,
    WGPUVertexFormat_Float16x2 = 0x0000001A,
    WGPUVertexFormat_Float16x4 = 0x0000001B,
    WGPUVertexFormat_Float32 = 0x0000001C,
    WGPUVertexFormat_Float32x2 = 0x0000001D,
    WGPUVertexFormat_Float32x3 = 0x0000001E,
    WGPUVertexFormat_Float32x4 = 0x0000001F,
    WGPUVertexFormat_Uint32 = 0x00000020,
    WGPUVertexFormat_Uint32x2 = 0x00000021,
    WGPUVertexFormat_Uint32x3 = 0x00000022,
    WGPUVertexFormat_Uint32x4 = 0x00000023,
    WGPUVertexFormat_Sint32 = 0x00000024,
    WGPUVertexFormat_Sint32x2 = 0x00000025,
    WGPUVertexFormat_Sint32x3 = 0x00000026,
    WGPUVertexFormat_Sint32x4 = 0x00000027,
    WGPUVertexFormat_Unorm10_10_10_2 = 0x00000028,
    WGPUVertexFormat_Unorm8x4BGRA = 0x00000029,
    WGPUVertexFormat_Force32 = 0x7FFFFFFF
} WGPUVertexFormat WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUVertexStepMode {
    WGPUVertexStepMode_VertexBufferNotUsed = 0x00000000,
    WGPUVertexStepMode_Undefined = 0x00000001,
    WGPUVertexStepMode_Vertex = 0x00000002,
    WGPUVertexStepMode_Instance = 0x00000003,
    WGPUVertexStepMode_Force32 = 0x7FFFFFFF
} WGPUVertexStepMode WGPU_ENUM_ATTRIBUTE;
typedef enum WGPUWaitStatus {
    WGPUWaitStatus_Success = 0x00000001,
    WGPUWaitStatus_TimedOut = 0x00000002,
    WGPUWaitStatus_UnsupportedTimeout = 0x00000003,
    WGPUWaitStatus_UnsupportedCount = 0x00000004,
    WGPUWaitStatus_UnsupportedMixedSources = 0x00000005,
    WGPUWaitStatus_Unknown = 0x00000006,
    WGPUWaitStatus_Force32 = 0x7FFFFFFF
} WGPUWaitStatus WGPU_ENUM_ATTRIBUTE;

typedef WGPUFlags WGPUBufferUsage;
static const WGPUBufferUsage WGPUBufferUsage_None = 0x0000000000000000;
static const WGPUBufferUsage WGPUBufferUsage_MapRead = 0x0000000000000001;
static const WGPUBufferUsage WGPUBufferUsage_MapWrite = 0x0000000000000002;
static const WGPUBufferUsage WGPUBufferUsage_CopySrc = 0x0000000000000004;
static const WGPUBufferUsage WGPUBufferUsage_CopyDst = 0x0000000000000008;
static const WGPUBufferUsage WGPUBufferUsage_Index = 0x0000000000000010;
static const WGPUBufferUsage WGPUBufferUsage_Vertex = 0x0000000000000020;
static const WGPUBufferUsage WGPUBufferUsage_Uniform = 0x0000000000000040;
static const WGPUBufferUsage WGPUBufferUsage_Storage = 0x0000000000000080;
static const WGPUBufferUsage WGPUBufferUsage_Indirect = 0x0000000000000100;
static const WGPUBufferUsage WGPUBufferUsage_QueryResolve = 0x0000000000000200;
typedef WGPUFlags WGPUColorWriteMask;
static const WGPUColorWriteMask WGPUColorWriteMask_None = 0x0000000000000000;
static const WGPUColorWriteMask WGPUColorWriteMask_Red = 0x0000000000000001;
static const WGPUColorWriteMask WGPUColorWriteMask_Green = 0x0000000000000002;
static const WGPUColorWriteMask WGPUColorWriteMask_Blue = 0x0000000000000004;
static const WGPUColorWriteMask WGPUColorWriteMask_Alpha = 0x0000000000000008;
static const WGPUColorWriteMask WGPUColorWriteMask_All = 0x000000000000000F;
typedef WGPUFlags WGPUMapMode;
static const WGPUMapMode WGPUMapMode_None = 0x0000000000000000;
static const WGPUMapMode WGPUMapMode_Read = 0x0000000000000001;
static const WGPUMapMode WGPUMapMode_Write = 0x0000000000000002;
typedef WGPUFlags WGPUShaderStage;
static const WGPUShaderStage WGPUShaderStage_None = 0x0000000000000000;
static const WGPUShaderStage WGPUShaderStage_Vertex = 0x0000000000000001;
static const WGPUShaderStage WGPUShaderStage_Fragment = 0x0000000000000002;
static const WGPUShaderStage WGPUShaderStage_Compute = 0x0000000000000004;
typedef WGPUFlags WGPUTextureUsage;
static const WGPUTextureUsage WGPUTextureUsage_None = 0x0000000000000000;
static const WGPUTextureUsage WGPUTextureUsage_CopySrc = 0x0000000000000001;
static const WGPUTextureUsage WGPUTextureUsage_CopyDst = 0x0000000000000002;
static const WGPUTextureUsage WGPUTextureUsage_TextureBinding = 0x0000000000000004;
static const WGPUTextureUsage WGPUTextureUsage_StorageBinding = 0x0000000000000008;
static const WGPUTextureUsage WGPUTextureUsage_RenderAttachment = 0x0000000000000010;
typedef void (*WGPUBufferMapCallback)(WGPUBufferMapAsyncStatus status, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUCompilationInfoCallback)(WGPUCompilationInfoRequestStatus status, struct WGPUCompilationInfo const * compilationInfo, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUCreateComputePipelineAsyncCallback)(WGPUCreatePipelineAsyncStatus status, WGPUComputePipeline pipeline, struct WGPUStringView message, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUCreateRenderPipelineAsyncCallback)(WGPUCreatePipelineAsyncStatus status, WGPURenderPipeline pipeline, struct WGPUStringView message, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUDeviceLostCallback)(WGPUDeviceLostReason reason, struct WGPUStringView message, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUDeviceLostCallbackNew)(WGPUDevice const * device, WGPUDeviceLostReason reason, struct WGPUStringView message, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUErrorCallback)(WGPUErrorType type, struct WGPUStringView message, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUPopErrorScopeCallback)(WGPUPopErrorScopeStatus status, WGPUErrorType type, struct WGPUStringView message, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProc)(void) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUQueueWorkDoneCallback)(WGPUQueueWorkDoneStatus status, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPURequestAdapterCallback)(WGPURequestAdapterStatus status, WGPUAdapter adapter, struct WGPUStringView message, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPURequestDeviceCallback)(WGPURequestDeviceStatus status, WGPUDevice device, struct WGPUStringView message, void * userdata) WGPU_FUNCTION_ATTRIBUTE;

// Callback function pointers
typedef void (*WGPUBufferMapCallback2)(WGPUMapAsyncStatus status, struct WGPUStringView message, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUCompilationInfoCallback2)(WGPUCompilationInfoRequestStatus status, struct WGPUCompilationInfo const * compilationInfo, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUCreateComputePipelineAsyncCallback2)(WGPUCreatePipelineAsyncStatus status, WGPUComputePipeline pipeline, struct WGPUStringView message, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUCreateRenderPipelineAsyncCallback2)(WGPUCreatePipelineAsyncStatus status, WGPURenderPipeline pipeline, struct WGPUStringView message, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUDeviceLostCallback2)(WGPUDevice const * device, WGPUDeviceLostReason reason, struct WGPUStringView message, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUPopErrorScopeCallback2)(WGPUPopErrorScopeStatus status, WGPUErrorType type, struct WGPUStringView message, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUQueueWorkDoneCallback2)(WGPUQueueWorkDoneStatus status, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPURequestAdapterCallback2)(WGPURequestAdapterStatus status, WGPUAdapter adapter, struct WGPUStringView message, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPURequestDeviceCallback2)(WGPURequestDeviceStatus status, WGPUDevice device, struct WGPUStringView message, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUUncapturedErrorCallback)(WGPUDevice const * device, WGPUErrorType type, struct WGPUStringView message, void* userdata1, void* userdata2) WGPU_FUNCTION_ATTRIBUTE;

typedef struct WGPUChainedStruct {
    struct WGPUChainedStruct const * next;
    WGPUSType sType;
} WGPUChainedStruct WGPU_STRUCTURE_ATTRIBUTE;

typedef struct WGPUChainedStructOut {
    struct WGPUChainedStructOut * next;
    WGPUSType sType;
} WGPUChainedStructOut WGPU_STRUCTURE_ATTRIBUTE;


#define WGPU_COMMA ,

typedef struct WGPUBufferMapCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUCallbackMode mode;
    WGPUBufferMapCallback2 callback;
    void* userdata1;
    void* userdata2;
} WGPUBufferMapCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BUFFER_MAP_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPUBufferMapCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})

typedef struct WGPUCompilationInfoCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUCallbackMode mode;
    WGPUCompilationInfoCallback2 callback;
    void* userdata1;
    void* userdata2;
} WGPUCompilationInfoCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COMPILATION_INFO_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPUCompilationInfoCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})

typedef struct WGPUCreateComputePipelineAsyncCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUCallbackMode mode;
    WGPUCreateComputePipelineAsyncCallback2 callback;
    void* userdata1;
    void* userdata2;
} WGPUCreateComputePipelineAsyncCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_CREATE_COMPUTE_PIPELINE_ASYNC_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPUCreateComputePipelineAsyncCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})

typedef struct WGPUCreateRenderPipelineAsyncCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUCallbackMode mode;
    WGPUCreateRenderPipelineAsyncCallback2 callback;
    void* userdata1;
    void* userdata2;
} WGPUCreateRenderPipelineAsyncCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_CREATE_RENDER_PIPELINE_ASYNC_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPUCreateRenderPipelineAsyncCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})

typedef struct WGPUDeviceLostCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUCallbackMode mode;
    WGPUDeviceLostCallback2 callback;
    void* userdata1;
    void* userdata2;
} WGPUDeviceLostCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_DEVICE_LOST_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPUDeviceLostCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})

typedef struct WGPUPopErrorScopeCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUCallbackMode mode;
    WGPUPopErrorScopeCallback2 callback;
    void* userdata1;
    void* userdata2;
} WGPUPopErrorScopeCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_POP_ERROR_SCOPE_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPUPopErrorScopeCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})

typedef struct WGPUQueueWorkDoneCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUCallbackMode mode;
    WGPUQueueWorkDoneCallback2 callback;
    void* userdata1;
    void* userdata2;
} WGPUQueueWorkDoneCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_QUEUE_WORK_DONE_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPUQueueWorkDoneCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})

typedef struct WGPURequestAdapterCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUCallbackMode mode;
    WGPURequestAdapterCallback2 callback;
    void* userdata1;
    void* userdata2;
} WGPURequestAdapterCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_REQUEST_ADAPTER_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPURequestAdapterCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})

typedef struct WGPURequestDeviceCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUCallbackMode mode;
    WGPURequestDeviceCallback2 callback;
    void* userdata1;
    void* userdata2;
} WGPURequestDeviceCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_REQUEST_DEVICE_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPURequestDeviceCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})

typedef struct WGPUUncapturedErrorCallbackInfo2 {
    WGPUChainedStruct const* nextInChain;
    WGPUUncapturedErrorCallback callback;
    void* userdata1;
    void* userdata2;
} WGPUUncapturedErrorCallbackInfo2 WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_UNCAPTURED_ERROR_CALLBACK_INFO_2_INIT WGPU_MAKE_INIT_STRUCT(WGPUUncapturedErrorCallbackInfo2, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata1=*/nullptr WGPU_COMMA \
    /*.userdata2=*/nullptr WGPU_COMMA \
})


typedef struct WGPUINTERNAL__HAVE_EMDAWNWEBGPU_HEADER {
    WGPUBool unused;
} WGPUINTERNAL__HAVE_EMDAWNWEBGPU_HEADER WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_INTERNAL__HAVE_EMDAWNWEBGPU_HEADER_INIT WGPU_MAKE_INIT_STRUCT(WGPUINTERNAL__HAVE_EMDAWNWEBGPU_HEADER, { \
    /*.unused=*/false WGPU_COMMA \
})

typedef struct WGPUBindGroupEntry {
    WGPUChainedStruct const * nextInChain;
    uint32_t binding;
    WGPU_NULLABLE WGPUBuffer buffer;
    uint64_t offset;
    uint64_t size;
    WGPU_NULLABLE WGPUSampler sampler;
    WGPU_NULLABLE WGPUTextureView textureView;
} WGPUBindGroupEntry WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BIND_GROUP_ENTRY_INIT WGPU_MAKE_INIT_STRUCT(WGPUBindGroupEntry, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.binding=*/{} WGPU_COMMA \
    /*.buffer=*/nullptr WGPU_COMMA \
    /*.offset=*/0 WGPU_COMMA \
    /*.size=*/WGPU_WHOLE_SIZE WGPU_COMMA \
    /*.sampler=*/nullptr WGPU_COMMA \
    /*.textureView=*/nullptr WGPU_COMMA \
})

typedef struct WGPUBlendComponent {
    WGPUBlendOperation operation;
    WGPUBlendFactor srcFactor;
    WGPUBlendFactor dstFactor;
} WGPUBlendComponent WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BLEND_COMPONENT_INIT WGPU_MAKE_INIT_STRUCT(WGPUBlendComponent, { \
    /*.operation=*/WGPUBlendOperation_Add WGPU_COMMA \
    /*.srcFactor=*/WGPUBlendFactor_One WGPU_COMMA \
    /*.dstFactor=*/WGPUBlendFactor_Zero WGPU_COMMA \
})

typedef struct WGPUBufferBindingLayout {
    WGPUChainedStruct const * nextInChain;
    WGPUBufferBindingType type;
    WGPUBool hasDynamicOffset;
    uint64_t minBindingSize;
} WGPUBufferBindingLayout WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BUFFER_BINDING_LAYOUT_INIT WGPU_MAKE_INIT_STRUCT(WGPUBufferBindingLayout, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.type=*/WGPUBufferBindingType_Undefined WGPU_COMMA \
    /*.hasDynamicOffset=*/false WGPU_COMMA \
    /*.minBindingSize=*/0 WGPU_COMMA \
})

typedef struct WGPUBufferMapCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUCallbackMode mode;
    WGPUBufferMapCallback callback;
    void * userdata;
} WGPUBufferMapCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BUFFER_MAP_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUBufferMapCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/{} WGPU_COMMA \
    /*.userdata=*/{} WGPU_COMMA \
})

typedef struct WGPUColor {
    double r;
    double g;
    double b;
    double a;
} WGPUColor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COLOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUColor, { \
    /*.r=*/{} WGPU_COMMA \
    /*.g=*/{} WGPU_COMMA \
    /*.b=*/{} WGPU_COMMA \
    /*.a=*/{} WGPU_COMMA \
})

typedef struct WGPUCompilationInfoCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUCallbackMode mode;
    WGPUCompilationInfoCallback callback;
    void * userdata;
} WGPUCompilationInfoCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COMPILATION_INFO_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUCompilationInfoCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/{} WGPU_COMMA \
    /*.userdata=*/nullptr WGPU_COMMA \
})

typedef struct WGPUComputePassTimestampWrites {
    WGPUQuerySet querySet;
    uint32_t beginningOfPassWriteIndex;
    uint32_t endOfPassWriteIndex;
} WGPUComputePassTimestampWrites WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COMPUTE_PASS_TIMESTAMP_WRITES_INIT WGPU_MAKE_INIT_STRUCT(WGPUComputePassTimestampWrites, { \
    /*.querySet=*/{} WGPU_COMMA \
    /*.beginningOfPassWriteIndex=*/WGPU_QUERY_SET_INDEX_UNDEFINED WGPU_COMMA \
    /*.endOfPassWriteIndex=*/WGPU_QUERY_SET_INDEX_UNDEFINED WGPU_COMMA \
})

typedef struct WGPUCreateComputePipelineAsyncCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUCallbackMode mode;
    WGPUCreateComputePipelineAsyncCallback callback;
    void * userdata;
} WGPUCreateComputePipelineAsyncCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_CREATE_COMPUTE_PIPELINE_ASYNC_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUCreateComputePipelineAsyncCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/{} WGPU_COMMA \
    /*.userdata=*/{} WGPU_COMMA \
})

typedef struct WGPUCreateRenderPipelineAsyncCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUCallbackMode mode;
    WGPUCreateRenderPipelineAsyncCallback callback;
    void * userdata;
} WGPUCreateRenderPipelineAsyncCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_CREATE_RENDER_PIPELINE_ASYNC_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUCreateRenderPipelineAsyncCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/{} WGPU_COMMA \
    /*.userdata=*/{} WGPU_COMMA \
})

typedef struct WGPUDeviceLostCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUCallbackMode mode;
    WGPUDeviceLostCallbackNew callback;
    void * userdata;
} WGPUDeviceLostCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_DEVICE_LOST_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUDeviceLostCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/WGPUCallbackMode_WaitAnyOnly WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata=*/nullptr WGPU_COMMA \
})

typedef struct WGPUExtent3D {
    uint32_t width;
    uint32_t height;
    uint32_t depthOrArrayLayers;
} WGPUExtent3D WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_EXTENT_3D_INIT WGPU_MAKE_INIT_STRUCT(WGPUExtent3D, { \
    /*.width=*/{} WGPU_COMMA \
    /*.height=*/1 WGPU_COMMA \
    /*.depthOrArrayLayers=*/1 WGPU_COMMA \
})

typedef struct WGPUFuture {
    uint64_t id;
} WGPUFuture WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_FUTURE_INIT WGPU_MAKE_INIT_STRUCT(WGPUFuture, { \
    /*.id=*/{} WGPU_COMMA \
})

typedef struct WGPUInstanceFeatures {
    WGPUChainedStruct const * nextInChain;
    WGPUBool timedWaitAnyEnable;
    size_t timedWaitAnyMaxCount;
} WGPUInstanceFeatures WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_INSTANCE_FEATURES_INIT WGPU_MAKE_INIT_STRUCT(WGPUInstanceFeatures, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.timedWaitAnyEnable=*/false WGPU_COMMA \
    /*.timedWaitAnyMaxCount=*/0 WGPU_COMMA \
})

typedef struct WGPULimits {
    uint32_t maxTextureDimension1D;
    uint32_t maxTextureDimension2D;
    uint32_t maxTextureDimension3D;
    uint32_t maxTextureArrayLayers;
    uint32_t maxBindGroups;
    uint32_t maxBindGroupsPlusVertexBuffers;
    uint32_t maxBindingsPerBindGroup;
    uint32_t maxDynamicUniformBuffersPerPipelineLayout;
    uint32_t maxDynamicStorageBuffersPerPipelineLayout;
    uint32_t maxSampledTexturesPerShaderStage;
    uint32_t maxSamplersPerShaderStage;
    uint32_t maxStorageBuffersPerShaderStage;
    uint32_t maxStorageTexturesPerShaderStage;
    uint32_t maxUniformBuffersPerShaderStage;
    uint64_t maxUniformBufferBindingSize;
    uint64_t maxStorageBufferBindingSize;
    uint32_t minUniformBufferOffsetAlignment;
    uint32_t minStorageBufferOffsetAlignment;
    uint32_t maxVertexBuffers;
    uint64_t maxBufferSize;
    uint32_t maxVertexAttributes;
    uint32_t maxVertexBufferArrayStride;
    uint32_t maxInterStageShaderComponents;
    uint32_t maxInterStageShaderVariables;
    uint32_t maxColorAttachments;
    uint32_t maxColorAttachmentBytesPerSample;
    uint32_t maxComputeWorkgroupStorageSize;
    uint32_t maxComputeInvocationsPerWorkgroup;
    uint32_t maxComputeWorkgroupSizeX;
    uint32_t maxComputeWorkgroupSizeY;
    uint32_t maxComputeWorkgroupSizeZ;
    uint32_t maxComputeWorkgroupsPerDimension;
} WGPULimits WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_LIMITS_INIT WGPU_MAKE_INIT_STRUCT(WGPULimits, { \
    /*.maxTextureDimension1D=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxTextureDimension2D=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxTextureDimension3D=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxTextureArrayLayers=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxBindGroups=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxBindGroupsPlusVertexBuffers=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxBindingsPerBindGroup=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxDynamicUniformBuffersPerPipelineLayout=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxDynamicStorageBuffersPerPipelineLayout=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxSampledTexturesPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxSamplersPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxStorageBuffersPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxStorageTexturesPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxUniformBuffersPerShaderStage=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxUniformBufferBindingSize=*/WGPU_LIMIT_U64_UNDEFINED WGPU_COMMA \
    /*.maxStorageBufferBindingSize=*/WGPU_LIMIT_U64_UNDEFINED WGPU_COMMA \
    /*.minUniformBufferOffsetAlignment=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.minStorageBufferOffsetAlignment=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxVertexBuffers=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxBufferSize=*/WGPU_LIMIT_U64_UNDEFINED WGPU_COMMA \
    /*.maxVertexAttributes=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxVertexBufferArrayStride=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxInterStageShaderComponents=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxInterStageShaderVariables=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxColorAttachments=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxColorAttachmentBytesPerSample=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxComputeWorkgroupStorageSize=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxComputeInvocationsPerWorkgroup=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxComputeWorkgroupSizeX=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxComputeWorkgroupSizeY=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxComputeWorkgroupSizeZ=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
    /*.maxComputeWorkgroupsPerDimension=*/WGPU_LIMIT_U32_UNDEFINED WGPU_COMMA \
})

typedef struct WGPUMultisampleState {
    WGPUChainedStruct const * nextInChain;
    uint32_t count;
    uint32_t mask;
    WGPUBool alphaToCoverageEnabled;
} WGPUMultisampleState WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_MULTISAMPLE_STATE_INIT WGPU_MAKE_INIT_STRUCT(WGPUMultisampleState, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.count=*/1 WGPU_COMMA \
    /*.mask=*/0xFFFFFFFF WGPU_COMMA \
    /*.alphaToCoverageEnabled=*/false WGPU_COMMA \
})

typedef struct WGPUOrigin3D {
    uint32_t x;
    uint32_t y;
    uint32_t z;
} WGPUOrigin3D WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_ORIGIN_3D_INIT WGPU_MAKE_INIT_STRUCT(WGPUOrigin3D, { \
    /*.x=*/0 WGPU_COMMA \
    /*.y=*/0 WGPU_COMMA \
    /*.z=*/0 WGPU_COMMA \
})

typedef struct WGPUPopErrorScopeCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUCallbackMode mode;
    WGPUPopErrorScopeCallback callback;
    WGPUErrorCallback oldCallback;
    void * userdata;
} WGPUPopErrorScopeCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_POP_ERROR_SCOPE_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUPopErrorScopeCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/WGPUCallbackMode_WaitAnyOnly WGPU_COMMA \
    /*.callback=*/{} WGPU_COMMA \
    /*.oldCallback=*/{} WGPU_COMMA \
    /*.userdata=*/nullptr WGPU_COMMA \
})

typedef struct WGPUPrimitiveState {
    WGPUChainedStruct const * nextInChain;
    WGPUPrimitiveTopology topology;
    WGPUIndexFormat stripIndexFormat;
    WGPUFrontFace frontFace;
    WGPUCullMode cullMode;
    WGPUBool unclippedDepth;
} WGPUPrimitiveState WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_PRIMITIVE_STATE_INIT WGPU_MAKE_INIT_STRUCT(WGPUPrimitiveState, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.topology=*/WGPUPrimitiveTopology_TriangleList WGPU_COMMA \
    /*.stripIndexFormat=*/WGPUIndexFormat_Undefined WGPU_COMMA \
    /*.frontFace=*/WGPUFrontFace_CCW WGPU_COMMA \
    /*.cullMode=*/WGPUCullMode_None WGPU_COMMA \
    /*.unclippedDepth=*/false WGPU_COMMA \
})

typedef struct WGPUQueueWorkDoneCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUCallbackMode mode;
    WGPUQueueWorkDoneCallback callback;
    void * userdata;
} WGPUQueueWorkDoneCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_QUEUE_WORK_DONE_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUQueueWorkDoneCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/{} WGPU_COMMA \
    /*.userdata=*/{} WGPU_COMMA \
})

typedef struct WGPURenderPassDepthStencilAttachment {
    WGPUTextureView view;
    WGPULoadOp depthLoadOp;
    WGPUStoreOp depthStoreOp;
    float depthClearValue;
    WGPUBool depthReadOnly;
    WGPULoadOp stencilLoadOp;
    WGPUStoreOp stencilStoreOp;
    uint32_t stencilClearValue;
    WGPUBool stencilReadOnly;
} WGPURenderPassDepthStencilAttachment WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_RENDER_PASS_DEPTH_STENCIL_ATTACHMENT_INIT WGPU_MAKE_INIT_STRUCT(WGPURenderPassDepthStencilAttachment, { \
    /*.view=*/{} WGPU_COMMA \
    /*.depthLoadOp=*/WGPULoadOp_Undefined WGPU_COMMA \
    /*.depthStoreOp=*/WGPUStoreOp_Undefined WGPU_COMMA \
    /*.depthClearValue=*/NAN WGPU_COMMA \
    /*.depthReadOnly=*/false WGPU_COMMA \
    /*.stencilLoadOp=*/WGPULoadOp_Undefined WGPU_COMMA \
    /*.stencilStoreOp=*/WGPUStoreOp_Undefined WGPU_COMMA \
    /*.stencilClearValue=*/0 WGPU_COMMA \
    /*.stencilReadOnly=*/false WGPU_COMMA \
})

// Can be chained in WGPURenderPassDescriptor
typedef struct WGPURenderPassMaxDrawCount {
    WGPUChainedStruct chain;
    uint64_t maxDrawCount;
} WGPURenderPassMaxDrawCount WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_RENDER_PASS_MAX_DRAW_COUNT_INIT WGPU_MAKE_INIT_STRUCT(WGPURenderPassMaxDrawCount, { \
    /*.chain=*/{/*.nextInChain*/nullptr WGPU_COMMA /*.sType*/WGPUSType_RenderPassMaxDrawCount} WGPU_COMMA \
    /*.maxDrawCount=*/50000000 WGPU_COMMA \
})

typedef struct WGPURenderPassTimestampWrites {
    WGPUQuerySet querySet;
    uint32_t beginningOfPassWriteIndex;
    uint32_t endOfPassWriteIndex;
} WGPURenderPassTimestampWrites WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_RENDER_PASS_TIMESTAMP_WRITES_INIT WGPU_MAKE_INIT_STRUCT(WGPURenderPassTimestampWrites, { \
    /*.querySet=*/{} WGPU_COMMA \
    /*.beginningOfPassWriteIndex=*/WGPU_QUERY_SET_INDEX_UNDEFINED WGPU_COMMA \
    /*.endOfPassWriteIndex=*/WGPU_QUERY_SET_INDEX_UNDEFINED WGPU_COMMA \
})

typedef struct WGPURequestAdapterCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUCallbackMode mode;
    WGPURequestAdapterCallback callback;
    void * userdata;
} WGPURequestAdapterCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_REQUEST_ADAPTER_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPURequestAdapterCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/{} WGPU_COMMA \
    /*.userdata=*/{} WGPU_COMMA \
})

typedef struct WGPURequestAdapterOptions {
    WGPUChainedStruct const * nextInChain;
    WGPU_NULLABLE WGPUSurface compatibleSurface;
    WGPUPowerPreference powerPreference;
    WGPUBackendType backendType;
    WGPUBool forceFallbackAdapter;
    WGPUBool compatibilityMode;
} WGPURequestAdapterOptions WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_REQUEST_ADAPTER_OPTIONS_INIT WGPU_MAKE_INIT_STRUCT(WGPURequestAdapterOptions, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.compatibleSurface=*/nullptr WGPU_COMMA \
    /*.powerPreference=*/WGPUPowerPreference_Undefined WGPU_COMMA \
    /*.backendType=*/WGPUBackendType_Undefined WGPU_COMMA \
    /*.forceFallbackAdapter=*/false WGPU_COMMA \
    /*.compatibilityMode=*/false WGPU_COMMA \
})

typedef struct WGPURequestDeviceCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUCallbackMode mode;
    WGPURequestDeviceCallback callback;
    void * userdata;
} WGPURequestDeviceCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_REQUEST_DEVICE_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPURequestDeviceCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.mode=*/{} WGPU_COMMA \
    /*.callback=*/{} WGPU_COMMA \
    /*.userdata=*/{} WGPU_COMMA \
})

typedef struct WGPUSamplerBindingLayout {
    WGPUChainedStruct const * nextInChain;
    WGPUSamplerBindingType type;
} WGPUSamplerBindingLayout WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SAMPLER_BINDING_LAYOUT_INIT WGPU_MAKE_INIT_STRUCT(WGPUSamplerBindingLayout, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.type=*/WGPUSamplerBindingType_Undefined WGPU_COMMA \
})

// Can be chained in WGPUShaderModuleDescriptor
typedef struct WGPUShaderSourceSPIRV {
    WGPUChainedStruct chain;
    uint32_t codeSize;
    uint32_t const * code;
} WGPUShaderSourceSPIRV WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SHADER_SOURCE_SPIRV_INIT WGPU_MAKE_INIT_STRUCT(WGPUShaderSourceSPIRV, { \
    /*.chain=*/{/*.nextInChain*/nullptr WGPU_COMMA /*.sType*/WGPUSType_ShaderSourceSPIRV} WGPU_COMMA \
    /*.codeSize=*/{} WGPU_COMMA \
    /*.code=*/{} WGPU_COMMA \
})

typedef struct WGPUStencilFaceState {
    WGPUCompareFunction compare;
    WGPUStencilOperation failOp;
    WGPUStencilOperation depthFailOp;
    WGPUStencilOperation passOp;
} WGPUStencilFaceState WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_STENCIL_FACE_STATE_INIT WGPU_MAKE_INIT_STRUCT(WGPUStencilFaceState, { \
    /*.compare=*/WGPUCompareFunction_Always WGPU_COMMA \
    /*.failOp=*/WGPUStencilOperation_Keep WGPU_COMMA \
    /*.depthFailOp=*/WGPUStencilOperation_Keep WGPU_COMMA \
    /*.passOp=*/WGPUStencilOperation_Keep WGPU_COMMA \
})

typedef struct WGPUStorageTextureBindingLayout {
    WGPUChainedStruct const * nextInChain;
    WGPUStorageTextureAccess access;
    WGPUTextureFormat format;
    WGPUTextureViewDimension viewDimension;
} WGPUStorageTextureBindingLayout WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_STORAGE_TEXTURE_BINDING_LAYOUT_INIT WGPU_MAKE_INIT_STRUCT(WGPUStorageTextureBindingLayout, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.access=*/WGPUStorageTextureAccess_Undefined WGPU_COMMA \
    /*.format=*/WGPUTextureFormat_Undefined WGPU_COMMA \
    /*.viewDimension=*/WGPUTextureViewDimension_2D WGPU_COMMA \
})

typedef struct WGPUStringView {
    WGPU_NULLABLE char const * data;
    size_t length;
} WGPUStringView WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_STRING_VIEW_INIT WGPU_MAKE_INIT_STRUCT(WGPUStringView, { \
    /*.data=*/nullptr WGPU_COMMA \
    /*.length=*/WGPU_STRLEN WGPU_COMMA \
})

typedef struct WGPUSupportedFeatures {
    size_t featureCount;
    WGPUFeatureName const * features;
} WGPUSupportedFeatures WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SUPPORTED_FEATURES_INIT WGPU_MAKE_INIT_STRUCT(WGPUSupportedFeatures, { \
    /*.featureCount=*/{} WGPU_COMMA \
    /*.features=*/{} WGPU_COMMA \
})

typedef struct WGPUSurfaceCapabilities {
    WGPUChainedStructOut * nextInChain;
    WGPUTextureUsage usages;
    size_t formatCount;
    WGPUTextureFormat const * formats;
    size_t presentModeCount;
    WGPUPresentMode const * presentModes;
    size_t alphaModeCount;
    WGPUCompositeAlphaMode const * alphaModes;
} WGPUSurfaceCapabilities WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SURFACE_CAPABILITIES_INIT WGPU_MAKE_INIT_STRUCT(WGPUSurfaceCapabilities, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.usages=*/{} WGPU_COMMA \
    /*.formatCount=*/{} WGPU_COMMA \
    /*.formats=*/{} WGPU_COMMA \
    /*.presentModeCount=*/{} WGPU_COMMA \
    /*.presentModes=*/{} WGPU_COMMA \
    /*.alphaModeCount=*/{} WGPU_COMMA \
    /*.alphaModes=*/{} WGPU_COMMA \
})

typedef struct WGPUSurfaceConfiguration {
    WGPUChainedStruct const * nextInChain;
    WGPUDevice device;
    WGPUTextureFormat format;
    WGPUTextureUsage usage;
    size_t viewFormatCount;
    WGPUTextureFormat const * viewFormats;
    WGPUCompositeAlphaMode alphaMode;
    uint32_t width;
    uint32_t height;
    WGPUPresentMode presentMode;
} WGPUSurfaceConfiguration WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SURFACE_CONFIGURATION_INIT WGPU_MAKE_INIT_STRUCT(WGPUSurfaceConfiguration, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.device=*/{} WGPU_COMMA \
    /*.format=*/{} WGPU_COMMA \
    /*.usage=*/WGPUTextureUsage_RenderAttachment WGPU_COMMA \
    /*.viewFormatCount=*/0 WGPU_COMMA \
    /*.viewFormats=*/nullptr WGPU_COMMA \
    /*.alphaMode=*/WGPUCompositeAlphaMode_Auto WGPU_COMMA \
    /*.width=*/{} WGPU_COMMA \
    /*.height=*/{} WGPU_COMMA \
    /*.presentMode=*/WGPUPresentMode_Fifo WGPU_COMMA \
})

typedef struct WGPUSurfaceTexture {
    WGPUTexture texture;
    WGPUBool suboptimal;
    WGPUSurfaceGetCurrentTextureStatus status;
} WGPUSurfaceTexture WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SURFACE_TEXTURE_INIT WGPU_MAKE_INIT_STRUCT(WGPUSurfaceTexture, { \
    /*.texture=*/{} WGPU_COMMA \
    /*.suboptimal=*/{} WGPU_COMMA \
    /*.status=*/{} WGPU_COMMA \
})

typedef struct WGPUTextureBindingLayout {
    WGPUChainedStruct const * nextInChain;
    WGPUTextureSampleType sampleType;
    WGPUTextureViewDimension viewDimension;
    WGPUBool multisampled;
} WGPUTextureBindingLayout WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_TEXTURE_BINDING_LAYOUT_INIT WGPU_MAKE_INIT_STRUCT(WGPUTextureBindingLayout, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.sampleType=*/WGPUTextureSampleType_Undefined WGPU_COMMA \
    /*.viewDimension=*/WGPUTextureViewDimension_2D WGPU_COMMA \
    /*.multisampled=*/false WGPU_COMMA \
})

// Can be chained in WGPUTextureDescriptor
typedef struct WGPUTextureBindingViewDimensionDescriptor {
    WGPUChainedStruct chain;
    WGPUTextureViewDimension textureBindingViewDimension;
} WGPUTextureBindingViewDimensionDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_TEXTURE_BINDING_VIEW_DIMENSION_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUTextureBindingViewDimensionDescriptor, { \
    /*.chain=*/{/*.nextInChain*/nullptr WGPU_COMMA /*.sType*/WGPUSType_TextureBindingViewDimensionDescriptor} WGPU_COMMA \
    /*.textureBindingViewDimension=*/WGPUTextureViewDimension_Undefined WGPU_COMMA \
})

typedef struct WGPUTextureDataLayout {
    WGPUChainedStruct const * nextInChain;
    uint64_t offset;
    uint32_t bytesPerRow;
    uint32_t rowsPerImage;
} WGPUTextureDataLayout WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_TEXTURE_DATA_LAYOUT_INIT WGPU_MAKE_INIT_STRUCT(WGPUTextureDataLayout, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.offset=*/0 WGPU_COMMA \
    /*.bytesPerRow=*/WGPU_COPY_STRIDE_UNDEFINED WGPU_COMMA \
    /*.rowsPerImage=*/WGPU_COPY_STRIDE_UNDEFINED WGPU_COMMA \
})

typedef struct WGPUUncapturedErrorCallbackInfo {
    WGPUChainedStruct const * nextInChain;
    WGPUErrorCallback callback;
    void * userdata;
} WGPUUncapturedErrorCallbackInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_UNCAPTURED_ERROR_CALLBACK_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUUncapturedErrorCallbackInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.callback=*/nullptr WGPU_COMMA \
    /*.userdata=*/nullptr WGPU_COMMA \
})

typedef struct WGPUVertexAttribute {
    WGPUVertexFormat format;
    uint64_t offset;
    uint32_t shaderLocation;
} WGPUVertexAttribute WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_VERTEX_ATTRIBUTE_INIT WGPU_MAKE_INIT_STRUCT(WGPUVertexAttribute, { \
    /*.format=*/{} WGPU_COMMA \
    /*.offset=*/{} WGPU_COMMA \
    /*.shaderLocation=*/{} WGPU_COMMA \
})

typedef struct WGPUAdapterInfo {
    WGPUChainedStructOut * nextInChain;
    WGPUStringView vendor;
    WGPUStringView architecture;
    WGPUStringView device;
    WGPUStringView description;
    WGPUBackendType backendType;
    WGPUAdapterType adapterType;
    uint32_t vendorID;
    uint32_t deviceID;
    WGPUBool compatibilityMode;
} WGPUAdapterInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_ADAPTER_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUAdapterInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.vendor=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.architecture=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.device=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.description=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.backendType=*/{} WGPU_COMMA \
    /*.adapterType=*/{} WGPU_COMMA \
    /*.vendorID=*/{} WGPU_COMMA \
    /*.deviceID=*/{} WGPU_COMMA \
    /*.compatibilityMode=*/false WGPU_COMMA \
})

typedef struct WGPUBindGroupDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    WGPUBindGroupLayout layout;
    size_t entryCount;
    WGPUBindGroupEntry const * entries;
} WGPUBindGroupDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BIND_GROUP_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUBindGroupDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.layout=*/{} WGPU_COMMA \
    /*.entryCount=*/{} WGPU_COMMA \
    /*.entries=*/{} WGPU_COMMA \
})

typedef struct WGPUBindGroupLayoutEntry {
    WGPUChainedStruct const * nextInChain;
    uint32_t binding;
    WGPUShaderStage visibility;
    WGPUBufferBindingLayout buffer;
    WGPUSamplerBindingLayout sampler;
    WGPUTextureBindingLayout texture;
    WGPUStorageTextureBindingLayout storageTexture;
} WGPUBindGroupLayoutEntry WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BIND_GROUP_LAYOUT_ENTRY_INIT WGPU_MAKE_INIT_STRUCT(WGPUBindGroupLayoutEntry, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.binding=*/{} WGPU_COMMA \
    /*.visibility=*/{} WGPU_COMMA \
    /*.buffer=*/WGPU_BUFFER_BINDING_LAYOUT_INIT WGPU_COMMA \
    /*.sampler=*/WGPU_SAMPLER_BINDING_LAYOUT_INIT WGPU_COMMA \
    /*.texture=*/WGPU_TEXTURE_BINDING_LAYOUT_INIT WGPU_COMMA \
    /*.storageTexture=*/WGPU_STORAGE_TEXTURE_BINDING_LAYOUT_INIT WGPU_COMMA \
})

typedef struct WGPUBlendState {
    WGPUBlendComponent color;
    WGPUBlendComponent alpha;
} WGPUBlendState WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BLEND_STATE_INIT WGPU_MAKE_INIT_STRUCT(WGPUBlendState, { \
    /*.color=*/WGPU_BLEND_COMPONENT_INIT WGPU_COMMA \
    /*.alpha=*/WGPU_BLEND_COMPONENT_INIT WGPU_COMMA \
})

typedef struct WGPUBufferDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    WGPUBufferUsage usage;
    uint64_t size;
    WGPUBool mappedAtCreation;
} WGPUBufferDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BUFFER_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUBufferDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.usage=*/{} WGPU_COMMA \
    /*.size=*/{} WGPU_COMMA \
    /*.mappedAtCreation=*/false WGPU_COMMA \
})

typedef struct WGPUCommandBufferDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
} WGPUCommandBufferDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COMMAND_BUFFER_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUCommandBufferDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
})

typedef struct WGPUCommandEncoderDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
} WGPUCommandEncoderDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COMMAND_ENCODER_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUCommandEncoderDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
})

typedef struct WGPUCompilationMessage {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView message;
    WGPUCompilationMessageType type;
    uint64_t lineNum;
    uint64_t linePos;
    uint64_t offset;
    uint64_t length;
    uint64_t utf16LinePos;
    uint64_t utf16Offset;
    uint64_t utf16Length;
} WGPUCompilationMessage WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COMPILATION_MESSAGE_INIT WGPU_MAKE_INIT_STRUCT(WGPUCompilationMessage, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.message=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.type=*/{} WGPU_COMMA \
    /*.lineNum=*/{} WGPU_COMMA \
    /*.linePos=*/{} WGPU_COMMA \
    /*.offset=*/{} WGPU_COMMA \
    /*.length=*/{} WGPU_COMMA \
    /*.utf16LinePos=*/{} WGPU_COMMA \
    /*.utf16Offset=*/{} WGPU_COMMA \
    /*.utf16Length=*/{} WGPU_COMMA \
})

typedef struct WGPUComputePassDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    WGPU_NULLABLE WGPUComputePassTimestampWrites const * timestampWrites;
} WGPUComputePassDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COMPUTE_PASS_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUComputePassDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.timestampWrites=*/nullptr WGPU_COMMA \
})

typedef struct WGPUConstantEntry {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView key;
    double value;
} WGPUConstantEntry WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_CONSTANT_ENTRY_INIT WGPU_MAKE_INIT_STRUCT(WGPUConstantEntry, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.key=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.value=*/{} WGPU_COMMA \
})

typedef struct WGPUDepthStencilState {
    WGPUChainedStruct const * nextInChain;
    WGPUTextureFormat format;
    WGPUOptionalBool depthWriteEnabled;
    WGPUCompareFunction depthCompare;
    WGPUStencilFaceState stencilFront;
    WGPUStencilFaceState stencilBack;
    uint32_t stencilReadMask;
    uint32_t stencilWriteMask;
    int32_t depthBias;
    float depthBiasSlopeScale;
    float depthBiasClamp;
} WGPUDepthStencilState WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_DEPTH_STENCIL_STATE_INIT WGPU_MAKE_INIT_STRUCT(WGPUDepthStencilState, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.format=*/{} WGPU_COMMA \
    /*.depthWriteEnabled=*/WGPUOptionalBool_Undefined WGPU_COMMA \
    /*.depthCompare=*/WGPUCompareFunction_Undefined WGPU_COMMA \
    /*.stencilFront=*/WGPU_STENCIL_FACE_STATE_INIT WGPU_COMMA \
    /*.stencilBack=*/WGPU_STENCIL_FACE_STATE_INIT WGPU_COMMA \
    /*.stencilReadMask=*/0xFFFFFFFF WGPU_COMMA \
    /*.stencilWriteMask=*/0xFFFFFFFF WGPU_COMMA \
    /*.depthBias=*/0 WGPU_COMMA \
    /*.depthBiasSlopeScale=*/0.0f WGPU_COMMA \
    /*.depthBiasClamp=*/0.0f WGPU_COMMA \
})

typedef struct WGPUFutureWaitInfo {
    WGPUFuture future;
    WGPUBool completed;
} WGPUFutureWaitInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_FUTURE_WAIT_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUFutureWaitInfo, { \
    /*.future=*/WGPU_FUTURE_INIT WGPU_COMMA \
    /*.completed=*/false WGPU_COMMA \
})

typedef struct WGPUImageCopyBuffer {
    WGPUTextureDataLayout layout;
    WGPUBuffer buffer;
} WGPUImageCopyBuffer WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_IMAGE_COPY_BUFFER_INIT WGPU_MAKE_INIT_STRUCT(WGPUImageCopyBuffer, { \
    /*.layout=*/WGPU_TEXTURE_DATA_LAYOUT_INIT WGPU_COMMA \
    /*.buffer=*/{} WGPU_COMMA \
})

typedef struct WGPUImageCopyTexture {
    WGPUTexture texture;
    uint32_t mipLevel;
    WGPUOrigin3D origin;
    WGPUTextureAspect aspect;
} WGPUImageCopyTexture WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_IMAGE_COPY_TEXTURE_INIT WGPU_MAKE_INIT_STRUCT(WGPUImageCopyTexture, { \
    /*.texture=*/{} WGPU_COMMA \
    /*.mipLevel=*/0 WGPU_COMMA \
    /*.origin=*/WGPU_ORIGIN_3D_INIT WGPU_COMMA \
    /*.aspect=*/WGPUTextureAspect_All WGPU_COMMA \
})

typedef struct WGPUInstanceDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUInstanceFeatures features;
} WGPUInstanceDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_INSTANCE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUInstanceDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.features=*/WGPU_INSTANCE_FEATURES_INIT WGPU_COMMA \
})

typedef struct WGPUPipelineLayoutDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    size_t bindGroupLayoutCount;
    WGPU_NULLABLE WGPUBindGroupLayout const * bindGroupLayouts;
    uint32_t immediateDataRangeByteSize;
} WGPUPipelineLayoutDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_PIPELINE_LAYOUT_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUPipelineLayoutDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.bindGroupLayoutCount=*/{} WGPU_COMMA \
    /*.bindGroupLayouts=*/nullptr WGPU_COMMA \
    /*.immediateDataRangeByteSize=*/0 WGPU_COMMA \
})

typedef struct WGPUQuerySetDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    WGPUQueryType type;
    uint32_t count;
} WGPUQuerySetDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_QUERY_SET_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUQuerySetDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.type=*/{} WGPU_COMMA \
    /*.count=*/{} WGPU_COMMA \
})

typedef struct WGPUQueueDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
} WGPUQueueDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_QUEUE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUQueueDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
})

typedef struct WGPURenderBundleDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
} WGPURenderBundleDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_RENDER_BUNDLE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPURenderBundleDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
})

typedef struct WGPURenderBundleEncoderDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    size_t colorFormatCount;
    WGPUTextureFormat const * colorFormats;
    WGPUTextureFormat depthStencilFormat;
    uint32_t sampleCount;
    WGPUBool depthReadOnly;
    WGPUBool stencilReadOnly;
} WGPURenderBundleEncoderDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_RENDER_BUNDLE_ENCODER_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPURenderBundleEncoderDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.colorFormatCount=*/{} WGPU_COMMA \
    /*.colorFormats=*/{} WGPU_COMMA \
    /*.depthStencilFormat=*/WGPUTextureFormat_Undefined WGPU_COMMA \
    /*.sampleCount=*/1 WGPU_COMMA \
    /*.depthReadOnly=*/false WGPU_COMMA \
    /*.stencilReadOnly=*/false WGPU_COMMA \
})

typedef struct WGPURenderPassColorAttachment {
    WGPUChainedStruct const * nextInChain;
    WGPU_NULLABLE WGPUTextureView view;
    uint32_t depthSlice;
    WGPU_NULLABLE WGPUTextureView resolveTarget;
    WGPULoadOp loadOp;
    WGPUStoreOp storeOp;
    WGPUColor clearValue;
} WGPURenderPassColorAttachment WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_RENDER_PASS_COLOR_ATTACHMENT_INIT WGPU_MAKE_INIT_STRUCT(WGPURenderPassColorAttachment, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.view=*/nullptr WGPU_COMMA \
    /*.depthSlice=*/WGPU_DEPTH_SLICE_UNDEFINED WGPU_COMMA \
    /*.resolveTarget=*/nullptr WGPU_COMMA \
    /*.loadOp=*/{} WGPU_COMMA \
    /*.storeOp=*/{} WGPU_COMMA \
    /*.clearValue=*/WGPU_COLOR_INIT WGPU_COMMA \
})

typedef struct WGPURequiredLimits {
    WGPUChainedStruct const * nextInChain;
    WGPULimits limits;
} WGPURequiredLimits WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_REQUIRED_LIMITS_INIT WGPU_MAKE_INIT_STRUCT(WGPURequiredLimits, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.limits=*/WGPU_LIMITS_INIT WGPU_COMMA \
})

typedef struct WGPUSamplerDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    WGPUAddressMode addressModeU;
    WGPUAddressMode addressModeV;
    WGPUAddressMode addressModeW;
    WGPUFilterMode magFilter;
    WGPUFilterMode minFilter;
    WGPUMipmapFilterMode mipmapFilter;
    float lodMinClamp;
    float lodMaxClamp;
    WGPUCompareFunction compare;
    uint16_t maxAnisotropy;
} WGPUSamplerDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SAMPLER_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUSamplerDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.addressModeU=*/WGPUAddressMode_ClampToEdge WGPU_COMMA \
    /*.addressModeV=*/WGPUAddressMode_ClampToEdge WGPU_COMMA \
    /*.addressModeW=*/WGPUAddressMode_ClampToEdge WGPU_COMMA \
    /*.magFilter=*/WGPUFilterMode_Nearest WGPU_COMMA \
    /*.minFilter=*/WGPUFilterMode_Nearest WGPU_COMMA \
    /*.mipmapFilter=*/WGPUMipmapFilterMode_Nearest WGPU_COMMA \
    /*.lodMinClamp=*/0.0f WGPU_COMMA \
    /*.lodMaxClamp=*/32.0f WGPU_COMMA \
    /*.compare=*/WGPUCompareFunction_Undefined WGPU_COMMA \
    /*.maxAnisotropy=*/1 WGPU_COMMA \
})

typedef struct WGPUShaderModuleDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
} WGPUShaderModuleDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SHADER_MODULE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUShaderModuleDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
})

// Can be chained in WGPUShaderModuleDescriptor
typedef struct WGPUShaderSourceWGSL {
    WGPUChainedStruct chain;
    WGPUStringView code;
} WGPUShaderSourceWGSL WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SHADER_SOURCE_WGSL_INIT WGPU_MAKE_INIT_STRUCT(WGPUShaderSourceWGSL, { \
    /*.chain=*/{/*.nextInChain*/nullptr WGPU_COMMA /*.sType*/WGPUSType_ShaderSourceWGSL} WGPU_COMMA \
    /*.code=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
})

typedef struct WGPUSupportedLimits {
    WGPUChainedStructOut * nextInChain;
    WGPULimits limits;
} WGPUSupportedLimits WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SUPPORTED_LIMITS_INIT WGPU_MAKE_INIT_STRUCT(WGPUSupportedLimits, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.limits=*/WGPU_LIMITS_INIT WGPU_COMMA \
})

typedef struct WGPUSurfaceDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
} WGPUSurfaceDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SURFACE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUSurfaceDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
})

// Can be chained in WGPUSurfaceDescriptor
typedef struct WGPUSurfaceSourceCanvasHTMLSelector_Emscripten {
    WGPUChainedStruct chain;
    WGPUStringView selector;
} WGPUSurfaceSourceCanvasHTMLSelector_Emscripten WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_SURFACE_SOURCE_CANVAS_HTML_SELECTOR__EMSCRIPTEN_INIT WGPU_MAKE_INIT_STRUCT(WGPUSurfaceSourceCanvasHTMLSelector_Emscripten, { \
    /*.chain=*/{/*.nextInChain*/nullptr WGPU_COMMA /*.sType*/WGPUSType_SurfaceSourceCanvasHTMLSelector_Emscripten} WGPU_COMMA \
    /*.selector=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
})

typedef struct WGPUTextureDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    WGPUTextureUsage usage;
    WGPUTextureDimension dimension;
    WGPUExtent3D size;
    WGPUTextureFormat format;
    uint32_t mipLevelCount;
    uint32_t sampleCount;
    size_t viewFormatCount;
    WGPUTextureFormat const * viewFormats;
} WGPUTextureDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_TEXTURE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUTextureDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.usage=*/{} WGPU_COMMA \
    /*.dimension=*/WGPUTextureDimension_2D WGPU_COMMA \
    /*.size=*/WGPU_EXTENT_3D_INIT WGPU_COMMA \
    /*.format=*/{} WGPU_COMMA \
    /*.mipLevelCount=*/1 WGPU_COMMA \
    /*.sampleCount=*/1 WGPU_COMMA \
    /*.viewFormatCount=*/0 WGPU_COMMA \
    /*.viewFormats=*/nullptr WGPU_COMMA \
})

typedef struct WGPUTextureViewDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    WGPUTextureFormat format;
    WGPUTextureViewDimension dimension;
    uint32_t baseMipLevel;
    uint32_t mipLevelCount;
    uint32_t baseArrayLayer;
    uint32_t arrayLayerCount;
    WGPUTextureAspect aspect;
    WGPUTextureUsage usage;
} WGPUTextureViewDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_TEXTURE_VIEW_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUTextureViewDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.format=*/WGPUTextureFormat_Undefined WGPU_COMMA \
    /*.dimension=*/WGPUTextureViewDimension_Undefined WGPU_COMMA \
    /*.baseMipLevel=*/0 WGPU_COMMA \
    /*.mipLevelCount=*/WGPU_MIP_LEVEL_COUNT_UNDEFINED WGPU_COMMA \
    /*.baseArrayLayer=*/0 WGPU_COMMA \
    /*.arrayLayerCount=*/WGPU_ARRAY_LAYER_COUNT_UNDEFINED WGPU_COMMA \
    /*.aspect=*/WGPUTextureAspect_All WGPU_COMMA \
    /*.usage=*/WGPUTextureUsage_None WGPU_COMMA \
})

typedef struct WGPUVertexBufferLayout {
    uint64_t arrayStride;
    WGPUVertexStepMode stepMode;
    size_t attributeCount;
    WGPUVertexAttribute const * attributes;
} WGPUVertexBufferLayout WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_VERTEX_BUFFER_LAYOUT_INIT WGPU_MAKE_INIT_STRUCT(WGPUVertexBufferLayout, { \
    /*.arrayStride=*/{} WGPU_COMMA \
    /*.stepMode=*/{} WGPU_COMMA \
    /*.attributeCount=*/{} WGPU_COMMA \
    /*.attributes=*/{} WGPU_COMMA \
})

typedef struct WGPUBindGroupLayoutDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    size_t entryCount;
    WGPUBindGroupLayoutEntry const * entries;
} WGPUBindGroupLayoutDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_BIND_GROUP_LAYOUT_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUBindGroupLayoutDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.entryCount=*/{} WGPU_COMMA \
    /*.entries=*/{} WGPU_COMMA \
})

typedef struct WGPUColorTargetState {
    WGPUChainedStruct const * nextInChain;
    WGPUTextureFormat format;
    WGPU_NULLABLE WGPUBlendState const * blend;
    WGPUColorWriteMask writeMask;
} WGPUColorTargetState WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COLOR_TARGET_STATE_INIT WGPU_MAKE_INIT_STRUCT(WGPUColorTargetState, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.format=*/{} WGPU_COMMA \
    /*.blend=*/nullptr WGPU_COMMA \
    /*.writeMask=*/WGPUColorWriteMask_All WGPU_COMMA \
})

typedef struct WGPUCompilationInfo {
    WGPUChainedStruct const * nextInChain;
    size_t messageCount;
    WGPUCompilationMessage const * messages;
} WGPUCompilationInfo WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COMPILATION_INFO_INIT WGPU_MAKE_INIT_STRUCT(WGPUCompilationInfo, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.messageCount=*/{} WGPU_COMMA \
    /*.messages=*/{} WGPU_COMMA \
})

typedef struct WGPUDeviceDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    size_t requiredFeatureCount;
    WGPUFeatureName const * requiredFeatures;
    WGPU_NULLABLE WGPURequiredLimits const * requiredLimits;
    WGPUQueueDescriptor defaultQueue;
    WGPUDeviceLostCallbackInfo deviceLostCallbackInfo;
    WGPUUncapturedErrorCallbackInfo uncapturedErrorCallbackInfo;
    WGPUDeviceLostCallbackInfo2 deviceLostCallbackInfo2;
    WGPUUncapturedErrorCallbackInfo2 uncapturedErrorCallbackInfo2;
} WGPUDeviceDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_DEVICE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUDeviceDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.requiredFeatureCount=*/0 WGPU_COMMA \
    /*.requiredFeatures=*/nullptr WGPU_COMMA \
    /*.requiredLimits=*/nullptr WGPU_COMMA \
    /*.defaultQueue=*/WGPU_QUEUE_DESCRIPTOR_INIT WGPU_COMMA \
    /*.deviceLostCallbackInfo=*/WGPU_DEVICE_LOST_CALLBACK_INFO_INIT WGPU_COMMA \
    /*.uncapturedErrorCallbackInfo=*/WGPU_UNCAPTURED_ERROR_CALLBACK_INFO_INIT WGPU_COMMA \
    /*.deviceLostCallbackInfo2=*/{} WGPU_COMMA \
    /*.uncapturedErrorCallbackInfo2=*/{} WGPU_COMMA \
})

typedef struct WGPUProgrammableStageDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUShaderModule module;
    WGPUStringView entryPoint;
    size_t constantCount;
    WGPUConstantEntry const * constants;
} WGPUProgrammableStageDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_PROGRAMMABLE_STAGE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUProgrammableStageDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.module=*/{} WGPU_COMMA \
    /*.entryPoint=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.constantCount=*/0 WGPU_COMMA \
    /*.constants=*/{} WGPU_COMMA \
})

typedef struct WGPURenderPassDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    size_t colorAttachmentCount;
    WGPURenderPassColorAttachment const * colorAttachments;
    WGPU_NULLABLE WGPURenderPassDepthStencilAttachment const * depthStencilAttachment;
    WGPU_NULLABLE WGPUQuerySet occlusionQuerySet;
    WGPU_NULLABLE WGPURenderPassTimestampWrites const * timestampWrites;
} WGPURenderPassDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_RENDER_PASS_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPURenderPassDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.colorAttachmentCount=*/{} WGPU_COMMA \
    /*.colorAttachments=*/{} WGPU_COMMA \
    /*.depthStencilAttachment=*/nullptr WGPU_COMMA \
    /*.occlusionQuerySet=*/nullptr WGPU_COMMA \
    /*.timestampWrites=*/nullptr WGPU_COMMA \
})

typedef struct WGPUVertexState {
    WGPUChainedStruct const * nextInChain;
    WGPUShaderModule module;
    WGPUStringView entryPoint;
    size_t constantCount;
    WGPUConstantEntry const * constants;
    size_t bufferCount;
    WGPUVertexBufferLayout const * buffers;
} WGPUVertexState WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_VERTEX_STATE_INIT WGPU_MAKE_INIT_STRUCT(WGPUVertexState, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.module=*/{} WGPU_COMMA \
    /*.entryPoint=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.constantCount=*/0 WGPU_COMMA \
    /*.constants=*/{} WGPU_COMMA \
    /*.bufferCount=*/0 WGPU_COMMA \
    /*.buffers=*/{} WGPU_COMMA \
})

typedef struct WGPUComputePipelineDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    WGPU_NULLABLE WGPUPipelineLayout layout;
    WGPUProgrammableStageDescriptor compute;
} WGPUComputePipelineDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_COMPUTE_PIPELINE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPUComputePipelineDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.layout=*/nullptr WGPU_COMMA \
    /*.compute=*/WGPU_PROGRAMMABLE_STAGE_DESCRIPTOR_INIT WGPU_COMMA \
})

typedef struct WGPUFragmentState {
    WGPUChainedStruct const * nextInChain;
    WGPUShaderModule module;
    WGPUStringView entryPoint;
    size_t constantCount;
    WGPUConstantEntry const * constants;
    size_t targetCount;
    WGPUColorTargetState const * targets;
} WGPUFragmentState WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_FRAGMENT_STATE_INIT WGPU_MAKE_INIT_STRUCT(WGPUFragmentState, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.module=*/{} WGPU_COMMA \
    /*.entryPoint=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.constantCount=*/0 WGPU_COMMA \
    /*.constants=*/{} WGPU_COMMA \
    /*.targetCount=*/{} WGPU_COMMA \
    /*.targets=*/{} WGPU_COMMA \
})

typedef struct WGPURenderPipelineDescriptor {
    WGPUChainedStruct const * nextInChain;
    WGPUStringView label;
    WGPU_NULLABLE WGPUPipelineLayout layout;
    WGPUVertexState vertex;
    WGPUPrimitiveState primitive;
    WGPU_NULLABLE WGPUDepthStencilState const * depthStencil;
    WGPUMultisampleState multisample;
    WGPU_NULLABLE WGPUFragmentState const * fragment;
} WGPURenderPipelineDescriptor WGPU_STRUCTURE_ATTRIBUTE;

#define WGPU_RENDER_PIPELINE_DESCRIPTOR_INIT WGPU_MAKE_INIT_STRUCT(WGPURenderPipelineDescriptor, { \
    /*.nextInChain=*/nullptr WGPU_COMMA \
    /*.label=*/WGPU_STRING_VIEW_INIT WGPU_COMMA \
    /*.layout=*/nullptr WGPU_COMMA \
    /*.vertex=*/WGPU_VERTEX_STATE_INIT WGPU_COMMA \
    /*.primitive=*/WGPU_PRIMITIVE_STATE_INIT WGPU_COMMA \
    /*.depthStencil=*/nullptr WGPU_COMMA \
    /*.multisample=*/WGPU_MULTISAMPLE_STATE_INIT WGPU_COMMA \
    /*.fragment=*/nullptr WGPU_COMMA \
})

// WGPURenderPassDescriptorMaxDrawCount is deprecated.
// Use WGPURenderPassMaxDrawCount instead.
typedef WGPURenderPassMaxDrawCount WGPURenderPassDescriptorMaxDrawCount;

// WGPUShaderModuleSPIRVDescriptor is deprecated.
// Use WGPUShaderSourceSPIRV instead.
typedef WGPUShaderSourceSPIRV WGPUShaderModuleSPIRVDescriptor;

// WGPUShaderModuleWGSLDescriptor is deprecated.
// Use WGPUShaderSourceWGSL instead.
typedef WGPUShaderSourceWGSL WGPUShaderModuleWGSLDescriptor;

// WGPUSurfaceDescriptorFromCanvasHTMLSelector is deprecated.
// Use WGPUSurfaceSourceCanvasHTMLSelector_Emscripten instead.
typedef WGPUSurfaceSourceCanvasHTMLSelector_Emscripten WGPUSurfaceDescriptorFromCanvasHTMLSelector;

#ifdef __cplusplus
extern "C" {
#endif

#if !defined(WGPU_SKIP_PROCS)

// TODO(374150686): Remove these Emscripten specific declarations from the
// header once they are fully deprecated.
#ifdef __EMSCRIPTEN__
WGPU_EXPORT WGPUDevice emscripten_webgpu_get_device(void);
#endif

typedef void (*WGPUProcAdapterInfoFreeMembers)(        WGPUAdapterInfo value) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUInstance (*WGPUProcCreateInstance)(        WGPU_NULLABLE WGPUInstanceDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUStatus (*WGPUProcGetInstanceFeatures)(        WGPUInstanceFeatures * features) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUProc (*WGPUProcGetProcAddress)(        WGPUStringView procName) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSupportedFeaturesFreeMembers)(        WGPUSupportedFeatures value) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSurfaceCapabilitiesFreeMembers)(        WGPUSurfaceCapabilities value) WGPU_FUNCTION_ATTRIBUTE;

// Procs of Adapter
typedef void (*WGPUProcAdapterGetFeatures)(WGPUAdapter adapter, WGPUSupportedFeatures * features) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUStatus (*WGPUProcAdapterGetInfo)(WGPUAdapter adapter, WGPUAdapterInfo * info) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUStatus (*WGPUProcAdapterGetLimits)(WGPUAdapter adapter, WGPUSupportedLimits * limits) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUBool (*WGPUProcAdapterHasFeature)(WGPUAdapter adapter, WGPUFeatureName feature) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcAdapterRequestDevice)(WGPUAdapter adapter, WGPU_NULLABLE WGPUDeviceDescriptor const * descriptor, WGPURequestDeviceCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcAdapterRequestDevice2)(WGPUAdapter adapter, WGPU_NULLABLE WGPUDeviceDescriptor const * options, WGPURequestDeviceCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcAdapterRequestDeviceF)(WGPUAdapter adapter, WGPU_NULLABLE WGPUDeviceDescriptor const * options, WGPURequestDeviceCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcAdapterAddRef)(WGPUAdapter adapter) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcAdapterRelease)(WGPUAdapter adapter) WGPU_FUNCTION_ATTRIBUTE;

// Procs of BindGroup
typedef void (*WGPUProcBindGroupSetLabel)(WGPUBindGroup bindGroup, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcBindGroupAddRef)(WGPUBindGroup bindGroup) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcBindGroupRelease)(WGPUBindGroup bindGroup) WGPU_FUNCTION_ATTRIBUTE;

// Procs of BindGroupLayout
typedef void (*WGPUProcBindGroupLayoutSetLabel)(WGPUBindGroupLayout bindGroupLayout, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcBindGroupLayoutAddRef)(WGPUBindGroupLayout bindGroupLayout) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcBindGroupLayoutRelease)(WGPUBindGroupLayout bindGroupLayout) WGPU_FUNCTION_ATTRIBUTE;

// Procs of Buffer
typedef void (*WGPUProcBufferDestroy)(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
typedef void const * (*WGPUProcBufferGetConstMappedRange)(WGPUBuffer buffer, size_t offset, size_t size) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUBufferMapState (*WGPUProcBufferGetMapState)(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
typedef void * (*WGPUProcBufferGetMappedRange)(WGPUBuffer buffer, size_t offset, size_t size) WGPU_FUNCTION_ATTRIBUTE;
typedef uint64_t (*WGPUProcBufferGetSize)(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUBufferUsage (*WGPUProcBufferGetUsage)(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcBufferMapAsync)(WGPUBuffer buffer, WGPUMapMode mode, size_t offset, size_t size, WGPUBufferMapCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcBufferMapAsync2)(WGPUBuffer buffer, WGPUMapMode mode, size_t offset, size_t size, WGPUBufferMapCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcBufferMapAsyncF)(WGPUBuffer buffer, WGPUMapMode mode, size_t offset, size_t size, WGPUBufferMapCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcBufferSetLabel)(WGPUBuffer buffer, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcBufferUnmap)(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcBufferAddRef)(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcBufferRelease)(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;

// Procs of CommandBuffer
typedef void (*WGPUProcCommandBufferSetLabel)(WGPUCommandBuffer commandBuffer, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandBufferAddRef)(WGPUCommandBuffer commandBuffer) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandBufferRelease)(WGPUCommandBuffer commandBuffer) WGPU_FUNCTION_ATTRIBUTE;

// Procs of CommandEncoder
typedef WGPUComputePassEncoder (*WGPUProcCommandEncoderBeginComputePass)(WGPUCommandEncoder commandEncoder, WGPU_NULLABLE WGPUComputePassDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPURenderPassEncoder (*WGPUProcCommandEncoderBeginRenderPass)(WGPUCommandEncoder commandEncoder, WGPURenderPassDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderClearBuffer)(WGPUCommandEncoder commandEncoder, WGPUBuffer buffer, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderCopyBufferToBuffer)(WGPUCommandEncoder commandEncoder, WGPUBuffer source, uint64_t sourceOffset, WGPUBuffer destination, uint64_t destinationOffset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderCopyBufferToTexture)(WGPUCommandEncoder commandEncoder, WGPUImageCopyBuffer const * source, WGPUImageCopyTexture const * destination, WGPUExtent3D const * copySize) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderCopyTextureToBuffer)(WGPUCommandEncoder commandEncoder, WGPUImageCopyTexture const * source, WGPUImageCopyBuffer const * destination, WGPUExtent3D const * copySize) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderCopyTextureToTexture)(WGPUCommandEncoder commandEncoder, WGPUImageCopyTexture const * source, WGPUImageCopyTexture const * destination, WGPUExtent3D const * copySize) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUCommandBuffer (*WGPUProcCommandEncoderFinish)(WGPUCommandEncoder commandEncoder, WGPU_NULLABLE WGPUCommandBufferDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderInsertDebugMarker)(WGPUCommandEncoder commandEncoder, WGPUStringView markerLabel) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderPopDebugGroup)(WGPUCommandEncoder commandEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderPushDebugGroup)(WGPUCommandEncoder commandEncoder, WGPUStringView groupLabel) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderResolveQuerySet)(WGPUCommandEncoder commandEncoder, WGPUQuerySet querySet, uint32_t firstQuery, uint32_t queryCount, WGPUBuffer destination, uint64_t destinationOffset) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderSetLabel)(WGPUCommandEncoder commandEncoder, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderWriteTimestamp)(WGPUCommandEncoder commandEncoder, WGPUQuerySet querySet, uint32_t queryIndex) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderAddRef)(WGPUCommandEncoder commandEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcCommandEncoderRelease)(WGPUCommandEncoder commandEncoder) WGPU_FUNCTION_ATTRIBUTE;

// Procs of ComputePassEncoder
typedef void (*WGPUProcComputePassEncoderDispatchWorkgroups)(WGPUComputePassEncoder computePassEncoder, uint32_t workgroupCountX, uint32_t workgroupCountY, uint32_t workgroupCountZ) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderDispatchWorkgroupsIndirect)(WGPUComputePassEncoder computePassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderEnd)(WGPUComputePassEncoder computePassEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderInsertDebugMarker)(WGPUComputePassEncoder computePassEncoder, WGPUStringView markerLabel) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderPopDebugGroup)(WGPUComputePassEncoder computePassEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderPushDebugGroup)(WGPUComputePassEncoder computePassEncoder, WGPUStringView groupLabel) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderSetBindGroup)(WGPUComputePassEncoder computePassEncoder, uint32_t groupIndex, WGPU_NULLABLE WGPUBindGroup group, size_t dynamicOffsetCount, uint32_t const * dynamicOffsets) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderSetLabel)(WGPUComputePassEncoder computePassEncoder, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderSetPipeline)(WGPUComputePassEncoder computePassEncoder, WGPUComputePipeline pipeline) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderWriteTimestamp)(WGPUComputePassEncoder computePassEncoder, WGPUQuerySet querySet, uint32_t queryIndex) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderAddRef)(WGPUComputePassEncoder computePassEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePassEncoderRelease)(WGPUComputePassEncoder computePassEncoder) WGPU_FUNCTION_ATTRIBUTE;

// Procs of ComputePipeline
typedef WGPUBindGroupLayout (*WGPUProcComputePipelineGetBindGroupLayout)(WGPUComputePipeline computePipeline, uint32_t groupIndex) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePipelineSetLabel)(WGPUComputePipeline computePipeline, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePipelineAddRef)(WGPUComputePipeline computePipeline) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcComputePipelineRelease)(WGPUComputePipeline computePipeline) WGPU_FUNCTION_ATTRIBUTE;

// Procs of Device
typedef WGPUBindGroup (*WGPUProcDeviceCreateBindGroup)(WGPUDevice device, WGPUBindGroupDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUBindGroupLayout (*WGPUProcDeviceCreateBindGroupLayout)(WGPUDevice device, WGPUBindGroupLayoutDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUBuffer (*WGPUProcDeviceCreateBuffer)(WGPUDevice device, WGPUBufferDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUCommandEncoder (*WGPUProcDeviceCreateCommandEncoder)(WGPUDevice device, WGPU_NULLABLE WGPUCommandEncoderDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUComputePipeline (*WGPUProcDeviceCreateComputePipeline)(WGPUDevice device, WGPUComputePipelineDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDeviceCreateComputePipelineAsync)(WGPUDevice device, WGPUComputePipelineDescriptor const * descriptor, WGPUCreateComputePipelineAsyncCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcDeviceCreateComputePipelineAsync2)(WGPUDevice device, WGPUComputePipelineDescriptor const * descriptor, WGPUCreateComputePipelineAsyncCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcDeviceCreateComputePipelineAsyncF)(WGPUDevice device, WGPUComputePipelineDescriptor const * descriptor, WGPUCreateComputePipelineAsyncCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUPipelineLayout (*WGPUProcDeviceCreatePipelineLayout)(WGPUDevice device, WGPUPipelineLayoutDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUQuerySet (*WGPUProcDeviceCreateQuerySet)(WGPUDevice device, WGPUQuerySetDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPURenderBundleEncoder (*WGPUProcDeviceCreateRenderBundleEncoder)(WGPUDevice device, WGPURenderBundleEncoderDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPURenderPipeline (*WGPUProcDeviceCreateRenderPipeline)(WGPUDevice device, WGPURenderPipelineDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDeviceCreateRenderPipelineAsync)(WGPUDevice device, WGPURenderPipelineDescriptor const * descriptor, WGPUCreateRenderPipelineAsyncCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcDeviceCreateRenderPipelineAsync2)(WGPUDevice device, WGPURenderPipelineDescriptor const * descriptor, WGPUCreateRenderPipelineAsyncCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcDeviceCreateRenderPipelineAsyncF)(WGPUDevice device, WGPURenderPipelineDescriptor const * descriptor, WGPUCreateRenderPipelineAsyncCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUSampler (*WGPUProcDeviceCreateSampler)(WGPUDevice device, WGPU_NULLABLE WGPUSamplerDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUShaderModule (*WGPUProcDeviceCreateShaderModule)(WGPUDevice device, WGPUShaderModuleDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUTexture (*WGPUProcDeviceCreateTexture)(WGPUDevice device, WGPUTextureDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDeviceDestroy)(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUStatus (*WGPUProcDeviceGetAdapterInfo)(WGPUDevice device, WGPUAdapterInfo * adapterInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDeviceGetFeatures)(WGPUDevice device, WGPUSupportedFeatures * features) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUStatus (*WGPUProcDeviceGetLimits)(WGPUDevice device, WGPUSupportedLimits * limits) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcDeviceGetLostFuture)(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUQueue (*WGPUProcDeviceGetQueue)(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUBool (*WGPUProcDeviceHasFeature)(WGPUDevice device, WGPUFeatureName feature) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDevicePopErrorScope)(WGPUDevice device, WGPUErrorCallback oldCallback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcDevicePopErrorScope2)(WGPUDevice device, WGPUPopErrorScopeCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcDevicePopErrorScopeF)(WGPUDevice device, WGPUPopErrorScopeCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDevicePushErrorScope)(WGPUDevice device, WGPUErrorFilter filter) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDeviceSetLabel)(WGPUDevice device, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDeviceSetUncapturedErrorCallback)(WGPUDevice device, WGPUErrorCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDeviceAddRef)(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcDeviceRelease)(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;

// Procs of Instance
typedef WGPUSurface (*WGPUProcInstanceCreateSurface)(WGPUInstance instance, WGPUSurfaceDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef size_t (*WGPUProcInstanceEnumerateWGSLLanguageFeatures)(WGPUInstance instance, WGPUWGSLFeatureName * features) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUBool (*WGPUProcInstanceHasWGSLLanguageFeature)(WGPUInstance instance, WGPUWGSLFeatureName feature) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcInstanceProcessEvents)(WGPUInstance instance) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcInstanceRequestAdapter)(WGPUInstance instance, WGPU_NULLABLE WGPURequestAdapterOptions const * options, WGPURequestAdapterCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcInstanceRequestAdapter2)(WGPUInstance instance, WGPU_NULLABLE WGPURequestAdapterOptions const * options, WGPURequestAdapterCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcInstanceRequestAdapterF)(WGPUInstance instance, WGPU_NULLABLE WGPURequestAdapterOptions const * options, WGPURequestAdapterCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUWaitStatus (*WGPUProcInstanceWaitAny)(WGPUInstance instance, size_t futureCount, WGPUFutureWaitInfo * futures, uint64_t timeoutNS) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcInstanceAddRef)(WGPUInstance instance) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcInstanceRelease)(WGPUInstance instance) WGPU_FUNCTION_ATTRIBUTE;

// Procs of PipelineLayout
typedef void (*WGPUProcPipelineLayoutSetLabel)(WGPUPipelineLayout pipelineLayout, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcPipelineLayoutAddRef)(WGPUPipelineLayout pipelineLayout) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcPipelineLayoutRelease)(WGPUPipelineLayout pipelineLayout) WGPU_FUNCTION_ATTRIBUTE;

// Procs of QuerySet
typedef void (*WGPUProcQuerySetDestroy)(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;
typedef uint32_t (*WGPUProcQuerySetGetCount)(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUQueryType (*WGPUProcQuerySetGetType)(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcQuerySetSetLabel)(WGPUQuerySet querySet, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcQuerySetAddRef)(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcQuerySetRelease)(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;

// Procs of Queue
typedef WGPUFuture (*WGPUProcQueueOnSubmittedWorkDone2)(WGPUQueue queue, WGPUQueueWorkDoneCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcQueueOnSubmittedWorkDoneF)(WGPUQueue queue, WGPUQueueWorkDoneCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcQueueSetLabel)(WGPUQueue queue, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcQueueSubmit)(WGPUQueue queue, size_t commandCount, WGPUCommandBuffer const * commands) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcQueueWriteBuffer)(WGPUQueue queue, WGPUBuffer buffer, uint64_t bufferOffset, void const * data, size_t size) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcQueueWriteTexture)(WGPUQueue queue, WGPUImageCopyTexture const * destination, void const * data, size_t dataSize, WGPUTextureDataLayout const * dataLayout, WGPUExtent3D const * writeSize) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcQueueAddRef)(WGPUQueue queue) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcQueueRelease)(WGPUQueue queue) WGPU_FUNCTION_ATTRIBUTE;

// Procs of RenderBundle
typedef void (*WGPUProcRenderBundleSetLabel)(WGPURenderBundle renderBundle, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleAddRef)(WGPURenderBundle renderBundle) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleRelease)(WGPURenderBundle renderBundle) WGPU_FUNCTION_ATTRIBUTE;

// Procs of RenderBundleEncoder
typedef void (*WGPUProcRenderBundleEncoderDraw)(WGPURenderBundleEncoder renderBundleEncoder, uint32_t vertexCount, uint32_t instanceCount, uint32_t firstVertex, uint32_t firstInstance) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderDrawIndexed)(WGPURenderBundleEncoder renderBundleEncoder, uint32_t indexCount, uint32_t instanceCount, uint32_t firstIndex, int32_t baseVertex, uint32_t firstInstance) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderDrawIndexedIndirect)(WGPURenderBundleEncoder renderBundleEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderDrawIndirect)(WGPURenderBundleEncoder renderBundleEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPURenderBundle (*WGPUProcRenderBundleEncoderFinish)(WGPURenderBundleEncoder renderBundleEncoder, WGPU_NULLABLE WGPURenderBundleDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderInsertDebugMarker)(WGPURenderBundleEncoder renderBundleEncoder, WGPUStringView markerLabel) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderPopDebugGroup)(WGPURenderBundleEncoder renderBundleEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderPushDebugGroup)(WGPURenderBundleEncoder renderBundleEncoder, WGPUStringView groupLabel) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderSetBindGroup)(WGPURenderBundleEncoder renderBundleEncoder, uint32_t groupIndex, WGPU_NULLABLE WGPUBindGroup group, size_t dynamicOffsetCount, uint32_t const * dynamicOffsets) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderSetIndexBuffer)(WGPURenderBundleEncoder renderBundleEncoder, WGPUBuffer buffer, WGPUIndexFormat format, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderSetLabel)(WGPURenderBundleEncoder renderBundleEncoder, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderSetPipeline)(WGPURenderBundleEncoder renderBundleEncoder, WGPURenderPipeline pipeline) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderSetVertexBuffer)(WGPURenderBundleEncoder renderBundleEncoder, uint32_t slot, WGPU_NULLABLE WGPUBuffer buffer, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderAddRef)(WGPURenderBundleEncoder renderBundleEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderBundleEncoderRelease)(WGPURenderBundleEncoder renderBundleEncoder) WGPU_FUNCTION_ATTRIBUTE;

// Procs of RenderPassEncoder
typedef void (*WGPUProcRenderPassEncoderBeginOcclusionQuery)(WGPURenderPassEncoder renderPassEncoder, uint32_t queryIndex) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderDraw)(WGPURenderPassEncoder renderPassEncoder, uint32_t vertexCount, uint32_t instanceCount, uint32_t firstVertex, uint32_t firstInstance) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderDrawIndexed)(WGPURenderPassEncoder renderPassEncoder, uint32_t indexCount, uint32_t instanceCount, uint32_t firstIndex, int32_t baseVertex, uint32_t firstInstance) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderDrawIndexedIndirect)(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderDrawIndirect)(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderEnd)(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderEndOcclusionQuery)(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderExecuteBundles)(WGPURenderPassEncoder renderPassEncoder, size_t bundleCount, WGPURenderBundle const * bundles) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderInsertDebugMarker)(WGPURenderPassEncoder renderPassEncoder, WGPUStringView markerLabel) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderMultiDrawIndexedIndirect)(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset, uint32_t maxDrawCount, WGPU_NULLABLE WGPUBuffer drawCountBuffer, uint64_t drawCountBufferOffset) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderMultiDrawIndirect)(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset, uint32_t maxDrawCount, WGPU_NULLABLE WGPUBuffer drawCountBuffer, uint64_t drawCountBufferOffset) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderPopDebugGroup)(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderPushDebugGroup)(WGPURenderPassEncoder renderPassEncoder, WGPUStringView groupLabel) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderSetBindGroup)(WGPURenderPassEncoder renderPassEncoder, uint32_t groupIndex, WGPU_NULLABLE WGPUBindGroup group, size_t dynamicOffsetCount, uint32_t const * dynamicOffsets) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderSetBlendConstant)(WGPURenderPassEncoder renderPassEncoder, WGPUColor const * color) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderSetIndexBuffer)(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer buffer, WGPUIndexFormat format, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderSetLabel)(WGPURenderPassEncoder renderPassEncoder, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderSetPipeline)(WGPURenderPassEncoder renderPassEncoder, WGPURenderPipeline pipeline) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderSetScissorRect)(WGPURenderPassEncoder renderPassEncoder, uint32_t x, uint32_t y, uint32_t width, uint32_t height) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderSetStencilReference)(WGPURenderPassEncoder renderPassEncoder, uint32_t reference) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderSetVertexBuffer)(WGPURenderPassEncoder renderPassEncoder, uint32_t slot, WGPU_NULLABLE WGPUBuffer buffer, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderSetViewport)(WGPURenderPassEncoder renderPassEncoder, float x, float y, float width, float height, float minDepth, float maxDepth) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderWriteTimestamp)(WGPURenderPassEncoder renderPassEncoder, WGPUQuerySet querySet, uint32_t queryIndex) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderAddRef)(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPassEncoderRelease)(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;

// Procs of RenderPipeline
typedef WGPUBindGroupLayout (*WGPUProcRenderPipelineGetBindGroupLayout)(WGPURenderPipeline renderPipeline, uint32_t groupIndex) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPipelineSetLabel)(WGPURenderPipeline renderPipeline, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPipelineAddRef)(WGPURenderPipeline renderPipeline) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcRenderPipelineRelease)(WGPURenderPipeline renderPipeline) WGPU_FUNCTION_ATTRIBUTE;

// Procs of Sampler
typedef void (*WGPUProcSamplerSetLabel)(WGPUSampler sampler, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSamplerAddRef)(WGPUSampler sampler) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSamplerRelease)(WGPUSampler sampler) WGPU_FUNCTION_ATTRIBUTE;

// Procs of ShaderModule
typedef void (*WGPUProcShaderModuleGetCompilationInfo)(WGPUShaderModule shaderModule, WGPUCompilationInfoCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcShaderModuleGetCompilationInfo2)(WGPUShaderModule shaderModule, WGPUCompilationInfoCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUFuture (*WGPUProcShaderModuleGetCompilationInfoF)(WGPUShaderModule shaderModule, WGPUCompilationInfoCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcShaderModuleSetLabel)(WGPUShaderModule shaderModule, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcShaderModuleAddRef)(WGPUShaderModule shaderModule) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcShaderModuleRelease)(WGPUShaderModule shaderModule) WGPU_FUNCTION_ATTRIBUTE;

// Procs of Surface
typedef void (*WGPUProcSurfaceConfigure)(WGPUSurface surface, WGPUSurfaceConfiguration const * config) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUStatus (*WGPUProcSurfaceGetCapabilities)(WGPUSurface surface, WGPUAdapter adapter, WGPUSurfaceCapabilities * capabilities) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSurfaceGetCurrentTexture)(WGPUSurface surface, WGPUSurfaceTexture * surfaceTexture) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSurfacePresent)(WGPUSurface surface) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSurfaceSetLabel)(WGPUSurface surface, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSurfaceUnconfigure)(WGPUSurface surface) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSurfaceAddRef)(WGPUSurface surface) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcSurfaceRelease)(WGPUSurface surface) WGPU_FUNCTION_ATTRIBUTE;

// Procs of Texture
typedef WGPUTextureView (*WGPUProcTextureCreateView)(WGPUTexture texture, WGPU_NULLABLE WGPUTextureViewDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcTextureDestroy)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef uint32_t (*WGPUProcTextureGetDepthOrArrayLayers)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUTextureDimension (*WGPUProcTextureGetDimension)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUTextureFormat (*WGPUProcTextureGetFormat)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef uint32_t (*WGPUProcTextureGetHeight)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef uint32_t (*WGPUProcTextureGetMipLevelCount)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef uint32_t (*WGPUProcTextureGetSampleCount)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef WGPUTextureUsage (*WGPUProcTextureGetUsage)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef uint32_t (*WGPUProcTextureGetWidth)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcTextureSetLabel)(WGPUTexture texture, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcTextureAddRef)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcTextureRelease)(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;

// Procs of TextureView
typedef void (*WGPUProcTextureViewSetLabel)(WGPUTextureView textureView, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcTextureViewAddRef)(WGPUTextureView textureView) WGPU_FUNCTION_ATTRIBUTE;
typedef void (*WGPUProcTextureViewRelease)(WGPUTextureView textureView) WGPU_FUNCTION_ATTRIBUTE;


#endif  // !defined(WGPU_SKIP_PROCS)

#if !defined(WGPU_SKIP_DECLARATIONS)

WGPU_EXPORT void wgpuAdapterInfoFreeMembers(WGPUAdapterInfo value) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUInstance wgpuCreateInstance(WGPU_NULLABLE WGPUInstanceDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUStatus wgpuGetInstanceFeatures(WGPUInstanceFeatures * features) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUProc wgpuGetProcAddress(WGPUStringView procName) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSupportedFeaturesFreeMembers(WGPUSupportedFeatures value) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSurfaceCapabilitiesFreeMembers(WGPUSurfaceCapabilities value) WGPU_FUNCTION_ATTRIBUTE;

// Methods of Adapter
WGPU_EXPORT void wgpuAdapterGetFeatures(WGPUAdapter adapter, WGPUSupportedFeatures * features) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUStatus wgpuAdapterGetInfo(WGPUAdapter adapter, WGPUAdapterInfo * info) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUStatus wgpuAdapterGetLimits(WGPUAdapter adapter, WGPUSupportedLimits * limits) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUBool wgpuAdapterHasFeature(WGPUAdapter adapter, WGPUFeatureName feature) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuAdapterRequestDevice(WGPUAdapter adapter, WGPU_NULLABLE WGPUDeviceDescriptor const * descriptor, WGPURequestDeviceCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuAdapterRequestDevice2(WGPUAdapter adapter, WGPU_NULLABLE WGPUDeviceDescriptor const * options, WGPURequestDeviceCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuAdapterRequestDeviceF(WGPUAdapter adapter, WGPU_NULLABLE WGPUDeviceDescriptor const * options, WGPURequestDeviceCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuAdapterAddRef(WGPUAdapter adapter) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuAdapterRelease(WGPUAdapter adapter) WGPU_FUNCTION_ATTRIBUTE;

// Methods of BindGroup
WGPU_EXPORT void wgpuBindGroupSetLabel(WGPUBindGroup bindGroup, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuBindGroupAddRef(WGPUBindGroup bindGroup) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuBindGroupRelease(WGPUBindGroup bindGroup) WGPU_FUNCTION_ATTRIBUTE;

// Methods of BindGroupLayout
WGPU_EXPORT void wgpuBindGroupLayoutSetLabel(WGPUBindGroupLayout bindGroupLayout, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuBindGroupLayoutAddRef(WGPUBindGroupLayout bindGroupLayout) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuBindGroupLayoutRelease(WGPUBindGroupLayout bindGroupLayout) WGPU_FUNCTION_ATTRIBUTE;

// Methods of Buffer
WGPU_EXPORT void wgpuBufferDestroy(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void const * wgpuBufferGetConstMappedRange(WGPUBuffer buffer, size_t offset, size_t size) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUBufferMapState wgpuBufferGetMapState(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void * wgpuBufferGetMappedRange(WGPUBuffer buffer, size_t offset, size_t size) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT uint64_t wgpuBufferGetSize(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUBufferUsage wgpuBufferGetUsage(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuBufferMapAsync(WGPUBuffer buffer, WGPUMapMode mode, size_t offset, size_t size, WGPUBufferMapCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuBufferMapAsync2(WGPUBuffer buffer, WGPUMapMode mode, size_t offset, size_t size, WGPUBufferMapCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuBufferMapAsyncF(WGPUBuffer buffer, WGPUMapMode mode, size_t offset, size_t size, WGPUBufferMapCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuBufferSetLabel(WGPUBuffer buffer, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuBufferUnmap(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuBufferAddRef(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuBufferRelease(WGPUBuffer buffer) WGPU_FUNCTION_ATTRIBUTE;

// Methods of CommandBuffer
WGPU_EXPORT void wgpuCommandBufferSetLabel(WGPUCommandBuffer commandBuffer, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandBufferAddRef(WGPUCommandBuffer commandBuffer) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandBufferRelease(WGPUCommandBuffer commandBuffer) WGPU_FUNCTION_ATTRIBUTE;

// Methods of CommandEncoder
WGPU_EXPORT WGPUComputePassEncoder wgpuCommandEncoderBeginComputePass(WGPUCommandEncoder commandEncoder, WGPU_NULLABLE WGPUComputePassDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPURenderPassEncoder wgpuCommandEncoderBeginRenderPass(WGPUCommandEncoder commandEncoder, WGPURenderPassDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderClearBuffer(WGPUCommandEncoder commandEncoder, WGPUBuffer buffer, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderCopyBufferToBuffer(WGPUCommandEncoder commandEncoder, WGPUBuffer source, uint64_t sourceOffset, WGPUBuffer destination, uint64_t destinationOffset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderCopyBufferToTexture(WGPUCommandEncoder commandEncoder, WGPUImageCopyBuffer const * source, WGPUImageCopyTexture const * destination, WGPUExtent3D const * copySize) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderCopyTextureToBuffer(WGPUCommandEncoder commandEncoder, WGPUImageCopyTexture const * source, WGPUImageCopyBuffer const * destination, WGPUExtent3D const * copySize) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderCopyTextureToTexture(WGPUCommandEncoder commandEncoder, WGPUImageCopyTexture const * source, WGPUImageCopyTexture const * destination, WGPUExtent3D const * copySize) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUCommandBuffer wgpuCommandEncoderFinish(WGPUCommandEncoder commandEncoder, WGPU_NULLABLE WGPUCommandBufferDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderInsertDebugMarker(WGPUCommandEncoder commandEncoder, WGPUStringView markerLabel) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderPopDebugGroup(WGPUCommandEncoder commandEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderPushDebugGroup(WGPUCommandEncoder commandEncoder, WGPUStringView groupLabel) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderResolveQuerySet(WGPUCommandEncoder commandEncoder, WGPUQuerySet querySet, uint32_t firstQuery, uint32_t queryCount, WGPUBuffer destination, uint64_t destinationOffset) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderSetLabel(WGPUCommandEncoder commandEncoder, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderWriteTimestamp(WGPUCommandEncoder commandEncoder, WGPUQuerySet querySet, uint32_t queryIndex) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderAddRef(WGPUCommandEncoder commandEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuCommandEncoderRelease(WGPUCommandEncoder commandEncoder) WGPU_FUNCTION_ATTRIBUTE;

// Methods of ComputePassEncoder
WGPU_EXPORT void wgpuComputePassEncoderDispatchWorkgroups(WGPUComputePassEncoder computePassEncoder, uint32_t workgroupCountX, uint32_t workgroupCountY, uint32_t workgroupCountZ) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderDispatchWorkgroupsIndirect(WGPUComputePassEncoder computePassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderEnd(WGPUComputePassEncoder computePassEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderInsertDebugMarker(WGPUComputePassEncoder computePassEncoder, WGPUStringView markerLabel) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderPopDebugGroup(WGPUComputePassEncoder computePassEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderPushDebugGroup(WGPUComputePassEncoder computePassEncoder, WGPUStringView groupLabel) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderSetBindGroup(WGPUComputePassEncoder computePassEncoder, uint32_t groupIndex, WGPU_NULLABLE WGPUBindGroup group, size_t dynamicOffsetCount, uint32_t const * dynamicOffsets) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderSetLabel(WGPUComputePassEncoder computePassEncoder, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderSetPipeline(WGPUComputePassEncoder computePassEncoder, WGPUComputePipeline pipeline) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderWriteTimestamp(WGPUComputePassEncoder computePassEncoder, WGPUQuerySet querySet, uint32_t queryIndex) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderAddRef(WGPUComputePassEncoder computePassEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePassEncoderRelease(WGPUComputePassEncoder computePassEncoder) WGPU_FUNCTION_ATTRIBUTE;

// Methods of ComputePipeline
WGPU_EXPORT WGPUBindGroupLayout wgpuComputePipelineGetBindGroupLayout(WGPUComputePipeline computePipeline, uint32_t groupIndex) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePipelineSetLabel(WGPUComputePipeline computePipeline, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePipelineAddRef(WGPUComputePipeline computePipeline) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuComputePipelineRelease(WGPUComputePipeline computePipeline) WGPU_FUNCTION_ATTRIBUTE;

// Methods of Device
WGPU_EXPORT WGPUBindGroup wgpuDeviceCreateBindGroup(WGPUDevice device, WGPUBindGroupDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUBindGroupLayout wgpuDeviceCreateBindGroupLayout(WGPUDevice device, WGPUBindGroupLayoutDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUBuffer wgpuDeviceCreateBuffer(WGPUDevice device, WGPUBufferDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUCommandEncoder wgpuDeviceCreateCommandEncoder(WGPUDevice device, WGPU_NULLABLE WGPUCommandEncoderDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUComputePipeline wgpuDeviceCreateComputePipeline(WGPUDevice device, WGPUComputePipelineDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDeviceCreateComputePipelineAsync(WGPUDevice device, WGPUComputePipelineDescriptor const * descriptor, WGPUCreateComputePipelineAsyncCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuDeviceCreateComputePipelineAsync2(WGPUDevice device, WGPUComputePipelineDescriptor const * descriptor, WGPUCreateComputePipelineAsyncCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuDeviceCreateComputePipelineAsyncF(WGPUDevice device, WGPUComputePipelineDescriptor const * descriptor, WGPUCreateComputePipelineAsyncCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUPipelineLayout wgpuDeviceCreatePipelineLayout(WGPUDevice device, WGPUPipelineLayoutDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUQuerySet wgpuDeviceCreateQuerySet(WGPUDevice device, WGPUQuerySetDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPURenderBundleEncoder wgpuDeviceCreateRenderBundleEncoder(WGPUDevice device, WGPURenderBundleEncoderDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPURenderPipeline wgpuDeviceCreateRenderPipeline(WGPUDevice device, WGPURenderPipelineDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDeviceCreateRenderPipelineAsync(WGPUDevice device, WGPURenderPipelineDescriptor const * descriptor, WGPUCreateRenderPipelineAsyncCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuDeviceCreateRenderPipelineAsync2(WGPUDevice device, WGPURenderPipelineDescriptor const * descriptor, WGPUCreateRenderPipelineAsyncCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuDeviceCreateRenderPipelineAsyncF(WGPUDevice device, WGPURenderPipelineDescriptor const * descriptor, WGPUCreateRenderPipelineAsyncCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUSampler wgpuDeviceCreateSampler(WGPUDevice device, WGPU_NULLABLE WGPUSamplerDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUShaderModule wgpuDeviceCreateShaderModule(WGPUDevice device, WGPUShaderModuleDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUTexture wgpuDeviceCreateTexture(WGPUDevice device, WGPUTextureDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDeviceDestroy(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUStatus wgpuDeviceGetAdapterInfo(WGPUDevice device, WGPUAdapterInfo * adapterInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDeviceGetFeatures(WGPUDevice device, WGPUSupportedFeatures * features) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUStatus wgpuDeviceGetLimits(WGPUDevice device, WGPUSupportedLimits * limits) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuDeviceGetLostFuture(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUQueue wgpuDeviceGetQueue(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUBool wgpuDeviceHasFeature(WGPUDevice device, WGPUFeatureName feature) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDevicePopErrorScope(WGPUDevice device, WGPUErrorCallback oldCallback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuDevicePopErrorScope2(WGPUDevice device, WGPUPopErrorScopeCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuDevicePopErrorScopeF(WGPUDevice device, WGPUPopErrorScopeCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDevicePushErrorScope(WGPUDevice device, WGPUErrorFilter filter) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDeviceSetLabel(WGPUDevice device, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDeviceSetUncapturedErrorCallback(WGPUDevice device, WGPUErrorCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDeviceAddRef(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuDeviceRelease(WGPUDevice device) WGPU_FUNCTION_ATTRIBUTE;

// Methods of Instance
WGPU_EXPORT WGPUSurface wgpuInstanceCreateSurface(WGPUInstance instance, WGPUSurfaceDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT size_t wgpuInstanceEnumerateWGSLLanguageFeatures(WGPUInstance instance, WGPUWGSLFeatureName * features) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUBool wgpuInstanceHasWGSLLanguageFeature(WGPUInstance instance, WGPUWGSLFeatureName feature) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuInstanceProcessEvents(WGPUInstance instance) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuInstanceRequestAdapter(WGPUInstance instance, WGPU_NULLABLE WGPURequestAdapterOptions const * options, WGPURequestAdapterCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuInstanceRequestAdapter2(WGPUInstance instance, WGPU_NULLABLE WGPURequestAdapterOptions const * options, WGPURequestAdapterCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuInstanceRequestAdapterF(WGPUInstance instance, WGPU_NULLABLE WGPURequestAdapterOptions const * options, WGPURequestAdapterCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUWaitStatus wgpuInstanceWaitAny(WGPUInstance instance, size_t futureCount, WGPUFutureWaitInfo * futures, uint64_t timeoutNS) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuInstanceAddRef(WGPUInstance instance) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuInstanceRelease(WGPUInstance instance) WGPU_FUNCTION_ATTRIBUTE;

// Methods of PipelineLayout
WGPU_EXPORT void wgpuPipelineLayoutSetLabel(WGPUPipelineLayout pipelineLayout, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuPipelineLayoutAddRef(WGPUPipelineLayout pipelineLayout) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuPipelineLayoutRelease(WGPUPipelineLayout pipelineLayout) WGPU_FUNCTION_ATTRIBUTE;

// Methods of QuerySet
WGPU_EXPORT void wgpuQuerySetDestroy(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT uint32_t wgpuQuerySetGetCount(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUQueryType wgpuQuerySetGetType(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuQuerySetSetLabel(WGPUQuerySet querySet, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuQuerySetAddRef(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuQuerySetRelease(WGPUQuerySet querySet) WGPU_FUNCTION_ATTRIBUTE;

// Methods of Queue
WGPU_EXPORT WGPUFuture wgpuQueueOnSubmittedWorkDone2(WGPUQueue queue, WGPUQueueWorkDoneCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuQueueOnSubmittedWorkDoneF(WGPUQueue queue, WGPUQueueWorkDoneCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuQueueSetLabel(WGPUQueue queue, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuQueueSubmit(WGPUQueue queue, size_t commandCount, WGPUCommandBuffer const * commands) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuQueueWriteBuffer(WGPUQueue queue, WGPUBuffer buffer, uint64_t bufferOffset, void const * data, size_t size) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuQueueWriteTexture(WGPUQueue queue, WGPUImageCopyTexture const * destination, void const * data, size_t dataSize, WGPUTextureDataLayout const * dataLayout, WGPUExtent3D const * writeSize) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuQueueAddRef(WGPUQueue queue) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuQueueRelease(WGPUQueue queue) WGPU_FUNCTION_ATTRIBUTE;

// Methods of RenderBundle
WGPU_EXPORT void wgpuRenderBundleSetLabel(WGPURenderBundle renderBundle, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleAddRef(WGPURenderBundle renderBundle) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleRelease(WGPURenderBundle renderBundle) WGPU_FUNCTION_ATTRIBUTE;

// Methods of RenderBundleEncoder
WGPU_EXPORT void wgpuRenderBundleEncoderDraw(WGPURenderBundleEncoder renderBundleEncoder, uint32_t vertexCount, uint32_t instanceCount, uint32_t firstVertex, uint32_t firstInstance) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderDrawIndexed(WGPURenderBundleEncoder renderBundleEncoder, uint32_t indexCount, uint32_t instanceCount, uint32_t firstIndex, int32_t baseVertex, uint32_t firstInstance) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderDrawIndexedIndirect(WGPURenderBundleEncoder renderBundleEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderDrawIndirect(WGPURenderBundleEncoder renderBundleEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPURenderBundle wgpuRenderBundleEncoderFinish(WGPURenderBundleEncoder renderBundleEncoder, WGPU_NULLABLE WGPURenderBundleDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderInsertDebugMarker(WGPURenderBundleEncoder renderBundleEncoder, WGPUStringView markerLabel) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderPopDebugGroup(WGPURenderBundleEncoder renderBundleEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderPushDebugGroup(WGPURenderBundleEncoder renderBundleEncoder, WGPUStringView groupLabel) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderSetBindGroup(WGPURenderBundleEncoder renderBundleEncoder, uint32_t groupIndex, WGPU_NULLABLE WGPUBindGroup group, size_t dynamicOffsetCount, uint32_t const * dynamicOffsets) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderSetIndexBuffer(WGPURenderBundleEncoder renderBundleEncoder, WGPUBuffer buffer, WGPUIndexFormat format, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderSetLabel(WGPURenderBundleEncoder renderBundleEncoder, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderSetPipeline(WGPURenderBundleEncoder renderBundleEncoder, WGPURenderPipeline pipeline) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderSetVertexBuffer(WGPURenderBundleEncoder renderBundleEncoder, uint32_t slot, WGPU_NULLABLE WGPUBuffer buffer, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderAddRef(WGPURenderBundleEncoder renderBundleEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderBundleEncoderRelease(WGPURenderBundleEncoder renderBundleEncoder) WGPU_FUNCTION_ATTRIBUTE;

// Methods of RenderPassEncoder
WGPU_EXPORT void wgpuRenderPassEncoderBeginOcclusionQuery(WGPURenderPassEncoder renderPassEncoder, uint32_t queryIndex) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderDraw(WGPURenderPassEncoder renderPassEncoder, uint32_t vertexCount, uint32_t instanceCount, uint32_t firstVertex, uint32_t firstInstance) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderDrawIndexed(WGPURenderPassEncoder renderPassEncoder, uint32_t indexCount, uint32_t instanceCount, uint32_t firstIndex, int32_t baseVertex, uint32_t firstInstance) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderDrawIndexedIndirect(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderDrawIndirect(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderEnd(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderEndOcclusionQuery(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderExecuteBundles(WGPURenderPassEncoder renderPassEncoder, size_t bundleCount, WGPURenderBundle const * bundles) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderInsertDebugMarker(WGPURenderPassEncoder renderPassEncoder, WGPUStringView markerLabel) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderMultiDrawIndexedIndirect(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset, uint32_t maxDrawCount, WGPU_NULLABLE WGPUBuffer drawCountBuffer, uint64_t drawCountBufferOffset) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderMultiDrawIndirect(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer indirectBuffer, uint64_t indirectOffset, uint32_t maxDrawCount, WGPU_NULLABLE WGPUBuffer drawCountBuffer, uint64_t drawCountBufferOffset) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderPopDebugGroup(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderPushDebugGroup(WGPURenderPassEncoder renderPassEncoder, WGPUStringView groupLabel) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderSetBindGroup(WGPURenderPassEncoder renderPassEncoder, uint32_t groupIndex, WGPU_NULLABLE WGPUBindGroup group, size_t dynamicOffsetCount, uint32_t const * dynamicOffsets) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderSetBlendConstant(WGPURenderPassEncoder renderPassEncoder, WGPUColor const * color) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderSetIndexBuffer(WGPURenderPassEncoder renderPassEncoder, WGPUBuffer buffer, WGPUIndexFormat format, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderSetLabel(WGPURenderPassEncoder renderPassEncoder, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderSetPipeline(WGPURenderPassEncoder renderPassEncoder, WGPURenderPipeline pipeline) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderSetScissorRect(WGPURenderPassEncoder renderPassEncoder, uint32_t x, uint32_t y, uint32_t width, uint32_t height) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderSetStencilReference(WGPURenderPassEncoder renderPassEncoder, uint32_t reference) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderSetVertexBuffer(WGPURenderPassEncoder renderPassEncoder, uint32_t slot, WGPU_NULLABLE WGPUBuffer buffer, uint64_t offset, uint64_t size) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderSetViewport(WGPURenderPassEncoder renderPassEncoder, float x, float y, float width, float height, float minDepth, float maxDepth) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderWriteTimestamp(WGPURenderPassEncoder renderPassEncoder, WGPUQuerySet querySet, uint32_t queryIndex) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderAddRef(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPassEncoderRelease(WGPURenderPassEncoder renderPassEncoder) WGPU_FUNCTION_ATTRIBUTE;

// Methods of RenderPipeline
WGPU_EXPORT WGPUBindGroupLayout wgpuRenderPipelineGetBindGroupLayout(WGPURenderPipeline renderPipeline, uint32_t groupIndex) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPipelineSetLabel(WGPURenderPipeline renderPipeline, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPipelineAddRef(WGPURenderPipeline renderPipeline) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuRenderPipelineRelease(WGPURenderPipeline renderPipeline) WGPU_FUNCTION_ATTRIBUTE;

// Methods of Sampler
WGPU_EXPORT void wgpuSamplerSetLabel(WGPUSampler sampler, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSamplerAddRef(WGPUSampler sampler) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSamplerRelease(WGPUSampler sampler) WGPU_FUNCTION_ATTRIBUTE;

// Methods of ShaderModule
WGPU_EXPORT void wgpuShaderModuleGetCompilationInfo(WGPUShaderModule shaderModule, WGPUCompilationInfoCallback callback, void * userdata) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuShaderModuleGetCompilationInfo2(WGPUShaderModule shaderModule, WGPUCompilationInfoCallbackInfo2 callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUFuture wgpuShaderModuleGetCompilationInfoF(WGPUShaderModule shaderModule, WGPUCompilationInfoCallbackInfo callbackInfo) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuShaderModuleSetLabel(WGPUShaderModule shaderModule, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuShaderModuleAddRef(WGPUShaderModule shaderModule) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuShaderModuleRelease(WGPUShaderModule shaderModule) WGPU_FUNCTION_ATTRIBUTE;

// Methods of Surface
WGPU_EXPORT void wgpuSurfaceConfigure(WGPUSurface surface, WGPUSurfaceConfiguration const * config) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUStatus wgpuSurfaceGetCapabilities(WGPUSurface surface, WGPUAdapter adapter, WGPUSurfaceCapabilities * capabilities) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSurfaceGetCurrentTexture(WGPUSurface surface, WGPUSurfaceTexture * surfaceTexture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSurfacePresent(WGPUSurface surface) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSurfaceSetLabel(WGPUSurface surface, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSurfaceUnconfigure(WGPUSurface surface) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSurfaceAddRef(WGPUSurface surface) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuSurfaceRelease(WGPUSurface surface) WGPU_FUNCTION_ATTRIBUTE;

// Methods of Texture
WGPU_EXPORT WGPUTextureView wgpuTextureCreateView(WGPUTexture texture, WGPU_NULLABLE WGPUTextureViewDescriptor const * descriptor) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuTextureDestroy(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT uint32_t wgpuTextureGetDepthOrArrayLayers(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUTextureDimension wgpuTextureGetDimension(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUTextureFormat wgpuTextureGetFormat(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT uint32_t wgpuTextureGetHeight(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT uint32_t wgpuTextureGetMipLevelCount(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT uint32_t wgpuTextureGetSampleCount(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT WGPUTextureUsage wgpuTextureGetUsage(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT uint32_t wgpuTextureGetWidth(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuTextureSetLabel(WGPUTexture texture, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuTextureAddRef(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuTextureRelease(WGPUTexture texture) WGPU_FUNCTION_ATTRIBUTE;

// Methods of TextureView
WGPU_EXPORT void wgpuTextureViewSetLabel(WGPUTextureView textureView, WGPUStringView label) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuTextureViewAddRef(WGPUTextureView textureView) WGPU_FUNCTION_ATTRIBUTE;
WGPU_EXPORT void wgpuTextureViewRelease(WGPUTextureView textureView) WGPU_FUNCTION_ATTRIBUTE;


#endif  // !defined(WGPU_SKIP_DECLARATIONS)

#ifdef __cplusplus
} // extern "C"
#endif

#endif // WEBGPU_H_
