# Mouse

**Mouse** is the most common input device on desktop platforms. You can access the mouse state by using the Input service:
* [Input.MousePosition](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_MousePosition)
* [Input.MousePositionDelta](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_MousePositionDelta)
* [Input.MouseScrollDelta](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_MouseScrollDelta)
* [Input.GetMouseButton](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GetMouseButton_FlaxEngine_MouseButton_)
* [Input.GetMouseButtonDown](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GetMouseButtonDown_FlaxEngine_MouseButton_)
* [Input.GetMouseButtonUp](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GetMouseButtonUp_FlaxEngine_MouseButton_)

## Locking cursor

Some games may want to lock the mouse position. For instance, first-person shooter games usually need 360-degree camera rotation. In those cases, your game probably will want to also hide a mouse cursor.

You can lock the mouse movement by using [Screen.CursorLock](https://docs.flaxengine.com/api/FlaxEngine.Screen.html#FlaxEngine_Screen_CursorLock), and modify the cursor visibility by using [Screen.CursorVisible](https://docs.flaxengine.com/api/FlaxEngine.Screen.html#FlaxEngine_Screen_CursorVisible).

