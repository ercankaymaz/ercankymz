using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal class ToroidalConstraintDataSurrogate : CylindricalConstraintDataSurrogate
{
	public double MinorRadius;

	public ToroidalConstraintDataSurrogate(ToroidalConstraintData obj)
		: base(obj)
	{
	}

	protected override ConstraintData ConvertToObject()
	{
		ToroidalConstraintData toroidalConstraintData = new ToroidalConstraintData(this);
		CopyDataToObject(toroidalConstraintData);
		return toroidalConstraintData;
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		base.CopyDataFromObject(obj);
		ToroidalConstraintData toroidalConstraintData = (ToroidalConstraintData)obj;
		MinorRadius = toroidalConstraintData.MinorRadius;
	}
}
