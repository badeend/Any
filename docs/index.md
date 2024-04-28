<p align="center">
  <img src="./images/logo.png" alt="Result" width="200"/>
</p>

# Introduction

`Any` is a C# struct that can hold any value of any type, similar to the `object` type, but without the overhead of boxing for small value types (up to 8 bytes). This library is designed to offer flexibility and efficiency when dealing with unknown or dynamic data types while minimizing garbage collection (GC) pressure.

Additionally, it can simplify API design in scenarios where using generics or method overloads is burdensome (or even impossible).

## Installation

[![NuGet Badeend.Any](https://img.shields.io/nuget/v/Badeend.Any?label=Badeend.Any)](https://www.nuget.org/packages/Badeend.Any)

```sh
dotnet add package Badeend.Any
```

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

> [!TIP]
> `Any` provides conversion operators for these (and more) BCL types;
> _implicit_ operators for types that are known to be inlinable, and
> _explicit_ operators for types that that require boxing.
> Due to the large amount of them, they're not shown in the documentation.

## Performance considerations

<details>
  <summary><b>Benchmark results (collapsed)</b></summary>
  
  Keep in mind that the real performance gain is not at the <em>time of allocation</em> (or lack thereof); .NET is pretty good at small allocations. But rather, the benefit will be at the <em>time of collection</em> (or again: lack thereof).

  #### From/to `int`

  | Method                | Mean       | Allocated |
  |---------------------- |-----------:|----------:|
  | `(object)int`         |  3.4404 ns |      24 B |
  | `(Any)int`            |  0.5099 ns |         - |

  | Method                | Mean       | Allocated |
  |---------------------- |-----------:|----------:|
  | `(int)object`         |  0.8044 ns |         - |
  | `(int)any`            |  1.4336 ns |         - |

  #### From/to `int?`

  | Method                | Mean       | Allocated |
  |---------------------- |-----------:|----------:|
  | `(object?)int?`       | 45.3577 ns |      24 B |
  | `(Any)int?`           |  1.0245 ns |         - |

  | Method                | Mean       | Allocated |
  |---------------------- |-----------:|----------:|
  | `(int?)object`        | 10.1198 ns |         - |
  | `(int?)any`           |  1.2666 ns |         - |

  #### From/to `string`

  | Method                | Mean       | Allocated |
  |---------------------- |-----------:|----------:|
  | `(object)string`      |  0.5537 ns |         - |
  | `(Any)string`         |  0.5689 ns |         - |

  | Method                | Mean       | Allocated |
  |---------------------- |-----------:|----------:|
  | `(string?)object`     |  0.9987 ns |         - |
  | `(string?)any`        |  1.2341 ns |         - |

  #### From/to `Guid`

  | Method                | Mean      | Allocated  |
  |---------------------- |----------:|-----------:|
  | `(object)guid`        | 4.2596 ns |       32 B |
  | `(Any)guid`           | 4.2065 ns |       32 B |

  | Method                | Mean      | Allocated  |
  |---------------------- |----------:|-----------:|
  | `(Guid)object`        | 0.7977 ns |          - |
  | `(Guid)any`           | 1.4500 ns |          - |

  > BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)
  > Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
  > .NET SDK 8.0.201

  [More available in the repo.](https://github.com/badeend/Any/tree/main/Badeend.Any.Benchmarks)
</details>

<br/>

The goal of this library is to reduce GC pressure. The real-world impact of this on _your_ application is impossible for me to tell. As always with third-party synthetic benchmarks; try it out into the actual product and measure it to ensure that `Any` is actually a net positive for you.
