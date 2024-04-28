using Badeend;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

namespace Badeend.Benchmarks;

public static class Benchmark
{
	internal const int Iterations = 10_000_000;

	public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Benchmark).Assembly).Run(args);
}
