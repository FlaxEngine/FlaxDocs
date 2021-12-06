# Collisions

![Collisions](media/physics3.gif)

This page describes how to filter and detect object collisions.

## Collisions filtering

Flax supports up to 32 different collision layers. Each layer can have different a collisions mask defined.

You can use [Physics Settings](physics-settings.md) to define the layers collisions mask matrix.
Every actor has property [Actor.Layer](https://docs.flaxengine.com/api/FlaxEngine.Actor.html#FlaxEngine_Actor_Layer) which is used to peek the collisions mask for the object.

## Collisions detection

Flax uses event-based collision detection. When a collision between two objects is detected it is reported during the **fixed update**. Use the [Collider](https://docs.flaxengine.com/api/FlaxEngine.Collider.html) events to handle the collisions.
To access information about the collision use [Collision](https://docs.flaxengine.com/api/FlaxEngine.Collision.html) class and [ContactPoint](https://docs.flaxengine.com/api/FlaxEngine.ContactPoint.html) structures.

Here is an example script which registers collision detection for a given input collider in the scene.

# [C#](#tab/code-csharp)
```cs
public class MyScript : Script
{
	public Collider TargetCollider;

	public override void OnEnable()
	{
		TargetCollider.CollisionEnter += OnCollisionEnter;
	}

	public override void OnDisable()
	{
		TargetCollider.CollisionEnter -= OnCollisionEnter;
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("We got the collision sir! With: " + collision.OtherCollider);
	}
}
```
# [C++](#tab/code-cpp)
```cpp
#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Core/Log.h"
#include "Engine/Physics/Colliders/Collider.h"
#include "Engine/Scripting/ScriptingObjectReference.h"

API_CLASS() class GAME_API MyScript : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(MyScript);

    API_FIELD() ScriptingObjectReference<Collider> TargetCollider;

    void OnCollisionEnter(const Collision& c)
    {
        LOG(Info, "We got the collision sir! With: {0}", c.OtherActor->ToString());
    }

    // [Script]
    void OnEnable() override
    {
        if (TargetCollider)
            TargetCollider->CollisionEnter.Bind<MyScript, &MyScript::OnCollisionEnter>(this);
    }
    void OnDisable() override
    {
        if (TargetCollider)
            TargetCollider->CollisionEnter.Unbind<MyScript, &MyScript::OnCollisionEnter>(this);
    }
};

inline MyScript::MyScript(const SpawnParams& params)
    : Script(params)
{
}
```
***

Please keep in mind that not only Colliders may be a source of collision but also other actor types eg. Terrain. To handle this use properties **ThisActor** and **OtherActor**.

## Learn more

See [Script Events](../scripting/events.md) page to learn more about the C# script events.

