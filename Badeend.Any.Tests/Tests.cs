using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Badeend;

namespace Badeend.Tests;

#pragma warning disable CS1718 // Comparison made to same variable
#pragma warning disable CS0618 // Type or member is obsolete

public class Tests
{
	[Fact]
	public void Size()
	{
		Assert.Equal(2 * sizeof(ulong), Unsafe.SizeOf<Any>());
	}

	[Fact]
	public void Coalesce()
	{
		var regularAny = Any.Create(123);
		var boxedAny = (object)Any.Create(123);
		Any a = Any.Create<Any>(regularAny);
		Any b = Any.Create<object>(boxedAny);

		Assert.False(a.IsBoxed);
		Assert.False(b.IsBoxed);
		Assert.Equal(typeof(int), a.Type);
		Assert.Equal(typeof(int), b.Type);
	}

	[Fact]
	public void ValueTypes()
	{
		AssertOk(123, 123);
		AssertOk(123, Any.Create(123));
		AssertOk(123, Any.Create((int?)123));
		AssertOk(123, Any.Create<int>(123));
		AssertOk(123, Any.Create<int?>(123));
		AssertOk(123, Any.Create<object>(123));

		Assert.True(Any.BitwiseEquals(123, 123));
		Assert.False(Any.BitwiseEquals(123, 987));
		Assert.False(Any.BitwiseEquals(123, Any.Create<object>(123)));

		static void AssertOk(int expected, Any any)
		{
			Assert.True(any.HasValue);

			Assert.Equal(typeof(int), any.Type);
			Assert.Equal(typeof(Any), any.GetType());

			Assert.True(any.Is<int>());
			Assert.True(any.Is<object>());
			Assert.False(any.Is<uint>());
			Assert.False(any.Is<string>());

			Assert.True(any.Is<int>(out var i1) == true && i1 == expected);
			Assert.True(any.TryGetValue<int>(out var i2) == true && i2 == expected);

			Assert.True(any.Is<object>(out var i3) == true && (int)i3 == expected);
			Assert.True(any.TryGetValue<object>(out var i4) == true && (int)i4 == expected);

			Assert.True(any.Is<uint>(out var i5) == false && i5 == default);
			Assert.True(any.TryGetValue<uint>(out var i6) == false && i6 == default);

			Assert.True(any.Is<string>(out var i7) == false && i7 == default);
			Assert.True(any.TryGetValue<string>(out var i8) == false && i8 == default);

			Assert.True(any.As<int>() == expected);
			Assert.True((int)any.As<object>()! == expected);
			Assert.True(any.As<uint>() == null);
			Assert.True(any.As<string>() == null);

			Assert.True((int)any == expected);
			Assert.True(any.Cast<int>() == expected);
			Assert.True((int)any.Cast<object>() == expected);
			Assert.Throws<InvalidCastException>(() => (uint)any);
			Assert.Throws<InvalidCastException>(() => any.Cast<uint>());
			Assert.Throws<InvalidCastException>(() => any.Cast<string>());

			Assert.True((int?)any == expected);
			Assert.True(any.CastNullable<int>() == expected);
			Assert.True((int)any.CastNullable<object>()! == expected);
			Assert.Throws<InvalidCastException>(() => (uint?)any);
			Assert.Throws<InvalidCastException>(() => any.CastNullable<uint>());
			Assert.Throws<InvalidCastException>(() => (string?)any);
			Assert.Throws<InvalidCastException>(() => any.CastNullable<string>());

#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
			Assert.Throws<InvalidOperationException>(() => any.TryGetValue<int?>(out _));
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.

			Assert.True(any == any);
			Assert.True(any == expected);
			Assert.True(any == Any.Create(expected));
			Assert.True(any == Any.Create((int?)expected));
			Assert.True(any == Any.Create<int>(expected));
			Assert.True(any == Any.Create<int?>(expected));
			Assert.True(any == Any.Create<object>(expected));

			Assert.False(any != any);
			Assert.True(any != 4321);
			Assert.True(any != 4321U);
			Assert.True(any != "Bad");
			Assert.True(any != default);

			Assert.True((int)any.ToObject()! == expected);
			Assert.Equal(expected.GetHashCode(), any.GetHashCode());
			Assert.Equal(expected.ToString(), any.ToString());
		}
	}

