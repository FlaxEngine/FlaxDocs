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

## Example with ignoring colliders

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


