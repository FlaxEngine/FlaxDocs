# Debugging Tools

## In this section

* [Profiler](../../editor/profiling/index.md)
* [Debug View](debug-view.md)
* [View Flags](view-flags.md)

## Test Value

When developing shaders, new rendering techniques, VFX or materials, it's often useful to perform A/B testing of different code paths in a shader or rendering pipeline. To do it, engine contains `Graphics.TestValue` command value as debug utility to control visual or rendering features during development. For example, can be used to branch different code paths in shaders for A/B testing (perf or quality). The value of it can be changed via console or from code (even in non-Debug builds).

## RenderDoc

![RenderDoc with Flax Engine](media/render-doc.png)

[RenderDoc](https://renderdoc.org/) is free MIT licensed stand-alone graphics debugger that allows quick and easy single-frame capture and detailed introspection. Launch editor with `-shaderdebug` command line to enable debugging data generation for shaders without shader compiler optimizations. Use `-shaderprofile` to run shaders with all optimizations but additional data generated for advanced performance profiling (works in non-Release game builds too).

## Profiler

![GPU Profiler](../../editor/profiling/media/gpu-dump-command.png)

Graphics profiling can be done via external tools or right inside the engine via [Profiler](../../editor/profiling/profiler.md) or `ProfilerGPU.Dump` command. It profiles next frame(s) rendering performance and dumps the results to the log (as a hierarchy structure). When using more than 1 frame, the results are averaged for more accurate profiling (especially for A/B testing).
