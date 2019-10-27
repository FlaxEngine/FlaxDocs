# Scripting Games

![Scripting](media/title.jpg)

The most important part of every game are **Scripts**. Creating chunks of code that handle game events, respond to user input, and control objects is an essential ingredient in all games. In short, scripts make games interactive by adding gameplay. It applies to both small and huge production. This documentation section covers the most important parts of the scripting pipeline and helps with starting the game scripting.

You can write scripts in **C#** and add them to scene objects. To learn more about it see the pages in this section.
If you need help with learning C# see [this page](http://www.letmegooglethat.com/?q=C%23+tutorial).

> [!Note]
> Explaining C# and vector math is out of the scope of this documentation.

## Scripting Backend

Flax uses [Mono](http://www.mono-project.com/) to load, compile and execute C# scripts.
Currently the newest **C# 7.2** version is fully supported (uses .Net 4.5).

If you want to use custom .NET libraries simply put them into the project `Content` folder (or any subdirectory). Flax will automatically reference it in your game scripts project.

## In this section

* [Create and use a script](new-script.md)
* [Script properties and fields](properties.md)
* [Script events](events.md)
* [Accessing scene objects](scene-objects.md)
* [Creating and destroying objects](objects-lifetime.md)
* [Attributes](attributes.md)
* [Scripts debugging](debugging/index.md)
 * [Visual Studio](debugging/visual-studio.md)
* [Scripts serialization](serialization/index.md)
* [Empty Actor](empty-actor.md)
* [Custom Editors](custom-editors/index.md)
 * [Custom script editor](tutorials/custom-editor.md)
 * [Attributes](custom-editors/attributes.md)
* [Preprocessor variables](preprocessor.md)
* [Scripting restrictions](restrictions.md)
* [Plugins](plugins/index.md)
 * [Plugins Window](plugins/plugins-window.md)
 * [Plugin Exporting](plugins/exporting.md)
* [Advanced](advanced/index.md)
 * [Raw Data Asset](advanced/raw-data-asset.md)
 * [Custom Editor Options](advanced/custom-editor-options.md)
 * [Curve](advanced/curve.md)
 * [Access Game Window](advanced/access-game-window.md)
 * [Multithreading](advanced/multithreading.md)
* [Tutorials](tutorials/index.md)
 * [How to create a custom editor](tutorials/custom-editor.md)
 * [How to create a custom editor window](tutorials/custom-window.md)
 * [How to create a custom editor plugin](tutorials/custom-plugin.md)
 * [How to create a custom asset type](tutorials/custom-asset.md)
 * [How to change scene from script](tutorials/change-scene.md)
 * [How to use custom settings](tutorials/custom-settings.md)
 * [How to import asset from code](tutorials/import-asset-from-code.md)
 * [How to control PostFx from code](tutorials/control-postfx-from-code.md)

