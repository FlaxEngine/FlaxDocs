# Particle Parameters

![Particle Parameters](media/particle-parameters.gif)

Every particle emitter can define a custom set of parameters exposed publicly for additional customizations. Those parameters can be accessed per particle effect via particle system tracks names used as namespaces. For instance, if particle emitter has a single parameter named *Color* and particle system has 2 tracks with this emitter one named *Smoke 1*, second named *Smoke 2*, then you can adjust every one of those parameters independently: *Smoke 1.Color* and *Smoke 2.Color*.

Here is an example code that modifies the parameters. Remember to cache the effect parameters instead of querying them every frame so your game performance is better.

```cs
var effect = Actor.As<ParticleEffect>();

var color1 = effect.GetParam("Smoke 1", "Color");
color1.Value = Color.Red;

var color2 = effect.GetParam("Smoke 2", "Color");
color2.Value = Color.Blue;
```

In addition, you can enumerate all particle effect parameters as follows:

```cs
var effect = Actor.As<ParticleEffect>();
foreach (var param in effect.Parameters)
{
    Debug.Log("Param " + param.Name + " = " + param.Value);
}
```
