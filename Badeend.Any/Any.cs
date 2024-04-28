using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Badeend;

/// <summary>
/// <c>Any</c> is able to hold <em>any</em> value of <em>any</em> type (hence the name).
///
/// This is similar to assigning a value to a variable of type <c>object</c>.
/// The key difference is that converting to <c>Any</c> does <em>not</em> cause
/// boxing for many small struct types as they're stored inline in the <c>Any</c>
/// instance itself. Whereas converting a struct type to <c>object</c> will
/// <em>always</em> box.
/// </summary>
/// <remarks>
/// Boxing is avoided for any value type that:
/// <list type="bullet">
///   <item>is 8 bytes in size or less, <em>and</em>:</item>
///   <item>does not contain references.</item>
/// </list>
///
/// In practice this turns out to be many of the commonly used .NET built-ins:
/// <list type="bullet">
///   <item><c>bool</c></item>
///   <item><c>char</c></item>
///   <item><c>byte</c></item>
///   <item><c>sbyte</c></item>
///   <item><c>short</c></item>
///   <item><c>ushort</c></item>
///   <item><c>int</c></item>
///   <item><c>uint</c></item>
///   <item><c>long</c></item>
///   <item><c>ulong</c></item>
///   <item><c>IntPtr</c> / <c>nint</c></item>
///   <item><c>UIntPtr</c> / <c>nuint</c></item>
///   <item><c>float</c></item>
///   <item><c>double</c></item>
///   <item><c>DateTime</c></item>
///   <item><c>TimeSpan</c></item>
///   <item><c>DateOnly</c></item>
///   <item><c>TimeOnly</c></item>
///   <item><c>Index</c></item>
///   <item><c>Range</c></item>
///   <item>all <c>enum</c>s</item>
///   <item><c>ValueTuple</c>s such as <c>(int, int)</c></item>
/// </list>
///
/// <see cref="Any"/> has a built-in representation for <c>null</c>, which can
/// be checked for with <see cref="HasValue"/>. Because <c>Any</c> can already
/// be null by itself, there's typically no need for having a nullable Any
/// (<c>Any?</c> / <c>Nullable&lt;Any&gt;</c>), as that will result in
/// "double" nullability.
///
/// <br/>
///
/// The <c>default</c> value of <c>Any</c> is <c>null</c>.
///
/// <br/>
///
/// > [!TIP]
/// > `Any` provides conversion operators from/to many BCL types, but those have
/// > been hidden from the documentation due to the sheer amount of them.
/// </remarks>
public readonly partial struct Any : IEquatable<Any>
{
	/// <summary>
	/// This field contains one of the following:
	/// - `null`: The Any represents a null value. The `inlineData` field is 0.
	/// - `Badeend.Any.InlineType`: The Any has prevented boxing by inlining the struct into the `inlineData` field.
	/// - (everything else): The Any represents a heap-allocated object, and this field contains that reference. The `inlineData` field is 0.
	/// </summary>
	private readonly object? typeOrBoxedData;
	private readonly ulong inlineData;

	/// <summary>
	/// Returns <c>true</c> if the value is not <c>null</c>.
	/// </summary>
	[Pure]
	[MemberNotNullWhen(true, nameof(Type))]
	public bool HasValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get => this.typeOrBoxedData is not null;
	}

	/// <summary>
	/// Returns the <see cref="System.Type">Type</see> of the contained
	/// value or <c>null</c> if the value is <c>null</c>.
	/// </summary>
	/// <remarks>
	/// This never returns <c>typeof(Any)</c>.
	/// </remarks>
	[Pure]
	public Type? Type => this.typeOrBoxedData switch
	{
		null => null,
		InlineType v => v.Type,
		var boxedData => boxedData.GetType(),
	};

#if DEBUG
	/// <summary>
	/// For internal use only.
	/// </summary>
	[Pure]
	public bool IsBoxed => this.typeOrBoxedData is not null and not InlineType;
