# Flax 1.4 release notes

## Highlights

### Feature A

## Migration Guide

### Scripts initialization order

We refactored actors' `PostLoad`/`PostSpawn` methods into `Initialize` and changed the script `OnAwake` event to be called during this initialization phase - before any `OnStart`/`OnEnable` logic. This helps to create gameplay systems in a scheme of manager+objects where the manager can use `OnAwake` to initialize properly, and `OnEnable` can be used to register objects to the manager. This change has no performance impact but might be important to address in existing Flax projects.

### Large Worlds

Adding 64-bit precision to the world coordinates to the Flax was a challenge. Both Engine and Editor have very complex and mature systems with tooling thus we wanted to make this transition seamless and stable. One of the goals was to don't bloat memory by just doubling every floating-point value but instead upgrade world-coordinates-related data to support very large worlds. For instance, 32-bit float gives us enough precision to represent object rotation and scale thus we upgraded only `Translation` (aka `Position`) of the `Transform` to a 64-bit double vector. Also, the UI system, mesh data, textures converter, and other engine features were changed to keep explicitly *Float* vectors for performance reasons.

Regarding data compatibility, we did automatic upgrade support for the older projects, as well as, an implicit conversion between 32-bit and 64-bit vector types to ensure gameplay code can be easily updated to the new engine version. Finally, this Large World Coordinates feature can be enabled via engine configuration parameter (see `Flax.flaxproj`). If your game needs 64-bit floats then you can use a custom engine build ([docs](../../editor/large-worlds/index.md)) and enable that feature.

Important changes regarding this feature:
- Refactored Vector types Float/Double/Int to have float/double/int as data and Vector to have a float or double (typedef as `Real` based on `USE_LARGE_WORLDS` define at compile time)
- Refactored UI to use `Float2` explicitly instead of `Vector2` (UI doesn't need 64-bit precision)
- Refactored rendering to use `Float3` explicitly instead of `Vector3` (GPU support for 64-bit coordinates is limited and due to performance reasons we continue to use 32-bit precision but the scene rendering is relative to the large world chunk thus enables using large worlds)
- Added implicit conversion between Vector<->Float<->Double<->Int vector types to make it easier for upgrade projects to 1.4 version
- Core math types that will keep 32-bit float precision: `Rectangle`, `Color`, `Matrix`, `Matrix3x3`, `Matrix3x4`, `Quaternion`, `Viewport`, `BoundingFrustum`
- Core math types that were upgraded to 64-bit double-precision: `Vector2/3/4`, `BoundingBox`, `BoundingSphere`, `OrientedBoundingBox`, `Plane`, `Ray`, `Triangle`, `Transform` (only translation, orientation, and scale will use 32-bit precision as it's enough to represent rotation and scaling)
- Mesh API has been changed to explicitly use `Float2/3/4` for mesh vertices data (instead of `Vector2/3/4`) - old API has been deprecated but still will work
- Collision Data and Physics uses 32-bit precision for vertices and geometry - old API has been deprecated but still will work
- Packed vector types (eg. `FloatR10G10B10A2`, `Half3`) have been refactor to use Float2/3/4 types for conversion as default instead of `Vector2/3/4`
- Material, particle, and animation graphs parameters were changed from Vector to Float (explicit type) but with new support for Doubles
- Gameplay Globals entries of `Vector2/3/4` has been changed into `Float2/3/4` and added `Double2/3/4` if more precision is needed

Migration guide:
- BoundingBox, BoundingSphere. Transform, Ray, Triangle Plane, Vector2/3/4 types can have different memory sizes if using doubles. Ensure the serialization of data using those types will work accordingly. You can use new WriteStream and ReadStream utility methods for those data types serialization. `Variant` type will automatically upgrade existing data.
- GameplayGlobals values of vector type have been changed into `Float2/3/4` (reading vectors will need to be changed explicitly).
- User Interface uses `Float2` explicitly for coordinates, please update your UI code.

## Changelog

### Version 1.4.XXXXX - XX XXX 2022

Contributors: 

PRs merged: 

* 
