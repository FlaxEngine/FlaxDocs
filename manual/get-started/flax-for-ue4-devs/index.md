# Flax for UE4® developers

![Unreal to Flax](media/title.jpg)

Flax and Unreal have many similarities (materials pipeline, physics engine) and share many concepts, however there are a few differences. This page helps Unreal Engine 4 developers to translate their existing experience into the world of Flax Engine.

> [!Warning]
> Warning! Guaranteed speed ahead!

## Editor

Flax Editor and Unreal Editor are very similar. You can see the color-coded, highlighted areas on screenshots of both editors that have common functionalities. Flax Editor layout is also highly customizable so you can drag and drop windows around to adapt the editor to your workflow.

![Unreal Editor](media/unreal-layout.png)

![Flax Editor](../media/flax-layout.png)

> [!TIP]
> With Flax Editor, fast compile times and project opening are a main focus.

## Terminology

This section contains the most common terms used in UE4 and their Flax equivalents (or rough equivalent). Flax keywords link directly to more in-depth information inside the documentation.

| Unreal | Flax |
|--------|--------|
| **Actor** | [Actor](../scenes/actors.md) |
| **Blueprint** | [Prefab](../prefabs/index.md) + [Visual Script](../../scripting/visual/index.md) |
| **C++** | [C++ and C#](../../scripting/index.md) |
| **Lumen** | [DDGI](../../graphics/lighting/gi/realtime.md) |
|||
| **World Outliner** | [Scene Window](../../editor/windows/scene-window.md) |
| **Details Panel** | [Properties Window](../../editor/windows/properties-window.md) |
| **Content Browser** | [Content Window](../../editor/windows/content-window.md) |

## Project

![Flax Project](../media/project-structure.png)

Flax projects structure is similar to UE4 projects. The editor uses **Cache** folder to keep temporary data. Also, **Content** folder works the same way as in Unreal (assets-only), while **Source** directory is used to keep all C# and C\+\+ scripts.

Flax also generates a solution and project files for your game scripts.

See [Flax projects structure](../project-structure.md) page to learn more about the projects in Flax Engine.

## Assets

Flax also uses binary asset files with extension `.flax` (instead of `.uasset`). We are using our own binary format that is well optimized for scalability and streaming. Other assets are usually stored in `Json` format (scenes, settings, etc.).

Flax supports the most popular asset files formats (for 3D models and textures) so you can import your game content.

See [Assets](../assets/index.md) page to learn more about importing and using game assets.

## Scenes and Actors

Flax doesn't use components to build scene objects logic. We only use [Actors](../scenes/actors.md). Each Actor has its own type (e.g. point light, box collider) and a collection of attached scripts. This means, in Flax the scene object hierarchy is created with Actors.

However, you can still use the entity-component design with your scripts because every actor can have scripts.
You can use `GetChild<T>()`/`GetScript<T>()` methods in your scripts to access the other objects.

In Flax, Scene object is also an Actor so you can access it like any other Actor. This means that Scenes can have their own scripts and be transformed like other objects.

Also, multiple actors can have the same name and you can also move assets whenever you like because Flax uses unique IDs of the objects for tracking. This unlocks your development speed. We don't want to constrain your development to some ancient-design but to allow you to iterate faster and create beautiful games even easier.

## Scripting

When it comes to game scripting, there is a significant difference between Unreal and Flax.
Firstly, we support both C\+\+ and C# languages to write game code and Visual Scripting as an addition.
Using Visual Scripts or C# helps with rapid game development and simplifies the development while writing parts of the gameplay in C\+\+ can benefit the performance.
The Flax Engine core itself is written in C++, while Flax Editor is mostly written in C#.

You can create C# and C\+\+ files with script classes that provide a gameplay logic. Then scripts can be attached to the actors and used in a game. Our scripting C# API is an open-source project and can be found [here](https://github.com/FlaxEngine/FlaxEngine). All contributions are welcome.

Here is an example script that has been written for Unreal and Flax which prints the next number every frame.

* Unreal

```cpp
#pragma once
#include "GameFramework/Actor.h"
#include "MyScript.generated.h"

UCLASS()
class AMyScript : public AActor
{
	GENERATED_BODY()
	int Count;

	AMyScript()
	{
		// Allows Tick() to be called
		PrimaryActorTick.bCanEverTick = true;
	}

	void BeginPlay()
	{
		// Called when the game starts or when spawned
		Super::BeginPlay();
		Count = 0;
	}

	void Tick(float DeltaSeconds)
	{
		// Called every frame
		Super::Tick(DeltaSeconds);
		GLog->Log(FString::FromInt(Count++));
	}
};
```

* Flax

```cs
using FlaxEngine;

public class MyScript : Script
{
	int Count;

	public override void OnStart()
	{
		// Use this for initialization
		Count = 0;
	}

	public override void OnUpdate()
	{
		// Update is called once per frame
		Debug.Log(Count++);
	}
}
```

See [Scripting](../../scripting/index.md) documentation to learn more about scripts in Flax.

<hr>

Unreal and its logo are trademarks of Epic Games, Inc.
