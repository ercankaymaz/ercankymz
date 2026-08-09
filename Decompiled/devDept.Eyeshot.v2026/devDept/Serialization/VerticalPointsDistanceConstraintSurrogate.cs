using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class VerticalPointsDistanceConstraintSurrogate : PointsDistanceConstraintSurrogate
{
	public VerticalPointsDistanceConstraintSurrogate(VerticalPointsDistanceConstraint verticalPointsDistance)
		: base(verticalPointsDistance)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		VerticalPointsDistanceConstraint verticalPointsDistanceConstraint = new VerticalPointsDistanceConstraint(null);
		CopyDataToObject(verticalPointsDistanceConstraint);
		return verticalPointsDistanceConstraint;
	}
}
