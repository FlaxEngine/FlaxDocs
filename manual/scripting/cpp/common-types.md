# Common Types for C\+\+ in Flax

## String

For character strings container Flax uses `String` class that holds a null-terminated text, encoded in UTF-16 (as `Char` type, 2-bytes per character) and provides extensive API for string operations like splitting, formatting, merging, etc.

```cpp
#include "Engine/Core/Types/String.h"

String myText = TEXT("hello there"); // string from constant
String substring = myText.Substring(0, 5);
String connected = myText + TEXT(" ") + substring; // join strings
int32 length = connected.Length(); // access string length
const Char* str = connected.Get(); // access string memory buffer
String objectName = this->ToString(); // most of C++ types implement ToString() method
String formatted = String::Format(TEXT("my custom message number {0}"), 11); // format strings like a pro
LOG(Info, "Connected: {0}", connected); // print to log
```

For ANSI and UTF-8 strings use `StringAnsi` that holds characters in `char` format (1 byte per-char).

## StringView

`StringView` holds information about a text, except it's not allocated inside it (unlike `String` does) but just provided as a view to a characters sequence with it's length. It doesn't have to be null-terminated. It's used in various Engine APIs and gets implicitly created from String or constant strings.

```cpp
#include "Engine/Core/Types/StringView.h"

StringView myText = TEXT("hello there"); // string view from constant
StringView fromStr = this->ToString(); // string view from string
LOG(Info, "Connected: {0}", myText); // print to log
```

For ANSI and UTF-8 strings use `StringAnsiView` that uses characters in `char` format (1 byte per-char).

## StringBuilder

`StringBuilder` is just like `String` except it uses resizable `Array` under the hood to provide better performance when generating longer strings (eg. generating log message).

```cpp
#include "Engine/Core/Types/StringBuilder.h"

StringBuilder sb;
sb.Append(TEXT("here")); // append strings to the buffer
sb.Append(TEXT(" comes "));
sb.Append(11); // automatic formatting of basic types
sb.AppendFormat(TEXT(" and {0}"), 12); // append formatted text
String str = sb.ToString(); // extract String (or use ToStringView)
LOG(Info, "sb: {0}", str); // print to log
```

## Variant

`Variant` is a multi-purpose value container for generic data types including:
* basic types (eg. `int`, `float`, `bool`)
* common types (eg. `String`, `Guid`)
* math types (eg. `Vector3`, `Transform`, `BoundingBox`)
* collections (eg. `Array<>`, `Dictionary<>`)
* object references (eg. `Asset*`, `Actor*`)
* enum types (eg. `ShadowsCastingMode`)
* structure types (eg. `RayCastHit`)
* raw daya (eg. `byte[]`)
* C# objects references (eg. `MonoObject*`)

It contains wide scripting API for accessing data and querying the value type including casting and comparisions. It can be serialized to raw bytes stream or to json (and loaded back). Scripting API supports automatic translation between `Variant` in C++ and `object` in C#.

```cpp
#include "Engine/Core/Types/Variant.h"

Variant myValue = 11; // store int
LOG(Info, "Variant type: {0}, value: {1}", myValue.Type.ToString(), myValue.ToString());
float asFloat = (float)myValue;
myValue = Vector3(1, 2, 3); // store Vector3
LOG(Info, "Variant type: {0}, value: {1}", myValue.Type.ToString(), myValue.ToString());
myValue = this; // store object reference
LOG(Info, "Variant type: {0}, value: {1}", myValue.Type.ToString(), myValue.ToString());
```

## Guid

`Guid` is *Globally Unique Identifier* that uses 128 bits to encode a number that is meant to be unique. Guids are used for objects identification - each Asset has unique ID and every scripting object uses it too. This allows to reference objects and assets by their ID rather than name. It also means fast objects searching via quick lookup.

```cpp
#include "Engine/Core/Types/Guid.h"

Guid objId = this->GetID(); // get this object id
auto obj = Scripting::FindObject<ScriptingObject>(objId); // find object by id
LOG(Info, "id: {0}", objId); // print to log
```

