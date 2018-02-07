# Script events

Scripts in Flax does not work like the traditional programs where code runs continuously in a loop until end.
Instead, Flax calls declared in script functions to handle speific game events like update or physics collision.
These functions are called **event functions** because they are executed by Flax in response to events that occur during a gameplay. Using these function allows you to implement a gameplay logic and handle different situations inside a game.

```cs
public class MyScript : Script
{
	private void Start()
	{
		// Here you can add code that needs to be called when script is created
	}

	private void Update()
	{
		// Here you can add code that needs to be called every frame
	}
}
```

## Event functions

The following table lists all the available event functions.

| Event | Signature | Description |
|--------|--------|--------|
|**Awake**| `void Awake()` | Called after the object is loaded. |
|**OnEnable**| `void OnEnable()` | Called when object becomes enabled and active. |
|**OnDisable**| `void OnDisable()` | Called when object becomes disabled and inactive. |
|**OnDestroy**| `void OnDestroy()` | Called before the object will be destroyed.. |
|**Start**| `void Start()` | Called when a script is enabled just before any of the Update methods is called for the first time. |
|**Update**| `void Update()` | Called every frame if object is enabled. |
|**LateUpdate**| `void LateUpdate()` | Called every frame (after *Update*) if object is enabled. |
|**FixedUpdate**| `void FixedUpdate()` | Called every fixed framerate frame if object is enabled. |
|**OnDebugDraw**| `void OnDebugDraw()` | Called during drawing debug shapes in editor. Use [DebugDraw](https://docs.flaxengine.com/api/FlaxEngine.DebugDraw.html). |
|**OnDebugDrawSelected**| `void OnDebugDrawSelected()` | Called during drawing debug shapes in editor when the object is selected. Use [DebugDraw](https://docs.flaxengine.com/api/FlaxEngine.DebugDraw.html). |
|**OnCollisionEnter**| `void OnCollisionEnter(Collision c)` | Called during fixed update when this collider/rigidbody started touching another rigidbody/collider. See also a [Collision](https://docs.flaxengine.com/api/FlaxEngine.Collision.html) structure. |
|**OnCollisionStay**| `void OnCollisionStay(Collision c)` | Called every fixed update when this collider/rigidbody keeps touching another rigidbody/collider. See also a [Collision](https://docs.flaxengine.com/api/FlaxEngine.Collision.html) structure. |
|**OnCollisionExit**| `void OnCollisionExit(Collision c)` | Called during fixed update when this collider/rigidbody ended touching another rigidbody/collider. See also a [Collision](https://docs.flaxengine.com/api/FlaxEngine.Collision.html) structure. |
|**OnTriggerEnter**| `void OnTriggerEnter(Collider c)` | Called during fixed update when the [Collider](https://docs.flaxengine.com/api/FlaxEngine.Collider.html) enters the trigger. |
|**OnTriggerStay**| `void OnTriggerStay(Collider c)` | Called every fixed update when the [Collider](https://docs.flaxengine.com/api/FlaxEngine.Collider.html) keeps touching the trigger. |
|**OnTriggerExit**| `void OnTriggerExit(Collider c)` | Called during fixed update when the [Collider](https://docs.flaxengine.com/api/FlaxEngine.Collider.html) leaves the trigger. |
|**OnJointBreak**| `void OnJointBreak()` | Called when joint, that script is attached to, gets broken. |

> [!WARNING]
> Use the exact signature (the same return type and the same arguments) because otherwise, it may crash your game.

