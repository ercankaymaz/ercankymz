using devDept.Geometry;

namespace devDept.Serialization;

public class PointUSurrogate : Point3DSurrogate
{
	public double U;

	public PointUSurrogate(PointU pointU)
		: base(pointU)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new PointU(X, Y, Z, U);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		PointU pointU = p as PointU;
		U = pointU.U;
		base.CopyDataFromObject(p);
	}
}
