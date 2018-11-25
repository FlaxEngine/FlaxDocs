# Terrain Materials

Terrain uses a dedicated shader type for geometry rendering. It's more optimized and focused on performant landscape rendering with seamless Continous LOD support and material layers blending.

Terrain materials are similar to **Surface** materials with features like a deferred pipeline, full PBR and tessellation support. However, instead of processing model meshes geometry triangles they use precreated flat chunk grids and move uniform grid vertices based on terrain heightmap. All math is done in a Vertex Shader at low-cost.

To learn more about creating and using terrain materials please see the related tutorial [here](tutorials/terrain-material.md).

## Terrain Domain

To change your material into terrain-capable material just modify its domain to **Terrain**.

![Terrain Domain Material](tutorials/media/terrain-material-domain.png)

Then you can use terrain layer weights and terrain holes mask node to implement specific features.

![Terrain Material Example](tutorials/media/terrain-material-example.png)

<p>
![Terrain Holes Mask](media/terrain-holes-material.png)
</p>
