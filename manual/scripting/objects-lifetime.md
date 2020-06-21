# Creating and destroying objects

Scene objects lifetime is controlled by the Flax but the game can also access **New/Destroy methods** that allow to manage the scene at runtime. Some games keep a constant number of objects in the scene, but it is very common for characters, treasures and other object to be created and removed during gameplay.

## Spawning objects

Example code that spawn a new point light:

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

> [!Note]
> Scene objects (actors, scripts) should **not use constructors** to prevent issues.

## Removing objects

Flax supports immediate and delayed objects removing system. This helps with cleanup up the scene from killed players or unused actors.

```cs
public class MyScript : Script
{
    public SpotLight Flashlight;

    public override void OnEnable()
    {
        Destroy(ref Flashlight);
    }
}
```

Here is an example script that will remove object after a specified timeout (in seconds):

```cs
public class AutoRemoveObj : Script
{
    [Tooltip("The time left to destroy object (in seconds).")]
    public float Timeout = 5.0f;

    public override void OnStart()
    {
        Destroy(Actor, Timeout);
    }
}
```

In the same way you can remove scripts:

```cs
Destroy(Actor.GetScript<Player>());
```