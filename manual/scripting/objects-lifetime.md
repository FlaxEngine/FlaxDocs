# Creating and destroying objects

Scene objects lifetime is controlled by the Flax but the game can also access **New/Destroy methods** that allow to manage the scene at runtime. Some games keep a constant number of objects in the scene, but it is very common for characters, treasures and other object to be created and removed during gameplay.

## Spawning objects

### C#
Example code that spawns a new point light:

```cs
public override void OnStart()
{
    var light = new PointLight();
    light.Color = Color.Blue;
    light.Parent = Actor;
}
```

You can add new scripts to any objects by using [AddScript](https://docs.flaxengine.com/api/FlaxEngine.Actor.html#FlaxEngine_Actor_AddScript_FlaxEngine_Script_) method:

```cs
public override void OnStart()
{
    var player = Actor.AddScript<Player>();
    player.HP = 100;
}
```

### C++

In C++ the implementation is the same.
```cpp
void ExampleScript::OnStart()
{
    auto light = New<PointLight>();
    light->Color = Color::Blue;
    light->SetParent(GetActor());
}
```

In order to add a script you just create a new instance and set the parent.
```cpp
void ExampleScript::OnStart()
{
    auto script = New<SecondaryScript>();
    script->SetParent(GetActor());
}
```

> [!Note]
> Scene objects (actors, scripts) should **not use constructors** to prevent issues.

## Removing objects

Flax supports immediate and delayed objects removing system. This helps with cleanup up the scene from killed players or unused actors.

### C#
[!code-csharp[Example1](code-examples/objects-lifetime.cs)]

Here is an example script that will remove object after a specified timeout (in seconds):

[!code-csharp[Example2](code-examples/objects-lifetime-2.cs)]

In the same way you can remove scripts:

```cs
Destroy(Actor.GetScript<Player>());
```

### C++

Simple deletion of a referenced object:
[!code-cpp[Example3](code-examples/objects-lifetime-2.h)]

How to time object deletion:
[!code-cpp[Example4](code-examples/objects-lifetime.h)]

How to delete script:
```cpp
GetActor()->GetScript<ExampleScript>()->DeleteObject();
```