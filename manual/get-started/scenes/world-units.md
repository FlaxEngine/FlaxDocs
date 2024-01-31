# World Units

![World Grid](media/world-grid.png)

Flax uses **centimeters** as a unit of length and **kilograms** as a unit of weight.  
These world units are used by both the physics and rendering engines.  
You should stick to using realistic values in order to create solid visual and physical behaviours for the objects.

## Coordinate system

Flax uses a **left-handed** coordinate system. Where each axis points:

* **X** axis - *right* direction
* **Y** axis - *up* direction
* **Z** axis - *forward* direction

## Math library

Flax uses **row-major matrices** and row vectors.
However, Flax tries to use [Transform](https://docs.flaxengine.com/api/FlaxEngine.Transform.html) structure as much as possible when it comes to objects' transformation representation, as it is easier to work with and has better precision in some cases. Transformation order is always: **Translate** -> **Rotate** -> **Scale** (TRS style).
Euler angles are stored in order: **pitch - yaw - roll** (x, y, z).
