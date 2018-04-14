# Animation

![Animation](media/title.jpg)

**Animation** asset contains a set of bone animation channels and curves. It's used to animate [skinned model](../skinned-model/index.md) skeleton bones.

## Importing animations

Importing animation files works in the same way as for other asset types. Simple drag and drop the model files from *Explorer* into the *Content* window or use the *Import* button.

![Importing Animation](media/import-animation.jpg)

After choosing the files **Import file settings** dialog shows up. It's used to specify import options per asset. In most cases the default values are fine and you can just press the **Import** button.

> [!Note]
> Using **Import file settings** dialog you can select more than one asset at once (or use **Ctrl+A** to select all) and specify import options at once.

Every asset can be reimport (relative path to the source file is cached) and import settings modified using Animation Window.

To learn more about **Import Options** see [Models Importing page](../../graphics/models/import.md).

## Using animations

To use the imported animation clip you can drag and drop it into the Anim Graph surface or add manually *Animation* node.
Then connect the animation pose with the animation output and see the animated mode.

![Using Animation](media/use-animation.jpg)

## Animation editor window

![Animation Window](media/animation-window.jpg)

Double-click the animation asset in the *Content* window to show it in teh dedicated editor window.
You can see the total animation length, amount of animated channels and the total keyframes amount.
Also it's very easy way to modify the import settings and reimport the source asset.


