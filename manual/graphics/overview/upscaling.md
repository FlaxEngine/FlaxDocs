# Upscaling

Flax supports performing scene rendering in lower resolution and upscaling the image into the window backbuffer. This allows improving game performance on slower devices. It can be configured via the `RenderScale` property (per `SceneRenderTask`). To change the resolution scale for the game viewport use `MainRenderTask.Instance.RenderScale` (you can preview it in the *Graphics Quality window* in the Editor). It's a scale of the rendering resolution relative to the output dimensions. If lower than `1` the scene and postprocessing will be rendered at a lower resolution and upscaled to the output backbuffer.

User Interface (`UI`) is rendered directly to the window backbuffer at native resolution (without upscaling). Except when UI Canvas is using a custom draw location (in. World-Space).

## Upscale Location

Scene image upscaling can happpen at different places within the pipleine:

| Location | Description |
|--------|--------|
|  After Anti Aliasing | The up-scaling happens directly to the output buffer (backbuffer) after post processing and anti-aliasing. |
| Before Post Processing | The up-scaling happens before the post processing after scene rendering (after geometry, lighting, volumetrics, transparency and SSR/SSAO). |
| During Anti Aliasing | The up-scaling happens during anti-aliasing. For example, when using Temporal Anti-Aliasing (TAA) it work as Temporal Anti-Aliasing Upsampling (TAAU) to both remove aliasing and upscale the image. |

This `UpscaleLocation` option can be set on `SceneRenderTask` or be automatically overridden by the active upscaling plugin (eg. DLSS) within `SetupRender` event or via `PreRender` callback on post-effect (by editing `renderContext.List->Setup`).

## Upscalers

Flax supports various methods of upscaling the image depending on the `UpscaleLocation` property (also set on `SceneRenderTask`) that defines when to 
* `Multi Scaler` - Catmull-Rom filtering with 9-taps,
* `TAAU` - Temporal Anti-Aliasing Upsampling (upscaling during TAA),
* Custom via plugin:
  * [AMD FSR](https://github.com/FlaxEngine/FidelityFX-FSR),
  * [NVIDIA DLSS](https://github.com/FlaxEngine/DLSS),

## Texture Mip Bias

With upscaling enabled, rendered resolution can be is much lower than displayed resolution. When combined with mipmap optimizations, this can limit the quality of texture samples relative to the displayed resolution. In these situations, specifying a *negative mip bias* can improve the shaprness of final image.

The desired mip bias varies with the ratio of `(rendered resolution) : (displayed resolution)`, which is also defined as `RenderScale`. The automatic mip bias is calculated as follows: `log2(setup.RenderScale)`, which produces negative values when upscaling (e.g. `-1.0` for `2x` upscaling). `SceneRenderTask` contains `MaterialTextureMipBias` field, which can act as an additional mip bias.

Computed `MaterialTextureMipBias` (stored inside `RenderSetup`) is passed to material data to bias mip level of the sampled textures. With an exception for `GUI` and `PostProcess` materials.
