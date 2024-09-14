# Editor Options

Editor Options allows to view and modify the settings used by the editor. Editor options are saved in local user cache folder and are shared globally between all installed Flax Editor instanced. By adjusting the settings you can customize the Flax Editor for your needs.

## Open options window

![Open Editor Options](media/open-options.png)

To open editor options window use main menu button **Edit -> Editor Options**.

## Usage

You can modify the properties and press the **Save** icon in the toolstrip to apply the changes. If you want to restore the settings for a given category, press the **Reset** button found at the bottom of each settings category.

## General options

| Property | Description |
|--------|--------|
| *General* ||
| **Startup Scene Mode** | The scene to load on editor startup. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**None**</td><td>Don't open scene on startup.</td></tr><tr><td>**Project Default**</td><td>The project default scene.</td></tr><tr><td>**Last Opened**</td><td>The last opened scene in the editor.</td></tr></tbody></table>|
| **Undo Actions Capacity** | Limit for the editor undo actions. Higher values may increase memory usage but also improve changes rollback history length. |
| **Editor FPS** | Limit for the editor draw/update frames per second rate (FPS). Use higher values if you need more responsive interface or lower values to use less device power. Value 0 disables any limits.|
| **Editor FPS when Not Focused** | The FPS of the editor when the editor window is not focused. Usually set to lower then the editor FPS.|
| **Build Actions** | The sequence of actions to perform when using Build Scenes button. Can be used to configure this as button (eg. compile code or just update navmesh). Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**CSG**</td><td>Builds Constructive Solid Geometry brushes into meshes.</td></tr><tr><td>**EnvProbes**</td><td>Builds Env Probes and Sky Lights to prerendered cube textures.</td></tr><tr><td>**StaticLighting**</td><td>Builds static lighting into lightmaps.</td></tr><tr><td>**NavMesh**</td><td>Builds navigation meshes.</td></tr><tr><td>**CompileScripts**</td><td>Compiles the scripts.</td></tr></tbody></table>|
| *Scripting* ||
| **Auto Reload Scripts On Main Window Focus** | Determines whether reload scripts after a change on main window focus. |
| **Force Script Compilation On Startup** | Determines whether automatically compile game scripts before starting the editor. |
| **Script Memebers Order** | Order of script properties/fields in properties panel. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Alphabetical**</td><td>Shows properties/fields in alphabetical order.</td></tr><tr><td>**Declaration**</td><td>Shows properties/fields in declaration order.</td></tr></tbody></table>|
| **Auto Save Visual Script On Play Start** | Determines whether automatically save the Visual Script asset editors when starting the play mode in editor. |
| *Content* ||
| **Use Asset Import Path Relative** | *No description avaliable.* |
| **Auto Rebuild CSG** | Determines whether perform automatic CSG rebuild on brush change. |
| *CSG* ||
| **Auto Rebuild CSG** | Determines whether perform automatic CSG rebuild on brush change. |
| **Auto Rebuild CSG Timeout** | Auto CSG rebuilding timeout (in milliseconds). Use lower value for more frequent and responsive updates but higher complexity. |
| *Navigation Mesh* ||
| **Auto Rebuild Nav Mesh** | Determines whether perform automatic NavMesh rebuild on scene change. |
| **Auto Rebuild Nav Mesh Timeout** | Auto NavMesh rebuilding timeout (in milliseconds). Use lower value for more frequent and responsive updates but higher complexity. |
| *Auto Save* ||
| **Enable Auto Save** | Enables or disables auto saving changes in edited scenes and content. |
| **Auto Save Frequency** | The interval between auto saves (in minutes). |
| **Auto Save Reminder Time** | The time before the auto save that the reminder popup shows (in seconds). Set to -1 to not show the reminder popup. |
| **Auto Save Scenes** | Enables or disables auto saving opened scenes. |
| **Auto Save Content** | Enables or disables auto saving content. |
| *Analytics* ||
| **Enable Editor Analytics** | Enables or disables anonymous editor analytics service used to improve editor experience and the quality. |

## Interface options

