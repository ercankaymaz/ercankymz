using System;
using System.Collections.Generic;

namespace CSMath.Geometry;

public static class CurveExtensions
{
	public static XYZ PolarCoordinate(double angle, XYZ center, XYZ normal, XYZ startPoint, double ratio = 1.0)
	{
		XYZ xYZ = XYZ.Cross(normal, startPoint);
		return Math.Cos(angle) * startPoint + ratio * Math.Sin(angle) * xYZ + center;
	}

	public static List<XYZ> PolygonalVertexes(int precision, XYZ center, double startAngle, double endAngle, double radius, XYZ normal)
	{
		if (precision < 2)
		{
			throw new ArgumentOutOfRangeException("precision", precision, "The precision must be equal or greater than two.");
		}
		List<XYZ> list = new List<XYZ>();
		double num = startAngle;
		double num2 = endAngle;
		if (num2 <= startAngle)
		{
			num2 += Math.PI * 2.0;
		}
		Matrix4 arbitraryAxis = Matrix4.GetArbitraryAxis(normal);
		int num3 = (MathHelper.IsEqual(num - num2, Math.PI * 2.0) ? precision : (precision - 1));
		double num4 = (num2 - num) / (double)num3;
		int num5 = 0;
		while (num5 < precision)
		{
			XYZ xYZ = new XYZ(MathHelper.Cos(num), MathHelper.Sin(num), 0.0);
			xYZ = center + radius * xYZ;
			list.Add(arbitraryAxis * xYZ);
			num5++;
			num += num4;
		}
		return list;
	}

	public static List<XYZ> PolygonalVertexes(double length, XYZ center, double startAngle, double endAngle, double radius, XYZ normal)
	{
		int num = (int)Math.Ceiling(Math.PI * 2.0 * radius / length);
		if (num < 2)
		{
			num = 3;
		}
		return PolygonalVertexes(num, center, startAngle, endAngle, radius, normal);
	}

	public static List<XYZ> PolygonalVertexes(int precision, XYZ center, double startAngle, double endAngle, XYZ normal, XYZ majorAxisPoint, double ratio = 1.0)
	{
		if (precision < 2)
		{
			throw new ArgumentOutOfRangeException("precision", precision, "The precision must be equal or greater than two.");
		}
		List<XYZ> list = new List<XYZ>();
		double num = startAngle;
		double num2 = endAngle;
		if (num2 <= num)
		{
			num2 += Math.PI * 2.0;
		}
		XYZ xYZ = majorAxisPoint - center;
		XYZ xYZ2 = XYZ.Cross(normal, xYZ);
		int num3 = (MathHelper.IsEqual(num - num2, Math.PI * 2.0) ? precision : (precision - 1));
		double num4 = (num2 - num) / (double)num3;
		int num5 = 0;
		while (num5 < precision)
		{
			list.Add(MathHelper.Cos(num) * xYZ + ratio * MathHelper.Sin(num) * xYZ2 + center);
			num5++;
			num += num4;
		}
		return list;
	}
}
