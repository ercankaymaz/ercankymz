using System;
using System.ComponentModel;
using devDept.Geometry.Converters;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(Point3DConverter))]
public class Size3D : Point3D
{
	public double Diagonal => Math.Sqrt(X * X + Y * Y + Z * Z);

	public double Min => Utility.Min(X, Y, Z);

	public double Max => Utility.Max(X, Y, Z);

	public Size3D(double width, double depth, double height)
		: base(width, depth, height)
	{
	}

	public Size3D(Point3D minCorner, Point3D maxCorner)
		: base(maxCorner.X - minCorner.X, maxCorner.Y - minCorner.Y, maxCorner.Z - minCorner.Z)
	{
	}
}
