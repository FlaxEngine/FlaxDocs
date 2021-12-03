#pragma once

#include "Engine/Scripting/Script.h"
#include <Engine/Level/Actors/SpotLight.h>
#include <Engine/Scripting/ScriptingObjectReference.h>

API_CLASS() class EXAMPLE_API MyScript : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(MyScript);

    API_FIELD()
    ScriptingObjectReference<SpotLight> Flashlight;

    // [Script]
    void OnStart() override
    {
        Flashlight.Get()->DeleteObject();
    }
};