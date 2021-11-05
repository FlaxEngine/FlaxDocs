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

## Example Using Layer Mask

Frequently you want a raycast to start from the player's position, however, such a raycast will instantly detect the player's collider. The correct way of solving this is to use the [layers feature](../editor/game-settings/layers-and-tags-settings.md).

To do so, assign a different layer to the player and colliders. You can also assign different layers to different groups of colliders. 
Then, in the raycast function, set the `layerMask` accordingly. The layer mask uses one bit for each layer. For example, to only check collisions with colliders from layer 3, you would typically use `1 << 3` as the layer mask.

```cs
public override void OnUpdate()
{
    // Collision with all layers, except layer 1
    if (Physics.RayCast(Actor.Position, Actor.Direction, out RayCastHit hit, layerMask: ~(1U << 1)))
    {
        DebugDraw.DrawSphere(new BoundingSphere(hit.Point, 50), Color.Red);
    }
}
```

## Example raycast with mesh data access

If Raycast hit mesh collider or terrain it contains `FaceIndex` (an index of the face that was hit) and `UV` (barycentric coordinates of hit triangle). Those can be used to access the geometry data that was used to cook the hit collider. One example would be reading the vertex colors or normal vectors of the hit mesh geometry.

To do so you can use `CollisionData.GetModelTriangle` method which converts the face index of the mesh collider into index of the geometry that was used for cooking collision. It's supported only for collision data built as triangle mesh and without `ConvexMeshGenerationFlags.SuppressFaceRemapTable` flag set.

After retrieving the source mesh and its triangle index you can get the index and vertex buffers to read the data of the hit triangle. If the data is accessed frequently for similar meshes, try to use caching or use C++ API that contains improved data access and internal cache by default.

```cs
public class RaycastUV : Script
{
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
                    var indexBuffer = mesh.DownloadIndexBuffer();
                    var vertexBuffer = mesh.DownloadVertexBuffer();

                    // Get the hit triangle data
                    ref var v0 = ref vertexBuffer[indexBuffer[triangle * 3 + 0]];
                    ref var v1 = ref vertexBuffer[indexBuffer[triangle * 3 + 1]];
                    ref var v2 = ref vertexBuffer[indexBuffer[triangle * 3 + 2]];

                    // Interpolate normal of the triangle using the barycentric coordinate of the hit
                    var n = v0.Normal * (1.0f - hit.UV.X - hit.UV.Y) + v1.Normal * hit.UV.X + v2.Normal * hit.UV.Y;

                    // Transform mesh data into world-space
                    n = Vector3.Normalize(n);
                    var t = hit.Collider.Transform;
                    n = t.TransformDirection(n);
                    var p0 = t.LocalToWorld(v0.Position);
                    var p1 = t.LocalToWorld(v1.Position);
                    var p2 = t.LocalToWorld(v2.Position);

                    // Display hit geometry normal and the triangle
                    DebugDraw.DrawTriangle(p0, p1, p2, Color.Green.AlphaMultiplied(0.5f), 10000);
                    DebugDraw.DrawLine(hit.Point, hit.Point + n * 30.0f, Color.Red, 10000);
                }
            }
        }
    }
}
```
