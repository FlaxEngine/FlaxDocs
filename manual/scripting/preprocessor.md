# Preprocessor variables

If you're developing for multiple platforms, you often need to write custom code for each platform. In most cases, the best way to do this is to use [Platform.Platform](https://docs.flaxengine.com/api/FlaxEngine.Platform.html#FlaxEngine_Application_Platform) and [GPUDevice.RendererType](https://docs.flaxengine.com/api/FlaxEngine.GPUDevice.html#FlaxEngine_GPUDevice_RendererType). Alternatively, you can use preprocessor variables which come heandy when you need to add editor-only code or compiled for selected platforms.

## Example

```cs
public override void OnStart()
{
#if FLAX_EDITOR
    Debug.Log("Ups! It's Editor!");
#else
}
```

## Defines

| Define | Description |
|--------|--------|
| **FLAX** | Always defined. Can be used to detect code compiled for Flax environment. |
| **FLAX_EDITOR** | Compile for editor (play in-edior). |
| **PLATFORM_WINDOWS** | Compile for Windows. |
| **PLATFORM_UWP** | Compile for Universal Windows Platform (UWP). |
| **PLATFORM_XBOX_ONE** | Compile for Xbox One. |
| **PLATFORM_XBOX_SCARLETT** | Compile for Xbox Scarlett. |
| **PLATFORM_PS4** | Compile for PlayStation 4. |
| **PLATFORM_PS5** | Compile for PlayStation 4. |
| **PLATFORM_LINUX** | Compile for Linux. |
| **PLATFORM_ANDROID** | Compile for Android. |
| **PLATFORM_SWITCH** | Compile for Switch. |
| **FLAX_X** | Used to detect Flax version during compilation. X=major version of Flax. eg. `FLAX_1` |
| **FLAX_X_Y** | Used to detect Flax version during compilation. X=major version of Flax. Y=minor version of Flax. eg. `FLAX_1_2` |
| **BUILD_DEBUG** | Compile in `Debug` mode. Full code debugging support without code optimizations. Worst performance but the best debugging experiance. All code checking assertions are enabled. Build intended for programmers to test bugs in code. |
| **BUILD_DEVELOPMENT** | Compile in `Development` mode. Better performance than Debug as code gets optimizations but debugging is still available with most of the assertions and checks. Build intended for developers team to have good ratio between code validation/verification and performance.  |
| **BUILD_RELEASE** | Compile in `Release` mode. The best performance as code gets all optimizations. Build intended for shipping. |

To specify custom compilation macros see [Game Cooker](../editor/flax-build/index.md) documentation.

