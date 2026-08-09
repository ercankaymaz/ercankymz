using devDept.Geometry;

namespace devDept.Serialization;

public class Point2DSurrogate : Surrogate<Point2D>
{
	public double X;

	public double Y;

	public Point2DSurrogate(Point2D point2D)
		: base(point2D)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new Point2D(X, Y);
	}

	protected override void CopyDataToObject(Point2D obj)
	{
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		X = p.X;
		Y = p.Y;
	}

	public static implicit operator Point2D(Point2DSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator Point2DSurrogate(Point2D source)
	{
		if (!(source == null))
		{
			return source.ConvertToSurrogate();
		}
		return null;
	}
}
