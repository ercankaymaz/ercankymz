using System;

namespace CSMath.Geometry;

public struct Line3D : ILine<XYZ>, IEquatable<Line3D>
{
	public XYZ Origin { get; set; }

	public XYZ Direction { get; set; }

	public Line3D(XYZ origin, XYZ direction)
	{
		Origin = origin;
		if (direction.Equals(XYZ.Zero))
		{
			throw new ArgumentException("The direction vector of the line cannot be a zero vector.");
		}
		Direction = direction.Normalize();
	}

	public XYZ FindIntersection(ILine<XYZ> line)
	{
		XYZ origin = Origin;
		XYZ direction = Direction;
		XYZ origin2 = line.Origin;
		XYZ direction2 = line.Direction;
		XYZ right = origin - origin2;
		double num = direction.Dot(direction);
		double num2 = direction.Dot(direction2);
		double num3 = direction2.Dot(direction2);
		double num4 = direction.Dot(right);
		double num5 = direction2.Dot(right);
		double num6 = (num2 * num5 - num3 * num4) / (num * num3 - num2 * num2);
		double num7 = (num * num5 - num2 * num4) / (num * num3 - num2 * num2);
		XYZ result = origin + num6 * direction;
		XYZ other = origin2 + num7 * direction2;
		if (result.Equals(other))
		{
			return result;
		}
		return XYZ.NaN;
	}

	public bool Equals(Line3D other)
	{
		if (this.IsPointOnLine(other.Origin))
		{
			return other.Direction == Direction;
		}
		return false;
	}
}
