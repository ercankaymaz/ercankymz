using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal static class PointHelper
{
	public static Point Empty => new Point(double.NaN, double.NaN);

	public static double DistanceBetween(Point p1, Point p2)
	{
		return Math.Sqrt(Math.Pow(((Point)(ref p1)).X - ((Point)(ref p2)).X, 2.0) + Math.Pow(((Point)(ref p1)).Y - ((Point)(ref p2)).Y, 2.0));
	}

	public static bool IsEmpty(Point point)
	{
		if (DoubleHelper.IsNaN(((Point)(ref point)).X))
		{
			return DoubleHelper.IsNaN(((Point)(ref point)).Y);
		}
		return false;
	}
}
