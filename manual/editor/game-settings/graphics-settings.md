# Graphics Settings

The graphics settings asset specifies the initial rendering quality and other graphics-related options.
You can change most of these values at runtime using the [GraphicsQuality](https://docs.flaxengine.com/api/FlaxEngine.GraphicsQuality.html) service or by using the dedicated window to edit the graphics quality in the editor (select option from *main menu* **Window -> Graphics Quality**).

## Properties

![Flax Graphics Settings](media/graphics-settings.png)

| Property | Description |
|--------|--------|
| **Use V-Sync**  | Enables rendering synchronization with the refresh rate of the display device to avoid "tearing" artifacts. |
| **AA Quality** | Anti Aliasing quality setting. |
| **SSR Quality** | Screen Space Reflections quality. |
| **SSAO Quality** | Screen Space Ambient Occlusion quality setting. |
| **Volumetric Fog Quality** | Volumetric Fog quality setting. |
| **Shadows Quality** | The shadows quality. |
| **Shadow Maps Quality** | The shadow maps quality (textures resolution). |
| **Allow CSM Blending** | If checked, enabled cascades splits blending for directional light shadows. Disable to reduce performance impact for dynamic sun shadows. |
