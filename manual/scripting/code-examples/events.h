#pragma once

#include "Engine/Scripting/Script.h"

API_CLASS() class GAME_API MyScript : public Script
{
public:
    API_AUTO_SERIALIZATION();

    DECLARE_SCRIPTING_TYPE(MyScript);

public:
    // [Script]
    void OnEnable() override;
    void OnDisable() override;
    void OnUpdate() override;
    void OnStart() override;
};