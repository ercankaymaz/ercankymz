using System;

namespace MS.Internal;

internal sealed class FloatingPointArithmetic
{
	private static double doubleTolerance = 1E-20;

	private static double singleTolerance = 1E-10;

	private static double distanceTolerance = 1E-10;

	private static double squaredDistanceTolerance = distanceTolerance * distanceTolerance;

	public static double DoubleTolerance => doubleTolerance;

	public static double SingleTolerance => singleTolerance;

	public static double DistanceTolerance => distanceTolerance;

	public static double SquaredDistanceTolerance => squaredDistanceTolerance;

	public static bool IsVerySmall(double k)
	{
		return Math.Abs(k) < DoubleTolerance;
	}

	public static bool IsVerySmall(float k)
	{
		return (double)Math.Abs(k) < SingleTolerance;
	}

	public static bool IsInClosedInterval(double x, double a, double b)
	{
		if (x >= a)
		{
			return x <= b;
		}
		return false;
	}

	public static float ToSingle(double d)
	{
		return (float)d;
	}

	public static double Hypotenuse(double x, double y)
	{
		return Math.Sqrt(x * x + y * y);
	}

	public static double DoubleFromMantissaAndExponent(double x, int exp)
	{
		return x * Math.Pow(2.0, exp);
	}

	public static bool IsFiniteDouble(double x)
	{
		if (!double.IsInfinity(x))
		{
			return !double.IsNaN(x);
		}
		return false;
	}

	private FloatingPointArithmetic()
	{
	}
}
