# Lightmapping

![Baking Lightmaps in Flax](media/bake_lightmaps.gif)

Flax supports baking lightmap texture using the custom algorithm that runs fully on a GPU. In this way, it is highly efficient and does not stall your computer during baking.

During Global Illumination baking all the static scene geometry and lights are processed to estimate the light transfer through the scene. The light emitted by the lights and emissive objects are bouncing though the scene as in the real world. GI baking calculates the final light passing to every lightmap texel and uses this information later to apply the indirect lighting into the scene rendering.

## How to use it

To bake lighting in your scene simply:
* ensure that objects and lights for baking are marked with **Lightmap static flag**
* ensure that your models have valid [lightmap UVs](lightmap-uvs.md) (engine warns if the object has missing UVs)
* adjust the [scene lightmap options](settings.md)
* use **Tools -> Bake Lightmaps** from the main menu

Lightmaps baking uses GPU and can take from few seconds up to several minutes depending on the scene size.
Output lightmap textures are always located in the [Scene Data folder](../../../get-started/scenes/scene-data.md).
