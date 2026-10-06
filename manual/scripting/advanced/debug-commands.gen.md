| **Command** | **Description** |
|-------|------|
| `Audio.ActiveDevice` | Gets the active device. Value type: AudioDevice |
| `Audio.ActiveDeviceIndex` | The index of the active device. Returns -1 if set to system default mode. Value type: Int32 |
| `Audio.ActiveDeviceResolvedIndex` | Gets the resolved index in Devices array of the device currently playing (resolves system default mode to the actual device index). Value type: Int32 |
| `Audio.Devices` | The all audio devices. Value type: AudioDevice[] |
| `Audio.DopplerFactor` | Sets the doppler effect factor. Scale for source and listener velocities. Default is 1. Value type: Float |
| `Audio.EnableHRTF` | The preference to use HRTF audio (when available on platform). Default is true. Value type: Boolean |
| `Audio.MasterVolume` | The master volume applied to all the audio sources (normalized to range 0-1). Value type: Float |
| `Audio.Volume` | Gets the actual master volume (including all side effects and mute effectors). Value type: Float |
| `Engine.Crash` | Crashes the engine. Utility used to test crash reporting or game stability monitoring systems. Parameters:   error: enum FatalErrorType (None, Unknown, Exception, Assertion, OutOfMemory, GPUCrash, GPUHang, GPUOutOfMemory) |
| `Engine.Exit` | Exits the engine. Parameters:   exitCode: Int32   error: enum FatalErrorType (None, Unknown, Exception, Assertion, OutOfMemory, GPUCrash, GPUHang, GPUOutOfMemory) |
| `Globals.BinariesFolder` | The game executable files location. Value type: String |
| `Globals.CompanyName` | The company name (short name used for app data directory). Value type: String |
| `Globals.EngineBuildNumber` | The engine build version. Value type: Int32 |
| `Globals.EngineContentFolder` | Engine content directory path (editor-only). Value type: String |
| `Globals.EngineVersion` | The full engine version. Value type: String |
| `Globals.MainThreadID` | Main Engine thread id. Value type: UInt64 |
| `Globals.ProductLocalFolder` | The product local data directory. Value type: String |
| `Globals.ProductName` | The short name of the product (can be `Flax Editor` or name of the game e.g. `My Space Shooter`). Value type: String |
| `Globals.ProjectCacheFolder` | Project specific cache folder path (editor-only). Value type: String |
| `Globals.ProjectContentFolder` | Project content directory path. Value type: String |
| `Globals.ProjectFolder` | Directory that contains project Value type: String |
| `Globals.ProjectSourceFolder` | Game source code directory path (editor-only). Value type: String |
| `Globals.StartupFolder` | Main engine directory path. Value type: String |
| `Globals.TemporaryFolder` | Temporary folder path. Value type: String |
| `GPUDevice.DumpResources` | Dumps all GPU resources information to the log. |
| `Graphics.AAQuality` | Anti Aliasing quality setting. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). Value type: enum Quality (Low, Medium, High, Ultra, MAX) |
| `Graphics.AllowCSMBlending` | Enables cascades splits blending for directional light shadows. Value type: Boolean |
| `Graphics.GammaColorSpace` | Enables Gamma color space workflow (instead of Linear). Gamma color space defines colors with an applied a gamma curve (sRGB) so they are perceptually linear.  This makes sense when the output of the rendering represent final color values that will be presented to a non-HDR screen. Value type: Boolean |
| `Graphics.GI.Dump` | Dumps Global Illumination rendering info to the log (the next frame). Can be used to inspect DDGI, Global Surface Atlas and Global SDF memory and usage (for optimization). Prints info about the number of probes, cascades and draw state. |
| `Graphics.GICascadesBlending` | Enables cascades splits blending for Global Illumination. Value type: Boolean |
| `Graphics.GIProbesSpacing` | The Global Illumination probes spacing distance (in world units). Defines the quality of the GI resolution. Adjust to 200-500 to improve performance and lower frequency GI data. Value type: Float |
| `Graphics.GIQuality` | The Global Illumination quality. Controls the quality of the GI effect. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). Value type: enum Quality (Low, Medium, High, Ultra, MAX) |
| `Graphics.GlobalSDFQuality` | The Global SDF quality. Controls the volume texture resolution and amount of cascades to use. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). Value type: enum Quality (Low, Medium, High, Ultra, MAX) |
| `Graphics.GlobalSurfaceAtlasResolution` | The Global Surface Atlas resolution. Adjust it if atlas `flickers` due to overflow (eg. to 4096). Value type: Int32 |
| `Graphics.MotionVectors.MinObjectScreenSize` | The minimum screen size of objects to draw motion vectors. Improves performance by skipping too small objects (eg. sub-pixel) from rendering motion vectors. Value type: Float |
| `Graphics.PostProcessing.ColorGradingVolumeLUT` | Toggles between 2D and 3D LUT texture for Color Grading. Value type: Boolean |
| `Graphics.PostProcessSettings` | The default Post Process settings. Can be overriden by PostFxVolume on a level locally, per camera or for a whole map. Value type: PostProcessSettings |
| `Graphics.ShadowMapsQuality` | The shadow maps quality (textures resolution). Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). Value type: enum Quality (Low, Medium, High, Ultra, MAX) |
| `Graphics.Shadows.Dump` | Dumps active shadow projections info to the log (the next frame). Can be used to inspect what lights are casting shadows (for optimization). |
| `Graphics.Shadows.MinObjectPixelSize` | The minimum size in pixels of objects to cast shadows. Improves performance by skipping too small objects (eg. sub-pixel) from rendering into shadow maps. Value type: Float |
| `Graphics.ShadowsQuality` | The shadows filtering quality (sampling). Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). Value type: enum Quality (Low, Medium, High, Ultra, MAX) |
| `Graphics.ShadowUpdateRate` | The global scale for all shadow maps update rate. Can be used to slow down shadows rendering frequency on lower quality settings or low-end platforms. Default 1. Value type: Float |
| `Graphics.SpreadWorkload` | Debug utility to toggle graphics workloads amortization over several frames by systems such as shadows mapping, global illumination or surface atlas. Can be used to test performance in the worst-case scenario (eg. camera-cut). Value type: Boolean |
| `Graphics.SSAOQuality` | Screen Space Ambient Occlusion quality setting. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). Value type: enum Quality (Low, Medium, High, Ultra, MAX) |
| `Graphics.SSRQuality` | Screen Space Reflections quality setting. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). Value type: enum Quality (Low, Medium, High, Ultra, MAX) |
| `Graphics.TestValue` | Debug utility to control visual or rendering features during development. For example, can be used to branch different code paths in shaders for A/B testing (perf or quality). Value type: Float |
| `Graphics.UseVSync` | Enables rendering synchronization with the refresh rate of the display device to avoid "tearing" artifacts. Value type: Boolean |
| `Graphics.VolumetricFogQuality` | Volumetric Fog quality setting. Available values are: Low, Medium, High, Ultra (or 0, 1, 2, 3). Value type: enum Quality (Low, Medium, High, Ultra, MAX) |
| `Level.StreamingFrameBudget` | Fraction of the frame budget to limit time spent on levels streaming. For example, value of 0.3 means that 30% of frame time can be spent on levels loading within a single frame (eg. 0.3 at 60fps is 4.8ms budget). Value type: Float |
| `Level.TickEnabled` | True if game objects (actors and scripts) can receive a tick during engine Update/LateUpdate/FixedUpdate events. Can be used to temporarily disable gameplay logic updating. Value type: Boolean |
| `NetworkManager.Clients` | List of all clients: connecting, connected and disconnected. Empty on clients. Value type: NetworkClient[] |
| `NetworkManager.Frame` | Current network system frame number (incremented every tick). Can be used for frames counting in networking and replication. Value type: UInt32 |
| `NetworkManager.IsClient` | Returns true if network is a client. Value type: Boolean |
| `NetworkManager.IsConnected` | Returns true if network is connected and online. Value type: Boolean |
| `NetworkManager.IsHost` | Returns true if network is a host (both client and server). Value type: Boolean |
| `NetworkManager.IsOffline` | Returns true if network is online or disconnected. Value type: Boolean |
| `NetworkManager.IsServer` | Returns true if network is a server. Value type: Boolean |
| `NetworkManager.LocalClient` | Local client, valid only when Network Manager is running in client or host mode (server doesn't have a client). Value type: NetworkClient |
| `NetworkManager.LocalClientId` | Local client identifier. Valid even on server that doesn't have LocalClient. Value type: UInt32 |
| `NetworkManager.Mode` | Current manager mode. Value type: enum NetworkManagerMode (Offline, Server, Client, Host) |
| `NetworkManager.NetworkFPS` | The target amount of the network logic updates per second (frequency of replication, events sending and network ticking). Use 0 to run every game update. Value type: Float |
| `NetworkManager.Peer` | Current network peer (low-level). Value type: NetworkPeer |
| `NetworkManager.ServerClientId` | Server client identifier. Constant value of 0. Value type: UInt32 |
| `NetworkManager.StartClient` | Starts the network in client mode. Returns true if failed (eg. invalid config). Value type: Boolean |
| `NetworkManager.StartHost` | Starts the network in host mode. Returns true if failed (eg. invalid config). Value type: Boolean |
| `NetworkManager.StartServer` | Starts the network in server mode. Returns true if failed (eg. invalid config). Value type: Boolean |
| `NetworkManager.State` | Current network connection state. Value type: enum NetworkConnectionState (Offline, Connecting, Connected, Disconnecting, Disconnected) |
| `NetworkManager.Stop` | Stops the network. |
| `NetworkReplicator.EnableLog` | Enables verbose logging of the networking runtime. Can be used to debug problems of missing RPC invoke or object replication issues. Value type: Boolean |
| `Physics.Gravity` | The current gravity force. Value type: Vector3 |
| `ProfilerGPU.Dump` | Profiles next frame(s) rendering performance and dumps the results to the log (as a hierarchy structure). When using more than 1 frame, the results are averaged for more accurate profiling (especially for A/B testing). Parameters:   frames: Int32 |
| `ProfilerGPU.Enabled` | True if GPU profiling is enabled, otherwise false to disable events collecting and GPU timer queries usage. Can be changed during rendering. Value type: Boolean |
| `ProfilerGPU.EventsEnabled` | True if GPU events are enabled (see GPUContext.EventBegin), otherwise false. Cannot be changed during rendering. Value type: Boolean |
| `ProfilerMemory.Dump` | Dumps the memory allocations stats (grouped). Parameters:   options: String |
| `ProfilingTools.Enabled` | Controls the engine profiler (CPU, GPU, etc.) usage. Value type: Boolean |
| `Screen.CursorLock` | The cursor lock mode. Value type: enum CursorLockMode (None, Locked, Clipped) |
| `Screen.CursorVisible` | The cursor visible flag. Value type: Boolean |
| `Screen.GameWindowMode` | The game window mode. Value type: enum GameWindowMode (Windowed, Fullscreen, Borderless, FullscreenBorderless) |
| `Screen.IsFullscreen` | The fullscreen mode. Value type: Boolean |
| `Screen.MainWindow` | Gets the main window. Value type: Window |
| `Screen.Size` | The window size (in screen-space, includes DPI scale). Value type: Float2 |
| `Screenshot.Capture` | Captures the specified render target contents and saves it to the file.  Remember that downloading data from the GPU may take a while so screenshot may be taken one or more frames later due to latency.  Staging textures are saved immediately. Parameters:   target: GPUTexture   path: String |
| `Streaming.Stats` | Gets streaming statistics. Value type: StreamingStats |
| `Time.DeltaTime` | Gets time in seconds it took to complete the last frame, Time.TimeScale dependent. Value type: Float |
| `Time.DrawFPS` | The target amount of the frames rendered per second (target game FPS). Value type: Float |
| `Time.GamePaused` | The value indicating whenever game logic is paused (physics, script updates, etc.). Value type: Boolean |
| `Time.GameTime` | Gets time at the beginning of this frame. This is the time in seconds since the start of the game. Value type: Float |
| `Time.PhysicsFPS` | The target amount of the physics simulation updates per second (also fixed updates frequency). Value type: Float |
| `Time.SetFixedDeltaTime` | Sets the fixed FPS for game logic updates (draw and update). Parameters:   enable: Boolean   value: Float |
| `Time.StartupTime` | The time at which the game started (UTC local). Value type: DateTime |
| `Time.Synchronize` | Synchronizes update, fixed update and draw. Resets any pending deltas for fresh ticking in sync. Parameters:   resetTotalTime: Boolean |
| `Time.TimeScale` | The game time scale factor. Default is 1. Value type: Float |
| `Time.TimeSinceStartup` | Gets the time since startup in seconds (unscaled). Value type: Float |
| `Time.UnscaledDeltaTime` | Gets timeScale-independent time in seconds it took to complete the last frame. Value type: Float |
| `Time.UnscaledGameTime` | Gets timeScale-independent time at the beginning of this frame. This is the time in seconds since the start of the game. Value type: Float |
| `Time.UpdateFPS` | The target amount of the game logic updates per second (script updates frequency). Value type: Float |
