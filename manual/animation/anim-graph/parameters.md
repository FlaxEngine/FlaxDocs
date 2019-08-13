# Anim Graph Parameters

Anim Graph parameters are **public variables** of the graph which can be modified from the outside to configure its logic.
For example, you can create a parameter called **Speed** and use it to blend between *Run* and *Walk* animations fo your character to implement the proper animation playback for your game.

Using graph parameters allow you to implement desired gameplay features and extend the default skeleton animation playback in order to use Inverse-Kinematics (IK), transform single bone or simply blend between the set of animations using the parameters passed from the C# source. It is a very common technique to create the player animation controller script and pass the animation control variables like `Move Forward`, `Move Right`, `Is Jumping` to the graph and implement the proper animation logic.

## Creating and using parameters

![Anim Graph Edit Param](../tutorials/media/add-param-button.jpg)

Creating graph parameters is done using the [Anim Graph Editor Window](interface.md) which contains a dedicated panel with properties.
To do it simply specify the parameter type (with combo box menu) and click the **Add parameter** button. It will add a new parameter. You can rename or remove the created parameters by using the dedicated context menu. Simply right click on a parameter name label. You can also specify the default value for the parametrs.

![Anim Graph Edit Param](../tutorials/media/anim-param-edit.jpg)

To access this parameter in the graph spawn the **Get Parameter** node and then select your parameter from the dropdown menu.

![Anim Graph Get Param](../tutorials/media/get-param-node-add.jpg)

After that connect your parameter outputs with the other nodes to implement the desired usage. In this example, the **Head Scale** parameter is used to scale the skeleton bone using the **Transform Bone (local space)** node. Note that Anim Graph supports implicit type casting so the value type **float** gets converted into the **Vector3** type which is used for the bone transformation scale.

![Anim Graph Get Param](../tutorials/media/get-param-node-use.png)

## Using Anim Graph parameters from code

Created Anim Graph parameters can be accessed from C# script. You can cache the graph parameters, iterate over them and access from any part of your code. Here is an example code that updates the single graph parameter.

```cs
using FlaxEngine;

public class EditAnimGraphParam : Script
{
	[Range(0.5f, 2.5f)]
	public float HeadScale  = 1.0f;

	private AnimationGraphParameter _parameter;

	public override void OnStart()
	{
		// Cache the parameter handle
		_parameter = Actor.As<AnimatedModel>().GetParam("Head Scale");
	}

	public override void OnUpdate()
	{
		// Update the value
		_parameter.Value = HeadScale;
	}
}
```

Result:

![Anim Graph Param Edit](../tutorials/media/edit-anim-graph-param-code.gif)
