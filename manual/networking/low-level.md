# Low-Level Networking

Low-level networking layer is built around `NetworkPeer` object which uses `INetworkDriver` interface to send/receive `NetworkMessage`. It allows to declare custom network packet types and send them between server and client peers.

To learn how to create own server/client logic see [HOWTO: Create networking server and client](tutorials/network-client-server.md) tutorial.
