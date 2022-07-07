# Large Worlds

Flax Engine contains various features to create large and rich worlds such as:
* content async loading
* textures dynamic quality streaming
* highly multithreaded (physics, job system, animations, particles, etc.)
* terrain and foliage tools
* automatic draw calls batching and instancing
* levels streaming
* rendering relative to the camera
* physics simulation origin shifting
* 64-bit world coordinates

## Worlds Coordinates Precision

Flax Engine by default uses `32-bit` precision (single precision, `float` type) to represent object coordinates in the world. This gives enough quality for most games and yields solid performance. However, for games with larger worlds, we recommend using `64-bit` precision (double precision, `double` type) and enabling Large Worlds features in the engine. This allows the game scenes to be as large as the whole Solar System while still maintaining good quality and precision.

### Enabling Large Worlds

Use [Custom Engine build](custom-engine.md) and modify `Flax.flaxproj` file by setting `"UseLargeWorlds": true`. Then build the engine. It will overlap all Vector2/3/4 components from `float` into `double` and store object coordinates with higher precision.

The engine supports loading and saving projects with both `UseLargeWorlds` enabled and disabled without any compatibility issues. Which means that you can still open project with default engine version, even if it was edited with Large Worlds support enabled.

### Real type

When using large worlds various in-built types get converted into higher precision format, such as:
* `Vector2`, `Vector3`, `Vector4`
* `BoundingBox`
* `BoundingSphere`
* `OrientedBoundingBox`
* `Plane`
* `Ray`
* `Triangle`
* `Transform` (only position, scale remains as Float3)

You can detect whether your code is compiled with 64-bit support by using `USE_LARGE_WORLDS` preprocessor definition. With `Real` type definition you can overlap types in your code to support both build modes (with or without large worlds).

# [C#](#tab/code-csharp)
```cs
#if USE_LARGE_WORLDS
using Real = System.Double;
#else
using Real = System.Single;
#endif

Real coordinate = Actor.Position.X;
```
# [C++](#tab/code-cpp)
```cpp
Real coordinate = GetActor()->GetPosition().X;
```
***

## Render View origin

Flax contains relative-to-camera rendering which allows to shift the `Origin` of the whole scene when rendering. It's automatically calculated when rendering a scene with `LargeWorlds.UpdateOrigin` based on the current camera location. It can be disabled with `LargeWorlds.Enable`.

> [!TIP]
> Even when using 64-bit precision, the whole rendering still uses 32-bits as using larger data has high-performance impact.

## Physics origin

A physical simulation system supports adjusting the origin of the simulation world. This can be used to improve collisions and forces simulation because the underlying PhysX library uses 32-bit precision and won't achieve high-quality simulation in large worlds scenario.

You can easily synchronize the current main game view origin with physics origin (or manually calculate it with `LargeWorlds.UpdateOrigin`):

# [C#](#tab/code-csharp)
```cs
Physics.DefaultScene.Origin = MainRenderTask.Instance.View.Origin;
```
# [C++](#tab/code-cpp)
```cpp
Physics::DefaultScene->SetOrigin(MainRenderTask::Instance->View.Origin);
```
***

Finally, your game can use multiple PhysicsScenes and use them to simulate separate parts of the world at different frequencies and different world origins.
