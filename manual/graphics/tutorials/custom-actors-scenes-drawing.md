# HOWTO: Draw custom set of actors or scenes

By default Flax draws all loaded scenes into the game viewport. There are several ways to include or exclude specific objects from being visible such as:
* Actor enable state (`IsActiveInHierarchy`) - only active actors are visible.
* Actor layer mask - only actors matching camera's (`RenderLayersMask`) or view's layers mask are visible.
* Custom actor or scenes set on Scene Render Task (`MainRenderTask.Instance.ActorsSource`).

In this tutorial we will cover example of the last one.

The game viewport uses `SceneRenderTask` API to draw the game. It can be accessed via `MainRenderTask.Instance` by the game or plugins to customize the rendering. By using `ActorsSource` property the source of the actors for drawing can be customized. It's related to an enum `ActorsSources` which is an enum thus allows one to draw from multiple sources (eg. draw default scenes plus some additional actors that don't exist in the game).

### Custom Scenes

Example script that loads and draws only a specific scene in the game viewport:

```cs
using FlaxEngine;

/// <summary>
/// Loads and draws only a specific scene in the game viewport:
/// </summary>
public class CustomScenesRendering : Script
{
    /// <summary>
    /// The scene to load and draw.
    /// </summary>
    public SceneReference CustomScene;

    /// <inheritdoc />
    public override void OnEnable()
    {
        Level.LoadScene(CustomScene);
        var scene = FlaxEngine.Object.Find<Scene>(ref CustomScene.ID);
        if (scene)
        {
            // Override game drawing for a specific scene
            MainRenderTask.Instance.ActorsSource = ActorsSources.CustomScenes;
            MainRenderTask.Instance.CustomScenes = new[] { scene };
        }
    }

    /// <inheritdoc />
    public override void OnDisable()
    {
        // Restore state
        MainRenderTask.Instance.ActorsSource = ActorsSources.Scenes;
        MainRenderTask.Instance.CustomScenes = Array.Empty<Scene>();
    }
}
```
