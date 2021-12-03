# Script properties and fields

Every script can contain various fields and properties. By default Flax shows all **public fields and properties** in the *Properties* window so user may edit them (undo/redo is supported).

# Script

# [C#](#tab/code-csharp)
[!code-csharp[Example1](code-examples/properties.cs)]
# [C++](#tab/code-cpp)
[!code-cpp[Example2](code-examples/properties.h)]
***

![Script Properties](media/script-ui.png)

# Attributes

If you want to **hide** a public property or a field simply use [HideInEditor](https://docs.flaxengine.com/api/FlaxEngine.HideInEditorAttribute.html) attribute.

# [C#](#tab/code-csharp)
```cs
[HideInEditor]
public float Field1 = 11;
```
# [C++](#tab/code-cpp)
```cpp
API_FIELD(Attributes="HideInEditor")
float Field1 = 11;
```
***

If you want to **don't serialize** a public property or a field use [NoSerialize](https://docs.flaxengine.com/api/FlaxEngine.NoSerializeAttribute.html) attribute.

# [C#](#tab/code-csharp)
```cs
[NoSerialize]
public float Field1 = 11;
```
# [C++](#tab/code-cpp)
```cpp
API_FIELD(Attributes="NoSerialize")
float Field1 = 11;
```
***

To learn more about using attributes see this [page](attributes.md).

To learn more about scripts serialization see this [page](serialization/index.md).
