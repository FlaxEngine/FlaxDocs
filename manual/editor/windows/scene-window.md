# Scene Window

![Scene Window](media/scene.jpg)

**Scene Window** shows a tree control with full hierarchy of the loaded scenes.
It updates automatically so if you remove or spawn actors at runtime from code all level changes can be seen live.
Also, it supports muli-scene editing.

Every Actor is represented by a tree node (named after the actor).
Scene actors are the root nodes of the tree.
You can expand and collapse the scene hierarchy by using arrow icons on the left of the node names.
To select one or more nodes use **LMB**, **Ctrl + LMB** or **Shift + LMB** to select range of nodes.

If you select and drag the actor or selection of actors you can reorder it or reparent them.

## Context menu

![Context Menu](media/scene-context-menu.jpg)

Use **right-click** to show the context menu for the actor node.
You can copy, paste, cut, duplicate, delete and add new actors using this menu.

## Shortcuts

| Control | Action |
|--------|--------|
| **Up/Down Arrows** | Navigation |
| **Left/Right Arrows** | Collapse/expand the node |
| **Ctrl + LMB** | Add/remove from selection |
| **Shift + LMB** | Select range of nodes |
| **Ctrl + A** | Select all items in a view |
| **Double-right-click** on actor | Moves the editor [viewport](viewport.md) to see this actor |
| **Delete** | Deletes the selected actors |
| **Ctrl + D** | Duplicates selected actors |
| **Ctrl + F** | Starts searching |
| **Ctrl + S** | Saves all the project changes (modified scenes and assets) |
| **Ctrl + Z** | Performs the undo action |
| **Ctrl + Y** | Performs the redo action |
| **Ctrl + X** | Cuts selected actors |
| **Ctrl + C** | Copies selected actors |
| **Ctrl + V** | Pastes copied actors |
| **F5** | Starts in-editor playmode |
| **F11** | Steps one frame during pause in in-editor playmode |
