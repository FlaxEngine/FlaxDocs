# Accessing scene objects

One of the most important aspects of the scripts is interaction and accessing other scene objects including of course the actor that script is attached to. For instance, if game wants to spawn a ball in front of the player, it needs to get a player location and a view direction which can be done by using [Flax C# API](https://github.com/FlaxEngine/FlaxAPI).

## Accessing actors

Every script has inherited property `Actor` that represents an actor the script is attached to. For example you can use it to modify the actor position every frame:

```cs
private void FixedUpdate()
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
private void Start()
{
    // Prints all children names
    var children = Actor.GetChildren();
    foreach (var a in children)
        Debug.Log(a.Name);

    // Changes the child point light color (if has)
    var pointLight = Actor.GetChild<PointLight>();
    if (pointLight)
        pointLight.Color = Color.Red;
}

private void FixedUpdate()
{
    // Rotates the parent object
    Actor.Parent.LocalEulerAngles += new Vector3(0, 2, 0);
}
```

## Accessing other scripts

Scripts attached to the actors can be queries like the actors using a dedicated methods:

```cs
private void OnTriggerEnter(Collider c)
{
    // Deal damage to the player when enters the trigger
    var player = c.GetScript<Player>();
    if (player)
        player.DealDamage(10);
}
```

You can also query all the scripts of the any actor and use them to perform any action:

```cs
private void OnTriggerEnter(Collider c)
{
    foreach (var script in c.Scripts)
    {
        if (script is IAdProvider provider)
            provider.ShowAd();
    }
}
```

## Finding actors

Flax implements API to find objects.

```cs
private void OnTriggerLeave(Collider c)
{
    var obj = Actor.Scene.FindActor("Spaceship");
    Destroy(obj);
}
```




