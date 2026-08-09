using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal class ConicalConstraintDataSurrogate : CylindricalConstraintDataSurrogate
{
	public double HalfAngle;

	public Point3D Tip;

	public ConicalConstraintDataSurrogate(ConicalConstraintData obj)
		: base(obj)
	{
	}

	protected override ConstraintData ConvertToObject()
	{
		ConicalConstraintData conicalConstraintData = new ConicalConstraintData(this);
		CopyDataToObject(conicalConstraintData);
		return conicalConstraintData;
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		base.CopyDataFromObject(obj);
		ConicalConstraintData conicalConstraintData = (ConicalConstraintData)obj;
		HalfAngle = conicalConstraintData.HalfAngle;
		Tip = conicalConstraintData.Tip;
	}
}
