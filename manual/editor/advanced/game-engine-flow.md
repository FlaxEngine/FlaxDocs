# Game and Engine Flow

Flax Engine contains multiple advanced systems and can be extended in many areas. This documentation page explains the engine initialization process and general game flow.

## Scripting Flow

Game scripts or plugins code is executed when all engine services are ready and initialized.

* **Scripts** - initialized during scene initialization, during loading. See [script events execution order](../../scripting/events.md).
* **Game Plugins** - initialized when game starts but always before any scene is loaded.
* **Editor Plugins** - initialized when editor is opened.

## Engine Flow

The list below shows the flow of the engine with all services initialization order. When working with [custom engine](custom-engine.md) the most important parts of the engine core logic are inside file `Source\Engine\Engine\Engine.cpp`. To learn more look into the engine log as well.

* Platform initialization
* Project info loading
* Logging initialization
* **Engine services initialization**
  * Objects Removal Service
  * Thread Pool
  * Time
  * Content Storage
  * Job System
  * Font Manager
  * Content
  * Content Loading Manager
  * Localization
  * Assets Importing Manager *(editor-only)*
  * Assets Exporting Manager *(editor-only)*
  * Shader Cache Manager *(editor-only)*
  * Shaders Compilation Service *(editor-only)*
  * Debug Draw *(editor-only)*
  * Game Settings
  * Input
  * Audio
  * Graphics
  * Windows Manager
  * Scripting
  * Animations
  * Viewport Icons Renderer *(editor-only)*
  * Scripts Builder *(editor-only)*
  * Profiling Tools *(editor-only)*
  * Physics
  * Editor Analytics *(editor-only)*
  * Game Cooker *(editor-only)*
  * Custom Editors Util *(editor-only)*
  * Render2D
  * Renderer
  * Scene Manager
  * Terrain Manager
  * Atmosphere Pre Compute
  * Navigation
  * Particle Manager
  * Probes Renderer *(editor-only)*
  * ShadowsOfMordor Builder *(editor-only)*
  * CSG Builder *(editor-only)*
  * Streaming
  * Prefab Manager
  * Screen
  * Plugin Manager
* Application initialization *(editor or game)*
* Main window creation
* **Main loop**
  * Idle if unattended
  * Sleep if app paused *(platform specific)*
  * Update
  * Fixed Update
  * Draw
* **Exit**
  * Before Exit event
  * Engine services disposing *(reversed order)*
  * Exit.
