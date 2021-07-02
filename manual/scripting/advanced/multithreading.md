# Multithreading

Flax Engine runs game logic by default on the main thread using the synchronous execution so it's safe to access other objects and edit scene during scripts update events. However, many games require more advanced computing and data processing. In order to provide smooth performance many parts of the game logic could be moved to async.

Except for general computing, the multithreading can be used to work with Flax objects and engine contents. There are several restrictions:
* editing gameplay objects (actors, scripts) can be done only on a main thread (eg. via `Scripting.InvokeOnUpdate(..)`)
* scripts and actors can be created and edited on other thread but added/removed to gameplay only on a main thread (you can create new actor, setup it and then add to scene on main thread)
* content can be generated from other threads but if not used by the gameplay (eg. generate model asset and then add it to scene on main thread)

There is no *great rule* whether use main thread or custom jobs. In most cases, ensure to profile your code and optimize it when you find bottlenecks. Keep in mind that engine internally extensively uses multi-threading for content streaming, assets loading, physics simulation, etc.

> [!TIP]
> To profile asynchronous code use in-built [Profiler](../../editor/profiling/profiler.md) or [Tracy](../../editor/profiling/tracy.md) profiler.

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

## Job System

Flax contains own **Job System** which is used by the engine to pararellize systems like particles, animations, content, etc. It can be also used by the game to execute code in paraller. It makes easier to optimize large data sets processing using multi-core. Job System uses one thread per CPU. Example usage of the job system that will trigger two async job dispatches and wait for the second one to finish before continuing.

```cs
using System;
using FlaxEngine;

class JobSystemTest : Script
{
    /// <inheritdoc />
    public override void OnEnable()
    {
        // Run example jobs in async on all CPUs
        Debug.Log("Start");
        var label = JobSystem.Dispatch(i => Debug.Log($"FactorialRecursion({i + 1}) = {FactorialRecursion(i + 1)}"), 30);
        JobSystem.Wait(label);
        Debug.Log("End");
    }

    public double FactorialRecursion(int number)
    {
        if (number == 1)
            return 1;
        return number * FactorialRecursion(number - 1);
    }
}
```

## Task Graph

For more advanced gameplay systems that need to use dependencies and aim to improve CPU performance (better scheduling without gaps) the **Task Graph** is preferred. It's used by the engine to parallarize animations, particles, streaming and other systems update and can be used by the gameplay code. For instance, you can create own Task Graph System for a game that will calculate AI paths or perform player visibility checks or anything your project needs. The advantage of using Task Graph is that your async jobs will overlap with other jobs including engine async task which gives significant performance boost over traditional single-threaded gameplay programming.

**TaskGraph** is a graph-based asynchronous tasks scheduler for high-performance computing and processing. It contains a list of systems to execute. You can create own graphs or use in-built ones to share CPU with engine systems.

**TaskGraphSystem** represents a system that can generate work into Task Graph for asynchronous execution. Each system has list of dependencies to be executed before running given system (systems can be also sorted by *Order*). Before execution all systems receive `PreExecute` call and `PostExecute` call for custom data setup/cleanup before actual async execution. `Execute` method is used to schedule async jobs by using `graph.DispatchJob` (via *Job System*).

The following code creates custom *Task Graph System* and adds it to the engine *Update* to be scheduled automatically.

```cs
using System;
using FlaxEngine;

class TaskGraphTest : Script
{
    private class MyGameplaySystem : TaskGraphSystem
    {
        /// <inheritdoc />
        public override void PreExecute(TaskGraph graph)
        {
            Debug.Log("PreExecute");
        }

        /// <inheritdoc />
        public override void Execute(TaskGraph graph)
        {
            // Run example jobs in async on all CPUs
            graph.DispatchJob(i => Debug.Log($"FactorialRecursion({i + 1}) = {FactorialRecursion(i + 1)}"), 30);
        }

        /// <inheritdoc />
        public override void PostExecute(TaskGraph graph)
        {
            Debug.Log("PostExecute");
        }
    }

    private MyGameplaySystem _system;

    /// <inheritdoc />
    public override void OnEnable()
    {
        _system = new MyGameplaySystem();
        Engine.UpdateGraph.AddSystem(_system);

        // You can add dependencies on engine systems to run async jobs after/before them
        //_system.AddDependency(Animations.System);
        //Particles.System.AddDependency(_system);
    }

    /// <inheritdoc />
    public override void OnDisable()
    {
        Engine.UpdateGraph.RemoveSystem(_system);
        Destroy(ref _system);
    }

    static double FactorialRecursion(int number)
    {
        if (number == 1)
            return 1;
        return number * FactorialRecursion(number - 1);
    }
}
```

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
        string file = Path.Combine(Globals.ProjectContentFolder, "myFile.txt");
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

Also, when using `async` tasks you can use the `Scripting.MainThreadScheduler` to invoke task on a main thread during game *Update*. This can be usefull when chacing the async tasks with main thread tasks.

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
        string file = Path.Combine(Globals.ProjectContentFolder, "myFile.txt");
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
        string file = Path.Combine(Globals.ProjectContentFolder, "myFile.txt");
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
