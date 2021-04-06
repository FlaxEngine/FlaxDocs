using FlaxEngine;

public class MyScript : Script
{
    public override void OnStart()
    {
        // Prints all children names
        var children = Actor.Children;
        foreach (var a in children)
            Debug.Log(a.Name);

        // Changes the child point light color (if has)
        var pointLight = Actor.GetChild<PointLight>();
        if (pointLight)
            pointLight.Color = Color.Red;
    }

    public override void OnFixedUpdate()
    {
        // Rotates the parent object
        Actor.Parent.LocalEulerAngles += new Vector3(0, 2, 0);
    }
}