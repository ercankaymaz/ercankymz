using devDept.Geometry;

namespace devDept.Serialization;

public class PointUvSurrogate : PointUSurrogate
{
	public double V;

	public PointUvSurrogate(PointUv pointUv)
		: base(pointUv)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new PointUv(X, Y, Z, U, V);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		PointUv pointUv = p as PointUv;
		V = pointUv.V;
		base.CopyDataFromObject(p);
	}
}
