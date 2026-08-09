using devDept.Geometry;

namespace devDept.Serialization;

public class PointTangentUSurrogate : PointTangentSurrogate
{
	public double U;

	public PointTangentUSurrogate(PointTangentU ptU)
		: base(ptU)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new PointTangentU(X, Y, Z, Tx, Ty, Tz, U);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		PointTangentU pointTangentU = p as PointTangentU;
		U = pointTangentU.U;
		base.CopyDataFromObject(p);
	}
}
