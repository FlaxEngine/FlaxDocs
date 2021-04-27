# HOWTO: Change scene from script

In this tutorial you will learn how to unload existing scenes and load a different one using a script.

## 1. Prepare a new script

Navigate to `Source` directory, **right-click**, and select the option **New -> Script**. Then specify its name (eg. `SceneChanger`) and hit Enter.

## 2. Implement scene change logic

Here is a sample code that exposes a public variable with a reference to a scene asset that it should load. It checks in the Update function if the `G` key was pressed, it then changes the current scene into the selected one.

### C#

[!code-csharp[Example1](../code-examples/change-scene.cs)]

### C++

[!code-cpp[Example2](../code-examples/change-scene.h)]

## 3. Add script

Now, add the script to an actor in your scene (select the actor and use `Add script` button).

![Change Scene From Code](media/change-scene-1.png)

## 4. Assign scene

Then *drag and drop* the scene that you want to load from the *Content Window* into the asset picker.

![Change Scene From Code](media/change-scene-2.png)

## 5. Test it out

Finally, hit the play button (or **F5**) and test the script logic by pressing the `G` key. Your scene will be unloaded and a new scene will be loaded at runtime.

