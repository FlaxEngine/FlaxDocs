# Access Game Window

Flax automatically creates the main window for the game. Some platforms allow to customzie it (eg. desktop) while on other platforms access to it is fixed (eg. consoles). Hovewer Flax supports API for creating custom windows (multi-window setup) and you can also access the pre-created window from your scripts.

## Change window title

To change the title of you game window simply access the root control for the game UI and peek it's parent window.

```cs
#if !FLAX_EDITOR
RootControl.GameRoot.RootWindow.Window.Title = "Hello!"
#endif
```

You can also resize or adjust the window manually.

## Managing cursor and focus

Engine provides a utility to show/hide and constrain mouse cursor via: `Screen.CursorVisible` and `CursorLock.CursorLockMode` properties. Cursor lock modes are:
* `None` - the default mode.
* `Locked` -  cursor position is locked to the center of the game window. Ideal for FPS games.
* `Clipped` - cursor position is confined to the bounds of the game window. Ideal for RTS/Strategy games.

Your game camera script can manage those and use `Engine.HasGameViewportFocus` property to detect whether game viewport is focused by the player, which is well supported in Ediotr to allow developer debug game while it's running in one of the Editor windows:

```cs
/// <inheritdoc />
public override void OnUpdate()
{
    if (Engine.HasGameViewportFocus)
    {
        Screen.CursorVisible = false;
        Screen.CursorLock = CursorLockMode.Locked;
    }

    var mouseDelta = new Float2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    pitch = Mathf.Clamp(pitch + mouseDelta.Y, -88, 88);
    yaw += mouseDelta.X;
    // ...more camera logic
}
```

When creating pause menu or game main menu you can use `Engine.FocusGameViewport()` method which focuses the game window and allows player to use UI Navigation (eg. with gamepad or Tab) within the opened UI panel
