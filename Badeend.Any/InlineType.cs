using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Badeend;

internal abstract class InlineType
{
	internal abstract Type Type { get; }

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal abstract bool TryGetValue<TOutput>(ulong input, [MaybeNullWhen(false)] out TOutput output);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal abstract bool Is<TOutput>();

	internal abstract int GetHashCode(ulong input);

	internal abstract string? ToString(ulong input);

	internal abstract bool EquatableEquals(ulong left, ulong right);

	internal abstract bool ObjectEquals(ulong left, object? right);

	internal abstract object ToObject(ulong input);
}

internal sealed class InlineType<T> : InlineType
{
	internal static readonly InlineType<T> Instance = new();

	private InlineType()
	{
		Debug.Assert(typeof(T).IsValueType);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static T FromLong(ulong input) => Unsafe.As<ulong, T>(ref Unsafe.AsRef(in input));

	internal override Type Type { get; } = typeof(T);

	internal override bool Is<TOutput>()
	{
		return default(T) is TOutput;
	}

	internal override bool TryGetValue<TOutput>(ulong input, [MaybeNullWhen(false)] out TOutput output)
	{
		if (FromLong(input) is TOutput targetType)
		{
			output = targetType;
			return true;
		}

		output = default;
		return false;
	}

	internal override int GetHashCode(ulong input) => FromLong(input)!.GetHashCode();

	internal override string? ToString(ulong input) => FromLong(input)!.ToString();

	internal override bool EquatableEquals(ulong left, ulong right) => EqualityComparer<T>.Default.Equals(FromLong(left), FromLong(right));

	internal override bool ObjectEquals(ulong left, object? right) => FromLong(left)!.Equals(right);

	internal override object ToObject(ulong input) => FromLong(input)!;
}
