using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class HorizontalPointsDistanceConstraintSurrogate : PointsDistanceConstraintSurrogate
{
	public HorizontalPointsDistanceConstraintSurrogate(HorizontalPointsDistanceConstraint horizontalPointsDistance)
		: base(horizontalPointsDistance)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		HorizontalPointsDistanceConstraint horizontalPointsDistanceConstraint = new HorizontalPointsDistanceConstraint(null);
		CopyDataToObject(horizontalPointsDistanceConstraint);
		return horizontalPointsDistanceConstraint;
	}
}
