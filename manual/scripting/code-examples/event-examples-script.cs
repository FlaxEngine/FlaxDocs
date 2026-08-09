using FlaxEngine;

public class EventExamples : Script
{
    public override void OnEnable()
    {
        Debug.Log("Script is now enabled");
    }

    public override void OnDisable()
    {
        Debug.Log("Script is now disabled");
    }

    public override void OnStart()
    {
        // Init the position to (0, 0, 0) once after the script is created
        Actor.Position = Vector3.Zero;
    }

    public override void OnUpdate()
    {
        // Adjusts the actors rotation to look at the world origin every frame
        Actor.LookAt(Vector3.Zero);
    }

    public override void OnFixedUpdate()
    {
        // Move the actor up by 10 centimeters every fixed framerate frame
        Actor.Position += new Vector3(0f, 10f, 0);
    }

    public override void OnDebugDraw()
    {
        // Draw the actors bounds using DebugDraw
        DebugDraw.DrawWireBox(Actor.Box, Color.Red, 0f);
    }
}
