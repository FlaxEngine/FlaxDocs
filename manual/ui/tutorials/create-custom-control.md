# HOWTO: Create custom control

In this tutorial, you will learn how to create customized User Interface control for your game. Flax Engine uses UI scripted on a C# side so you can add your own controls and container controls as needed.

## 1. Create `MyControl` script

Add a new script named `MyControl` that will implement the control logic. The C# class need to inherit from [Control](https://docs.flaxengine.com/api/FlaxEngine.GUI.Control.html) type. To learn more about creating and using scripts see [this tutorial](../scripting/new-script.md).

## 2. Edit script

Open script file and write the following code:

```cs
using FlaxEngine;
using FlaxEngine.GUI;

public class MyControl : Control
{
	[EditorOrder(0), Tooltip("Rendered texture tin color. use white as default.")]
	public Color TintColor { get; set; } = Color.Red;

	[EditorOrder(1), Tooltip("The texture to draw.")]
	public Texture Image { get; set; }

	/// <inheritdoc />
	public override void Draw()
	{
		base.Draw();

		Render2D.DrawTexture(Image, new Rectangle(Vector2.Zero, Size), TintColor, true);
	}
}
```

As you can see it exposes a texture property and the tint color used for rendering. Use [Render2D](https://docs.flaxengine.com/api/FlaxEngine.Render2D.html) to perform custom rendering. Also you can override all Control event sto provide any other custom logic for your UI. Feel free to experiment.

## 3. Spawn `UI Control`

Now spawn a new *UI Control* to the scene and set its type to **MyControl** as shwon in a picture below.
To learn more how to do it see the related [tutorial here](create-ui.md).

![Set Control type to MyControl](media/set-control-to-my-control.png)

## 4. Test it out!

Finally, adjust the exposed properties of the control and see the final results.

![Final Results](media/custom-control-results.png)

