# Data Serialization for C\+\+ in Flax

## ISerializable

`ISerializable` is a interface for objects that implement data serialization. It contains 2 methods:
* `virtual void Serialize(SerializeStream& stream, const void* otherObj)` - serializes object to the output stream compared to the values of the other object instance (eg. default class object). If other object is null then serialize all properties.
* `virtual void Deserialize(DeserializeStream& stream, ISerializeModifier* modifier)` - deserializes object from the input stream.

In C++ scripts you can use `API_AUTO_SERIALIZATION()` macro to inject automatic data serialization generated based on object `API_FIELDS()`. Alternatively you can manually implement this interface and use helper macros and tools from `Engine/Serialization/Serialization.h`.

The automatic serialization matches the [C# serialization rules](../serialization/index.md), where all public properties and fields are serialized. You can exclude or include field or property from serialization by using tags:

```cpp
public:
    API_FIELD(Attributes="NoSerialize") float PublicVarNotSaved;

private:
    API_FIELD(Attributes="Serialize") float PrivateVarSaved;
```

## Json

Flax uses [RapidJSON](https://rapidjson.org) library to serialize data into *json* format.

Example:

```cpp
#include "Engine/Serialization/JsonWriters.h"
#include "Engine/Serialization/JsonSerializer.h"
#include "Engine/Platform/File.h"

rapidjson_flax::StringBuffer buffer;
// PrettyJsonWriter can be also used here for better JSON formatting
CompactJsonWriter writer(buffer);
writer.StartObject();
object->Serialize(writer, nullptr);
writer.EndObject();
File::WriteAllBytes(TEXT("Output.json"), (byte*)buffer.GetString(), (int32)buffer.GetSize());

BytesContainer data;
File::ReadAllBytes(TEXT("Output.json"), data);
ISerializable::SerializeDocument document;
document.Parse(data.Get<char>(), data.Length());
if (!document.HasParseError())
    object->Deserialize(document, nullptr);
```

### Custom types

To implement data serialization for custom native type or custom data container add 3 methods in `Serialization` namespace as in an example shown below. It can be used for defining specialization implementation for template types too.

```cpp
API_STRUCT(NoDefault) struct MyCustomNativeData
{
    // This, combined with API_STRUCT(NoDefault) allows this type
    // to be used in scripting environment (C#, Visual Script, etc)
    DECLARE_SCRIPTING_TYPE_STRUCTURE(MyCustomNativeData);
    // Expose all the fields to the scripting api with API_FIELD()
    API_FIELD() Vector3 Direction;
    API_FIELD() float Length;
};

// C++ doesnt allow us to implement automatic serialization for structs with something convenient like API_AUTO_SERIALIZATION();,
// so in this case we have to manually tell it how to serialize and deserialize our data.

#include "Engine/Serialization/Serialization.h"
namespace Serialization
{
    inline bool ShouldSerialize(const MyCustomNativeData& v, const void* otherObj)
    {
        // This can detect if value is the same as other object (if not null) and skip serialization
        return true;
    }
    inline void Serialize(ISerializable::SerializeStream& stream, const MyCustomNativeData& v, const void* otherObj)
    {
        // Populate stream with the struct data
        stream.StartObject();
        stream.JKEY("Direction");
        Serialize(stream, v.Direction, nullptr);
        stream.JKEY("Length");
        Serialize(stream, v.Length, nullptr);
        stream.EndObject();
    }
    inline void Deserialize(ISerializable::DeserializeStream& stream, MyCustomNativeData& v, ISerializeModifier* modifier)
    {
        // Populate data with values from stream
        DESERIALIZE_MEMBER(Direction, v.Direction);
        DESERIALIZE_MEMBER(Length, v.Length);
    }
}

// If you want your struct to be compatible with automatic binary serialization (you would need that if you are planning
// to mark your struct with NetworkReplicated tag, as an example), then you should also add this template. This helps
// Read/WriteStream in deducting which binary serialization strategy to use for your struct (in our case we would want it as a POD struct).

template<>
struct TIsPODType<MyCustomNativeData>
{
    enum { Value = true };
};
```

If your code needs to auto-serialize the custom data type field or property but it should be not exposed to scripting (as it can be C++-only) use `Hidden` attribute.

```cpp
API_FIELD(Hidden) float NativeOnlyVar;
```

## Streams

Flax contains in-built file and memory streams for robust binary data serialization.
* `MemoryReadStream` - reading from memory
* `MemoryWriteStream` - writting to memory
* `FileReadStream` - reading from file (uses buffer to improve file access)
* `FileWriteStream` - writting to file (uses buffer to improve file access)

All types are in `Engine/Serialization/..`.
