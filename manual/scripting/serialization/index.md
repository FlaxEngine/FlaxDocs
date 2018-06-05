# Scripts serialization

**Scripts serialization** is a feature that allows to save the object into a portable data format. Later this data can be used to restore the state of the object. It's used when loading scenes, performing hot-reload or recording undo actions.

Flax uses **Json** format to store scripts and objects state. It's a lightweight and very standardized format. Flax C# API contains a build-in methods to serialize and deserialize objects, even at runtime. See [JsonSerializer](https://docs.flaxengine.com/api/FlaxEngine.Json.JsonSerializer.html) class. Under the hood Flax uses custom [Json.NET](https://github.com/JamesNK/Newtonsoft.Json) which is a popular high-performance JSON framework for .NET.

## Serialization rules

Flax serializes object field or properties if:

* It's `public` or has [Serialize](https://docs.flaxengine.com/api/FlaxEngine.SerializeAttribute.html) attribute
* It has no [NoSerialize](https://docs.flaxengine.com/api/FlaxEngine.NoSerializeAttribute.html) attribute
* It's not `static`
* It's not `readonly`
* It's not `const`
* Its type can be serialized

[Here](https://github.com/FlaxEngine/FlaxAPI/blob/master/FlaxEngine/Json/JsonCustomSerializers/ExtendedDefaultContractResolver.cs) you can find a open source file that implements serialization rules used by the Flax API.

Flax deserialization works more like `populate` existing object with data rather than `full load`. This reduces amount of data required to save and helps with changing the default values for the fields and properties.

## Serialization tips

Here are listed various hints about Flax serialization:

* References to the scene objects (actors, scripts) are serialized as `Guid` (hex format, inlined). See [Object.ID](https://docs.flaxengine.com/api/FlaxEngine.Object.html#FlaxEngine_Object_ID).
* Editor uses default serialization rules for Undo
* Flax deserializes all child scene object before calling `Awake`/`Start` methods on loaded objects (parent object may not be deserialized yet).
* Avoid recursive references for custom objects types. It's better to use loop-references for scene objects.

