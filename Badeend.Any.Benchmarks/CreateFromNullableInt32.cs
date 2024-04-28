using BenchmarkDotNet.Attributes;

namespace Badeend.Benchmarks;

[MemoryDiagnoser]
[DisassemblyDiagnoser]
public class CreateFromNullableInt32
{
	private readonly int?[] nullableInts = Enumerable.Repeat<int?>(123, Benchmark.Iterations).ToArray();

	[Benchmark(Description = "(object?)int?")]
	public object? CastObject()
	{
		object? obj = null;

		foreach (var i in nullableInts)
		{
			obj = (object?)i;
		}

		return obj;
	}

	[Benchmark(Description = "Any.Create<T>(int?)")]
	public Any AnyCreate()
	{
		Any any = default;

		foreach (var i in nullableInts)
		{
			any = Any.Create<int?>(i);
		}

		return any;
	}

	[Benchmark(Description = "Any.Create(int?)")]
	public Any AnyCreateSpecialized()
	{
		Any any = default;

		foreach (var i in nullableInts)
		{
			any = Any.Create(i);
		}

		return any;
	}
}
