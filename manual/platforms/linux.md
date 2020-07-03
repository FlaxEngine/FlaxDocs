# Linux

## Technical information

Flax is compiled for Linux platform using **Clang 7.0** compiler and uses **X11**. Binaries are tested on Ubuntu 18.

If your device has multiple GPUs installed you can select one using the cmd line argument: `-nvidia`, `-intel`, or `-amd`. Flax uses **Vulkan** for rendering.

If your game build runs on Linux as a server build then you can pass `-mute -null -headless -std` command line arguments to disable specific features (audio, graphics, window, log to std). To elarn more about command line access see [this page](../editor/advanced/command-line-access.md).

## Build options

![Build Options](media/build-linux.jpg)

| Property | Description |
|--------|--------|
| **Output** | The builded game output folder (relative to the project). |
| **Show Output** | If checked, after building the output folder will be shown in an Explorer. |
| **Configuration Mode** | Game building mode. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Release**</td><td>The release build ready for shipment.</td></tr><tr><td>**Debug**</td><td>The debug build for testing and profiling. Most of the code optimizations are disabled for the best debugging experience.</td></tr><tr><td>**Development**</td><td>The development build for testing and profiling but is more optimized for runtime than Debug build.</td></tr></tbody></table>|
| **Defines** | Array of custom script defines to use during source code compilation. |

## Platform settings

![Settings](media/settings-linux.jpg)

| Property | Description |
|--------|--------|
| **Window Mode** | The default game window mode. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Windowed**</td><td>The window has borders and does not take up the full screen.</td></tr><tr><td>**Fullscreen**</td><td>The window exclusively takes up the full screen.</td></tr><tr><td>**Borderless**</td><td>The window behaves like in Windowed mode but has no borders.</td></tr><tr><td>**Fullscreen Borderless**</td><td>Same as in Borderless, but is of the size of the screen.</td></tr></tbody></table> |
| **Screen Width** | The default game window width (in pixels). |
| **Screen Height** | The default game window height (in pixels). |
| **Resizable Window** | Enables resizing the game window by the user. |
| **Run In Background** | Enables game running when application window loses focus. |
| **Force Single Instance** | Limits maximum amount of concurrent game instances running to one, otherwise user may launch application more than once. |
| **Override Icon** | Custom icon texture to use for the application (overrides the default one). |
| **Support Vulkan** | Enables support for Vulkan. Disabling it reduces compiled shaders count. |
