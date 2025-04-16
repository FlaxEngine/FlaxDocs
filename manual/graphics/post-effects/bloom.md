# Bloom

![Bloom](media/bloom.png)

The **Bloom** effect searches for the bright areas of the input image to extend and bleed into the surrounding area. This simulates bright light overwhelming the camera so bright objects start to glow.

## Properties

![Properties](media/bloom-properties.jpg)

| Property | Description |
|--------|--------|
| **Enabled** | If checked, the bloom effect will be rendered. |
| **Intensity** | Bloom effect strength. Set a value of 0 to disabled it, while higher values increase the effect. |
| **Threshold** | Luminance threshold where bloom begins. |
| **Threshold Knee** | Controls the threshold rolloff curve. Higher values create a softer transition. |
| **Clamp** | Maximum brightness limit for bloom highlights. |
| **Base Mix** | Base mip contribution for wider, softer bloom.
| **High Mix** | High mip contribution for tighter, core bloom. |
