# Creating and destroying objects

Scene objects lifetime is controlled by the Flax but the game can also access **New/Destroy methods** that allow to manage the scene at runtime. Some games keep a constant number of objects in the scene, but it is very common for characters, treasures and other object to be created and removed during gameplay.

## Spawning objects

### C#
Example code that spawns a new point light:

# [C#](#tab/code-csharp)
```cs
public override void OnStart()
{
    var light = new PointLight();
    light.Color = Color.Blue;
    light.Parent = Actor;
}
```
# [C++](#tab/code-cpp)
```cpp
void ExampleScript::OnStart()
{
    auto light = New<PointLight>();
    light->Color = Color::Blue;
    light->SetParent(GetActor());
}
```
***

You can add new scripts to any objects by using [AddScript](https://docs.flaxengine.com/api/FlaxEngine.Actor.html#FlaxEngine_Actor_AddScript_FlaxEngine_Script_) method:

# [C#](#tab/code-csharp)
```cs
public override void OnStart()
{
    var player = Actor.AddScript<Player>();
    player.HP = 100;
}
```
# [C++](#tab/code-cpp)
```cpp
void ExampleScript::OnStart()
{
    auto script = New<Player>();
    script->SetParent(GetActor());
    script->HP = 100;
}
```
***

> [!Note]
> Scene objects (actors, scripts) should **not use constructors** to prevent issues.

## Removing objects

Flax supports immediate and delayed objects removing system. This helps with cleanup up the scene from killed players or unused actors.

# [C#](#tab/code-csharp)
[!code-csharp[Example1](code-examples/objects-lifetime.cs)]
# [C++](#tab/code-cpp)
[!code-cpp[Example3](code-examples/objects-lifetime.h)]
***

Here is an example script that will remove object after a specified timeout (in seconds):

# [C#](#tab/code-csharp)
[!code-csharp[Example2](code-examples/objects-lifetime-2.cs)]
# [C++](#tab/code-cpp)
[!code-cpp[Example4](code-examples/objects-lifetime-2.h)]
***

In the same way you can remove scripts:

# [C#](#tab/code-csharp)
```cs
Destroy(Actor.GetScript<Player>());
```
# [C++](#tab/code-cpp)
```cpp
GetActor()->GetScript<ExampleScript>()->DeleteObject();
```
***
