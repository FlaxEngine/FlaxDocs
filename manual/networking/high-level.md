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

Each client has own unique `uint32 ClientId` used to identify it within a newtowkr session. Network manager in mode Server or Host always uses `NetworkManager.ServerClientId = 0` to distinguish from other peers.

## Network Settings

To control network system use **Network Settings** asset (linked into [Game Settings](../editor/game-settings/index.md)). You can adjust those options from code at runtime (eg. to set server address or port) with the following code:

```cs
// Setup network connection settings
var networkSettings = GameSettings.Load<NetworkSettings>();
networkSettings.Address = "23.145.242.343";
networkSettings.Port = 2137;
GameSettings.LoadAsset<NetworkSettings>().SetInstance(networkSettings);
```

| Property | Description |
|--------|--------|
| **Max Clients** | Maximum amount of active network clients in a game session. Used by server or host to limit amount of players and spectators. |
| **Protocol Version** | Network protocol version of the game. Network clients and server can use only the same protocol version (verified upon client joining). |
| **Network FPS** | The target amount of the network system updates per second. Higher values provide better network synchronization (eg. *60* for shooters), lower values reduce network usage and performance impact (eg. *30* for strategy games). Can be used to tweak networking performance impact on game. Cannot be higher that UpdateFPS (from [Time Settings](../editor/game-settings/time-settings.md)). Use 0 to run every game update. |
|||
| **Address** | Address of the server (server/host always runs on *localhost*). Only `IPv4` is supported. |
| **Port** | The port for the network peer. |
| **Network Driver** | The type of the network driver (implements `INetworkDriver`) that will be used to create, manage, send and receive messages over the network. |

## Network Replicator

`NetworkReplicator` is system responsible for replicating networked objects and sending/receiving RPCs. It supports objects network role and ownership concepts but also cotains API to spawn/despawn objects at runtime.

To register object (script or actor) for network call `NetworkReplicator.AddObject` (eg. in `OnEnable` method). It will be automatically added to replication and will be able to invoke or execute RPCs. If you want to register dynamically spawned scene object (eg. player prefab) then call `NetworkReplicator.SpawnObject` (`DespawnObject` to remove it).

Statically placed objects on a level (eg. door actor) can register themselves (eg. in `OnEnable`/`BeginPlay` method) so when the network is online those objects will be properly replicated with RPCs support since they exist on server and clients (assuming all of them loaded that level).

> [!Tip]
> `NetworkReplicator` APIs are ignored when `NetworkManager` is offline.

```cs
public class MyPlayer : Script
{
    /// <inheritdoc />
    public override void OnEnable()
    {
        // Register for replication
        NetworkReplicator.AddObject(this);
    }

    /// <inheritdoc />
    public override void OnDisable()
    {
        // Unregister from replication
        NetworkReplicator.RemoveObject(this);
    }
}

public class MyGameManager : Script
{
    public Prefab PlayerPrefab;

    public void SpawnPlayer()
    {
        // Spawning prefab object over the network (by default all objects are always owned by the server)
        var player = PrefabManager.SpawnPrefab(PlayerPrefab);  
        NetworkReplicator.SpawnObject(player);
    }
}
```

Each object can query own role and ownership via `GetObjectRole`/`GetObjectOwnerClientId` including utilities such as `IsObjectOwned`/`IsObjectSimulated`/`IsObjectReplicated`. Object owner can also update its ownership via `SetObjectOwnership`.

## Replication Hierarchy

`NetworkReplicationHierarchy` is a feature that allows the game to configure objects replication mechanism. It's an optional extension to `NetworkReplicator` accessible via `Hierarchy` property and can be set by game to a custom nodes hierarchy. It's used to store objects for replication in a more optimized structure (eg. grid or hierarchical tree) and it can be used to control the replication rate and target clients for each object individually.

For example, when a large game level contains 10k networked objects (eg. POIs) then replicating all of them to all connected clients would kill the performance. To solve this problem a simple replication hierarchy can be created that would control Replication FPS for each object and call unnecessary replications for clients that are too far from the objects. Below is the sample code:

> [!Tip]
> `NetworkReplicationHierarchy` runs on both server and client but contains only objects that are *owned locally* - no need to manage objects that should not be replicated by remote clients.

