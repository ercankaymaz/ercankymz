using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

internal class PointConstraintDataSurrogate : ConstraintDataSurrogate
{
	public Point3D Position;

	public PointConstraintDataSurrogate(PointConstraintData obj)
		: base(obj)
	{
	}

	protected override ConstraintData ConvertToObject()
	{
		PointConstraintData pointConstraintData = new PointConstraintData(this);
		CopyDataToObject(pointConstraintData);
		return pointConstraintData;
	}

	protected override void CopyDataFromObject(ConstraintData obj)
	{
		base.CopyDataFromObject(obj);
		PointConstraintData pointConstraintData = (PointConstraintData)obj;
		Position = pointConstraintData.Position;
	}
}
