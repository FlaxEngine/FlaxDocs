# Scripting Games

![Scripting](media/title.png)

A **Script** is what implements logic for your game. Creating pieces of code that handle game events, respond to user input and control objects is an essential ingredient in the recipe for a game of all sorts. 

This documentation section covers the most important parts of the scripting pipeline and helps you with getting started with scripting in Flax Engine.

> [!Note]
> Explaining the basics of C# and C++ programming, as well as vector math is out of the scope of this documentation.

### Scripting Languages

Flax supports **C#**, **C++** and **Visual Scripting**. Every one of those three languages is highly integrated into the engine, as the engine is written in C++, while the editor is C#, which Visual Scripting also relies on. 

## Code/ Binary Modules

An important concept related to programming in Flax are **binary modules**. Binary modules are compiled source code libraries that can be referenced in other modules (eg. Editor, Graphics, or plugins).

In most cases, the main code of your game will be in the module named `Game` (automatically created by Flax in every new project). It is located in the `Source` folder at `Source/Game`.

The `Game` folder/ module is the place where your games scripts live. They will be automatically compiled by the build tool as soon as it detects a new script or changes in an existing one.

To learn more about build tools and infrastructure, see the [Flax.Build](../editor/flax-build/index.md) documentation.

For more advanced uses, your Flax project can contain multiple modules and have code split between them for better organization (the engine does that for example - it is made of multiple modules all working together).

## C# Scripting

In Flax you can write scripts in **C#** (amongst other languages) and attach them to `Actor`s in your scene. Most of the documentation related to scripting covers C# scripting.

If you need help with learning C# itself, that is unfortunately out of the scope of this documentation, but you can easily find some beginner tutorials online.

Flax uses [.NET](https://dotnet.microsoft.com/en-us) to load, compile and execute C# scripts.
Currently, the newest **C# 12** version is fully supported. The Flax Editor requires [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) to be installed.

If you want to use third party .NET libraries, you can use build scripts to reference them in your project (as [shown here](tutorials/use-third-party-library.md)).

## C++ Scripting

Flax supports native **C++** scripting with direct access to whole engine API. 

C++ scripts can be created side-by-side with C# scripts and expose their own types, functions and properties via automatic binding generation (more about that [here](../editor/flax-build/api-tags.md)). 

To write and use C++ code, engine headers and platform toolset are required.

To start native scripting in C++ see the related documentation [here](cpp/index.md).

## Visual Scripting

Flax supports **Visual Scripting** with fully-featured Editor tools for creating and debugging Visual Scripts.

As opposed to C# or C++ scripts, Visual Scripts can not be created in the `Source/Game` folder and live in your projects `/Content` folder instead.

They can inherit from C++ or C# classes (eg. a custom Actor or Script). and access the whole engine API, as well as any existing C# or C++ code. Of course you can also define custom functions, classes and variables inside of Visual Scripts.

It's a very light-weight and extensible solution for prototyping games, but can also be used by artists and other people with no or few coding experience to make a whole game.

It does also not require any additional tooling or compiler, since it will hot-reload in editor to provide an even more robust and easy development.

To start visual scripting, see the related documentation [here](visual/index.md).

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
  * [CLion](debugging/clion.md)
* [Scripts serialization](serialization/index.md)
* [Empty Actor](empty-actor.md)
* [Engine API](engine-api.md)
* [Custom Editors](custom-editors/index.md)
  * [Custom script editor](tutorials/custom-editor.md)
  * [Attributes](custom-editors/attributes.md)
* [Preprocessor variables](preprocessor.md)
* [C# Scripting](csharp/index.md)
  * [Project file management](csharp/project-file-management.md)
  * [Nuget Packages](csharp/nuget-packages.md)
  * [Scripting Restrictions](csharp/restrictions.md)
* [C++ Scripting](cpp/index.md)
  * [Common Types](cpp/common-types.md)
  * [Collections](cpp/collections.md)
  * [String Formatting](cpp/string-formatting.md)
  * [Logging and Assertions](cpp/logging-assertions.md)
  * [Object References](cpp/object-references.md)
  * [Serialization](cpp/serialization.md)
  * [Interfaces](cpp/interfaces.md)
  * [Tips & Tricks](cpp/tips-tricks.md)
* [Visual Scripting](visual/index.md)
  * [Events](visual/events.md)
  * [Arrays](visual/arrays.md)
  * [Dictionaries](visual/dictionaries.md)
* [Plugins](plugins/index.md)
  * [Plugins Window](plugins/plugins-window.md)
  * [Plugin Project](plugins/plugin-project.md)
* [Advanced](advanced/index.md)
  * [Script Templates](advanced/templates.md)
  * [Raw Data Asset](advanced/raw-data-asset.md)
  * [Custom Editor Options](advanced/custom-editor-options.md)
  * [Curve](advanced/curve.md)
  * [Access Game Window](advanced/access-game-window.md)
  * [Multithreading](advanced/multithreading.md)
  * [Screenshots](advanced/screenshots.md)
  * [Gameplay Globals](advanced/gameplay-globals.md)
  * [Refactoring and Renaming](advanced/refactoring-renaming.md)
  * [Cert Store](advanced/cert-store.md)
  * [Noise](advanced/noise.md)
  * [Tags](advanced/tags.md)
  * [Run code on module load](advanced/code-on-load.md)
  * [File Reference](advanced/file-reference.md)
  * [Debug Commands](advanced/debug-commands.md)
* [Artificial Intelligence](ai/index.md)
  * [Behavior Trees](ai/behavior-trees/index.md)
    * [Behavior Knowledge](ai/behavior-trees/knowledge.md)
    * [Behavior](ai/behavior-trees/behavior.md)
    * [Behavior Tree Nodes](ai/behavior-trees/nodes.md)
    * [Behavior Tree Decorators](ai/behavior-trees/decorators.md)
    * [How to create a custom Behavior Tree node](ai/behavior-trees/custom-node.md)
    * [How to create a custom Behavior Tree decorator](ai/behavior-trees/custom-decorator.md)
    * [How to create a custom Move To node](ai/behavior-trees/custom-move-to.md)
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
  * [How to create loading screen](tutorials/loading-screen.md)
