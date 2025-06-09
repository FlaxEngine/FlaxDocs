# C++ Scripting

Flax Engine fully supports C++ scripting with even more features than C# scripting. In general, C\+\+ offers more **performance** and allows to **access engine API directly** which comes with many benefits. Flax Engine is mostly written in C\+\+ with C# flavor which means you can easily build the game on top of the engine. Also, Flax uses its own build tool called [Flax.Build](../../editor/flax-build/index.md) to compile both the engine and the game.

Follow this documentation section to learn how to write your own C\+\+ scripts and use them in a game. Also, if you see any code examples in the *Flax Documentation* that are written in C# you can similarly use them in C\+\+ scripts since the engine uses the same API in both languages (you can even move your existing game code from C# to C\+\+ quite quickly).

Visit **[C++ API Reference](../../../api-cpp/index.md)** to learn about scripting types.

## In this section

* [Common Types](common-types.md)
* [Collections](collections.md)
* [String Formatting](string-formatting.md)
* [Logging and Assertions](logging-assertions.md)
* [Object References](object-references.md)
* [Serialization](serialization.md)
* [Interfaces](interfaces.md)
* [Tips & Tricks](tips-tricks.md)

## Setup

Flax Editor contains a built-in C# compiler for scripts but for C\+\+ scripting the platform-dependent toolset is required to be installed on the machine. Every platform uses its own native tools. To learn about them see this [page](../../platforms/index.md). Below you can learn quickly how to set it up depending on your platform.

### Windows

