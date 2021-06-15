#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Debug/DebugLog.h"

API_CLASS()
class GAME_API ScriptExample : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(ScriptExample);

    // [Script]
    void OnEnable() override;
    void OnDisable() override;
    void OnStart() override
    {
        // Prints all children names
        Array<Actor *> children = GetActor()->GetChildren<Actor>();
        for each (auto a in children)
            DebugLog::Log(a->GetName());

        // Changes the child point light color (if has)
        auto pointLight = GetActor()->GetChild<PointLight>();
        if (pointLight)
            pointLight->Color = Color::Red;
    }
    void OnUpdate() override
    {
        // Rotates the parent object
        Vector3 targetOrientation = GetActor()->GetParent()->GetLocalOrientation().GetEuler();
        targetOrientation += {0, 2, 0};

        GetActor()->GetParent()->SetLocalOrientation(Quaternion::Euler(targetOrientation));
    }
};