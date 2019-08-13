# Triggers

![Triggers](media/triggers.gif)

**Triggers** are colliders used to detect other colliders enter it, which you can use to script events. For example, you can detect when a player character enters a room, and use this in your script to trigger an event.

Triggers don't generate collisions.

> [!Note]
> Triangle Mesh colliders cannot be triggers.

## Create a trigger

1. Create a Colldier (box, sphere, etc.)

2. Check **Is Trigger**
   <br>![Is Trigger](media/set-trigger.jpg)

## Use a trigger

Triggers use dedicated trigger events that you can register for:
* `Trigger.TriggerEnter`
* `Trigger.TriggerStay`
* `Trigger.TriggerExit`

To learn more about using triggers see tutorial [How to use a trigger](tutorials/use-trigger.md).

