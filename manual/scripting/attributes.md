# Attributes

Flax provides various attributes that are used to extend the default logic or provide metadata about the code (serialization and editing options).

Most of the attributes can be used for both: fields and properties:

```cs
[Limit(0, 10)]
public float Field1 = 11;

[Tooltip("Light color")]
public Color Field2 { get; set; }
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
| **MemberCollection** | This attributes provides additional information on a member collection. |
| **CustomEditor** | Overrides the default editor provided for the target object/class/field/property. Allows to extend visuals and editing experience of the object. To learn more see [Custom Editors](custom-editors/index.md) docuemntation. |
| **CustomEditorAlias** | Works the same as *CustomEditor* attribute, except uses a typename that can be located in different assembly (not referenced). |
| **ExecuteInEditMode** | Makes a script execute in edit mode. |
| **RequireChildActor** | Automatically adds required child actor as dependencies if not added yet. |
| **VisibleIf** | Shows property/field in the editor only if the specified member has a given value. Can be used to hide properties based on other properties (also private properties). The given member has to be bool type. |

## Script execution in editor

By using **ExecuteInEditMode** you can enable your scripts to run in Editor. This is useful to generate procedural content for your game from code. Here is an example script that generates a grid of lights in Editor:

```cs
[ExecuteInEditMode]
public class MyGenerator : Script
{
    private void Start()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 5; z++)
            {
                var light = PointLight.New();
                light.Radius = 1000;
                light.ShadowsMode = ShadowsCastingMode.None;
                light.Position = new Vector3(x * 100.0f, 0, z * 100.0f);
                light.Parent = Actor;
                //light.HideFlags = HideFlags.DontSave; // Uncomment to don't save generated actors
            }
        }
    }
}
```
