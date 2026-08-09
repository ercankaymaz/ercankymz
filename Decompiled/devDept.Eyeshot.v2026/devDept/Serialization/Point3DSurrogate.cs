using devDept.Geometry;

namespace devDept.Serialization;

public class Point3DSurrogate : Point2DSurrogate
{
	public double Z;

	public Point3DSurrogate(Point3D point3D)
		: base(point3D)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new Point3D(X, Y, Z);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		Point3D point3D = (Point3D)p;
		Z = point3D.Z;
		base.CopyDataFromObject(p);
	}
}
