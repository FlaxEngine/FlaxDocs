# HOWTO: Create TCP client-server

The following example uses a pair of Server and Client scripts to send a text message over the network. Note that this example uses non-blocking code and performs pooling on sockets during script `OnUpdate`.

To use it simple create a pair of scripts and add them to the scene.

## C#

### Client

```cs
using System.Text;
using FlaxEngine;

public class CSharpClient : Script
{
    private NetworkSocket _socket;
    private byte[] _buffer = new byte[100];

    /// <inheritdoc/>
    public override void OnEnable()
    {
        Debug.Log("Setting up client");
        Network.CreateEndPoint("localhost", "35000", NetworkIPVersion.IPv4, out var endPoint);
        Network.CreateSocket(ref _socket, NetworkProtocol.Tcp, NetworkIPVersion.IPv4);
        Network.SetSocketOption(ref _socket, NetworkSocketOption.ReuseAddr, 1);
        Network.ConnectSocket(ref _socket, ref endPoint);
        Debug.Log("Client listening for server...");
    }

    /// <inheritdoc/>
    public override void OnDisable()
    {
        Network.DestroySocket(ref _socket);
    }

    /// <inheritdoc/>
    public override void OnUpdate()
    {
        if (Network.IsReadable(ref _socket))
        {
            int size = Network.ReadSocket(_socket, _buffer);
            if (size > 0)
            {
                _buffer[size] = 0;
                Debug.Log($"Message : {Encoding.ASCII.GetString(_buffer)} | Size : {size}");
            }
        }
    }
}
```

### Server

```cs
using System.Text;
using FlaxEngine;

public class CSharpServer : Script
{
    private bool _connected;
    private NetworkSocket _serverSocket;
    private NetworkSocket _clientSocket;

    /// <inheritdoc/>
    public override void OnEnable()
    {
        Debug.Log("Setting up server");
        Network.CreateEndPoint(null, "35000", NetworkIPVersion.IPv4, out var serverPoint);
        Network.CreateSocket(ref _serverSocket, NetworkProtocol.Tcp, NetworkIPVersion.IPv4);
        Network.SetSocketOption(ref _serverSocket, NetworkSocketOption.ReuseAddr, 1);
        Network.BindSocket(ref _serverSocket, ref serverPoint);
        Network.Listen(ref _serverSocket, 100);
        Debug.Log("Server waiting for connection...");
    }

    /// <inheritdoc/>
    public override void OnDisable()
    {
        Debug.Log("Shutting down server");
        if (_connected)
        {
            Network.DestroySocket(ref _clientSocket);
            _connected = false;
        }

        Network.DestroySocket(ref _serverSocket);
    }

    /// <inheritdoc/>
    public override void OnUpdate()
    {
        if (Network.IsReadable(ref _serverSocket))
        {
            Network.Accept(ref _serverSocket, ref _clientSocket, out var clientPoint);
            Debug.Log("Client connected");
            _connected = true;
        }

        if (_connected && Network.IsWritable(ref _clientSocket))
        {
            string data = "Hello, world! The very first message.";
            int written = Network.WriteSocket(_clientSocket, Encoding.ASCII.GetBytes(data));
            Debug.Log($"Sended : {written}");
            Network.DestroySocket(ref _clientSocket);
            _connected = false;
        }
    }
}
```

## C++

### Client

```cpp
#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Platform/Network.h"

API_CLASS() class GAME_API CppClient : public Script
{
API_AUTO_SERIALIZATION();
DECLARE_SCRIPTING_TYPE(CppClient);
private:
    NetworkSocket _socket;

public:

    // [Script]
    void OnEnable() override;
    void OnDisable() override;
    void OnUpdate() override;
};
```

```cpp
#include "CppClient.h"
#include "Engine/Core/Log.h"

CppClient::CppClient(const SpawnParams& params)
    : Script(params)
{
    _tickUpdate = true;
}

void CppClient::OnEnable()
{
    LOG(Info, "Setting up client");
    NetworkEndPoint endPoint;
    Network::CreateEndPoint(TEXT("localhost"), TEXT("35000"), NetworkIPVersion::IPv4, endPoint);
    Network::CreateSocket(_socket, NetworkProtocol::Tcp, NetworkIPVersion::IPv4);
    Network::SetSocketOption(_socket, NetworkSocketOption::ReuseAddr, 1);
    Network::ConnectSocket(_socket, endPoint);
    LOG(Info, "Client listening for server...");
}

void CppClient::OnDisable()
{
    Network::DestroySocket(_socket);
}

void CppClient::OnUpdate()
{
    if (Network::IsReadable(_socket))
    {
        byte buf[100];
        const int32 size = Network::ReadSocket(_socket, buf, ARRAY_COUNT(buf) - 1);
        if (size > 0)
        {
            buf[size] = '\0';
            LOG(Info, "Message : {0} | Size : {1}", String((char*)buf), size);
        }
    }
}
```

### Server

```cpp
#pragma once

#include "Engine/Scripting/Script.h"
#include "Engine/Platform/Network.h"

API_CLASS() class GAME_API CppServer : public Script
{
API_AUTO_SERIALIZATION();
DECLARE_SCRIPTING_TYPE(CppServer);
private:
    bool _connected;
    NetworkSocket _serverSocket;
    NetworkSocket _clientSocket;

public:

    // [Script]
    void OnEnable() override;
    void OnDisable() override;
    void OnUpdate() override;
};
```

```cpp
#include "CppServer.h"
#include "Engine/Core/Log.h"

CppServer::CppServer(const SpawnParams& params)
    : Script(params)
{
    _tickUpdate = true;
}

void CppServer::OnEnable()
{
    LOG(Info, "Setting up server");
    NetworkEndPoint serverPoint;
    Network::CreateEndPoint(String::Empty, TEXT("35000"), NetworkIPVersion::IPv4, serverPoint);
    Network::CreateSocket(_serverSocket, NetworkProtocol::Tcp, NetworkIPVersion::IPv4);
    Network::SetSocketOption(_serverSocket, NetworkSocketOption::ReuseAddr, 1);
    Network::BindSocket(_serverSocket, serverPoint);
    Network::Listen(_serverSocket, 100);
    LOG(Info, "Server waiting for connection...");
}

void CppServer::OnDisable()
{
    LOG(Info, "Shutting down server");
    if (_connected)
    {
        Network::DestroySocket(_clientSocket);
        _connected = false;
    }
    Network::DestroySocket(_serverSocket);
}

void CppServer::OnUpdate()
{
    if (Network::IsReadable(_serverSocket))
    {
        NetworkEndPoint clientPoint;
        Network::Accept(_serverSocket, _clientSocket, clientPoint);
        LOG(Info, "Client connected");
        _connected = true;
    }

    if (_connected && Network::IsWritable(_clientSocket))
    {
        const StringAnsi data("Hello, world! The very first message.");
        const int32 written = Network::WriteSocket(_clientSocket, (byte*)*data, data.Length());
        LOG(Info, "Sended : {0}", written);
        Network::DestroySocket(_clientSocket);
        _connected = false;
    }
}
```
