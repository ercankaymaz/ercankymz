using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SharpGLTF;

[DebuggerStepThrough]
internal static class GuardAll
{
	public static void NotNull<T>(IEnumerable<T> collection, string parameterName, string message = "")
	{
		SharpGLTF.Guard.NotNull(collection, "collection");
		foreach (T item in collection)
		{
			SharpGLTF.Guard.NotNull(item, parameterName, message);
		}
	}

	public static void AreTrue(IEnumerable<bool> collection, string parameterName, Func<int, string> messageFunc = null)
	{
		SharpGLTF.Guard.NotNull(collection, "collection");
		int num = 0;
		foreach (bool item in collection)
		{
			SharpGLTF.Guard.IsTrue(item, parameterName, messageFunc?.Invoke(num) ?? string.Empty);
			num++;
		}
	}

	public static void MustBeEqualTo<TValue>(IEnumerable<TValue> collection, TValue expected, string parameterName) where TValue : IComparable<TValue>
	{
		SharpGLTF.Guard.NotNull(collection, "collection");
		foreach (TValue item in collection)
		{
			SharpGLTF.Guard.MustBeEqualTo(item, expected, parameterName);
		}
	}

	public static void MustBeGreaterThan<TValue>(IEnumerable<TValue> collection, TValue minExclusive, string parameterName) where TValue : IComparable<TValue>
	{
		SharpGLTF.Guard.NotNull(collection, "collection");
		foreach (TValue item in collection)
		{
			SharpGLTF.Guard.MustBeGreaterThan(item, minExclusive, parameterName);
		}
	}

	public static void MustBeLessThan<TValue>(IEnumerable<TValue> collection, TValue maxExclusive, string parameterName) where TValue : IComparable<TValue>
	{
		SharpGLTF.Guard.NotNull(collection, "collection");
		foreach (TValue item in collection)
		{
			SharpGLTF.Guard.MustBeLessThan(item, maxExclusive, parameterName);
		}
	}

	public static void MustBeLessThanOrEqualTo<TValue>(IEnumerable<TValue> collection, TValue maxInclusive, string parameterName) where TValue : IComparable<TValue>
	{
		SharpGLTF.Guard.NotNull(collection, "collection");
		foreach (TValue item in collection)
		{
			SharpGLTF.Guard.MustBeLessThanOrEqualTo(item, maxInclusive, parameterName);
		}
	}

	public static void MustBeGreaterThanOrEqualTo<TValue>(IEnumerable<TValue> collection, TValue minInclusive, string parameterName) where TValue : IComparable<TValue>
	{
		SharpGLTF.Guard.NotNull(collection, "collection");
		foreach (TValue item in collection)
		{
			SharpGLTF.Guard.MustBeGreaterThanOrEqualTo(item, minInclusive, parameterName);
		}
	}

	public static void MustBeBetweenOrEqualTo<TValue>(IEnumerable<TValue> collection, TValue minInclusive, TValue maxInclusive, string parameterName) where TValue : IComparable<TValue>
	{
		SharpGLTF.Guard.NotNull(collection, "collection");
		foreach (TValue item in collection)
		{
			SharpGLTF.Guard.MustBeBetweenOrEqualTo(item, minInclusive, maxInclusive, parameterName);
		}
	}
}
