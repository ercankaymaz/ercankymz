using devDept.Geometry;

namespace devDept.Serialization;

public class Vector2D_V6Surrogate : Point2D_V6Surrogate
{
	public Vector2D_V6Surrogate(Vector2D vector2D)
		: base(vector2D)
	{
	}

	public static implicit operator Vector2D(Vector2D_V6Surrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator Vector2D_V6Surrogate(Vector2D source)
	{
		if (!(source == null))
		{
			return source.ConvertToSurrogate_V6();
		}
		return null;
	}
}
