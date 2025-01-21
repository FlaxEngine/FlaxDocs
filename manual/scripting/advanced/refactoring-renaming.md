# Refactoring and Renaming

Sometimes during development programmers need to rename script properties or fields, change asset data format or refactor code. As this is pretty common case for longer projects please follow this documentation page to learn how to handle those kind of situations with an ease. *Good luck!*

## Renaming property or field

In this example, script had field named `PlayerSpeed` that was renamed to `Speed`. By adding `JsonProperty` attribute to C# filed you cna redirect serializer to use other name. It works in the same way for game scripts and json asset objects.

```cs
// C#

// Before:
public float PlayerSpeed;

// After:
[JsonProperty("PlayerSpeed")]
public float Speed;
```

## Moving fields or properties when refactoring code

In this example, asset had field named `WalkableRadius` but it was removed and refactored into structure `SurfaceOptions`. By adding property you can use its setter method to perform data upgrade on deserialization. Make it `private`, add `Serialize` attribute so it will be using serialization and mark as `Obsolete` so it won't be saved anymore. `ContentDeprecated.Mark` can be used to indicate that object upgraded its data from the old format which wil cause source asset saving in Editor.

# [C#](#tab/code-csharp)
```cs
// Before:
public float WalkableRadius;

// After:
public struct SurfaceOptions
{
    public float WalkRadius;
}
public SurfaceOptions Surface;

[Serialize, Obsolete, NoUndo]
private float WalkableRadius
{
    get => throw new Exception();
    set
    {
        // Upgrade value
        Surface.WalkRadius = value;

#if FLAX_EDITOR
        // Mark content as deprecated (engine will resave asset)
        ContentDeprecated.Mark();
#endif
    }
}
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Content/Deprecated.h"

// If your type is using API_AUTO_SERIALIZATION() then add deprecated property upgrader:
private:
API_PROPERTY(Attributes="Serialize, Obsolete, NoUndo") float GetWalkableRadius() const
{
    return Surface.WalkRadius;
}

API_PROPERTY(Attributes="Serialize, Obsolete, NoUndo") void SetWalkableRadius(float value)
{
    // Upgrade value
    Surface.WalkRadius = value;

    // Mark content as deprecated (engine will resave asset)
    MARK_CONTENT_DEPRECATED();
}

// If you manually serialize your type, then read the old json entry during deserialization:
void MyType::Deserialize(DeserializeStream& stream, ISerializeModifier* modifier)
{
    const auto e = SERIALIZE_FIND_MEMBER(stream, "WalkableRadius");
    if (e != stream.MemberEnd())
        Serialization::Deserialize(e->value, Surface.WalkRadius, modifier);
    // ...then deserialize other properties/fields
}
```
***
