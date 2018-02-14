# Flax Glossary

This page lists and describes the most common terms used in Flax Engine. For instance, if you find yourself asking questions like *"What is an Actor"*, or *"What is a Visject"*, this page will help you with an understanding of what each term means, links are provided for more documentation and guidance on working with them.

## Glossary

| Term | Description |
|--------|--------|
| **Project** | It is a self-contained directory that holds all the game files used during the development. See [Flax projects structure](project-structure.md) page to learn more about it. |
| **Actor** | Actors are objects that can be placed in your level. Every [Actor](https://docs.flaxengine.com/api/FlaxEngine.Actor.html) is linked to the parent actor (except the Scene actors which are root of the hierarchy) and can have child actors (tree hierarchy). Actors have own 3D transformation (translation, rotation and scale) and inherit the parent actor transformation. You can attach C# scripts to the actors and spawn/destroy them at runtime. See [Actors](scenes/actors.md) page to learn more about it. |
| **C# Script** | It is a text document that contains a source code of the custom [Script](https://docs.flaxengine.com/api/FlaxEngine.Script.html) class implementation written in a [C# language](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/). |
| **Scene Objects** | This term refers to both **Actors** and **Scripts** as they can be instantiated in your game and appear on the scene. Every scene object can be created and destroyed at runtime and is identified by the [Object.ID](https://docs.flaxengine.com/api/FlaxEngine.Object.html#FlaxEngine_Object_ID). |
| **Visject** | It is a visual surface graph that contains nodes connected to a network. For instance, it is used by the [Materials Editor](../graphics/materials/material-editor/index.md) to create material shaders. *Visject* was a name of the deprecated visual scripting interface that was featured in a very old version of the engine. It has been replaced by the C# scripts. |
| **Flax** | ![Flax Icon](../../media/Web_Logo_64.png) |



