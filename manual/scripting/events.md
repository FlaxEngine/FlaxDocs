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

## Order of execution for event functions

Script events are invoked in the following order:

![Script Events Order](media/script-events.png)

### Initialization

Every created and added to *Actor* script receives **OnAwake**. If Script and its parent are active in the hierarchy then **OnStart** and **OnEnable** are being called (on game start or object spawn). Otherwise, this call is postponed until someone enables that script.

Events OnAwake and OnStart can be called only once on a script. OnStart is always called before the first OnEnable.

### Game Logic

Engine main loop update is highly configurable and supports performing the game update, physics update and drawing at different framerates. This means that update, fixed update, and a draw might be desynchronized and not called in the same order. Event **OnUpdate** is called during the game update, then is followed by **OnLateUpdate**. During physics update engine invokes **OnFixedUpdate**. During rendering engine can invoke **OnDebugDraw** and **OnDebugDrawSelected** (used by the editor).

### Deinitialization

On game end all scripts are disabled and **OnDisable** event is called when removing the object from gameplay. Then during actual object destruction, the **OnDestroy** is invoked. Also, if the script gets inactive (eg. someone disables it or one of its parents in hierarchy) then engine invokes **OnDisable**. The disabled script can be activated again and receive *OnEnable* to begin being part of the gameplay logic.

Event OnDestroy can be called only once on a script. Flax does not uses script anymore after OnDestroy event invocation.

### Events in Editor

Flax does not invoke any script events during `edit-time` (when the scene is loaded and user modifies it) except **OnDebugDraw** and **OnDebugDrawSelected**. Only when in-build play mode starts the actual game logic is being simulated. However, if the game script wants to receive events during editing it can be marked with `[ExecuteInEditMode]` attribute. Then all events will be called normally.
