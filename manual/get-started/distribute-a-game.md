# Distribute your game

When you're ready to publish your game, create a release build with [Game Cooker](../editor/game-cooker/index.md), then distribute it. Please follow these steps.

## 1. Create a game

Before you can publish your game you will have to create it first. Sounds obvious but it's definitely required to do! Please test your game and perform enough QA to deliver a high-quality product.

## 2. Follow the guidelines

All commercial games made using Flax Engine must to follow various guidelines. It's required by the [EULA](http://flaxengine.com/licensing/) which has to be accepted before installing the engine. It does not affect trully uncommercial products (educational, totally free). Please visit [Commercial Product Release Guidelines](http://flaxengine.com/release/) page to learn more.

## 3. Build a game

Now prepare the final build. Remember to use **Release** mode and remove any debug/testing code sections with [preprocessor variables](../scripting/preprocessor.html). Use [Game Cooker](../editor/game-cooker/index.md) tool to generate the game files for a target platform.

![Game Cooker](media/build-release.jpg)

## 4. Distribute your game

Every platform has own building process and custom output data format but in most cases simply grab the files from the *Output* directory. How you distribute it is up to you.

![Game Output](media/build-output.jpg)











