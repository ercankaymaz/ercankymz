using devDept.Geometry;

namespace devDept.Serialization;

public class Point2D_V6Surrogate : Surrogate<Vector2D>
{
	public double X;

	public double Y;

	public Point2D_V6Surrogate(Vector2D point2D)
		: base(point2D)
	{
	}

	protected override Vector2D ConvertToObject()
	{
		return new Vector2D(X, Y);
	}

	protected override void CopyDataToObject(Vector2D obj)
	{
	}

	protected override void CopyDataFromObject(Vector2D p)
	{
		X = p.X;
		Y = p.Y;
	}

	public static implicit operator Vector2D(Point2D_V6Surrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator Point2D_V6Surrogate(Vector2D source)
	{
		if (!(source == null))
		{
			return source.ConvertToSurrogate_V6();
		}
		return null;
	}
}
