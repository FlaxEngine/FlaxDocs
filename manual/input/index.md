# Input

Reading the game input is the most essential part of providing user interactions in games. Every application must support at least one input device.

## Input handling

Flax supports two types of input:
* **Low-level** API used to read the state from the input devices directly (eg. mouse position, gamepad buttons)
* **High-level** API using the [virtual input](virtual-input.md) layer to provide more unified input events and data across different platforms and input devices

Games use C# scripting API to access the input data. The most of it can be done by using [Input](https://docs.flaxengine.com/api/FlaxEngine.Input.html) service. It provides input data in both, at runtime and in-editor playmode.

## In this section

* [Virtual Input](virtual-input.md)
* [Input Settings](input-settings.md)
* [Mouse](mouse.md)
* [Keyboard](keyboard.md)
* [Gamepads](gamepads.md)
