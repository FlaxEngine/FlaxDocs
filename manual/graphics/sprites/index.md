# Sprites

**Sprites** are assets that contain an image comprised of pixel data. They are mainly used for GUI implementation and can be animated. A sprite can be a singular image or an image composed of multiple frames. When a sprite contains multiple images or frames it is known as a sprite atlas.

Flax Engine supports importing the following list of file types as sprites:
- `.png`
- `.jpg`
- `.jpeg`
- `.bmp`
- `.gif`
- `.tga`
- `.tif`
- `.tiff`
- `.dds`
- `.hdr`
- `.raw`

## Importing a sprite

The easiest way to import one or more sprites is to drag them from *Explorer* to the *Content* window.

![Importing Sprites](media/sprites-01.jpg)

Alternatively, you can use **Import** button in a *Content* window toolbar and then select files to import.

After choosing the files **Import file settings** dialog shows up. It's used to specify import options per sprite. In most cases the default values are fine and you can just press the **Import** button.

After importing a sprite you will be prompted with a dialogue box for import settings. If this sprite is a sprite atlas, you will need to select the **Is Atlas** option. Additionally, if you wish to import the sprite with transparencies intact, for example from a .png, select the **RBGA** option to include the Alpha channel in the import. After importing the sprite, Flax Editor will convert the sprite to binaries.

![Sprite Import Settings](media/sprites-02.jpg)

The sprite should now be imported.

![Imported Sprite](media/sprites-03.jpg)

## Modifying a sprite atlas

A sprite atlas refers to both the sprite and frame data. Currently frame data can be entered in one of two ways. One method is to enter frame location and size values after clicking the "+" icon. Once a frame has been added you can enter location and size values on the right-side navigation. Another method for adding a frame to the atlas is through code, the API reference is [here](https://docs.flaxengine.com/api/FlaxEngine.SpriteAtlas.html#FlaxEngine_SpriteAtlas_AddSprite).

