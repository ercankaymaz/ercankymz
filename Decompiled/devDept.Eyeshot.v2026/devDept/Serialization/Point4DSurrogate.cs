using devDept.Geometry;

namespace devDept.Serialization;

public class Point4DSurrogate : Point3DSurrogate
{
	public double W;

	public Point4DSurrogate(Point4D point4D)
		: base(point4D)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new Point4D(X, Y, Z, W);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		Point4D point4D = p as Point4D;
		W = point4D.W;
		base.CopyDataFromObject(p);
	}
}
