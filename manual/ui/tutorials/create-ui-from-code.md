# HOWTO: Create UI from code

In this tutorial, you will learn how to create a User Interface for your game. Follow these steps to prepare a simple heath bar for your player.

## 1. Create `PlayerHealthFromCode` script

Add a new script named `PlayerHealthFromCode` that will control the player's health level and update the progress bar to visualize it. To learn more about creating and using scripts see [this tutorial](../../scripting/new-script.md).

## 2. Edit script

Open script file and write the following code:

```cs
using FlaxEngine;
using FlaxEngine.GUI;

public class PlayerHealthFromCode : Script
{
	[Limit(0, 100), Tooltip("The current player health (in range 0-100)")]
	public float Health { get; set; } = 100.0f;

	private ProgressBar _progressBar;

	public override void OnEnable()
	{
		_progressBar = new ProgressBar
		{
			Width = 120,
			Parent = RootControl.GameRoot,
		};
		_progressBar.Value = Health;
	}

	public override void OnDisable()
	{
		_progressBar.Dispose();
		_progressBar = null;
	}

	public override void OnUpdate()
	{
		var health = Health;
		if (Input.GetKey(KeyboardKeys.Q))
			health -= 5;
		if (Input.GetKey(KeyboardKeys.W))
			health += 5;
		Health = Mathf.Clamp(health, 0, 100);

		_progressBar.Value = Health;
	}
}
```

As you can see it creates a `ProgressBar` control in `OnEnable` event and disposes it in `OnDisable`. The created GUI control is linked to the `RootControl.GameRoot` container control which is used as a main game UI control (the topmost).
You can create more UI elements and manage them at runtime but remember to dispose or unlink them when the script is being disabled or removed from the game.

## 3. Add script to the player

Now drag and drop the script to the player actor.

## 4. Test it out!

Finally, hit **Play** button (or **F5** key) and test the player health controller by using **Q** and **W** keys to change it dowm or up.

Later you can link your existing gameplay logic to visualize the player's health level or create more HUD for your game.

![Test Health Bar](media/test-progress-bar.png)

