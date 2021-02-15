# Graphics

![Graphics](media/title.jpg)

Flax offers a wide variety of graphics pipeline features as well as solid renderer that includes deferred shading, global illumination, reflective environment and post-processing.

This section explains all you need to know about working with materials pipeline, importing textures, lighting the environment and much more.

## Supported graphics backends

* DirectX 11 (with DirectX 10/10.1 fallback)
* DirectX 12
* Vulkan
* Null
* Platform native (eg. on PS4)

> [!TIP]
> To check on which rendering backend game is running use [GPUDevice.Instance.RendererType](https://docs.flaxengine.com/api/FlaxEngine.GPUDevice.html#FlaxEngine_Rendering_GPUDevice_RendererType). You can also use [GPUDevice.Instance.ShaderProfile](https://docs.flaxengine.com/api/FlaxEngine.GPUDevice.html#FlaxEngine_Rendering_GPUDevice_ShaderProfile) to check the shaders format that is being used by the rendering backend.

## In this section

* [Rendering overview](overview/index.md)
* [Cameras](cameras/index.md)
* [Materials](materials/index.md)
* [Textures](textures/index.md)
* [Models](models/index.md)
* [Decals](decals/index.md)
* [Splines](splines/index.md)
* [Lighting](lighting/index.md)
* [Fog effects](fog-effects/index.md)
* [Post effects](post-effects/index.md)
* [Shaders](shaders/index.md)
* [Debugging tools](debugging-tools/index.md)
