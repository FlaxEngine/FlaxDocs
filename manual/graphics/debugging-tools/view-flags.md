# View Flags

**View Flags** are used to enable or disable various rendering features. This can be useful when debugging the graphics or when tweaking the graphics rendering for the game.

Every viewport in Editor has options to configure its rendering flags using **View -> View Flags** as shown on the picture below.

![View Flags](media/view-flags.png)

The full list of options and the documentation is available [here](https://docs.flaxengine.com/api/FlaxEngine.ViewFlags.html).

You can also adjust those options from code:

# [C++](#tab/code-cpp)
```cpp
#include "Engine/Graphics/RenderTask.h"

MainRenderTask::Instance->View.Flags |= ViewFlags::PhysicsDebug;
```
# [C#](#tab/code-csharp)
```cs
MainRenderTask.Instance.View.Flags |= ViewFlags.PhysicsDebug;
```
***
