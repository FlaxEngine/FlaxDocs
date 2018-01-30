# Material Inputs

This page explains all the material inputs. By connecting values to these inputs (e.g. constants, textures, and parameters), you can define almost any physical surface.

Not all material inputs are used all the time. For instance, *Unlit* material uses only Emissive, Mask and Position Offset, since rest of the inputs is not applicable. It's important to keep know this during creating new materials.

![Graphics](media/main_node.png)

## Color

The **Color** input defines material surface base color. It's a `Vector3` value (*RGB* format).
For non-metal materials it defines diffuse color. For metals, it's used as a specular color of the surface.

![Material Color](media/material-color.png)

## Mask

The **Mask** input allows to clip material pixels that are under certain value (see *Mask Threshold* in [Material Properties](material-properties/index.md)). Unlike *Opacity*, mask can be used also for opaque materials which makes it a perfect solution when you need materials that define complex solid surfaces such as wire mesh, chain link fences, and so on. The opaque portions will still respect lighting.
The default value is 1.

![Material Mask](media/material-mask.png)

## Emissive

The **Emissive** input defines material surface light emission. It's a HDR `Vector3` value (*RGB* format) so values greater  than 1 are allowed as HDR lighting is supported.
Materials using this property may appear to glow because they are emitting light. Also if object using emissive material is marked as static (see [StaticFlags](http://docs.flaxengine.com/api/FlaxEngine.StaticFlags.html)) then light emission will be handled properly in static lighting.

![Material Emissive](media/material-emissive.png)

## Metalness

The **Metalness** input simply controls how *"metal-like"* surface is. Non-metals use values of 0, metals have metalness values of 1. For pure surfaces, such as pure metal, pure stone, pure plastic, etc. this value will be 0 or 1, not anything in between. When creating hybrid surfaces like corroded, dusty, or rusty metals, you may find that you need some value between 0 and 1.
The default value is 0.

![Material Metalness](media/material-metalness.png)

## Specular

The **Specular** input can be used to increase or decrease the specular highlight of the material.
The default value is 0.5.

![Material Specular](media/material-specular.png)

## Roughness

The **Roughness** input controls how *"rough"* surface is. More glossy materials (roughness near 0) will reflect more light, while rough materials (roughness near 1) will appear completely matte or diffuse.
The default value is 0.4.

![Material Roughness](media/material-roughness.png)

## Ambient Occlusion

The **Ambient Occlusion** input helps with simulating the self=shadowing effect that happens within certain surface types. Generally, this input will be connected to an AO map of some type, which is often created within 3D modeling packages such as *Maya*, *3ds Max*, or *ZBrush*.
The default value is 1.0.

![Material Ambient Occlusion](media/material-ao.png)

## Normal

The **Normal** input defines macro surface normals. It takes the *normal map* to provide per-pixel normal perturbation of the normal vector of the mesh. Normal maps create the appearance of bumps and indents in the surface.

![Material Normal](media/material-normal.png)

## Opacity

The **Opacity** input controls the transparency of the surface. Value 0 defines a completely transparent object, while value 1 represents the fully opaque surface. The higher value, the more visible object will be.
The default value is 1.

![Material Opacity](media/material-opacity.png)

## Refraction

The **Refraction** input controls simulation of the light refraction of the surface. This is useful for creating glass and water materials which refract light that passes through them. One of the most common examples is to use material node *Fresnel* and lerp between two values (for e.g. 1 and 1.4) to create realistic glass effect on a transparent material.
The default value is 1.

![Material Refraction](media/material-refraction.png)

## Position Offset

The **Position Offset** input allows moving rendered geometry vertices in world space. This is especially useful for making objects move, change shape, rotate or morph. It can be also used for ambient animation.

![Material Position Offset](media/material-vertex-offset.png)
