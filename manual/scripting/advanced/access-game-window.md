# Access Game Window

Flax automatically creates the main window for the game. Some platforms allow to customzie it (eg. desktop) while on other platforms access to it is fixed (eg. consoles). Hovewer Flax supports API for creating custom windows (multi-window setup) and you can also access the pre-created window from your scripts.

## Change window title

To change the title of you game window simply access the root control for the game UI and peek it's parent window.

# [C#](#tab/code-csharp)
```cs
#if !FLAX_EDITOR
RootControl.GameRoot.RootWindow.Window.Title = "Hello!"
#endif
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Engine/Engine.h"
#include "Engine/Platform/Window.h"

#if !USE_EDITOR
Engine::MainWindow->SetTitle(TEXT("Hello!"));
#endif
```
***

You can also resize or adjust the window manually.

## Managing cursor and focus

Engine provides a utility to show/hide and constrain mouse cursor via: `Screen.CursorVisible` and `CursorLock.CursorLockMode` properties. Cursor lock modes are:
* `None` - the default mode.
* `Locked` -  cursor position is locked to the center of the game window. Ideal for FPS games.
* `Clipped` - cursor position is confined to the bounds of the game window. Ideal for RTS/Strategy games.

Your game camera script can manage those and use `Engine.HasGameViewportFocus` property to detect whether game viewport is focused by the player, which is well supported in Ediotr to allow developer debug game while it's running in one of the Editor windows:

# [C#](#tab/code-csharp)
```cs
/// <inheritdoc />
public override void OnUpdate()
{
    if (Engine.HasGameViewportFocus)
    {
        // Hide and lock mouse cursor
        Screen.CursorVisible = false;
        Screen.CursorLock = CursorLockMode.Locked;
    }

    var mouseDelta = new Float2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    pitch = Mathf.Clamp(pitch + mouseDelta.Y, -88, 88);
    yaw += mouseDelta.X;
    // ...more camera logic
}
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Engine/Engine.h"
#include "Engine/Engine/Screen.h"
#include "Engine/Input/Input.h"

void OnUpdate() override
{
    if (Engine::HasGameViewportFocus())
    {
        // Hide and lock mouse cursor
        Screen::SetCursorVisible(false);
        Screen::SetCursorLock(CursorLockMode::Locked);
    }

    Float2 mouseDelta(Input::GetAxis(TEXT("Mouse X")), Input::GetAxis(TEXT("Mouse Y")));
    pitch = Math::Clamp(pitch + mouseDelta.Y, -88, 88);
    yaw += mouseDelta.X;
    // ...more camera logic
}
```
***

When creating pause menu or game main menu you can use `Engine.FocusGameViewport()` method which focuses the game window and allows player to use UI Navigation (eg. with gamepad or Tab) within the opened UI panel.

### Cursor image

Depending on the platform, mouse cursor can have a custom image. Use `Window.LoadCursorImage` to load cursor from texture data (or from `.cur`/`.ani` file on Windows). Then you can call `SetCursorImage` on game window and shoow it by changing cursor to `CursorType.Image`. See the example code below:

# [C#](#tab/code-csharp)
```cs
public class TestCursor : Script
{
    private IntPtr _cursorFromFile;
    private IntPtr _cursorFromTexture;

    public Texture CursorFromTexture;

    public override void OnEnable()
    {
        // Load cursor from file 'Content/cursor1.cur'
        _cursorFromFile = Window.LoadCursorImage(Path.Combine(Globals.ProjectContentFolder, "cursor1.cur"));

        // Load cursor from texture data (use uncompressed image)
        CursorFromTexture.GetTextureData(out var textureData);
        var hotSpot = Int2.Zero;
        _cursorFromTexture = Window.LoadCursorImage(textureData, hotSpot);
        Destroy(textureData);
    }

    public override void OnDisable()
    {
        // Ensure to destroy unsued resources
        Window.DestroyCursorImage(_cursorFromFile);
        Window.DestroyCursorImage(_cursorFromTexture);
    }

    /// <inheritdoc/>
    public override void OnUpdate()
    {
        // Get current game window (works in both Editor and cooked Game)
        var win = RootControl.GameRoot.RootWindow.Window;

        // Toggle cursor visibility Q/W keys
        if (Input.GetKeyDown(KeyboardKeys.Q))
            Screen.CursorVisible = true;
        if (Input.GetKeyDown(KeyboardKeys.W))
            Screen.CursorVisible = false;

        // Change cursor type 1-3 keys
        if (Input.GetKeyDown(KeyboardKeys.Alpha1))
        {
            win.Cursor = CursorType.Default;
        }
        if (Input.GetKeyDown(KeyboardKeys.Alpha2))
        {
            win.Cursor = CursorType.Image;
            win.CursorImage = _cursorFromFile;
        }
        if (Input.GetKeyDown(KeyboardKeys.Alpha3))
        {
            win.Cursor = CursorType.Image;
            win.CursorImage = _cursorFromTexture;
        }
    }
}
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Scripting/Script.h"
#include "Engine/Engine/Engine.h"
#include "Engine/Engine/Screen.h"
#include "Engine/Engine/Globals.h"
#include "Engine/Content/AssetReference.h"
#include "Engine/Content/Assets/Texture.h"
#include "Engine/Platform/Window.h"
#include "Engine/Graphics/Textures/TextureData.h"
#include "Engine/Input/Input.h"

class GAME_API TestCursor : public Script
{
    DECLARE_SCRIPTING_TYPE(TestCursor);
    API_AUTO_SERIALIZATION();
private:
    void* _cursorFromFile = nullptr;
    void* _cursorFromTexture = nullptr;

public:
    API_FIELD() AssetReference<Texture> CursorFromTexture;

    void OnEnable() override
    {
        // Load cursor from file 'Content/cursor1.cur'
        _cursorFromFile = Window::LoadCursorImage(Globals::ProjectContentFolder / TEXT("cursor1.cur"));

        // Load cursor from texture data (use uncompressed image)
        TextureData textureData;
        CursorFromTexture->GetTextureData(textureData);
        auto hotSpot = Int2::Zero;
        _cursorFromTexture = Window::LoadCursorImage(textureData, hotSpot);
    }
    void OnDisable() override
    {
        // Ensure to destroy unsued resources
        Window::DestroyCursorImage(_cursorFromFile);
        Window::DestroyCursorImage(_cursorFromTexture);
    }
    void OnUpdate() override
    {
        // Get current game window (works in both Editor and cooked Game)
        auto win = Engine::MainWindow;

        // Toggle cursor visibility Q/W keys
        if (Input::GetKeyDown(KeyboardKeys::Q))
            Screen::SetCursorVisible(true);
        if (Input::GetKeyDown(KeyboardKeys::W))
            Screen::SetCursorVisible(false);

        // Change cursor type 1-3 keys
        if (Input::GetKeyDown(KeyboardKeys::Alpha1))
        {
            win->SetCursor(CursorType::Default);
        }
        if (Input::GetKeyDown(KeyboardKeys::Alpha2))
        {
            win->SetCursor(CursorType::Image);
            win->SetCursorImage(_cursorFromFile);
        }
        if (Input::GetKeyDown(KeyboardKeys::Alpha3))
        {
            win->SetCursor(CursorType::Image);
            win->SetCursorImage(_cursorFromTexture);
        }
    }
};
```
***
