# Data Serialization for C\+\+ in Flax

## ISerializable

`ISerializable` is a interface for objects that implement data serialization. It contains 2 methods:
* `virtual void Serialize(SerializeStream& stream, const void* otherObj)` - serializes object to the output stream compared to the values of the other object instance (eg. default class object). If other object is null then serialize all properties.
* `virtual void Deserialize(DeserializeStream& stream, ISerializeModifier* modifier)` - deserializes object from the input stream.

In C++ scripts yo ucan use `API_AUTO_SERIALIZATION()` macro to inject automatic data serialization generated based on object `API_FIELDS()`. Alternatively you can manually implement this interface and use helper macros and tools from `Engine/Serialization/Serialization.h`.

## Json

Flax uses [RapidJSON](https://rapidjson.org) library to serialize data into *json* format.

Example:

```cpp
#include "Engine/Serialization/JsonWriters.h"

rapidjson_flax::StringBuffer buffer;
CompactJsonWriter writer(buffer);
writer.SceneObject(this);
```

## Streams

Flax contains in-built file and memory streams for robust binary data serialization.
* `MemoryReadStream` - reading from memory
* `MemoryWriteStream` - writting to memory
* `FileReadStream` - reading from file (uses buffer to improve file access)
* `FileWriteStream` - writting to file (uses buffer to improve file access)

All types are in `Engine/Serialization/..`.
