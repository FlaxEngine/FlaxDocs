using FlaxEngine;

public class MyScript : Script
{
    public SpotLight Flashlight;

    public override void OnStart()
    {
        Destroy(ref Flashlight);
    }
}