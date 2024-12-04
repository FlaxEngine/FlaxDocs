# Command line access

Both Flax Engine and built game (Flax executable) support various input command line arguments.
Using this feature can help with games development and can be involved in testing various scenarios.

It’s very common technique to build games on the separate machines or even in the cloud. For example, [Jenkins](https://jenkins-ci.org/) server can be used to invoke Flax Game Cooker to build game for a QA team so it will be ready right in the morning to test it.

Here is an example command that will build the game project in the Output folder for the Windows platform:

```
FlaxEditor.exe -project "<project-path>" -headless -mute -null -std -build "Development.Windows"
```

To run Flax via Windows **Command Prompt** (`cmd.exe`) with logs use `start /w ...` as follows:

```
start /w FlaxEditor.exe -std -project "<project-path>"
```

To run Flax via Windows **PowerShell** with logs use `Start-Process -Wait ...` as follows:

```
Start-Process -Wait FlaxEditor.exe -Args "-std -project `"<project-path>`""
```

It will also send the log (including C# API [Debug.Log](https://docs.flaxengine.com/api/FlaxEngine.Debug.html#FlaxEngine_Debug_Log_System_Object_)) to the standard process output so in case of issues they can be easily detected. What is, even more, the editor may start without a window (headless mode) and perform some additional actions like clearing cooker cache or project cache.
Of course, all those things can be made manually by using Flax Editor C# API and Editor Plugins (see [here](https://docs.flaxengine.com/api/FlaxEditor.GameCooker.html)).

## Options

| Command | Description |
|--------|--------|
| **-windowed** | Starts the game in windowed mode (even if default built game setting was fullscreen). |
| **-fullscreen** | Starts the game in fullscreen mode (even if default built game setting was windowed). |
| **-vsync** | Forces to enable vertical synchronization when presenting the frame on screen. |
| **-novsync** | Forces to disable vertical synchronization when presenting the frame on screen. |
| **-nolog** | Disables output log file. |
| **-std** | Redirects log to the standard process output (std). |
| **-debug `ip:port`** | Sets the Mono debugger address and port (or just port) used for the remote debugging. The default Mono debugger IP=127.0.0.1, Port=41000+(process_id%1000). Can be just port number to use *localhost*. |
| **-debugwait** | Instructs Mono debugger to wait for client attach for 5 seconds. Can be used to debug initialization code when a standalone game starts. |
| **-headless** | Starts without windows, used by CL. Can be also used in cooked game on desktop platforms. |
| **-lowdpi** | Disables High DPI awareness support. |
| **-vulkan** | Forces to use Vulkan rendering backend (if available). |
| **-d3d12** | Forces to use DirectX 12 rendering backend (if available). |
| **-d3d11** | Forces to use DirectX 11 rendering backend (if available). |
| **-d3d10** | Forces to use DirectX 10 rendering backend (if available). |
| **-null** | Forces to use Null rendering backend. Graphics rendering will be disabled but other game systems will work normally. Highly recommended to use for headless server builds for multiplayer games. |
| **-nvidia** | Hints to use NVIDIA GPU (if available). |
| **-amd** | Hints to use AMD GPU (if available). |
| **-intel** | Hints to use Intel GPU (if available). |
| **-monolog** | Enables advanced debugging for Mono runtime. Can be used to debug problems with managed scripting runtime. Produces lots of logs. |
| **-mute** | Disables audio playback and uses Null Audio Backend. |

## Editor-only options

| Command | Description |
|--------|--------|
| **-project <path>** | Startup project path. It must be specified to start the editor. |
| **-new** | Generates the project files inside the specified project folder or uses current workspace folder. |
| **-play** | Starts the play-mode in Editor after startup. Can open a certain level if provided with asset id (eg. `-play SCENE_ASSET_ID`). |
| **-genProjectFiles** | Generates the scripts project files and exits. |
| **-skipcompile** | Skips the scripts compilation on editor startup, useful when launching engine from IDE. |
| **-shaderdebug** | Enables debugging data generation for shaders and disables shader compiler optimizations. |
| **-shaderprofile** | Enables debugging data generation for shaders but leaves shader compiler optimizations active for performance profiling. |
| **-clearCache** | Clears the project cache before starting the editor. |
| **-clearCooker** | Clears the project Game Cooker cache before starting the editor. |
| **-build `preset.target`** | Starts the game building after editor launch and closes editor after building end. You can specify the single present name to build all its targets or specify both the present name and target name (separated by a dot). You can use braces if your preset/target name contains space characters. |
| **-exit** | Exits the editor after startup and performing all queued actions. Usefull when invoking editor from CL/CD. |
