# Script properties and fields

Every script can contain various fields and properties. By default Flax shows all **public fields and properties** in the *Properties* window so user may edit them (undo/redo is supported).

* Script
```cs
public class MyScript : Script
{
	public float Field1 = 11;
	public Color Field2 = Color.Yellow;
	public DirectionalLight Field3 { get; set; }
}
```

* Editor
<br>![Script Properties](media/script-ui.png)

# Attributes

If you want to **hide** a public property or a field simply use [HideInEditor](https://docs.flaxengine.com/api/FlaxEngine.HideInEditorAttribute.html) attribute.

```cs
[HideInEditor]
public float Field1 = 11;
```

If you want to **don't serialize** a public property or a field use [NoSerialize](https://docs.flaxengine.com/api/FlaxEngine.NoSerializeAttribute.html) attribute.

```cs
[NoSerialize]
public float Field1 = 11;
```

To learn more about using attributes see this [page](attributes.md).

To learn more about scripts serialization see this [page](serialization/index.md).
