# Custom engine build

This documentation section covers the usage of the custom engine builds. This includes compiling, distribution, and running custom editor binaries. As a requirement, the engine source code access is needed.

## Build Tool

Flax contains an in-build utility set called **Flax.Build** which is a complete build system written in C#. It supports:
* compiling and linking of engine, game and tools projects
* downloading and pre-building engine dependencies
* updating 3rd Party libraries
* generating project files
* deploying engine
* generating C# bindings for native code.

For advanced engine customizations or deep integration of engine and game tools please refer to Flax.Build sources located under `Source\Tools\Flax.Build` and/or use `Binaries\Tools\Flax.Build.exe -help` to learn more about usage. Engine repository contains useful scripts that are wrappers against the build tool and automatically compile its sources.

To learn more about build tool and build scripts see the related documentation page [here](../flax-build/index.md).

## Compiling

To learn how to build editor from source see **README.md** documentation file located in the root of the repository. Under section *Windows*/*Linux* basic steps are described as well as requirements.

You can use *Flax.Build* for automated editor building with a custom engine for your team members. In that case, the distribution flow is similar to binaries distributed via Flax Store except the engine is located and installed manually. To use it further follow the Engine Registration and Engine Nickname sections.

## Engine Registration

**Flax Launcher** manages a small registry of installed engine versions on a system. When installing or removing the engine from Flax Store it gets updated. To use custom engine build from any location on a drive use **RegisterEngineLocation.bat** script (engine repo root). It will register the engine location so the engine build can be used to open projects via Flax Launcher (or shell integration).

## Engine Nickname

When working with custom engine build (eg. in-house fork of the Flax) some team members might have installed other versions of Flax. To ensure that the game project is always opened with proper engine version your team can use **Engine Nickname** feature. It's a user-friendly nickname for the engine installation to use when opening the project. It can be used to open a game project with a custom engine distributed for team members. This value must be the same in engine and game projects to be paired. Then Flax Launcher will pick the matching engine build when opening a project.

To use it simply add `EngineNickname` property to both `Flax.flaxproj` and `<game>.flaxproj` to associate project with an engine.
```json
...
	"EngineNickname": "our-cool-flax-engine",
...
```

After that Flax Launcher will also display engine nickname so it can be recognized in UI.

