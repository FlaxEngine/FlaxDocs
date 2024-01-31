# Scene Data Storage

**Scene Data Storage** is a dedicated folder located in a Content directory that is used to store the private scene asset. Each scene uses its own subdirectory scene data to keep its own assets. When you bake the lightmaps or environment probes, they are stored right in the scene data directory. You can move these assets and reuse them in other parts of the game if you need. For instance, an environment probe cube texture can be used for a skybox.

## Storage

* Content
* SceneData
   * &lt;scene_name&gt;
     * **EnvProbes** - directory with baked environment probes cube textures
     * **Lightmaps** - directory with baked lightmap textures
     * **Terrain** - directory with terrain heightmaps and splatmap textures
     * **CSG_Collision.flax** - CSG mesh collision data
     * **CSG_Data.flax** - additional CSG data
     * **CSG_Mesh.flax** - CSG model
     * **NavMesh.flax** - Navigation Mesh tiles data
