# Motion Blur

![Motion Blur](media/motion_blur.gif)

The **Motion Blur** effect simulates the blur of an object based on its motion. When objects filmed by a camera are moving faster than the camera’s exposure time they appear as blurred on the edges. This can be caused by rapidly moving objects or a long exposure time. The effect itself is based on *Motion Vectors* buffer rendering which contains an objects pixels moving across the screen.

## Properties

![Properties](media/motion-blur-properties.jpg)

| Property | Description |
|--------|--------|
| **Enabled** | If checked, the motion blur effect will be rendered. |
| **Scale** | The blur effect strength. A value of 0 disables it, while higher values increase the effect. |
| **Sample Count** | The amount of sample points used during motion blur rendering. It affects blur quality and performance. |
| **Motion Vectors Resolution** | The motion vectors texture resolution. Motion blur uses a per-pixel motion vector buffer that contains an objects movement information. Use a lower resolution to improve performance. |

## Motion Vector Debugging

![Motion Vectors](media/motion_vectors_debug.gif)

The editor supports rendering motion vector visualizations by checking **View -> Debug View -> Motion Vectors**.
You can use it to preview and debug the motion vectors of your game objects.

## Per-Bone motion

![Per Bone Motion Blue Flax](media/per-bone-motion-blur.png)

Skeletal meshes support **Per Bone Motion Blur** that handles rendering the pixel motion for the animated model's bones transformation changes.
