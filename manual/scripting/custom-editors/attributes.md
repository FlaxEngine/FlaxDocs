# Custom editors attributes

This page lists all common attributes that are used by the Custom Editors pipeline. Each attribute comes up with a short explanation and the usage example.

### HideInEditor

Makes a variable not show up in the editor.

```cs
[HideInEditor]
public int CoolVariable;
```

![Example](media/HideInEditor.jpg)

### ShowInEditor

Makes a variable show up in the editor even if it's private.
If used on a private field/property you may also need to add `SerializeAttribute` to ensure that modified value is being serialized.

```cs
[ShowInEditor]
private int CoolVariable;
```

### VisibleIf

Shows property/field in the editor only if the specified member has a given value. Can be used to hide properties based on other properties (also private properties). The given member has to be bool type.

```cs
public bool ShowIt;

[VisibleIf(nameof(ShowIt)]
public int CoolVariable;
```

### ReadOnly

Makes a variable show up in the editor as read-only (editing is disabled).

```cs
[ReadOnly]
public int CoolVariable;
```

### Tooltip

Specifies a tooltip for a property/field in the editor. Useful to provide documentation for object properties.

```cs
[Tooltip("Hello there!")]
public int CoolVariable;
```

![Example](media/Tooltip.jpg)

### Limit

Used to make a float or int variable in a script be restricted to a specific range.

```cs
[Limit(0, 100, 0.1f)]
public int CoolVariable;
```

### Range

Used to make a float or int variable in a script be restricted to a specific range. When used, the float or int will be shown as a slider in the editor instead of default number field.

```cs
[Range(0, 100)]
public int CoolVariable;
```

![Example](media/Range.jpg)

### Header

Inserts a header control with a custom text into the editor layout.

```cs
[Header("Super Section")]
public int CoolVariable;
```

![Example](media/Header.jpg)

### Space

Inserts an empty space between controls in the editor.

```cs
[Space(50)]
public int CoolVariable;
```

![Example](media/Space.jpg)

### EditorDisplay

Allows to change item display name or a group in the editor.

```cs
[EditorDisplay("My Super Group")]
public int CoolVariable1;

[EditorDisplay(null, "Override Label")]
public int CoolVariable;
```

![Example](media/EditorDisplay.jpg)

### EditorOrder

Allows to declare order of the item in the editor. Items are listed from the lowest to the highest order.

```cs
[EditorOrder(-10)]
public int CoolVariable;
```

### ExpandGroups

Marks the item to be visible in editor by expanding all the container groups in the upper hierarchy.

```cs
[EditorDisplay("My Group"), ExpandGroups]
public int CoolVariable;
```

### MultilineText

Instructs UI editor to use multiline textbox for editing *string* property or field.

```cs
[MultilineText]
public string CoolVariable;
```

![Example](media/MultilineText.jpg)

### AssetReference

Specifies a options for an asset reference picker in the editor. Allows to customize view or provide custom value assign policy.

```cs
[AssetReference(useSmallPicker: true)]
public Texture CoolVariable;
```

![Example](media/AssetReference.jpg)

### MemberCollection

This attributes provides additional information on a member collection.

```cs
[MemberCollection(ReadOnly = true)]
public int[] CoolVariable = new int[]
{
	1,
	2,
	3,
};
```

![Example](media/MemberCollection.jpg)

### CustomEditor

Overrides the default editor provided for the target object/class/field/property. Allows to extend visuals and editing experience of the object.

```cs
[CustomEditor(typeof(MyScript))]
public class MyScriptEditor : GenericEditor
{
	public override void Initialize(LayoutElementsContainer layout)
	{
		base.Initialize(layout);

		layout.Space(20);
		var button = layout.Button("Click me", Color.Green);
		button.Button.Clicked += () => Debug.Log("Clicked!");
	}
}
```

![Example](../tutorials/media/custom-window-tutorial-2.jpg)

### CustomEditorAlias

Works the same as *CustomEditor* attribute, except uses a typename that can be located in different assembly (not referenced).

```cs
[CustomEditorAlias("MyScriptEditor")]
public class MyScript : Script
{
	public float Speed = 11;
	public Color LightColor = Color.Yellow;
}
```

