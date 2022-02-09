# String Formatting for C\+\+ in Flax

Flax uses [fmt](https://fmt.dev/5.3.0/index.html) lib to format strings. The formatting syntax is similar to the one in C# and is considered as easy to use and quite extensible. The same formatting style can be used also in `LOG` macro to print formatted messages.

## Syntax

Format strings contain `replacement fields` surrounded by curly braces `{}`. Anything that is not contained in braces is considered literal text, which is copied unchanged to the output. If you need to include a brace character in the literal text, it can be escaped by doubling: `{{` and `}}`.

To learn more see the reference: [fmt syntax](https://fmt.dev/5.3.0/syntax.html).

## Examples

Example usage of `String::Format` that provides string formatting. Macro `LOG_STR` prints the String directly to the Output Log.

```cpp
auto str1 = String::Format(TEXT("a: {0}, b: {1}, a: {0}"), TEXT("a"), TEXT("b"));
LOG_STR(Info, str1);
auto str2 = String::Format(TEXT("1: {}, 2: {}, 3: {}"), 1, 2, 3);
LOG_STR(Info, str2);
auto str3 = String::Format(TEXT("vector: {0}"), Vector3(1, 2, 3));
LOG_STR(Info, str3);
auto str4 = String::Format(TEXT("string: {0}"), this->ToString());
LOG_STR(Info, str4);
auto str5 = String::Format(TEXT("boolean: {0}"), true);
LOG_STR(Info, str5);
```

## Custom Type Formatting

Here is an example how to implement automatic formatting for custom types:

```cpp
// Custom structure
struct MyStruct
{
	Vector2 Direction;
	float Speed;
};

// Use helper define to declare printing for a custom structure
#include "Engine/Core/Formatting.h"
DEFINE_DEFAULT_FORMATTING(MyStruct, "Direction:{0} Speed:{1}", v.Direction, v.Speed);

// Print structure as string
MyStruct data = { Vector2(1, 2), 10.0f };
auto str1 = String::Format(TEXT("{0}"), data);
LOG_STR(Info, str1);
```

## Named Arguments

String format text can can contain ordered arguments such as `{0}`, `{1}`, `{2}`, `{}`, etc. but also named arguments like `{PlayerName}`, `{Currency}`, etc. This can be implemented by using `fmt::arg(argName, argValue)` passed to the string format function.

```cpp
String text1 = String::Format(TEXT("text: {0}, {1}"), TEXT("one"), TEXT("two"));
String text2 = String::Format(TEXT("text: {arg0}, {arg1}"), fmt::arg(TEXT("arg0"), TEXT("one")), fmt::arg(TEXT("arg1"), TEXT("two")));
ASSERT(text1 == text2);
```
