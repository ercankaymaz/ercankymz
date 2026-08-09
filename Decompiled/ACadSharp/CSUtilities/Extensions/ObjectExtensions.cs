using System;
using System.Runtime.CompilerServices;

namespace CSUtilities.Extensions;

internal static class ObjectExtensions
{
	public delegate bool Check<T>(T obj);

	public static void ThrowIfNull(this object parameter)
	{
		if (parameter != null)
		{
			return;
		}
		throw new ArgumentNullException();
	}

	public static void ThrowIfNull(this object parameter, string paramName)
	{
		if (parameter != null)
		{
			return;
		}
		throw new ArgumentNullException(paramName);
	}

	public static void ThrowIfNull(this object parameter, string paramName, string message)
	{
		if (parameter != null)
		{
			return;
		}
		throw new ArgumentNullException(paramName, message);
	}

	public static void ThrowIf<T, E>(this T parameter, Check<T> check) where E : Exception, new()
	{
		if (check(parameter))
		{
			throw new E();
		}
	}

	public static void ThrowIf<T, E>(this T parameter, Check<T> check, string message) where E : Exception, new()
	{
		if (check(parameter))
		{
			throw Activator.CreateInstance(typeof(E), message) as E;
		}
	}

	public static void GreaterThan<T>(this T value, T min, bool inclusive = true, [CallerMemberName] string name = null) where T : struct, IComparable<T>
	{
		int num = value.CompareTo(min);
		if (num <= -1 || (!inclusive && num == 0))
		{
			throw new ArgumentOutOfRangeException(name, value, $"{name} valid values are from {min}.");
		}
	}

	public static void InRange<T>(this T value, T min, T max, bool inclusive = true, [CallerMemberName] string name = null) where T : struct, IComparable<T>
	{
		value.InRange(min, max, $"{name} valid values are from {min} to {max}.", inclusive, name);
	}

	public static void InRange<T>(this T value, T min, T max, string message, bool inclusive = true, [CallerMemberName] string name = null) where T : struct, IComparable<T>
	{
		int num = value.CompareTo(max);
		int num2 = value.CompareTo(min);
		bool flag = !inclusive && (num == 0 || num2 == 0);
		if (num >= 1 || num2 <= -1 || flag)
		{
			throw new ArgumentOutOfRangeException(name, value, message);
		}
	}
}
