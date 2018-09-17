# Open Source C# API

![FlaxAPI](media/repo-title.png)

The main open-source repository [FlaxAPI](https://github.com/FlaxEngine/FlaxAPI) contains full source code of the Flax Editor and C# scripting API. You can fork it and edit whatever you need. Modified API and Editor can be used in Flax games production so it can be very handy to have mor control over the engine. Also any pull requests are welcome.

## Custom Editor or/and API

Open source C# Editor and API can be forked and modified to be customized by you and your team. Also, modified code can be used as a Pull Request to introduce new features into the engine. We kindly support that.

If you want to use custom FlaxAPI, then fork the repository on a [Github](https://github.com/FlaxEngine/FlaxAPI) and clone it to your computer. After adding custom modifications into the code you can build it in *Release* mode and copy binaries into `<engine_installation_root>\Editor\Assemblies\Release` folder. To automate this process you can uncomment certain lines in `CopyDotNetApi.bat` file that will copy the binaries after building the FlaxAPI.

## Flax Engine Tools for Visual Studio

![Flax Engine Tools for Visual Studio](../scripting/debugging/media/flax-vs.jpg)

If you want to open the FlaxAPI in Visual Studio you need to install [Flax Engine Tools for Visual Studio](https://marketplace.visualstudio.com/items?itemName=Flax.FlaxVS) extension.

