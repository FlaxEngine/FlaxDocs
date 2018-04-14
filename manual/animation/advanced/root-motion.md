# Root Motion

**Root Motion** is a special feature of the Flax animation system that can be used to extract the motion from the animated model root node and apply it to the actor. This is useful, for example, to create animation-driven characters. Flax supports extracting root motion from the custom node and motion blending so it's possible to achieve realistic looking results.

| No root motion | Root motion enabled |
|--------|--------|
| ![Root Motion Off](media/root-motion-off.gif) | ![Root Motion Off](media/root-motion-on.gif) |

## Usage

In order to use root motion you need to:

1. Enable root motion when importing an animation

	![Root Motion Setup](media/root-motion-setup-1.jpg)

2. Enable root motion extraction and apply in Anim Graph

	![Root Motion Setup](media/root-motion-setup-2.jpg)

## Tips

You can manually specify the root node for the motion extracting when importing the animation. Use **Root Node Name** field (more info [here](../../graphics/models/import.md)).

If your character uses [Character Controller](../../physics/character-controller.md) or kinematic [rigidbody](../../physics/rigid-bodies.md) you may want to apply the root motion to it instead of to animated model. To do this simply assign the target object to [AnimatedModel.RootMotionTarget](fixmeeeee).

