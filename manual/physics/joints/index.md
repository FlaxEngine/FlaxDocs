# Joints

![Joints](media/joints.gif)

**Joint** actors are used to connect two rigidbodies (character controllers are also supported).
For instance, by using a distance joint you can create a spring connection between two objects. By using hinge joint you can create a door.

To make joint work you need to add it as a child to the first rigidbody and link the second one to the **Target** property. Joints support breaking after a certain force applied. Broken joints are not used anymore and should be removed from the game.

## In this section

* [Fixed Joint](fixed-joint.md)
* [Distance Joint](distance-joint.md)
* [Hinge Joint](hinge-joint.md)
* [Slider Joint](slider-joint.md)
* [Spherical Joint](spherical-joint.md)
* [D6 Joint](d6-joint.md)

