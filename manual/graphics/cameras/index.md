# Cameras

![Camera](media/camera.png)

**Camera** captures the scene and displays it to the user. It defines a view in screen space. Camera's position and rotaton define the *viewport* and *view direction*. Those properties are used to render scene objects and preent them to the user.

Flax Engine allows to create unlimited amount of cameras in scene while the [main one](http://docs.flaxengine.com/api/FlaxEngine.Camera.html#FlaxEngine_Camera_MainCamera) is used for the final frame rendering.

## Creating camera in editor

In the *Scene* tree window, right-click and select **New -> Camera**.
Editor will create new Camera actor with default properties.

![New Camera](media/new-cam.jpg)

## Creating camera in script

The following sample code can be used to instantiate new camera object in a scene.

```cs
public class MyScript : Script
{
	public override void OnStart()
	{
		var camera = new Camera();
		Level.SpawnActor(camera);
		camera.Position = new Vector3(0, 100, 0);
	}
}
```

To learn more about the C# scripting API see [Camera](http://docs.flaxengine.com/api/FlaxEngine.Camera.html) class.

## Camera properties

![Camera Propertiess](media/camera-properties.png)

| Property | Description |
|--------|--------|
| **Field Of View** | The vertical field of view (in degrees) used for perspective projection. |
| **Use Perspective** | If checked, camera will use perspective projection, otherwise orthographic. |
| **Near Plane** | The nearest point the camera can see (near clipping plane). |
| **Far Plane** | The furthest point the camera can see (far clipping plane). |
| **Custom Aspect Ratio** | Custom aspect ratio you specify. Otherwise, automatically adjust the aspect ratio to the render target ratio. Use value 0 to disable it. |
| **Orthographic Scale** | Additional scale used for the orthographic projection size. This has the effect of zooming in and out. |
| **Render Layers Mask** | The layers mask used for rendering using this camera. Can be used to include or exclude specific actor layers from the drawing. |

## Masking object layers

![Camera Render Layers Masking](media/render-layers-masking.gif)

Every actor on a scene has **Layer** property assigned. Cameras can use per-layer masking for rendering to include or exclude certain objects from drawing.

## Perspective and orthographic cameras

Camera objects can work in two modes: perspective and orthographic. Each mode uses different projection mapping method affect how rendered scene looks.

- **Perspective** camera provides a "real-world" perspective of the objects in your scene. In this view, objects close to the camera appear larger, and lines of identical lengths appear different due to foreshortening, as in reality. Perspective cameras are most used for games that require a realistic perspective, such as third-person and first-person shooters.

- **Orthographic** camera renders objects always in the same size, no matter their distance from the camera. Parallel lines never touch, and there's no vanishing point. Orthographic cameras are most used for games with isometric perspectives, such as some strategy or role-playing games.

## Field of view (perspective mode only)

If camera has checked value **Use Perspective**, then it will use perspective projection. The **field of view** changes the camera frustum, and has effect of zooming in or out of the scene. When using high value (90 or above), the field of view results in stretched "fish-eye lens' views.

| Field of view: 50 | Field of view: 80 |
|--------|--------|
| ![Field of View 50](media/fov_1.png) | ![Field of View 80](media/fov_2.png) |

## Orthographic scale (orthographic mode only)

If camera has unchecked value **Use Perspective**, then it will use orthographic projection. The **orthographic scale** changes the camera frustum size, and has effect of zooming in or out of the scene.

| Orthographic scale: 0.3 | Orthographic scale: 1 |
|--------|--------|
| ![Field of View 50](media/ortho_scale_1.png) | ![Field of View 80](media/ortho_scale_2.png) |

## Near and far planes

The near and far clipping planes are used to define the camera frustum begin and end points.
The near plane is the closest point the camera can see. All geometry that it in front of it won't be rendered.
The far plane is the furthest point the camera can see. It's also known as a draw distance or a view distance. All geometry that it beyond of it won't be rendered.

Adjusting near and far planes affects rendering precision and scene depth quality. Using too small near plane value (lower than 1) or very high far plane (higher than 100000) may result in depth precision issues as well as [Z-fighting](https://en.wikipedia.org/wiki/Z-fighting).

| Near plane: 300 | Far plane: 800 |
|--------|--------|
| ![Field of View 50](media/nearFar_1.png) | ![Field of View 80](media/nearFar_2.png) |

## Render a camera to a texture

Flax Engine offers very wide range of customization that can be made to extend the rendering pipeline. One of them is rendering scene using the custom camera right to the render target. Then presenting it on an object surface. To create such effect check out the tutorial: [How to render a camera to a texture](render-camera-to-texture.md).

## Override view

Flax uses extensible RenderTask system for high-level rendering achitecture. By default game uses `MainRenderTask.Instance` to drive the scene rendering into the main game viewport. You can use it to plug into rendering pipeline for custom effects, rendering or view override.

# [C#](#tab/code-csharp)
```cs
class MyScript : Script
{
    public override void OnEnable()
    {
        MainRenderTask.Instance.PreRender += OnPreRender;
    }

    public override void OnDisable()
    {
        MainRenderTask.Instance.PreRender -= OnPreRender;
    }

    private void OnPreRender(GPUContext context, ref RenderContext renderContext)
    {
        // Here you can modify the render View
        float fov = 120.0f;
        renderContext.View.Near = 100.0f;
        Viewport viewport = renderContext.Buffers.Viewport;
        Matrix view = renderContext.View.View;
        Matrix proj;
        Matrix.PerspectiveFov(fov * Mathf.DegreesToRadians, viewport.AspectRatio, renderContext.View.Near, renderContext.View.Far, out proj);
        renderContext.View.SetUp(ref view, ref proj);
    }
}
```
# [C++](#tab/code-cpp)
```cpp
#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Core/Log.h"
#include "Engine/Graphics/RenderBuffers.h"
#include "Engine/Graphics/RenderTask.h"

API_CLASS() class GAME_API MyScript : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(MyScript);

    void OnPreRender(GPUContext* context, RenderContext& renderContext)
    {
        // Here you can modify the render View
        float fov = 120.0f;
        renderContext.View.Near = 100.0f;
        const Viewport viewport(renderContext.Buffers->GetViewport());
        Matrix view = renderContext.View.View;
        Matrix proj;
        Matrix::PerspectiveFov(fov * DegreesToRadians, viewport.GetAspectRatio(), renderContext.View.Near, renderContext.View.Far, proj);
        renderContext.View.SetUp(view, proj);
    }

    // [Script]
    void OnEnable() override
    {
        MainRenderTask::Instance->PreRender.Bind<MyScript, &MyScript::OnPreRender>(this);
    }

    void OnDisable() override
    {
        MainRenderTask::Instance->PreRender.Unbind<MyScript, &MyScript::OnPreRender>(this);
    }
};

inline MyScript::MyScript(const SpawnParams& params)
    : Script(params)
{
}
```
***
