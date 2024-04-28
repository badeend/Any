using BenchmarkDotNet.Attributes;

namespace Badeend.Benchmarks;

[MemoryDiagnoser]
[DisassemblyDiagnoser]
public class CreateFromString
{
	private readonly string[] strings = Enumerable.Repeat("My string", Benchmark.Iterations).ToArray();

	[Benchmark(Description = "(object)string")]
	public object? CastObject()
	{
		object? obj = null;

		foreach (var str in strings)
		{
			obj = (object)str;
		}

		return obj;
	}

	[Benchmark(Description = "Any.Create<T>(string)")]
	public Any AnyCreate()
	{
		Any any = default;

		foreach (var str in strings)
		{
			any = Any.Create<string>(str);
		}

		return any;
	}

	[Benchmark(Description = "Any.Create(string)")]
	public Any AnyCreateSpecialized()
	{
		Any any = default;

		foreach (var str in strings)
		{
			any = Any.Create(str);
		}

		return any;
	}
}
