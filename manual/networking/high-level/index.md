# High-Level Networking

High-level networking layer supports creating fully-featured multiplayer games. It features:
* High-level networking abstraction and implementation
  * Singleton service (1 per running game)
  * Configuration from game settings
  * Ability to adjust configs at runtime (eg. server ip/port)
* Allows creating multiplayer games easily
  * Shooters
  * Strategy
  * Coop
  * Competitive
* Can be integrated into an existing game project
* Not enabled/user by default
  * Reduce bloat in the engine from this feature
* Synchronizes game objects across the network
  * Game session state
  * Players data
  * Scene objects
    * Actors
    * Scripts
    * SubObjects
* Provides automatic data replication
  * Ability to prioritize objects to synchronize
  * Synchronize objects placed on a map (already on the level)
  * Synchronize objects spawned on a map
    * Synchronized object/prefab spawning
    * Authoritative or weak
* Remote procedure call (RPC)
  * Ability to invoke gameplay method on server or remote clients
  * Automatic arguments serialization
  * Customizable `NetworkChannelType`
* Build on top of the existing [low-level networking](low-level.md)
  * Offers the ability to swap `INetworkDriver` backend
  * Cross-platform networking
* Supports cross-play
* Client-Server connection only (clients cannot communicate directly)
* Scales up to 100 players
* Provides network profiler
  * Analyze data transfer usage per-frame

## In this section

* [Network Settings](settings.md)
* [Network Replication](replication.md)
* [Network RPCs](rpcs.md)

## Scripting integration

If you want to use automatic objects network replication or RPCs codegen, then modify your game code module build scripts by adding `Network` tag to it - it wil trigger additional processing and code generation to optimize networking.

```cs
// Game.Build.cs

public override void Setup(BuildOptions options)
{
    base.Setup(options);

    Tags["Network"] = string.Empty;
    options.PublicDependencies.Add("Networking");
}
```

## Network Manager

The main manager of high-level networking system is `NetworkManager` which provides API such as `StartServer()`/`StartClient()`/`StartHost()`/`Stop()`.  It creates `NetworkManager.Peer` to run as a server or client.

### Clients

Network Manager running as server or host receives new client connections which can be validated/rejected with `NetworkManager.ClientConnecting` event. For example, game client can send version, player info or local game files checksum to perform server-side verification for competitive multiplayer gaming.

After performing initial handshake with a new client it's added to `NetworkManager.Clients` list and `NetworkManager.ClientConnected` event is being called (as opposted to `NetworkManager.ClientDisconnected` event upon connection end or timeout). Network state can be checked with `State` property (`NetworkConnectionState` enum) and responsed to changes on `NetworkManager.StateChanged` event.

Each client has own unique `uint32 ClientId` used to identify it within a network session. Network manager in mode Server or Host always uses `NetworkManager.ServerClientId = 0` to distinguish from other peers.

### Extending network objects

To extend networking for more custom case you can use `INetworkObject` interfaces on networked objects:
* `INetworkObject` - allows to extend networked objects lifetime with custom events called on certain points during it's lifetime (eg. spawn/despawn or during replication).
* `INetworkSerializable` - allows to override default replication logic by using custom serialize/deserialize methods that send object state over network using `NetworkStream` object.

### Profiling and debugging

To analyze network transfer use Network tab in [Profiler window](../editor/profiling/profiler.md) in Editor.
To quickly profile networking with lag simulation (eg. due to bad network ocnnection) you can use `NetworkLagDriver` (set it in `Network Settings`) which can delay network messages sending to fake the lag between server and client.

To access objects **replication logs** use:

# [C#](#tab/code-csharp)
```cs
NetworkReplicator.EnableLog = true;
```
# [C++](#tab/code-cpp)
```cpp
NetworkReplicator::EnableLog = true;
```
***
