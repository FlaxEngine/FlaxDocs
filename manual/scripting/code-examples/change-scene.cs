using FlaxEngine;

public class SceneChanger : Script
{
    public SceneReference AnotherScene;

    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyboardKeys.G))
            Level.ChangeSceneAsync(AnotherScene);
    }
}