using System.ComponentModel;

#pragma warning disable CA2225 // Operator overloads have named alternates

namespace Badeend;

/// <content>
/// Constructors and conversions from/to common BCL types.
/// The conversions in this file implicitly require little endian for correctness.
/// </content>
public readonly partial struct Any
{
	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(bool value) => new(InlineType<bool>.Instance, value ? 1UL : 0UL);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(bool value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator bool(Any any) => any.Cast<bool>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(bool? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(bool? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator bool?(Any any) => any.CastNullable<bool>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(sbyte value) => new(InlineType<sbyte>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(sbyte value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator sbyte(Any any) => any.Cast<sbyte>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(sbyte? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(sbyte? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator sbyte?(Any any) => any.CastNullable<sbyte>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(byte value) => new(InlineType<byte>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(byte value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator byte(Any any) => any.Cast<byte>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(byte? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(byte? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator byte?(Any any) => any.CastNullable<byte>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(short value) => new(InlineType<short>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(short value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator short(Any any) => any.Cast<short>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(short? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(short? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator short?(Any any) => any.CastNullable<short>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(ushort value) => new(InlineType<ushort>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(ushort value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator ushort(Any any) => any.Cast<ushort>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(ushort? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(ushort? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator ushort?(Any any) => any.CastNullable<ushort>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(int value) => new(InlineType<int>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(int value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator int(Any any) => any.Cast<int>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(int? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(int? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator int?(Any any) => any.CastNullable<int>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(uint value) => new(InlineType<uint>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(uint value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator uint(Any any) => any.Cast<uint>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(uint? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(uint? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator uint?(Any any) => any.CastNullable<uint>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(long value) => new(InlineType<long>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(long value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator long(Any any) => any.Cast<long>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(long? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(long? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator long?(Any any) => any.CastNullable<long>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(ulong value) => new(InlineType<ulong>.Instance, value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(ulong value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator ulong(Any any) => any.Cast<ulong>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(ulong? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(ulong? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator ulong?(Any any) => any.CastNullable<ulong>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(nint value) => new(InlineType<nint>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(nint value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator nint(Any any) => any.Cast<nint>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(nint? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(nint? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator nint?(Any any) => any.CastNullable<nint>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(nuint value) => new(InlineType<nuint>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(nuint value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator nuint(Any any) => any.Cast<nuint>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(nuint? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(nuint? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator nuint?(Any any) => any.CastNullable<nuint>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(char value) => new(InlineType<char>.Instance, unchecked((ulong)value));

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(char value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator char(Any any) => any.Cast<char>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(char? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(char? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator char?(Any any) => any.CastNullable<char>();

#if NET5_0_OR_GREATER
	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Half value) => Create<Half>(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(Half value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Half(Any any) => any.Cast<Half>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Half? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(Half? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Half?(Any any) => any.CastNullable<Half>();
#endif

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(float value) => Create<float>(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(float value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator float(Any any) => any.Cast<float>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(float? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(float? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator float?(Any any) => any.CastNullable<float>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(double value) => Create<double>(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(double value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator double(Any any) => any.Cast<double>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(double? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(double? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator double?(Any any) => any.CastNullable<double>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(DateTime value) => Create<DateTime>(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(DateTime value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator DateTime(Any any) => any.Cast<DateTime>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(DateTime? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(DateTime? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator DateTime?(Any any) => any.CastNullable<DateTime>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(TimeSpan value) => Create<TimeSpan>(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(TimeSpan value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator TimeSpan(Any any) => any.Cast<TimeSpan>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(TimeSpan? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(TimeSpan? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator TimeSpan?(Any any) => any.CastNullable<TimeSpan>();

#if NET6_0_OR_GREATER
/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(DateOnly value) => Create<DateOnly>(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(DateOnly value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator DateOnly(Any any) => any.Cast<DateOnly>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(DateOnly? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(DateOnly? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator DateOnly?(Any any) => any.CastNullable<DateOnly>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(TimeOnly value) => Create<TimeOnly>(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(TimeOnly value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator TimeOnly(Any any) => any.Cast<TimeOnly>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(TimeOnly? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(TimeOnly? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator TimeOnly?(Any any) => any.CastNullable<TimeOnly>();
#endif

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Index value) => Create<Index>(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(Index value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Index(Any any) => any.Cast<Index>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Index? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(Index? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Index?(Any any) => any.CastNullable<Index>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Range value) => Create<Range>(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(Range value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Range(Any any) => any.Cast<Range>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Range? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(Range? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Range?(Any any) => any.CastNullable<Range>();
#endif

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(decimal value) => Create<decimal>(value);

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(decimal value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator decimal(Any any) => any.Cast<decimal>();

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(decimal? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(decimal? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator decimal?(Any any) => any.CastNullable<decimal>();

#if NET7_0_OR_GREATER
	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Int128 value) => Create<Int128>(value);

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(Int128 value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Int128(Any any) => any.Cast<Int128>();

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Int128? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(Int128? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Int128?(Any any) => any.CastNullable<Int128>();

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(UInt128 value) => Create<UInt128>(value);

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(UInt128 value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator UInt128(Any any) => any.Cast<UInt128>();

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(UInt128? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(UInt128? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator UInt128?(Any any) => any.CastNullable<UInt128>();
#endif

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Guid value) => Create<Guid>(value);

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(Guid value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Guid(Any any) => any.Cast<Guid>();

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(Guid? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(Guid? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Guid?(Any any) => any.CastNullable<Guid>();

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(DateTimeOffset value) => Create<DateTimeOffset>(value);

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(DateTimeOffset value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator DateTimeOffset(Any any) => any.Cast<DateTimeOffset>();

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(DateTimeOffset? value) => value.HasValue ? Create(value.Value) : default;

	/// <summary>
	/// Create <see cref="Any"/> <em>by boxing</em> the provided <paramref name="value"/>.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator Any(DateTimeOffset? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator DateTimeOffset?(Any any) => any.CastNullable<DateTimeOffset>();

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static Any Create(string? value) => new(value);

	/// <summary>
	/// Create <see cref="Any"/> from the provided <paramref name="value"/> without boxing.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator Any(string? value) => Create(value);

	/// <summary>
	/// Cast to target type. Throws an exception if the conversion is not possible.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator string?(Any any) => any.CastSpecificClassUnchecked<string>();
}
