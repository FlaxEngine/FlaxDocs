# Mouse

The **Mouse** is one of the most common input devices on desktop platforms. You can access the mouse state by using the Input class:
* [Input.MousePosition](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_MousePosition)
* [Input.MousePositionDelta](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_MousePositionDelta)
* [Input.MouseScrollDelta](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_MouseScrollDelta)
* [Input.GetMouseButton](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GetMouseButton_FlaxEngine_MouseButton_)
* [Input.GetMouseButtonDown](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GetMouseButtonDown_FlaxEngine_MouseButton_)
* [Input.GetMouseButtonUp](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GetMouseButtonUp_FlaxEngine_MouseButton_)

## Locking cursor

In some games you may want to lock the mouse position or hide the cursor during gameplay. For instance, first-person shooter games usually need 360-degree camera rotation, and you don't want to click off the game or have the cursor blocking gameplay.

You can lock the mouse movement by using [Screen.CursorLock](https://docs.flaxengine.com/api/FlaxEngine.Screen.html#FlaxEngine_Screen_CursorLock), and modify the cursor visibility by using [Screen.CursorVisible](https://docs.flaxengine.com/api/FlaxEngine.Screen.html#FlaxEngine_Screen_CursorVisible).

## Usage

In your C# script you can read mouse button inputs:

```cs
public override void OnUpdate()
{
	if (Input.GetMouseButton(MouseButton.Left))
    {
        Debug.Log("Left mouse button is pressed.");
    }
}
```

You can read how much the mouse has moved:

```cs
public override void OnUpdate()
{
	Float2 delta = Input.MousePositionDelta;
    Debug.Log("The mouse movement since last frame is: " + delta);
}
```

And you can lock and hide the mouse cursor:

```cs
public override void OnStart()
{
	Screen.CursorLock = CursorLockMode.Locked;
    Screen.CursorVisible = false;
}
```
