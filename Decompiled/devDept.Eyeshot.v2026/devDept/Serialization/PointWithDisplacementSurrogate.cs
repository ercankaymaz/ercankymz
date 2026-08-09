using devDept.Geometry;

namespace devDept.Serialization;

public class PointWithDisplacementSurrogate : Point3DSurrogate
{
	public PointWithDisplacementSurrogate(PointWithDisplacement pwd)
		: base(pwd)
	{
	}

	protected override Point2D ConvertToObject()
	{
		PointWithDisplacement pointWithDisplacement = new PointWithDisplacement(X, Y, Z);
		CopyDataToObject(pointWithDisplacement);
		return pointWithDisplacement;
	}
}
