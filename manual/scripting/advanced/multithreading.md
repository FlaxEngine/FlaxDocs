# Multithreading

Flax Engine runs game logic by default on the main thread using the synchronous execution so it's safe to access other objects and edit scene during scripts update events. However, many games require more advanced computing and data processing. In order to provide smooth performance many parts of the game logic could be moved to async.

Except for general computing, the multithreading can be used to work with Flax objects and engine contents. There are several restrictions:
* editing gameplay objects (actors, scripts) can be done only on a main thread (eg. via `Scripting.InvokeOnUpdate(..)`)
* scripts and actors can be created and edited on other thread but added/removed to gameplay only on a main thread (you can create new actor, setup it and then add to scene on main thread)
* content can be generated from other threads but if not used by the gameplay (eg. generate model asset and then add it to scene on main thread)

There is no *great rule* whether use main thread or custom jobs. In most cases, ensure to profile your code and optimize it when you find bottlenecks. Keep in mind that engine internally extensively uses multi-threading for content streaming, assets loading, physics simulation, etc.

## Synchronziation

One of the key elements of multi-threaded programming is synchronization. Work submissions and results fetching are important aspects of this area. Always try to implement your algorithms starting from designing the data that you want to process. For instance, if you generate voxel terrain, then you can generate geometry in async but the created model can be added to the scene only on the main thread, then you can use something like this: `Scripting.InvokeOnUpdate(() => model.Parent = mainScene)`.

Synchronziation primitives you can use in C#:
* `Semaphore`
* `Mutex`
* `SpinLock`

Thread-safe concurrent collections you can use in C#
* `ConcurrentBag`
* `ConcurrentQueue`
* `ConcurrentDictionary`
* `ConcurrentStack`

## Async

The engine provides various ways to runs logic on a separate thread. The easiest one is to use `async` and `await`:

```cs
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FlaxEngine;

class AsyncTest : Script
{
    private Task _task;

    /// <inheritdoc />
    public override void OnEnable()
    {
        // Start async work
        _task = Task.Run(HandleFileAsync);
    }

    /// <inheritdoc />
    public override void OnDisable()
    {
        // End async work
        _task.Wait();
    }

    async Task HandleFileAsync()
    {
        Debug.Log("Starting async job from thread: " + Thread.CurrentThread.ManagedThreadId);
        string file = Path.Combine(Globals.ContentFolder, "myFile.txt");
        int count = 0;

        // Read in the specified file (use async StreamReader method)
        using (StreamReader reader = new StreamReader(file))
        {
            string v = await reader.ReadToEndAsync();

            // Process the file data somehow
            count += v.Length;

            // A slow-running computation
            for (int i = 0; i < 10000; i++)
            {
                int x = v.GetHashCode();
                if (x == 0)
                {
                    count--;
                }
            }
        }

        Debug.Log("Job result " + count);
    }
}
```

## Thread

If you want to have more control over the multithreaded code execution then the best way is to create thread manually and control its execution:

```cs
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FlaxEngine;

class ThreadTest : Script
{
    private Thread _thread;

    /// <inheritdoc />
    public override void OnEnable()
    {
        // Start async work
        _thread = new Thread(HandleFileAsync);
        _thread.Start();
    }

    /// <inheritdoc />
    public override void OnDisable()
    {
        // End async work
        _thread.Join();
    }

    void HandleFileAsync()
    {
        Debug.Log("Starting async job from thread " + Thread.CurrentThread.ManagedThreadId);
        string file = Path.Combine(Globals.ContentFolder, "myFile.txt");
        int count = 0;

        // Read in the specified file
        using (StreamReader reader = new StreamReader(file))
        {
            string v = reader.ReadToEnd();

            // Process the file data somehow
            count += v.Length;

            // A slow-running computation
            for (int i = 0; i < 10000; i++)
            {
                int x = v.GetHashCode();
                if (x == 0)
                {
                    count--;
                }
            }
        }

        Debug.Log("Job result " + count);
    }
}
```

## Thread Pool

If your game requires multiple jobs execution, then it might be worth to try using in-build C# `ThreadPool` to enqueue tasks:

```cs
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FlaxEngine;

class ThreadPoolTest : Script
{
    private ManualResetEvent _doneEvent;

    /// <inheritdoc />
    public override void OnEnable()
    {
        // Start async work
        _doneEvent = new ManualResetEvent(false);
        ThreadPool.QueueUserWorkItem(HandleFileAsync);
    }

    /// <inheritdoc />
    public override void OnDisable()
    {
        // End async work
        _doneEvent.WaitOne();
    }

    void HandleFileAsync(object stateInfo)
    {
        Debug.Log("Starting async job from thread " + Thread.CurrentThread.ManagedThreadId);
        string file = Path.Combine(Globals.ContentFolder, "myFile.txt");
        int count = 0;

        // Read in the specified file
        using (StreamReader reader = new StreamReader(file))
        {
            string v = reader.ReadToEnd();

            // Process the file data somehow
            count += v.Length;

            // A slow-running computation
            for (int i = 0; i < 10000; i++)
            {
                int x = v.GetHashCode();
                if (x == 0)
                {
                    count--;
                }
            }
        }

        Debug.Log("Job result " + count);
        _doneEvent.Set();
    }
}
```
