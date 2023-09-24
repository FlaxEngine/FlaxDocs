# Behavior Tree Decorators

Behavior Trees are very extensible meaning you can create own decorator types in your game project or use the ones from engine and plugins. Each decorator can define custom logic, contain properties and store runtime state (per-instance). This page contains a list of all in-built decorator types with their documentation.

## Invert

Inverts node's result - fails if node succeeded or succeeds if node failed.

## Force Success

Forces node to success - even if it failed.

## Force Failed

Forces node to fail - even if it succeeded.

## Loop

Loops node execution multiple times as long as it doesn't fail. Returns the last iteration result.

| Property | Description |
|--------|--------|
| **Loop Count** | Amount of times to execute the node. Unused if *Loop Count Selector* is used. |
| **Loop Count Selector** | Amount of times to execute the node from behavior's knowledge (blackboard, goal or sensor). If set, overrides *Loop Count*. |

## Time Limit

Limits maximum duration of the node execution time (in seconds). Node will fail if it runs out of time.

| Property | Description |
|--------|--------|
| **Max Duration** | Maximum node execution time (in seconds). Unused if *Max Duration Selector* is used. |
| **Random Deviation** | Duration time randomization range to deviate original value. |
| **Max Duration Selector** | Maximum node execution time (in seconds) from behavior's knowledge (blackboard, goal or sensor). If set, overrides MaxDuration but still uses *Random Deviation*. |

## Cooldown

Adds cooldown in between node executions. Blocks node execution for a given duration after last run.

| Property | Description |
|--------|--------|
| **Min Duration** | Minimum cooldown time (in seconds). Unused if *Min Duration Selector* is used. |
| **Random Deviation** | Duration time randomization range to deviate original value. |
| **Min Duration Selector** | Minimum cooldown time (in seconds) from behavior's knowledge (blackboard, goal or sensor). If set, overrides MinDuration but still uses *Random Deviation*. |

## Knowledge Conditional

Checks certain knowledge value to conditionally enter the node.

| Property | Description |
|--------|--------|
| **Value A** | The first value from behavior's knowledge (blackboard, goal or sensor) to use for comparision. |
| **Value B** | The second value to use for comparision (constant). |
| **Comparison** | Values comparision mode (equal, not equal, less, greater, etc.). |

## Knowledge Values Conditional

Checks certain knowledge value to conditionally enter the node.

| Property | Description |
|--------|--------|
| **Value A** | The first value from behavior's knowledge (blackboard, goal or sensor) to use for comparision. |
| **Value B** | The second value from behavior's knowledge (blackboard, goal or sensor) to use for comparisio. |
| **Comparison** | Values comparision mode (equal, not equal, less, greater, etc.). |

## Has Tag

Checks if certain actor (from knowledge) has a given tag assigned.

| Property | Description |
|--------|--------|
| **Actor** | The actor value from behavior's knowledge (blackboard, goal or sensor) to check against tag ownership. |
| **Tag** | The tag to check. |
| **Invert** | If checked, inverts condition - checks if actor doesn't have a tag. |

## Has Goal

Checks if certain goal has been added to Behavior knowledge.

| Property | Description |
|--------|--------|
| **Goal** | The goal type to check. |
