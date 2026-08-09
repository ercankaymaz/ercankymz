using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Collections;

internal static class ThrowHelper
{
	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	internal static void ThrowKeyNotFound<TKey>(TKey key)
	{
		throw new KeyNotFoundException(System.SR.Format(System.SR.Arg_KeyNotFoundWithKey, key));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	internal static void ThrowDuplicateKey<TKey>(TKey key)
	{
		throw new ArgumentException(System.SR.Format(System.SR.Argument_AddingDuplicate, key), "key");
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	internal static void ThrowConcurrentOperation()
	{
		throw new InvalidOperationException(System.SR.InvalidOperation_ConcurrentOperationsNotSupported);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	internal static void ThrowIndexArgumentOutOfRange()
	{
		throw new ArgumentOutOfRangeException("index");
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	internal static void ThrowVersionCheckFailed()
	{
		throw new InvalidOperationException(System.SR.InvalidOperation_EnumFailedVersion);
	}

	public static void ThrowIfNull([System.Diagnostics.CodeAnalysis.NotNull] object argument, [CallerArgumentExpression("argument")] string paramName = null)
	{
		if (argument == null)
		{
			ThrowNull(paramName);
		}
	}

	public static void ThrowIfNegative(int value, [CallerArgumentExpression("value")] string paramName = null)
	{
		if (value < 0)
		{
			ThrowNegative(value, paramName);
		}
	}

	public static void ThrowIfGreaterThan<T>(T value, T other, [CallerArgumentExpression("value")] string paramName = null) where T : IComparable<T>
	{
		if (value.CompareTo(other) > 0)
		{
			ThrowGreater(value, other, paramName);
		}
	}

	public static void ThrowIfLessThan<T>(T value, T other, [CallerArgumentExpression("value")] string paramName = null) where T : IComparable<T>
	{
		if (value.CompareTo(other) < 0)
		{
			ThrowLess(value, other, paramName);
		}
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	private static void ThrowNull(string paramName)
	{
		throw new ArgumentNullException(paramName);
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	private static void ThrowNegative(int value, string paramName)
	{
		throw new ArgumentOutOfRangeException(paramName, value, System.SR.Format(System.SR.ArgumentOutOfRange_Generic_MustBeNonNegative, paramName, value));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	private static void ThrowGreater<T>(T value, T other, string paramName)
	{
		throw new ArgumentOutOfRangeException(paramName, value, System.SR.Format(System.SR.ArgumentOutOfRange_Generic_MustBeLessOrEqual, paramName, value, other));
	}

	[System.Diagnostics.CodeAnalysis.DoesNotReturn]
	private static void ThrowLess<T>(T value, T other, string paramName)
	{
		throw new ArgumentOutOfRangeException(paramName, value, System.SR.Format(System.SR.ArgumentOutOfRange_Generic_MustBeGreaterOrEqual, paramName, value, other));
	}
}
