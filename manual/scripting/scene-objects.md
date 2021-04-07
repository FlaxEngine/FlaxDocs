# Accessing scene objects

One of the most important aspects of the scripts is interaction and accessing other scene objects including of course the actor that script is attached to. For instance, if game wants to spawn a ball in front of the player, it needs to get a player location and a view direction which can be done by using [Flax](https://github.com/FlaxEngine/FlaxEngine).

## Accessing actors

Every script has inherited property `Actor` that represents an actor the script is attached to. For example you can use it to modify the actor position every frame:

### C#

```cs
public override void OnFixedUpdate()
{
	Actor.Position += new Vector3(0, 2, 0);
}
```

You can also print its name:

```cs
Debug.Log(Actor.Name);
```

See [Actor](https://docs.flaxengine.com/api/FlaxEngine.Actor.html) class reference to learn more.

You can also print all child actors and rotate the parent actor:

[!code-csharp[Example1](code-examples/scene-objects.cs]

### C++

Here is the equivalent of the implemented logic above in C++.

```cpp
void ScriptExample::OnUpdate()
{
    GetActor()->SetPosition(GetActor()->GetPosition() + Vector3(0, 2, 0));
}
```

Prints the name of the owning actor:
```cpp
DebugLog::Log(GetActor()->GetName());
```

Prints all child actors and rotates the parent actor:

[!code-csharp[Example2](code-examples/scene-objects.h]

## Accessing other scripts

Scripts attached to the actors can be queries like the actors using a dedicated methods:

### C#

```cs
private void OnTriggerEnter(Collider collider)
{
    // Deal damage to the player when enters the trigger
    var player = collider.GetScript<Player>();
    if (player)
        player.DealDamage(10);
}
```

You can also query all the scripts of the any actor and use them to perform any action:

```cs
private void OnTriggerEnter(Collider collider)
{
    foreach (var provider in collider.GetScripts<IAdProvider>())
       provider.ShowAd();
}
```

### C++

Same code as above, implemented in C++.

```cpp
void ScriptExample::OnTriggerEnter(Collider* collider)
{
    // Deal damage to the player when enters the trigger
    auto player = collider->GetScript<Player>();
    if (player)
        player->DealDamage(10);
}
```

```cpp
void ScriptExample::OnTriggerEnter(Collider* collider)
{
    for each (auto provider in collider->GetScripts<IAdProvider>())
        provider.ShowAd();
}
```

## Finding actors

Flax implements API to find objects.

### C#

```cs
private void OnTriggerLeave(Collider collider)
{
    var obj = Actor.Scene.FindActor("Spaceship");
    Destroy(obj);
}
```

However, in most cases, the best solution is to expose a field with reference to the object and set it in the editor to improve game performance.

```cs
public Actor Spaceship;

private void OnTriggerLeave(Collider collider)
{
    Destroy(ref Spaceship);
}
```

### C++

Equal implementation in C++.

```cpp
void ScriptExample::OnTriggerLeave(Collider* collider)
{
    auto obj = GetActor()->GetScene()->FindActor(TEXT("Spaceship"));
    obj->DeleteObject();
}
```

Using a field to store the spaceship.

```cpp
//.h
API_FIELD()
ScriptingObjectReference<Actor> Spaceship;

//.cpp
void ScriptExample::OnTriggerLeave(Collider* collider)
{
    SpaceShip.Get()->DeleteObject();
}
```