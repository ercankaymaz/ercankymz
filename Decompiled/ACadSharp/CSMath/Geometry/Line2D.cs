using System;

namespace CSMath.Geometry;

public struct Line2D : ILine<XY>, IEquatable<Line2D>
{
	public XY Direction { get; set; }

	public double Offset => Origin.Y - Slope * Origin.X;

	public XY Origin { get; set; }

	public double Slope => (Direction.Y - Direction.Y) / (Direction.X - Direction.X);

	public Line2D(XY origin, XY direction)
	{
		Origin = origin;
		Direction = direction;
	}

	public bool Equals(Line2D other)
	{
		if (this.IsPointOnLine(other.Origin))
		{
			return other.Direction == Direction;
		}
		return false;
	}

	public XY FindIntersection(ILine<XY> line)
	{
		if (Direction.IsParallel(line.Direction))
		{
			return XY.NaN;
		}
		XY xY = line.Origin - Origin;
		double num = XY.Cross(Direction, line.Direction);
		double num2 = (xY.X * line.Direction.Y - xY.Y * line.Direction.X) / num;
		return Origin + num2 * Direction;
	}
}
