# Network Replication

`NetworkReplicator` is system responsible for replicating networked objects and sending/receiving RPCs. It supports network role and ownership concepts for objects but also cotains API to spawn/despawn objects at runtime.

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

`NetworkReplicationHierarchy` runs on both server and client but contains only objects that are *owned locally* - no need to manage objects that should not be replicated by remote clients.

For example, when a large game level contains 10k networked objects (eg. POIs) then replicating all of them to all connected clients would sacrifice the performance. To solve this problem a simple replication hierarchy can be created that would control Replication FPS for each object and skip unnecessary replications for clients that are too far away. Below is the sample code:

> [!Tip]
> Use `NetworkReplicator.DirtyObject(obj)` to mark object as modified for immediate replication (eg. when an object has low Replication FPS but needs to replicate state quickly). You can also set `ReplicationFPS` of an object to be less than `0` if you only want it to be replicated on spawn.

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
NetworkReplicator.Hierarchy = new MyReplicationHierarchy();
```
# [C++](#tab/code-cpp)
```cpp

#include "Engine/Networking/NetworkReplicationHierarchy.h"
#include "Engine/Networking/NetworkManager.h"
#include "Engine/Level/Actor.h"

// Custom replication hierarchy type
API_CLASS() class GAME_API MyReplicationHierarchy : public NetworkReplicationHierarchy
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

In a fully-authoritative setup server owns all gameplay objects replicated over the network thus clients cannot enforce property changes on other clients directly. However, the game might want to retain overship for local client pawns/characters and let servers do the sync or validation only. This might simplify gameplay simulation of the player inputs (players control local pawns) but still allows the server to validate state before replicating it to other clients.

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
