# Decal

![Decal](media/decals.png)

**Decal** is an actor type that projects and renders the material on top of the other objects. Decal uses a oriented bounding box to define its volume.

## Usage

To learn how to setup and use the decal please see the dedicated tutorial: [How to create decal](create-decal.md).

## Properties

![Decal Properties](media/decal-properties.png)

| Option | Description |
|--------|--------|
| **Material** | The decal material. Must have domain mode to *Decal* type. |
| **Sort Order** | The decal rendering order. The higher values are render later (on top). |
| **Size** | The decal bounds size (in local space). |
| **Draw Min Screen Size** | The minimum screen size for the decal drawing. If the decal size on the screen is smaller than this value then decal will be culled. Set it to higher value to make culling more aggressive. |

