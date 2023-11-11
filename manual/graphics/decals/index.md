# Decals

![Decals](media/title.png)

**Decals** are special materials that are projected onto the objects of your scene (including models and animated models).
For example, with a blood stain texture and by using a decal you can draw it on top of the player body when it gets hit by a bullet. Another example is to render footsteps on sand when your player walks on it.

## How to create a decal?

To learn how to create and use decals please see the related tutorial [here](create-decal.md).

## Performance

Decals are rendered after the *GBuffer Pass* to inject custom surface properties like the normal vector or color stain.
Flax collects all decals and draws them in batches to improve engine performance. In most cases, you should use the default **Sort Order** as it improves overall performance.

Decals are rendered in screen-space so many decals can be rendered at once without a large performance decrease. Performance decreases with larger screen space size and higher shader instruction count.

