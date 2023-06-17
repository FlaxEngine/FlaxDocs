# HOWTO: Use Custom Settings

**Custom Settings** are the easiest way to extend the default game configuration by adding own data components that define the game configuration. Also, it's a very unified way for plugins to inject custom options into the game. In this tutorial, you will learn how to define, create and use custom settings right in your game or a plugin.

To learn more about custom settings see related page [here](../../editor/game-settings/custom-settings.md).

### 1. Define custom settings data object

The first step is to prepare the actual layout for the custom settings.
Flax uses C# objects that are a very good way to define data, serialize, and access from C# code.
Here is a sample class that defines a set of settings used by the example game. Create this class in your game project (Game project).

```cs
public class MySettings
{
	public float Speed = 2.0f;
}
```

### 2. Create settings in Editor

Next step is to create an actual asset (*.json* file) that contains settings.
In project *Content* use *right-click* and use option **New -> Json Asset**.
Then specify it's name and pick the type to created class typename (in this example it's `MySettings`).
Press **Create** button to make a file with default values of the type.

![New Asset picker](media/new-settings-asset-picker.png)

Also, you can use your script code (Start method), a [custom editor](custom-editor.md), or a [custom editor window](custom-window.md) to do it.

```cs
#if FLAX_EDITOR
	var path = Path.Combine(Globals.ProjectContentFolder, "mySetitng.json");
	FlaxEditor.Editor.SaveJsonAsset(path, new MySettings());
	GameSettings.SetCustomSettings("MyPlugin", Content.LoadAsync<JsonAsset>(path));
#endif
```

The sample code creates a new settigns asset in Content folder named *myPluginSettings.json*.

Note: if you are developing a plugin you can create a default plugin settings asset and ship it with the plugin so it can be used to adjust plugin options in the project that uses it.

You can also inject custom settings asset proxy controller for Editor which allows to extend the asset type with custom actions, editor window, creation method, etc:

```cs
var assetProxy = new CustomSettingsProxy(typeof(MySettings), "My Settings");
Editor.ContentDatabase.AddProxy(assetProxy);

// then ensure to cleanup on deinitialization (eg. of the plugin)
// Editor.ContentDatabase.RemoveProxy(assetProxy);
```

### 3. Edit settings in Editor

Now you can use Flax Editor to open and edit the settings. Simply **double click on an asset in the Content Window** to open the editor window and modify the settings.

![Edit Custom Settings](media/custom-settings-edit.png)

### 4. Access settings at runtime

Custom Settings can be accessed at runtime via `Engine.GetCustomSettings` method that returns the `JsonAsset` linked by the given key (this example code uses key *MyPlugin*).

```cs
var settings = Engine.GetCustomSettings("MyPlugin");
if (settings)
{
    Debug.Log("Settings: " + settings.CreateInstance<MySettings>().Speed);
}
```

## Settings in C++

If you use C++ scripting you can create a class that defines the data for the settings with `API_CLASS` and inherit from `SettingsBase`. It will be automatically exposed to the C#/Visual scripting and will be accessible in native scripts.

Use `API_AUTO_SERIALIZATION` tag to make it automatically serializable (all `API_FIELD` items), add default `DECLARE_SCRIPTING_TYPE_NO_SPAWN` macro to insert scripting information and place utility `DECLARE_SETTINGS_GETTER` macro to insert settings getter for easier usage in game code (implemented with `IMPLEMENT_GAME_SETTINGS_GETTER` macro in `cpp` file).

```cpp
// .h
#include "Engine/Core/Config/Settings.h"
#include "Engine/Scripting/ScriptingObject.h"

/// <summary>
/// The custom settings.
/// </summary>
API_CLASS() class GAME_API MySettings : public SettingsBase
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE_NO_SPAWN(SettingsBase);
    DECLARE_SETTINGS_GETTER(SettingsBase);
public:
    // The custom option.
    API_FIELD() String Text;
};

// .cpp
#include "MySettings.h"

IMPLEMENT_GAME_SETTINGS_GETTER(MySettings, "MySettings");
```

Then you can use them in C#/Visual just like any other settings, in C++ code this can be accessed via getter:

```cpp
const auto settings = MySettings::Get();
```

Which will take the current settings data from the asset linked to the Cusstom Settings (in root `GameSettings.json`). Use `CustomSettingsProxy` mentioned above to make it easier to construct this asset in Editor.
