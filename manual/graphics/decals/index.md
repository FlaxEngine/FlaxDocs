# Decals

![Decals](media/title.png)

**Decals** are special materials are projected onto the objects of your scene (including models and animated models).
For example, with a blood stain texture and by using decal you can draw it on top of the player body when it gets hit by the bullet. Another example is to render footsteps on a sand when your player walks on it.

## How to create decal?

To learn how to create and use decal please see the related tutorial [here](create-decal.md).

## Performance

Decals are rendered after *GBuffer Pass* to inject custom surface properties like normal vector or color stain.
Flax collects all decals and draws them in batches to improve the performance. In most cases, you should use the default **Sort Order** as it improves overall performance.

Decals are rendered in a screen-space so many decals can be rendered at once without a large performance decrease. Performance decreases with larger screen space size and higher shader instruction count.

