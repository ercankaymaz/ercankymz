using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal class LinearConstraintDataSurrogate : ConstraintDataSurrogate
{
	public Point3D Start;

	public Point3D End;

	public LinearConstraintDataSurrogate(LinearConstraintData obj)
		: base(obj)
	{
	}

	protected override ConstraintData ConvertToObject()
	{
		LinearConstraintData linearConstraintData = new LinearConstraintData(this);
		CopyDataToObject(linearConstraintData);
		return linearConstraintData;
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		base.CopyDataFromObject(obj);
		LinearConstraintData linearConstraintData = (LinearConstraintData)obj;
		Start = linearConstraintData.Start;
		End = linearConstraintData.End;
	}
}