| Property | Description |
|--------|--------|
| *Interface* ||
| **Interface Scale** | Editor User Interface scale. Applied to all UI elements, windows and text. Can be used to scale the interface up on a bigger display. Editor restart required. |
| **Use Native Window System** | Determines whether use native window title bar. Editor restart required. Windows Only.|
| **Show Selected Camera Preview** | Determines whether show selected camera preview in the edit window. |
| **Center Mouse On Game Window Focus** | Determines whether center mouse position on window focus in play mode. Helps when working with games that lock mouse cursor. |
| **New Window Location** | Define the opening method for new windows, open in a new tab by default. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Float**</td><td>Spawn new windows as floating window.</td></tr><tr><td>**DockFill**</td><td>*No description avaliable.*</td></tr><tr><td>**DockLeft**</td><td>*No description avaliable.*</td></tr><tr><td>**DockRight**</td><td>*No description avaliable.*</td></tr><tr><td>**DockTop**</td><td>*No description avaliable.*</td></tr><tr><td>**DockBottom**</td><td>*No description avaliable.*</td></tr></tbody></table> |
| **Icons Scale** | Editor icons scale. Editor restart required. |
| **Content Window Orientation** | Define the opening method for new windows, open in a new tab by default. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Horizontal**</td><td>Horizontal Content Window.</td></tr><tr><td>**Vertical**</td><td>Vertical Content Window.</td></tbody></table> |
| **Auto Accept Color Picker Change** | *No description avaliable.* |
| **Value Formatting** | *No description avaliable.* Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**None**</td><td>No formatting.</td></tr><tr><td>**BaseUnit**</td><td>The Format using the base SI unit.</td></tr><tr><td>**AutoUnit**</td><td>Format using a unit that matches the value best.</td></tr></tbody></table> |
| **Sparate Value And Unit** | *No description avaliable.* |
| **Show Tree Lines** | *No description avaliable.* |
| *Debug Log* ||
| **Debug Log Timestamps Format** | The timestamps prefix mode for debug log messages. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**None**</td><td>No prefix.</td></tr><tr><td>**Utc**</td><td>The UTC time format.</td></tr><tr><td>**Local Time**</td><td>The local time format.</td></tr><tr><td>**Time Since Startup**</td><td>The time since startup (in seconds).</td></tr></tbody></table> |
| **Clear On Play** | Clears all log entries on enter playmode. |
| **Debug Log Collapse** | Collapses similar or repeating log entries. |
| **Pause On Error** | Performs auto pause on error. |
| **Show Error Messages** | Shows/hides error messages. |
| **Show Warning Messages** | Shows/hides warning messages. |
| **Show Info Messages** | Shows/hides info messages. |
| *Output Log* ||
| **Timestamps Format** | The timestamps prefix mode for output log log messages. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**None**</td><td>No prefix.</td></tr><tr><td>**Utc**</td><td>The UTC time format.</td></tr><tr><td>**Local Time**</td><td>The local time format.</td></tr><tr><td>**Time Since Startup**</td><td>The time since startup (in seconds).</td></tr></tbody></table> |
| **Show Log Type** | Determines whether show log type prefix in output log messages. |
| **Text Font** | The output log text font. |
| **Text Color** | The output log text color. |
| **Text Shadow Color** | The output log text shadow color. |
| **Text Shadow Offset** | The output log text shadow offset. Set to 0 to disable this feature. |
| **Focus Output Log On Compilation Error** | Determines whether auto-focus output log window on code compilation error. |
| **Focus Output Log On Game Build Error** | Determines whether auto-focus output log window on game build error. |
| **Scroll To Bottom** | Scroll the output log view to bottom automatically after new lines are added. |
| **Scroll To Bottom On On Play** | Scroll the output log view to bottom automatically when Play Mode is entered. |
| *Play In-Editor* ||
| **Focus Game Window On Play** | Determines whether auto-focus game window on play mode start. |
| **Play Button Action** | *No description avaliable.* Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**PlayGame**</td><td>Launches the game from the First Scene defined in the project settings.</td></tr><tr><td>**PlayScenes**</td><td>Launches the game using the scenes currently loaded in the editor.</td></tr></tbody></table> |
| **Game Window Mode** | *No description avaliable.* Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Docked**</td><td>Launches the game from the First Scene defined in the project settings.</td></tr><tr><td>**PopupWindow**</td><td>Shows the game window as a popup.</td></tr><tr><td>**MaximizedWindow**</td><td>Shows the game window maximized. (Same as pressing F11).</td></tr><tr><td>**BorderlessWindow**</td><td>Shows the game window borderless.</td></tr></tbody></table> |
| *Visject* ||
| **Connection Curvature** | *No description avaliable.* |
| **Node Description Panel** | Shows/hides the description panel in visual scripting context menu. |
| **Grid Snapping** | Toggles grid snapping when moving nodes. |
| **Grid Snapping Size** | Defines the size of the grid for nodes snapping. |
| *Cook & Run* ||
| **Number of Game Clients To Launch** | Gets ir sets a value indicating the number of game clients to launch when building and/or running cooked game. |
| *Fonts* ||
| **Title Font** | The title font for editor UI. |
| **Large Font** | The large font for editor UI. |
| **Medium Font** | The medium font for editor UI. |
| **Small Font** | The small font for editor UI. |
| **Fallback Fonts** | The list of fallback fonts to use when main text font is missing certain characters. Empty to use fonts from GraphicsSettings. |

