# Sky Light

![Sky Light](media/sky-light.png)

**Sky Light** draws an ambient light emitted by the [skybox](../sky-skybox/skybox.md), [sky](../sky-skybox/sky.md) or other distant parts of the scene. It helps with [image-based lighting (Wikipedia)](https://en.wikipedia.org/wiki/Image-based_lighting).

Sky lights are very good choice for outdoor scenes where a lot of sky is visible. Under the hood Sky Light uses a [cube texture](../../textures/cube-textures.md) and samples it (low mip map) to simulate realistic directional irradiance. Sky Light can use a custom texture or baked one. To update the capture press **Bake** button under the object properties.

## Light Properties

![Sky Light Properties](media/sky-light-properties-1.jpg)

| Property | Description |
|--------|--------|
| **Color** | Light emission color. |
| **Additive Color** | Additional light color to add. Source texture colors are sumed with it. Can be used to apply custom ambient color. |
| **Radius** | Light range (in world units). Use very high value to apply light globally. |
| **Brightness** | Light brightness parameter. Controls intensity of the light emitted by this actor. |
| **View Distance** | Controls light visibility range. The distance at which the light be completely faded. Use value 0 to always draw a light. |

## Prope Properties

![Sky Light Properties](media/sky-light-properties-2.jpg)

| Property | Description |
|--------|--------|
| **Mode** | Defines sky light source mode. Possible options: |
| **Sky Distance Threshold** | Distance from the light at which any geometry should be treated as part of the sky (in world units). <br>Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Capture Scene**</td><td>The captured scene will be used as a light source.</td></tr><tr><td>**Custom Texture**</td><td>The custom cube texture will be used as a light source.</td></tr></tbody></table>|
| **Custom Texture** | Custom light texture. Used only if *Mode* is set to *Custom Texture*. |

If **Mode** is set to **Capture Scene**, then use **Bake** button to update the captured image.

> [!Note]
> To learn more about cube textures in Flax see [this page](../../textures/cube-textures.md).

## Volumetric Fog Properties

![Sky Light Properties](media/volumetric-fog-properties.jpg)

| Property | Description |
|--------|--------|
| **Scattering Intensity** | Controls how much this light will contribute to the [Volumetric Fog](../../fog-effects/volumetric-fog.md). When set to 0, there is no contribution. |
| **Cast Shadow** | If checked, light will cast a volumetric shadow to [Volumetric Fog](../../fog-effects/volumetric-fog.md). Also shadows casting by this light should be enabled in order to make it cast volumetric fog shadow. |

> [!Note]
> To learn more about Volumetric Fog effect see [this page](../../fog-effects/volumetric-fog.md).
