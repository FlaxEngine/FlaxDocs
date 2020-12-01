# Plugins

Flax.Build allows to extend it by using custom **Plugins**. Each plugin can deliver custom build system tasks, platform integration, scripting language support, or code IDE support.

To create a plugin simply add build script file somewhere in the `Source` folder of your project (`<name>.Build.cs`). Then write a class that inherits from `Flax.Build.Plugin` as follows:

```cs
using Flax.Build;

class MyPlugin : Plugin
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Here you can implement custom logic...
        Log.Info("Hello from plugin!");
    }
}
```

Plugins are initialized before any build/clean/projects actions so you can use them to register custom logic into the build tool. Follow Flax.Build code docuemntation to learn more. As an example, Visual Scripting integration into the engine is using **VisualScriptingPlugin** to inject custom virtual methods wrappers code.
