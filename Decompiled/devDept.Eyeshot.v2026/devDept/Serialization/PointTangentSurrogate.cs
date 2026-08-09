using devDept.Geometry;

namespace devDept.Serialization;

public class PointTangentSurrogate : Point3DSurrogate
{
	public double Tx;

	public double Ty;

	public double Tz;

	public PointTangentSurrogate(PointTangent pt)
		: base(pt)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new PointTangent(X, Y, Z, Tx, Ty, Tz);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		PointTangent pointTangent = p as PointTangent;
		Tx = pointTangent.Tx;
		Ty = pointTangent.Ty;
		Tz = pointTangent.Tz;
		base.CopyDataFromObject(p);
	}
}
