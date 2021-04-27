using FlaxEngine;

public class AutoRemoveObj : Script
{
    [Tooltip("The time left to destroy object (in seconds).")]
    public float Timeout = 5.0f;

    public override void OnStart()
    {
        Destroy(Actor, Timeout);
    }
}