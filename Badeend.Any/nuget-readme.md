
`Any` is a C# struct that can hold any value of any type, similar to the `object` type, but without the overhead of boxing for small value types (up to 8 bytes). This library is designed to offer flexibility and efficiency when dealing with unknown or dynamic data types while minimizing garbage collection (GC) pressure.

Additionally, it can simplify API design in scenarios where using generics or method overloads is burdensome (or even impossible).

---

**Documentation & more information at: https://badeend.github.io/Any/**

---

## Usage

In its most basic form, it can be as simple as this:
```cs
Any a = 42; // Does not allocate.
Any b = "Hello world";
Any c = DateTime.UtcNow;

// Somewhere down the line:

var i = (int)a;
var s = (string)b;
var d = (DateTime)c;
```

Unlike `object`, two `Any` instances are considered equal when their content is the same:
```cs
Any x = 123;
Any y = 123;

// If you were to use `object`, the following line would fail:
Assert(x == y); // => true
```

More operations are available as extension methods:
```cs
_ = a.As<int>(); // Similar to: `a as int?`
_ = a.Is<int>(); // Similar to: `a is int`
_ = a.Cast<int>(); // Similar to: `(int)a`
```

[Full API reference](https://badeend.github.io/Any/api/Badeend.html)

## When can boxing be avoided?

Data can be inlined into the `Any` instance itself for any `struct` type (including user-defined types) that:
- is 8 bytes in size or less, _and_:
- does not contain references.

In practice this turns out to be many of the commonly used .NET built-ins:
- `bool`
- `char`
- `byte`
- `sbyte`
- `short`
- `ushort`
- `int`
- `uint`
- `long`
- `ulong`
- `nint` / `IntPtr`
- `nuint` / `UIntPtr`
- `float`
- `double`
- `DateTime`
- `TimeSpan`
- `DateOnly`
- `TimeOnly`
- `Index`
- `Range`
- all `enum`s
- `ValueTuple`s such as `(int, int)`

### Shameless self-promotion

May I interest you in one of my other packages?

- **[Badeend.ValueCollections](https://badeend.github.io/ValueCollections/)**: _Low overhead immutable collection types with structural equality._
- **[Badeend.EnumClass](https://badeend.github.io/EnumClass/)**: _Discriminated unions for C# with exhaustiveness checking._
- **[Badeend.Result](https://badeend.github.io/Result/)**: _For failures that are not exceptional: `Result<T,E>` for C#._
- **[Badeend.Any](https://badeend.github.io/Any/)**: _Holds any value of any type, without boxing small structs (up to 8 bytes)._
- **[Badeend.Nothing](https://github.com/badeend/Nothing)**: _If you want to use `void` as a type parameter, but C# won't let you._