	[Fact]
	public void ReferenceTypes()
	{
		AssertOk("Test", "Test");
		AssertOk("Test", Any.Create("Test"));
		AssertOk("Test", Any.Create<string>("Test"));
		AssertOk("Test", Any.Create<object>("Test"));

		var a = "hello";
		var b = "HELLO".ToLowerInvariant();
		Assert.True(a == b);
		Assert.False(Object.ReferenceEquals(a, b));

		Assert.True(Any.BitwiseEquals(a, a));
		Assert.False(Any.BitwiseEquals(a, b));

		static void AssertOk(string expected, Any any)
		{
			Assert.True(any.HasValue);

			Assert.Equal(typeof(string), any.Type);
			Assert.Equal(typeof(Any), any.GetType());

			Assert.True(any.Is<string>());
			Assert.True(any.Is<object>());
			Assert.False(any.Is<int>());
			Assert.False(any.Is<IPAddress>());

			Assert.True(any.Is<string>(out var s1) == true && s1 == expected);
			Assert.True(any.Is<object>(out var s2) == true && (string)s2 == expected);
			Assert.True(any.Is<int>(out var s3) == false && s3 == default);
			Assert.True(any.Is<IPAddress>(out var s4) == false && s4 == default);

			Assert.True(any.As<string>() == expected);
			Assert.True((string)any.As<object>()! == expected);
			Assert.True(any.As<int>() == null);
			Assert.True(any.As<IPAddress>() == null);

			Assert.True(any.Cast<string>() == expected);
			Assert.True((string)any.Cast<object>() == expected);
			Assert.Throws<InvalidCastException>(() => (int)any);
			Assert.Throws<InvalidCastException>(() => any.Cast<int>());
			Assert.Throws<InvalidCastException>(() => any.Cast<IPAddress>());

			Assert.True((string?)any == expected);
			Assert.True(any.CastNullable<string>() == expected);
			Assert.True((string)any.CastNullable<object>()! == expected);
			Assert.Throws<InvalidCastException>(() => (int?)any);
			Assert.Throws<InvalidCastException>(() => any.CastNullable<int>());
			Assert.Throws<InvalidCastException>(() => any.CastNullable<IPAddress>());

#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
			Assert.Throws<InvalidOperationException>(() => any.TryGetValue<int?>(out _));
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.

			Assert.True(any == any);
			Assert.True(any == expected);
			Assert.True(any == Any.Create(expected));
			Assert.True(any == Any.Create<string>(expected));
			Assert.True(any == Any.Create<object>(expected));

			Assert.False(any != any);
			Assert.True(any != default);
			Assert.True(any != 4321);
			Assert.True(any != 4321U);
			Assert.True(any != "Bad");
			Assert.True(any != Any.Create(IPAddress.Loopback));

			Assert.True((string)any.ToObject()! == expected);
			Assert.Equal(expected.GetHashCode(), any.GetHashCode());
			Assert.Equal(expected.ToString(), any.ToString());
		}
	}

