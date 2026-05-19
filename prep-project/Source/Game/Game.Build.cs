using Flax.Build;
using Flax.Build.NativeCpp;

public class Game : GameModule
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // C#-only scripting
        BuildNativeCode = false;
    }

    /// <inheritdoc />
    public override void Setup(BuildOptions options)
    {
        base.Setup(options);

        options.ScriptingAPI.IgnoreMissingDocumentationWarnings = true;
    }
}
