# Network Settings

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
| **Network FPS** | The target amount of the network system updates per second. Higher values provide better network synchronization (eg. *60* for shooters), lower values reduce network usage and performance impact (eg. *30* for strategy games). Can be used to tweak networking performance impact on game. Cannot be higher that UpdateFPS (from [Time Settings](../editor/game-settings/time-settings.md)). Use 0 to run every game update. Use value lower than 0 if you want to disable automatic field replication. |
|||
| **Address** | Address of the server (server/host always runs on *localhost*). Only `IPv4` is supported. |
| **Port** | The port for the network peer. |
| **Network Driver** | The type of the network driver (implements `INetworkDriver`) that will be used to create, manage, send and receive messages over the network. |
|||
| **Max Messages Per Update** | Limit for network manager messages amount to process within a single update. Prevents flooding the network system with too many messages and causing performance issues. Use 0 to process all messages. |
| **Max Messages Per Update Per Client** | Limit for network manager messages amount to process within a single update by a single client. Prevents flooding the network system with too many messages and causing performance issues. Use 0 to process all messages. |
| **Max Sync Parts** | Limit for network replication partial messages in-flight. Used to reduce object RPC/Replication/Spawn partial chunks that need multiple messages in order to process (due to large data size). Use 0 to disable this feature. |
| **Max Sync Part TTL** | Limit for network replication partial messages, within which all parts should arrive (in seconds). Used to limiting amount of in-flight parts or reject lost parts of object RPC/Replication/Spawn partial chunks. Use 0 to disable this feature. |
