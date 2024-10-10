# Virtual Input

**Virtual input** is a Flax feature used to unify the input data across different input devices and runtime platforms. It helps with cross-platform development and adds a convenient abstraction layer between raw input devices and the game scripts. It's highly configurable and can be used in all games made with Flax.

This documentation covers the usage and important parts of the virtual input interface.

## Settings and usage

The first step to using the virtual input is preparing a proper configuration. This is done via the **Input Settings** asset. You can learn more about creating and using these settings on the [Input Settings](input-settings.md) page. If you're using one of the *Flax Templates* it should already contain a proper configuration file in `Content/Settings/Input Settings.json`. Open this asset in the Editor.

![Virtual Input Config](media/virtual-input-config.jpg)

As you can see in the image above, there can be many virtual inputs, and they can handle input from a mouse, keyboard, or controller. For instance, the `Fire` Action is set to trigger on both `Left Mouse Button` and `Gamepad Button B`, and there is an option to add a keyboard input as well. This Action is set to `Press` mode, which means it will trigger an event when the action is activated.

In your C# script you can read the state of the action directly:

```cs
public override void OnUpdate()
{
	if (Input.GetAction("Fire"))
	{
		ShootBall();
	}
}
```

You can also use the [InputEvent](https://docs.flaxengine.com/api/FlaxEngine.InputEvent.html) and [InputAxis](https://docs.flaxengine.com/api/FlaxEngine.InputEvent.html) classes to configure your script further, directly subscribing a method to the `Pressed` Event:

```cs
public InputEvent FireEvent = new InputEvent("Fire");
public InputAxis MouseX = new InputAxis("MouseX");

public OnStart()
{
	// Register for input action event
	FireEvent.Pressed += ShootBall;
}

private void ShootBall()
{
	Debug.Log("Shooting Ball");
}

public override void OnUpdate()
{
	// Read the virtual axis value
	var mouseX = MouseX.Value;
	...
}

public override void OnDestroy()
{
	// Deregister from input action event
	FireEvent.Pressed -= ShootBall;

	// Remember to dispose the action object (it holds reference to your methods)
	FireEvent.Dispose();
	MouseX.Dispose();
}
```

If you select the Actor with this script in the Editor, you can edit the `FireEvent` and `MouseX` inputs without editing the code. 

![Virtual Input Script](media/virtual-input-script-example.jpg)

