# Flax 1.6 release notes

## Highlights

### .NET 7

TODO

### PhysX 5

TODO

### iOS Support

### macOS arm64 Support

TODO

## Migration Guide

### From Mono to .NET 7

C# scripting runtime and tools have been updated to use the latest .NET 7 SDK on all platforms (both desktop, mobile, and consoles). It brings massive performance and stability benefits but might require some users to update their code and tools. Notable changes:
* Flax Editor doesn't contain C# runtime nor C# compiler anymore but depends on system-installed .NET SDK
* Desktop platforms (Windows, macOS, Linux) use CoreCLR runtime with new JIT and GC
* Mobile and Consoles use new [mono](https://github.com/dotnet/runtime/tree/main/src/mono) with Mono AOT but with the latest class library (feature compatible with CoreCLR)
* Visual Studio 2019 (and older) are unsupported by .NET 7 SDK (still can be used for programming but with less tooling)
* [Flax.VS](https://marketplace.visualstudio.com/items?itemName=Flax.FlaxVS) extension is not required anymore for C# debugging in Visual Studio - VS 2022 has inbuilt .NET 7 debugger
* Android platform requires Android .NET Workload installation via `dotnet workload install android`
* Old Mono runtime hosting code is still available in Flax codebase but is disabled and will be removed in future
* If you're using `Regex` in your code then add `options.ScriptingAPI.SystemReferences.Add("System.Text.RegularExpressions");` to `Game.Build.cs` to properly reference System Library (not used by default now)

We've updated docs, code examples, and all official plugins to reflect those changes.

## Changelog

### Version 1.6.XXX - XX XXXX 2023

Contributors: XXX

PRs merged: XXX

* 
