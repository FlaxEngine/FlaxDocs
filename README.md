# Flax Engine Documentation

![Flax Engine Docs](manual/graphics/post-effects/media/postFx.png)

Welcome to the Flax documentation repository. This repository contains all the source files for the Flax documentation (https://docs.flaxengine.com/). Anyone is welcome to contribute!

## Editing

We use [DocFX](https://github.com/dotnet/docfx) tool for building and hosting documentation online. It supports markdown style files (`.md`) as it's very standardized and popular format. Also writing technical documentation using markdown style is easy and efficient.

To edit docs we recommend you to use tools such as [Haroopad](http://pad.haroopress.com/) or [Visual Code](https://code.visualstudio.com/).

## Building and Testing

Documentation can be builded and hosted on both Linux and Windows. DocFx can run on .Net or Mono. By default site is hosted on `localhost:8080` but this can be easily configured.

### Windows

* Download repository (or clone with `git clone https://github.com/FlaxEngine/FlaxDocs.git`)
* Call `call build_manual.bat` to build the Manual or `build_all.bat` to build whole documentation (with API) but it will take more time to finish
* Call `run_local_website.bat` to preview the site

### Linux

* Install [Mono](http://www.mono-project.com/docs/getting-started/install/linux/)
* Clone repository (`git clone https://github.com/FlaxEngine/FlaxDocs.git`)
* Call `chmod +x docs.sh`. It will modify permissions for the script `docs.sh` to allow to execute it
* Call `./docs.sh rebuild`
