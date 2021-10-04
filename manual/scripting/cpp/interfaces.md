# Interfaces

Flax Scripting API supports using interfaces on classes to splitting unrelated functionality into separate interfaces. This comes useful when desiging larger game systems or when ensuring the code can be extended.

## Interface declaration

Declaring an interface is quite similar to declaring a normal class: simply use `API_INTERFACE` tag. Then you can declare virtual function to be part of the interface.

```cpp
#pragma once

#include "Engine/Scripting/ScriptingType.h"

API_INTERFACE() class GAME_API IMyInterface
{
DECLARE_SCRIPTING_TYPE_MINIMAL(IMyInterface);

	// Interface virtual method
	API_FUNCTION() virtual float GetSpeed(const Vector3& v) = 0;
};
```

> [!Tip]
> Interfaces with an abstract method (deleted virtual) that don't contain `API_FUNCTION` tag are not supported.

## Interface implementation

The next step is to define interface inheritance on an class and implement all it's methods. Interfaces can be implemented on any Scripting Object such as `Script`, `Actor`, `PersistentScriptingObject`. Interface methods are virtual thus they can be overridden also in C# and Visual Scripting.

### C++
```cpp
#pragma once

#include "IMyInterface.h"
#include "Engine/Scripting/Script.h"

// Script that implements custom interface
API_CLASS() class GAME_API InterfaceInCpp : public Script, public IMyInterface
{
API_AUTO_SERIALIZATION();
DECLARE_SCRIPTING_TYPE(InterfaceInCpp);

	float GetSpeed(const Vector3& v) override
    {
		// Implement interface method
		return v.Length();
    }
};
```

### C#
```cs
// Script that implements custom interface
public class InterfaceInCSharp : Script, IMyInterface
{
    public float GetSpeed(Vector3 v)
    {
		// Implement interface method
        return v.Length;
    }
}
```

## Interface calling

### C++
```cpp
#pragma once

#include "IMyInterface.h"
#include "Engine/Scripting/Script.h"

API_CLASS() class GAME_API InterfaceInCpp : public Script
{
API_AUTO_SERIALIZATION();
DECLARE_SCRIPTING_TYPE(InterfaceInCpp);

	// Pointer to object with interface implementation (can be set from other script in C++ or C# or VS)
	API_FIELD() ScriptingObject* MyInterface = nullptr;

    void OnUpdate() override
    {
    	// Cast object into interface
        auto interface = ToInterface<IMyInterface>(MyInterface);
        if (interface)
        {
        	// Call interface method (with with both C++ and C# interface implementations)
        	interface->GetSpeed(Vector3::One);
        }
    }
};
```

### C#
```cs
public class InterfaceInCSharp : Script, IMyInterface
{
    // Reference to object with interface implementation (can be set from other script in C# or VS)
    public FlaxEngine.Object MyInterface;

    public override void OnUpdate()
    {
        // Cast object into interface
        var inter = MyInterface as IMyInterface;
        if (inter != null)
        {
            // Call interface method (with with both C++ and C# interface implementations)
            inter.GetSpeed(Vector3.One);
        }
    }
}
```

## Checking if object implements interface

### C++
```cpp
auto someObject = GetActor();
if (someObject && someObject->GetType().GetInterface(IMyInterface::TypeInitializer))
{
    // someObject implements IMyInterface interface...
}
```

### C#
```cs
var someObject = Actor;
if (someObject is IMyInterface)
{
    // someObject implements IMyInterface interface...
}
```
