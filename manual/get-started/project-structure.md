# Flax projects structure

![Project Structure](media/project-structure.jpg)

All Flax projects have unified structure. This strict organization helps with development and provides better standardization across all Flax games.

Flax Editor can load project located in any place on your drive. It's only required to place a valid **Project.xml** file that describes the project (name, metadata). Flax Editor will generate all project folders if missing (Cache, Content, Logs and Source directories) as well as C# projects and solution file.

## Example Project.xml

```xml
<Project>
	<Name>My Super Game</Name>
	<DefaultSceneId>a470726f441936acfe25318b162c336c</DefaultSceneId>
	<DefaultSceneSpawnPos>
		<X>-390</X>
		<Y>268</Y>
		<Z>-260</Z>
	</DefaultSceneSpawnPos>
	<DefaultSceneSpawnDir>
		<X>20</X>
		<Y>63</Y>
		<Z>0</Z>
	</DefaultSceneSpawnDir>
	<MinVersionSupported>6146</MinVersionSupported>
</Project>
```

## Folders structure

* **&lt;root&gt;**
 * **Cache** - editor local cache folder, used for thumbnails, game cooker cache and other temporary files
 * **Content** - contains all the game assets (models, textures, settings, etc.)
   * **SceneData** - dedicated directory for the [private scene assets](scenes/scene-data.md)
   * **GameSettings.json** - fixed location for the game settings asset
 * **Logs** - contains editor log files
 * **Screenshots** - contains screenshot files (`.png` format) you took in editor (use `F12` key)
 * **Source** - contains all game script files (use **Editor** subdirectories to separate editor-only scripts)
 * **&lt;project_name&gt;.csproj** - game scripts C# project file
 * **&lt;project_name&gt;.Editor.csproj** - editor scripts C# project file
 * **&lt;project_name&gt;.sln** - project scripts solution file, open it with Visual Studio
 * **Project.xml** - project description and metadata file (used by editor and launcher)
