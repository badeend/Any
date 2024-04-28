using BenchmarkDotNet.Attributes;

namespace Badeend.Benchmarks;

[MemoryDiagnoser]
[DisassemblyDiagnoser]
public class CastToGuid
{
	private readonly object[] objects = Enumerable.Repeat<object>(Guid.NewGuid(), Benchmark.Iterations).ToArray();
	private readonly Any[] anies = Enumerable.Repeat<Any>((Any)Guid.NewGuid(), Benchmark.Iterations).ToArray();

	[Benchmark(Description = "(Guid)object")]
	public Guid FromObject()
	{
		Guid result = default;

		foreach (var o in objects)
		{
			result = (Guid)o;
		}

		return result;
	}

	[Benchmark(Description = "any.Cast<Guid>()")]
	public Guid FromAny()
	{
		Guid result = default;

		foreach (var a in anies)
		{
			result = a.Cast<Guid>();
		}

		return result;
	}
}
