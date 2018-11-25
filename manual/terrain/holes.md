# Terrain Holes

![Terrain Holes](media/terrain_pic_07.gif)

Flax supports creating **per-vertex holes in terrain**. Holes mask is stored in the terrain patch heightmap texture as *invalid normals*. This packing methods allows keeping terrain height valid without quality loss except the normal vectors around the terrain holes which are using fixed value of `(0, 0, 1)` that points up (in world-space).

Terrain collision cooking samples the heightmap and produces holes in the collider shape to keep visual and physical appearance in pair. As a result objects can fall though the terrain holes.

Holes can be painted using the ediotr tool in **Toolbox -> Landscape -> Sculpt -> Tool Mode -> Holes**. After selecting the **Holes Mode** you can use the mouse to add holes to the terrain. If you hold **Control** key then you can revert holes and clear the mask.

In order to see the holes in the terrain its material needs to support masking the areas using the holes layers. To achieve it use material **Mask** property and **Terrain Holes Mask** node as shown below:

![Holes Material](media/terrain-holes-material.png)

To learn more about creating and using terrain holes please see the related tutorial [here](tutorials/terrain-holes.md).