# [C#](#tab/code-csharp)
```cs
// Custom replication hierarchy type
public class MyReplicationHierarchy : NetworkReplicationHierarchy
{
    private NetworkReplicationGridNode _grid = new NetworkReplicationGridNode();

    ~MyReplicationHierarchy()
    {
        // Cleanup memory
        Destroy(_grid);
    }

    // Called by NetworkReplicator to insert object into hierarchy
    public override void AddObject(NetworkReplicationHierarchyObject obj)
    {
        // Scale down update rate (it can be setup per-object type or from object interface method)
        obj.ReplicationFPS = 30;

        var actor = obj.Actor;
        if (actor != null && actor.HasStaticFlag(StaticFlags.Transform))
        {
            // Insert static objects into a grid for faster replication
            _grid.AddObject(obj);
            return;
        }

        base.AddObject(obj);
    }

    // Called by NetworkReplicator to remove object from hierarchy
    public override bool RemoveObject(Object obj)
    {
        if (_grid.RemoveObject(obj))
            return true;
        return base.RemoveObject(obj);
    }

    // Called every network update to gather objects for replication
    public override void Update(NetworkReplicationHierarchyUpdateResult result)
    {
        // Setup players locations for distance culling
        var clients = NetworkManager.Clients;
        for (var i = 0; i < clients.Length; i++)
        {
            var client = clients[i];
            // TODO: use real-life location of the player
            result.SetClientLocation(i, Vector3.Zero);
        }

        // Update hierarchy
        _grid.Update(result);
        base.Update(result);
    }
}

// Then in your game code before starting the multiplayer:
NetworkReplicator.SetHierarchy(new MyReplicationHierarchy());
```
# [C++](#tab/code-cpp)
```cpp

#include "Engine/Networking/NetworkReplicationHierarchy.h"
#include "Engine/Networking/NetworkManager.h"
#include "Engine/Level/Actor.h"

// Custom replication hierarchy type
API_CLASS() class FLAXENGINE_API MyReplicationHierarchy : public NetworkReplicationHierarchy
{
    DECLARE_SCRIPTING_TYPE_WITH_CONSTRUCTOR_IMPL(MyReplicationHierarchy, NetworkReplicationHierarchy);
private:
    NetworkReplicationGridNode _grid;

public:
    // Called by NetworkReplicator to insert object into hierarchy
    void AddObject(NetworkReplicationHierarchyObject obj) override
    {
        // Scale down update rate (it can be setup per-object type or from object interface method)
        obj.ReplicationFPS = 30;

        const Actor* actor = obj.GetActor();
        if (actor && actor->HasStaticFlag(StaticFlags::Transform))
        {
            // Insert static objects into a grid for faster replication
            _grid.AddObject(obj);
            return;
        }

        NetworkReplicationHierarchy::AddObject(obj);
    }

    // Called by NetworkReplicator to remove object from hierarchy
    bool RemoveObject(ScriptingObject* obj) override
    {
        if (_grid.RemoveObject(obj))
            return true;
        return NetworkReplicationHierarchy::RemoveObject(obj);
    }

    // Called every network update to gather objects for replication
    void Update(NetworkReplicationHierarchyUpdateResult* result) override
    {
        // Setup players locations for distance culling
        const auto& clients = NetworkManager::Clients;
        for (int32 i = 0; i < clients.Count(); i++)
        {
            NetworkClient* client = clients[i];
            // TODO: use real-life location of the player
            result->SetClientLocation(i, Vector3::Zero);
        }

        // Update hierarchy
        _grid.Update(result);
        NetworkReplicationHierarchy::Update(result);
    }
};

// Then in your game code before starting the multiplayer:
NetworkReplicator::SetHierarchy(New<MyReplicationHierarchy>());
```
***

## Object Ownership

In a fully-authoritative setup server owns all gameplay objects replicated over the network thus clients cannot enforce property changes on other clients directly. Hoverwer, the game might want to retain overship for local client pawns/characters and let servers do the sync or validation only. This might simplify gameplay simulation of the player inputs (players control local pawns) but still allows the server to validate state before replicating it to other clients.

Objects might rely on the ownership thus can be split into:
* **server only** - objects only exist on the server,
  * *Game Mode* - controls the global gameplay logic (eg. winning conditions),
* **server and clients** - objects exist on the server and all clients,
  * *Game State* - contains global gameplay data,
  * *Player State* - contains players data,
  * *Player Pawn* - represents player pawn on a scene,
* **server and owning client** - objects exist on the server and owning client only,
  * *Player Controller* - controls player logic,
* **owning client only** - objects exist on owning client only,
  * *UI and HUD* - displays the player and gameplay state,

Owning client is a player/client that owns the object (spawned it with authority - eg. player pawn prefab).

