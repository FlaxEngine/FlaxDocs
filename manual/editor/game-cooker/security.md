# Game Data Security

This page covers various aspects of the game data and code files that are deployed during game cooking for distribution.

## Assets

During game cooking, all assets used by the game are collected, processed, and packaged into `.flaxpac` files. It's a custom binary format that allows storing multiple assets in a single file with support for:
* random-data-access from multiple Content Loading threads (at runtime)
* in-built data compression (eg. *LZ4*),
* metadata-storage (eg. asset header, asset dependencies cache),
* asset chunks remapping (eg. custom asset chunks placement in a file).

[Build Settings](../../editor/game-settings/build-settings.md) allows to configure the packaging process by adjusting maximum package size and amount of assets packed into a single file.

### Binary Assets

Binary assets (`BinaryAsset`) are usually packaged as-it-is after processing. This depends on the asset type, for instance:
* **textures** can be converted into the other format for some platforms (eg. Android) or down-scaled based on the [texture groups settings](../../graphics/textures/texture-groups.md),
* **shaders** are pre-compiled thus no shader source code is even deployed (no runtime shaders compilation),
* **materials, particle emitters** are precompiled into destination platform shader bytecode (shader source code is removed).

### Json Assets

Json assets (`JsonAssetBase`) are compressed using *LZ4* algorithm (internally) and stored in compressed format. At runtime data is automatically decompressed and parsed into the Json for further processing (eg. settings loading or scene deserialization). This reduces the built game size (compressed text weights far less) and improves game performance (less data to read from a drive, data is compressed in memory).

### Custom Assets

Custom assets can be processed for game cooking with `CookAssetsStep::AssetProcessors`.

## Code

Depending on the scripting language used in the game project it might be more or less secure. There are several actions that can increase the final security of the game but remember that it might be very hard or nearly impossible to secure the game fully.

### C#

Game code is compiled into .Net assemblies - separate for each binary module such as `Game.CSharp.dll` (default). Thus no source code is deployed with the game. However, C# DLLs can be easily decompiled with the various tools which make it insecure. Possible ways to overcome this:
* [Obfuscation](https://en.wikipedia.org/wiki/Obfuscation_(software)) tools (eg. [Eazfuscator.NET](https://www.gapotchenko.com/eazfuscator.net), [ConfuserEx](https://yck1509.github.io/ConfuserEx/), [neo-ConfuserEx](https://github.com/XenocodeRCE/neo-ConfuserEx), [Babel Obfuscator](https://www.babelfor.net/products/babel-obfuscator/), etc.) - those can mangle code-flow, variable names, constants, and types. But if the class typenames or field/properties get renamed it might lead to incorrect deserialization when loading scenes or prefabs. For this case [Serialization Callbacks](../../scripting/serialization/index.md) can be used to load the data from the asset for runtime.
* [Code signing](https://en.wikipedia.org/wiki/Code_signing) - after project compilation all game DLLs can be signed with a code-signing certificate which allows validating the file upon the execution to prevent hacking game files (at least partially).
* Critical-code could be moved into C++ scripts which are compiled directly into the platform bytecode.

### C++

Native C++ game code is compiled directly into the target platform executable format (eg. `.dll`, `.so`, `.dylib`, etc.). In `Release` mode there is **no debug information** and all **code optimizations are enabled** in the compiler. This results in secure code in a way it's unable to decompile and very hard to hack.

### Visual Script

Visual Scripts are stored in binary format as *Visject Surface* that is a common format for various graph asset types in Flax (materials, particles, animations, etc.). Currently, there is no post-processing of those files (aside from packaging into `.flaxpac` files) which makes them vulnerable.

## Platform-specific

Various platforms implement different techniques to improve the security of the game. For instance, consoles such as Switch, Xbox, or Playstation support encryption of the game package and restrict the user access to those files. However, in most cases (Windows, macOS, Linux, Android) game files are in DRM-free format. Any additional protection might be provided by the game store platform (eg. GOG).