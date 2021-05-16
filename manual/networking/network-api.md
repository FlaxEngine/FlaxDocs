# Network API

Flax implements a low-level networking interface with Berkeley sockets. It's exposed to scripting API and can be used in C++, C#, or Visual Scripting.

## API

* [Network](https://docs.flaxengine.com/api/FlaxEngine.Network.html) - networking interface (platform-dependant implementation)
* [NetworkSocket](https://docs.flaxengine.com/api/FlaxEngine.NetworkSocket.html) - socket object (value structure)
* [NetworkEndPoint](https://docs.flaxengine.com/api/FlaxEngine.NetworkEndPoint.html) - network endpoint created from address, port and protocol
* [NetworkSocketOption](https://docs.flaxengine.com/api/FlaxEngine.NetworkSocketOption.html) - network socket options
* [NetworkSocketGroup](https://docs.flaxengine.com/api/FlaxEngine.NetworkSocketGroup.html) - socket objects group for batch operations
