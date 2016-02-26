# IsTo
Any type or object checking and conversion extension methods.

## Is
Checking any type or object inherits from any class or implemented by any interface.

```C#
value.Is<T>()
value.Is(Type type)
```

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


## To
Any type of object convert to any type.

```C#
value.To<T>()
value.TryTo<T>(out T result)
value.To(Type type)
```

**value.To<T>()**


**value.TryTo<T>(out T result)**


**value.To(Type type)**



## License
* __[Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0)__
