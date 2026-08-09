# Basics of Coroutines

Basic coroutine workflow requires 3 steps:

1. Creating a sequence.
2. Passing the sequence to an executor.
3. (Optional) Manipulating execution with a handle.

## 1. Creating Sequence

To create a sequence, a builder pattern is used to define steps. The order of executing those steps is the same as the order of adding them.

# [C#](#tab/code-csharp)
```cs
CoroutineSequence sequence = new CoroutineSequence()
    .ThenRun(() => { Debug.Log("Greeting in 3 seconds!"); })
    .ThenWait(3.0f)
    .ThenRun(() => { Debug.Log("Hello World!"); });
```
# [C++](#tab/code-cpp)
```cpp
CoroutineSequence* sequence = New<CoroutineSequence>()
    ->ThenRun([](){ DebugLog::Log(TEXT("Greeting in 3 seconds!")); })
    ->ThenWait(3.0f)
    ->ThenRun([](){ DebugLog::Log(TEXT("Hello World!")); });
```
***

Once you declared the coroutine sequence, you must pass it to what's called executor. 

## 2. Executing Sequence

Second stage is to pass the sequence to the *executor*. One executor can process multiple executions at once. To distinguish them, executor returns *execution handle*, which is explored in 3rd stage. Let's see the mechanism in action:

> [!Note]
> In the example, we use Script class as a proxy for shared per-scene executor. If you want to use see how to interact with executors directly, check [advanced scenarios](coroutines-advanced.md).

# [C#](#tab/code-csharp)
```cs
CoroutineHandle _handle;

public override OnEnabled() 
{
    CoroutineSequence sequence = ...;
    _handle = ExecuteOnce(sequence);
}
```
# [C++](#tab/code-cpp)
```cpp
ScriptingObjectReference<CoroutineHandle> _handle;

void OnEnabled() override 
{
    auto sequence = ...;
    _handle = ExecuteOnce(sequence);
}
```
***

Sequences can be executed in three run modes:

| Run Mode | Number of Runs | Auto-Cancel | Manual Cancel | Method Name |
|----------|----------------|-------------|---------------|-------------|
| *Single Run* | 1 | Yes | Yes | `ExecuteOnce` |
| *Repeating Run* | n | Yes | Yes | `ExecuteRepeating` |
| *Looped Run* | infinite | **No** | Yes | `ExecuteLooped` |

> [!Note]
> Execution starts right after passing a sequence to the executor. If your first step is code, it will be run immediately.

## 3. Manipulating Execution

Flax coroutines execution can be manually altered from outside by using the *handles*. To control the flow, there are three available methods:

- **Pause** to request the executor to halt execution until resuming is requested.
- **Resume** to request the executor to continue potentially paused execution.
- **Cancel** to terminate the execution completelly.

Each one of them returns a flag indicating if the operation was successful.

Let's see an example, how to stop coroutine at the end of our script's lifetime:

# [C#](#tab/code-csharp)
```cs
// ...
public override OnDisabled() 
{
    _handle.Cancel();
}
```
# [C++](#tab/code-cpp)
```cpp
// ...
void OnDisabled() override 
{
    _handle.Cancel();
}
```
***

## Full Example

### Example - Ticking Bomb

*Ticking Bomb* presents the basic use of coroutines. We have a sequence of bomb going 3 times through a 5-seconds cycle turning its diode on for one second.

> [!Note]
> In this example, we count number of sequence runs manually, so the execution is stopped manually too.

# [C#](#tab/code-csharp)
```cs
public class Bomb : Script
{
    [Serialize] public int SequenceCount = 3;
    [Serialize] public Light BlinkSource;
    [Serialize] public AudioSource BeepSource;

    private CoroutineSequence _tickingSequence;
    private CoroutineHandle _tickingHandle;

    public override OnStart()
    {
        _tickingSequence = new CoroutineSequence()
            .ThenRun(() => { 
                BlinkSource.IsActive = true;
                BeepSource.Play();
            })
            .ThenWait(1.0f)
            .ThenRun(() => {
                BlinkSource.IsActive = false;
            })
            .ThenWait(4.0f)
            .ThenRun(() => {
                SequenceCount--;
                if (SequenceCount <= 0)
                    Explode();
            });
    }

    public override OnEnabled()
    {
        _tickingHandle = ExecuteLooping(_tickingSequence);
    }

    public override OnDisabled()
    {
        _tickingHandle.Cancel();
        _tickingHandle = null;
    }

    private void Explode()
    {
        Enabled = false;
        // Use your imagination here.
    }
}
```
# [C++](#tab/code-cpp)
```cpp
API_CLASS()
class Bomb : public Script
{
    DECLARE_SCRIPTING_TYPE(Bomb);
    AUTO_SERIALIZE();

    API_FIELD() int32 SequenceCount = 3;
    API_FIELD() ScriptingObjectReference<Light> BlinkSource;
    API_FIELD() ScirptingObjectReference<AudioSource> BeedSource;

private:
    ScriptingObjectReference<CoroutineSequence> _tickingSequence;
    ScriptingObjectReference<CoroutineHandle> _tickingHandle;

    void Explode()
    {
        SetEnabled(false);
        // Use your imagination here.
    }

public:
    void OnStart() override
    {
        _tickingSequence = New<CoroutineSequence>()
            ->ThenRun([this](){
                BlinkSource.SetIsActive(true);
                BeepSource->Play();
            })
            ->ThenWait(1.0f)
            ->ThenRun([this](){
                BlinkSource.SetIsActive(false);
            })
            ->ThenWait(4.0f)
            ->ThenRun([this](){
                --SequenceCount;
                if (SequenceCount <= 0>)
                    Explode();
            });
    }

    void OnEnabled() override
    {
        _tickingHandle = ExecuteLooping(_tickingSequence);
    }

    void OnDisabled() override
    {
        _tickingHandle->Cancel();
        _tickingHandle = nullptr;
    }
};
```
***