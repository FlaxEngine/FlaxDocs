# HOWTO: Setup time of the day simulation

![Texture](media/time-of-the-day.gif)

In this tutorial, you will learn how to setup script to control sun light colors to match the current time of the day (from sun rotaton).

## Tutorial

### 1. Setup Directional Light

Adjust the rotation and brightness (eg. `10`).

### 2. Setup Sky

Setup `Sky` actor by linking the `Sun Light` to the created Directional Light actor (if not linked already).

### 3. Create new C# script `RealisticSun`

Setup new script that will control the Directional Light color based it's rotation to match the lighting color during time of the day.

```cs
/// <summary>
/// Realistic sun coloring script.
/// </summary>
[ExecuteInEditMode]
public class RealisticSun : Script
{
    /// <summary>
    /// Reference to the sun actor to control (if not specified the first Directional Light is used).
    /// </summary>
    public DirectionalLight SunActor;

    /// <summary>
    /// Color curve for sun light colors. In time range [-1;1] where positive time values (between [0;1]) are for day-time and negative values (between [-1;0)) are for night-time.
    /// </summary>
    public LinearCurve<Color> SunLightColors = new LinearCurve<Color>
    {
        Keyframes = new[]
        {
            new LinearCurve<Color>.Keyframe(-0.2f, new Color(0.609958f, 0.768231f, 0.97746f, 0.3f)),
            new LinearCurve<Color>.Keyframe(0.0f, new Color(0.998158f, 0.431645f, 0.083600f, 0.7f)),
            new LinearCurve<Color>.Keyframe(0.1f, new Color(0.991379f, 0.796836f, 0.427773f, 0.9f)),
            new LinearCurve<Color>.Keyframe(0.2f, new Color(0.991379f, 0.893238f, 0.598813f)),
            new LinearCurve<Color>.Keyframe(0.4f, new Color(1.0f, 0.966467f, 0.911958f)),
            new LinearCurve<Color>.Keyframe(1.0f, new Color(1.0f, 0.977460f, 0.911515f)),
        }
    };

    /// <inheritdoc />
    public override void OnStart()
    {
        // Automatically pick the first sun light
        if (!SunActor)
            SunActor = Actor as DirectionalLight;
        if (!SunActor)
            SunActor = Level.FindActor<DirectionalLight>();
    }

    /// <inheritdoc />
    public override void OnUpdate()
    {
        if (!SunActor)
            return;
  
        // Update light color based on the pitch angle
        var sunAngle = SunActor.Orientation.EulerAngles.X / 90.0f;
        SunLightColors.Evaluate(out var color, sunAngle, false);
        SunActor.Color = color;
    }
}
```

### 4. Attach the script

Now, attach the created script to the Directional Light actor (or any other actor). Now, you can edit the sun color curve property `Sun Light Colors`.
