# Custom Editors

**Custom Editors** system is a Flax Editor feature used to present objects data in the editor. It's a layer between the actual objects and the user interface. It handles all user operations, objects editing and undo actions. By using Custom Editors any object type can be visualized in the editor. This helps with creating and editing scenes and scripts for your games.

Flax Editor uses Custom Editors to show selected actors properties in the *Properties* window. It also lists scripts attached. Game developers can write custom editors to extend the default UI and logic of the editor. For example, you can very easily **create a custom editor for your script**. To learn how, see [this tutorial](../tutorials/custom-editor.md).

You can also use custom attributes right insiide your code. See [this documentation page](attributes.md).

Implementation of the Custom Editors is open source (as a part of *Flax Engine*) and can be found [here](https://github.com/FlaxEngine/FlaxEngine/tree/master/Source/Editor/CustomEditors).
