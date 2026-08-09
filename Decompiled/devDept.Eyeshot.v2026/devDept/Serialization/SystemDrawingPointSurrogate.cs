using System.Drawing;

namespace devDept.Serialization;

internal class SystemDrawingPointSurrogate : Surrogate<Point>
{
	public int X;

	public int Y;

	public SystemDrawingPointSurrogate(Point point)
		: base(point)
	{
	}

	protected override Point ConvertToObject()
	{
		return new Point(X, Y);
	}

	protected override void CopyDataToObject(Point obj)
	{
	}

	protected override void CopyDataFromObject(Point p)
	{
		X = p.X;
		Y = p.Y;
	}

	public static implicit operator Point(SystemDrawingPointSurrogate surrogate)
	{
		if (surrogate != null)
		{
			return new Point(surrogate.X, surrogate.Y);
		}
		return Point.Empty;
	}

	public static implicit operator SystemDrawingPointSurrogate(Point source)
	{
		return new SystemDrawingPointSurrogate(source);
	}
}
