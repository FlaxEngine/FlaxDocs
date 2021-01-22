# Events in Visual Scripts

**Visual Scripting** supports binding for various events for easier gameplay scripting. Follow this documentation page to learn how to use them in your project.

## How to handle trigger event?

Onve you've created Visual Script use **Bind XXX** node to register custom function for event that will be executed every time event gets called. Flax supports registering member or static functions to member and static events.

Firstly, **override OnEnable** method.

![Override OnEnable method in Visual Script](media/override-on-enable.png)

Then use **Get Actor** node from **Script** class and **Cast** node to cast it to **PhysicsColliderActor**.

![Cast Actor to Physicsc Collider Actor](media/cast-actor-to-collder.png)

Now, add **Bind TriggerEnter** method and connect it to Cast outputs. We will use it to register for trigger collider to call our function every time something enters the trigger.

![Bind Trigger Enter Event](media/bind-trigger-enter.png)

As you can see it shows the handler function dropdown menu as disabled which means there are no valid functions on a graph to call for event. Let's **use red button** to quickly create new event handler function and use it in that bind node.

![Add Trigger Event Handler Function](media/add-trigger-event-handler.gif)

After that you can use this function to perform any custom logic every time this collider gets triggered. In this example we simply print the custom message with the object name that activated the trigger

![Event Handler Function](media/event-trigger-handler.png)

Finally we can test this script. Create collider (eg. box collider), adjust it's size and check **Is Trigger**, then add the script we've created to it.

![Trigger Event Setup](media/event-trigger-setup.png)

Then you can **play game** and see the log print when something enters this trigger.

![Trigger Event Showcase](media/vs-trigger-event-showcase.gif)

> [!Tip]
> You can manually unregister function from event by using **Unbind XXX** node. Also, Flax will unregister event automatically when script gets deleted.
