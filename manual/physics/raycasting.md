# Raycasting

By using **Raycasts** game scripts can detect various geometry intersections. For instance, you can perform various overlap tests and raycasts to scan the space around the player. Probably the most common case is to use raycast to place a third-person camera right behind the player but without clipping the scene objects.

Flax provides various C# API for raycasting and geometry tests:
* [Physics.RayCast](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_RayCast_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_RayCastHit__System_Single_System_Int32_System_Boolean_)
* [Physics.RayCastAll](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#collapsible-FlaxEngine_Physics_RayCastAll_FlaxEngine_Vector3_FlaxEngine_Vector3_System_Single_System_Int32_System_Boolean_)
* [Physics.BoxCast](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_BoxCast_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Quaternion_System_Single_System_Int32_System_Boolean_)
* [Physics.BoxCastAll](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_BoxCastAll_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Quaternion_System_Single_System_Int32_System_Boolean_)
* [Physics.SphereCast](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_SphereCast_FlaxEngine_Vector3_System_Single_FlaxEngine_Vector3_FlaxEngine_RayCastHit__System_Single_System_Int32_System_Boolean_)
* [Physics.SphereCastAll](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_SphereCastAll_FlaxEngine_Vector3_System_Single_FlaxEngine_Vector3_System_Single_System_Int32_System_Boolean_)
* [Physics.CheckBox](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_CheckBox_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Quaternion_System_Int32_System_Boolean_)
* [Physics.CheckSphere](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_CheckSphere_FlaxEngine_Vector3_System_Single_System_Int32_System_Boolean_)
* [Physics.OverlapBox](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_OverlapBox_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Quaternion_System_Int32_System_Boolean_)
* [Physics.OverlapSphere](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_OverlapSphere_FlaxEngine_Vector3_System_Single_System_Int32_System_Boolean_)

Additionally you can perform similar tests for single collider using [Collider.RayCast](https://docs.flaxengine.com/api/FlaxEngine.Collider.html#FlaxEngine_Collider_RayCast_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_RayCastHit__System_Single_) and [Collider.ClosestPoint](https://docs.flaxengine.com/api/FlaxEngine.Collider.html#FlaxEngine_Collider_ClosestPoint_FlaxEngine_Vector3_) methods.

## Example

This code sends a raycast from the object location and draws a red sphere at the hit location.

# [C#](#tab/code-csharp)
```cs
public override void OnUpdate()
{
    RayCastHit hit;
    if (Physics.RayCast(Actor.Position, Actor.Direction, out hit))
    {
        DebugDraw.DrawSphere(new BoundingSphere(hit.Point, 50), Color.Red);
    }
}
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Physics/Physics.h"
#include "Engine/Debug/DebugDraw.h"

void MyScript::OnUpdate() override
{
    RayCastHit hit;
    if (Physics::RayCast(GetActor()->GetPosition(), GetActor()->GetDirection(), hit))
    {
        DEBUG_DRAW_SPHERE(BoundingSphere(hit.Point, 50), Color::Red, 0.0f, true);
    }
}
```
***

## Example Using Layer Mask

Frequently you want a raycast to start from the player's position, however, such a raycast will instantly detect the player's collider. The correct way of solving this is to use the [layers feature](../editor/game-settings/layers-and-tags-settings.md).

To do so, assign a different layer to the player and colliders. You can also assign different layers to different groups of colliders. Then, in the raycast function, set the `layerMask` accordingly. The layer mask uses one bit for each layer. For example, to only check collisions with colliders from layer 3, you would typically use `1 << 3` as the layer mask. Use `LayersMask` structure to pick the selection of layers via editor popup.

# [C#](#tab/code-csharp)
```cs
public LayersMask Layers;

public override void OnUpdate()
{
    if (Physics.RayCast(Actor.Position, Actor.Direction, out RayCastHit hit, float.MaxValue, Layers))
    {
        DebugDraw.DrawSphere(new BoundingSphere(hit.Point, 50), Color.Red);
    }
}
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Core/Types/LayersMask.h"
#include "Engine/Physics/Physics.h"
#include "Engine/Debug/DebugDraw.h"

API_FIELD() LayersMask Layers;

void MyScript::OnUpdate() override
{
    RayCastHit hit;
    if (Physics::RayCast(GetActor()->GetPosition(), GetActor()->GetDirection(), hit, MAX_float, Layers))
    {
        DEBUG_DRAW_SPHERE(BoundingSphere(hit.Point, 50), Color::Red, 0.0f, true);
    }
}
```
***

## Example raycast with mesh data access

If Raycast hit mesh collider or terrain it contains `FaceIndex` (an index of the face that was hit) and `UV` (barycentric coordinates of hit triangle). Those can be used to access the geometry data that was used to cook the hit collider. One example would be reading the vertex colors or normal vectors of the hit mesh geometry.

To do so you can use `CollisionData.GetModelTriangle` method which converts the face index of the mesh collider into index of the geometry that was used for cooking collision. It's supported only for collision data built as triangle mesh and without `ConvexMeshGenerationFlags.SuppressFaceRemapTable` flag set.

After retrieving the source mesh and its triangle index you can get the index and vertex buffers to read the data of the hit triangle. If the data is accessed frequently for similar meshes, try to use caching or use C++ API that contains improved data access and internal cache by default.

# [C#](#tab/code-csharp)
```cs
public override void OnUpdate()
{
    // Try to hit something with a mouse click
    if (!Input.GetMouseButtonDown(MouseButton.Left))
        return;
    var pos = Input.MousePosition;
    var ray = Camera.MainCamera.ConvertMouseToRay(pos);
    if (!Physics.RayCast(ray.Position, ray.Direction, out var hit))
        return;

    Debug.Log("Hit UV: " + hit.UV);

    // Check if mouse clicked on a mesh collider
    if (hit.Collider is MeshCollider meshCollider)
    {
        // Read the source geometry triangle based on the hit face index
        if (meshCollider.CollisionData.GetModelTriangle(hit.FaceIndex, out var meshBase, out var triangle))
        {
            Debug.Log("Hit mesh: " + (meshBase != null ? meshBase.ModelBase.Path : "<null>"));
            Debug.Log("Hit triangle: " + triangle);

            if (meshBase is Mesh mesh)
            {
                // Access static mesh data
                var accessor = new MeshAccessor();
                if (accessor.LoadMesh(mesh))
                {
                    Debug.LogError("Failed to get mesh data");
                    return;
                }

                // Get the hit triangle data
                var indexStream = accessor.Index();
                var i0 = indexStream.GetInt((int)triangle * 3 + 0);
                var i1 = indexStream.GetInt((int)triangle * 3 + 1);
                var i2 = indexStream.GetInt((int)triangle * 3 + 2);

                // Interpolate normal of the triangle using the barycentric coordinate of the hit
                var normalStream = accessor.Normal();
                var n0 = normalStream.GetFloat3(i0);
                var n1 = normalStream.GetFloat3(i1);
                var n2 = normalStream.GetFloat3(i2);
                MeshAccessor.UnpackNormal(ref n0);
                MeshAccessor.UnpackNormal(ref n1);
                MeshAccessor.UnpackNormal(ref n2);
                var n = n0 * (1.0f - hit.UV.X - hit.UV.Y) + n1 * hit.UV.X + n2 * hit.UV.Y;

                // Transform mesh data into world-space
                var positionStream = accessor.Position();
                n = Vector3.Normalize(n);
                var t = hit.Collider.Transform;
                n = t.TransformDirection(n);
                var p0 = t.LocalToWorld(positionStream.GetFloat3(i0));
                var p1 = t.LocalToWorld(positionStream.GetFloat3(i1));
                var p2 = t.LocalToWorld(positionStream.GetFloat3(i2));

                // Display hit geometry normal and the triangle
                DebugDraw.DrawTriangle(p0, p1, p2, Color.Green.AlphaMultiplied(0.5f), 10000);
                DebugDraw.DrawLine(hit.Point, hit.Point + n * 30.0f, Color.Red, 10000);
            }
        }
    }
}
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Core/Log.h"
#include "Engine/Input/Input.h"
#include "Engine/Physics/Physics.h"
#include "Engine/Level/Actors/Camera.h"
#include "Engine/Physics/Colliders/MeshCollider.h"
#include "Engine/Graphics/Models/MeshAccessor.h"
#include "Engine/Debug/DebugDraw.h"

void MyScript::OnUpdate() override
{
    // Try to hit something with a mouse click
    if (!Input::GetMouseButtonDown(MouseButton::Left))
        return;
    auto pos = Input::GetMousePosition();
    auto ray = Camera::GetMainCamera()->ConvertMouseToRay(pos);
    RayCastHit hit;
    if (!Physics::RayCast(ray.Position, ray.Direction, hit))
        return;

    LOG(Info, "Hit UV: {}", hit.UV);

    // Check if mouse clicked on a mesh collider
    if (const auto* meshCollider = Cast<MeshCollider>(hit.Collider))
    {
        // Read the source geometry triangle based on the hit face index
        MeshBase* meshBase;
        uint32 triangle;
        if (meshCollider->CollisionData->GetModelTriangle(hit.FaceIndex, meshBase, triangle))
        {
            LOG(Info, "Hit mesh: {}", meshBase ? meshBase->GetModelBase()->GetPath() : TEXT("<null>"));
            LOG(Info, "Hit triangle: {}", triangle);

            if (auto* mesh = Cast<Mesh>(meshBase))
            {
                // Access static mesh data
                MeshAccessor accessor;
                if (accessor.LoadMesh(mesh))
                {
                    LOG(Error, "Failed to get mesh data");
                    return;
                }

                // Get the hit triangle data
                auto indexStream = accessor.Index();
                auto i0 = indexStream.GetInt(triangle * 3 + 0);
                auto i1 = indexStream.GetInt(triangle * 3 + 1);
                auto i2 = indexStream.GetInt(triangle * 3 + 2);

                // Interpolate normal of the triangle using the barycentric coordinate of the hit
                auto normalStream = accessor.Normal();
                auto n0 = normalStream.GetFloat3(i0);
                auto n1 = normalStream.GetFloat3(i1);
                auto n2 = normalStream.GetFloat3(i2);
                MeshAccessor::UnpackNormal(n0);
                MeshAccessor::UnpackNormal(n1);
                MeshAccessor::UnpackNormal(n2);
                auto n = n0 * (1.0f - hit.UV.X - hit.UV.Y) + n1 * hit.UV.X + n2 * hit.UV.Y;

                // Transform mesh data into world-space
                auto positionStream = accessor.Position();
                n = Vector3::Normalize(n);
                auto t = hit.Collider->GetTransform();
                n = Vector3::Transform(n, t.Orientation);
                auto p0 = t.LocalToWorld(positionStream.GetFloat3(i0));
                auto p1 = t.LocalToWorld(positionStream.GetFloat3(i1));
                auto p2 = t.LocalToWorld(positionStream.GetFloat3(i2));
                auto p2 = t.LocalToWorld(v02.Position);

                // Display hit geometry normal and the triangle
                DEBUG_DRAW_TRIANGLE(p0, p1, p2, Color::Green.AlphaMultiplied(0.5f), 10000, true);
                DEBUG_DRAW_LINE(hit.Point, hit.Point + n * 30.0f, Color::Red, 10000, true);
            }
        }
    }
}
```
***
