# Run code on module load

The most common way to inject custom features to game or engine is via plugins but you can also run custom chunks of code when code assembly gets loaded by the engine:

# [C#](#tab/code-csharp)
```cs
// Use ModuleInitializer attribute on static class - every static, void and parameterless method will be invoked after C# module gets loaded.

using FlaxEngine;

[ModuleInitializer]
static partial class Initializer
{
    static void Init()
    {
        Debug.Log("Hello!");
    }
}
```
# [C++](#tab/code-cpp)
```cpp
// Use static variable which constructor will be called when C++ module gets loaded.

#include "Engine/Core/Log.h"

struct Initializer
{
    Initializer()
    {
        LOG(Info, "Helllo!");
    }
};

Initializer Init;
```
***
