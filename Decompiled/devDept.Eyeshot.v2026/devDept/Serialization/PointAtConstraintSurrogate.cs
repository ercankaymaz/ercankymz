using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class PointAtConstraintSurrogate : PointOnConstraintSurrogate
{
	public PointAtConstraintSurrogate(PointAtConstraint pointConstraintAtConstraint)
		: base(pointConstraintAtConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		PointAtConstraint pointAtConstraint = new PointAtConstraint(null);
		CopyDataToObject(pointAtConstraint);
		return pointAtConstraint;
	}
}
