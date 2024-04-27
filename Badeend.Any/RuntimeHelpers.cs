using System.Reflection;
using System.Runtime.CompilerServices;

namespace Badeend;

internal static class RuntimeHelpers
{
#if NETSTANDARD2_0
	/*
	The following polyfill for System.Runtime.CompilerServices.RuntimeHelpers.IsReferenceOrContainsReferences<T>()
	has been adapted from the .NET runtime:
	https://github.com/dotnet/corefx/blob/v2.2.8/src/System.Memory/src/System/SpanHelpers.cs#L129
	*/
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsReferenceOrContainsReferences<T>() => PerTypeValues<T>.IsReferenceOrContainsReferences;

	private static bool IsReferenceOrContainsReferencesCore(Type type)
	{
		if (type.GetTypeInfo().IsPrimitive)
		{
			return false;
		}

		if (!type.GetTypeInfo().IsValueType)
		{
			return true;
		}

		// If type is a Nullable<> of something, unwrap it first.
		var underlyingNullable = Nullable.GetUnderlyingType(type);
		if (underlyingNullable != null)
		{
			type = underlyingNullable;
		}

		if (type.GetTypeInfo().IsEnum)
		{
			return false;
		}

		foreach (var field in type.GetTypeInfo().DeclaredFields)
		{
			if (field.IsStatic)
			{
				continue;
			}

			if (IsReferenceOrContainsReferencesCore(field.FieldType))
			{
				return true;
			}
		}

		return false;
	}

	private static class PerTypeValues<T>
	{
		internal static readonly bool IsReferenceOrContainsReferences = IsReferenceOrContainsReferencesCore(typeof(T));
	}

#else

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool IsReferenceOrContainsReferences<T>() => System.Runtime.CompilerServices.RuntimeHelpers.IsReferenceOrContainsReferences<T>();

#endif
}
