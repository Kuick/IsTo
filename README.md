# IsTo
### Any type or object checking and conversion extension.


## Features
### Is
**Check any type or object inherits from any class or implemented by any interface.**

1. `value.Is<T>()`  
    From Type or Object to check by **_Generic_**. 
2. `value.Is(Type type)`  
    From Type or Object to check by **_Type_**. 


### To
**Any type of object convert to any type.**

1. `value.To<T>()`  
    From any type of Object convert to any type by **_Generic_**. 
2. `value.TryTo<T>(out T result)`  
    From any type of Object try to convert to any type by **_Generic_**. 
3. `value.To(Type type)`  
    From any type of Object convert to any type by **_Type_**. 


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
**value.Is&lt;T&gt;()** Check by **_Generic_**  
```C#
// 1. from Type
var value = typeof(Int32);
value.Is<Int32>(); // true

// 2. from Object
var value = 123;
value.Is<Int32>(); // true
```

**value.Is(Type type)** Check by **_Type_**  
```C#
// 1. from Type
var value = typeof(Int32);
value.Is(typeof(Int32)); // true

// 2. from Object
var value = 123;
value.Is(typeof(Int32)); // true
```


### To
There is an enumeration for example:  
```C#
public enum Animal
{
	Bird,
	Cat,
	Dog
}
```

**value.To&lt;T&gt;()** Convert by **_Generic_**  
```C#
var value = new[] { Animal.Cat, Animal.Dog };

// Convert to array
var result1 = value.To<int[]>(); // { 1, 2 }
var result2 = value.To<string[]>(); // { "Cat", "Dog" }

// Convert to List<T>
var result3 = value.To<List<int>>();
var result4 = value.To<List<string>>();
```

**value.TryTo&lt;T&gt;(out T result)** Try Convert by **_Generic_**  
```C#
var value = new[] { Animal.Cat, Animal.Dog };

// Try to Convert to array
int[] result;
if(value.TryTo<int[]>(out result)){
    // Success
} else {
    // Failure
}
```

**value.To(Type type)** Convert by **_Type_**  
```C#
var value = new[] { Animal.Cat, Animal.Dog };
var type = typeof(int[]);

// Convert to array
var result1 = value.To(type); // { 1, 2 }
```


## License
* __[Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0)__

