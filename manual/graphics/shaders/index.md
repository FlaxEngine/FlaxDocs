# Shaders

Shaders are **GPU program** resources which can run on the GPU and are able to perform rendering calculation using textures, vertices and other resources. Follow this documentation to learn more about wrtting and using shaders in your projects.

## Graphics rendering

Flax supports graphics programming via C++ and/or C# API that wraps the underlaying graphics beckend API with a thin abstraction layer. By using single API game and engine code can perform rendering and support multiple platforms such as DirectX, Vulkan and more. The API is **low-level and object-oriented**, as it contains most common types such as *GPUDevice*, *GPUContext*, *GPUTexture*, *GPUBuffer*, *GPUShader*, *GPUPipelineState*, etc.

GPU pipeline uses **slot-based binding model** which is explicit and has low-overhead characteristic. When performing drawing or compute work dispatching the GPU resources such as textures and buffers are binded using resource views to the explicit bipeline slots - SRV/UAV/CB. The binding slots are global to all shader stages (vertex, pixel, compute, etc.) so texture view assigned to Shader Resource View slot can be used in binded pipeline state vertex/pixel/compute shaders. The engine implements shaders reflections and optimizes the direct stages binding under the hood.

To learn more about graphics programming in Flax see related [documentation here](graphics-api.md).

## Shading language

Flax uses **HLSL** as a shading language as it's very popular in the industry and supports all major graphics rendering features. Additionally, engine will automatically compile HLSL shaders into target platform such as Vulkan or PS4 with full runtime support.
To learn about HLSL syntax see [Reference for HLSL](https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-reference) and [Programming guide for HLSL](https://docs.microsoft.com/en-us/windows/win32/direct3dhlsl/dx-graphics-hlsl-pguide).

As an extension to the HLSL language, Flax uses a small set of **attribute macros** that are used to annotate code for the engine to understand the contents and automatically handle certain parts of the graphics pipeline such as constant buffers binding. Sample shaders (vertex, pixel, compute) in documentation showcase proper usage of those macros. Additionally you can reference the engine in-build shaders to learn more (see `Flax/Content/Shaders` assets).

#### Reference of Flax Shaders Macros

| **Attribute** | **Description** |
|--------|--------|
| `META_VS(isVisible, minFeatureLevel)` | Placed above Vertex Shader function annotates it. |
| `META_VS_IN_ELEMENT(type, index, format, slot, offset, slotClass, stepRate, isVisible)` | Placed between Vertex Shader function annotation and definition marks the vertex shader input usage and defines the data properties. Can be used multiple for every possible vertex element. |
| `META_HS(isVisible, minFeatureLevel)` | Placed above Hull Shader function annotates it. |
| `META_HS_PATCH(inControlPoints)` | Placed between Hull Shader function annotation and definition defines the amount of control points used by the patch function. |
| `META_DS(isVisible, minFeatureLevel)` | Placed above Domain Shader function annotates it. |
| `META_GS(isVisible, minFeatureLevel)` | Placed above Geometry Shader function annotates it. |
| `META_PS(isVisible, minFeatureLevel)` | Placed above Pixel Shader function annotates it. |
| `META_CS(isVisible, minFeatureLevel)` | Placed above Compute Shader function annotates it. |
| `META_FLAG(flag)` | Marks the shader program with a custom flag. Eg. `Hidden`, `NoFastMath`, `VertexToGeometryShader`. To learn more see `ShaderFlags` enum. |
| `META_PERMUTATION_1(param0)` | Creates a permutation based on single macro parameter. Can be used to inject macro for the given shader compilation. |
| `META_PERMUTATION_2(param0, param1)` | Creates a permutation based on two macros.  |
| `META_PERMUTATION_3(param0, param1, param2)` | Creates a permutation based on three macros. |
| `META_PERMUTATION_4(param0, param1, param2, param3)` | Creates a permutation based on four macros. |
| `META_CB_BEGIN(index, name)` | Marks the beginning of the constant buffer definition. |
| `META_CB_END` | Marks the end of the constant buffer definition. |

#### Shader permutations

One of the features of the shading language in Flax is ability to explicitly permute a shader source using a meta attributes with defines. To understand it take a look at the following example:

```hlsl
// Pixel shader for spot light rendering
META_PS(false)
META_PERMUTATION_2(NO_SPECULAR=0, USE_IES_PROFILE=0)
META_PERMUTATION_2(NO_SPECULAR=1, USE_IES_PROFILE=0)
META_PERMUTATION_2(NO_SPECULAR=0, USE_IES_PROFILE=1)
META_PERMUTATION_2(NO_SPECULAR=1, USE_IES_PROFILE=1)
void PS_Spot(Model_VS2PS input, out float4 output : SV_Target0)
{
    ...

    // Sample GBuffer
    GBuffer gBuffer = SampleGBuffer(uv);

    // Calculate lighting
    output = GetLighting(Light, gBuffer, shadow, true, true);

    // Apply IES texture
#if USE_IES_PROFILE
    output *= ComputeLightProfileMultiplier(IESTexture, gBuffer.WorldPos, Light.LightPos, -Light.LightDir);
#endif
}
```

This shader is used to calculate per pixel lighting for spot lights (tooltip: **IES Profile** is a technique to simulate real-life light bulb physical properties like non-uniform light propagation, look at the above screenshot).
The problem is that we have to create a set of different **variations of this shader**.

1) With specular, without IES Profile.
2) Without specular, without IES Profile.
3) With specular, with IES Profile.
4) Without specular, with IES Profile.

However we don’t want to write 4 shaders but single one and just permutate it.
That’s why we use macros *META_PERMUTATION_2*. Then we can simply compile shader with different sets of macros (eg. *NO_SPECULAR=1*, *USE_IES_PROFILE=0*) and generate different shaders from the same source code. The key to success is that we use data-oriented design and define all possible shader permutation statically in a shader. Later at runtime we just select desire permutation by index and use it in rendering code. This approach is low-overhead and doesn't generate unnessesery permutations but only the ones delcared by the user.

Also, if your code needs to be used just for a single shader function use macro `_<function_name>` (eg. `_CS_Sort`). In that way also resources used just by this function (eg. buffer slot or texture slot) can be exlucded from other functions compilation.

#### Including shader files

Shader sources are stored in `.shader` files. Each file can contain one or more shader functions for the certain graphics rendering implementation. Hovewer when building complex graphics pipeline you might need to split some functionalities into several utility files. For this case, `.hlsl` files can be used as they can contain custom code to be included. Flax supports including files with a following pattern:

```hlsl
#include "./<project_name>/file_path.hlsl>"

// Example:
#include "./Flax/GBufferCommon.hlsl"
```

## Using shaders

In all Flax projects shader sources are stored in `<project_root>/Source/Shader` folder and automatically imported to `<project_root>/Content/Shader`. This also supports hot-reloading shaders at runtime and including them in source project files for editing in IDE (such as Visual Studio). To learn how to create a simple PostFx shader see [this tutorial].

Additionally, shader sources are used only in Editor during design-time. During game cooking all used shaders are precompiled to the target platform graphics APIs. Flax doesn't support compiling shaders at runtime in game.

## In this section

To learn how to use shaders in your projects follow the documentation and tutorials in this section:

* [Custom Fullscreen Shader](custom-fullscreen-shader.md)
* [Custom Surface Shader](custom-surface-shader.md)
* [Custom Geometry Drawing](custom-geometry-drawing.md)
* [Custom Compute Shader](custom-compute-shader.md)
* [Graphics API](graphics-api.md)
