# Accessing scene objects

One of the most important aspects of the scripts is interaction and accessing other scene objects including of course the actor that script is attached to. For instance, if game wants to spawn a ball in front of the player, it needs to get a player location and a view direction which can be done by using [Flax](https://github.com/FlaxEngine/FlaxEngine).

## Accessing actors

Every script has inherited property `Actor` that represents an actor the script is attached to. For example you can use it to modify the actor position every frame:

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

```cs
public override void OnStart()
{
    // Prints all children names
    foreach (var a in Actor.Children)
        Debug.Log(a.Name);

    // Prints the names of all point light children
    var children = Actor.GetChildren<PointLight>();
    foreach (var a in children)
        Debug.Log(a.Name);

    // Changes the first child point light color
    var pointLight = Actor.GetChild<PointLight>();
    if (pointLight)
        pointLight.Color = Color.Red;
}

public override void OnFixedUpdate()
{
    // Rotates the parent object
    Actor.Parent.LocalEulerAngles += new Vector3(0, 2, 0);
}
```

## Accessing other scripts

Scripts attached to the actors can be queries like the actors using a dedicated methods:

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
    foreach (var script in collider.Scripts)
    {
        if (script is IAdProvider provider)
            provider.ShowAd();
    }
}
```

## Finding actors

Flax implements API to find objects.

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



