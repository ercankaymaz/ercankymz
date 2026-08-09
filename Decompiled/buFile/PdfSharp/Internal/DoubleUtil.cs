using System;
using System.Runtime.InteropServices;
using PdfSharp.Drawing;

namespace PdfSharp.Internal;

internal static class DoubleUtil
{
	[StructLayout(LayoutKind.Explicit)]
	private struct NanUnion
	{
		[FieldOffset(0)]
		internal double DoubleValue;

		[FieldOffset(0)]
		internal readonly ulong UintValue;
	}

	private const double Epsilon = 2.220446049250313E-16;

	private const double TenTimesEpsilon = 2.220446049250313E-15;

	private const float FloatMinimum = 1.175494E-38f;

	private static readonly double[] decs = new double[17]
	{
		1.0, 0.1, 0.01, 0.001, 0.0001, 1E-05, 1E-06, 1E-07, 1E-08, 1E-09,
		1E-10, 1E-11, 1E-12, 1E-13, 1E-14, 1E-15, 1E-16
	};

	public static bool AreClose(double value1, double value2)
	{
		if (value1.Equals(value2))
		{
			return true;
		}
		double num = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * 2.220446049250313E-16;
		double num2 = value1 - value2;
		return 0.0 - num < num2 && num > num2;
	}

	public static bool AreRoughlyEqual(double value1, double value2, int decimalPlace)
	{
		if (value1 == value2)
		{
			return true;
		}
		return Math.Abs(value1 - value2) < decs[decimalPlace];
	}

	public static bool AreClose(XPoint point1, XPoint point2)
	{
		return AreClose(point1.X, point2.X) && AreClose(point1.Y, point2.Y);
	}

	public static bool AreClose(XRect rect1, XRect rect2)
	{
		if (rect1.IsEmpty)
		{
			return rect2.IsEmpty;
		}
		return !rect2.IsEmpty && AreClose(rect1.X, rect2.X) && AreClose(rect1.Y, rect2.Y) && AreClose(rect1.Height, rect2.Height) && AreClose(rect1.Width, rect2.Width);
	}

	public static bool AreClose(XSize size1, XSize size2)
	{
		return AreClose(size1.Width, size2.Width) && AreClose(size1.Height, size2.Height);
	}

	public static bool AreClose(XVector vector1, XVector vector2)
	{
		return AreClose(vector1.X, vector2.X) && AreClose(vector1.Y, vector2.Y);
	}

	public static bool GreaterThan(double value1, double value2)
	{
		return value1 > value2 && !AreClose(value1, value2);
	}

	public static bool GreaterThanOrClose(double value1, double value2)
	{
		return value1 > value2 || AreClose(value1, value2);
	}

	public static bool LessThan(double value1, double value2)
	{
		return value1 < value2 && !AreClose(value1, value2);
	}

	public static bool LessThanOrClose(double value1, double value2)
	{
		return value1 < value2 || AreClose(value1, value2);
	}

	public static bool IsBetweenZeroAndOne(double value)
	{
		return GreaterThanOrClose(value, 0.0) && LessThanOrClose(value, 1.0);
	}

	public static bool IsNaN(double value)
	{
		NanUnion nanUnion = new NanUnion
		{
			DoubleValue = value
		};
		ulong num = nanUnion.UintValue & 0xFFF0000000000000uL;
		ulong num2 = nanUnion.UintValue & 0xFFFFFFFFFFFFFL;
		return (num == 9218868437227405312L || num == 18442240474082181120uL) && num2 != 0;
	}

	public static bool RectHasNaN(XRect r)
	{
		return IsNaN(r.X) || IsNaN(r.Y) || IsNaN(r.Height) || IsNaN(r.Width);
	}

	public static bool IsOne(double value)
	{
		return Math.Abs(value - 1.0) < 2.220446049250313E-15;
	}

	public static bool IsZero(double value)
	{
		return Math.Abs(value) < 2.220446049250313E-15;
	}

	public static int DoubleToInt(double value)
	{
		return (0.0 < value) ? ((int)(value + 0.5)) : ((int)(value - 0.5));
	}
}
