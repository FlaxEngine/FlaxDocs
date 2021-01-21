# High DPI UI

Modern screens have increasingly higher pixel densities, meaning more pixels in the same area. Such screens are called high DPI (dots per inch) screens. To make UIs have the correct size on such screens, you have to introduce a DPI adjustment.

For example, with a DPI scale of 200%, all UI pixels become twice as large as the pixels on the screen.

For the most part, you don't have to do anything and Flax takes care of everything for you. 

## Screen Space

One pixel in screen space is exactly one pixel on the screen. Screen space also stretches across all monitors.

## Window Space

Window space starts in the top left corner of the window, excluding the title-bar. For FlaxEngine's UIs, this is always DPI-adjusted.

## Local Space

Local space starts in the top left corner of the control. It is also DPI-adjusted.