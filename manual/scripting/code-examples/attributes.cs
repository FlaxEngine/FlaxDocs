using FlaxEngine;

[ExecuteInEditMode]
public class MyGenerator : Script
{
    public override void OnStart()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 5; z++)
            {
                var light = new PointLight
                {
                    Radius = 1000,
                    ShadowsMode = ShadowsCastingMode.None,
                    Position = new Vector3(x * 100.0f, 0, z * 100.0f),
                    Parent = Actor
                    //HideFlags = HideFlags.DontSave; // Uncomment to don't save generated actors
                };
            }
        }
    }
}