Network object roles:
* **None** - not replicated object,
* **Owned Authoritative** - server/client owns the object and replicates it to others,
* **Replicated** - server/client gets replicated object from other server/client,
* **Replicated Simulated**- client gets replicated object from server but can locally autonomously simulate it too (eg. control local pawn with real human input but sync+validate with server - player can smoothly move but won't go through the walls since server does the validation).

## Object Serialization

Game objects and types can define their own serialization/deserialization methods to customize how data is passed through the network via `INetworkSerializable` interface or by registering via `NetworkReplicator::AddSerializer`. Serialization methods use `NetworkStream` which supports streaming raw bytes, structure, in-built types, collections and custom types. When sending larger objects data (bigger than default message size of `INetworkDriver` which is usually 1500 bytes) the networking system will split message into parts.

Examples of network object data serialization with fields/properties marked with `NetworkReplicated` attribute:

# [C#](#tab/code-csharp)
```cs
// Automatic replication of custom structures
public struct CustomStruct
{
    [NetworkReplicated] public int MyVar;
};

// Automatic replication of object properties
public class MyScript :  Script
{
    [NetworkReplicated] public float MyFloat = 0.0f;
    [NetworkReplicated] public CustomStruct MyStruct;
    [NetworkReplicated] public PlatformType MyEnum = PlatformType.Windows;
    [NetworkReplicated] public string MyString = "text";
    [NetworkReplicated] public int[] MyArray = new []{ 1, 2, 3 };
    [NetworkReplicated] public Dictionary<int, string> MyMap;
};

// Custom network serialization of custom structures
public struct CustomStructManual : INetworkSerializable
{
    public float MyVar;

    public void Serialize(NetworkStream stream)
    {
        // Custom data replication
        stream.WriteSingle(Val);
    }

    public void Deserialize(NetworkStream stream)
    {
        // Custom data replication
        Val = stream.ReadSingle();
    }
};
```
# [C++](#tab/code-cpp)
```cpp
// Automatic replication of custom structures
API_STRUCT() struct GAME_API CustomStruct
{
    DECLARE_SCRIPTING_TYPE_STRUCTURE(CustomStruct);

    API_FIELD(NetworkReplicated) int32 MyVar = 0.0f;
};

// Automatic replication of object properties
API_CLASS() class GAME_API MyScript : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(MyScript);

    API_FIELD(NetworkReplicated) float MyFloat = 0.0f;
    API_FIELD(NetworkReplicated) CustomStruct MyStruct;
    API_FIELD(NetworkReplicated) PlatformType MyEnum = PlatformType::Windows;
    API_FIELD(NetworkReplicated) String MyString = TEXT("text");
    API_FIELD(NetworkReplicated) Array<int32> MyArray = { 1, 2, 3 };
    API_FIELD(NetworkReplicated) Dictionary<int32, String> MyMap;
};

#include "Engine/Networking/INetworkSerializable.h"
#include "Engine/Networking/NetworkStream.h"

// Custom network serialization of custom structures
API_STRUCT() struct GAME_API CustomStructManual : INetworkSerializable
{
    DECLARE_SCRIPTING_TYPE_STRUCTURE(CustomStructManual);

    API_FIELD() float Val;

    void Serialize(NetworkStream* stream) override
    {
        // Custom data replication
        stream->Write(Val);
    }

    void Deserialize(NetworkStream* stream) override
    {
        // Custom data replication
        stream->Read(Val);
    }
};
```
***

## RPCs

**Remote Procedure Call** (shorten as RPC) is used to invoke code on other network clients. For example, call server method from client or vice versa: call method on all clients from server. This is useful to synchronize state or invoke certain action over the network (eg. player attack, chat message, etc.). RPC methods can be normally called from gameplay code but inner logic might be executed only on other clients.

To declare RPC use `NetworkRpc` attribute on function with `Server` or `Client` value set. Each RPC can also specify the transport channel to use (`Unreliable`, `UnreliableOrdered`, `Reliable`, `ReliableOrdered`). [Flax.Build](../editor/flax-build/index.md) codegen will inject custom code before the method body which will invoke the method properly on remote clients. Example RPCs:

> [!Tip]
> RPCs can be used only in networked objects (registered via `NetworkReplicator.AddObject`) and in types which code module is marked with `Network` tag.

#### RPC concepts

* Client RPC
  * Can be called only by server or host
  * Is sent to all connected clients that have registered the RPC object instance and are matching custom `TargetIds` (if provided via `NetworkRpcParams`)
  * Can be both sent and executed locally on host (both server and client)
* Server RPC
  * Can be called only by client or host
  * Is sent to server only
  * You can use `SenderId` field from `NetworkRpcParams` to detect which client send that RPC

#### RPC examples

# [C#](#tab/code-csharp)
```cs
// Example RPC invoked on server-only
[NetworkRpc(Server = true)]
public void SetSequenceIndex(ushort value)
{
    _currentSequence = value;
}

// Example RPC invoked on clients with Unreliable channel (message might not arrive but will have less lag)
[NetworkRpc(Client = true, Channel = NetworkChannelType.Unreliable)]
public void CallClientRPC(string text, uint[] ids)
{
    Debug.Log("Got msg from server: " + text);
}
```
# [C++](#tab/code-cpp)
```cpp
// .h
API_CLASS() class GAME_API MyScript : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(MyScript);

    // Example RPC invoked on server-only
    API_FUNCTION(NetworkRpc=Server)
    void SetSequenceIndex(ushort value);

    // Example RPC invoked on clients with Unreliable channel (message might not arrive but will have less lag)
    API_FUNCTION(NetworkRpc="Client, Unreliable")
    void CallClientRPC(const String& text, Array<uint32>& ids);
};

// .cpp

// Ensure to include utility header for RPC impl
#include "Engine/Networking/NetworkRpc.h"

void MyScript::SetSequenceIndex(ushort value)
{
    // Macro `NETWORK_RPC_IMPL` is used to inject RPC invoke/execute code
    // Usage: NETWORK_RPC_IMPL(<type>, <rpcName>, <arguments>)
    NETWORK_RPC_IMPL(MyScript, SetSequenceIndex, value);

    // then method body..
    _currentSequence = value;
}

void MyScript::CallClientRPC(const String& text, Array<uint32>& ids)
{
    NETWORK_RPC_IMPL(MyScript, CallClientRPC, text, ids);

    LOG(Info, "Got msg from server: {0}", text);
}

// If you override virtual RPC method, then use `NETWORK_RPC_OVERRIDE_IMPL` macro before calling base method or overriden method body.
```
***

#### RPC context parameters

Network RPCs can use contextual parameters as input to detect who sends the message or as output to send a message to a specific set of clients. Those identifiers are based on `NetworkClient.ClientId`, you can use `NetworkManager.GetClient` to get the client for a specific id. Use `NetworkRpcParams` structure parameter as follows:

# [C#](#tab/code-csharp)
```cs
// Example RPC invoked on server that logs the client who send this message
[NetworkRpc(Server = true)]
public void SetSequenceIndex(ushort value, NetworkRpcParams rpc = new NetworkRpcParams())
{
    Debug.Log("Got msg on server from clientId: " + rpc.SenderId);
}

// Example RPC invoked on clients
[NetworkRpc(Client = true)]
public void CallClientRPC(string text, NetworkRpcParams rpc = new NetworkRpcParams())
{
    Debug.Log("Got msg from server: " + text);
}

// Server method that invokes CallClientRPC only on specific list of clients
public void CallSpecificClients()
{
    var rpc = new NetworkRpcParams
    {
        TargetIds = new uint[] { 1, 3 }, // NetworkClient.ClientId
    };
    CallClientRPC("hello", rpc);
}
```
# [C++](#tab/code-cpp)
```cpp
// .h
#include "Engine/Networking/NetworkRpc.h"
API_CLASS() class GAME_API MyScript : public Script
{
    API_AUTO_SERIALIZATION();
    DECLARE_SCRIPTING_TYPE(MyScript);

    // Example RPC invoked on server that logs the client who send this message
    API_FUNCTION(NetworkRpc=Server)
    void SetSequenceIndex(ushort value, NetworkRpcParams rpc = NetworkRpcParams());

    // Example RPC invoked on clients
    API_FUNCTION(NetworkRpc=Client)
    void CallClientRPC(const String& text, NetworkRpcParams rpc = NetworkRpcParams());

    // Server method that invokes CallClientRPC only on specific list of clients
    API_FUNCTION()
    void CallSpecificClients();
};

// .cpp
void MyScript::SetSequenceIndex(ushort value, NetworkRpcParams rpc)
{
    NETWORK_RPC_IMPL(MyScript, SetSequenceIndex, value, rpc);

    // then method body..
    LOG(Info, "Got msg on server from clientId: {0}", rpc.SenderId);
}

void MyScript::CallClientRPC(const String& text, NetworkRpcParams rpc)
{
    NETWORK_RPC_IMPL(MyScript, CallClientRPC, text, rpc);

    LOG(Info, "Got msg from server: {0}", text);
}

void MyScript::CallSpecificClients()
{
    NetworkRpcParams rpc;
    uint32 ids[2] = { 1, 3 }; // NetworkClient::ClientId
    rpc.TargetIds = ToSpan(ids, ARRAY_COUNT(ids));
    CallClientRPC(TEXT("hello"), rpc);
}
```
***

### Extending network objects

To extend networking for more custom case you can use `INetworkObject` interfaces on networked objects:
* `INetworkObject` - allows to extend networked objects lifetime with custom events called on certain points during it's lifetime (eg. spawn/despawn or during replication).
* `INetworkSerializable` - allows to override default replication logic by using custom serialize/deserialize methods that send object state over network using `NetworkStream` object.

### Profiling and debugging

To analyze network transfer use Network tab in [Profiler window](../editor/profiling/profiler.md) in Editor.
To quickly profile networking with lag simulation (eg. due to bad network ocnnection) you can use `NetworkLagDriver` (set it in `Network Settings`) which can delay network messages sending to fake the lag between server and client.
