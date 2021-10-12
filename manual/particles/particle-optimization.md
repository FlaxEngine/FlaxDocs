# Particle Optimization

Large particle systems can affect game performance and reduce FPS. There are several ways to optimize high-quality visual effects. Follow this documentation page to learn them.

## Basic checklist

Here is a helper checklist to follow when profiling and optimizing particles.

* Adjust *Capacity* of particle emitters to an actual real value used by the effect. Using too high values increases memory usage.
* Enable *auto-pooling* on commonly used emitters or short-lived emitters.
* Disable *auto-bounds* on small CPU particle emitters or if particle system bounds are predictable or almost constant. This will improve particles updating (engine won't compute bounds after particles update).
* Use *Material Complexity* and *Quad Overdraw* modes [Debug View](../graphics/debugging-tools/debug-view.md) to analyze rendering performance impact of the particles.
* Use [Tracy](../editor/profiling/tracy.md) or an [in-built profiler](../editor/profiling/profiler.md) to analyze CPU particles performance. You can see how much it takes to update specific emitters so it might be better to optimize the slowest ones firstly. Optionally, if you're working with a custom engine fork you can enable more detailed profile events for CPU particles by setting `PARTICLE_EMITTER_MODULES_PROFILE` to `1` in `ParticleEmitterGraph.CPU.ParticleModules.cpp` file.
