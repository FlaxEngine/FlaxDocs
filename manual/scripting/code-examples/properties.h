#pragma once

#include "Engine/Scripting/Script.h"
#include <Engine/Core/Math/Color.h>
#include <Engine/Level/Actors/DirectionalLight.h>
#include <Engine/Scripting/ScriptingObjectReference.h>

API_CLASS() class GAME_API MyScript : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(MyScript);

public:
    API_FIELD() bool Field1 = 11;
    API_FIELD() Color Field2 = Color::Yellow;
    API_FIELD() ScriptingObjectReference<DirectionalLight> Field3;

public:
    // [Script]
    void OnEnable() override;
    void OnDisable() override;
    void OnUpdate() override;
};