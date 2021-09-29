# Game and Engine Flow

Flax Engine contains multiple advanced systems and can be extended in many areas. This documentation page explains the engine initialization process and general game flow.

## Scripting Flow

Game scripts or plugins code is executed when all engine services are ready and initialized.

* **Scripts** - initialized during scene initialization, during loading. See [script events execution order](../../scripting/events.md).
* **Game Plugins** - initialized when game starts but always before any scene is loaded.
* **Editor Plugins** - initialized when editer is opened.

## Engine Flow

The list below shows the flow of the engine with all services initialization order. When working with [custom engine](custom-engine.md) the most important parts of the engine core logic are inside file `Source\Engine\Engine\Engine.cpp`. To learn more look into the engine log as well.

1. Platform initialization
2. Project info loading
3. Logging initialization
4. **Engine services initialization**
4.1. Objects Removal Service
4.2. Thread Pool
4.3. Time
4.4. Content Storage
4.5. Job System
4.6. Font Manager
4.7. Content
4.8. Content Loading Manager
4.9. Localization
4.10. Assets Importing Manager *(editor-only)*
4.11. Assets Exporting Manager *(editor-only)*
4.12. Shader Cache Manager *(editor-only)*
4.13. Shaders Compilation Service *(editor-only)*
4.14. Debug Draw *(editor-only)*
4.15. Game Settings
4.16. Input
4.17. Audio
4.18. Graphics
4.19. Windows Manager
4.20. Scripting
4.21. Animations
4.22. Viewport Icons Renderer *(editor-only)*
4.23. Scripts Builder *(editor-only)*
4.24. Profiling Tools *(editor-only)*
4.25. Physics
4.26. Editor Analytics *(editor-only)*
4.27. Game Cooker *(editor-only)*
4.28. Custom Editors Util *(editor-only)*
4.29. Render2D
4.30. Renderer
4.31. Scene Manager
4.32. Terrain Manager
4.33. Atmosphere Pre Compute
4.34. Navigation
4.35. Particle Manager
4.36. Probes Renderer *(editor-only)*
4.37. ShadowsOfMordor Builder *(editor-only)*
4.38. CSG Builder *(editor-only)*
4.39. Streaming
4.40. Prefab Manager
4.41. Screen
4.42. Plugin Manager
5. Application initialization *(editor or game)*
6. Main window creation
7. **Main loop**
7.1. Idle if unatended
7.2. Sleep if app paused *(platform specific)*
7.3. Update
7.4. Fixed Update
7.5. Draw
8. **Exit**
8.1. Before Exit event
8.2. Engine services disposing *(reversed order)*
8.3. Exit.
