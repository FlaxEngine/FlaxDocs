#pragma once

#include "Engine/Scripting/Script.h"

API_CLASS() class GAME_API AutoRemoveObj : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(AutoRemoveObj);

    API_FIELD(Attributes = "Tooltip(\"The time left to destroy object (in seconds).\")")
    float Timeout = 5.0f;

    // [Script]
    void OnEnable() override;
    void OnDisable() override;
    void OnUpdate() override;
    void OnStart() override 
    {
        GetActor()->DeleteObject(Timeout);
    }
};