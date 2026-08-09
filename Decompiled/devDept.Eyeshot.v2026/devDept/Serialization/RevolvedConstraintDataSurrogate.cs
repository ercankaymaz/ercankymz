using devDept.Eyeshot.Entities;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal class RevolvedConstraintDataSurrogate : PlanarConstraintDataSurrogate
{
	public Curve Generatrix;

	public RevolvedConstraintDataSurrogate(RevolvedConstraintData obj)
		: base(obj)
	{
	}

	protected override ConstraintData ConvertToObject()
	{
		RevolvedConstraintData revolvedConstraintData = new RevolvedConstraintData(this);
		CopyDataToObject(revolvedConstraintData);
		return revolvedConstraintData;
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		base.CopyDataFromObject(obj);
		RevolvedConstraintData revolvedConstraintData = (RevolvedConstraintData)obj;
		Generatrix = revolvedConstraintData.Generatrix;
	}
}
