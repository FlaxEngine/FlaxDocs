# Screenshots

Flax supports in-build screenshots taking utilities. You game capture the contents of the render target or the scene rendering task output and save it to file.

## Example code

Here is an example usage code that captures the screenshot of the game viewport and saves it to file.

```cs
// Pick a path to the output file
var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "screenshot.png");

// Caprute game screen to file (done in async)
FlaxEngine.Utilities.Screenshot.Capture(MainRenderTask.Instance, path);
```

