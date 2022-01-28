# macOS

## Technical information

Flax supports **macOS 10.14 or newer**. For graphics rendering Vulkan is used via MoltenVK to run on Metal.

## Build options

| Property | Description |
|--------|--------|
| **Output** | The builded game output folder (relative to the project). |
| **Show Output** | If checked, after building the output folder will be shown in an Explorer. |
| **Configuration Mode** | Game building mode. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Release**</td><td>The release build ready for shipment.</td></tr><tr><td>**Debug**</td><td>The debug build for testing and profiling. Most of the code optimizations are disabled for the best debugging experience.</td></tr><tr><td>**Development**</td><td>The development build for testing and profiling but is more optimized for runtime than Debug build.</td></tr></tbody></table>|

## Platform settings

| Property | Description |
|--------|--------|
| **App Identifier** | The app identifier (reversed DNS, eg. com.company.product). Custom tokens: `${PROJECT_NAME}`, `${COMPANY_NAME}`. |
| **Window Mode** | The default game window mode. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Windowed**</td><td>The window has borders and does not take up the full screen.</td></tr><tr><td>**Fullscreen**</td><td>The window exclusively takes up the full screen.</td></tr><tr><td>**Borderless**</td><td>The window behaves like in Windowed mode but has no borders.</td></tr><tr><td>**Fullscreen Borderless**</td><td>Same as in Borderless, but is of the size of the screen.</td></tr></tbody></table> |
| **Screen Width** | The default game window width (in pixels). |
| **Screen Height** | The default game window height (in pixels). |
| **Resizable Window** | Enables resizing the game window by the user. |
| **Override Icon** | Custom icon texture to use for the application (overrides the default one). |
| **Run In Background** | Enables game running when application window loses focus. |
