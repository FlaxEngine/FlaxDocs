# Raw Data Asset

**Raw Data Asset** is a general purpose data container that is designed to store an array of raw bytes.

## Example code

Here is an example usage code that creates a virtual assets, sets its data and saves it to file.

```cs
var myAsset = Content.CreateVirtualAsset<RawDataAsset>();
myAsset.Data = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
myAsset.Save(Path.Combine(Globals.ContentFolder, "MyData.flax"));
```

Then you can load the asset or reference is in the script and use in your game.

```cs
var myAsset = Content.Load<RawDataAsset>(Path.Combine(Globals.ContentFolder, "MyData.flax"));
Debug.Log("Data size: " + myAsset.Data.Length);
```
