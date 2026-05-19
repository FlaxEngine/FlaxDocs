# Flax 1.13 release notes

## Highlights

### TODO

TODO

## Migration Guide

### TODO

TODO

### API Changes

* Automatic GPU Debug Layer has been disabled in `Debug` builds and can be activated manually via command line `-gpudebug` in both `Debug` and `Development` builds. `GPU_ENABLE_DIAGNOSTICS` has been renamed to `GPU_ENABLE_DEBUG_LAYER`.

### Known Issues

* On Linux with `X11` the new `SDL` platform backend doesn't work with drag&drop if `XInput2` is active. Use Wayland (`-wayland` command arg) or compile engine with `SDL: false` for Linux on X11.

## Changelog

### Version 1.13.XXXX.0 - XX XX 2026

Contributors: TODO

PRs merged: TODO

* TODO
