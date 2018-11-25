# HOWTO: Create terrain material

In this tutorial, you will learn how to create and use a custom terrain material that blends between various textures.

## 1. Create new material

In *Content* window use **Right-click** and select option **New -> Material**, then specify its name and hit **Enter**.

![New Material](media/new-material.png)

Then double-click on an asset to open the dedicated editor.

## 2. Set Domain to Terrain

In material properties panel change its **Domain** to **Terrain**.

![Terrain Material Domain](media/terrain-material-domain.png)

## 3. Create material

Add various landscape textures and implement simple linear blending using the texture layer weights (as shown in the picture below).

![Created material](media/terrain-material-example.png)

## 4. Assign material to terrain

Save created material and assign it to the terrain **Material** property.

![Terrain Material](media/terrain-material-set.png)

You can also override per chunk material using the toolbox.

![Terrain Chunk Material Override](media/per-chunk-material-override.png)

## 5. Paint the layers

To use the paint tool select the **Toolbox -> Paint -> Select Layer** and pick the terrain actor to paint over it.

![Paint Terrain Tool](media/paint-layer-tool.png)

Now using the **left mouse button** you can paint over the terrain with the textures you specified in material. 

![Paint Terrain](../media/terrain_pic_08.gif)
