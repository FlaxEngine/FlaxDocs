# Gamepads

**Gamepads** are one of the most popular input devices across consoles and desktop. Flax supports having up to 8 gamepad devices connected at once. Also, each gamepad can use a custom buttons/triggers layout. This helps with handling different types of gamepads.

## Accessing the gamepads

Use the [Input.Gamepads](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_Gamepads) property to get the list of all connected gamepads. Each gamepad can be identified by the ID and the Name provided by the operating system.

You can use the [Gamepad](https://docs.flaxengine.com/api/FlaxEngine.Gamepad.html) object methods to read the raw device state and set the vibration or the layout.

Here is an example code that lists all the connected gamepads:

```cs
foreach (var gamepad in Input.Gamepads)
	Debug.Log("Gamepad: " + gamepad.Name + "(" + gamepad.ProductID + ")");
```

## Gamepads scanning

The Flax input layer supports detecting connected gamepads at runtime. Some platforms (eg. Xbox One) expose events for tracking changes in input devices, but other platforms (eg. Windows) handle gamepad changes by default.

If you want to detect any changes in gamepad devices, (connect/disconnect) use the [Input.GamepadsChanged](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GamepadsChanged) event. It's always called on the main app thread before the scripts update. This helps with detecting new/old players for local multiplayer games.



