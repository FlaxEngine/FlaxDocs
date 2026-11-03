# Low-level compute resources

Compute shaders read and write GPU resources through views. Resource creation, command submission and CPU readback are separate operations.

## Memory and ownership

An unmanaged pointer into a managed array must remain pinned for the entire native call that reads it. Keeping the array in a field or keeping its length unchanged does not pin it. Never keep an `Unsafe.AsPointer` result across calls without a matching lifetime and pinning contract.

`InitData` is consumed during buffer initialization; it is not a permanent association with the array. Later CPU changes require another upload. Buffer sizes and strides are byte counts.

Keep resources alive while queued GPU work or downloads use them. Destroy GPU objects you create when their work is finished. `ReleaseGPU()` releases their GPU allocation but does not destroy the owning engine object. Do not destroy borrowed assets or a texture owned by an assigned asset. Return pooled targets with `RenderTargetPool.Release`.

## Typed buffers

`Buffer<T>` and `RWBuffer<T>` use a typed format. Match the HLSL element type and the supported view format; scalar 32-bit types are examples, not the only possible typed formats. Backend format capabilities still apply.

| HLSL element | Example format |
|---|---|
| `float` | `PixelFormat.R32_Float` |
| `int` | `PixelFormat.R32_SInt` |
| `uint` | `PixelFormat.R32_UInt` |

This helper initializes a writable typed buffer with pinned input and checks the failure result:

```csharp
using System;
using FlaxEngine;

public static class ComputeBuffers
{
    public static unsafe GPUBuffer Create(float[] values)
    {
        if (values == null || values.Length == 0)
            throw new ArgumentException("Provide at least one element.", nameof(values));
        checked { _ = values.Length * sizeof(float); }

        var buffer = new GPUBuffer();
        fixed (float* pointer = values)
        {
            var description = GPUBufferDescription.Typed(
                (IntPtr)pointer, values.Length, PixelFormat.R32_Float, true);
            if (buffer.Init(ref description)) // true means failure
            {
                FlaxEngine.Object.Destroy(buffer);
                throw new InvalidOperationException("GPU buffer initialization failed.");
            }
        }
        return buffer;
    }
}
```

`GPUResourceUsage.Default` does not mean immutable. Use the appropriate usage for your update strategy.

## Structured buffers

Use `GPUBufferDescription.Structured(elementCount, elementSize, isUnorderedAccess)` for `StructuredBuffer<T>` or `RWStructuredBuffer<T>`. It sets `PixelFormat.Unknown` and the Structured flag. Put GPUBufferFlags in `Flags`, not in `Usage`.

For an HLSL `float3` element, the structured stride is 12 bytes. This is different from HLSL constant-buffer packing. Establish the complete CPU/HLSL layout before uploading a structure; a C# bool or managed reference is not a portable raw GPU field.

## Binding resources

Creation flags allow views; the shader declaration determines which view to bind:

| HLSL declaration | Binding |
|---|---|
| `Buffer`, `StructuredBuffer`, `Texture2D` at `t0` | `context.BindSR(0, resource.View())` |
| `RWBuffer`, `RWStructuredBuffer`, `RWTexture2D` at `u0` | `context.BindUA(0, resource.View())` |
| constant buffer at `b0` | `context.BindCB(0, shader.GPU.GetCB(0))` |

A buffer with both ShaderResource and UnorderedAccess flags can be read through an SRV in one pass and written through a UAV in another. The flags do not require UAV binding for every use. Avoid overlapping read/write bindings to the same subresource.

Constant-buffer data must match HLSL layout and byte size, including padding. A sequential C# layout alone does not prove a match. Take the address of an unmanaged stack local, or pin managed storage, while calling UpdateCB. Initialize padding too.

## Textures

For an `RWTexture2D<float4>`, choose a concrete UAV-capable format supported by the device, for example R16G16B16A16_Float where supported. Use `GPUTextureFlags.ShaderResource | GPUTextureFlags.UnorderedAccess`, not GPUBufferFlags. Check the result of `GPUTexture.Init`.

A typeless format is not a substitute for a correctly typed view. CPU uploads use the texture upload API with valid row/slice pitches; ShaderResource does not mean an uploaded texture cannot exist. A Texture asset owns its GPU texture, whereas a standalone GPUTexture is a rendering resource, not automatically a saved content asset.

## Dispatch

Check compute support, shader loading and a nonzero kernel returned by `GetCS("CS_Main")`. Dispatch dimensions count thread groups, not individual threads. For a group width of 64, use `(elementCount + 63) / 64` groups and check `id.x < elementCount` in HLSL. Skip empty workloads rather than forcing one group.

Submit from the provided rendering callback context. Reset UAV/SRV slots in a finally block after use. Resetting bindings is state cleanup, not a GPU completion fence. Use separate dispatches for dependencies requiring all groups to finish; a group barrier synchronizes only its own group.

## Upload and readback

The buffer-description helpers create staging descriptions:

- `ToStagingUpload()`: CPU-write staging storage.
- `ToStagingReadback()`: CPU-read staging storage.
- `ToStaging()`: CPU read/write staging storage where supported.

They clear shader binding flags and InitData. Initialize a separate staging GPUBuffer and check its Init result. A staging buffer is copied to/from a GPU buffer; it is not the UAV used by the shader.

For a manual readback, record `CopyBuffer(staging, source, byteCount)` before mapping staging for reading. Mapping may wait for GPU work; it is not a free asynchronous operation. Check for a null map result, copy into pinned destination storage within its bounds, and always Unmap in finally after a successful map. Upload follows the reverse direction: map CPU-write staging, fill it, unmap, then copy to the GPU destination.

`GPUBuffer.DownloadData(out byte[])` provides a blocking convenience path. For a default GPU buffer the native implementation rejects main-thread use, queues copy/download tasks and waits on the calling worker. Keep the buffer alive, keep engine rendering progressing, and consume the result only after completion. Do not wait synchronously from an engine update/render callback. Calling DownloadData on a worker does not permit arbitrary GPUContext commands on that worker.

Do not assume a fixed number of frames proves completion. A streaming service needs bounded pending requests and a shutdown/drain policy before releasing resources.

## Further examples

- [Post-processing blur](Running-compute-with-Post-Proccesing-efect.md)
- [Render task](Running-compute-with-Render-Task.md)
- [Main context usage](Running-compute-with-MainContext.md)

Byte-address buffers, append/consume counters and a complete streaming readback service are not covered here yet.