	[Fact]
	public void Nullability()
	{
		AssertOk(default);
		AssertOk(Any.Create((int?)null));
		AssertOk(Any.Create<int?>(null));
		AssertOk(Any.Create((string?)null));
		AssertOk(Any.Create<string?>(null));
		AssertOk(Any.Create<object?>(null));

		Assert.True(Any.BitwiseEquals(default, default));
		Assert.True(Any.BitwiseEquals(default, Any.Create<int?>(null)));
		Assert.True(Any.BitwiseEquals(default, Any.Create<object?>(null)));
		Assert.False(Any.BitwiseEquals(default, string.Empty));
		Assert.False(Any.BitwiseEquals(default, 0));

		static void AssertOk(Any any)
		{
			Assert.False(any.HasValue);

			Assert.Null(any.Type);
			Assert.Equal(typeof(Any), any.GetType());

			Assert.False(any.Is<string>());
			Assert.False(any.Is<object>());
			Assert.False(any.Is<int>());

			Assert.True(any.Is<string>(out var s1) == false && s1 == default);
			Assert.True(any.Is<object>(out var s2) == false && s2 == default);
			Assert.True(any.Is<int>(out var s3) == false && s3 == default);

			Assert.True(any.As<string>() == null);
			Assert.True(any.As<object>() == null);
			Assert.True(any.As<int>() == null);

			Assert.Throws<NullReferenceException>(() => any.Cast<string>());
			Assert.Throws<NullReferenceException>(() => any.Cast<object>());
			Assert.Throws<NullReferenceException>(() => any.Cast<int>());
			Assert.Throws<NullReferenceException>(() => (int)any);

			Assert.True(any.CastNullable<string>() == null);
			Assert.True(any.CastNullable<object>() == null);
			Assert.True(any.CastNullable<int>() == null);
			Assert.True((int?)any == null);
			Assert.True((string?)any == null);

#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
			Assert.Throws<InvalidOperationException>(() => any.TryGetValue<int?>(out _));
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.

			Assert.True(any == any);
			Assert.True(any == default);
			Assert.True(any == Any.Create((int?)null));
			Assert.True(any == Any.Create<int?>(null));
			Assert.True(any == Any.Create((string?)null));
			Assert.True(any == Any.Create<string?>(null));
			Assert.True(any == Any.Create<object?>(null));

			Assert.False(any != any);
			Assert.True(any != 4321);
			Assert.True(any != 4321U);
			Assert.True(any != "Bad");
			Assert.True(any != Any.Create(IPAddress.Loopback));

			Assert.True(any.ToObject() is null);
			Assert.Equal(0, any.GetHashCode());
			Assert.Equal(string.Empty, any.ToString());
		}
	}

