# Graphics Settings

The graphics settings asset specifies the initial rendering quality and other graphics-related options.
You can change most of these values at runtime using the [GraphicsQuality](https://docs.flaxengine.com/api/FlaxEngine.GraphicsQuality.html) service or by using the dedicated window to edit the graphics quality in the editor (select option from *main menu* **Window -> Graphics Quality**).

## Properties

![Flax Graphics Settings](media/graphics-settings.png)

| Property | Description |
|--------|--------|
| **Use V-Sync**  | Enables rendering synchronization with the refresh rate of the display device to avoid "tearing" artifacts. |
|||
| **AA Quality** | Anti Aliasing quality setting. |
| **SSR Quality** | Screen Space Reflections quality. |
| **SSAO Quality** | Screen Space Ambient Occlusion quality setting. |
| **Volumetric Fog Quality** | Volumetric Fog quality setting. |
| **Shadows Quality** | The shadows quality. |
| **Shadow Maps Quality** | The shadow maps quality (textures resolution). |
| **Allow CSM Blending** | Enables cascades splits blending for directional light shadows. |
| **Default Probe Resolution** | Default probes cubemap resolution (use for Environment Probes, can be overridden per-actor). Recommended is default `128x128`. For mobile platforms try using a lower resolution to get more performance. |
| **Use HDR Probes** | If checked, Environment Probes will use HDR texture format. Improves quality in very bright scenes at cost of higher memory usage. |
|||
| **Enable Global SDF** | If checked, enables Global SDF rendering. This can be used in materials, shaders, and particles. |
| **Global SDF Distance** | Draw distance of the Global SDF. Actual value can be large when using DDGI. |
| **Global SDF Quality** | The Global SDF quality. Controls the volume texture resolution and amount of cascades to use. |
| **Generate SDF On Model Import** | If checked, the `Generate SDF` option will be checked on model import options by default. Use it if your project uses Global SDF (eg. for Global Illumination or particles). |
|||
| **GI Quality** | The Global Illumination quality. Controls the quality of the GI effect. |
| **GI Probes Spacing** | The Global Illumination probes spacing distance (in world units). Defines the quality of the GI resolution. Adjust to 200-500 to improve performance and lower frequency GI data. |
| **GI Cascades Blending** | Enables cascades splits blending for Global Illumination. |
| **Global Surface Atlas Resolution** | The Global Surface Atlas resolution. Adjust it if atlas `flickers` due to overflow (eg. to 4096). |
|||
| **Gamma Color Space** | If checked, color space workflow will use Gamma instead of Linear. Gamma color space defines colors with an applied a gamma curve (sRGB) so they are perceptually linear. This makes sense when the output of the rendering represent final color values that will be presented to a non-HDR screen. |
| **Render Color Format** | Pixel format used by the rendering pipeline (for light buffer and post-processing). Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**R11G11B10**</td><td>HDR 32-bit buffer without alpha channel support. Offers good performance but might result in colors banding or shift towards yellowish colors due to low data precision.</td></tr><tr><td>**R8G8B8A8**</td><td>LDR 32-bit buffer with alpha channel support. Offers good performance but doesn't support High Dynamic Range rendering.</td></tr><tr><td>**R16G16B16A16**</td><td>HDR 64-bit buffer with alpha channel support. Offers very good quality for wide range of colors but requires more memory.</td></tr></tbody></table> |
|||
| **Fallback Fonts** | The list of fallback fonts used for text rendering. Ignored if empty. |
|||
| **Post Process Settings** | The default Post Process settings. Can be overridden by PostFxVolume on a level locally, per camera or for a whole map. |
