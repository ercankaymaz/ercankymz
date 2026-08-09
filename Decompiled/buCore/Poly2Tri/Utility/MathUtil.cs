using System;
using System.Collections.Generic;

namespace Poly2Tri.Utility;

public class MathUtil
{
	public const double EPSILON = 1E-12;

	public static bool AreValuesEqual(double val1, double val2, double tolerance = 1E-12)
	{
		if (val1 < val2 - tolerance || !(val1 <= val2 + tolerance))
		{
			return false;
		}
		return true;
	}

	public static bool IsValueBetween(double val, double min, double max, double tolerance)
	{
		if (min > max)
		{
			double num = min;
			min = max;
			max = num;
		}
		if (val + tolerance < min || !(val - tolerance <= max))
		{
			return false;
		}
		return true;
	}

	public static double RoundWithPrecision(double f, double precision)
	{
		if (!(precision < 0.0))
		{
			double num = Math.Pow(10.0, precision);
			return Math.Floor(f * num) / num;
		}
		return f;
	}

	public static double Clamp(double a, double low, double high)
	{
		return Math.Max(low, Math.Min(a, high));
	}

	public static void Swap<T>(ref T a, ref T b)
	{
		T val = a;
		a = b;
		b = val;
	}

	public static uint Jenkins32Hash(IEnumerable<byte> data, uint nInitialValue)
	{
		foreach (byte datum in data)
		{
			nInitialValue += datum;
			nInitialValue += nInitialValue << 10;
			nInitialValue += nInitialValue >> 6;
		}
		nInitialValue += nInitialValue << 3;
		nInitialValue ^= nInitialValue >> 11;
		nInitialValue += nInitialValue << 15;
		return nInitialValue;
	}
}
