| **Command** | **Description** |
|-------|------|
| `Audio.ActiveDevice` | Gets the active device. |
| `Audio.ActiveDeviceIndex` | The index of the active device. |
| `Audio.Devices` | The all audio devices. |
| `Audio.DopplerFactor` | Sets the doppler effect factor. Scale for source and listener velocities. Default is 1. |
| `Audio.EnableHRTF` | The preference to use HRTF audio (when available on platform). Default is true. |
| `Audio.MasterVolume` | The master volume applied to all the audio sources (normalized to range 0-1). |
| `Audio.Volume` | Gets the actual master volume (including all side effects and mute effectors). |
| `Engine.Crash` | Crashes the engine. Utility used to test crash reporting or game stability monitoring systems. |
| `Engine.Exit` | Exits the engine. |
| `Globals.BinariesFolder` | The game executable files location. |
| `Globals.CompanyName` | The company name (short name used for app data directory). |
| `Globals.EngineBuildNumber` | The engine build version. |
| `Globals.EngineContentFolder` | Engine content directory path (editor-only). |
| `Globals.EngineVersion` | The full engine version. |
| `Globals.MainThreadID` | Main Engine thread id. |
| `Globals.ProductLocalFolder` | The product local data directory. |
| `Globals.ProductName` | The short name of the product (can be `Flax Editor` or name of the game e.g. `My Space Shooter`). |
| `Globals.ProjectCacheFolder` | Project specific cache folder path (editor-only). |
| `Globals.ProjectContentFolder` | Project content directory path. |
| `Globals.ProjectFolder` | Directory that contains project |
| `Globals.ProjectSourceFolder` | Game source code directory path (editor-only). |
| `Globals.StartupFolder` | Main engine directory path. |
| `Globals.TemporaryFolder` | Temporary folder path. |
| `GPUDevice.DumpResources` | Dumps all GPU resources information to the log. |
| `Graphics.AAQuality` | Anti Aliasing quality setting. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). |
| `Graphics.AllowCSMBlending` | Enables cascades splits blending for directional light shadows. |
| `Graphics.GammaColorSpace` | Enables Gamma color space workflow (instead of Linear). Gamma color space defines colors with an applied a gamma curve (sRGB) so they are perceptually linear.  This makes sense when the output of the rendering represent final color values that will be presented to a non-HDR screen. |
| `Graphics.GICascadesBlending` | Enables cascades splits blending for Global Illumination. |
| `Graphics.GIQuality` | The Global Illumination quality. Controls the quality of the GI effect. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). |
| `Graphics.GlobalSDFQuality` | The Global SDF quality. Controls the volume texture resolution and amount of cascades to use. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). |
| `Graphics.PostProcessing.ColorGradingVolumeLUT` | Toggles between 2D and 3D LUT texture for Color Grading. |
| `Graphics.PostProcessSettings` | The default Post Process settings. Can be overriden by PostFxVolume on a level locally, per camera or for a whole map. |
| `Graphics.ShadowMapsQuality` | The shadow maps quality (textures resolution). Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). |
| `Graphics.Shadows.MinObjectPixelSize` | The minimum size in pixels of objects to cast shadows. Improves performance by skipping too small objects (eg. sub-pixel) from rendering into shadow maps. |
| `Graphics.ShadowsQuality` | The shadows quality. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). |
| `Graphics.ShadowUpdateRate` | The global scale for all shadow maps update rate. Can be used to slow down shadows rendering frequency on lower quality settings or low-end platforms. Default 1. |
| `Graphics.SpreadWorkload` | Debug utility to toggle graphics workloads amortization over several frames by systems such as shadows mapping, global illumination or surface atlas. Can be used to test performance in the worst-case scenario (eg. camera-cut). |
| `Graphics.SSAOQuality` | Screen Space Ambient Occlusion quality setting. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). |
| `Graphics.SSRQuality` | Screen Space Reflections quality setting. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). |
| `Graphics.TestValue` | Debug utility to control visual or rendering features during development. For example, can be used to branch different code paths in shaders for A/B testing (perf or quality). |
| `Graphics.UseVSync` | Enables rendering synchronization with the refresh rate of the display device to avoid "tearing" artifacts. |
| `Graphics.VolumetricFogQuality` | Volumetric Fog quality setting. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). |
| `Level.StreamingFrameBudget` | Fraction of the frame budget to limit time spent on levels streaming. For example, value of 0.3 means that 30% of frame time can be spent on levels loading within a single frame (eg. 0.3 at 60fps is 4.8ms budget). |
| `Level.TickEnabled` | True if game objects (actors and scripts) can receive a tick during engine Update/LateUpdate/FixedUpdate events. Can be used to temporarily disable gameplay logic updating. |
| `NetworkManager.Clients` | List of all clients: connecting, connected and disconnected. Empty on clients. |
| `NetworkManager.Frame` | Current network system frame number (incremented every tick). Can be used for frames counting in networking and replication. |
| `NetworkManager.GetClient` | Gets the network client for a given connection. Returns null if failed to find it. |
| `NetworkManager.GetClient` | Gets the network client for a given connection. Returns null if failed to find it. |
| `NetworkManager.IsClient` | Returns true if network is a client. |
| `NetworkManager.IsConnected` | Returns true if network is connected and online. |
| `NetworkManager.IsHost` | Returns true if network is a host (both client and server). |
| `NetworkManager.IsOffline` | Returns true if network is online or disconnected. |
| `NetworkManager.IsServer` | Returns true if network is a server. |
| `NetworkManager.LocalClient` | Local client, valid only when Network Manager is running in client or host mode (server doesn't have a client). |
| `NetworkManager.LocalClientId` | Local client identifier. Valid even on server that doesn't have LocalClient. |
| `NetworkManager.Mode` | Current manager mode. |
| `NetworkManager.NetworkFPS` | The target amount of the network logic updates per second (frequency of replication, events sending and network ticking). Use 0 to run every game update. |
| `NetworkManager.Peer` | Current network peer (low-level). |
| `NetworkManager.ServerClientId` | Server client identifier. Constant value of 0. |
| `NetworkManager.StartClient` | Starts the network in client mode. Returns true if failed (eg. invalid config). |
| `NetworkManager.StartHost` | Starts the network in host mode. Returns true if failed (eg. invalid config). |
| `NetworkManager.StartServer` | Starts the network in server mode. Returns true if failed (eg. invalid config). |
| `NetworkManager.State` | Current network connection state. |
| `NetworkManager.Stop` | Stops the network. |
| `NetworkReplicator.EnableLog` | Enables verbose logging of the networking runtime. Can be used to debug problems of missing RPC invoke or object replication issues. |
| `Physics.Gravity` | The current gravity force. |
| `ProfilerGPU.Dump` | Profiles next frame(s) rendering performance and dumps the results to the log (as a hierarchy structure). When using more than 1 frame, the results are averaged for more accurate profiling (especially for A/B testing). |
| `ProfilerGPU.Enabled` | True if GPU profiling is enabled, otherwise false to disable events collecting and GPU timer queries usage. Can be changed during rendering. |
| `ProfilerGPU.EventsEnabled` | True if GPU events are enabled (see GPUContext.EventBegin), otherwise false. Cannot be changed during rendering. |
| `ProfilerMemory.Dump` | Dumps the memory allocations stats (grouped). |
| `ProfilingTools.Enabled` | Controls the engine profiler (CPU, GPU, etc.) usage. |
| `Screen.CursorLock` | The cursor lock mode. |
| `Screen.CursorVisible` | The cursor visible flag. |
| `Screen.GameViewportToScreen` | Converts the game viewport position to the screen-space position. |
| `Screen.GameWindowMode` | The game window mode. |
| `Screen.IsFullscreen` | The fullscreen mode. |
| `Screen.MainWindow` | Gets the main window. |
| `Screen.ScreenToGameViewport` | Converts the screen-space position to the game viewport position. |
| `Screen.Size` | The window size (in screen-space, includes DPI scale). |
| `Screenshot.Capture` | Captures the specified render target contents and saves it to the file.  Remember that downloading data from the GPU may take a while so screenshot may be taken one or more frames later due to latency.  Staging textures are saved immediately. |
| `Streaming.Stats` | Gets streaming statistics. |
| `Time.DeltaTime` | Gets time in seconds it took to complete the last frame, Time.TimeScale dependent. |
| `Time.DrawFPS` | The target amount of the frames rendered per second (target game FPS). |
| `Time.GamePaused` | The value indicating whenever game logic is paused (physics, script updates, etc.). |
| `Time.GameTime` | Gets time at the beginning of this frame. This is the time in seconds since the start of the game. |
| `Time.PhysicsFPS` | The target amount of the physics simulation updates per second (also fixed updates frequency). |
| `Time.SetFixedDeltaTime` | Sets the fixed FPS for game logic updates (draw and update). |
| `Time.StartupTime` | The time at which the game started (UTC local). |
| `Time.Synchronize` | Synchronizes update, fixed update and draw. Resets any pending deltas for fresh ticking in sync. |
| `Time.TimeScale` | The game time scale factor. Default is 1. |
| `Time.TimeSinceStartup` | Gets the time since startup in seconds (unscaled). |
| `Time.UnscaledDeltaTime` | Gets timeScale-independent time in seconds it took to complete the last frame. |
| `Time.UnscaledGameTime` | Gets timeScale-independent time at the beginning of this frame. This is the time in seconds since the start of the game. |
| `Time.UpdateFPS` | The target amount of the game logic updates per second (script updates frequency). |
