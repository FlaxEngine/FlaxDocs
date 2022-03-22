# Graphics API

Flax supports graphics programming via C++ and/or C# API that wraps the underlaying graphics backend API with a thin abstraction layer. By using single API game and engine code can perform rendering and support multiple platforms such as DirectX, Vulkan and more. The API is **low-level and object-oriented**, as it contains most common types such as *GPUDevice*, *GPUContext*, *GPUTexture*, *GPUBuffer*, *GPUShader*, *GPUPipelineState*, etc.

GPU pipeline uses **slot-based binding model** which is explicit and has low-overhead characteristic. When performing drawing or compute work dispatching the GPU resources such as textures and buffers are bound using resource views to the explicit pipeline slots - SRV/UAV/CB. The binding slots are global to all shader stages (vertex, pixel, compute, etc.) so texture view assigned to Shader Resource View slot can be used in binded pipeline state vertex/pixel/compute shaders. The engine implements shaders reflections and optimizes the direct stages binding under the hood.

## Pipeline State

Flax uses *GPUPipelineState* objects that wrap the whole graphics pipeline state into a single descriptor representation used by the GPU driver to optimize the render state switches. When creating new pipeline states fill up the *Description* structure with shaders and rendering stages features to use. Ensure to dispose pipeline states when shader asset that is used in it gets reloaded in editor.

## Supported graphics backends

* DirectX 11 (with DirectX 10/10.1 fallback)
* DirectX 12
* Vulkan
* Null
* Platform native (eg. on PS4)

> [!TIP]
> To check on which rendering backend game is running use [GPUDevice.Instance.RendererType](https://docs.flaxengine.com/api/FlaxEngine.GPUDevice.html#FlaxEngine_GPUDevice_RendererType). You can also use [GPUDevice.Instance.ShaderProfile](https://docs.flaxengine.com/api/FlaxEngine.GPUDevice.html#FlaxEngine_GPUDevice_ShaderProfile) to check the shaders format that is being used by the rendering backend.

You can also force to use a specific graphics backend API or even specific GPU (if multiple adapters available). To learn how see the engine [command line documentation](../../editor/advanced/command-line-access.md).
