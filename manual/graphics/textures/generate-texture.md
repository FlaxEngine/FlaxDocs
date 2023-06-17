# HOWTO: Generate procedural texture

![Texture](media/cubeResult.png)

In this tutorial, you will learn how to create a simple texture from C# script code.

This sample uses C# API method [Content.CreateVirtualAsset<T>](http://docs.flaxengine.com/api/FlaxEngine.Content.html#FlaxEngine_Content_CreateVirtualAsset__1) to generate procedural texture resource which can be modified at runtime from code.

## Tutorial

### 1. Create new C# script `TextureFromCode`

### 2. Write texture data generating code

# [C#](#tab/code-csharp)
```cs
public class TextureFromCode : Script
{
    private Texture _tempTexture;
    private MaterialInstance _tempMaterialInstance;

    public Material Material;
    public Model Model;

    public override unsafe void OnStart()
    {
        // Ensure that model asset is loaded
        if (Model.WaitForLoaded())
            return;

        // Create new texture asset
        var texture = Content.CreateVirtualAsset<Texture>();
        _tempTexture = texture;
        var initData = new TextureBase.InitData();
        initData.Width = 64;
        initData.Height = 64;
        initData.ArraySize = 1;
        initData.Format = PixelFormat.R8G8B8A8_UNorm;
        var data = new byte[initData.Width * initData.Height * PixelFormatExtensions.SizeInBytes(initData.Format)];
        fixed (byte* dataPtr = data)
        {
            // Generate pixels data (linear gradient)
            var colorsPtr = (Color32*)dataPtr;
            for (int y = 0; y < initData.Height; y++)
            {
                float t1 = (float)y / initData.Height;
                var c1 = Color32.Lerp(Color.Red, Color.Blue, t1);
                var c2 = Color32.Lerp(Color.Yellow, Color.Green, t1);
                for (int x = 0; x < initData.Width; x++)
                {
                    float t2 = (float)x / initData.Width;
                    colorsPtr[y * initData.Width + x] = Color32.Lerp(c1, c2, t2);
                }
            }
        }
        initData.Mips = new[]
        {
            // Initialize mip maps data container description
            new TextureBase.InitData.MipData
            {
                Data = data,
                RowPitch = data.Length / initData.Height,
                SlicePitch = data.Length
            },
        };
        if (texture.Init(ref initData))
            return;

        // Use a dynamic material instance with a texture to sample
        var material = Material.CreateVirtualInstance();
        _tempMaterialInstance = material;
        material.SetParameterValue("tex", texture);

        // Add a model actor and use the dynamic material for rendering
        var staticModel = Actor.GetOrAddChild<StaticModel>();
        staticModel.Model = Model;
        staticModel.SetMaterial(0, material);
    }

    public override void OnDestroy()
    {
        // Ensure to cleanup resources
        FlaxEngine.Object.Destroy(ref _tempTexture);
        FlaxEngine.Object.Destroy(ref _tempMaterialInstance);
    }
}
```
# [C++](#tab/code-cpp)
```cpp
// .h
#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Content/AssetReference.h"
#include "Engine/Content/Assets/Model.h"
#include "Engine/Content/Assets/Material.h"

API_CLASS() class MYPROJECT_API TextureFromCodeCpp : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(TextureFromCodeCpp);
private:
    Texture* _tempTexture = nullptr;
    MaterialInstance* _tempMaterialInstance = nullptr;

public:
    // The custom material to set it's texture.
    API_FIELD() AssetReference<Material> Material;
    // The custom model to set its material.
    API_FIELD() AssetReference<Model> Model;

    // [Script]
    void OnStart() override;
    void OnDestroy() override;
};

// .cpp
#include "TextureFromCodeCpp.h"
#include "Engine/Core/Types/Variant.h"
#include "Engine/Level/Actor.h"
#include "Engine/Content/Content.h"
#include "Engine/Content/Assets/MaterialInstance.h"
#include "Engine/Graphics/PixelFormatExtensions.h"
#include "Engine/Level/Actors/StaticModel.h"

TextureFromCodeCpp::TextureFromCodeCpp(const SpawnParams& params)
    : Script(params)
{
}

void TextureFromCodeCpp::OnStart()
{
    CHECK(Material);
    CHECK(Model);

    // Ensure that model asset is loaded
    if (Model->WaitForLoaded())
        return;

    // Create new texture asset
    auto texture = Content::CreateVirtualAsset<Texture>();
    _tempTexture = texture;
    TextureBase::InitData initData;
    initData.Width = 64;
    initData.Height = 64;
    initData.ArraySize = 1;
    initData.Format = PixelFormat::R8G8B8A8_UNorm;
    auto& mipData = initData.Mips.AddOne();
    {
        // Initialize mip maps data container description
        mipData.Data.Allocate(initData.Width * initData.Height * PixelFormatExtensions::SizeInBytes(initData.Format));
        mipData.RowPitch = mipData.Data.Length() / initData.Height;
        mipData.SlicePitch = mipData.Data.Length();
    }
    byte* data = mipData.Data.Get();
    {
        // Generate pixels data (linear gradient)
        auto colorsPtr = (Color32*)data;
        for (int y = 0; y < initData.Height; y++)
        {
            float t1 = (float)y / initData.Height;
            Color c1 = Color::Lerp(Color::Red, Color::Blue, t1);
            Color c2 = Color::Lerp(Color::Yellow, Color::Green, t1);
            for (int x = 0; x < initData.Width; x++)
            {
                float t2 = (float)x / initData.Width;
                colorsPtr[y * initData.Width + x] = Color32(Color::Lerp(c1, c2, t2));
            }
        }
    }
    if (texture->Init(MoveTemp(initData)))
        return;

    // Use a dynamic material instance with a texture to sample
    auto material = Material->CreateVirtualInstance();
    _tempMaterialInstance = material;
    material->SetParameterValue(TEXT("tex"), Variant(texture));

    // Add a model actor and use the dynamic material for rendering
    auto staticModel = GetActor()->GetOrAddChild<StaticModel>();
    staticModel->Model = Model;
    staticModel->SetMaterial(0, material);
}

void TextureFromCodeCpp::OnDestroy()
{
    // Ensure to cleanup resources
    SAFE_DELETE(_tempMaterialInstance);
    SAFE_DELETE(_tempTexture);
}
```
***

### 3. Create material

Create a sample material that contains a public texture parameter named `tex`. It's used by the script to assign a texture to draw.

![Material](media/material1.png)

### 4. Link material and model

Add created script `TextureFromCode` to an actor in your scene (or create a new one for it). Then select it and assign the model and created material (as shown in a picture below).

![Link Material and Model](media/textureFromCode1.png)

### 5. Test it out!

Press **Play** (or *F5*) and see the results!

![Results](media/cubeResult.png)