## Input options

![Open Editor Options](media/input-options-clear.png)

Use this section to modify the input shortcuts binding used by the editor. By pressing the `X` button you can remove the binding.

## Viewport options

| Property | Description |
|--------|--------|
| *General* ||
| **Mouse Sensitivity** | The mouse movement sensitivity scale applied when using the viewport camera. |
| **Mouse Wheel Sensitivity** | The mouse wheel sensitivity applied to zoom in orthographic mode. |
| **Invert Mouse Y Axis Rotation** | Whether to invert the Y rotation of the mouse in the editor viewport. |
| *Camera* ||
| **Total Camera Speed Steps** | The total amount of steps the camera needs to go from minimum to maximum speed. |
| **Total Camera Speed Steps** | The total amount of steps the camera needs to go from minimum to maximum speed. |
| **Camera Easing Degree** | The degree to which the camera will be eased when using camera flight in the editor window (ignored if camera easing degree is enabled). |
| *Defaults* ||
| **Movement Speed** | The default movement speed for the viewport camera (must be in range between minimum and maximum movement speed values). |
| **Min Movement Speed** | The default minimum movement speed for the viewport camera. |
| **Max Movement Speed** | The default maximum movement speed for the viewport camera. |
| **Use Camera Easing** | The default camera easing mode. |
| **Near Plane** | The default near clipping plane distance for the viewport camera. |
| **Far Plane** | The default far clipping plane distance for the viewport camera. |
| **Use Orthographic Projection** | The default camera orthographic mode. |
| **Orthographic Scale** | The default camera orthographic scale (if camera uses orthographic mode). |
| **Invert Panning** | The default panning direction for the viewport camera. |
| **Use Relative Panning** | The default relative panning mode. Uses distance between camera and target to determine panning speed. |
| **Panning Speed** | The default camera panning speed (ignored if relative panning is enabled). |
| **Viewport Grid Scale** | The default editor viewport grid scale. |
| *Grid* ||
| **Viewport Grid View Distance** | The maximum distance you will be able to see the grid. |
| **Viewport Grid Color** | The color for the viewport grid. |


## Visual options

| Property | Description |
|--------|--------|
| *Gizmo* ||
| **Show Selection Outline** | If checked, the selection outline will be visible. |
| **Selection Outline Color 0** | The first color of the selection outline gradient. |
| **Ui Control Outline Size** | The size of the selection outline for UI controls. |
| **Selection Outline Color 1** | The second color of the selection outline gradient. |
| **Gizmo Size** | The transform gizmo size. |
| **Highlight Color** | The color used to highlight selected meshes and CSG surfaces. |
| *Quality* ||
| **Enable MSAA For DebugDraw** | Determines whether enable MSAA for DebugDraw primitives rendering. Helps with pixel aliasing but reduces performance. |
| *Preview* ||
| **Enable Particles Preview** | *No description avaliable.* |

## Source Code options

| Property | Description |
|--------|--------|
| *Project Files* ||
| **Source Code Editor** | The source code editing IDE to use for project and source files accessing. |
| **Auto Generate Scripts Project Files** | Determines whether automatically generate scripts project files when adding/removing/moving scripts in Editor. |

## Theme

| Property | Description |
|--------|--------|
| **Selected Style** | *No description avaliable.* |
| **Styles** | *No description avaliable.* |

## Custom options

The Editor supports extending the options by adding custom settings. This can be used by the editor plugins. 
To learn how to use custom option it see the [tutorial here](../../scripting/tutorials/custom-editor-settings.md).
