using BenchmarkDotNet.Attributes;

namespace Badeend.Benchmarks;

[MemoryDiagnoser]
[DisassemblyDiagnoser]
public class CastToNullableInt32
{
	private readonly object[] objects = Enumerable.Repeat<object>(123, Benchmark.Iterations).ToArray();
	private readonly Any[] anies = Enumerable.Repeat<Any>(123, Benchmark.Iterations).ToArray();

	[Benchmark(Description = "(int?)object")]
	public int? FromObject()
	{
		int? result = 0;

		foreach (var o in objects)
		{
			result = (int?)o;
		}

		return result;
	}

	[Benchmark(Description = "any.CastNullable<int>()")]
	public int? FromAny()
	{
		int? result = 0;

		foreach (var a in anies)
		{
			result = a.CastNullable<int>();
		}

		return result;
	}
}
