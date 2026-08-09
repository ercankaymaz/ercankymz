using System;

namespace ModuleWorks;

[Serializable]
public class BoundingBoxi2D
{
	public Point2d<int> LowerLeft { get; set; }

	public Point2d<int> UpperRight { get; set; }

	public int DeltaX => UpperRight.X - LowerLeft.X;

	public int DeltaY => UpperRight.Y - LowerLeft.Y;

	public BoundingBoxi2D()
	{
		LowerLeft = new Point2d<int>();
		UpperRight = new Point2d<int>();
	}

	public BoundingBoxi2D(Point2d<int> lowerLeft, Point2d<int> upperRight)
	{
		LowerLeft = new Point2d<int>(lowerLeft);
		UpperRight = new Point2d<int>(upperRight);
	}

	public bool Contains(Point2d<int> point)
	{
		int num = Math.Max(LowerLeft.X, point.X);
		int num2 = Math.Max(LowerLeft.Y, point.Y);
		int num3 = Math.Min(UpperRight.X, point.X);
		int num4 = Math.Min(UpperRight.Y, point.Y);
		if (point.X == num && point.Y == num2 && point.X == num3)
		{
			return point.Y == num4;
		}
		return false;
	}

	public void Uninitialize()
	{
		LowerLeft.X = int.MaxValue;
		LowerLeft.Y = int.MaxValue;
		UpperRight.X = -2147483647;
		UpperRight.Y = -2147483647;
	}
}
