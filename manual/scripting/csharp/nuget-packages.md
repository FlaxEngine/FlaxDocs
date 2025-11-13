# Nuget Packages

Flax.Build allows using Nuget Packages.

To add a Nuget Package, open your build.cs module and add code that is similar to the following in the `Setup` method. Flax will automatically download the Nuget package if needed.

```cs
public override void Setup(BuildOptions options)
{
    base.Setup(options);

    options.NugetPackages.Add("<nuget package name>", "<nuget package version>", "<framework version to use>")
}
```

Once the script files are regenerated, the nuget package will be available to use in the module.