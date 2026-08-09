using System;

namespace CSMath.Geometry;

public static class LineExtensions
{
	public static T CreateFromPoints<T, R>(R pt1, R pt2) where T : ILine<R> where R : IVector, new()
	{
		return (T)Activator.CreateInstance(typeof(T), pt1, pt2.Subtract(pt1));
	}

	public static bool IsPointOnLine<T>(this ILine<T> line, T point) where T : IVector
	{
		double num = 0.0;
		for (int i = 0; i < point.Dimension; i++)
		{
			double num2 = (point[i] - line.Origin[i]) / line.Direction[i];
			if (i != 0 && num2 != num)
			{
				return false;
			}
			num = num2;
		}
		return true;
	}

	public static bool TryFindIntersection<T, R>(this T line1, T line2, out R intersection) where T : ILine<R> where R : IVector
	{
		intersection = line1.FindIntersection(line2);
		return !intersection.IsNaN();
	}
}
