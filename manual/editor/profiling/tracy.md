# Tracy Profiler

**Tracy** is C++ frame profiler and can be downloaded [here](https://github.com/wolfpld/tracy/releases).

Tracy supports profiling CPU, threading, memory, locks, context switches, and more. It's integrated into Flax and can be used to profile both game and engine in Editor or in cooked build (Debug or Development configurations).

> [!TIP]
> Profiling Editor with Tracy after scripting hot-reload is not supported. Can be optionally enabled in custom engine build with `PROFILE_CPU_USE_TRANSIENT_DATA` set to `1` (see `ProfilerCPU.h`).

## Setup

![Tracy Profiler Flax Engine](media/tracy-connected.png)

Download latest Tracy from [Github releases](https://github.com/wolfpld/tracy/releases), extract `Tracy-<version>.7z` file and run **Tracy.exe**. It will show active Flax. *Double-click* to connect and start collecting profiling data.

![Tracy Connect](media/tracy-connect.png)

> [!Tip]
> Use *Tracy.pdf* manual to learn more about profiling and performance measurements.

## Profiler integration

Use Flax API to inject profile blocks:

# [C#](#tab/code-csharp)
```cs
Profiler.BeginEvent("MyFunc");
// do some stuff
Profiler.EndEvent();
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Profiler/ProfilerCPU.h"

PROFILE_CPU();
// do some stuff
```
***

## Automated data collection

![Tracy Connect](media/tracy-full-profile.png)

Tracy supports automatic instrumentation of the profiled code without injecting the profiler sections/macros. To do so run Flax with admin rights (privilege elevation). In this mode, Tracy will also capture the CPU cores usage by other processes and will allow for more complex application profiling.

## Memory Profiling

![Tracy Profiler Flax Engine](media/tracy-memory-profiling.png)

Flax automatically captures the callstack for memory allocations and frees. This can be used in Tracy profiler app to analyze memory usage.

## GPU Profiling

![Tracy GPU Profiler Flax Engine](media/tracy-gpu.png)

D3D11, D3D12 and Vulkan graphics APIs are supported in GPU performance timeline. Integration automatically inserts timer queries to calculate duration of various events. Additionally Tracy provides functionality to show CPU section that corresponds to the given GPU work event. This can be used to profile rendering performance on connected devices.
