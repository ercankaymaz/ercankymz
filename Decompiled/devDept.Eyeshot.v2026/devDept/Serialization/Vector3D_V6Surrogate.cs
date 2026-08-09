using devDept.Geometry;

namespace devDept.Serialization;

public class Vector3D_V6Surrogate : Point3D_V6Surrogate
{
	public Vector3D_V6Surrogate(Vector3D vector3D)
		: base(vector3D)
	{
	}

	protected override Vector2D ConvertToObject()
	{
		return new Vector3D(X, Y, Z);
	}

	public static implicit operator Vector3D(Vector3D_V6Surrogate surrogate)
	{
		if (surrogate != null)
		{
			return (Vector3D)surrogate.ConvertToObject();
		}
		return null;
	}

	public static implicit operator Vector3D_V6Surrogate(Vector3D source)
	{
		if (!(source == null))
		{
			return source.ConvertToSurrogate_V6();
		}
		return null;
	}
}
