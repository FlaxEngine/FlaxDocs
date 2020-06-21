# Screenshots

Flax supports in-build screenshots taking utilities. You game capture the contents of the render target or the scene rendering task output and save it to file.

## Example code

Here is an example usage code that captures the screenshot of the game viewport and saves it to file.

```cs
// Pick a path to the output file
var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "screenshot.png");

// Caprute game screen to file (done in async)
FlaxEngine.Screenshot.Capture(MainRenderTask.Instance, path);
```

## In Editor

![Editor Viewport Screenshot](media/viewport-screenshot-2.png)

To take a screenshot of the focused game view or game edit view you can use **F12** key or main menu option **Tools -> Take Screenshot**.

![Game Viewport Screenshot](media/viewport-screenshot-1.png)

If you want to take **high-resolution** screenshot of the game viewport you can *right-click* on the dock window tab and use the option to increase the resolution scale (eg. to 2) and then use additional option for screenshot taking. Saved images are stored in the **project folder/Screenshots** directory.

