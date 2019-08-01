# Particle Materials

![Particle Materials](media/particle-material.png)

Particles rendering uses a dedicated shader domain that supports sprite, model and ribbon particles. To use custom material for your particles ensure to select **Domain** to **Particle** in *Material Window*.

![Particle Material Domain](media/particle-material-domain.jpg)

## Particle Attributes

Particle materials can easily access any attribute of the rendered particle. You can use predefined nodes such as **Particle Color**, **Particle Normalized Age**, or **Particle Mass**. If your particle system uses any custom attributes shader can read them via **Particle Attribute** node. Simply specify the attribute name and type and the data will be available to read.

![Particle Attribute](media/particle-attribute.png)

## Sprite sheet animation

Many particle systems such as smoke, fire, and explosions use sprite sheet to animate the particle texture over time. To do so simply use **Flipbook** node that implements sampling the sprite sheet.

![Sprite Sheet](media/sprite-sheet.png)
