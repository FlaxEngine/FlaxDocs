# Attributes

Flax provides various attributes that are used to extend the default logic or provide metadata about the code (serialization and editing options). These attributes can be used in both C# as well as C++.


## Using Attributes
Most of the attributes can be used for both: fields and properties:

### C#
```cs
[Limit(0, 10)]
public float Field1 = 11f;

[Tooltip("Light color")]
public Color Field2 { get; set; }
```

### C++
```cpp
API_FIELD(Attributes = "Limit(0, 10)")
float Field1 = 11f;

API_FIELD(Attributes = "Tooltip(\"Light color\")")
Color ColorVal;
```

## Common attributes

The following table lists the most common attributes with usage description.

| Attribute | Description |
|--------|--------|
| **Serialize** | Indicates that a field or a property should be be serialized. |
| **NoSerialize** | Indicates that a field or a property should not be serialized. |
| **HideInEditor** | Makes a variable not show up in the editor. |
| **ShowInEditor** | Makes a variable show up in the editor (even private ones). If used on a private field/property you may also need to add SerializeAttribute to ensure that modified value is being serialized. |
| **Tooltip** | Specifies a tooltip for a property/field in the editor. Useful to provide documentation for object properties. |
| **Limit** |  Used to make a float or int variable in a script be restricted to a specific range. |
| **Range** | Used to make a float or int variable in a script be restricted to a specific range. When used, the float or int will be shown as a slider in the editor instead of default number field. |
| **Header** | Inserts a header control with a custom text into the editor layout. |
| **Space** | Inserts an empty space between controls in the editor. |
| **EditorDisplay** | Allows to change item display name or a group in the editor. |
| **EditorOrder** | Allows to declare order of the item in the editor. Items are listed from the lowest to the highest order. |
| **MultilineText** | Instructs UI editor to use multiline textbox for editing *string* property or field. |
| **AssetReference** | Specifies a options for an asset reference picker in the editor. Allows to customize view or provide custom value assign policy. |
| **Collection** | This attributes provides additional information on a member collection for the editor. |
| **CustomEditor** | Overrides the default editor provided for the target object/class/field/property. Allows to extend visuals and editing experience of the object. To learn more see [Custom Editors](custom-editors/index.md) docuemntation. |
| **CustomEditorAlias** | Works the same as *CustomEditor* attribute, except uses a typename that can be located in different assembly (not referenced). |
| **ExecuteInEditMode** | Makes a script execute in edit mode. |
| **RequireChildActor** | Automatically adds required child actor as dependencies if not added yet. |
| **VisibleIf** | Shows property/field in the editor only if the specified member has a given value. Can be used to hide properties based on other properties (also private properties). The given member has to be bool type. |
| **DefaultValue** | Can be used to specify the default value for the field or the property. The editor will highlight the modified properties and add an option to restore value to default. You can use it on basic types like: `[DefaultValue(3.14f)] public float MyValue;` or on complex types: `[DefaultValue(typeof(Vector2), "1,2")] public Vector2 StartPosition;`. |
| **ReadOnly** | Properties and fields marked with this attribute won't be editable in the inspector. This allows to show object proeprties values in the editor but without option to modify the value which can be handy in some cases. |
| **Category** | Describes the category name for a type. Can be used to group script, asset or actor types for editor pickers to organize types. |

## Script execution in editor

By using **ExecuteInEditMode** you can enable your scripts to run in Editor. This is useful to generate procedural content for your game from code. Here is an example script that generates a grid of lights in Editor:

### C#
[!code-csharp[Example1](code-examples/attributes.cs)]

### C++
[!code-cpp[Example2](code-examples/attributes.h)]