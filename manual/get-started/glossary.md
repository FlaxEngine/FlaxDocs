# Flax Glossary

This page lists and describes the most common terms used in the Flax Engine. For instance, if you find yourself asking questions like *"What is an Actor?"* or *"What is a Visject?"*, this page will help you with an understanding of what each term means. Links are provided for more documentation and guidance on working with them.

## Glossary

| Term | Description |
|--------|--------|
| **Project** | A self-contained directory that holds all the game files used during development. See [Flax projects structure](project-structure.md) page to learn more about it. |
| **Actor** | Actors are objects that can be placed in your level. Every [Actor](https://docs.flaxengine.com/api/FlaxEngine.Actor.html) is linked to the parent actor (except the Scene actors which are the root of the hierarchy) and can have child actors (tree hierarchy). Actors have their own 3D transformation (translation, rotation and scale) and inherit the parent actor transformation. You can attach C# scripts to actors and spawn/destroy them at runtime. See [Actors](scenes/actors.md) page to learn more about it. |
| **C# Script** | A text document that contains the source code of the custom [Script](https://docs.flaxengine.com/api/FlaxEngine.Script.html) class implementation written in [C# language](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/). |
| **Scene Objects** | This term refers to both **Actors** and **Scripts** as they can be instantiated in your game and appear in the scene. Every scene object can be created and destroyed at runtime and is identified by the [Object.ID](https://docs.flaxengine.com/api/FlaxEngine.Object.html#FlaxEngine_Object_ID). |
| **Visject** | A visual surface graph that contains nodes connected to a network. For instance, it is used by the [Materials Editor](../graphics/materials/material-editor/index.md) to create material shaders. *Visject* was the name of the now deprecated visual scripting interface that was featured in a previous version of the engine. It has been replaced by C# scripts. |
| **Visual Script** | A built-in binary asset that contains a graph with visual script nodes, properties and metadata. This graph is processed and executed at runtime by the engine. It is used for Visual Scripting, a non-code based method for programming game logic. |
| **Prefab** | An asset in json format that contains prefab data. It holds serialized data of the prefab objects collection. Prefabs can be instantiated to reuse the objects within an archetype. |
| **Prefab Instance** | Spawned prefab objects can contain links to prefab assets and prefab objects. They can be modified at runtime and can contain more than one actor (whole actors tree, including nested prefabs). |
| **Flax** | ![Flax Icon](../../media/Web_Logo_64.png) |



