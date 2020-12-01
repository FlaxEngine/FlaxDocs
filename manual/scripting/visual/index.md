# Visual Scripting

![Visual Scripting](media/vs-sample.png)

Flax Engine supports fully Visual Scripting with lots of great features such as: hot-reloading, full-API access, debugging, Visject Surface UI, and more. In general, Visual Scriptng offers more **robust development** for rapid prototyping while mainting solid performance.

Follow this documentation section to learn how to create your own visual scripts and use them in a game. Also, if you see any code examples in the *Flax Documentation* that are written in C# you can similarly use them in visual scripts since the engine uses the same API in all languages.

## How to create Visual Script?

**Visual Script** is an in-build binary asset that contains a graph with visual script nodes, properties and metadata. This graph is processed and executed at runtime by the engine. To create new Visual Script simply navigate to the *Content* directory, *right-click* and select option **New -> Visual Script**. Then specify it's name and confirm with *Enter*.
Now, you can *double-click* to open asset editor.

# TODO: finish tutorial

Feel free to start coding your game logic in Visual Scripting language!

## Visual Scripting with Flax

Visual Scripts can override base class methods, have custom properties and methods full of visual code. To understand some basic concepts let's create a simple script that spawns decals on mouse clicks and places them at the geometry using raycast from mouse location.

Firstly, create a new Visual Script. Then open it and override the **Update** method.

# TODO: finish tutorial

Also, since Visual Scripting uses C# API of the engine you can use this [API reference](https://docs.flaxengine.com/api/FlaxEngine.html).

## Interop with C\+\+

To call Visual Script from C\+\+ you can do it as in the following example:

```cpp
#include "Engine/Content/Assets/VisualScript.h"
..
VisualScript* myScript = ..; // Assign it from editor or load asset manually
ScriptingObject* instance = nullptr; // Null for static methods, assign to object instance to call member function
Span<Variant> parameters; // Here you can pass parameters to the function
Variant result = VisualScripting::Invoke(myScript->FindMethod("My Func"), instance, parameters);
```
