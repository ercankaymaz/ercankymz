using System;

namespace CSMath;

public static class MathHelper
{
	public const double DegToGradFactor = 1.1111111111111112;

	public const double DegToRadFactor = Math.PI / 180.0;

	public const double Epsilon = 1E-12;

	public const double GradToDegFactor = 0.9;

	public const double GradToRadFactor = Math.PI / 200.0;

	public const double HalfPI = Math.PI / 2.0;

	public const double PI = Math.PI;

	public const double RadToDegFactor = 180.0 / Math.PI;

	public const double RadToGradFactor = 200.0 / Math.PI;

	public const double ThreeHalfPI = 4.71238898038469;

	public const double TwoPI = Math.PI * 2.0;

	public static double Cos(double value)
	{
		double num = Math.Cos(value);
		if (!IsZero(num))
		{
			return num;
		}
		return 0.0;
	}

	public static double DegToGrad(double value)
	{
		return value * 1.1111111111111112;
	}

	public static double DegToRad(double value)
	{
		return value * (Math.PI / 180.0);
	}

	public static double FixZero(double number)
	{
		return FixZero(number, 1E-12);
	}

	public static double FixZero(double number, double threshold)
	{
		if (!IsZero(number, threshold))
		{
			return number;
		}
		return 0.0;
	}

	public static T FixZero<T>(T vector) where T : IVector, new()
	{
		return FixZero(vector, 1E-12);
	}

	public static T FixZero<T>(T vector, double threshold) where T : IVector, new()
	{
		T result = new T();
		for (int i = 0; i < vector.Dimension; i++)
		{
			result[i] = FixZero(vector[i], threshold);
		}
		return result;
	}

	public static double GradToDeg(double value)
	{
		return value * 0.9;
	}

	public static double GradToRad(double value)
	{
		return value * (Math.PI / 200.0);
	}

	public static bool IsAlmostZero(double value)
	{
		if (value > -1E-12)
		{
			return value < 1E-12;
		}
		return false;
	}

	public static bool IsEqual(double a, double b)
	{
		return IsEqual(a, b, 1E-12);
	}

	public static bool IsEqual(double a, double b, double threshold)
	{
		return IsZero(Math.Abs(a) - Math.Abs(b), threshold);
	}

	public static bool IsZero(double number)
	{
		return IsZero(number, 1E-12);
	}

	public static bool IsZero(double number, double threshold)
	{
		if (number >= 0.0 - threshold)
		{
			return number <= threshold;
		}
		return false;
	}

	public static double NormalizeAngle(double angle)
	{
		double num = angle % 360.0;
		if (IsZero(num) || IsEqual(Math.Abs(num), 360.0))
		{
			return 0.0;
		}
		if (num < 0.0)
		{
			return 360.0 + num;
		}
		return num;
	}

	public static double RadToDeg(double value, bool absolute = true)
	{
		return NormalizeAngle(value * (180.0 / Math.PI));
	}

	public static double RadToGrad(double value)
	{
		return value * (200.0 / Math.PI);
	}

	public static double RoundToNearest(double number, double roundTo)
	{
		return Math.Round(number / roundTo, 0) * roundTo;
	}

	public static double Sin(double value)
	{
		double num = Math.Sin(value);
		if (!IsZero(num))
		{
			return num;
		}
		return 0.0;
	}
}
