# PostFx Volumes

![PostFx Volumes](media/post-fx-volumes.png)

A **PostFx Volume** is a special actor that overrides the default post-processing settings inside a defined volume in space.
By using it you can modify the depth of field, bloom, or other effects within a volume.
When the player camera moves into the volume, settings are blended.

Using post effect volumes allows modifying post processing in 3D space or per camera (simply attach the postFx volume as a child of the camera). Flax Engine supports blending an unlimited number of volumes. However, blending too many volumes at once may have a negative impact on CPU performance.

## Properties

![Properties](media/post-fx-volumes-properties.jpg)

| Property | Description |
|--------|--------|
| **Center** | Position of the bounds center (in local space of the actor). |
| **Size** | Size of the bounding box. |
| **Priority** | Blending priority. Volumes with higher priority are blended first. |
| **Blend Radius** | Bounds blending fall off radius. Used to smooth the settings transiion when the camera enters the bounds. Used only if volume *Is Bounded*. |
| **Blend Weight** | Normalized (range of 0-1) weight of the volume blending. Can be animated or modified at runtime to perform a smooth transition when enabling the volume (instead of using the binary option *Is Active*). |
| **Is Bounded** | If checked, settings blending will use the object's bounds, otherwise it will have a global effect. |

## Editing PostFx Settings

The PostFx Volume supports a *"per option"* value override which means only selected options could be modified by the volume. This is very handy during game production when dealing with custom effects per level area.

To override the setting, simply select the checkbox dedicated to it and adjust the value as shown in the picture below.

![Properties](media/post-fx-volumes-edit.jpg)

## Default Settings

Use [Graphics Settings](../../editor/game-settings/graphics-settings.md) to edit the default Post Process Settings.
