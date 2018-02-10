# Gamepads

**Gamepads** are the most popular input devices for consoles and desktop. Flax supports up to 8 gamepad devices connected at once. Also, each gamepad can use a custom buttons/triggers layout. This helps with handling different types of gamepads.

## Accessing the gamepads

Use [Input.Gamepads](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_Gamepads) property to get the current gamepads collection. Each gamepad can be identified by the ID and the Name provided by the operating system.

You can use [Gamepad](https://docs.flaxengine.com/api/FlaxEngine.Gamepad.html) object methods to read the raw device state and set the vibration or the layout.

Here is an example code that lists all the connected gamepads:

```cs
foreach (var gamepad in Input.Gamepads)
	Debug.Log("Gamepad: " + gamepad.Name + "(" + gamepad.ProductID + ")");
```

## Gamepads scanning

Flax input layer supports detecting connected gamepads at runtime. Some platforms (eg. Xbox One) do it by auto but on other (eg. Windows) game should handle this. By default, [Input.AutoGamepadsScanInterval](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_AutoGamepadsScanInterval) property is used to perform an automatic gamepads scan every few seconds. However you may want to disable it and perform a manual scan using [Input.ScanGamepads](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_ScanGamepads) method.

If you want to detect any gamepads changes (connect/disconnect) use [Input.GamepadsChanged](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GamepadsChanged) event. It's always called on the main app thread before the scripts update or during *ScanGamepads* call. This helps with detecting new/old players for local multiplayer games.



