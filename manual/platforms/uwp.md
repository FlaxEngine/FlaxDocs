# Universal Windows Platform (UWP)

## Build options

![Build Options](media/build-xbox-one.jpg)

| Property | Description |
|--------|--------|
| **Output** | The builded game output folder (relative to the project). |
| **Show Output** | If checked, after building the output folder will be shown in an Explorer. |
| **Configuration Mode** | Game building mode. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Release**</td><td>The release build ready for shipment.</td></tr><tr><td>**Debug**</td><td>The debug build for testing and profiling.</td></tr></tbody></table>|
| **Architecture** | Target platform CPU type. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**x64**</td><td>The 64-bit.</td></tr><tr><td>**x86**</td><td>The 32-bit.</td></tr></tbody></table>|
| **Defines** | Array of custom script defines to use during source code compilation. |

## Platform settings

![Settings](media/settings-uwp.jpg)

| Property | Description |
|--------|--------|
| **Preferred Launch Windowing Mode** | The preferred launch windowing mode. See [WindowMode](https://docs.flaxengine.com/api/FlaxEditor.Content.Settings.UWPPlatformSettings.WindowMode.html) docs. |
| **Auto Rotation Preferences** | The display orientation modes. Can be combined as flags. See [DisplayOrientations](https://docs.flaxengine.com/api/FlaxEditor.Content.Settings.UWPPlatformSettings.DisplayOrientations.html) docs. |
| **Certificate Location** | The location of the package certificate (relative to the project). |