* Install **Visual Studio 2022** ([download](https://visualstudio.microsoft.com/en/vs/community/))
* Install **Windows 10 SDK** (or Windows 8.1 SDK)
* Install **Microsoft Visual C++** (v140 toolset or newer)

### Linux

* Install [Visual Studio Code](https://code.visualstudio.com/)
* Get the compiler `sudo apt-get install clang lldb lld` (Clang 6 or newer)
* Install required dependencies `libxcursor-dev libxinerama-dev libx11-dev`

### Mac

* Install XCode or XCode Command Line Tools (and optionally [Visual Studio Code](https://code.visualstudio.com/))

## How to create C++ script?

By default, new Flax projects have a game module using C# scripting. You can learn more about modules and targets [here](../../editor/flax-build/index.md). After installing the required tools, open `Source/<module_name>/<module_name>.Build.cs` (i.e. `Source/Game/Game.Build.cs`). This file is a build script for the code module and can specify its build environment and dependencies. It contains a overriden **Setup(BuildOptions options)** method which performs the module initialization.

Find the `BuildNativeCode = false` line and change the value to `true` or add the following code at the end of the method:

```cs
BuildNativeCode = true;
```

Now, you can **add a new C\+\+ script** to the project and they will be compiled into the binary libraries and loaded by the engine. To do so, navigate in the *Content Window* to that module's source folder `Source/<module_name>`, *right-click* and choose the **C++ Script** option. Specify its name and confirm with *Enter*.

![New Native Script C\+\+](media/new-cpp-script.png)

Under File, you can select **generate scripts project files** or right-click on the game project file and choose a similar option.

![Generate Scripts Project Files](media/project-files-generation.png)

After that open the code project (eg. Visual Studio Solution). Ensure to use the **Editor.Development** configuration and **Win64** platform (if you're working on Windows).

![Visual Studio Scripts Project](media/cpp-scripts-visual-studio.png)

As you can see, the editor generated a simple script from a template that overrides the `OnEnable`, `OnDisable`, and `OnUpdate` methods similar to C# scripts. Open the created `.cpp` file and add following code on top to include debug logging:

```cpp
#include "Engine/Core/Log.h"
```

Then add a simple log instruction in the `OnUpdate` method:

```cpp
void CppScript::OnUpdate()
{
    LOG(Info, "Hello from C++!");
}
```

Go back to the editor so that it can autocompile the scripts or open it from Visual Studio with **Local Windows Debugger** button aka Debugger Start (or hit *F5*). Now, you can add the script to the actor and see the message printed in the *Output Log* every frame by your own C\+\+ script.

![C++ Script Runtime](media/cpp-script-run.png)

Feel free to start coding your game logic in C\+\+!

## C\+\+ scripting with Flax

Flax supports **hot-reloading C\+\+** code which greatly improves the workflow. It works in the same way as for C# scripting and can be configured in the editor options. You can also close the editor, compile the scripts from Visual Studio and open the project with the Visual Studio debugger.

In many cases before using a specific API type (eg. `PointLight` actor or `Model` asset) you have to **include a proper header file** since Flax uses paradigm *include-only-what-you-see*. But if you want to easily include all the common headers you can include `Engine/Core/Common.h`. Also, as you've probably noticed the Visual Studio solution contains also **Flax** C\+\+ project (in Flax folder). You can freely browse the Flax code to learn more about API and available code utilities. If you downloaded the engine from Flax Store then it will contain only header files. Flax header files use **XML documentation tags** and are almost 100% documented so working with them is fairly smooth as you can quickly learn what a given method/field does. Those documentation comments are later parsed by the build tool and exposed to C# for scripting and editor tooltips.

Now, to understand some basic concepts related to C\+\+ scripting in Flax let's analyze the following script that spawns decals on mouse clicks and places them at the geometry using a raycast from the mouse location:

```cpp
#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Content/AssetReference.h"
#include "Engine/Content/Assets/MaterialBase.h"
#include "Engine/Input/Input.h"
#include "Engine/Level/Level.h"
#include "Engine/Level/Actors/Camera.h"
#include "Engine/Level/Actors/Decal.h"
#include "Engine/Serialization/JsonTools.h"
#include "Engine/Physics/Physics.h"

API_CLASS() class GAME_API MouseDecalShoot : public Script
{
API_AUTO_SERIALIZATION();
DECLARE_SCRIPTING_TYPE(MouseDecalShoot);

	// The decal material to use for spawned decals.
	API_FIELD() AssetReference<MaterialBase> DecalMaterial;

	// Spawns the decal at the given mouse screen position.
	API_FUNCTION() void SpawnDecal(const Float2& mousePos)
	{
		// Convert mouse position into the world-space ray and perform the raycast in physics scene
		const auto ray = Camera::GetMainCamera()->ConvertMouseToRay(mousePos);
		RayCastHit hit;
		if (Physics::RayCast(ray.Position, ray.Direction, hit))
		{
			// Create decal at hit point and add it to the scene
			auto decal = New<Decal>();
			decal->Material = DecalMaterial;
			decal->SetPosition(hit.Point);
			decal->SetDirection(hit.Normal);
			Level::SpawnActor(decal);
		}
	}

	// [Script]
	void OnUpdate() override
	{
		if (Input::GetMouseButtonDown(MouseButton::Left))
		{
			SpawnDecal(Input::GetMousePosition());
		}
	}
};

inline MouseDecalShoot::MouseDecalShoot(const SpawnParams& params)
	: Script(params)
{
	// Enable ticking OnUpdate function
	_tickUpdate = true;
}
```

### OnUpdate/OnLateUpdate/OnFixedUpdate

As an optimization, the engine by default doesn't call the tick function for all scripts. Script types that want to receive this need to see appropriate flag: `_tickUpdate`, `_tickLateUpdate` or/and `_tickFixedUpdate` to `true` in constructor. This informs the engine that the script wants to be updated at a certain stage.

Also, you can manually register custom tick function in `OnEnable` (or when script is active):

```cpp
GetActor()->GetScene()->Ticking.Update.AddTick<MyScript, &MyScript::Tick>(this);
```

## C\+\+ scripting documentation

To learn more about specific areas of C\+\+ scripting in Flax see the related sections:

* [Common Types](common-types.md)
* [Collections](collections.md)
* [String Formatting](string-formatting.md)
* [Logging and Assertions](logging-assertions.md)
* [Object References](object-references.md)
* [Serialization](serialization.md)
* [Interfaces](interfaces.md)
* [Tips & Tricks](tips-tricks.md)
* [API_ tags](../../editor/flax-build/api-tags.md)

Also, you can use Flax [C++ API reference](../../../api-cpp/index.md) to browse the engine types.

## Interop with C# #

To call C# from C\+\+ you need to use engine managed scripting wrappers `MClass` and `MMethod` as in the following example:

```cs
public void CallMe()
{
   // Code in C#
}
```

```cpp
#include "Engine/Scripting/ManagedCLR/MClass.h"
#include "Engine/Scripting/ManagedCLR/MMethod.h"

...

Script* someCSharpScript = ...;
auto method = someCSharpScript->GetClass()->GetMethod("CallMe");
method->Invoke(someCSharpScript->GetOrCreateManagedInstance(), nullptr, nullptr);
```

This code will call a parameter-less, member function named *CallMe* from the given object.

To call C\+\+ from C# simply expose your type with `API_CLASS` to C# and expose the given method with `API_FUNCTION` tag too. The build tool will generate the glue code for native methods invocation from C#.

```cpp
API_FUNCTION() void CallMe()
{
   // Code in C++
}
```

```cs
NativeScript someCppScript = ...;
someCppScript.CallMe();
```

## Good Luck and Have Fun

![Cpp Oh Boi](media/cpp-oh-boi.jpg)
