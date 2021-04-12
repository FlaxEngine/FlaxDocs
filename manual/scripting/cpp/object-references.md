# Object References for C\+\+ in Flax

## Assets

When referencing assets in C++ code use `AssetReference<T>` where `T` is a type of the asset. It will handle asset events, serialization and provide a safe way of referencing asset objects.

```cpp
// .h
#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Content/Assets/Texture.h"
#include "Engine/Content/AssetReference.h"

API_CLASS() class GAME_API MyCppScript : public Script
{
API_AUTO_SERIALIZATION();
DECLARE_SCRIPTING_TYPE(MyCppScript);
public:
	API_FIELD() AssetReference<Texture> AssetRef;

	// [Script]
	void OnEnable() override;
};

// .cpp
#include "MyCppScript.h"

MyCppScript::MyCppScript(const SpawnParams& params)
	: Script(params)
{
}

void MyCppScript::OnEnable()
{
	LOG(Info, "Selected asset: {0}", AssetRef ? AssetRef->ToString() : String::Empty);
	if (AssetRef && !AssetRef->WaitForLoaded())
	{
		LOG(Info, "Texture size: {0}", AssetRef->Size());
	}
}
```

If you want to reference asset without increasing the ref count use `WeakAssetReference<Type>`.

## Objects

When referencing other gameplay objects eg. other scripts or actors use `ScriptingObjectReference<Type>` where `T` is a type of the object.

```cpp
// .h
#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Scripting/ScriptingObjectReference.h"
#include "Engine/Level/Actors/PointLight.h"

API_CLASS() class GAME_API MyCppScript : public Script
{
API_AUTO_SERIALIZATION();
DECLARE_SCRIPTING_TYPE(MyCppScript);
public:
	API_FIELD() ScriptingObjectReference<PointLight> LightRef;

	// [Script]
	void OnEnable() override;
};

// .cpp
#include "MyCppScript.h"

MyCppScript::MyCppScript(const SpawnParams& params)
	: Script(params)
{
}

void MyCppScript::OnEnable()
{
	LOG(Info, "Selected light: {0}", LightRef ? LightRef->GetNamePath() : String::Empty);
}
```

If you want to create soft-reference to the object use `SoftObjectReference<T>`. It will support referencing objects that are not yet loaded (eg. soft-asset ref or object from other scene that will be streamed in later).
