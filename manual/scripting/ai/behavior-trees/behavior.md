# Behavior

**Behavior** is a script attached to the actor on a level that intends to control it's logic via [Behavior Tree](index.md) execution.

Behavior can be started when script (and it's parent actors) is enabled during level load or when it's spawned in the scene. When *Auto Start* is enabled (by default) Behavior will use `OnEnable()` event to start its logic.

You can manually control logic execution via `StartLogic()`, `StopLogic()`, `ResetLogic()` methods. When behavior ends it invokes `Finished` event and has `Result` property set (see `BehaviorUpdateResult`).

When behavior is running it's execution is performed within `Behavior.System` (`TaskGraphSystem`) that runs during game update (on `Engine.UpdateGraph`) and schedules async execution via Job System.

## Properties

| Property | Description |
|--------|--------|
| **Tree** | Behavior Tree asset to use for logic execution. |
| **Auto Start** | If checked, auto starts the logic on begin play. |
| **Update Rate Scale** | The behavior logic update rate scale (multiplies the *Update FPS* defined in Behavior Tree root node). Can be used to improve performance via LOD to reduce updates frequency (eg. by `0.5``) for behaviors far from player. |
