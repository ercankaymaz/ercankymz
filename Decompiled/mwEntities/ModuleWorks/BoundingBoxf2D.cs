using System;

namespace ModuleWorks;

[Serializable]
public class BoundingBoxf2D
{
	public Point2d<float> LowerLeft { get; set; }

	public Point2d<float> UpperRight { get; set; }

	public float DeltaX => UpperRight.X - LowerLeft.X;

	public float DeltaY => UpperRight.Y - LowerLeft.Y;

	public float Diagonal => (float)Math.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY);

	public BoundingBoxf2D()
	{
		LowerLeft = new Point2d<float>();
		UpperRight = new Point2d<float>();
	}

	public BoundingBoxf2D(Point2d<float> lowerLeft, Point2d<float> upperRight)
	{
		LowerLeft = new Point2d<float>(lowerLeft);
		UpperRight = new Point2d<float>(upperRight);
	}

	public bool Contains(Point2d<float> point)
	{
		float num = Math.Max(LowerLeft.X, point.X);
		float num2 = Math.Max(LowerLeft.Y, point.Y);
		float num3 = Math.Min(UpperRight.X, point.X);
		float num4 = Math.Min(UpperRight.Y, point.Y);
		if (point.X == num && point.Y == num2 && point.X == num3)
		{
			return point.Y == num4;
		}
		return false;
	}

	public void Uninitialize()
	{
		LowerLeft.X = 3E+38f;
		LowerLeft.Y = 3E+38f;
		UpperRight.X = -3E+38f;
		UpperRight.Y = -3E+38f;
	}
}
