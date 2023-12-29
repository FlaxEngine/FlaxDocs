# Actors

![Actors](media/actors.png)

**Actors** are the essential objects of a scene. You can place them into a scene to build a game environment, setup lighting and create gameplay. Every [Actor](https://docs.flaxengine.com/api/FlaxEngine.Actor.html) is linked to the parent actor (except the Scene actors which are the root of the hierarchy) and can have child actors (tree hierarchy). Actors have their own 3D transformation (translation, rotation and scale) and inherit the parent actor transformation. You can attach C# scripts to the actors and spawn/destroy them at runtime.

This documentation page contains links to all tutorials related to working with actors and references to actor types.

## Using actors

<div class="frontpage">

<div class="frontpage-section">
<a href="placing-actors.md"><img src="media/placing-actors-icon.jpg"></a>
<h3><a href="placing-actors.md">Placing actors</a></h3>
<p>Learn how to create and remove actors in the editor.</p>
</div>

<div class="frontpage-section">
<a href="selecting-actors.md"><img src="media/selecting-actors-icon.jpg"></a>
<h3><a href="selecting-actors.md">Selecting actors</a></h3>
<p>Learn how to select actors in the editor.</p>
</div>

<div class="frontpage-section">
<a href="transforming-actors.md"><img src="media/transforming-actors-icon.jpg"></a>
<h3><a href="transforming-actors.md">Transforming actors</a></h3>
<p>Learn how to move, rotate and scale your objects in the editor.</p>
</div>

</div>

## Actor types

<div class="frontpage">

<div class="frontpage-section">
<a href="../../graphics/cameras/index.md"><img src="../../graphics/cameras/media/icon.jpg"></a>
<h3><a href="../../graphics/cameras/index.md">Camera</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/lighting/reflections/env-probe.md"><img src="../../graphics/lighting/reflections/media/env-probe-icon.jpg"></a>
<h3><a href="../../graphics/lighting/reflections/env-probe.md">Environment Probe</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/models/static-model.md"><img src="../../graphics/models/media/icon.jpg"></a>
<h3><a href="../../graphics/models/static-model.md">Static Actor</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/lighting/light-types/directional-light.md"><img src="../../graphics/lighting/light-types/media/directional-light-icon.jpg"></a>
<h3><a href="../../graphics/lighting/light-types/directional-light.md">Directional Light</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/lighting/light-types/point-light.md"><img src="../../graphics/lighting/light-types/media/point-light-icon.jpg"></a>
<h3><a href="../../graphics/lighting/light-types/point-light.md">Point Light</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/lighting/light-types/spot-light.md"><img src="../../graphics/lighting/light-types/media/spot-light-icon.jpg"></a>
<h3><a href="../../graphics/lighting/light-types/spot-light.md">Spot Light</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/lighting/light-types/sky-light.md"><img src="../../graphics/lighting/light-types/media/sky-light-icon.jpg"></a>
<h3><a href="../../graphics/lighting/light-types/sky-light.md">Sky Light</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/lighting/sky-skybox/sky.md"><img src="../../graphics/lighting/sky-skybox/media/sky-icon.jpg"></a>
<h3><a href="../../graphics/lighting/sky-skybox/sky.md">Sky</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/lighting/sky-skybox/skybox.md"><img src="../../graphics/lighting/sky-skybox/media/skybox-icon.jpg"></a>
<h3><a href="../../graphics/lighting/sky-skybox/skybox.md">Skybox</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/post-effects/post-fx-volumes.md"><img src="../../graphics/post-effects/media/post-fx-volumes-icon.jpg"></a>
<h3><a href="../../graphics/post-effects/post-fx-volumes.md">PostFx Volume</a></h3>
</div>

<div class="frontpage-section">
<a href="index.md"><img src="media/icon.jpg"></a>
<h3><a href="index.md">Scene</a></h3>
</div>

<div class="frontpage-section">
<a href="../../physics/rigid-bodies.md"><img src="../../physics/media/icon.jpg"></a>
<h3><a href="../../physics/rigid-bodies.md">Rigid Body</a></h3>
</div>

<div class="frontpage-section">
<a href="../../physics/character-controller.md"><img src="../../physics/media/character-controller-icon.jpg"></a>
<h3><a href="../../physics/character-controller.md">Character Controller</a></h3>
</div>

<div class="frontpage-section">
<a href="../../physics/colliders/index.md"><img src="../../physics/colliders/media/icon.jpg"></a>
<h3><a href="../../physics/colliders/index.md">Colliders</a></h3>
</div>

<div class="frontpage-section">
<a href="../../physics/joints/index.md"><img src="../../physics/joints/media/icon.jpg"></a>
<h3><a href="../../physics/joints/index.md">Joints</a></h3>
</div>

<div class="frontpage-section">
<a href="../../audio/audio-source.md"><img src="../../audio/media/autio-source-icon.jpg"></a>
<h3><a href="../../audio/audio-source.md">Audio Source</a></h3>
</div>

<div class="frontpage-section">
<a href="../../audio/audio-listener.md"><img src="../../audio/media/audio-listener-icon.jpg"></a>
<h3><a href="../../audio/audio-listener.md">Audio Listener</a></h3>
</div>

<div class="frontpage-section">
<a href="../../animation/animated-model.md"><img src="../../animation/media/animated-model-icon.jpg"></a>
<h3><a href="../../animation/animated-model.md">Animated Model</a></h3>
</div>

<div class="frontpage-section">
<a href="../../animation/bone-socket.md"><img src="../../animation/media/bone-socket-icon.jpg"></a>
<h3><a href="../../animation/bone-socket.md">Bone Socket</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/decals/decal.md"><img src="../../graphics/decals/media/icon.jpg"></a>
<h3><a href="../../graphics/decals/decal.md">Decal</a></h3>
</div>

<div class="frontpage-section">
<a href="../../scripting/empty-actor.md"><img src="../../../media/dummy-icon.jpg"></a>
<h3><a href="../../scripting/empty-actor.md">Empty Actor</a></h3>
</div>

<div class="frontpage-section">
<a href="../../ui/text-render/index.md"><img src="../../ui/text-render/media/icon.jpg"></a>
<h3><a href="../../ui/text-render/index.md">Text Render</a></h3>
</div>

<div class="frontpage-section">
<a href="../../ui/canvas/index.md"><img src="../../ui/canvas/media/icon.jpg"></a>
<h3><a href="../../ui/canvas/index.md">UI Canvas</a></h3>
</div>

<div class="frontpage-section">
<a href="../../ui/control/index.md"><img src="../../ui/control/media/icon.jpg"></a>
<h3><a href="../../ui/control/index.md">UI Control</a></h3>
</div>

<div class="frontpage-section">
<a href="../../terrain/index.md"><img src="../../terrain/media/icon.jpg"></a>
<h3><a href="../../terrain/index.md">Terrain</a></h3>
</div>

<div class="frontpage-section">
<a href="../../navigation/nav-mesh-bounds-volume.md"><img src="../../navigation/media/nav-mesh-bounds-volume-icon.jpg"></a>
<h3><a href="../../navigation/nav-mesh-bounds-volume.md">Nav Mesh Bounds Volume</a></h3>
</div>

<div class="frontpage-section">
<a href="../../navigation/nav-link.md"><img src="../../navigation/media/nav-link-icon.jpg"></a>
<h3><a href="../../navigation/nav-link.md">Nav Link</a></h3>
</div>

<div class="frontpage-section">
<a href="../../particles/particle-effect.md"><img src="../../particles/media/particle-effect-icon.jpg"></a>
<h3><a href="../../particles/particle-effect.md">Particle Effect</a></h3>
</div>

<div class="frontpage-section">
<a href="../../animation/scene-animations/scene-animation-player.md"><img src="../../animation/scene-animations/media/scene-animation-player-icon.jpg"></a>
<h3><a href="../../animation/scene-animations/scene-animation-player.md">Scene Animation Player</a></h3>
</div>

<div class="frontpage-section">
<a href="../../graphics/fog-effects/exponential-height-fog.md"><img src="../../graphics/fog-effects/media/exponential-height-fog-icon.jpg"></a>
<h3><a href="../../graphics/fog-effects/exponential-height-fog.md">Exponential Height Fog</a></h3>
</div>

<div class="frontpage-section">
<a href="../../ui/sprite-render/index.md"><img src="../../ui/sprite-render/media/icon.jpg"></a>
<h3><a href="../../ui/sprite-render/index.md">Sprite Render</a></h3>
</div>

</div>
