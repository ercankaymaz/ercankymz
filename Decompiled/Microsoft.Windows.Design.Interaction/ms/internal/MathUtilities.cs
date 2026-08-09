using System;
using System.Windows;
using System.Windows.Media;

namespace MS.Internal;

internal static class MathUtilities
{
	private static double DBL_EPSILON = 2.220446049250313E-16;

	internal static bool AreClose(Size s1, Size s2)
	{
		if (AreClose(((Size)(ref s1)).Width, ((Size)(ref s2)).Width))
		{
			return AreClose(((Size)(ref s1)).Height, ((Size)(ref s2)).Height);
		}
		return false;
	}

	internal static bool AreClose(Vector s1, Vector s2)
	{
		if (AreClose(((Vector)(ref s1)).X, ((Vector)(ref s2)).X))
		{
			return AreClose(((Vector)(ref s1)).Y, ((Vector)(ref s2)).Y);
		}
		return false;
	}

	internal static bool AreClose(double value1, double value2)
	{
		if (value1 == value2)
		{
			return true;
		}
		double num = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * DBL_EPSILON;
		double num2 = value1 - value2;
		if (0.0 - num < num2)
		{
			return num > num2;
		}
		return false;
	}

	internal static bool AreClose(Point value1, Point value2)
	{
		if (AreClose(((Point)(ref value1)).X, ((Point)(ref value2)).X))
		{
			return AreClose(((Point)(ref value1)).Y, ((Point)(ref value2)).Y);
		}
		return false;
	}

	internal static bool AreClose(Rect value1, Rect value2)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (AreClose(((Rect)(ref value1)).TopLeft, ((Rect)(ref value2)).TopLeft))
		{
			return AreClose(((Rect)(ref value1)).Size, ((Rect)(ref value2)).Size);
		}
		return false;
	}

	internal static bool AreClose(Matrix m1, Matrix m2)
	{
		if (!AreClose(((Matrix)(ref m1)).OffsetX, ((Matrix)(ref m2)).OffsetX))
		{
			return false;
		}
		if (!AreClose(((Matrix)(ref m1)).OffsetY, ((Matrix)(ref m2)).OffsetY))
		{
			return false;
		}
		if (!AreClose(((Matrix)(ref m1)).M11, ((Matrix)(ref m2)).M11))
		{
			return false;
		}
		if (!AreClose(((Matrix)(ref m1)).M12, ((Matrix)(ref m2)).M12))
		{
			return false;
		}
		if (!AreClose(((Matrix)(ref m1)).M21, ((Matrix)(ref m2)).M21))
		{
			return false;
		}
		if (!AreClose(((Matrix)(ref m1)).M22, ((Matrix)(ref m2)).M22))
		{
			return false;
		}
		return true;
	}

	internal static double Round(double value, double rounding)
	{
		return Math.Round(rounding * Math.Round(value / rounding, MidpointRounding.AwayFromZero), DesignerUtilities.DesignerRoundingPrecision, MidpointRounding.AwayFromZero);
	}

	internal static double Round(double value)
	{
		return Math.Round(value, DesignerUtilities.DesignerRoundingPrecision, MidpointRounding.AwayFromZero);
	}
}
