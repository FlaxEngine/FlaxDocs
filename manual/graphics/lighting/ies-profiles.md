# IES Light Profiles

![IES Light Profiles](media/ies_profiles_sample.png)

**IES Profiles** are assets that contain information about light intensity of the light build around the arc. They are used to simulate real-life light emission properties. Using IES Profiles for [Point Lights](light-types/point-light.md) and [Spot Lights](light-types/spot-light.md) adds more realism and is highly recommended for architectural visualizations.

## Importing IES Profiles

Flax supports importing IES Profiles from `.ies` files. The importing process works the same as for other assets except there are no additional import settings.

To get IES profiles, go to the lighting manufacturer's site (e.g. [Philips](http://www.usa.lighting.philips.com/support/support/literature/photometric-data)). Almost all major lighting manufactures provide them free of charge.

## Using IES Profiles

![IES Profile](media/ies.png)

After importing an IES Profile simply drag and drop it to the point or spot light's `IES Texture` property.
Additionally, you can scale the imported IES profile brightness.

![IES Properties](media/ies-properties.jpg)
