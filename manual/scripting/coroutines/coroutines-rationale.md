# Rationale

This sections contains additional information about coroutines which does not regard using the feature.

## Implementation Decisions

The following decisions have been made during implementation:

* `Execution` has been implemented using a union to improve data locality. Waiting-for-seconds events are the most popular, therefor storing executions in continuous block of memory follows data-oriented principles.
* Coroutine execution methods have been split into `ExecuteOnce`, `ExecuteRepeating` and `ExecuteLooping` to 

## Future Works

This list contains aspects that can be improved in the future:

* Injecting context, for example using boxing: `::ScriptableObject` and `System.Object`.
* Checking for predicates with interval, for example `WaitUntil(predicate: ..., interval: 3.0f)` would test the condition each 3 seconds.
* Handling errors in runnables and predicated.
