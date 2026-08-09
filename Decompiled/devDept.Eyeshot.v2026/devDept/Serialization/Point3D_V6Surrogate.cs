using devDept.Geometry;

namespace devDept.Serialization;

public class Point3D_V6Surrogate : Point2D_V6Surrogate
{
	public double Z;

	public Point3D_V6Surrogate(Vector3D point3D)
		: base(point3D)
	{
	}

	protected override Vector2D ConvertToObject()
	{
		return new Vector3D(X, Y, Z);
	}

	protected override void CopyDataFromObject(Vector2D p)
	{
		Vector3D vector3D = p as Vector3D;
		Z = vector3D.Z;
		base.CopyDataFromObject(p);
	}
}
