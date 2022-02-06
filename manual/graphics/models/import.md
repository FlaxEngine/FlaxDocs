# Importing models

Importing model files works in the same way as for other asset types. Simply drag and drop the model files from *Explorer* into the *Content* window or use the *Import* button.

![Importing Model](media/import-model.jpg)

After choosing the files **Import file settings** dialog shows up. It's used to specify import options per model. In most cases the default values are fine and you can just press the **Import** button.

> [!Note]
> Using **Import file settings** dialog you can select more than one model at once (or use **Ctrl+A** to select all) and specify import options at once.

Every model can be reimported (relative path to the source file is cached) and import settings modified using [Model Window](model-window.md).

## Supported file types

Flax Engine supports importing the following list of file types as models:
- `.fbx` - currently recommended format
- `.gltf`
- `.glb`
- `.obj`
- `.x`
- `.dae`
- `.blend`
- `.lwo`
- `.lws`
- `.lxo`
- `.ply`
- `.q3o`
- `.q3s`
- `.stl`

## Importing model LODs

Flax supports up to 6 model level of details. To import them use `LODx` (where `x` is a LOD index, zero-based) postfix for object nodes in model file. Also when importing model ensure to check the **Import LODs** option.

Example usage (from Blender):

![Model LODs import example](media/model-lods-example.jpg)

## Importing collision mesh

Flax supports automatic collision mesh importing from a source model. To import it use a custom name prefix for collision meshes in the model file (eg. `COLL_` or `UCX_` prefix) and specify that prefix in the import option **Collision Meshes Prefix**. The engine will extract those collision meshes and create a separate collision data asset

Example usage:

![Model Collsion import engine](media/collision-mesh.png)

For ease of use after you add a model on a scene you can use *Right-click* and select option **Add mesh collider**. Then the editor will automatically pick up the imported collision mesh (or generate a new one) and add it to the model on a scene so it has a collision for physics.

## Model import settings

![Models](media/imort-model-settigns.jpg)

Flax uses the same import settings data scheme for **models**, **skinned models** and **animations** as they all can be imported from the same source files (eg. `.fbx` or `.dae`).

| Property | Description |
|--------|--------|
| **Type** | The type of the imported asset. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Model**</td><td>The model asset.</td></tr><tr><td>**Skinned Model**</td><td>The skinned model asset.</td></tr><tr><td>**Animation**</td><td>The animation asset.</td></tr></table></tbody> |
|||
| **Geometry** ||
| **Calculate Normals** | If checked, model normal vectors will be recalculated. |
| **Smoothing Normals Angle** | Specifies the maximum angle (in degrees) that may be between two face normals at the same vertex position that their are smoothed together. Used only if *Calculate Normals* is checked. The default value is 175. |
| **Calculate Tangents** | If checked, model tangent vectors will be recalculated. |
| **Smoothing Tangents Angle** | Specifies the maximum angle (in degrees) that may be between two vertex tangents that their tangents and bi-tangents are smoothed. Used only if *Calculate Tangents* is checked. The default value is 45. |
| **Optimize Meshes** | If checked, model meshes geometry will be optimized. Duplicated or invalid vertices will be removed. Index buffer will be reordered to improve performance and other modification will be applied. However, importing time will be increased. |
| **Merge Meshes** | If checked, meshes with the same materials will be merged. Helps with rendering performance. |
| **Import LODs** | If checked, model importer will try to find LODs and import them. See *Importing model LODs* section to learn more. |
| **Import Vertex Colors** | If checked, vertex colors will be imported (channel 0 only, if exists). |
| **Import Blend Shapes** | If checked, blend shapes will be imported (morph targets). |
| **Lightmap UVs Source** | Specifies model lightmap texture coordinates source. Can import them from the source model or generate them with in-build tool. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Disable**</td><td>Don't use lightmap UVs.</td></tr><tr><td>**Generate**</td><td>Generate lightmap UVs from model geometry. Requires proper normal/tangent vectors. Highly increases the importing time.</td></tr><tr><td>**Channel 0**</td><td>Use input mesh texture coordinates channel 0.</td></tr><tr><td>**Channel 1**</td><td>Use input mesh texture coordinates channel 1.</td></tr><tr><td>**Channel 2**</td><td>Use input mesh texture coordinates channel 2.</td></tr><tr><td>**Channel 3**</td><td>Use input mesh texture coordinates channel 3.</td></tr></table></tbody>|
| **Collision Meshes Prefix** | If specified, all meshes which name starts with this prefix will be imported as a separate collision data (excluded used for rendering). |
|||
| **Transform** ||
| **Scale** | Custom uniform scale applied to the imported model data. |
| **Rotation** | Custom import geometry rotation applied to the imported model data. |
| **Translation** | Custom import geometry offset applied to the imported model data. |
| **Center Geometry** | If checked, the imported geometry will be shifted to the center of mass. |
|||
| **Animation** ||
| **Duration** | Specifies the imported animation duration mode. Can use the original value or overriden by settings. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Imported**</td><td>The imported duration.</td></tr><tr><td>**Custom**</td><td>The custom duration specified via keyframes range.</td></tr></table></tbody>|
| **Frames Range Start** | Imported animation first frame index. Used only if Duration mode is set to Custom. |
| **Frames Range End** | Imported animation last frame index. Used only if Duration mode is set to Custom. |
| **Default Frame Rate** | The imported animation default frame rate. Can specify the default frames per second amount for imported animation. If value is 0 then the original animation frame rate will be used. |
| **Sampling Rate** | The imported animation sampling rate. If value is 0 then the original animation speed will be used. |
| **Skip Empty Curves** | If checked, the imported animation will have removed tracks with no keyframes or unspecified data. Disable it to leave the data as it is. |
| **Optimize Keyframes** | If checked, the imported animation channels will be optimized to remove redundant keyframes. This option helps with getting better animation sampling performance. |
| **Enable Root Motion** | If checked, enables root motion extraction support from this animation. |
| **Root Node Name** | The custom node name to be used as a root motion source. If not specified the actual root node will be used. |
|||
| **Generate LODs** | If checked, the importer will generate a sequence of LODs based on the base LOD index. |
| **Base LOD** | The index of the LOD from the source model data to use as a reference for following LODs generation. |
| **LOD Count** | The amount of LODs to include in the model (all remaining ones starting from Base LOD will be generated). |
| **Triangle Reduction** | The target amount of triangles for the generated LOD (based on the higher LOD). Normalized to range 0-1. For instance 0.4 cuts the triangle count to 40%. |
|||
| **Import Materials** | If checked, the importer will create materials for model meshes as specified in the file. |
| **Import Textures** | If checked, the importer will import texture files used by the model and any embedded texture resources. |
| **Restore Materials On Reimport** | If checked, the importer will try to restore the assigned materials to the model slots. |
|||
| **Split Objects** | If checked, the imported mesh/animations are splitted into separate assets. Used if *Object Index* is set to -1. |
| **Object Index** | The zero-based index for the mesh/animation clip to import. If the source file has more than one mesh/animation it can be used to pick a desire object. The default `-1` imports all objects. |

## Tips

If the model appears to be missing something or there is more than you expected make sure the model you imported is in fact what you believe it is. For example Blender defaults to export everything unless you tick the "selection only" box. An easy way to check that is to import the file back in your modeller.

If you want to import all animation clips from the source file or import all model meshes as separate assets use **Split Objects** option. It will split the source objects from the model file and import them as separate assets. It will support reimporting them easily with as each splited object gets own **Object Index** auto-assigned.