#endif

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Any(object? typeOrHeapData)
	{
		this.typeOrBoxedData = typeOrHeapData;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private Any(InlineType type, ulong inlineData)
	{
		this.typeOrBoxedData = type;
		this.inlineData = inlineData;
	}

	/// <summary>
	/// Wrap the provided <paramref name="value"/> inside a new <see cref="Any"/>,
	/// avoiding boxing whenever possible.
	///
	/// Boxing can be prevented for any value type that:
	/// <list type="bullet">
	///   <item>is 8 bytes in size or less, <em>and</em>:</item>
	///   <item>does not contain references.</item>
	/// </list>
	/// </summary>
	[Pure]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Any Create<T>(T value)
	{
		// The JIT should be able to completely eliminate this if-else-if-else construct and inline just the relevant case body.
		if (default(T) is not null)
		{
			// T is a non-nullable value type.
			return CreateFromNonNullableStruct(value);
		}
		else if (NullableType<T>.IsNullable)
		{
			// T is a nullable value type
			return NullableType<T>.Instance!.Create(value);
		}
		else if (typeof(T) == typeof(object))
		{
			// Singled out `object` because that is the only reference type that is able to contain an Any.
			return CreateFromObject(value);
		}
		else
		{
			// T is a reference type, that is guaranteed not to be castable to Any.
			return new Any(value);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsInlinable<T>()
	{
		return Badeend.RuntimeHelpers.IsReferenceOrContainsReferences<T>() == false && Unsafe.SizeOf<T>() <= sizeof(ulong);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Any CreateFromNonNullableStruct<T>(T value)
	{
		if (typeof(T) == typeof(Any))
		{
			return Unsafe.As<T, Any>(ref value);
		}
		else if (IsInlinable<T>())
		{
			var result = new Any(InlineType<T>.Instance);
			Unsafe.As<ulong, T>(ref Unsafe.AsRef(in result.inlineData)) = value;
			return result;
		}
		else
		{
			return new Any(value);
		}
	}

	private static Any CreateFromObject<T>(T value)
	{
		if (value is Any box)
		{
			return box;
		}
		else
		{
			return new Any(value);
		}
	}

	private abstract class NullableType<TNullable>
	{
		internal static readonly bool IsNullable = Nullable.GetUnderlyingType(typeof(TNullable)) is not null;
		internal static readonly NullableType<TNullable>? Instance = MakeInstance();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal abstract Any Create(TNullable value);

		private static NullableType<TNullable>? MakeInstance()
		{
			var underlyingType = Nullable.GetUnderlyingType(typeof(TNullable));
			if (underlyingType is null)
			{
				return null;
			}

			return (NullableType<TNullable>)Activator.CreateInstance(typeof(NullableTypeImpl<>).MakeGenericType(underlyingType))!;
		}
	}

#pragma warning disable CA1812 // Avoid uninstantiated internal classes => Instantiated using reflection
	private sealed class NullableTypeImpl<T> : NullableType<T?>
		where T : struct
	{
		internal override Any Create(T? value)
		{
			if (value is null)
			{
				return default;
			}
			else
			{
				return CreateFromNonNullableStruct(value.Value);
			}
		}
	}
#pragma warning restore CA1812

	/// <summary>
	/// Attempt to downcast to the specified type <typeparamref name="T"/>.
	/// If the current instance represents <c>null</c>, the attempt always
	/// returns <c>false</c>.
	/// </summary>
	/// <typeparam name="T">The type to downcast to.</typeparam>
	/// <param name="value">On success; the downcast value.</param>
	/// <returns><c>true</c> is the conversion succeeded. Otherwise <c>false</c>.</returns>
	/// <exception cref="InvalidOperationException">
	/// Type parameter <typeparamref name="T"/> is a nullable value type.
	/// </exception>
	/// <remarks>
	/// For more ergonomic access, you might be interested in the
	/// <c>.As&lt;T&gt;()</c>, <c>.Is&lt;T&gt;()</c> and <c>.Cast&lt;T&gt;()</c>
	/// extension methods.
	/// </remarks>
	public bool TryGetValue<T>([MaybeNullWhen(false)] out T value)
		where T : notnull
	{
		if (typeof(T).IsValueType)
		{
			if (NullableType<T>.IsNullable)
			{
				throw new InvalidOperationException("Type parameter passed to Any.TryGetValue may not be a nullable value type.");
			}

			return this.TryGetNonNullableStructValue<T>(out value);
		}
		else
		{
			return this.TryGetReferenceValue<T>(out value);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool IsNonNullableStructValue<T>()
		where T : struct
	{
		return (IsInlinable<T>() && this.typeOrBoxedData == InlineType<T>.Instance) || this.typeOrBoxedData is T;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool TryGetNonNullableStructValue<T>([MaybeNullWhen(false)] out T value)
	{
		if (IsInlinable<T>() && this.typeOrBoxedData == InlineType<T>.Instance)
		{
			value = Unsafe.As<ulong, T>(ref Unsafe.AsRef(in this.inlineData));
			return true;
		}

		return this.TryGetNonNullableStructValue_NoInline<T>(out value);
	}

	private bool TryGetNonNullableStructValue_NoInline<T>([MaybeNullWhen(false)] out T value)
	{
		if (this.typeOrBoxedData is T typedData)
		{
			value = typedData;
			return true;
		}

		value = default;
		return false;
	}

	internal bool IsClassValue<T>()
	{
		if (this.typeOrBoxedData is InlineType valueType)
		{
			return valueType.Is<T>();
		}

		return this.typeOrBoxedData is T;
	}

	internal bool TryGetReferenceValue<T>([MaybeNullWhen(false)] out T value)
	{
		if (this.typeOrBoxedData is InlineType valueType)
		{
			return valueType.TryGetValue<T>(this.inlineData, out value);
		}

		if (this.typeOrBoxedData is T typedData)
		{
			value = typedData;
			return true;
		}

		value = default;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal T CastRequiredStruct<T>()
		where T : struct
	{
		if (IsInlinable<T>() && this.typeOrBoxedData == InlineType<T>.Instance)
		{
			return Unsafe.As<ulong, T>(ref Unsafe.AsRef(in this.inlineData));
		}

		return (T)this.typeOrBoxedData!;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal T? CastNullableStruct<T>()
		where T : struct
	{
		if (IsInlinable<T>() && this.typeOrBoxedData == InlineType<T>.Instance)
		{
			return Unsafe.As<ulong, T>(ref Unsafe.AsRef(in this.inlineData));
		}

		return (T?)this.typeOrBoxedData;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal T CastRequiredClass<T>()
		where T : class
	{
		if (this.typeOrBoxedData is T typedData)
		{
			return typedData;
		}

		return this.CastRequiredClass_NoInline<T>();
	}

	private T CastRequiredClass_NoInline<T>()
		where T : class
	{
		if (this.typeOrBoxedData is InlineType valueType && valueType.TryGetValue<T>(this.inlineData, out var value))
		{
			// T is an interface, implemented by the value type.
			return value;
		}

		// CastRequiredStruct uses a regular cast as its fallback.
		// Regular casts throw NRE when null. Therefore: so must we.
		if (this.typeOrBoxedData is null)
		{
#pragma warning disable CA2201 // Do not raise reserved exception types
			throw new NullReferenceException();
#pragma warning restore CA2201 // Do not raise reserved exception types
		}
		else
		{
			throw new InvalidCastException();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal T? CastNullableClass<T>()
		where T : class
	{
		if (this.typeOrBoxedData is T typedData)
		{
			return typedData;
		}

		return this.CastNullableClass_NoInline<T>();
	}

	private T? CastNullableClass_NoInline<T>()
		where T : class
	{
		if (this.typeOrBoxedData is null)
		{
			return null;
		}

		if (this.typeOrBoxedData is InlineType valueType && valueType.TryGetValue<T>(this.inlineData, out var value))
		{
			// T is an interface, implemented by the value type.
			return value;
		}

		throw new InvalidCastException();
	}

	/// <summary>
	/// WARNING! `T` may not be `object` or an interface.
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private T? CastSpecificClassUnchecked<T>()
		where T : class
	{
		return (T?)this.typeOrBoxedData;
	}

	/// <summary>
	/// Check if the two <see cref="Any"/> instances are identical.
	///
	/// This is checked by comparing the object references to the heap data
	/// and the raw bitpattern of the inlined struct data (if any).
	///
	/// It does <em>not</em> call the inner value's <c>.Equals</c> implementation.
	/// </summary>
	/// <remarks>
	/// This is the spiritual equivalent of <c>Object.ReferenceEquals(a, b)</c>,
	/// but for <c>Any</c> instances.
	/// </remarks>
	[Pure]
	public static bool AreIdentical(Any a, Any b) => a.typeOrBoxedData == b.typeOrBoxedData && a.inlineData == b.inlineData;

	/// <summary>
	/// Call the inner value's <c>.Equals</c> implementation.
	///
	/// Which <c>.Equals</c> method is called depends on the runtime values of <c>this</c> and <paramref name="other"><c>other</c></paramref>:
	/// <list type="bullet">
	///   <item>If both are <c>null</c>: <c>true</c></item>
	///   <item>If only one is <c>null</c>: <c>false</c></item>
	///   <item>If both are inlined structs of the same type: <c>EqualityComparer&lt;T&gt;.Default.Equals(this, other)</c></item>
	///   <item>If both are inlined structs, but of different types: <c>false</c></item>
	///   <item>If <c>this</c> is heap allocated and <c>other</c> is inlined: <c>other.Equals((object)this)</c></item>
	///   <item>All other cases: <c>this.Equals((object)other)</c></item>
	/// </list>
	/// </summary>
	[Pure]
	public bool Equals(Any other)
	{
		if (this.typeOrBoxedData is null)
		{
			return other.typeOrBoxedData is null;
		}

		if (other.typeOrBoxedData is null)
		{
			return false;
		}

		if (this.typeOrBoxedData is InlineType thisType)
		{
			if (other.typeOrBoxedData is InlineType otherType)
			{
				if (thisType == otherType)
				{
					return thisType.EquatableEquals(this.inlineData, other.inlineData);
				}
				else
				{
					return false;
				}
			}
			else
			{
				return thisType.ObjectEquals(this.inlineData, other.typeOrBoxedData);
			}
		}
		else
		{
			if (other.typeOrBoxedData is InlineType otherType)
			{
				return otherType.ObjectEquals(other.inlineData, this.typeOrBoxedData);
			}
			else
			{
				return this.typeOrBoxedData.Equals(other.typeOrBoxedData);
			}
		}
	}

#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
	/// <inheritdoc/>
	[Pure]
	[Obsolete("Avoid unnecessary boxing, use the == or != operator instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals(object? obj) => this.Equals(Create(obj));
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member

	/// <summary>
	/// Check for equality using the inner value's <c>.Equals</c> implementation.
	/// </summary>
	[Pure]
	public static bool operator ==(Any left, Any right) => left.Equals(right);

	/// <summary>
	/// Check for inequality using the inner value's <c>.Equals</c> implementation.
	/// </summary>
	[Pure]
	public static bool operator !=(Any left, Any right) => !left.Equals(right);

	/// <summary>
	/// Box the inner value, if it wasn't already.
	/// </summary>
	[Pure]
	public object? ToObject() => this.typeOrBoxedData switch
	{
		null => null,
		InlineType v => v.ToObject(this.inlineData),
		var boxedData => boxedData,
	};

	/// <summary>
	/// Invoke <see cref="object.GetHashCode()"/> on the inner value.
	/// </summary>
	[Pure]
	public override int GetHashCode() => this.typeOrBoxedData switch
	{
		null => 0,
		InlineType v => v.GetHashCode(this.inlineData),
		var boxedData => boxedData.GetHashCode(),
	};

	/// <summary>
	/// Invoke <see cref="object.ToString()"/> on the inner value.
	/// </summary>
	[Pure]
	public override string? ToString() => this.typeOrBoxedData switch
	{
		null => string.Empty,
		InlineType v => v.ToString(this.inlineData),
		var boxedData => boxedData.ToString(),
	};

	/// <summary>
	/// Returns <c>typeof(Any)</c>. It does <b>not</b> return the type of the content.
	/// For that, use the <see cref="Type"/> property.
	/// </summary>
	[Pure]
	[Obsolete("For clarity, use the `.Type` property or `typeof(Any)` depending on what you want.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Type GetType() => base.GetType();
}
