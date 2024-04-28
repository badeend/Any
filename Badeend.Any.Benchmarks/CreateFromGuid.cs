using BenchmarkDotNet.Attributes;

namespace Badeend.Benchmarks;

[MemoryDiagnoser]
[DisassemblyDiagnoser]
public class CreateFromGuid
{
	private readonly Guid[] guids = Enumerable.Repeat(Guid.NewGuid(), Benchmark.Iterations).ToArray();

	[Benchmark(Description = $"(object)guid")]
	public object? CastObject()
	{
		object? obj = null;

		foreach (var g in guids)
		{
			obj = (object)g;
		}

		return obj;
	}

	[Benchmark(Description = "Any.Create(guid)")]
	public Any AnyCreate()
	{
		Any any = default;

		foreach (var g in guids)
		{
			any = Any.Create(g);
		}

		return any;
	}
}
