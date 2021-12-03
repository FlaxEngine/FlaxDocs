# Accessing scene objects

One of the most important aspects of the scripts is interaction and accessing other scene objects including of course the actor that script is attached to. For instance, if game wants to spawn a ball in front of the player, it needs to get a player location and a view direction which can be done by using [Flax](https://github.com/FlaxEngine/FlaxEngine).

## Accessing actors

Every script has inherited property `Actor` that represents an actor the script is attached to. For example you can use it to modify the actor position every frame:

# [C#](#tab/code-csharp)
```cs
public override void OnFixedUpdate()
{
	Actor.Position += new Vector3(0, 2, 0);
}
```
# [C++](#tab/code-cpp)
```cpp
void ScriptExample::OnFixedUpdate()
{
    GetActor()->SetPosition(GetActor()->GetPosition() + Vector3(0, 2, 0));
}
```
***

You can also print its name:

# [C#](#tab/code-csharp)
```cs
Debug.Log(Actor.Name);
```
# [C++](#tab/code-cpp)
```cpp
DebugLog::Log(GetActor()->GetName());
```
***

See [Actor](https://docs.flaxengine.com/api/FlaxEngine.Actor.html) class reference to learn more.

You can also print all child actors and rotate the parent actor:

# [C#](#tab/code-csharp)
[!code-csharp[Example1](code-examples/scene-objects.cs)]
# [C++](#tab/code-cpp)
[!code-cpp[Example2](code-examples/scene-objects.h)]
***

## Accessing other scripts

Scripts attached to the actors can be queries like the actors using a dedicated methods:

# [C#](#tab/code-csharp)
```cs
private void OnTriggerEnter(Collider collider)
{
    // Deal damage to the player when enters the trigger
    var player = collider.GetScript<Player>();
    if (player)
        player.DealDamage(10);
}
```
# [C++](#tab/code-cpp)
```cpp
void ScriptExample::OnTriggerEnter(Collider* collider)
{
    // Deal damage to the player when enters the trigger
    auto player = collider->GetScript<Player>();
    if (player)
        player->DealDamage(10);
}
```
***

You can also query all the scripts of the any actor and use them to perform any action:

# [C#](#tab/code-csharp)
```cs
private void OnTriggerEnter(Collider collider)
{
    foreach (var provider in collider.GetScripts<IAdProvider>())
       provider.ShowAd();
}
```
# [C++](#tab/code-cpp)
```cpp
void ScriptExample::OnTriggerEnter(Collider* collider)
{
    for each (auto provider in collider->GetScripts<IAdProvider>())
        provider.ShowAd();
}
```
***

## Finding actors

Flax implements API to find objects.

# [C#](#tab/code-csharp)
```cs
private void OnTriggerLeave(Collider collider)
{
    var obj = Actor.Scene.FindActor("Spaceship");
    Destroy(obj);
}
```
# [C++](#tab/code-cpp)
```cpp
void ScriptExample::OnTriggerLeave(Collider* collider)
{
    auto obj = GetActor()->GetScene()->FindActor(TEXT("Spaceship"));
    obj->DeleteObject();
}
```
***

However, in most cases, the best solution is to expose a field with reference to the object and set it in the editor to improve game performance.

# [C#](#tab/code-csharp)
```cs
public Actor Spaceship;

private void OnTriggerLeave(Collider collider)
{
    Destroy(ref Spaceship);
}
```
# [C++](#tab/code-cpp)
```cpp
//.h
API_FIELD()
ScriptingObjectReference<Actor> Spaceship;

//.cpp
void ScriptExample::OnTriggerLeave(Collider* collider)
{
    CHECK(Spaceship);
    Spaceship->DeleteObject();
}
```
***
