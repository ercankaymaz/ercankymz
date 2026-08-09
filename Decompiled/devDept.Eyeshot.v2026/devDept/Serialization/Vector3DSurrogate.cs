using devDept.Geometry;

namespace devDept.Serialization;

public class Vector3DSurrogate : Vector2DSurrogate
{
	public double Z;

	public Vector3DSurrogate(Vector3D vector3D)
		: base(vector3D)
	{
	}

	protected override Vector2D ConvertToObject()
	{
		return new Vector3D(X, Y, Z);
	}

	protected override void CopyDataFromObject(Vector2D vector)
	{
		Vector3D vector3D = (Vector3D)vector;
		Z = vector3D.Z;
		base.CopyDataFromObject(vector);
	}
}
