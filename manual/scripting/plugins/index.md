# Plugins

Plugins are separate code libraries added to your Flax project that can be used to implement persistent game or utility classes, custom engine features or to extend the editor by adding custom tools with UI representation. This documentation section explains the basics of creating and using plugins. Follow these notes to learn more about plugins system in Flax.

Example plugin project can be found [here](https://github.com/FlaxEngine/ExamplePlugin). Use it as a reference.

## Introduction

Flax supports loading C# libraries (from *.dll* files) and adding references to game scripts. Many Flax Engine systems are designed to be extensible, enabling developers to add entire new features and to modify built-in functionality without modifying Engine Core code directly.

Using plugins allows the use of external .Net libraries to be used within a game. For instance, the developer can use custom game classes, custom networking libraries or a social media plugin. By default, Flax loads all .Net modules contained in the **Content** folder (or any subdirectory) and adds a reference to them to the game projects. During Game Cooking those assemblies can be deployed with the game to be used at runtime.

> [!IMPORTANT]
> If your plugin collects the C# types information (eg. methods cache or attributes) always remember to release them in Editor on [FlaxEditor.Scripting.ScriptsBuilder.ScriptsReloadBegin](https://docs.flaxengine.com/api/FlaxEditor.Scripting.ScriptsBuilder.html#FlaxEditor_Scripting_ScriptsBuilder_ScriptsReloadBegin) event to prevent crashes during scripts reload in Editor.

## Plugin Description

Every plugin has to export its description structure that defines the basic plugin properties. Plugin description is used to show the plugin information in [Plugins Window](plugins-window.md). Contents of the plugin description and related comment are listed below:

| Property | Info |
|--------|--------|
| **Name** | The name of the plugin. |
| **Version** | The version of the plugin. |
| **Author** | The name of the author of the plugin. |
| **AuthorUrl** | The plugin author website URL. |
| **HomepageUrl** | The homepage URL for the plugin. |
| **RepositoryUrl** | The plugin repository URL (for open-source plugins). |
| **Description** | The plugin description. |
| **Category** |  The plugin category (eg. `Rendering`).|
| **IsBeta** | True if plugin is during Beta tests (before release). |
| **IsAlpha** | True if plugin is during Alpha tests (early version). |
| **SupportedPlatforms** | The supported deploy platforms by this plugin. |

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

If you need to include custom settings for your plugin see [this tutorial](../tutorials/custom-settings.md) to learn more.

## Editor Plugins

**Editor Plugins** can extend the Flax Editor by adding new tools or functionalities. Editor plugin can add new buttons to the Editor GUI and/or override the Custom Editors pipeline or create custom windows to be used for game content creation. The amount of possibilities is very large. To learn more how to create and use editor plugin see the related tutorial [here](../tutorials/custom-plugin.md).

> [!Note]
> Note: if your plugin uses both **Game Plugin** and **Editor Plugin** types the remember to implement `EditorPlugin.GamePluginType` to point the type of the game plugin.

## In this section

* [Plugins Window](plugins-window.md)
* [Plugin Exporting](exporting.md)
* [How to create a custom editor plugin](../tutorials/custom-plugin.md)
* [How to use custom settings](../tutorials/custom-settings.md)
