# Directional Light

![Directional Light](media/directional-light.png)

A **Directional Light** emits light uniformly from a single direction. Directional Lights are useful for simulating large, distant light sources such as the sun.

## Light Properties

![Directional Light Properties](media/directional-light-properties-1.jpg)

| Property | Description |
|--------|--------|
| **Color** | Light emission color. |
| **Brightness** | Light brightness parameter. Controls intensity of the light emitted by this actor. |
| **View Distance** | Controls light visibility range. The distance at which the light becomes completely faded. Use a value of 0 to always draw a light. |
| **Minimum Roughness** | Controls the minimum roughness value used to clamp material surface roughness during shading. Can help with softening specular highlights. |

## Shadow Properties

![Directional Light Properties](media/directional-light-properties-2.jpg)

| Property | Description |
|--------|--------|
| **Mode** | Describes how a visual element casts shadows. Possible options: <br><table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**None**</td><td>Never render shadows.</td></tr><tr><td>**Static Only**</td><td>Render shadows only in static views (env probes, lightmaps, etc.).</td></tr><tr><td>**Dynamic Only**</td><td>Render shadows only in dynamic views (game, editor, etc.).</td></tr><tr><td>**All**</td><td>Always render shadows.</td></tr></tbody></table> |
| **Partition Mode** | The partitioning mode for the shadow cascades. Possible options: <br><table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Manual**</td><td>Internally defined cascade splits.</td></tr><tr><td>**Logarithmic**</td><td>Logarithmic cascade splits.</td></tr><tr><td>**PSSM**</td><td>Parallel-Split Shadow Maps cascade splits.</td></tr></tbody></table> |
| **Cascade Count** | The number of cascades used for slicing the range of depth covered by the light during shadow rendering. Values are 1, 2 or 4 cascades; a typical scene uses 4 cascades. |
| **Sharpness** | Controls shadow sharpness. Can be used to tweak the penumbra width. |
| **Strength** | Controls dynamic shadow blending strength. Default is 1 for fully opaque shadows, a value of 0 disables shadows. |
| **Distance** | Shadow rendering distance (in world units). |
| **Fade Distance** | Shadow fade off distance (in world units). |
| **Depth Bias** | Controls dynamic shadow depth bias value. Depth bias is used for shadow map comparison. |
| **Normal Offset Scale** | Controls dynamic shadows normal vector offset scale. A factor specifying the offset to add to the calculated shadow map depth with respect to the surface normal. |
| **Contact Shadows Length** | The length of the rays for contact shadows computed via screen-space tracing. Set this to values higher than 0 to enable screen-space shadow rendering for this light. This improves the shadowing details. Actual ray distance is based on the pixel distance from the camera. |
| **Update Rate** | Frequency of shadow updates. 1 - every frame, 0.5 - every second frame, 0 - on start or change. It's the inverse value of how many frames should happen in-between shadow map updates (eg. inverse of 0.5 is 2 thus shadow will update every 2nd frame). |
| **Update Rate At Distance** | Frequency of shadow updates at the maximum distance from the view at which shadows are still rendered. This value is multiplied by *Shadows Update Rate* and allows scaling the update rate in-between the shadow range. For example, if light is near view, it will get normal shadow updates but will reduce this rate when far from view. |
| **Resolution** | Defines the resolution of the shadow map texture used to draw objects projection from light-point-of-view. Higher values increase shadow quality at cost of performance. |

> [!Note]
> To learn more about shadows in Flax see [this page](../shadows.md).

## Volumetric Fog Properties

![Directional Light Properties](media/volumetric-fog-properties.jpg)

| Property | Description |
|--------|--------|
| **Scattering Intensity** | Controls how much this light will contribute to the [Volumetric Fog](../../fog-effects/volumetric-fog.md). When set to 0, there is no contribution. |
| **Cast Shadow** | If checked, light will cast a volumetric shadow to [Volumetric Fog](../../fog-effects/volumetric-fog.md). Also shadow casting by this light should be enabled in order to make it cast volumetric fog shadows. |

> [!Note]
> To learn more about Volumetric Fog effect see [this page](../../fog-effects/volumetric-fog.md).
