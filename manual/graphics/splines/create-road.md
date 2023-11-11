# HOWTO: Create road from spline

In the following tutorial, you will learn how to create a road in the scene with collision using spline components.

## Tutorial

### 1. Create a spline

Follow [this](index.md) tutorial and create a simple spline.

![Spline Line Chain](media/simple-spline.png)

### 2. Add model to the spline

*Right-click* on the spline actor in the *Scene* window and select the option **Add spline model**. This will create a spline model rendering actor as a child of the spline. It will draw a model between the spline segments. In this example it will be used to draw road segments.

![Add Spline Model](media/add-spline-model.png)

Now, set the model you want to draw over the spline. You can use one of the built-in primitives, such as a box if you don't have your own road model. Also, remember to use the **Pre Transform** property to adjust the model rotation, scale and translation to the spline so it will look as desired.

![Set Spline Model](media/spline-model-road.png)

If you want to use a custom material for the spline model ensure the **material domain** is set to **Deformable**. In this way a special shader is used to deform the mesh over the spline curve. Also, it supports tessellation to improve model geometry for highly bent meshes.

### 3. Add a collision to the spline

*Right-click* again on the spline actor in the *Scene* window and select the option **Add spline collider**. When this actor is added as a child to a Spline it creates a static collider over that spline's points. Ensure to assign the **Collision Data** to the created collider that matches the object mesh (can be convex or triangle mesh using lower LOD for better performance).

![Add Spline Rope Body](media/add-spline-collider.png)


### 4. It works!

As a final result, the road will have proper collision and model drawing. You can easily arrange the road over the level or terrain. The same technique can be used for rivers or rails. Also, the spline collider supports generating navmeshes so AI can walk over it.

![Spline Road](media/spline-road.png)

![Spline Collision](media/spline-collision.gif)
