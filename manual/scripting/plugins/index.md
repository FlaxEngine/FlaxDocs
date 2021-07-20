# Plugins

Plugins are collection of source code added to your Flax project that can be used to implement persistent game or utility classes, custom engine features, or to extend the editor by adding custom tools with UI representation. This documentation section explains the basics of creating and using plugins. Follow these notes to learn more about the plugin system in Flax.

Example plugin project can be found [here](https://github.com/FlaxEngine/ExamplePlugin), use this as a reference.

## Introduction

Flax supports loading native .dll files, C# libraries from *.dll* files and adding references to game projects for use in scripts. Many Flax Engine systems are designed to be extensible, enabling developers to add new features and to modify built-in functionality without modifying engine source code directly.

Using plugins allows the use of external .Net libraries to be used within a game. For instance, the developer can use custom game classes, custom networking libraries, or a social media plugin. To reference .Net module in your game scripts modify the build script file (eg. `Source/GameModule/MyGame.Build.cs`) by adding a file reference in overridden `Setup` method:

```cs
// Reference C# DLL placed Content folder
options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Content", "JetBrains.Annotations.dll"));
```

After this entry has been added and the .dll file is available on the filesystem at this path you will need to *generate project script files*. Generating project script files can be done by accessing a context menu option when right-clicking the .flaxproj file in the game project root directory.

To add a native .dll to your project, for example if your .Net dll wraps a native .dll, you can add an option to copy the native .dll to the output directory by adding the following to the `Setup` method:

```cs
// Copy native DLL placed in Content folder to output directory
options.DependencyFiles.Add(Path.Combine(FolderPath, "..", "..", "Content", "native.dll"));
```

Remember to generate project script files anytime you modify the `Game.Build.cs` file.

Build scripts work for both the editor and cooked game as the referenced assembly will be packaged.

> [!IMPORTANT]
> If your plugin collects the C# types information (eg. methods cache or attributes) always remember to release them in Editor on [FlaxEditor.ScriptsBuilder.ScriptsReloadBegin](https://docs.flaxengine.com/api/FlaxEditor.ScriptsBuilder.html#FlaxEditor_Scripting_ScriptsBuilder_ScriptsReloadBegin) event to prevent crashes during scripts reload in Editor.

## Plugin Description

Every plugin has to export its description structure that defines the basic plugin properties. Plugin description is used to show the plugin information in [Plugins Window](plugins-window.md). Contents of the plugin description and related comment are listed below:

| Property               | Info                                                  |
| ---------------------- | ----------------------------------------------------- |
| **Name**               | The name of the plugin.                               |
| **Version**            | The version of the plugin.                            |
| **Author**             | The name of the author of the plugin.                 |
| **AuthorUrl**          | The plugin author website URL.                        |
| **HomepageUrl**        | The homepage URL for the plugin.                      |
| **RepositoryUrl**      | The plugin repository URL (for open-source plugins).  |
| **Description**        | The plugin description.                               |
| **Category**           | The plugin category (eg. `Rendering`).                |
| **IsBeta**             | True if plugin is during Beta tests (before release). |
| **IsAlpha**            | True if plugin is during Alpha tests (early version). |
| **SupportedPlatforms** | The supported deploy platforms by this plugin.        |

# Types of Plugins

There are two types of plugins:

* Game plugins
* Editor plugins

## Game Plugins

**Game Plugins** are type of plugin that can be used at runtime. Game plugins are deployed with the game and can extend the engine by adding new features. Plugins can contain custom scripts that can be used in a game. To create a simple game plugin use the following code example:

```cs
public class MyPlugin : GamePlugin
{
    /// <inheritdoc />
    public override PluginDescription Description => new PluginDescription
    {
        Name = "My Plugin",
        Category = "Other",
        Description = "This is my custom plugin made for Flax.",
        Author = "Someone Inc.",
    };

    /// <inheritdoc />
    public override void Initialize()
    {
        base.Initialize();

        Debug.Log("Plugin initialization!");
    }

    /// <inheritdoc />
    public override void Deinitialize()
    {
        Debug.Log("Plugin cleanup!");

        base.Deinitialize();
    }
}
```

Your game can also use a Game Plugins within a code to implement various gameplay features because plugins don't rely on loaded scenes or scene objects and are created before the scenes loading (compared to the normal scripts).

### Game Plugin Settings

If you need to include custom settings for your plugin see [this tutorial](../tutorials/custom-settings.md) to learn more.

### Game Plugin Assets

If you want to bundle custom assets used in code-only plugin (eg. shader or debug model) override `OnCollectAssets` method as follows and provide IDs of the assets to include:

```cs
#if FLAX_EDITOR
/// <inheritdoc />
public override void OnCollectAssets(System.Collections.Generic.List<Guid> assets)
{
    base.OnCollectAssets(assets);

    // Add asset ID to the list
    assets.Add(ShaderId);

    // Add asset ID based on asset path
    var path = Path.Combine(Globals.ProjectFolder, "Plugins/MyPlugin/Content/MyCustomDebugModel.flax");
    Content.GetAssetInfo(path, out var info);
    assets.Add(info.ID);
#endif
```

## Editor Plugins

**Editor Plugins** can extend the Flax Editor by adding new tools or functionalities. Editor plugin can add new buttons to the Editor GUI and/or override the Custom Editors pipeline or create custom windows to be used for game content creation. The amount of possibilities is very large. To learn more how to create and use editor plugin see the related tutorial [here](../tutorials/custom-plugin.md).

> [!Note]
> Note: if your plugin uses both **Game Plugin** and **Editor Plugin** types the remember to implement `EditorPlugin.GamePluginType` to point the type of the game plugin.

## In this section

* [Plugins Window](plugins-window.md)
* [Plugin Project](plugin-project.md)
* [How to create a custom editor plugin](../tutorials/custom-plugin.md)
* [How to use custom settings](../tutorials/custom-settings.md)
