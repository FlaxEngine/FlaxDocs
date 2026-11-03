# Main GPU context

The main GPUContext records commands for the engine's rendering work. It is not a separate execution mode that waits for each shader to finish.

Use the context supplied to a [render task](Running-compute-with-Render-Task.md) or [post-processing callback](Running-compute-with-Post-Proccesing-efect.md). Merely obtaining the main context does not make it safe to use from an arbitrary update callback or worker thread.

`Dispatch` returning means commands were recorded/submitted through the backend; it does not mean CPU-readable results are ready. Mapping or downloading data may wait. Keep GPU command submission in the rendering callback and use the documented readback path for CPU results.
