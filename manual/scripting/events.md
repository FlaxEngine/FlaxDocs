# Script events

Scripts in Flax does not work like the traditional programs where code runs continuously in a loop until end.
Instead, Flax calls declared in script functions to handle speific game events like update or physics collision.
These functions are called **event functions** because they are executed by Flax in response to events that occur during a gameplay. Using these function allows you to implement a gameplay logic and handle different situations inside a game.

```cs
public class MyScript : Script
{
	public override void OnStart()
	{
		// Here you can add code that needs to be called when script is created
	}

	public override void OnUpdate()
	{
		// Here you can add code that needs to be called every frame
	}
}
```

## Event functions

The following table lists all the available event functions to override from the base **Script** class.

> [!TIP]
> You don't have to call the base class methods if you script inherits directly from Script type. The default implementations are empty.

| Event | Description |
|--------|--------|
| **void OnAwake()** | Called after the object is loaded. Before the enabling it or calling start. |
| **void OnEnable()** | Called when object becomes enabled and active. |
| **void OnDisable()** | Called when object becomes disabled and inactive. |
| **void OnDestroy()** | Called before the object will be destroyed. |
| **void OnStart()** | Called when a script is enabled just before any of the Update methods is called for the first time. |
| **void OnUpdate()** | Called every frame if object is enabled. |
| **void OnLateUpdate()** | Called every frame (after *Update*) if object is enabled. |
| **void OnFixedUpdate()** | Called every fixed framerate frame if object is enabled. |
| **void OnDebugDraw()** | Called during drawing debug shapes in editor. Use [DebugDraw](https://docs.flaxengine.com/api/FlaxEngine.DebugDraw.html). |
| **void OnDebugDrawSelected()** | Called during drawing debug shapes in editor when the object is selected. Use [DebugDraw](https://docs.flaxengine.com/api/FlaxEngine.DebugDraw.html). |

