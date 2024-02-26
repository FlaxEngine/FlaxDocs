# HOWTO: Raycast UI

UI controls implement `RayCast` utility method that can perform the precise checks for the mouse-content intersections. This can be useful when checking whether the mouse interacts with UI or the gameplay.

```cs
using FlaxEngine;
using FlaxEngine.GUI;

/// <summary>
/// Sample UI ray casting script.
/// </summary>
public class TestCanvasRayCast : Script
{
    /// <inheritdoc/>
    public override void OnUpdate()
    {
        var ui = RootControl.GameRoot;
        var pos = Input.MousePosition;
        if (ui.RayCast(ref pos, out var hit))
        {
            Debug.Log("UI hit over: " + hit.GetType().Name);
        }
    }
}
```
