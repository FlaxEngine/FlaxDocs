# Spherical Joint

**Spherical Joint** constrains the origins of the actors to be coincident.
It removes all translational degrees of freedom but allows all rotational degrees of freedom. Essentially this ensures that the anchor points of the two bodies are always coincident. Bodies are allowed to rotate around the anchor points, and their rotatation can be limited by an elliptical cone.

## Properties

![Properties](media/spherical-joint-properties.jpg)

| Property | Description |
|--------|--------|
| **Target** | The target actor for the joint. It has to be **RigidBody** or **CharacterController**. |
| **Break Force** | Determines the maximum force the joint can apply before breaking. Broken joints no longer participate in physics simulation. |
| **Break Torque** | Determines the maximum torque the joint can apply before breaking. Broken joints no longer participate in physics simulation. |
| **Enable Collision** | Determines whether a collision between the two bodies managed by the joint is enabled. |
| **Enable Auto Anchor** | Determines whether use automatic target anchor position and rotation based on the joint world-space frame (computed when creating joint). |
| **Target Anchor** | This is the relative pose which locates the joint frame relative to the target actor. |
| **Target Anchor Rotation** | This is the relative pose rotation which locates the joint frame relative to the target actor. |
| **Flags** | Controls joint behaviour. |
| **Limit** | Determines a limit that constrains the movement of the joint to a specific minimum and maximum distance. You must enable the limit flag on the joint in order for this to be recognized. See [LimitConeRange](https://docs.flaxengine.com/api/FlaxEngine.LimitConeRange.html) to learn more. |

