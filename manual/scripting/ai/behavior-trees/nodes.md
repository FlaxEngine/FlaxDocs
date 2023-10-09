# Behavior Tree Nodes

Behavior Trees are very extensible meaning you can create own node types in your game project or use the ones from engine and plugins. Each node can define custom logic, contain properties and store runtime state (per-instance). This page contains a list of all in-built node types with their documentation.

## Root

Root node of the behavior tree. Contains logic properties and definitions for the runtime. Created automatically for each Behavior Tree and cannot be removed.

| Property | Description |
|--------|--------|
| **Blackboard Type** | Type of the blackboard data (structure or class). Spawned for each instance of the behavior. See [knowledge docs](knowledge.md) to learn more. |
| **Goal Types** | List of types of the behavior goals (structure or class). See [knowledge docs](knowledge.md) to learn more. |
| **Update FPS** | The target amount of the behavior logic updates per second. |

## Sequence

Sequence node updates all its children (from left to right) as long as they return success. If any child fails, the sequence is failed.

## Selector

Selector node updates all its children (from left to right) until one of them succeeds. If all children fail, the selector fails.

## Delay

Delay node that waits a specific amount of time while executed.

| Property | Description |
|--------|--------|
| **Wait Time** | Time in seconds to wait when node gets activated. Unused if *Wait Time Selector* is used. |
| **Random Deviation** | Wait time randomization range to deviate original value. |
| **Wait Time Selector** | Wait time from behavior's [knowledge](knowledge.md) (blackboard, goal or sensor). If set, overrides *Wait Time* but still uses *Random Deviation*. |

## Sub Tree

Sub-tree node runs a nested Behavior Tree within this tree.

| Property | Description |
|--------|--------|
| **Tree** | Nested behavior tree to execute within this node. |

## Force Finish

Forces behavior execution end with a specific result (eg. force fail).

| Property | Description |
|--------|--------|
| **Result** | Execution result. |

## Move To

Moves an actor to the specific target location. Uses pathfinding on navmesh.

| Property | Description |
|--------|--------|
| **Agent** | The agent actor to move. If not set, uses Behavior's parent actor. |
| **Movement Speed** | The agent movement speed. Default value is 100 units/second. |
| **Target** | The target movement object. |
| **Target Location** | The target movement location. |
| **Acceptable Radius** | Threshold value between Agent and Target goal location for destination reach test. |
| **Target Goal Update Tolerance** | Threshold value for the Target actor location offset that will trigger re-pathing to find a new path. |
| **Use Pathfinding** | If checked, the movement will use navigation system pathfinding, otherwise direct motion to the target location will happen. |
| **Use Partial Path** | If checked, the movement will start even if there is no direct path to the target (only partial). |
| **Use Target Goal Update** | If checked, the target goal location will be updated while Target actor moves. |
