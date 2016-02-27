# IsTo
### Any type or object checking and conversion extension.

## Features
### Is
Checking any type or object inherits from any class or implemented by any interface.

1. `value.Is<T>()`<br>
    From Type or Object to check by Generic. 
2. `value.Is(Type type)`<br>
    From Type or Object to check by Type. 

### To
Any type of object convert to any type.

1. `value.To<T>()`<br>
    From any type of Object convert to any type by Generic. 
2. `value.TryTo<T>(out T result)`<br>
    From any type of Object try to convert to any type by Generic. 
3. `value.To(Type type)`<br>
    From any type of Object convert to any type by Type. 

## Installation
IsTo can be installed via the nuget UI (as [IsTo](https://www.nuget.org/packages/IsTo/)), or via the nuget package manager console:
```
PM> Install-Package IsTo
```
If you require a strong-named package (because your project is strong-named), then you may wish to use instead:
```
PM> Install-Package IsTo.StrongName
```

## How to use
After installed this package, add `using IsTo;` on your source code and enjoy the convenience from it.

### Is
**value.Is&lt;T&gt;()** Check by Generic
```C#
// 1. from Type
var value = typeof(Int32);
value.Is<Int32>(); // true

// 2. from Object
var value = 123;
value.Is<Int32>(); // true
```

**value.Is(Type type)** Check by Type
```C#
// 1. from Type
var value = typeof(Int32);
value.Is(typeof(Int32)); // true

// 2. from Object
var value = 123;
value.Is(typeof(Int32)); // true
```


### To
**value.To&lt;T&gt;()** Convert by Generic
```C#
```

**value.TryTo&lt;T&gt;(out T result)** Try Convert by Generic
```C#
```

**value.To(Type type)** Convert by Type
```C#
```

## License
* __[Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0)__
