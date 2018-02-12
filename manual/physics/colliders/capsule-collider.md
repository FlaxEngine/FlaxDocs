# Capsule Collider

![Capsule Collider](media/capsule.png)

A capsule-shaped primitive collider. Capsules are cylinders with a half-sphere at each end.

## Properties

![Properties](media/capsule-properties.jpg)

| Property | Description |
|--------|--------|
| **Is Trigger** | If checked, collider will be a trigger. See [Triggers](../triggers.md) documentation to learn more. |
| **Contact Offset** | Colliders whose distance is less than the sum of their ContactOffset values will generate contacts. The contact offset must be positive. Contact offset allows the collision detection system to predictively enforce the contact constraint even when the objects are slightly separated. |
| **Material** | The physical material used to define the collider physical properties. |
| **Center** | The center of the collider, measured in the object's local space. |
| **Radius** | The radius of the sphere, measured in the object's local space. It will be scaled by the actor's world scale. |
| **Height** | The height of the capsule, measured in the object's local space. It will be scaled by the actor's world scale. |
