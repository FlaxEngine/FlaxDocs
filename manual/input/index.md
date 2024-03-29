# Input

To handle user interactions effectively, games need constant access to input data. In Flax, you can read player inputs by utilizing the Input class.

## Input handling

Flax supports two types of input:
* **Low-level** API: This gives you direct access to the state of connected input devices. (eg. mouse position, gamepad buttons)
* **High-level** API: This uses the [virtual input](virtual-input.md) feature to provide more intuitive and unified input data across different platforms and input devices. (eg. "Move X" axis, "Jump" event)

Games will need to use the C# scripting API to access input data. This can be done by using the [Input](https://docs.flaxengine.com/api/FlaxEngine.Input.html) class. It provides Low Level and High Level input data at runtime and in-editor playmode.

## In this section

* [Virtual Input](virtual-input.md)
* [Input Settings](input-settings.md)
* [Mouse](mouse.md)
* [Keyboard](keyboard.md)
* [Gamepads](gamepads.md)
