# Profiler

The **Profiler** window provides various ways of measuring game performance and helps the optimization process. It can be used to collect data about game performance right in the Editor.

## Interface

![Profiler Interface](media/profiler-layout.png)

Profiler window is divided into 3 parts:
* Toolbar
* Sections list
* Details panel

## Sections

### Overall

The general profiling mode with major game performance charts and stats.

### CPU

The CPU performance profiling mode.

To add code section to be included in profile blocks use the following code:

# [C#](#tab/code-csharp)
```cs
Profiler.BeginEvent("MyFunction");
// do something
Profiler.EndEvent();
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Profiler/Profiler.h"

PROFILE_CPU_NAMED("MyFunction"); // or PROFILE_CPU to use auto-name of the current function
// do something
```
***

### GPU

The GPU performance profiling mode.

To add code section to be included in profile blocks use the following code:

# [C#](#tab/code-csharp)
```cs
Profiler.BeginEventGPU("MyFunction");
// do something on GPU with GPUContext
Profiler.EndEventGPU();
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Profiler/Profiler.h"

PROFILE_GPU("MyFunction"); // or PROFILE_GPU_CPU to inject both CPU and GPU profile event
// do something on GPU with GPUContext
```
***

### Memory

The memory profiling mode focused on breaking down system memory allocations. This includes separate stats for native memory allocation and managed C# allocations.

### Network

The network data transfer send/receive charts over game time.

