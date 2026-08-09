using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal class SphericalConstraintDataSurrogate : ConstraintDataSurrogate
{
	public Point3D Center;

	public double Radius;

	public SphericalConstraintDataSurrogate(SphericalConstraintData obj)
		: base(obj)
	{
	}

	protected override ConstraintData ConvertToObject()
	{
		SphericalConstraintData sphericalConstraintData = new SphericalConstraintData(this);
		CopyDataToObject(sphericalConstraintData);
		return sphericalConstraintData;
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		base.CopyDataFromObject(obj);
		SphericalConstraintData sphericalConstraintData = (SphericalConstraintData)obj;
		Center = sphericalConstraintData.Center;
		Radius = sphericalConstraintData.Radius;
	}
}
