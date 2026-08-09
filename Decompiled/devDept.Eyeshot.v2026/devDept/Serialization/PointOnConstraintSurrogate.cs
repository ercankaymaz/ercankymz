using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class PointOnConstraintSurrogate : ValueConstraintSurrogate
{
	public PointOnConstraintSurrogate(PointOnConstraint pointConstraintOnConstraint)
		: base(pointConstraintOnConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		PointOnConstraint pointOnConstraint = new PointOnConstraint(null);
		CopyDataToObject(pointOnConstraint);
		return pointOnConstraint;
	}
}
