{{{
    globalThis.__HAVE_EMDAWNWEBGPU_ENUM_TABLES = true;

    // Constant values used at code-generation time in an Emscripten build.
    // These will not appear in the final build result, so we can just dump
    // every enum here without affecting binary size.
    globalThis.WEBGPU_ENUM_CONSTANT_TABLES = {
        WGSLFeatureName: {
            'ReadonlyAndReadwriteStorageTextures': 1,
            'Packed4x8IntegerDotProduct': 2,
            'UnrestrictedPointerParameters': 3,
            'PointerCompositeAccess': 4,
        },
        AdapterType: {
            'DiscreteGPU': 1,
            'IntegratedGPU': 2,
            'CPU': 3,
            'Unknown': 4,
        },
        AddressMode: {
            'Undefined': 0,
            'ClampToEdge': 1,
            'Repeat': 2,
            'MirrorRepeat': 3,
        },
        BackendType: {
            'Undefined': 0,
            'Null': 1,
            'WebGPU': 2,
            'D3D11': 3,
            'D3D12': 4,
            'Metal': 5,
            'Vulkan': 6,
            'OpenGL': 7,
            'OpenGLES': 8,
        },
        BlendFactor: {
            'Undefined': 0,
            'Zero': 1,
            'One': 2,
            'Src': 3,
            'OneMinusSrc': 4,
            'SrcAlpha': 5,
            'OneMinusSrcAlpha': 6,
            'Dst': 7,
            'OneMinusDst': 8,
            'DstAlpha': 9,
            'OneMinusDstAlpha': 10,
            'SrcAlphaSaturated': 11,
            'Constant': 12,
            'OneMinusConstant': 13,
            'Src1': 14,
            'OneMinusSrc1': 15,
            'Src1Alpha': 16,
            'OneMinusSrc1Alpha': 17,
        },
        BlendOperation: {
            'Undefined': 0,
            'Add': 1,
            'Subtract': 2,
            'ReverseSubtract': 3,
            'Min': 4,
            'Max': 5,
        },
        BufferBindingType: {
            'Undefined': 0,
            'Uniform': 1,
            'Storage': 2,
            'ReadOnlyStorage': 3,
        },
        BufferMapAsyncStatus: {
            'Success': 1,
            'InstanceDropped': 2,
            'ValidationError': 3,
            'Unknown': 4,
            'DeviceLost': 5,
            'DestroyedBeforeCallback': 6,
            'UnmappedBeforeCallback': 7,
            'MappingAlreadyPending': 8,
            'OffsetOutOfRange': 9,
            'SizeOutOfRange': 10,
        },
        BufferMapState: {
            'Unmapped': 1,
            'Pending': 2,
            'Mapped': 3,
        },
        CallbackMode: {
            'WaitAnyOnly': 1,
            'AllowProcessEvents': 2,
            'AllowSpontaneous': 3,
        },
        CompareFunction: {
            'Undefined': 0,
            'Never': 1,
            'Less': 2,
            'Equal': 3,
            'LessEqual': 4,
            'Greater': 5,
            'NotEqual': 6,
            'GreaterEqual': 7,
            'Always': 8,
        },
        CompilationInfoRequestStatus: {
            'Success': 1,
            'InstanceDropped': 2,
            'Error': 3,
            'DeviceLost': 4,
            'Unknown': 5,
        },
        CompilationMessageType: {
            'Error': 1,
            'Warning': 2,
            'Info': 3,
        },
        CompositeAlphaMode: {
            'Auto': 0,
            'Opaque': 1,
            'Premultiplied': 2,
            'Unpremultiplied': 3,
            'Inherit': 4,
        },
        CreatePipelineAsyncStatus: {
            'Success': 1,
            'InstanceDropped': 2,
            'ValidationError': 3,
            'InternalError': 4,
            'DeviceLost': 5,
            'DeviceDestroyed': 6,
            'Unknown': 7,
        },
        CullMode: {
            'Undefined': 0,
            'None': 1,
            'Front': 2,
            'Back': 3,
        },
        DeviceLostReason: {
            'Unknown': 1,
            'Destroyed': 2,
            'InstanceDropped': 3,
            'FailedCreation': 4,
        },
        ErrorFilter: {
            'Validation': 1,
            'OutOfMemory': 2,
            'Internal': 3,
        },
        ErrorType: {
            'NoError': 1,
            'Validation': 2,
            'OutOfMemory': 3,
            'Internal': 4,
            'Unknown': 5,
            'DeviceLost': 6,
        },
        FeatureName: {
            'DepthClipControl': 1,
            'Depth32FloatStencil8': 2,
            'TimestampQuery': 3,
            'TextureCompressionBC': 4,
            'TextureCompressionETC2': 5,
            'TextureCompressionASTC': 6,
            'IndirectFirstInstance': 7,
            'ShaderF16': 8,
            'RG11B10UfloatRenderable': 9,
            'BGRA8UnormStorage': 10,
            'Float32Filterable': 11,
            'Float32Blendable': 12,
            'Subgroups': 13,
            'SubgroupsF16': 14,
        },
        FilterMode: {
            'Undefined': 0,
            'Nearest': 1,
            'Linear': 2,
        },
        FrontFace: {
            'Undefined': 0,
            'CCW': 1,
            'CW': 2,
        },
        IndexFormat: {
            'Undefined': 0,
            'Uint16': 1,
            'Uint32': 2,
        },
        LoadOp: {
            'Undefined': 0,
            'Load': 1,
            'Clear': 2,
        },
        MapAsyncStatus: {
            'Success': 1,
            'InstanceDropped': 2,
            'Error': 3,
            'Aborted': 4,
            'Unknown': 5,
        },
        MipmapFilterMode: {
            'Undefined': 0,
            'Nearest': 1,
            'Linear': 2,
        },
        OptionalBool: {
            'False': 0,
            'True': 1,
            'Undefined': 2,
        },
        PopErrorScopeStatus: {
            'Success': 1,
            'InstanceDropped': 2,
        },
        PowerPreference: {
            'Undefined': 0,
            'LowPower': 1,
            'HighPerformance': 2,
        },
        PresentMode: {
            'Fifo': 1,
            'FifoRelaxed': 2,
            'Immediate': 3,
            'Mailbox': 4,
        },
        PrimitiveTopology: {
            'Undefined': 0,
            'PointList': 1,
            'LineList': 2,
            'LineStrip': 3,
            'TriangleList': 4,
            'TriangleStrip': 5,
        },
        QueryType: {
            'Occlusion': 1,
            'Timestamp': 2,
        },
        QueueWorkDoneStatus: {
            'Success': 1,
            'InstanceDropped': 2,
            'Error': 3,
            'Unknown': 4,
            'DeviceLost': 5,
        },
        RequestAdapterStatus: {
            'Success': 1,
            'InstanceDropped': 2,
            'Unavailable': 3,
            'Error': 4,
            'Unknown': 5,
        },
        RequestDeviceStatus: {
            'Success': 1,
            'InstanceDropped': 2,
            'Error': 3,
            'Unknown': 4,
        },
        SType: {
            'ShaderSourceSPIRV': 1,
            'ShaderSourceWGSL': 2,
            'RenderPassMaxDrawCount': 3,
            'SurfaceSourceMetalLayer': 4,
            'SurfaceSourceWindowsHWND': 5,
            'SurfaceSourceXlibWindow': 6,
            'SurfaceSourceWaylandSurface': 7,
            'SurfaceSourceAndroidNativeWindow': 8,
            'SurfaceSourceXCBWindow': 9,
            'TextureBindingViewDimensionDescriptor': 131072,
            'SurfaceSourceCanvasHTMLSelector_Emscripten': 262144,
        },
        SamplerBindingType: {
            'Undefined': 0,
            'Filtering': 1,
            'NonFiltering': 2,
            'Comparison': 3,
        },
        Status: {
            'Success': 1,
            'Error': 2,
        },
        StencilOperation: {
            'Undefined': 0,
            'Keep': 1,
            'Zero': 2,
            'Replace': 3,
            'Invert': 4,
            'IncrementClamp': 5,
            'DecrementClamp': 6,
            'IncrementWrap': 7,
            'DecrementWrap': 8,
        },
        StorageTextureAccess: {
            'Undefined': 0,
            'WriteOnly': 1,
            'ReadOnly': 2,
            'ReadWrite': 3,
        },
        StoreOp: {
            'Undefined': 0,
            'Store': 1,
            'Discard': 2,
        },
        SurfaceGetCurrentTextureStatus: {
            'Success': 1,
            'Timeout': 2,
            'Outdated': 3,
            'Lost': 4,
            'OutOfMemory': 5,
            'DeviceLost': 6,
            'Error': 7,
        },
        TextureAspect: {
            'Undefined': 0,
            'All': 1,
            'StencilOnly': 2,
            'DepthOnly': 3,
        },
        TextureDimension: {
            'Undefined': 0,
            '1D': 1,
            '2D': 2,
            '3D': 3,
        },
        TextureFormat: {
            'Undefined': 0,
            'R8Unorm': 1,
            'R8Snorm': 2,
            'R8Uint': 3,
            'R8Sint': 4,
            'R16Uint': 5,
            'R16Sint': 6,
            'R16Float': 7,
            'RG8Unorm': 8,
            'RG8Snorm': 9,
            'RG8Uint': 10,
            'RG8Sint': 11,
            'R32Float': 12,
            'R32Uint': 13,
            'R32Sint': 14,
            'RG16Uint': 15,
            'RG16Sint': 16,
            'RG16Float': 17,
            'RGBA8Unorm': 18,
            'RGBA8UnormSrgb': 19,
            'RGBA8Snorm': 20,
            'RGBA8Uint': 21,
            'RGBA8Sint': 22,
            'BGRA8Unorm': 23,
            'BGRA8UnormSrgb': 24,
            'RGB10A2Uint': 25,
            'RGB10A2Unorm': 26,
            'RG11B10Ufloat': 27,
            'RGB9E5Ufloat': 28,
            'RG32Float': 29,
            'RG32Uint': 30,
            'RG32Sint': 31,
            'RGBA16Uint': 32,
            'RGBA16Sint': 33,
            'RGBA16Float': 34,
            'RGBA32Float': 35,
            'RGBA32Uint': 36,
            'RGBA32Sint': 37,
            'Stencil8': 38,
            'Depth16Unorm': 39,
            'Depth24Plus': 40,
            'Depth24PlusStencil8': 41,
            'Depth32Float': 42,
            'Depth32FloatStencil8': 43,
            'BC1RGBAUnorm': 44,
            'BC1RGBAUnormSrgb': 45,
            'BC2RGBAUnorm': 46,
            'BC2RGBAUnormSrgb': 47,
            'BC3RGBAUnorm': 48,
            'BC3RGBAUnormSrgb': 49,
            'BC4RUnorm': 50,
            'BC4RSnorm': 51,
            'BC5RGUnorm': 52,
            'BC5RGSnorm': 53,
            'BC6HRGBUfloat': 54,
            'BC6HRGBFloat': 55,
            'BC7RGBAUnorm': 56,
            'BC7RGBAUnormSrgb': 57,
            'ETC2RGB8Unorm': 58,
            'ETC2RGB8UnormSrgb': 59,
            'ETC2RGB8A1Unorm': 60,
            'ETC2RGB8A1UnormSrgb': 61,
            'ETC2RGBA8Unorm': 62,
            'ETC2RGBA8UnormSrgb': 63,
            'EACR11Unorm': 64,
            'EACR11Snorm': 65,
            'EACRG11Unorm': 66,
            'EACRG11Snorm': 67,
            'ASTC4x4Unorm': 68,
            'ASTC4x4UnormSrgb': 69,
            'ASTC5x4Unorm': 70,
            'ASTC5x4UnormSrgb': 71,
            'ASTC5x5Unorm': 72,
            'ASTC5x5UnormSrgb': 73,
            'ASTC6x5Unorm': 74,
            'ASTC6x5UnormSrgb': 75,
            'ASTC6x6Unorm': 76,
            'ASTC6x6UnormSrgb': 77,
            'ASTC8x5Unorm': 78,
            'ASTC8x5UnormSrgb': 79,
            'ASTC8x6Unorm': 80,
            'ASTC8x6UnormSrgb': 81,
            'ASTC8x8Unorm': 82,
            'ASTC8x8UnormSrgb': 83,
            'ASTC10x5Unorm': 84,
            'ASTC10x5UnormSrgb': 85,
            'ASTC10x6Unorm': 86,
            'ASTC10x6UnormSrgb': 87,
            'ASTC10x8Unorm': 88,
            'ASTC10x8UnormSrgb': 89,
            'ASTC10x10Unorm': 90,
            'ASTC10x10UnormSrgb': 91,
            'ASTC12x10Unorm': 92,
            'ASTC12x10UnormSrgb': 93,
            'ASTC12x12Unorm': 94,
            'ASTC12x12UnormSrgb': 95,
        },
        TextureSampleType: {
            'Undefined': 0,
            'Float': 1,
            'UnfilterableFloat': 2,
            'Depth': 3,
            'Sint': 4,
            'Uint': 5,
        },
        TextureViewDimension: {
            'Undefined': 0,
            '1D': 1,
            '2D': 2,
            '2DArray': 3,
            'Cube': 4,
            'CubeArray': 5,
            '3D': 6,
        },
        VertexFormat: {
            'Uint8': 1,
            'Uint8x2': 2,
            'Uint8x4': 3,
            'Sint8': 4,
            'Sint8x2': 5,
            'Sint8x4': 6,
            'Unorm8': 7,
            'Unorm8x2': 8,
            'Unorm8x4': 9,
            'Snorm8': 10,
            'Snorm8x2': 11,
            'Snorm8x4': 12,
            'Uint16': 13,
            'Uint16x2': 14,
            'Uint16x4': 15,
            'Sint16': 16,
            'Sint16x2': 17,
            'Sint16x4': 18,
            'Unorm16': 19,
            'Unorm16x2': 20,
            'Unorm16x4': 21,
            'Snorm16': 22,
            'Snorm16x2': 23,
            'Snorm16x4': 24,
            'Float16': 25,
            'Float16x2': 26,
            'Float16x4': 27,
            'Float32': 28,
            'Float32x2': 29,
            'Float32x3': 30,
            'Float32x4': 31,
            'Uint32': 32,
            'Uint32x2': 33,
            'Uint32x3': 34,
            'Uint32x4': 35,
            'Sint32': 36,
            'Sint32x2': 37,
            'Sint32x3': 38,
            'Sint32x4': 39,
            'Unorm10_10_10_2': 40,
            'Unorm8x4BGRA': 41,
        },
        VertexStepMode: {
            'VertexBufferNotUsed': 0,
            'Undefined': 1,
            'Vertex': 2,
            'Instance': 3,
        },
        WaitStatus: {
            'Success': 1,
            'TimedOut': 2,
            'UnsupportedTimeout': 3,
            'UnsupportedCount': 4,
            'UnsupportedMixedSources': 5,
            'Unknown': 6,
        },
        BufferUsage: {
            'None': 0,
            'MapRead': 1,
            'MapWrite': 2,
            'CopySrc': 4,
            'CopyDst': 8,
            'Index': 16,
            'Vertex': 32,
            'Uniform': 64,
            'Storage': 128,
            'Indirect': 256,
            'QueryResolve': 512,
        },
        ColorWriteMask: {
            'None': 0,
            'Red': 1,
            'Green': 2,
            'Blue': 4,
            'Alpha': 8,
            'All': 15,
        },
        MapMode: {
            'None': 0,
            'Read': 1,
            'Write': 2,
        },
        ShaderStage: {
            'None': 0,
            'Vertex': 1,
            'Fragment': 2,
            'Compute': 4,
        },
        TextureUsage: {
            'None': 0,
            'CopySrc': 1,
            'CopyDst': 2,
            'TextureBinding': 4,
            'StorageBinding': 8,
            'RenderAttachment': 16,
        },
    };

    // Maps from enum string back to enum number, for callbacks.
    // These appear in the final build result so should be kept minimal.
    globalThis.WEBGPU_STRING_TO_INT_TABLES = `
        Int_BufferMapState: {
            'unmapped': 1,
            'pending': 2,
            'mapped': 3,
        },
        Int_CompilationMessageType: {
            'error': 1,
            'warning': 2,
            'info': 3,
        },
        Int_DeviceLostReason: {
            'undefined': 1,  // For older browsers
            'unknown': 1,
            'destroyed': 2,
        },
        Int_PreferredFormat: {
            'rgba8unorm': 18,
            'bgra8unorm': 23,
        },
`;

    // Maps from enum number to enum string.
    // These appear in the final build result so should be kept minimal.
    globalThis.WEBGPU_INT_TO_STRING_TABLES = `
        WGSLFeatureName: {
            1: 'readonly_and_readwrite_storage_textures',
            2: 'packed_4x8_integer_dot_product',
            3: 'unrestricted_pointer_parameters',
            4: 'pointer_composite_access',
        },
        AddressMode: [
            undefined,
            'clamp-to-edge',
            'repeat',
            'mirror-repeat',
        ],
        BlendFactor: [
            undefined,
            'zero',
            'one',
            'src',
            'one-minus-src',
            'src-alpha',
            'one-minus-src-alpha',
            'dst',
            'one-minus-dst',
            'dst-alpha',
            'one-minus-dst-alpha',
            'src-alpha-saturated',
            'constant',
            'one-minus-constant',
            'src1',
            'one-minus-src1',
            'src1alpha',
            'one-minus-src1alpha',
        ],
        BlendOperation: [
            undefined,
            'add',
            'subtract',
            'reverse-subtract',
            'min',
            'max',
        ],
        BufferBindingType: [
            undefined,
            'uniform',
            'storage',
            'read-only-storage',
        ],
        BufferMapState: {
            1: 'unmapped',
            2: 'pending',
            3: 'mapped',
        },
        CompareFunction: [
            undefined,
            'never',
            'less',
            'equal',
            'less-equal',
            'greater',
            'not-equal',
            'greater-equal',
            'always',
        ],
        CompilationInfoRequestStatus: {
            1: 'success',
            2: 'instance-dropped',
            3: 'error',
            4: 'device-lost',
            5: 'unknown',
        },
        CompositeAlphaMode: [
            undefined,
            'opaque',
            'premultiplied',
            'unpremultiplied',
            'inherit',
        ],
        CullMode: [
            undefined,
            'none',
            'front',
            'back',
        ],
        ErrorFilter: {
            1: 'validation',
            2: 'out-of-memory',
            3: 'internal',
        },
        FeatureName: {
            1: 'depth-clip-control',
            2: 'depth32float-stencil8',
            3: 'timestamp-query',
            4: 'texture-compression-bc',
            5: 'texture-compression-etc2',
            6: 'texture-compression-astc',
            7: 'indirect-first-instance',
            8: 'shader-f16',
            9: 'rg11b10ufloat-renderable',
            10: 'bgra8unorm-storage',
            11: 'float32-filterable',
            12: 'float32-blendable',
            13: 'subgroups',
            14: 'subgroups-f16',
        },
        FilterMode: [
            undefined,
            'nearest',
            'linear',
        ],
        FrontFace: [
            undefined,
            'ccw',
            'cw',
        ],
        IndexFormat: [
            undefined,
            'uint16',
            'uint32',
        ],
        LoadOp: [
            undefined,
            'load',
            'clear',
        ],
        MipmapFilterMode: [
            undefined,
            'nearest',
            'linear',
        ],
        OptionalBool: [
            'false',
            'true',
            undefined,
        ],
        PowerPreference: [
            undefined,
            'low-power',
            'high-performance',
        ],
        PrimitiveTopology: [
            undefined,
            'point-list',
            'line-list',
            'line-strip',
            'triangle-list',
            'triangle-strip',
        ],
        QueryType: {
            1: 'occlusion',
            2: 'timestamp',
        },
        SamplerBindingType: [
            undefined,
            'filtering',
            'non-filtering',
            'comparison',
        ],
        Status: {
            1: 'success',
            2: 'error',
        },
        StencilOperation: [
            undefined,
            'keep',
            'zero',
            'replace',
            'invert',
            'increment-clamp',
            'decrement-clamp',
            'increment-wrap',
            'decrement-wrap',
        ],
        StorageTextureAccess: [
            undefined,
            'write-only',
            'read-only',
            'read-write',
        ],
        StoreOp: [
            undefined,
            'store',
            'discard',
        ],
        SurfaceGetCurrentTextureStatus: {
            1: 'success',
            2: 'timeout',
            3: 'outdated',
            4: 'lost',
            5: 'out-of-memory',
            6: 'device-lost',
            7: 'error',
        },
        TextureAspect: [
            undefined,
            'all',
            'stencil-only',
            'depth-only',
        ],
        TextureDimension: [
            undefined,
            '1d',
            '2d',
            '3d',
        ],
        TextureFormat: [
            undefined,
            'r8unorm',
            'r8snorm',
            'r8uint',
            'r8sint',
            'r16uint',
            'r16sint',
            'r16float',
            'rg8unorm',
            'rg8snorm',
            'rg8uint',
            'rg8sint',
            'r32float',
            'r32uint',
            'r32sint',
            'rg16uint',
            'rg16sint',
            'rg16float',
            'rgba8unorm',
            'rgba8unorm-srgb',
            'rgba8snorm',
            'rgba8uint',
            'rgba8sint',
            'bgra8unorm',
            'bgra8unorm-srgb',
            'rgb10a2uint',
            'rgb10a2unorm',
            'rg11b10ufloat',
            'rgb9e5ufloat',
            'rg32float',
            'rg32uint',
            'rg32sint',
            'rgba16uint',
            'rgba16sint',
            'rgba16float',
            'rgba32float',
            'rgba32uint',
            'rgba32sint',
            'stencil8',
            'depth16unorm',
            'depth24plus',
            'depth24plus-stencil8',
            'depth32float',
            'depth32float-stencil8',
            'bc1-rgba-unorm',
            'bc1-rgba-unorm-srgb',
            'bc2-rgba-unorm',
            'bc2-rgba-unorm-srgb',
            'bc3-rgba-unorm',
            'bc3-rgba-unorm-srgb',
            'bc4-r-unorm',
            'bc4-r-snorm',
            'bc5-rg-unorm',
            'bc5-rg-snorm',
            'bc6h-rgb-ufloat',
            'bc6h-rgb-float',
            'bc7-rgba-unorm',
            'bc7-rgba-unorm-srgb',
            'etc2-rgb8unorm',
            'etc2-rgb8unorm-srgb',
            'etc2-rgb8a1unorm',
            'etc2-rgb8a1unorm-srgb',
            'etc2-rgba8unorm',
            'etc2-rgba8unorm-srgb',
            'eac-r11unorm',
            'eac-r11snorm',
            'eac-rg11unorm',
            'eac-rg11snorm',
            'astc-4x4-unorm',
            'astc-4x4-unorm-srgb',
            'astc-5x4-unorm',
            'astc-5x4-unorm-srgb',
            'astc-5x5-unorm',
            'astc-5x5-unorm-srgb',
            'astc-6x5-unorm',
            'astc-6x5-unorm-srgb',
            'astc-6x6-unorm',
            'astc-6x6-unorm-srgb',
            'astc-8x5-unorm',
            'astc-8x5-unorm-srgb',
            'astc-8x6-unorm',
            'astc-8x6-unorm-srgb',
            'astc-8x8-unorm',
            'astc-8x8-unorm-srgb',
            'astc-10x5-unorm',
            'astc-10x5-unorm-srgb',
            'astc-10x6-unorm',
            'astc-10x6-unorm-srgb',
            'astc-10x8-unorm',
            'astc-10x8-unorm-srgb',
            'astc-10x10-unorm',
            'astc-10x10-unorm-srgb',
            'astc-12x10-unorm',
            'astc-12x10-unorm-srgb',
            'astc-12x12-unorm',
            'astc-12x12-unorm-srgb',
        ],
        TextureSampleType: [
            undefined,
            'float',
            'unfilterable-float',
            'depth',
            'sint',
            'uint',
        ],
        TextureViewDimension: [
            undefined,
            '1d',
            '2d',
            '2d-array',
            'cube',
            'cube-array',
            '3d',
        ],
        VertexFormat: {
            1: 'uint8',
            2: 'uint8x2',
            3: 'uint8x4',
            4: 'sint8',
            5: 'sint8x2',
            6: 'sint8x4',
            7: 'unorm8',
            8: 'unorm8x2',
            9: 'unorm8x4',
            10: 'snorm8',
            11: 'snorm8x2',
            12: 'snorm8x4',
            13: 'uint16',
            14: 'uint16x2',
            15: 'uint16x4',
            16: 'sint16',
            17: 'sint16x2',
            18: 'sint16x4',
            19: 'unorm16',
            20: 'unorm16x2',
            21: 'unorm16x4',
            22: 'snorm16',
            23: 'snorm16x2',
            24: 'snorm16x4',
            25: 'float16',
            26: 'float16x2',
            27: 'float16x4',
            28: 'float32',
            29: 'float32x2',
            30: 'float32x3',
            31: 'float32x4',
            32: 'uint32',
            33: 'uint32x2',
            34: 'uint32x3',
            35: 'uint32x4',
            36: 'sint32',
            37: 'sint32x2',
            38: 'sint32x3',
            39: 'sint32x4',
            40: 'unorm10-10-10-2',
            41: 'unorm8x4-bgra',
        },
        VertexStepMode: [
            'vertex-buffer-not-used',
            undefined,
            'vertex',
            'instance',
        ],
`;

    null;
}}}