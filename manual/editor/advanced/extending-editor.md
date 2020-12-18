# Extending Flax Editor

Flax Editor runs on top of the Flax Engine and is an open-source project hosted [here](https://github.com/FlaxEngine/FlaxEngine). Any contributions are welcome. However, there are other ways to extend the Editor for your needs. It's very common technique to customize the script editors and provide custom tool windows directly from your game source.

## Custom Editors

Flax Editor features the **Custom Editors pipeline** which helps building interactive GUI and script editors.
Read the [Custom Editors](../../scripting/custom-editors/index.md) documentation to learn more.

## Custom editor windows

You can also create custom tool windows. Those can be used for example to spawn procedural geometry or to show your plugin options. To learn more about it see tutorial [HOWTO: Create a custom editor window](../../scripting/tutorials/custom-window.md).

## Editor plugins

Flax Editor supports external plugins to be loaded and used. Plugins can extend the default editor functionalities and provide additional services, like custom gizmo tool or meshes merging plugin. To learn more about it see tutorial [HOWTO: Create a custom editor plugin](../../scripting/tutorials/custom-plugin.md).






