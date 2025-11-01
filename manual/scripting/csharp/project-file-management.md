# Project file management

Flax.Build tool generates the required C# project files expected for the configured Code Editor, which usually uses the .csproj-file format accompanied with Visual Studio .sln-solution files. The code editor can then use these files to provide code completion and other features language server features to help the user navigate around the codebase.

As these files are constantly regenerated after modifying the module files or adding new source files, any permanent modifications to the generated .csproj-file should be avoided. The expected place to do these modifications are in the [module configuration files](../../editor/flax-build/index.md) (eg. `Game.Build.cd`), which are used to configure the project file generation process.

# Adding references

`/Source/Game/MyScript.cs(32,13,32,18): error CS1069: The type name 'Regex' could not be found in the namespace 'System.Text.RegularExpressions'. This type has been forwarded to assembly 'System.Text.RegularExpressions, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' Consider adding a reference to that assembly.`

When scripting requires referencing other common system references, we can modify the module build file (eg. `Game.Build.cd`) in the following way to add the reference to the required assembly:
```cs
public override void Setup(BuildOptions options)
{
    base.Setup(options);

    options.ScriptingAPI.SystemReferences.Add("System.Text.RegularExpressions");
}
```

Referencing third-party C# library files can be done with file references, but in this case we need to provide the path to the assembly file:
```cs
public override void Setup(BuildOptions options)
{
    base.Setup(options);

    // Note: the path is relative to the .build file itself
    options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Content", "CustomAssembly.dll"));
}
```

In order to add **Nuget-packages** to your project, please see the dedicated section [here](nuget-packages.md).

For a more thorough example to use third-party libraries can be found [here](../tutorials/use-third-party-library.html#using-c-library).

# Analyzers and source generators

Source generators and analyzers are also supported. System provided assemblies can be added in `SystemAnalyzers` and external file references to `Analyzers` lists:
```cs
public override void Setup(BuildOptions options)
{
    base.Setup(options);

    options.ScriptingAPI.SystemAnalyzers.Add("Microsoft.Interop.ComInterfaceGenerator");

    // Note: the path is relative to the .build file itself
    options.ScriptingAPI.Analyzers.Add(Path.Combine(FolderPath, "..", "..", "Content", "CustomAnalyzer.dll"));
}
```
