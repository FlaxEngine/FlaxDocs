# CLion

![CLion](media/clion.png)

You can download CLion [here](https://www.jetbrains.com/clion/).

CLion support is provided through generated CMake facade project files for native C++ development on desktop host platforms: Windows, Linux, and Mac. Generate them by passing `-clion` to the project generation script, for example `GenerateProjectFiles.bat -clion`, `./GenerateProjectFiles.sh -clion`, or `GenerateProjectFiles.command -clion`.

The generated CMake project is written to `Cache/Projects/CMake/<ProjectName>`. Open that directory in CLion as a CMake project. Flax does not generate `.idea` files; CLion owns and updates its own local IDE settings after the project is opened.

This CMake project is an IDE facade, not the primary Flax build system. CMake is used to describe the code model and expose build presets, while actual native build steps are delegated to `Flax.Build`. Run configurations launch the generated engine executable after building it.

CLion project generation intentionally excludes platforms that are not supported by this workflow, including Android, iOS, UWP, Web, GDK/Xbox, PlayStation, and Switch. The generated CLion project does not configure C# debugging; use an IDE or editor with .NET debugging support for managed code.
