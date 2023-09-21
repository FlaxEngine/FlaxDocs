# Keyboard

**Keyboard** is the most common input device on desktop platforms. You can access the keyboard state by using the Input service:
* [Input.InputText](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_InputText)
* [Input.GetKey](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GetKey_FlaxEngine_KeyboardKeys_)
* [Input.GetKeyDown](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GetKeyDown_FlaxEngine_KeyboardKeys_)
* [Input.GetKeyUp](https://docs.flaxengine.com/api/FlaxEngine.Input.html#FlaxEngine_Input_GetKeyUp_FlaxEngine_KeyboardKeys_)

## Usage

In your C# script you can handle keyboard inputs:

```cs
public override void OnUpdate()
{
	if (Input.GetKey(KeyboardKeys.E))
	{
		Debug.Log("E key is pressed.");
	}
}
```

