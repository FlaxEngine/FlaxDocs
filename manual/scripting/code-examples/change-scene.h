#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Input/Input.h"
#include "Engine/Level/Level.h"

API_CLASS() class GAME_API SceneChanger : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(SceneChanger);

    API_FIELD(Attributes = "CustomEditorAlias(\"FlaxEditor.CustomEditors.Editors.SceneRefEditor\"), AssetReference(typeof(SceneReference))")
    Guid AnotherScene;

    // [Script]
    void OnUpdate() override
    {
        if (Input::GetKeyDown(KeyboardKeys::G) && AnotherScene.IsValid())
        {
            // Does the same as the C# API
            Level::UnloadAllScenesAsync();
            Level::LoadSceneAsync(AnotherScene);
        }
    }
};
