using System;
using System.ComponentModel;
using devDept.Geometry.Converters;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(Point2DConverter))]
public class Size2D : Point2D
{
	public double Diagonal => Math.Sqrt(X * X + Y * Y);

	public double Min => Math.Min(X, Y);

	public double Max => Math.Max(X, Y);

	public Size2D(double width, double height)
		: base(width, height)
	{
	}

	public Size2D(Point2D minCorner, Point2D maxCorner)
		: base(maxCorner.X - minCorner.X, maxCorner.Y - minCorner.Y)
	{
	}
}
