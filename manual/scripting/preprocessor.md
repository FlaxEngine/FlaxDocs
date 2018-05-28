# Preprocessor variables

If you're developing for multiple platforms, you often need to write custom code for each platform. In most cases, the best way to do this is to use [Application.Platform](https://docs.flaxengine.com/api/FlaxEngine.Application.html#FlaxEngine_Application_Platform) and [GraphicsDevice.RendererType](https://docs.flaxengine.com/api/FlaxEngine.Rendering.GraphicsDevice.html#FlaxEngine_Rendering_GraphicsDevice_RendererType). Alternatively, you can use preprocessor variables which come heandy when you need to add editor-only code or compiled for selected platforms.

## Example

```cs
private void Start()
{
#if FLAX_EDITOR
    Debug.Log("Ups! It's Editor!");
#else
}
```

## Defines

| Define | Description |
|--------|--------|
| **FLAX_EDITOR** | Compile for editor (play in-edior). |
| **FLAX_EDITOR_WIN** | Compile for editor on Windows. |
| **FLAX_WINDOWS** | Compile for Windows. |
| **FLAX_UWP** | Compile for Universal Windows Platform (UWP). |
| **FLAX_WSA** | Compile for Windows Store. |
| **FLAX_XBOX_ONE** | Compile for Xbox One. |
| **FLAX_X** | Used to detect Flax version during compilation. X=major version of Flax. eg. `FLAX_1` |
| **FLAX_X_Y** | Used to detect Flax version during compilation. X=major version of Flax. Y=minor version of Flax. eg. `FLAX_1_2` |
| **FLAX_X_Y_Z** | Used to detect Flax version during compilation. X=major version of Flax. Y=minor version of Flax, Z=build number of Flax. eg. `FLAX_1_2_6554` |

To specify custom compilation macros see [Game Cooker](../editor/game-cooker/index.md) and [Game Settings](../editor/game-settings/index.md) documentation.

