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
