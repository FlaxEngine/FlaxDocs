# HOWTO: Import asset from code

In case of more advanced game development or plugin development you may need to import or create a texture, model or other asset from code. Flax Editor exposes various public C# APIs that help with automatic-assets creation and management.

Here is an example script that imports a texture from a given path. It is important to use `FLAX_EDITOR` macro when compiling code in the editor, otherwise, compilation may fail during building standalone game. You can also use Editor scripts project to extend the Editor by custom logic (for you game or plugin).

```cs
#if FLAX_EDITOR
var sourcePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MyTexture.png");
var outputPath = Globals.ContentFolder;
var outputLocation = (ContentFolder)Editor.Instance.ContentDatabase.Find(outputPath);

Editor.Instance.ContentImporting.Import(sourcePath, outputLocation, true);
#endif
```

You can also provide custom settings for the importer as shown in the example below that imports the model asset.

```cs
var sourcePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MyModel.fbx");
var outputPath = Globals.ContentFolder;
var outputLocation = (ContentFolder)Editor.Instance.ContentDatabase.Find(outputPath);

var settings = new FlaxEditor.Content.Import.ModelImportSettings();
settings.ImportVertexColors = false;
settings.Scale = 10.0f;

Editor.Instance.ContentImporting.Import(sourcePath, outputLocation, true, settings);
```
