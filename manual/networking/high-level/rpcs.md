# Network RPCs

**Remote Procedure Call** (shorten as RPC) is used to invoke code on other network clients. For example, call server method from client or vice versa: call method on all clients from server. This is useful to synchronize state or invoke certain action over the network (eg. player attack, chat message, etc.). RPC methods can be normally called from gameplay code but inner logic might be executed only on other clients.

To declare RPC use `NetworkRpc` attribute on function with `Server` or `Client` value set. Each RPC can also specify the transport channel to use (`Unreliable`, `UnreliableOrdered`, `Reliable`, `ReliableOrdered`). [Flax.Build](../editor/flax-build/index.md) codegen will inject custom code before the method body which will invoke the method properly on remote clients. Example RPCs:

> [!Tip]
> RPCs can be used only in networked objects (registered via `NetworkReplicator.AddObject`) and in types which code module is marked with `Network` tag.

## RPC Concepts

* Client RPC
  * Can be called only by server or host
  * Is sent to all connected clients that have registered the RPC object instance and are matching custom `TargetIds` (if provided via `NetworkRpcParams`)
  * Can be both sent and executed locally on host (both server and client)
* Server RPC
  * Can be called only by client or host
  * Is sent to server only
  * You can use `SenderId` field from `NetworkRpcParams` to detect which client send that RPC

## RPC Examples

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

## RPC Context Parameters

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
