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
    // object will be part of the scene hierarhcy
    // engine will destroy it on scene unload
}
```
# [C++](#tab/code-cpp)
```cpp
void ExampleScript::OnStart()
{
    auto light = New<PointLight>();
    light->Color = Color::Blue;
    light->SetParent(GetActor());
    // object will be part of the scene hierarhcy
    // engine will destroy it on scene unload
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
    // object will be part of the scene hierarhcy
    // engine will destroy it on scene unload
}
```
***

> [!Note]
> Scene objects (actors, scripts) should **not use constructors** other than initialize itself (defaults).

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

## Language-specific

### C#

Various components and APIs that are specific to C# language use `Dispose()` pattern and implement `IDisposable` interface for convenience. For example:
* `Control` - GUI controls use `Dispose` method to destroy UI element,
* `InputAxis`/`InputEvent` - virtual input reading utility has to be released via `Dispose`,

### C++

* Use utility macros: `SAFE_DISPOSE`, `SAFE_RELEASE`, `SAFE_DELETE` to cleanup objects, depending on the method to call.
* Graphics objects such as `GPUTexture` or `GPUBuffer` can be cleared via `SAFE_DELETE_GPU_RESOURCE` macro. Those are normal scripting objects but invoking `ReleaseGPU` beforehand helps to reduce memory pressure when unused.
* `Task` system uses automatic auto-destruction of past tasks. There is no need to manually destroy objects after use.
