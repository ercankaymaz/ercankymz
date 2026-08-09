using devDept.Geometry;

namespace devDept.Serialization;

public class Vector2DSurrogate : Surrogate<Vector2D>
{
	public double X;

	public double Y;

	public Vector2DSurrogate(Vector2D vector2D)
		: base(vector2D)
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

	public static implicit operator Vector2D(Vector2DSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator Vector2DSurrogate(Vector2D source)
	{
		if (!(source == null))
		{
			return source.ConvertToSurrogate();
		}
		return null;
	}
}
