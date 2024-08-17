# HOWTO: Create path following agent

In this tutorial, you will learn how to implement a simple script that uses pathfinding to move the object thought the scene to the destination location.

## 1. Setup a scene

Firstly you will need to prepare you level, setup the navmesh and the object to move (our agent).

![Example Scene](media/sample-scene.jpg)

## 2. Create agent logic script

Create and implement the following script:

```cs
public class Agent007 : Script
{
    /// <summary>
    /// The target object to follow.
    /// </summary>
    public Actor MoveToTarget;

    /// <summary>
    /// The offset applied to the actor position on moving it.
    /// </summary>
    public Vector3 Offset = new Vector3(0, 100, 0);

    /// <summary>
    /// Agent movement speed (units/second).
    /// </summary>
    public float Speed = 500.0f;

    private Vector3 _targetPos;
    private Vector3[] _path;
    private float _pathLength;
    private float _pathPosition;

    /// <inheritdoc />
    public override void OnUpdate()
    {
        if (!MoveToTarget)
        {
            Debug.LogError("No target to move.");
            return;
        }

        var currentPos = Actor.Position;
        var targetPos = MoveToTarget.Position;

        // Check if reached target location
        if (Vector3.Distance(ref currentPos, ref targetPos) < 2)
            return;

        // Check if need to build a new path
        if (targetPos != _targetPos)
        {
            _targetPos = targetPos;
            _pathPosition = 0;
            _pathLength = 0;
            if (!Navigation.FindPath(currentPos, targetPos, out _path))
            {
                Debug.LogWarning("Failed to find path to the target.");
                return;
            }

            // Move the start/end points to navmesh floor
            if (_path.Length != 0)
                Navigation.FindClosestPoint(_path[0], out _path[0]);
            if (_path.Length > 1)
                Navigation.FindClosestPoint(_path[_path.Length - 1], out _path[_path.Length - 1]);

            // Compute path length
            for (int i = 1; i < _path.Length; i++)
                _pathLength += Vector3.Distance(ref _path[i - 1], ref _path[i]);
        }

        // Skip if has no path
        if (_path == null)
            return;

        // Move
        var pathProgress = Mathf.Min(_pathLength * _pathPosition + Time.DeltaTime * Speed, _pathLength);
        _pathPosition = pathProgress / _pathLength;

        // Calculate position on path
        float segmentsSum = 0;
        for (int i = 0; i < _path.Length - 1; i++)
        {
            var segmentLength = Vector3.Distance(ref _path[i], ref _path[i + 1]);
            if (segmentsSum <= pathProgress && segmentsSum + segmentLength >= pathProgress)
            {
                float t = (pathProgress - segmentsSum) / segmentLength;
                targetPos = Vector3.Lerp(_path[i], _path[i + 1], t) + Offset;
                Actor.AddMovement(targetPos - currentPos);
                break;
            }

            segmentsSum += segmentLength;
        }
    }
}
```

## 3. Add script to the object and link the `Move To Target`

![Setup Agent](media/setup-agent.jpg)

## 4. See the results

Finally, just press **Play** (or hit *F5*) and see your bot moving through the scene.

![Moving Bot](../media/navmesh-agent.gif)
