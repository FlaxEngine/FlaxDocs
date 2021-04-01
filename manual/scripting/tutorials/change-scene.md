# HOWTO: Change scene from script

In this tutorial you will learn how to unload existing scenes and load a different one using a script.

## 1. Prepare a new script

Navigate to `Source` directory, **right-click**, and select the option **New -> Script**. Then specify its name (eg. `SceneChanger`) and hit Enter.

## 2. Implement scene change logic

Here is a sample code that exposes a public variable with a reference to a scene asset that it should load. It checks in the Update function if the `G` key was pressed, it then changes the current scene into the selected one.

### C#

```cs
public class SceneChanger : Script
{
	public SceneReference AnotherScene;

	public override void OnUpdate()
	{
		if (Input.GetKeyDown(KeyboardKeys.G))
			Level.ChangeSceneAsync(AnotherScene);
	}
}
```

### C++

```cpp
API_CLASS() class EXAMPLE_API SceneChanger : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(SceneChanger);

public:

    API_FIELD(Attributes = "CustomEditorAlias(\"FlaxEditor.CustomEditors.Editors.SceneRefEditor\"), AssetReference(typeof(SceneReference))")
        Guid AnotherScene;

public:
    void OnEnable() override;
    void OnDisable() override;
    void OnUpdate() override
    {
        if (Input::GetKeyDown(KeyboardKeys::G) && AnotherScene.IsValid())
        {
			// Does the same as the C# API
			Level::UnloadAllScenesAsync();
			Level::LoadSceneAsync(id);
        }
    }
};
```

## 3. Add script

Now, add the script to an actor in your scene (select the actor and use `Add script` button).

![Change Scene From Code](media/change-scene-1.png)

## 4. Assign scene

Then *drag and drop* the scene that you want to load from the *Content Window* into the asset picker.

![Change Scene From Code](media/change-scene-2.png)

## 5. Test it out

Finally, hit the play button (or **F5**) and test the script logic by pressing the `G` key. Your scene will be unloaded and a new scene will be loaded at runtime.

