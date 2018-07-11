# Fonts

![Font](media/title.jpg)

**Font Assets** are binary resources that contain font characters description (and/or prerendered characters texture).
Flax performs required importing, loading and rasterization of the font glyphs. Fonts are used by 3D [Text Render](../text-render/index.md) actor, as well as, [UI](../index.md) system.

Flax uses **FreeType** library for font characters rasterization and offline rendering.

## Importing fonts

You can import font files to use as font assets in your project. Flax Engine supports importing the following list of file types as fonts:

* `.ttf`
* `.otf`

The easiest way to import one or more fonts is to drag them from Explorer to the *Content Window*.
Alternatively, you can use **Import** button in a *Content Window* toolbar and then select files to import.

## Font Window

**Double-click** on an imported Font asset in *Content Window* to open the dedicated font asset tool window.
You can use it to type the text and preview the font characters.

![Font Window](media/font-window.png)
