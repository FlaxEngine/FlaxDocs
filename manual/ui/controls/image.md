# Image

![Image](media/image.png)

The **Image** control displays a non-interactive graphic defined by the assigned brush. It can draw a texture, render target, sprite, GUI material, solid color or a linear gradient.
To change the texture from code, assign new TextureBrush(newTexture) to the Brush parameter of Image.
For example: portraitImage.Get<Image>().Brush = new TextureBrush(portraitTexture);
