# Logging and Assertions for C\+\+ in Flax

## Output Log

The best way to log data and messages from C++ code is to use the `LOG` macros that output messages directly to the engine log output file (in folder `projectFolder/Logs`) and to the *Output Log* window in Editor.

To access logging tool use the following include:

```cpp
#include "Engine/Core/Log.h"
```

Then you can use the following macros:
* `LOG(messageType, format, arguments..)` - formats the message with arguments and prints it to the log (see [formatting docs](string-formatting.md))
* `LOG_STR(messageType, str)` - writes the string to the log

Supported message types:
* `Info`
* `Warning`
* `Error`
* `Fatal`

Examples:

```cpp
String info = TEXT("Object: ") + this->ToString();
LOG_STR(Info, info);
LOG(Warning, "hello there! {0}", info);
LOG(Error, "player speed: {0}, direction: {1}", 11.0f, Vector3::UnitX);
```

Those logs are also redirected to the low-level platform output (via `Platform::Log`) so can be seen when using target platform debugger andor utilities (eg. *Visual Studio* program output, or Android *adb* output).

## Debug Log

C++ API contains access to `DebugLog` utility used in C# scripts. It displays messages in *Debug Log* window in Editor. It also supports showing the complete stack trace of the log location for easier debugging (including copying messages with *Ctrl+C*).

Examples:

```cpp
#include "Engine/Debug/DebugLog.h"

DebugLog::Log(LogType::Info, TEXT("Hello there!"));
DebugLog::LogError(String::Format(TEXT("error number: {0}"), 11));
```

## Assertions

To prevent invalid code execution or to provide validation for runtime values you can use assertions in your code. Assertion are a hard way of validation and result in crash.

Example:

```cpp
const int32 counter = 100;
ASSERT(counter != 0); // will assert if counter gets set to 0
```

## Checks

Checks work just like assertions instead are not crashing the program but just result in error and return from current scope method.

Example:

```cpp
const int32 counter = 100;
CHECK(counter != 0); // will print error and return if counter gets set to 0

CHECK_RETURN(counter != 0, false); // will print error and return false if count == 0
```

## Stack Traces

Flax supports capturing the stack trace of the current thread execution for both C++ and C# code. This feature might not be supported on all platforms and is disabled in *Release* builds.

Example:

```cpp
#include "Engine/Debug/DebugLog.h"

String managedStackTrace = DebugLog::GetStackTrace();
LOG_STR(Info, managedStackTrace);

String nativeStackTrace = Platform::GetStackTrace();
LOG_STR(Info, nativeStackTrace);
```
