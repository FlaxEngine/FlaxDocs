# Using Assets

Asset are used by almost all parts of the engine.
Model actors need materials and 3D model assets to draw the geometry, Environment probes need cube textures to use them for reflections rendering and so on.
Every asset is identified by its own **unique ID**.
This means you can rename and move your assets around the Content workspace without resictions.
Also if you reference asset in your script, only asset id is serialized to keep the linkage.

## Use asset

In editor, for most of the time, to use the asset simply drag and drop it into the asset picker control.

![Apply material](../../graphics/materials/media/apply-material-2.jpg)

Some asset types (models, materials, etc.) support direct drag and drop into the editor viewport.
For example, if you drag and drop the model into the scene it will spawn the Model Actor instance.
You can also drag and drop material or material instance onto the model to set its material.

![Apply material](../../graphics/materials/media/apply-material-1.jpg)

## Asset picker

Asset references can be modified in Editor using an **asset picker**. This controls allows to preview the asset thumbnail, select asset in a *Content* window or clear the reference. If you double-click on the asset icon it will open the default editor for this asset type. Also you can use asset picker to drag the asset reference into the other pickers.
![Apply material](../../graphics/materials/media/apply-material-3.jpg)

Some asset pickers are smaller to reduce UI complexity:

![Small picker](media/small-settings.jpg)

## Assets in scripts

All asset types can be also used at runtime in you C# scripts. For example, declare a public field in your script and use the value.

```cs
public class SetMaterial : Script
{
    [Tooltip("Material to assign to the model")]
    public Material Material;

    public override void OnStart()
    {
        ((StaticModel)Actor).Entries[0].Material = Material;
    }
}
```
