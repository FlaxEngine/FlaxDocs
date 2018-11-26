# Materials Basics

![Graphics](../media/sample-material-instance.jpg)

**Material** defines the appearance of the model surfaces and how they react to light. Each material describes not only it's color but also how it reflects and emits light. All those properties are used by the Flax rendering pipeline to result in realistic lighting (*Physically Based Rendering*).

# Creating new material

1. In the *Content* window navigate to the *Content* folder

2. Right click in the empty area

3. Select option *New* -> *Material*

    ![Creating new material](../media/new-material.jpg)

4. Specify new material name and press *Enter*

5. Double click on a material

    ![Creating new material](../media/my-material.png)

6. [Material Editor](../material-editor/index.md) window shows up

# Material nodes

The first and the most important thing to know about the materials editing is that they are made of nodes. Each node generates a snippet of HLSL code so in that way connected nodes networks outputs full materials source code. This means that user creates a material using visual scripting instead of writing code.

![Sample material](../media/sample-material.jpg)

The above picture shows a sample of mahogany floor surface properties. However it's important to say that the material node's network does not need to be so simple. In many cases, artists create complex materials to achieve the desired look.

To learn more about materials editor you can find documentation in the [Material Editor](../material-editor/index.md) section.

# Using textures

The most common way to supply details to material surfaces is by using **Textures**. In the case of materials, textures are simply images that provide some sort of pixel-based data. This data may be the color of an object, how shiny it is, its transparency, and a variety of other aspects. There is an old-school mode of thought that *texturing* is how you apply color to your game models. While the process of creating textures is still critical, it is important to think of textures as a component of materials, and not as the end result themselves.

A single material may use several different textures for different purposes. For instance, s simple material may have a diffuse color texture, a roughness map and a normal map. 

To use texture in a material, simply drag & drop it from the *Content* window into the material surface. It will automaticly create a proper texture sampling node. Alternativly you can create new *Texture* or *Normal Map* node.

![Sample material](../media/texture-node.png)

To learn more about textures pipeline you can find documentation in the [Textures](../../textures/index.md) section.

# Applying material to model

There are several ways to apply material to the model:

- *Drag & Drop* material asset right onto the model

![Apply material](../media/apply-material-1.jpg)

- *Drag & Drop* material asset into the properties window

![Apply material](../media/apply-material-2.jpg)

- Assign material to the model material slot

![Apply material](../media/apply-material-3.jpg)

- Set material using C# script

```cs
public class SetMaterial : Script
{
    [Tooltip("Material to assign to the model")]
    public Material Material;

    void Start()
    {
        ((StaticModel)Actor).Entries[0].Material = Material;
    }
}
```

