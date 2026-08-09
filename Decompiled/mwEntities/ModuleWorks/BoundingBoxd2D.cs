using System;

namespace ModuleWorks;

[Serializable]
public class BoundingBoxd2D
{
	public Point2d<double> LowerLeft { get; set; }

	public Point2d<double> UpperRight { get; set; }

	public double DeltaX => UpperRight.X - LowerLeft.X;

	public double DeltaY => UpperRight.Y - LowerLeft.Y;

	public double Diagonal => Math.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY);

	public BoundingBoxd2D()
	{
		LowerLeft = new Point2d<double>();
		UpperRight = new Point2d<double>();
	}

	public BoundingBoxd2D(Point2d<double> lowerLeft, Point2d<double> upperRight)
	{
		LowerLeft = new Point2d<double>(lowerLeft);
		UpperRight = new Point2d<double>(upperRight);
	}

	public void Union(Point2d<double> point)
	{
		for (int i = 0; i < 2; i++)
		{
			if (point[i] < LowerLeft[i])
			{
				LowerLeft[i] = point[i];
			}
			if (point[i] > UpperRight[i])
			{
				UpperRight[i] = point[i];
			}
		}
	}

	public bool Contains(Point2d<double> point)
	{
		double num = Math.Max(LowerLeft.X, point.X);
		double num2 = Math.Max(LowerLeft.Y, point.Y);
		double num3 = Math.Min(UpperRight.X, point.X);
		double num4 = Math.Min(UpperRight.Y, point.Y);
		if (point.X == num && point.Y == num2 && point.X == num3)
		{
			return point.Y == num4;
		}
		return false;
	}

	public void Uninitialize()
	{
		LowerLeft.X = 1E+308;
		LowerLeft.Y = 1E+308;
		UpperRight.X = -1E+308;
		UpperRight.Y = -1E+308;
	}
}
