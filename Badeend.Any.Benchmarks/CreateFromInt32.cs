using BenchmarkDotNet.Attributes;

namespace Badeend.Benchmarks;

[MemoryDiagnoser]
[DisassemblyDiagnoser]
public class CreateFromInt32
{
	private readonly int[] ints = Enumerable.Repeat(123, Benchmark.Iterations).ToArray();

	[Benchmark(Description = $"(object)int")]
	public object? CastObject()
	{
		object? obj = null;

		foreach (var i in ints)
		{
			obj = (object)i;
		}

		return obj;
	}

	[Benchmark(Description = "Any.Create<T>(int)")]
	public Any AnyCreate()
	{
		Any any = default;

		foreach (var i in ints)
		{
			any = Any.Create<int>(i);
		}

		return any;
	}

	[Benchmark(Description = "Any.Create(int)")]
	public Any AnyCreateSpecialized()
	{
		Any any = default;

		foreach (var i in ints)
		{
			any = Any.Create(i);
		}

		return any;
	}
}
