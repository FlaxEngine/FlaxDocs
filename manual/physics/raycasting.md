# Raycasting

By using **Raycasts** game scripts can detect various geometry intersections. For instance, you can perform various overlap tests and raycasts to scan the space around the player. Probably the most common case is to use raycast to place a third-person camera right behind the player but without clipping the scene objects.

Flax provides various C# API for raycasting and geometry tests:
* [Physics.RayCast](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_RayCast_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_RayCastHit__System_Single_System_Int32_System_Boolean_)
* [Physics.BoxCast](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_BoxCast_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Quaternion_System_Single_System_Int32_System_Boolean_)
* [Physics.SphereCast](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_SphereCast_FlaxEngine_Vector3_System_Single_FlaxEngine_Vector3_FlaxEngine_RayCastHit__System_Single_System_Int32_System_Boolean_)
* [Physics.CheckBox](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_CheckBox_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Quaternion_System_Int32_System_Boolean_)
* [Physics.CheckSphere](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_CheckSphere_FlaxEngine_Vector3_System_Single_System_Int32_System_Boolean_)
* [Physics.OverlapBox](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_OverlapBox_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_Quaternion_System_Int32_System_Boolean_)
* [Physics.OverlapSphere](https://docs.flaxengine.com/api/FlaxEngine.Physics.html#FlaxEngine_Physics_OverlapSphere_FlaxEngine_Vector3_System_Single_System_Int32_System_Boolean_)

Adidtionally you can perform similar tests for single collider using [Collider.RayCast](https://docs.flaxengine.com/api/FlaxEngine.Collider.html#FlaxEngine_Collider_RayCast_FlaxEngine_Vector3_FlaxEngine_Vector3_FlaxEngine_RayCastHit__System_Single_) and [Collider.ClosestPoint](https://docs.flaxengine.com/api/FlaxEngine.Collider.html#FlaxEngine_Collider_ClosestPoint_FlaxEngine_Vector3_) methods.

## Example

This code sends a raycast from the object location and draws a red sphere at the hit location.

```cs
public void Update()
{
    RayCastHit hit;
    if (Physics.RayCast(Actor.Position, Actor.Direction, out hit))
    {
        DebugDraw.DrawSphere(hit.Point, 50, Color.Red);
    }
}
```