	[Fact]
	public void Specializations()
	{
		AssertBoxed<object>(123);

		AssertBoxed<Enum>(MyEnum.C);
		AssertNotBoxed<MyEnum>(MyEnum.C);

		AssertIdentical(true, Any.Create<bool>(true));
		AssertNotBoxed<bool>(true);
		AssertIdentical(false, Any.Create<bool>(false));
		AssertNotBoxed<bool>(false);

		AssertIdentical('c', Any.Create<char>('c'));
		AssertNotBoxed<char>('c');

#if NETCOREAPP3_0_OR_GREATER
		AssertNotBoxed<Rune>(new('c'));
#endif

		Assert.True((Any)"Test" == Any.Create<string>("Test"));
		AssertBoxed<string>(string.Empty);
		AssertBoxed<string>("Test");

		AssertIdentical((byte)123, Any.Create<byte>(123));
		AssertNotBoxed<byte>(123);
		AssertIdentical((sbyte)123, Any.Create<sbyte>(123));
		AssertNotBoxed<sbyte>(123);

		AssertIdentical((short)123, Any.Create<short>(123));
		AssertNotBoxed<short>(123);
		AssertIdentical((ushort)123, Any.Create<ushort>(123));
		AssertNotBoxed<ushort>(123);

		AssertIdentical((int)123, Any.Create<int>(123));
		AssertNotBoxed<int>(123);
		AssertIdentical((uint)123, Any.Create<uint>(123));
		AssertNotBoxed<uint>(123);

		AssertIdentical((long)123, Any.Create<long>(123));
		AssertNotBoxed<long>(123);
		AssertIdentical((ulong)123, Any.Create<ulong>(123));
		AssertNotBoxed<ulong>(123);

#if NET7_0_OR_GREATER
		Assert.True((Any)new Int128(123, 456) == Any.Create<Int128>(new(123, 456)));
		AssertBoxed<Int128>(new(123, 456));
		Assert.True((Any)new UInt128(123, 456) == Any.Create<UInt128>(new(123, 456)));
		AssertBoxed<UInt128>(new(123, 456));
#endif

		AssertIdentical(new IntPtr(123), Any.Create<IntPtr>(new(123)));
		AssertNotBoxed<IntPtr>(new(123));
		AssertIdentical(new UIntPtr(123), Any.Create<UIntPtr>(new(123)));
		AssertNotBoxed<UIntPtr>(new(123));

		AssertIdentical((nint)123, Any.Create<nint>(123));
		AssertNotBoxed<nint>(123);
		AssertIdentical((nuint)123, Any.Create<nuint>(123));
		AssertNotBoxed<nuint>(123);

#if NET5_0_OR_GREATER
		AssertIdentical((Half)1.23f, Any.Create<Half>((Half)1.23f));
		AssertNotBoxed<Half>((Half)1.23f);
#endif
		AssertIdentical(1.23f, Any.Create<float>(1.23f));
		AssertNotBoxed<float>(1.23f);
		AssertIdentical(1.23d, Any.Create<double>(1.23d));
		AssertNotBoxed<double>(1.23d);

		Assert.True((Any)1.23m == Any.Create<decimal>(1.23m));
		AssertBoxed<decimal>(1.23m);

		var someDateTime = DateTime.UtcNow;
		AssertIdentical(someDateTime, Any.Create<DateTime>(someDateTime));
		AssertNotBoxed<DateTime>(someDateTime);

		var someDateTimeOffset = DateTimeOffset.UtcNow;
		Assert.True((Any)someDateTimeOffset == Any.Create<DateTimeOffset>(someDateTimeOffset));
		AssertBoxed<DateTimeOffset>(DateTimeOffset.UtcNow);

		var someTimeSpan = TimeSpan.FromDays(123);
		AssertIdentical(someTimeSpan, Any.Create<TimeSpan>(someTimeSpan));
		AssertNotBoxed<TimeSpan>(someTimeSpan);
#if NET6_0_OR_GREATER
		var someDateOnly = DateOnly.FromDateTime(DateTime.UtcNow);
		AssertIdentical(someDateOnly, Any.Create<DateOnly>(someDateOnly));
		AssertNotBoxed<DateOnly>(someDateOnly);

		var someTimeOnly = TimeOnly.FromDateTime(DateTime.UtcNow);
		AssertIdentical(someTimeOnly, Any.Create<TimeOnly>(someTimeOnly));
		AssertNotBoxed<TimeOnly>(someTimeOnly);
#endif

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
		AssertIdentical(new Index(123), Any.Create<Index>(123));
		AssertNotBoxed<Index>(123);

		AssertIdentical(new Range(123, 124), Any.Create<Range>(new(123, 124)));
		AssertNotBoxed<Range>(new(123, 124));
#endif

		var someGuid = Guid.NewGuid();
		Assert.True((Any)someGuid == Any.Create<Guid>(someGuid));
		AssertBoxed<Guid>(Guid.NewGuid());

		AssertNotBoxed<ValueTuple>(ValueTuple.Create());
		AssertNotBoxed<ValueTuple<int>>(ValueTuple.Create(123));
		AssertNotBoxed<(int, int)>((123, 456));
		AssertNotBoxed<(byte, byte, byte, byte, byte, byte, byte)>((1, 2, 3, 4, 5, 6, 7));

		AssertBoxed<ValueTuple<string>>(ValueTuple.Create("Test"));
		AssertBoxed<(long, long)>((123, 456));
		AssertBoxed<(int, int, int, int)>((1, 2, 3, 4));
		AssertBoxed<(string, string)>(("a", "b"));

		AssertNotBoxed<KeyValuePair<int, int>>(new(123, 456));

		AssertBoxed<KeyValuePair<string, int>>(new("Test", 456));
	}

	private static void AssertBoxed<T>(T value)
		where T : notnull
	{
		Any a = Any.Create<T>(value);

		Assert.True(a.HasValue);
		Assert.True(a.IsBoxed);

		Assert.True(a.TryGetValue<T>(out var b) == true && EqualityComparer<T>.Default.Equals(b, value));
		Assert.True(a.TryGetValue<object>(out var o) == true && EqualityComparer<T>.Default.Equals((T)o, value));
	}

	private static void AssertNotBoxed<T>(T value)
		where T : notnull
	{
		Any a = Any.Create<T>(value);

		Assert.True(a.HasValue);
		Assert.False(a.IsBoxed);

		Assert.True(a.TryGetValue<T>(out var b) == true && EqualityComparer<T>.Default.Equals(b, value));
		Assert.True(a.TryGetValue<object>(out var o) == true && EqualityComparer<T>.Default.Equals((T)o, value));
	}

	private static void AssertIdentical(Any left, Any right)
	{
		Assert.Equal(left.HasValue, right.HasValue);
		Assert.Equal(left.IsBoxed, right.IsBoxed);
		Assert.Equal(left.Type, right.Type);

		Assert.True(left == right);
		Assert.True(Any.BitwiseEquals(left, right));
	}

	private enum MyEnum
	{
		A,
		B,
		C,
	}
}
