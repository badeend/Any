using BenchmarkDotNet.Attributes;

namespace Badeend.Benchmarks;

[MemoryDiagnoser]
[DisassemblyDiagnoser]
public class CastToString
{
	private readonly object[] objects = Enumerable.Repeat<object>("My string", Benchmark.Iterations).ToArray();
	private readonly Any[] anies = Enumerable.Repeat<Any>("My string", Benchmark.Iterations).ToArray();

	[Benchmark(Description = "(string?)object")]
	public string? FromObject()
	{
		string? result = null;

		foreach (var o in objects)
		{
			result = (string?)o;
		}

		return result;
	}

	[Benchmark(Description = "any.CastNullable<string>()")]
	public string? FromAny()
	{
		string? result = null;

		foreach (var a in anies)
		{
			result = a.CastNullable<string>();
		}

		return result;
	}

	[Benchmark(Description = "(string?)any")]
	public string? FromAnySpecialized()
	{
		string? result = null;

		foreach (var a in anies)
		{
			result = (string?)a;
		}

		return result;
	}
}
