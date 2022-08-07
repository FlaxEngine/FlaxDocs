# Tips & Tricks for C\+\+ in Flax

* To create new object use `New<Type>()` - it allocates memory using Flax allocators
* For string literalts use `TEXT("My  Cool Text in UTF-16")` macro
* You can use raw pointers to the assets but the safe way is with `AssetReference<T>` or `WeakAssetReference<T>`
* To reference scene objects and other scripts in a safe way `ScriptingObjectReference<T>` is preferred
* Scripting classes can be visible in Editor and C# scripting needs to have `API_CLASS()` meta macro before and `DECLARE_SCRIPTING_TYPE(<typename>);` added
* By default script objects contain a constructor that takes a single parameter `const SpawnParams& params`
* To expose a field into the editor and C# scripting use `API_FIELD()` prefix macro that can contain additional metadata attributes
* To expose a function to the editor and C# scripting use `API_FUNCTION` prefix macro
* You can use engine API similar to C# (eg. Camera, Physics, Input...)
* The `<module_name>_API` define used between `class` and class name (i.e. `class GAME_API MouseDecalShoot`) is to export the C++ class to public module symbols so it can be used by other code
* You can manually override `Serialize`/`Deserialize` method or use `API_AUTO_SERIALIZATION` macro to automatically generate serialziation code for the type (for classes and structures that inherit from `ISerializable`)
* If your game module uses types from various engine modules (eg. Graphics, Physics) you have to add a reference to the in a build script so build tools can handle modules dependencies and properly link binaries - simply add `options.PublicDependencies.Add("<module_name>");` in you build script (where module name is Physics/Terrain/etc. - see BuildScripts for all modules you can use)
* Engine uses C++14 version but you can override it for your own code module with `options.CompileEnv.CppVersion = CppVersion.Cpp17;` in your build script.
* Reference Scene asset with a picker UI for editor:

```cpp
API_FIELD(Attributes="CustomEditorAlias(\"FlaxEditor.CustomEditors.Editors.SceneRefEditor\"), AssetReference(typeof(SceneReference))")
Guid SceneAsset = Guid::Empty;
```

* Custom constructor example for class object:

```cpp
// .h
API_CLASS() class GAME_API Primitives : public Actor
{
DECLARE_SCRIPTING_TYPE(Primitives);
public:
    Primitives(const SpawnParams& params, int32 pt);
};

// .cpp
Primitives::Primitives(const SpawnParams& params)
	: Actor(params)
{
    // Default constructor body
}
Primitives::Primitives(const SpawnParams& params, int32 pt)
	: Actor(params)
{
    // Custom constructor body
}

// usage
int32 pt = 11;
auto obj = New<Primitives>(SpawnParams(Guid::New(), Primitives::TypeInitializer), pt);
```

* You can convert scripting enum values to string (eg. for logging) or parse it back (eg. from console command input):

```cpp
API_ENUM()
enum class PlayerStates
{
    Idle,
    Running,
    Swimming,
    Attacking,
    Died,
};

#include "Engine/Core/Log.h"
#include "Engine/Scripting/Enums.h"

PlayerStates playerState = PlayerStates::Attacking;
LOG(Info, "Player state: {0} = {1}", ScriptingEnum::ToString(playerState), playerState);
String stateName = ScriptingEnum::ToString(PlayerStates::Running);
PlayerStates state = ScriptingEnum::FromString<PlayerStates>(stateName);
LOG(Info, "Player state: {0} = {1}", stateName, state);
```

See `ScriptingEnum` for more.
