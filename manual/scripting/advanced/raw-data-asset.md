# Raw Data Asset

**Raw Data Asset** is a general purpose data container that is designed to store an array of raw bytes.

## Example code

Here is an example usage code that creates a virtual assets, sets its data and saves it to file.

```cs
var myAsset = Content.CreateVirtualAsset<RawDataAsset>();
myAsset.Data = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
myAsset.Save(Path.Combine(Globals.ProjectContentFolder, "MyData.flax"));
```

Then you can load the asset or reference is in the script and use in your game.

```cs
var myAsset = Content.Load<RawDataAsset>(Path.Combine(Globals.ProjectContentFolder, "MyData.flax"));
Debug.Log("Data size: " + myAsset.Data.Length);
```

Here is an example usage code in C++ that creates a virtual assets, sets its data and saves it to file while also assigning it to a field member.

```cpp
API_CLASS() class GAME_API Test : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(Test);
public:
    API_FIELD() AssetReference<RawDataAsset>> Data;
    API_FUNCTION() void Save()
    {
        // This code only works with assets imported compiled
#if COMPILE_WITH_ASSETS_IMPORTER
        // Create a container for data
        BytesContainer bytesContainer;
        bytesContainer.Allocate(32);
        // Fill it with random stuff
        for (int i = 0; i < 32; ++i)
            bytesContainer[i] = i;
        // Determine a saving path. Using Globals::ProjectContentFolder and equivelants and never use TEXT("Content/{xxx}")
        // or you WILL get asset duplication issues.
        const String targetPath = Globals::ProjectContentFolder / TEXT("Test") + ASSET_FILES_EXTENSION_WITH_DOT;
        // Manually generating a Guid to get consistency for the field assignment.
        Guid assetId = Guid::New();
        // Perform a content saving opperation
        AssetsImportingManager::Create(AssetsImportingManager::CreateRawDataTag, targetPath, assetId, (void*)&bytesContainer);
        // Take a Guid that was used during asset saving and use it to load an asset to your field
        Data = Content::Load<RawDataAsset>(assetId);
#endif
    }
};
```
