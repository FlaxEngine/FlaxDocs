# HOWTO: Create a custom Move To node

Below is an example of a custom `Move To` node that runs gameplay-related code to provide movement action for gameplay objects. Default node logic calls virtual `AddMovement()` method on a target actor.

> [!Warning]
> If you want to store additional per-instance data for a custom movement node then use C++ script and make your state structure to inherit from `BehaviorTreeMoveToNode::State`. Otherwise, implement a custom movement node.

# [C#](#tab/code-csharp)
```cs
using FlaxEngine;

/// <summary>
/// Custom move node.
/// </summary>
public class MyMoveToNode : BehaviorTreeMoveToNode
{
    /// <inheritdoc />
    public override void GetAgentSize(Actor agent, out float outRadius, out float outHeight)
    {
        // Here you can provide custom size of the agent (radius and height) or use default values queried from actor type
        base.GetAgentSize(agent, out outRadius, out outHeight);
    }
    
    /// <inheritdoc />
    public override NavMeshRuntime GetNavMesh(Actor agent)
    {
        // Here you can override navmesh to be used for the given agent
        return base.GetNavMesh(agent);
    }

    /// <inheritdoc />
    public override bool Move(Actor agent, Vector3 move)
    {
        // Here you can perform custom movement logic (eg. via entity interface or similar)
        // It's always called on a main-thread during game Update so here you safely can modify state of the game
        // Return true if cannot apply move (node will fail)
        return base.Move(agent, move);
    }
}
```
# [C++](#tab/code-cpp)
```cpp
#pragma once

#include "Engine/AI/BehaviorTreeNodes.h"

/// <summary>
/// Simple delay node.
/// </summary>
API_CLASS() class GAME_API MyMoveToNode : public BehaviorTreeMoveToNode
{
    DECLARE_SCRIPTING_TYPE(MyMoveToNode);

public:
    // [BehaviorTreeNode]
    void GetAgentSize(Actor* agent, float& outRadius, float& outHeight) const override
    {
        // Here you can provide custom size of the agent (radius and height) or use default values queried from actor type
        BehaviorTreeMoveToNode::GetAgentSize(agent, outRadius, outHeight);
    }
    NavMeshRuntime* GetNavMesh(Actor* agent) const override
    {
        // Here you can override navmesh to be used for the given agent
        return BehaviorTreeMoveToNode::GetNavMesh(agent);
        
    }
    bool Move(Actor* agent, const Vector3& move) const override
    {
        // Here you can perform custom movement logic (eg. via entity interface or similar)
        // It's always called on a main-thread during game Update so here you safely can modify state of the game
        // Return true if cannot apply move (node will fail)
        return BehaviorTreeMoveToNode::Move(agent, move);
    }
};

inline MyMoveToNode::MyMoveToNode(const SpawnParams& params)
    : BehaviorTreeMoveToNode(params)
{
}
```
***
