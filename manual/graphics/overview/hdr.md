# HDR Output

HDR output is a feature that presents the output image to display in High Dynamic Range (HDR) on HDR-capable screens. When `EnableHDR` is checked in [Graphics Settings](../../editor/game-settings/graphics-settings.md), Flax creates window swap chains with HDR output enabled, provided the platform, display, and rendering backend. If the swap chain cannot present in the requested color space, it logs a warning and falls back to Standard Dynamic Range (SDR).

Currently supported platforms and backends:

* Windows: DirectX 11, DirectX 12

## Color Space

When HDR is enabled, the window swpchain uses backbuffer format of `R16G16B16A16_Float` using **scRGB**: full-range, linear-light RGB using Rec. 709 primaries (`DXGI_COLOR_SPACE_RGB_FULL_G10_NONE_P709` on Windows). The HDR swap chains use the DXGI flip presentation model.

The post-processing pass converts the final scene color to scRGB. The shader multiplies linear scene color by a luminance scale in nits, then converts nits to scRGB units by dividing by **80 nits** (the scRGB D65 reference white). For gamma-space color grading, it first decodes the color from sRGB to linear (if used in Graphics Settings).

## Luminance values

When HDR is active, the output scene colors are scaled to cover whole luminance range reported by the output display. **Reference point is 80 nits** value which represents the D65 white point (`1, 1, 1`) in scRGB. For example, if display supports max `400` nits, then colors will cover range up to `5` units ( `400 / 80 = 5`). Post-processing applies this scale to the tone-mapped scene before conversion to scRGB. Thus a normalized scene value of 1 maps to the selected scale; higher or lower tone-mapped values scale proportionally.

User Interface (UI) uses sRGB colors to draw directly into the backbuffer. When HDR is enabled those colors are converted to linear color space and then to scRGB using a fixed **203-nit reference white** (BT.2408). White UI therefore becomes `203 / 80` (about **2.54**) scRGB units, independent of the display's reported peak luminance.

> [!Tip]
> A nit is one candela per square meter (cd/m²). The values above are engine output scaling targets; actual perceived brightness depends on the display and its HDR configuration.

## Available Displays

You can get the available [video output displays](https://docs.flaxengine.com/api/FlaxEngine.GPUDevice.VideoOutput.html) using the following code:

# [C#](#tab/code-csharp)
```cs
GPUDevice.VideoOutput[] outputs = GPUDevice.Instance.VideoOutputs;
```
# [C++](#tab/code-cpp)
```cpp
#include "Engine/Graphics/GPUDevice.h"

const Array<GPUDevice::VideoOutput>& outputs = GPUDevice::Instance->VideoOutputs;
```
***
