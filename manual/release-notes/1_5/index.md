# Flax 1.5 release notes

## Highlights

### Feature A

Text.

## Migration Guide

### PostProcessEffect changes

For this update, we've added support for implementing `PostProcessEffect` in C++ scripts - previously it was C#-only feature. For this change, both `PostProcessEffect` and `SceneRenderTask` API has been slightly modified:
* `Location`/`UseSingleTarget`/`Order` getters has been changed into fields which can be adjusted from code (in constructor or at runtime).
* `CanRender` getter has been changed into `CanRender()` virtual method which can be overridden to provide a custom checks for PostFx render availability.
* `RemoveCustomPostFx` and `GlobalCustomPostFx` lists have been more to C++ thus use `AddCustomPostFx`/`RemoveCustomPostFx` and `AddGlobalCustomPostFx`/`RemoveGlobalCustomPostFx` to extend the rendering with custom effects. `PostProcessEffect` scripts attached to the camera actor will remain working as before.
We've updated docs, code examples, and all official plugins to reflect those changes.

## Changelog

### Version 1.5.XXX - Day Month 2022

Contributors: XXX

PRs merged: XXX

* 
