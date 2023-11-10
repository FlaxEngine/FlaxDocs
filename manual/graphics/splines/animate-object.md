# HOWTO: Animate object over spline

In the following tutorial, you will learn how to move an object over a spline.

## Tutorial

### 1. Create a spline

Follow [this](index.md) tutorial. Alternatively, the spline can be set to **Loop** to have continuous animation.

![Create Spline Editor](media/create-spline.gif)

### 2. Create the script

Follow the [scripting documentation](../../scripting/index.md) for information about creating new scripts and make a new script named **SplineAnimation** then write the following code:

```cs
using System;
using FlaxEngine;

public class SplineAnimation : Script
{
    private float _time;
    private Spline _spline;

    [Tooltip("The speed of the object animation over the spline.")]
    public float Speed = 1.0f;

    [Tooltip("The actor to move over the spline.")]
    public Actor ObjectToMove;

    public override void OnEnable()
    {
        // Cache spline actor
        _spline = Actor.As<Spline>();
        if (!_spline)
            throw new Exception("Attach script to a spline.");
    }

    public override void OnUpdate()
    {
        if (!_spline || !ObjectToMove)
            return;

        // Update position
        _time += Time.DeltaTime * Speed;

        // Evaluate the spline curve
        var direction = _spline.GetSplineDirection(_time);
        var transform = _spline.GetSplineTransform(_time);

        // Place object on the spline and make it oriented along the spline direction
        transform.Orientation = Quaternion.LookRotation(direction, Float3.Up) * transform.Orientation;
        ObjectToMove.Transform = transform;
    }
}
```

### 3. Setup

Select the spline and click the **Add script** button. Next, pick your new script and attach it to the spline.
Finally, choose the actor to move over the spline by setting the **Object To Move** property on the script.

![Spline Animate Setup Editor](media/spline-animate-object-setup.png)

### 4. Test it out!

Now, hit the *play* button and see the object moving along the spline. You can even edit the spline while it moves over it.

![Animate Object Over Spline](media/animate-object-over-spline.gif)

