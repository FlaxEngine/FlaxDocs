# Scripting restrictions

Flax tries to implement all the engine features and scripting APIs across all supported platforms. However, some platforms have permanent restrictions. This page helps with understanding and dealing with possible cross-platform limitations.

## Not supported features

* `Debugger.Break()`

## Not supported APIs

- System.Collections.Immutable.dll
- System.Design.dll
- System.Drawing.Design.dll
- System.Reflection.Metadata.dll
- System.Web.Extensions.Design.dll

## Static variables in editor

Static variables may behave differently when running the scripts in editor compared to running the cooked game. The static variables are usually initialized when the scripting assemblies are loaded and used for the first time, but Flax Editor may not always reload the assemblies between runs (unless recompilation is needed), so the values from previous runs are retained. There are many ways to work around this by using [Game Plugins](../plugins/index.md) to manage state or subscribing to `FlaxEditor.Editor.Instance.PlayModeBeginning` event which is called right before entering play mode.

## Ahead-of-time compile

Ahead-of-time (**AOT**) compile is a technique used to precompile all the managed code during game building process instead of using just-in-time (**JIT**) compilation on the target device. That's because some platforms do not allow runtime code generation. In most cases this has no effect on game scripting but in a few specific cases, AOT platforms require additional consideration.

Because code generation is disabled in AOT mode (scripting backend throws an exception) the following features are not supported:
* No dynamic loading (eg. `Assembly.LoadFile`).
* No runtime code generation (eg. `System.Reflection.Emit`).
* Generic virtual methods have restrictions.
* When using generic types you need to declare generic attributes types to precompile them.
* C# debugger is not available - but debug symbols are available for native debugger (eg. full Stack Traces).

When compiling with AOT mode enabled C# scripts have a preprocessor defined `USE_AOT`. It can be used to redirect different API usage depending o the target platform build.

Platforms that use AOT:
* Xbox One
* Xbox Scarlett
* PlayStation 4
* PlayStation 5
* Switch
* iOS
