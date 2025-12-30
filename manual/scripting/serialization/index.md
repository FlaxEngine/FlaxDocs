# Scripts serialization

**Scripts serialization** is a feature that allows to save an object into a portable data format. Later, this data can be used to restore the state of the object. It is used when loading scenes, performing hot-reload or recording undo actions.

Flax uses the **Json** format to store scripts and objects state. It's a lightweight and very standardized format. 

Flax's C# API contains a build-in methods to serialize and deserialize objects, even at runtime. See [JsonSerializer](https://docs.flaxengine.com/api/FlaxEngine.Json.JsonSerializer.html) class. Under the hood, Flax uses a custom fork of [Json.NET](https://github.com/JamesNK/Newtonsoft.Json), which is a popular high-performance JSON framework for .NET.

## Serialization rules

Flax serializes an object field or a property if:

* Its type can be serialized
* It is `public`
* It is `private` **and** has a [Serialize](https://docs.flaxengine.com/api/FlaxEngine.SerializeAttribute.html) attribute (inherited `private` members are not saved - but `protected` are)

Flax does *not* serialize an object field or a property if:
* It is `private`
* It is `static`
* It is `readonly`
* It is a `const`
* It has a [NoSerialize](https://docs.flaxengine.com/api/FlaxEngine.NoSerializeAttribute.html) attribute

You can find an open source file that implements serialization rules used by Flax [here](https://github.com/FlaxEngine/FlaxEngine/blob/master/Source/Engine/Serialization/JsonCustomSerializers/ExtendedDefaultContractResolver.cs)  .

Flax deserialization works more like `populate` existing object with data rather than `full load`. This reduces the amount of data required to save, and it helps with changing the default values for the fields and properties.

## Serialization tips

Here are some tips and hints about serialization in Flax:

* References to scene objects (actors, scripts) are serialized as `Guid` (hex format, inlined). See [Object.ID](https://docs.flaxengine.com/api/FlaxEngine.Object.html#FlaxEngine_Object_ID).
* The editor uses default serialization rules for the Undo & Redo system.
* Flax deserializes all child scene object before calling the `OnAwake`/`OnStart` methods on loaded objects (parent object may not be deserialized yet).
* It is best to avoid recursive references for custom objects types. It's better to use loop-references for scene objects.
* When performing code refactoring, take a look at [this tutorial](../advanced/refactoring-renaming.md) about supporting old data format loading

## Serialization Callbacks

Flax supports serialization callback methods. A callback can be used to manipulate an object before and/or after its serialization and deserialization by the serializer.

* OnSerializing
* OnSerialized
* OnDeserializing
* OnDeserialized

Example:

```cs
using System.Runtime.Serialization;

public class MyScript : Script
{
    [OnSerializing]
    internal void OnSerializing(StreamingContext context)
    {
        Debug.Log("OnSerializing");
    }

    [OnSerialized]
    internal void OnSerialized(StreamingContext context)
    {
        Debug.Log("OnSerialized");
    }

    [OnDeserializing]
    internal void OnDeserializing(StreamingContext context)
    {
        Debug.Log("OnDeserializing");
    }

    [OnDeserialized]
    internal void OnDeserialized(StreamingContext context)
    {
        Debug.Log("OnDeserialized");
    }
}
```

## Native C\+\+ serialization

To learn more about C++ objects serialization, see the related documentation [here](../cpp/serialization.md).
