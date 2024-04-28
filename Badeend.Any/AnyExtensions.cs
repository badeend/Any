using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

#pragma warning disable SA1649 // File name should match first type name

namespace Badeend;

/// <summary>
/// Extension methods for <see cref="Any"/> constrained to <c>where T : struct</c>.
/// </summary>
public static class AnyValueExtensions
{
	/// <summary>
	/// Check if the value is of the specified type <typeparamref name="T"/>.
	///
	/// This is the equivalent of the C# <c>is</c> operator:
	/// <code>
	/// // Using objects:
	/// if (obj is int) { /* ... */ }
	///
	/// // Using Any:
	/// if (any.Is&lt;int&gt;()) { /* ... */ }
	/// </code>
	/// </summary>
	[Pure]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool Is<T>(this Any any)
		where T : struct
	{
		return any.IsNonNullableStructValue<T>();
	}

	/// <summary>
	/// Check if the value is of the specified type <typeparamref name="T"/>
	/// cast to that type if it is.
	///
	/// This is the equivalent of the C# <c>is</c> operator:
	/// <code>
	/// // Using objects:
	/// if (obj is int x) { /* ... */ }
	///
	/// // Using Any:
	/// if (any.Is(out int x)) { /* ... */ }
	/// </code>
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool Is<T>(this Any any, [MaybeNullWhen(false)] out T value)
		where T : struct
	{
		return any.TryGetNonNullableStructValue<T>(out value);
	}

	/// <summary>
	/// Attempt to cast the inner value to the specified type <typeparamref name="T"/>.
	/// If the cast isn't possible, <c>null</c> is returned.
	///
	/// This is the equivalent of the C# <c>as</c> operator:
	/// <code>
	/// // Using objects:
	/// int? x = obj as int?;
	///
	/// // Using Any:
	/// int? x = any.As&lt;int&gt;();
	/// </code>
	/// </summary>
	[Pure]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T? As<T>(this Any any)
		where T : struct
	{
		return any.TryGetNonNullableStructValue<T>(out var value) ? value : null;
	}

	/// <summary>
	/// Attempt to cast the inner value to the specified type <typeparamref name="T"/>.
	/// If the cast isn't possible, an exception will be thrown.
	///
	/// This is the equivalent of the C# cast expression:
	/// <code>
	/// // Using objects:
	/// int x = (int)obj;
	///
	/// // Using Any:
	/// int x = any.Cast&lt;int&gt;();
	/// </code>
	/// </summary>
	/// <exception cref="InvalidCastException">
	/// The inner value is not of type <typeparamref name="T"/>.
	/// </exception>
	/// <exception cref="NullReferenceException">
	/// The inner value is null.
	/// </exception>
	/// <remarks>
	/// Alternatively to calling this method, for many of the .NET built-in value
	/// types you can use regular cast syntax instead, e.g. <c>(int)myAny</c>.
	/// </remarks>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T Cast<T>(this Any any)
		where T : struct
	{
		return any.CastRequiredStruct<T>();
	}

	/// <summary>
	/// Attempt to cast the inner value to the specified type <typeparamref name="T"/>.
	/// If the inner value is null, this method returns null too.
	/// If the inner value is not null but the cast isn't possible,
	/// an exception will be thrown.
	///
	/// This is the equivalent of the C# cast expression:
	/// <code>
	/// // Using objects:
	/// int? x = (int?)obj;
	///
	/// // Using Any:
	/// int? x = any.CastNullable&lt;int&gt;();
	/// </code>
	/// </summary>
	/// <exception cref="InvalidCastException">
	/// The inner value is not of type <typeparamref name="T"/>.
	/// </exception>
	/// <remarks>
	/// Alternatively to calling this method, for many of the .NET built-in value
	/// types you can use regular cast syntax instead, e.g. <c>(int?)myAny</c>.
	/// </remarks>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T? CastNullable<T>(this Any any)
		where T : struct
	{
		return any.CastNullableStruct<T>();
	}
}

/// <summary>
/// Extension methods for <see cref="Any"/> constrained to <c>where T : class</c>.
/// </summary>
public static class AnyReferenceExtensions
{
	/// <summary>
	/// Check if the value is of the specified type <typeparamref name="T"/>.
	///
	/// This is the equivalent of the C# <c>is</c> operator:
	/// <code>
	/// // Using objects:
	/// if (obj is string) { /* ... */ }
	///
	/// // Using Any:
	/// if (any.Is&lt;string&gt;()) { /* ... */ }
	/// </code>
	/// </summary>
	[Pure]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool Is<T>(this Any any)
		where T : class
	{
		return any.IsClassValue<T>();
	}

	/// <summary>
	/// Check if the value is of the specified type <typeparamref name="T"/>
	/// cast to that type if it is.
	///
	/// This is the equivalent of the C# <c>is</c> operator:
	/// <code>
	/// // Using objects:
	/// if (obj is string x) { /* ... */ }
	///
	/// // Using Any:
	/// if (any.Is(out string x)) { /* ... */ }
	/// </code>
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool Is<T>(this Any any, [MaybeNullWhen(false)] out T value)
		where T : class
	{
		return any.TryGetReferenceValue<T>(out value);
	}

	/// <summary>
	/// Attempt to cast the inner value to the specified type <typeparamref name="T"/>.
	/// If the cast isn't possible, <c>null</c> is returned.
	///
	/// This is the equivalent of the C# <c>as</c> operator:
	/// <code>
	/// // Using objects:
	/// string? x = obj as string;
	///
	/// // Using Any:
	/// string? x = any.As&lt;string&gt;();
	/// </code>
	/// </summary>
	[Pure]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T? As<T>(this Any any)
		where T : class
	{
		return any.TryGetReferenceValue<T>(out var value) ? value : null;
	}

	/// <summary>
	/// Attempt to cast the inner value to the specified type <typeparamref name="T"/>.
	/// If the cast isn't possible, an exception will be thrown.
	///
	/// This is the equivalent of the C# cast expression followed by a null check:
	/// <code>
	/// // Using objects:
	/// string x = (string?)obj ?? throw new NullReferenceException();
	///
	/// // Using Any:
	/// string x = any.Cast&lt;string&gt;();
	/// </code>
	/// </summary>
	/// <exception cref="InvalidCastException">
	/// The inner value is not of type <typeparamref name="T"/>.
	/// </exception>
	/// <exception cref="NullReferenceException">
	/// The inner value is null.
	/// </exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T Cast<T>(this Any any)
		where T : class
	{
		return any.CastRequiredClass<T>();
	}

	/// <summary>
	/// Attempt to cast the inner value to the specified type <typeparamref name="T"/>.
	/// If the inner value is null, this method returns null too.
	/// If the inner value is not null but the cast isn't possible,
	/// an exception will be thrown.
	///
	/// This is the equivalent of the C# cast expression:
	/// <code>
	/// // Using objects:
	/// string? x = (string?)obj;
	///
	/// // Using Any:
	/// string? x = any.CastNullable&lt;string&gt;();
	/// </code>
	/// </summary>
	/// <exception cref="InvalidCastException">
	/// The inner value is not of type <typeparamref name="T"/>.
	/// </exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T? CastNullable<T>(this Any any)
		where T : class
	{
		return any.CastNullableClass<T>();
	}
}
