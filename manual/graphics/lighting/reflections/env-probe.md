# Environment Probe

![Environment Probe](media/env-probe.png)

The [Environment Probe](http://docs.flaxengine.com/api/FlaxEngine.EnvironmentProbe.html) actor uses a cube texture and applies it onto the objects as a reflection source. This technique is called reflection mapping and comes in very handy to reproduce reflective surfaces like metals, marble or shiny plastics.

## Creating a new reflection probe

Creating a reflection probe is done similar to creating other actor types. Simply right click on an actor node in the *Scene* window, and select the option **New -> Visuals -> Environment Probe**.

![New Environment Probe](media/env-probe-create.jpg)

Creating probes at runtime via script is also possible but not recommended. It's better to toggle an existing probes visibility or modify its **Brightness** property to fade in or out.

Alternatively, you can use the *Toolbox* window and drag and drop the environment probe actor from the **Visuals** group into a scene.

## Properties

![Properties](media/env-probe-properties.jpg)

| Property | Description |
|--------|--------|
| **Cubemap Resolution** | The reflection texture resolution. Can use graphics settings or a custom resolution. |
| **Brightness** | Controls the intensity of the reflection color from the probe. Can be used to fade in or out reflections. |
| **Radius** | Reflection probe influence range. |
| **Update Mode** | The probe update mode. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Manual**</td><td>Probe can be updated manually (eg. in Editor or from script).</td></tr><tr><td>**When Moved**</td><td>Probe will be automatically updated when it is moved.</td></tr><tr><td>**Realtime**</td><td>Probe will be automatically updated in real-time (only if in view and frequency depending on distance to the camera).</td></tr></tbody></table> |
| **Capture Near Plane** | Defines a near clipping plane used for rendering the probe. Use a higher value to clip geometry near the probe. |
| **Custom Probe** | If specified, the environment probe will use a custom [CubeTexture](http://docs.flaxengine.com/api/FlaxEngine.CubeTexture.html) as a reflection source. |

To capture the scene around the reflection probe press the **Bake** button. It will render the scene in each of 6 directions into a cube map and filter it. During reflection probe rendering only actors with [StaticFlags.ReflectionProbe](http://docs.flaxengine.com/api/FlaxEngine.StaticFlags.html) enabled will be visible.

Updated environment probe cube textures are stored in a *SceneData* folder. To read more about scene data, see the `Scene Data storage` section down below.

## Blending

![Reflections Blending](media/env-probe-blending.png)

Flax Engine renders reflection probes into a dedicated buffer using a dedicated pass using a screen space shader. It then mixes the final reflection color into the light buffer. This provides the opportunity to perform high quality **per-pixel relfections color blending**. Rendering starts from drawing probes with the highest radius and then moces to the smaller ones (**probes are sorted by radius**). Reflection color is also being faded on the edges of the probe bounds. This results in a smooth transition and reduces any flickering -- especially for dynamic objects that move quickly through the scene.

## Scene Data storage

By default, Flax uses a dedicated content directory for **scene data assets**. It's used by the lightmaps, CSG meshes and also Environment Probes. Reflection probes' cube textures are located in: **Content/SceneData/'scene_name'/EnvProbes**. If you want to reuse a baked reflection probe or modify it you can access textures in that location. Also, the Environment Probe actor contains a dedicated public property [EnvironmentProbe.Probe](http://docs.flaxengine.com/api/FlaxEngine.EnvironmentProbe.html#FlaxEngine_EnvironmentProbe_Probe) which can be used to access the cube texture in use.

To learn more about scene assets see the [Scene Data Storage](../../../get-started/scenes/scene-data.md) page.

## Realtime probes

Probes can be used at runtime from a script or automatically every frame. This can be used to implement dynamic environment reflections at the cost of performance. Make sure to limit the amount of probes that are updated frequently and adjust the resolution to keep stable performance.
