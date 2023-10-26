# Flax Release Policy

This document covers the Flax Engine release plan and describes the versioning method.

## Versioning

Flax uses versioning based on the `major.minor[.build[.revision]]` formula, where:

- **Major**: major version number, changed when a new product version arrives with a significant number of changes including heavy API refactoring and design concepts modifications.
- **Minor**: minor version number, changed after engine updates which bring quality improvements and new features. Upgrades between minor engine versions are rather easy as only single APIs can differ.
- **Build**: build number that is incremented every engine release and is used also for maintenance bugfix updates. It doesn't affect the API.
- **Revision**: revision of the version. Used to differentiate revisions of the same engine release (as patches). For example, `1.7.6403.1` is displayed as `1.7.1` in UI for higher readability (1st patch of `1.7` release).

The same versioning schema is used for binaries (both native and managed C#) and game or project files.

## Branching

The combination of `major.minor` is called `stable branch` and is used in separation for maintenance and support (see [branches](https://github.com/FlaxEngine/FlaxEngine/branches)). This way we can apply hotfixes and security updates separately for multiple releases (the latest one and the past ones if needed).

The most of the active development work happens on `master` branch, which is used for the next engine update. Changes can be also backported from `master` into specific release branch. Shortly after stable releases we keep `master`` for hotfixes and further stabilization (e.g. 1-2 weeks) and await before merging any new features or breaking changes.

## Support

The stable updates (eg. `1.7`, `1.8`) target to be released every ~4 months. Then, we support the latest released *stable version* with patch updates (eg. `1.7.2`, `1.7.3`).

Any deprecated features or APIs are maintained for at least a year before removal. Changes to the content data or project format are maintained for at least two years (due to backward compatibility reasons).
