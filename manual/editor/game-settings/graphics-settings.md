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
| **Default Probe Cubemap Format** | Environment Probes texture storage format. Controls the quality fo reflections and memory usage of probes data. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**R8G8B8A8**</td><td>LDR uncompressed format (32-bit per pixel).</td></tr><tr><td>**R11G11B10**</td><td>HDR uncompressed format (32-bit per pixel, no alpha).</td></tr><tr><td>**BC6**</td><td>HDR compressed format (8-bit per pixel, no alpha). Converted into ASTC/Basis for mobile/web. Realtime probes will fallback to R11G11B10.</td></tr><tr><td>**BC7**</td><td>HDR compressed format (8-bit per pixel). Converted into ASTC/Basis for mobile/web. Realtime probes will fallback to R11G11B10.</td></tr></tbody></table> |
|||
| **Occlusion Culling** | The type of the occlusion culling (implements `IOcclusionCulling`) that will be used to test visibility of the objects and skip rendering occluded ones. Can be left empty to use frustum-culling only. |
| **Occlusion Buffered Frames** | The number of buffered frames for the visibility query results readback from GPU (to avoid stalls). The higher value the more latency but less CPU stalls (to wait for GPU results). Higher values increase object popping artifacts. |
| **Occlusion Bounds Scale** | The object bounds scale for occlusion culling to reduce popping artifacts caused by latency of visibility readback from GPU to CPU. Higher values inflate bounds which improves visual stability but lowers occlusion culling efficiency. |
|||
| **Enable Global SDF** | If checked, enables Global SDF rendering. This can be used in materials, shaders, and particles. |
| **Global SDF Distance** | Draw distance of the Global SDF. Actual value can be large when using DDGI. |
| **Global SDF Quality** | The Global SDF quality. Controls the volume texture resolution and amount of cascades to use. |
| **Generate SDF On Model Import** | If checked, the `Generate SDF` option will be checked on model import options by default. Use it if your project uses Global SDF (eg. for Global Illumination or particles). |
|||
| **GI Quality** | The Global Illumination quality. Controls the quality of the GI effect. |
| **GI Probes Spacing** | The global spacing between Global Illumination probes (in world units). Smaller values improve interior detail at a higher GPU cost. Values around 100-150 are a useful starting point for mixed interiors and exteriors; adjust to 200-500 for mostly outdoor scenes and lower-frequency GI. Changing this value recreates the DDGI probe resources and can change the automatic cascade layout. |
| **GI Cascades Blending** | Enables smooth blending between Global Illumination cascade splits. If disabled, the transition uses dithering intended for temporal anti-aliasing. Smooth blending can expose rounded cascade boundaries when adjacent cascades contain significantly different lighting. |
| **Global Surface Atlas Resolution** | The Global Surface Atlas resolution. Adjust it if atlas `flickers` due to overflow (eg. to 4096). |
|||
| **Gamma Color Space** | If checked, color space workflow will use Gamma instead of Linear. Gamma color space defines colors with an applied a gamma curve (sRGB) so they are perceptually linear. This makes sense when the output of the rendering represent final color values that will be presented to a non-HDR screen. |
| **Render Color Format** | Pixel format used by the rendering pipeline (for light buffer and post-processing). Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**R11G11B10**</td><td>HDR 32-bit buffer without alpha channel support. Offers good performance but might result in colors banding or shift towards yellowish colors due to low data precision.</td></tr><tr><td>**R8G8B8A8**</td><td>LDR 32-bit buffer with alpha channel support. Offers good performance but doesn't support High Dynamic Range rendering.</td></tr><tr><td>**R16G16B16A16**</td><td>HDR 64-bit buffer with alpha channel support. Offers very good quality for wide range of colors but requires more memory.</td></tr></tbody></table> |
|||
| **Fallback Fonts** | The list of fallback fonts used for text rendering. Ignored if empty. |
|||
| **Post Process Settings** | The default Post Process settings. Can be overriden by PostFxVolume on a level locally, per camera or for a whole map. |
