# File Reference

Flax uses the concept of **Asset** which is a resource with type (typename), unique identifier (128-bit `Guid`) and data. This serves well for game resources such as textures, models, Visual Scripts, Json files but cannot be used for source files or other data files like text files, spreadsheets, etc.

Here is an example usage of file reference which can be assigned in Editor to file from *Content* window. `AssetReference` attribute used on `string` property or field will store the path relative to the project root folder. You can specify the file extension to use (eg. `.txt` or `.csv`).

```cs
public class MyFileReference : Script
{
    [AssetReference(".txt"), CustomEditorAlias("FlaxEditor.CustomEditors.Editors.AssetRefEditor")]
    public string Path = "";

    // Alternative way for path reference that supports any text input (eg. URL)
    [AssetReference(".txt"), CustomEditorAlias("FlaxEditor.CustomEditors.Editors.FilePathEditor")]
    public string Url = "";

    /// <inheritdoc />
    public override void OnStart()
    {
        Debug.Log("Selected path: " + Path);
        // You can read file directly from disc (eg. via File.ReadAllText)
    }
}
```
