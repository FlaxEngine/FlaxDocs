# Flax Project Format (.flaxproj)

Flax uses its own project file format known as `.flaxproj` which is a JSON-based text file. Each project defines its own properties such as name, version, and references. Projects can contain custom properties (eg. used by external plugins or custom gam tools).

## Example .flaxproj

```json
{
  "Name": "My Project",
  "Version": "1.0",
  "Company": "",
  "Copyright": "",
  "GameTarget": "MyProjectTarget",
  "EditorTarget": "MyProjectEditorTarget",
  "References": [
    {
      "Name": "$(EnginePath)/Flax.flaxproj"
    },
    {
      "Name": "$(ProjectPath)/Plugins/MyPlugin/MyPlugin.flaxproj"
    }
  ],
  "DefaultScene": "297f662e43c41143e406ae9ab85097f2"
}
```

## Project References

Each project can reference other projects. Usually, game projects reference only Flax Engine project and some plugins. References are path-based, can be relative to the project file directory or absolute paths. Additionally, special macros can be used to point to specific folders:
* `$(EnginePath)` - currently used engine folder (root),
* `$(ProjectPath)` - current  project folder.

## Reference

| Property | Description |
|--------|--------|
| **Name**  | The project name. |
| **Version**  | The project version. In format: *major.minor.build.revision*. |
| **Company**  | The project publisher company. |
| **Copyright**  | The project copyright note. |
| **GameTarget**  | The name of the build target to use for the game building (final, cooked game code). |
| **EditorTarget**  | The name of the build target to use for the game in editor building (editor game code). |
| **References**  | The list of project references. |
| **DefaultScene**  | The default scene asset identifier to open on project startup. |
| **DefaultSceneSpawn**  | The default scene spawn point (position and view direction). |
| **MinEngineVersion**  | The minimum version supported by this project. |
| **EngineNickname**  | The user-friendly nickname of the engine installation to use when opening the project. Can be used to open game project with a custom engine distributed for team members. This value must be the same in engine and game projects to be paired. |
| **Configuration**  | The custom build configuration entries loaded from project file. In format: key-value pairs. |

To learn more about project properties and API see the [reference](https://docs.flaxengine.com/api/FlaxEditor.ProjectInfo.html).
