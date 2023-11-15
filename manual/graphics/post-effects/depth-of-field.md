# Depth of Field

![Depth of Field](media/depth-of-field.png)

The **Depth of Field** effect simulates the behavior of a real-life camera lens focusing on an object. This effect blurs image areas that are out of focus and generates Bokeh shapes. It really helps with creating realistic looking scenes and is one of the most important parts of a game's cut-scenes.

## Properties

![Properties](media/depth-of-field-properties.jpg)

| Property | Description |
|--------|--------|
| **Enabled** | If checked, the depth of field effect will be visible. |
| **Blur Strength** | The blur intensity in the out-of-focus areas. Allows reducing the blur amount by scaling down the Gaussian Blur radius. Normalized to a range of 0-1. |
| **Focal Distance** | Distance from the camera (in world units) to the center point of the focus area. |
| **Focal Region** | Controls the length of the focal region (in world units). |
| **Near Transition Range** | Near camera blur transition distance (in world units). |
| **Far Transition Range** | Far camera blur transition distance (in world units). |
| **Depth Limit** | The maximum pixel depth to be affected by the depth of field (in world units). Useful for stopping the effect on sky and skyboxes. |
| **Bokeh Enable** | If checked, bokeh shapes will be rendered. |
| **Bokeh Size** | Controls the size of the bokeh shapes. |
| **Bokeh Shape** | Defines the type of the bokeh shapes. Possible options: <table><tbody><tr><th>Option</th><th>Description</th></tr><tr><td>**Hexagon**</td><td>The hexagon shape.<br>![Hexagon](media/Bokeh/Bokeh_Hex.png)</td></tr><tr><td>**Octagon**</td><td>The octagon shape.<br>![Octagon](media/Bokeh/Bokeh_Oct.png)</td></tr><tr><td>**Circle**</td><td>The circle shape.<br>![Circle](media/Bokeh/Bokeh_Circle.png)</td></tr><tr><td>**Cross**</td><td>The cross shape.<br>![HexaCrossgon](media/Bokeh/Bokeh_Cross.png)</td></tr><tr><td>**Custom**</td><td>A custom texture shape (uses the *Bokeh Shape Custom Texture* property).</td></tr></tbody></table>|
| **Bokeh Shape Custom Texture** | If *Bokeh Shape* is set to **Custom**, then this texture will be used for the bokeh shapes. For best performance, use small, compressed, grayscale textures (for instance 32px). |
| **Bokeh Brightness Threshold** | The minimum pixel brightness to create the bokeh. Pixels with lower brightness will be skipped. |
| **Bokeh Blur Threshold** | Controls Bokeh shape blur threshold value. |
| **Bokeh Falloff** | Controls bokeh shape brightness falloff. Higher values reduce bokeh visibility. |
| **Bokeh Depth Cutoff** | Controls bokeh shape generation for depth discontinuities. |
