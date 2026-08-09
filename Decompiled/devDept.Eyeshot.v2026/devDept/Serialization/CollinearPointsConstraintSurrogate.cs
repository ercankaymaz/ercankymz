using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class CollinearPointsConstraintSurrogate : HVConstraintSurrogate
{
	public CollinearPointsConstraintSurrogate(CollinearPointsConstraint collinearPointsConstraint)
		: base(collinearPointsConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		CollinearPointsConstraint collinearPointsConstraint = new CollinearPointsConstraint(null);
		CopyDataToObject(collinearPointsConstraint);
		return collinearPointsConstraint;
	}
}
