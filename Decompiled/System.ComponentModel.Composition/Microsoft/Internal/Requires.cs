using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace Microsoft.Internal;

internal static class Requires
{
	[DebuggerStepThrough]
	public static void NotNullOrNullElements<T>(IEnumerable<T> values, string parameterName) where T : class
	{
		NotNull(values, parameterName);
		NotNullElements(values, parameterName);
	}

	[DebuggerStepThrough]
	public static void NullOrNotNullElements<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>>? values, string parameterName) where TKey : class where TValue : class
	{
		NotNullElements(values, parameterName);
	}

	[DebuggerStepThrough]
	public static void NullOrNotNullElements<T>(IEnumerable<T>? values, string parameterName) where T : class
	{
		NotNullElements(values, parameterName);
	}

	[DebuggerStepThrough]
	private static void NotNullElements<T>(IEnumerable<T> values, string parameterName) where T : class
	{
		if (values == null)
		{
			return;
		}
		foreach (T value in values)
		{
			if (value == null)
			{
				throw ExceptionBuilder.CreateContainsNullElement(parameterName);
			}
		}
	}

	[DebuggerStepThrough]
	public static void NullOrNotNullElements<T>(T[]? values, string parameterName) where T : class
	{
		NotNullElements(values, parameterName);
	}

	[DebuggerStepThrough]
	private static void NotNullElements<T>(T[] values, string parameterName) where T : class
	{
		if (values == null)
		{
			return;
		}
		foreach (T val in values)
		{
			if (val == null)
			{
				throw ExceptionBuilder.CreateContainsNullElement(parameterName);
			}
		}
	}

	[DebuggerStepThrough]
	private static void NotNullElements<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> values, string parameterName) where TKey : class where TValue : class
	{
		if (values == null)
		{
			return;
		}
		foreach (KeyValuePair<TKey, TValue> value in values)
		{
			if (value.Key == null || value.Value == null)
			{
				throw ExceptionBuilder.CreateContainsNullElement(parameterName);
			}
		}
	}

	[DebuggerStepThrough]
	public static void IsInMembertypeSet(MemberTypes value, string parameterName, MemberTypes enumFlagSet)
	{
		if ((value & enumFlagSet) != value || (value & (value - 1)) != 0)
		{
			throw new ArgumentException(System.SR.Format(System.SR.ArgumentOutOfRange_InvalidEnumInSet, parameterName, value, enumFlagSet.ToString()), parameterName);
		}
	}

	public static void NotNull<T>(T value, string parameterName) where T : class
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}

	public static void NotNullOrEmpty(string value, string parameterName)
	{
		NotNull(value, parameterName);
		if (value.Length == 0)
		{
			throw new ArgumentException(System.SR.Format(System.SR.ArgumentException_EmptyString, parameterName), parameterName);
		}
	}
}
