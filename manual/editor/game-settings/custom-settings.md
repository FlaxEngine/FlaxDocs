# Custom Settings

Custom settings can be used to inject custom game configuration or plugin configuration into build game settings.
Custom settings are identified by unique key and link the custom json asset with data.

To set custom settings in Editor you can use the following code:

```cs
var path = Path.Combine(Globals.ProjectContentFolder, "myPluginSettings.json");
FlaxEditor.Editor.SaveJsonAsset(path, new MySettings());
GameSettings.SetCustomSettings("MyPlugin", Content.LoadAsync<JsonAsset>(path));
```

To access custom settings at runtime you the following code:

```cs
var settings = Engine.GetCustomSettings("MyPlugin");
if (settings)
{
	var settingsObj = settings.CreateInstance<MySettings>();
	// Use settingsObj to access options...
}
```

To learn more about using custom settings see this [tutorial](../../scripting/tutorials/custom-settings.md).
