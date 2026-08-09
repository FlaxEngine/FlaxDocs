# Coroutines Advanced Scenarios

## Context

Unfortunately, **coroutines do not have a system to pass context** yet. Contemporary solution is to inject context during sequence declaration. Example:

# [C#](#tab/code-csharp)
```cs
public class Example
{
    //TODO
}
```
# [C++](#tab/code-cpp)
```cpp
class Example
{
    //TODO
}
```
***

## Branching

Flax coroutines use linear sequence of instructions. This means the flow may not be controlled such way that it branches.

If branching is required, separate sequences must be declared:

# [C#](#tab/code-csharp)
```cs
public class Example
{
    //TODO
}
```
# [C++](#tab/code-cpp)
```cpp
class Example
{
    //TODO
}
```
***

## Custom Order

In advanced scenarios it may be important for the coroutines to follow specific order of execution. To do that, you can manually dispatch an executor. Additionaly, such apporach will may skip unnecessary suspension points.

# [C#](#tab/code-csharp)
```cs
public class Example
{
    //TODO
}
```
# [C++](#tab/code-cpp)
```cpp
class Example
{
    //TODO
}
```
***
