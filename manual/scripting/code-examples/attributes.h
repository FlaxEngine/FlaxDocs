#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Level/Actors/PointLight.h"

API_CLASS(Attributes = "ExecuteInEditMode") class GAME_API MyGenerator : public Script
{
public:
    API_AUTO_SERIALIZATION();

    DECLARE_SCRIPTING_TYPE(MyGenerator);

public:
    // [Script]
    void OnEnable() override;
    void OnDisable() override;
    void OnUpdate() override;
    void OnStart() override
    {
        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 5; z++)
            {
                auto light = New<PointLight>();
                light->SetRadius(1000.0f);
                light->ShadowsMode = ShadowsCastingMode::None;
                light->SetPosition({ x * 100.0f, 0, z * 100.0f });
                light->SetParent(GetActor());
                //light->HideFlags = HideFlags::DontSave; // Uncomment to don't save generated actors
            }
        }
    }
};