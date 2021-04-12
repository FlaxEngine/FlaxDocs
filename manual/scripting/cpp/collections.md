# Collections for C\+\+ in Flax

## Array

`Array<T>` is a general-purpose dynamic allocated and resizable list object. Use it to store a list of values.

Examples:

```cpp
#include "Engine/Core/Collections/Array.h"

Array<String> messages;
messages.Add(TEXT("one")); // add items to the list
messages.Add(TEXT("two"));
messages.Add(TEXT("three"));
int32 count = messages.Count(); // access amount of items
bool hasTwo = messages.Contains(TEXT("two")); // utilities like Find, Contains, IndexOf, Reverse
messages.Insert(0, TEXT("zero")); // inserting at index
messages.Dequeue(); messages.Enqueue(TEXT("a")); // can work like a queue
messages.Pop(); messages.Push(TEXT("a")); // can work like a stack

// iteration over the list with for-range loop
for (auto& item : messages)
	LOG_STR(Info, item);

// iteration over the list with for loop
for (int32 i = 0; i < messages.Count(); i++)
	LOG_STR(Info, messages[i]);

Array<int32> values;
int32 defaults[] = {1, 2, 3, 4};
values.SetCapacity(100); // dynamic resizable allocation
values.Add(defaults, ARRAY_COUNT(defaults)); // adding range of values
values.Clear(); // clearing values (preserves allocation)
values.SetCapacity(0); // clears the allocartion too
```

### ArrayExtensions

For more advanced usage of the Array use `ArrayExtensions`, example:

```cpp
#include "Engine/Core/Collections/ArrayExtensions.h"

const std::function<bool(const ModelInstanceEntry&)> IsValidMaterial = [](const ModelInstanceEntry& e) -> bool
{
    return e.Material;
};
// utilities like Any, All, IndexOf, GroupBy
if (ArrayExtensions::Any(Entries, IsValidMaterial))
{
    // do sth...
}
```

## Dictionary

`Dictionary<Key, Value>` is a template for unordered dictionary with mapped key with value pairs.

```cpp
#include "Engine/Core/Collections/Dictionary.h"

Dictionary<String, int32> map;
map[TEXT("Speed")] = 10;
map[TEXT("Car")] = 0;
map.Add(TEXT("Key"), 11);
bool containsCar = map.ContainsKey(TEXT("Car"));
bool contains0 = map.ContainsValue(0);
for (auto& e : map)
    LOG(Info, "Key: {0}, Value: {1}", e.Key, e.Value);
```

## HashSet

`HashSet<T>` is a template for unordered set of values (without duplicates with *O(1)* lookup access). It works like `Dictionary` except it stores only keys without paired value.

```cpp
#include "Engine/Core/Collections/HashSet.h"

HashSet<String> map;
map.Add(TEXT("Speed"));
map.Add(TEXT("Car"));
map.Add(TEXT("Key"));
bool containsCar = map.Contains(TEXT("Car"));
for (auto& e : map)
    LOG(Info, "Item: {0}", e.Item);
```

## ChunkedArray

`ChunkedArray<T, ChunkSize>` is a template for dynamic array with variable capacity that uses fixed size memory chunks for data storage rather than linear allocation. It's more optimized for cases where single linear allocation would no be performant (eg. very large data sets) that keep growing.

```cpp
#include "Engine/Core/Collections/ChunkedArray.h"

ChunkedArray<int32, 1024> flags;
for (int32 i = 0; i < 4096; i++)
	flags.Add((int32)(Math::Cos((float)i / 100.0f) * 100.0f));
```

## BitArray

`BitArray<>` is a template for dynamic array with variable capacity that stores the bit values. It uses `uint32` to use optimized storage for 32 bits per-item and contains API for accessing the data.

```cpp
#include "Engine/Core/Collections/BitArray.h"

BitArray<> flags;
for (int32 i = 0; i < 100; i++)
    flags.Add(i % 2);
```

## Hash Functions

`Dictionary` and `HashSet` collections use key hashing to implement fast lookups. Flax uses `uint32 GetHash(const Type& key)` signature to natch the hash function for `Type` (reference is optional). Example hash functions are implemented in `Engine/Core/Collections/HashFunctions.h`.

## Sorting

For sorting data, especially when using `Array` it's possible to use sorting methods implemented in `Sorting` header.

Example:

```cpp
#include "Engine/Core/Collections/Sorting.h"

Array<String> names;
names.Add(TEXT("zzzz"));
names.Add(TEXT("bbb"));
names.Add(TEXT("aaa"));
names.Add(TEXT("fff"));
Sorting::QuickSort(names.Get(), names.Count());
for (auto& e : names)
    LOG_STR(Info, e);
```

## Allocators

By default all collections are using heap-allocated memory using `Platform::Allocate` to store data. Hovewer is some cases when programmer knows that collection will store up to X items or will be unlikely to grow very large the custom, more optimized allocator can be used to gain more performance.

Allocators:
* `HeapAllocation`
* `InlinedAllocation`
* `FixedAllocation`

For example if the Array used in the following example can hold up to 10 items it can use `FixedAllocation<>` with predefined capacity which will use stack-memory to place items - it's faster.

```cpp
Array<int32, FixedAllocation<10>> myItens;
for (int32 i = 0; i < 10; i++)
{
	if (i % 2 == 0) // perform some cool check
	{
		myItens.Add(i * 2 + 1);
	}
}
// do sth with myItens...
```

If the array is more likely to contain up to 10 items but i can be resized to be bigger for a given case the `InlinedAllocation<>` can be used:

```cpp
Array<int32, InlinedAllocation<10>> myItens;
```

Using allocators is more advanced use-case but can benefit the game performance. Also, scripting API bindings generator supports using custom allocators when exposing gameplay components for C#/Visual Script using `API_` macros.
