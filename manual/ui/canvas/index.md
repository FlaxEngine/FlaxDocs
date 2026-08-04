# UI Canvas

![UI Canvas](media/title.jpg)

**UI Canvas** is an actor type that renders UI. It's the root of the UI structure and performs GUI drawing with input events handling. A canvas can be placed in 3D space (as world-space or camera-space object) or rendered directly on a screen (as screen-space mode).

> [!Note]
> After creating a UI Canvas in the editor, it is rotated by default. This is because the GUI coordinate system uses the upper-left corner of the container as a origin for its transformations.

## Properties

![UI Canvas Properties](media/properties.png)

| Property | Description |
|--------|--------|
| **Render Mode** | Canvas rendering mode. Possible options include: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Screen Space**</td><td>The screen space rendering mode that places UI elements on the screen, rendered on top of the scene. If the screen is resized or changes resolution, the canvas will automatically change size to match this.</td></tr><tr><td>**Camera Space**</td><td>The camera space rendering mode that places canvas in a given distance in front of a specified camera. The UI elements are rendered by this camera, which means that the camera settings affect the appearance of the UI. If the camera is set to 'Perspective', the UI elements will be rendered with perspective and the amount of perspective distortion can be controlled by the camera field of view. If the screen is resized, changes resolution, or the camera frustum changes, the canvas will automatically change size to match as well.</td></tr><tr><td>**World Space**</td><td>The world space rendering mode places the canvas like any other object in the scene. The size of the canvas can be set manually using its transform, and UI elements will render in front of or behind other objects in the scene based on 3D placement. This is useful for UIs that are meant to be a part of the world. This is also known as a "diegetic interface".</td></tr><tr><td>**World Space Face Camera**</td><td>The world space rendering mode that places Canvas as any other object in the scene and orients it to face the camera. The size of the Canvas can be set manually using its Transform, and UI elements will render in front of or behind other objects in the scene based on 3D placement. This is useful for UIs that are meant to be a part of the world. This is also known as a 'diegetic interface'.</td></tr><tr><td>**GPU Texture**</td><td>The off-screen rendering mode that draws the contents of the canvas into a GPU texture that can be used in the scene or by other systems. The size of the canvas is automatically set to the size of the texture.</td></tr></tbody></table>|
| **Render Location** | Canvas rendering location within the rendering pipeline. Change this if you want GUI to affect the lighting or post processing effects like bloom. *Used only by 3D canvas (World Space or Camera Space).* Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Default**</td><td>The default location after the in-build PostFx pass (bloom, color grading, etc.) but before anti-aliasing effect.</td></tr><tr><td>**Before Post Processing Pass**</td><td>The 'before' in-build PostFx pass (bloom, color grading, etc.). After Forward Pass (transparency) and fog effects.</td></tr><tr><td>**Before Forward Pass**</td><td>The 'before' Forward pass (transparency) and fog effects. After the Light pass and Reflections pass.</td></tr><tr><td>**Before Reflections Pass**</td><td>The 'before' Reflections pass. After the Light pass. Can be used to affect Screen Space Reflections by the GUI.</td></tr><tr><td>**After Anti-Aliasing Pass**</td><td>The 'after' AA filter pass. Rendering is done to the output backbuffer.</td></tr></tbody></table>|
| **Order** | The canvas rendering and input events gather order. Created GUI canvas objects are sorted before rendering (from the lowest order to the highest order). Canvas with the highest order can handle input events first. |
| **Receives Events** | If checked, canvas can receive the input events. |
| **Size** | Canvas size. *Used only by World Space canvas.*|
| **Ignore Depth** | If checked, scene depth will be ignored when rendering the GUI (scene objects won't cover the interface). *Used only by 3D canvas (World Space or Camera Space).* |
| **Render Camera** | Camera used to place the GUI. *Used only by Camera Space canvas.* |
| **Distance** | Distance from the RenderCamera to place the plane with GUI. If the screen is resized, changes resolution, or the camera frustum changes then the canvas will automatically change size to match as well. Value is in world units. |
| **Output Texture** | Output texture for the canvas when render mode is set to <see cref="CanvasRenderMode.GPUTexture"/>. The size of the canvas will be automatically set to the size of the texture. The canvas will render its content into this texture.
|||
| **Input Repeat Delay** | The delay (in seconds) before a navigation input event starts repeating if input control is held down (Input Action mode is set to *Pressing*). |
| **Input Repeat Rate** | The delay (in seconds) between successive repeated navigation input events after the first one. |
| **Navigate Up** | The name of the input action for performing UI navigation Up (from Input Settings). |
| **Navigate Down** | The name of the input action for performing UI navigation Down (from Input Settings). |
| **Navigate Left** | The name of the input action for performing UI navigation Left (from Input Settings). |
| **Navigate Right** | The name of the input action for performing UI navigation Right (from Input Settings). |
| **Navigate Submit** | The name of the input action for performing UI navigation Submit (from Input Settings). |

## Rendering Canvas to GPU Texture

Canvas can be rendered directly to the GPU Texture for use in materials or VFX. Simply change the `RenderMode` to `GPUTexture` and provide `OutputTexture` that will be used as an output image for the canvas elements. See an example script:

```cs
using FlaxEngine;

namespace Game;

public class RenderCanvasToTexture : Script
{
    public GPUTexture MyTexture;

    public override void OnEnable()
    {
        // Allocate a new GPU texture and resize it
        MyTexture = new GPUTexture();
        var desc = GPUTextureDescription.New2D(300, 200, PixelFormat.R8G8B8A8_UNorm);
        MyTexture.Init(ref desc);

        // Link texture to the canvas
        Actor.As<UICanvas>().OutputTexture = MyTexture;
    }

    public override void OnDisable()
    {
        // Release reference and dispose texture memory
        Actor.As<UICanvas>().OutputTexture = null;
        Destroy(ref MyTexture);
    }
}
```
