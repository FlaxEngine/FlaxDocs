# Scripting Games

![Scripting](media/title.jpg)

The most important part of every game are **Scripts**. Creating chunks of code that handle game events, respond to user input, and control objects is an essential ingredient in all games. In short, scripts make games interactive by adding gameplay. It applies to both small and huge production. This documentation section covers the most important parts of the scripting pipeline and helps with starting the game programming.

Flax supports **C#**, **C++** and **Visual** scripting. The mix of those three languages is highly integrated into the engine as it's written in those languages (engine is C++, editor is C#).

> [!Note]
> Explaining C#, C++ and vector math is out of the scope of this documentation.

## Code Modules

Important concepts related to programming in Flax are **binary modules**. Binary modules are compiled source code libraries that can reference other modules (eg. Editor, Graphics, or plugins).

In most cases, the main game code is in the module named `<project_name>` or named `Game` located in `Source` folder (eg. `Source/Game`). That's the place where you can add new scripts so build tool will compile them. For more, advanced uses game can contain multiple modules and have code split for better organization (as for example engine does - it's made of multiple modules working together). For instance, you can create an editor-only module and use its code only in the Editor.

To learn more about build tools and infrastructure see [Flax.Build](../editor/flax-build/index.md) utility documentation.

## C# Scripting

You can write scripts in **C#** and add them to scene objects. To learn more about it see the pages in this section. Most of the documentation related to scripting covers C# to implement various gameplay logic. If you need help with learning C# see [this page](http://www.letmegooglethat.com/?q=C%23+tutorial).

Flax uses [Mono](https://www.mono-project.com) to load, compile and execute C# scripts.
Currently the newest **C# 7.2** version is fully supported (with .Net Framework 4.5). Flax Editor ships with C# Roslyn  Compiler - no need to install any external tools to compile and run C# code.

If you want to use custom .NET libraries use build scripts to reference them as [shown here](tutorials/use-third-party-library.md).

## C++ Scripting

Flax supports native **C++** scripting with direct access to whole engine API. C++ scripts can be created side-by-side with C# scripts and expose own types/functions/properties via automatic bindings as decscribed [here](../editor/flax-build/api-tags.md). To write and use C\+\+ code engine headers and platform toolset are requried.

To start native scripting in C\+\+ see the related documentation [here](cpp/index.md).

## Visual Scripting

Flax supports **Visual** scripting with fully-featured Editor tools for creating, using and debugging Visual Scripts. Visual Scripts can inherit from C++ or C# classes (eg. custom Actor or Script) to provide more logic and data. Visual Scripting is very light-weight and extensible solution for prototyping games especially boosting the rapid development.

Visual Scripts can access to whole engine API and the game code. Visual Scripts can be created side-by-side with C# and C++ scripts to expose own functions/properties. Also, Visual Scripting doesn't requrie any additional tools nor compiler as it's hot-reloading in Editor without any processing to provide even more robust development.

To start visual scripting see the related documentation [here](visual/index.md).

## In this section

* [Create and use a script](new-script.md)
* [Script properties and fields](properties.md)
* [Script events](events.md)
* [Accessing scene objects](scene-objects.md)
* [Creating and destroying objects](objects-lifetime.md)
* [Attributes](attributes.md)
* [Scripts debugging](debugging/index.md)
  * [Visual Studio](debugging/visual-studio.md)
  * [Visual Studio Code](debugging/visual-studio-code.md)
  * [Rider](debugging/rider.md)
* [Scripts serialization](serialization/index.md)
* [Empty Actor](empty-actor.md)
* [Engine API](engine-api.md)
* [Custom Editors](custom-editors/index.md)
  * [Custom script editor](tutorials/custom-editor.md)
  * [Attributes](custom-editors/attributes.md)
* [Preprocessor variables](preprocessor.md)
* [Scripting restrictions](restrictions.md)
* [C++ Scripting](cpp/index.md)
  * [Common Types](cpp/common-types.md)
  * [Collections](cpp/collections.md)
  * [String Formatting](cpp/string-formatting.md)
  * [Logging and Assertions](cpp/logging-assertions.md)
  * [Object References](cpp/object-references.md)
  * [Serialization](cpp/serialization.md)
  * [Tips & Tricks](cpp/tips-tricks.md)
* [Visual Scripting](visual/index.md)
* [Plugins](plugins/index.md)
  * [Plugins Window](plugins/plugins-window.md)
  * [Plugin Project](plugins/plugin-project.md)
* [Advanced](advanced/index.md)
  * [Raw Data Asset](advanced/raw-data-asset.md)
  * [Custom Editor Options](advanced/custom-editor-options.md)
  * [Curve](advanced/curve.md)
* [Access Game Window](advanced/access-game-window.md)
  * [Multithreading](advanced/multithreading.md)
  * [Screenshots](advanced/screenshots.md)
  * [Gameplay Globals](advanced/gameplay-globals.md)
* [Tutorials](tutorials/index.md)
  * [How to create a custom editor](tutorials/custom-editor.md)
  * [How to create a custom editor window](tutorials/custom-window.md)
  * [How to create a custom editor plugin](tutorials/custom-plugin.md)
  * [How to create a custom asset type](tutorials/custom-asset.md)
  * [How to create a custom actor](tutorials/custom-actor.md)
  * [How to change scene from script](tutorials/change-scene.md)
  * [How to use custom settings](tutorials/custom-settings.md)
  * [How to import asset from code](tutorials/import-asset-from-code.md)
  * [How to control PostFx from code](tutorials/control-postfx-from-code.md)
  * [How to use third-party library](tutorials/use-third-party-library.md)
  * [How to add scripts module](tutorials/add-scripts-module.md)
