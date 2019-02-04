# Foliage Types

Each foliage actor contains a list of types that it uses. This helps editing many instances at the same time and share data for them to improve overall performance. Use **Foliage** tab to add/remove/modify foliage types contained in the selected foliage actor.

## Properties

| Property | Description |
|--------|--------|
| **Model** | Model to draw by all the foliage instances of this type. It must be unique within the foliage actor and cannot be null. |
| **Materials** | Model materials override collection. Can be used to change a specific material of the mesh to the custom one without editing the asset. |
|||
| **Cull Distance** | The per-instance cull distance. |
| **Cull Distance Random Range** | The per-instance cull distance randomization range (randomized per instance and added to master CullDistance value). |
| **Shadows Mode** | The shadows casting mode. |
| **Receive Decals** | Determines whenever this meshes can receive decals. |
| **Use Density Scaling** | Flag used to determinate whenever use global foliage density scaling for instances of this foliage type. |
| **Density Scaling Scale** | The density scaling scale applied to the global scale for the foliage instances of this type. Can be used to boost or reduce density scaling effect on this foliage type. |
|||
| **Density** | The foliage instances density defined in instances count per 1000x1000 units area. |
| **Radius** | The minimum radius between foliage instances. |
| **Paint Ground Slope Angle Range** | The minimum and maximum ground slope angle to paint foliage on it (in degrees). |
| **Scaling** | The scaling mode. |
| **Scale Min** | The scale minimum values per axis. |
| **Scale Max** | The scale maximum values per axis. |
|||
| **Offset Y** | The per-instance random offset range on axis Y (min-max). |
| **Random Pitch Angle** | The random pitch angle range (uniform in both ways around normal vector). |
| **Random Roll Angle** | The random roll angle range (uniform in both ways around normal vector). |
| **Align To Normal** | If checked, instances will be aligned to normal of the placed surface. |
| **Random Yaw** | If checked, instances will use randomized yaw when placed. Random yaw uses will rotation range over the Y axis. |
