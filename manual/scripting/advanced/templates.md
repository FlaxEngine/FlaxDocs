# Script Templates

Script templates can be used to allow users to create a new script based on a template.

## Create a script template

Create a text document anywhere in the **Content** folder and create the template that you desire. It is recommended the use .cs or .h/.cpp for the file extension for the template files.

### The available identifiers

Use the following identifiers to replace certain parts of your template with information upon creation by the user.

| Identifier | Description |
|--------|--------|
| **%copyright%** | Replaced with the copyright comment |
| **%class%** | Replaced with the class name. This is a modified version of the file name. |
| **%filename%** | C++ Template only. Replaced with the file name. |
| **%module%** | C++ Template only. Replaced with the module name. |
| **%namespace%** | C# Template only. Replaced with the module name. |

## Create a new template proxy

New C# template proxy:

```cs
[ContentContextMenu("New/C#/My new template")]
public class TestingCSharpProxy : CSharpProxy 
{
    public override string Name => "My new template";

    protected override void GetTemplatePath(out string path)
    {
        // Can use `Globals` class to get specific project folders
        path = "path to new .cs template";
    }
}
```

New C++ template proxy:

```cs
[ContentContextMenu("New/C++/My new template")]
public class TestingCppProxy : CppProxy
{
    public override string Name => "My new template";

    protected override void GetTemplatePaths(out string headerTemplate, out string sourceTemplate)
    {
        // Can use `Globals` class to get specific project folders
        headerTemplate = "path to new .h template";
        sourceTemplate = "path to new .cpp template";
    }
}
```

Add the new proxy to the **ContentDatabase** using an **EditorPlugin**

```cs
public class TestEditorPlugin : EditorPlugin
{
    public override void InitializeEditor()
    {
        base.InitializeEditor();
        
        Editor.ContentDatabase.AddProxy(new TestingCSharpProxy());
        Editor.ContentDatabase.AddProxy(new TestingCppProxy());
        Editor.ContentDatabase.Rebuild(true);
    }
}
```