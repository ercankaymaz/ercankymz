using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class PointsDistanceConstraintSurrogate : ValueConstraintSurrogate
{
	public PointsDistanceConstraintSurrogate(PointsDistanceConstraint pointsDistanceConstraint)
		: base(pointsDistanceConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		PointsDistanceConstraint pointsDistanceConstraint = new PointsDistanceConstraint(null);
		CopyDataToObject(pointsDistanceConstraint);
		return pointsDistanceConstraint;
	}
}
