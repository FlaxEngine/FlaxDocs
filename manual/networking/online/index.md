# Online

**Online** system provides the access to player user profile, friends list, achievements, online presence, cloud saves and more which are exposed to desktop, mobile and console games on various online platforms such as Steam, Xbox Live or PlayStation Network.

## Online Platform Interface

Flax contains `IOnlinePlatform` interface designed for online platform providers for communicating with various multiplayer services such as player info, achievements, game lobby or in-game store. Each Online Platform implements this interface and is provided via plugin which can be used by your game project:
* [Steam](https://github.com/FlaxEngine/OnlinePlatformSteam)
* [Xbox Live](https://github.com/FlaxEngine/OnlinePlatformXboxLive)
* Platform-specific (PlayStation, Switch) for registered developers

## Online Platform Setup

In your game code setup the Online system with Online Platform (eg. when game opens the main menu). Depening on the runtime platform you can pick the online service to use (eg. Xbox Live on Xbox, Google Play on Android and Steam on Windows/Mac/Linux):

# [C#](#tab/code-csharp)
```cs
using FlaxEngine.Online;
using FlaxEngine.Online.Steam;

var platform = platform = new OnlinePlatformSteam();
Online.Initialize(platform);
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Online/Online.h"
#include "OnlinePlatformSteam/OnlinePlatformSteam.h"

auto platform = New<OnlinePlatformSteam>();
Online::Initialize(platform);
```
***

## Online Platform Usage

Once `Online` system is setup it exposes the current online platform to be used across the whole game project. Here is an example script that gets some basic information from online platform:

# [C#](#tab/code-csharp)
```cs
using FlaxEngine.Online;

// Setup
var platform = Online.Platform;
if (platform == null)
{
    Debug.LogError("Missing Online Platform");
    return;
}
if (platform.UserLogin())
{
    Debug.LogError("Failed to login to Online");
    return;
}

// User profile
platform.GetUser(out var user);
Debug.Log("User: " + user.Name + ", state: " + user.PresenceState);

// User friends info
platform.GetFriends(out var friends);
Debug.Log("Friends: " + friends.Length);
foreach (var f in friends)
    Debug.Log("    Friend: " + f.Name + ", state: " + f.PresenceState);

// Achievements
platform.ResetAchievements();
platform.UnlockAchievementProgress("ACH_WIN_100_GAMES", 40);
platform.GetAchievements(out var achievements);
Debug.Log("Achievements: " + achievements.Length);
foreach (var a in achievements)
    Debug.Log($"    Achievement: {a.Name}, Progress={a.Progress}, IsHidden={a.IsHidden}, desc: {a.Description}");

// Savegames
platform.GetSaveGame("savegame_0", out var saveGame);
if (saveGame != null && saveGame.Length != 0)
    Debug.Log("Has savegame of size: " + saveGame.Length);
else
    Debug.Log("No savegame");
platform.SetSaveGame("savegame_0", new byte[] { 1, 2, 3, 4 });
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Online/Online.h"
#include "Engine/Online/IOnlinePlatform.h"
#include "Engine/Scripting/Enums.h"

// Setup
auto platform = Online::Platform;
if (platform == nullptr)
{
    LOG(Error, "Missing Online Platform");
    return;
}
if (platform->UserLogin())
{
    LOG(Error, "Failed to login to Online");
    return;
}

// User profile
OnlineUser user;
platform->GetUser(user);
LOG(Info, "User: {0}, state: {1}", user.Name, ScriptingEnum::ToString(user.PresenceState));

// User friends info
Array<OnlineUser> friends;
platform->GetFriends(friends);
LOG(Info, "Friends: {0}", friends.Count());
for (auto& f : friends)
    LOG(Info, "    Friend: {0}, state: {1}", f.Name, ScriptingEnum::ToString(f.PresenceState));

// Achievements
platform->ResetAchievements();
platform->UnlockAchievementProgress(TEXT("ACH_WIN_100_GAMES"), 40);
Array<OnlineAchievement> achievements;
platform->GetAchievements(achievements);
LOG(Info, "Achievements: {0}", achievements.Count());
for (auto& a : achievements)
    LOG(Info, "    Achievement: {0}, Progress={1}, IsHidden={2}, desc: {3}", a.Name, a.Progress, a.IsHidden, a.Description);

// Savegames
Array<byte> saveGame;
platform->GetSaveGame(TEXT("savegame_0"), saveGame);
if (saveGame.HasItems())
    LOG(Info, "Has savegame of size: {0}", saveGame.Count());
else
    LOG(Info, "No savegame");
saveGame = Array<byte>({ 1, 2, 3, 4 });
platform->SetSaveGame(TEXT("savegame_0"), Span<byte>(saveGame.Get(), saveGame.Count()));
```
***

Note that Online API is sync and always returns `true` on failure. In some cases, such as player freiends list reading, it might take a bit to download this information from online service provider thus you might consider using it asynchroniusly (eg. from async task or a custom thread). To learn about multithreading see [this page](../../scripting/advanced/multithreading.md).

Finally, many of the Online API methods contain the last argument as `User localUser` which is `null` by default. It can be used to redirect Online Platform for a specific local player which is usefull in case of local-multiplayer games. The default value `null` can be used to access the first player info.
