# Flax 0.1 release notes

## Highlights

### Decals

![Declas](media/decals.png)

We've added a new material type: **Decal** and new **Decal Actor** which can be used to draw decal materials on top of the surface of the scene geometry. It's a very common and easy way to add special effects like blood drops, footsteps or more. Draw calls rendering is very optimized and fits needs of most of the games. To learn more about decals see the related documentation [here](../../graphics/decals/index.md).

### C# 7.2 support

Now you can use the newest **C# 7.2** features including:
* local functions
* binary literals
* digit separators
* pattern matching
* `out` variables
* expression bodied members
* `ref readonly`
* `private protected`
* and more...

The current Flax version includes [Roslyn](https://github.com/dotnet/roslyn) compiler and supports using the newest C# language version in your scripts.

## Changelog

### Version 0.1.6156 - 1 June 2018

* Added **Decals** support
* Added **C# 7.2** support
* Upgrade to **Mono 5.12**
* Added SGen for C# Garbage Collection (multi-threaded GC)
* Added support for catching StackOverflowException
* Added Decal actor
* Added Material types: Decal and GUI
* Added selecting the material preview mesh (cube, sphere, plane, cylinder or cone)
* Added `atan2` function to materials
* Improve initial asset registry building (faster files discovery)
* Improve managed objects performance (don't pin persistent managed objects)
* Optimize scenes reload on scripts reload (keep data cached in memory)
* Optimize draw calls sorting performance (for 2k+ draw calls)
* Support `Position Offset` in layered materials
* Support sampling material layer that is using material layer input
* Support copy/paste files and folders in the Content Window
* Support calling Update/LateUpdate/FixedUpdate in editor for scripts marked with ExecuteInEditModeAttribute
* Improve materials compilation
* Optimize DirectX 11 backend state changes
* Swap Roughness with AO in GBuffer
* Use `CreateDXGIFactory1` on DirectX 11 backend (min Win7 support)
* Added scripts define `FLAX_X_Y_Z` for scripting to include patches
* Added tooltip to Visject Surface graph nodes with the node type
* Added C# API to copy folders and files with a system clipboard
* Fix Combobox text clipping
* Fix Character Controller collisions filter
* Fix many crashes on scripts reload in editor
* Fix C# various internal structures serialization
* Fix scriptis builder events sending
* Stability improvements related to meshes rendering
* Minor fixes

### Version 0.1.6155 - 20 May 2018

* Added feature to center the imported model geometry
* Added feature to copy/paste/cut/duplicate nodes in Material and Anim Graph editors
* Added support for range selection in Content Window with Shift key
* Changing Actor.Parent does not preserve the object world transformation (use Actor.SetParent(value, true) to keep it, otherwise local transform will be unchanged)
* Use editor viewport grid for the objects placement
* Implement ExecuteInEditModeAttribute
* Script events in editor (during editing) are now executed only for types with [ExecuteInEditMode] attribute assigned
* Support importing folders with contents
* Improve Env Probes usage with Auto Bake option set
* Improve startup on Windows 7 systems
* Improve spawning Visject Surface nodes via drag and drop
* Use First Person camera in the Collision Data asset editor
* Fix local transformation issue when using undo after reparenting actor
* Fix mouse pos when no capture
* Fixes for importing various model files
* Fixes for scripts that have base class other than Scritpt type (eg. Actor)
* Fix crash when updating the Collision Data asset
* Fix Animated Model update when offscreen (better sync and stable looping)
* Fix RayCast with layer specified
* Fix ShadowsMode deserialization for the meshes
* Fix black screen issue in a builded game
* Fix error when trying to create a new folder in a project root folder
* Fix Game Cooker progress reporting to be more thread-safe
* Serialize Sky.SunDiscScale
* Fix sampling textures in material’s vertex shader
* Fix initial OpenAL warning
* Fix error when dragging and dropping actors in tree structure

### Version 0.1.6154 - 15 May 2018

Initial release. We're getting started...