> [!Tip]
> Flax Guid uses different string represenation compared to .Net Guid. In C# use `FlaxEngine.Json.JsonSerializer.GetStringID(id)` to print `System.Guid` to string in Flax-format (and `ParseID` to parse it back).

## Nullable

For optional values use `Nullable<>` type that supports holding value that can be undefined (not specified).

```cpp
#include "Engine/Core/Types/Nullable.h"

Nullable<int32> optionA;
LOG(Info, "Is Set? {0}", optionA.HasValue());
if (optionA.HasValue())
	LOG(Info, "Value {0}", optionA.GetValue());
optionA = 11;
LOG(Info, "Is Set? {0}", optionA.HasValue());
if (optionA.HasValue())
	LOG(Info, "Value {0}", optionA.GetValue());
```

## Pair

`Pair<Key, Value>` is a structure that wraps the *Key* and *Value* together and can be used to easily connect two values together. Utility method `ToPair` converts two values into a pair structure.

```cpp
#include "Engine/Core/Types/Pair.h"

Pair<int32, float> pair1(11, 200.0f);
int32 key = pair1.First;
float value = pair1.Second;
auto pair2 = ToPair(12, 230.0f);
```

## Span

`Span<>` is a small container for raw data pointer and data length.

```cpp
#include "Engine/Core/Types/Span.h"

byte rawData[] = { 1, 2, 3, 4, 5};
Span<byte> span1(rawData, ARRAY_COUNT(rawData));
byte* ptr = span1.Get(); // memory pointer
int32 length = span1.Length(); // amount of items
```

## DataContainer

`DataContainer<>` works just like `Span<>` except it can contain self allocated memory block and supports easy data serialization and operation with other types. Can be used to manage raw data in memory with an ease. Also, `BytesContainer` which is `DataContainer<byte>` can be used to hold pure bytes data.

```cpp
#include "Engine/Core/Types/DataContainer.h"

DataContainer<float> someFloats;
someFloats.Allocate(10); // Allocate memory for 10 floats
for (int32 i = 0; i < someFloats.Length(); i++)
	someFloats.Get()[i] = 11.0f;

byte rawData[] = { 1, 2, 3, 4, 5};
BytesContainer rawBytes;
rawBytes.Link(rawData, ARRAY_COUNT(rawData)); // Link static data without allocating
rawBytes.Copy(rawData, ARRAY_COUNT(rawData)); // Copy static data into self allocated memory
```

## DateTime

To perform operations based date and calendar use in-built `DateTime` type which contains numerous functionalities such as: date math operations and conversion to string.  It uses ticks in 100 nanoseconds resolution since *January 1, 0001 A.D.* to represent the date and time. Flax also supports accessing current system time in both Local and UTC time (implemented on all supported platforms).

```cpp
#include "Engine/Core/Types/DateTime.h"

DateTime currentDateTime = DateTime::Now();
LOG(Info, "Date and time: {0}", currentDateTime); // print to log
int32 year = currentDateTime.GetYear();
int32 hour = currentDateTime.GetHour();
int32 minute = currentDateTime.GetMinute();
```

## TimeSpan

`TimeSpan` defines a difference between two moments in time. For instance it can be used to perform math on DateTime or to perform conversion between seconds and milliseconds. It offers wide scripting API for timespan calculations.

```cpp
#include "Engine/Core/Types/TimeSpan.h"
#include "Engine/Core/Types/DateTime.h"

auto time1 = DateTime::Now();
Platform::Sleep(10);
auto time2 = DateTime::Now();
TimeSpan timeDiff = time2 - time1; // compute time difference
LOG(Info, "Time diff: {0}", timeDiff); // print to log
double miliseconds = timeDiff.GetTotalMilliseconds();
```

## Version

`Version` represents the version number made of *major*, *minor*, *build* and *revision* numbers. Can be easily parsed from string, compared or converted into string.

```cpp
#include "Engine/Core/Types/Version.h"

Version version1(1, 0);
Version version2(1, 3, 323, 15);
LOG(Info, "Version1: {0}", version1.ToString());
LOG(Info, "Version2: {0}", version2.ToString());
```
