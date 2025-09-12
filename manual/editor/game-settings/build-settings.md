# Build Settings

Build settings asset specifies the Game Cooker options and contains set of game building presets.
For editing and using presets see [Game Cooker window](../game-cooker/index.md) as it has a better interface to do it.

## Properties

![Flax Build Settings](media/build-settings.jpg)

| Property | Description |
|--------|--------|
| **Output Name** | Name of the output app created by the build system. Used to rename main executable (eg. `MyGame.exe`) or final package name (eg. `MyGame.apk`). Custom tokens: `${PROJECT_NAME}`, `${COMPANY_NAME}`. |
| **Max assets per package** | The maximum amount of assets to include into a single assets package. Assets will be split into several packages if needed. |
| **Max package size (in MB)** | The maximum size of the single assets package (in megabytes). Assets will be split into several packages if need to. |
| **Content Key** | The game content cooking keys. Use the same value for a game and DLC packages to support loading them by the built game. Use 0 to randomize it during building. |
| **For Distribution** | If checked, the builds produced by the Game Cooker will be treated as for final game distribution (eg. for game store upload). Builds done this way cannot be tested on console devkits (eg. Xbox One, Xbox Scarlett). |
| **Skip Packaging** | If checked, the output build files won't be packaged for the destination platform. Useful when debugging build from local PC. |
|||
| **Additional Assets** | The additional assets to include into build (into root assets set). |
| **Additional Scenes** | The additional scenes to include into build (into root assets set). |
| **Additional Asset Folders** | The additional folders with assets to include into build (into root assets set). List of paths relative to the project directory or absolute paths. |
|||
| **Shaders No Optimize** | Disables shader compiler optimizations in the cooked game. Can be used to debug shaders on a target platform or to speed up the shaders compilation time. |
| **Shaders Generate Debug Data** | Enables shader debug data generation for shaders in cooked game (depends on the target platform rendering backend). |
| **Skip Default Fonts** | If checked, skips bundling default engine fonts for UI. Use if to reduce build size if you don't use default engine fonts but custom ones only. |
| **Max Mesh Position Error** | The maximum acceptable mesh vertex position error (in world units) for data quantization. Use `0` to disable this feature. Affects meshes during import (or reimpport). |
|||
| **Skip .NET Runtime Packaging** | If checked, .NET Runtime won't be packaged with a game and will be required by user to be installed on system upon running game build. Available only on supported platforms such as Windows, Linux and macOS. |
| **Skip Unused .NET Runtime Libs Packaging** | If checked, .NET Runtime packaging will skip unused libraries from packaging resulting in smaller game builds. |
|||
| **Presets** | The build [presets](https://docs.flaxengine.com/api/FlaxEditor.Content.Settings.BuildPreset.html). |
