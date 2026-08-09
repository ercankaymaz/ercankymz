using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class PointLineDistanceConstraintSurrogate : ValueConstraintSurrogate
{
	public PointLineDistanceConstraintSurrogate(PointLineDistanceConstraint pointLineDistanceConstraint)
		: base(pointLineDistanceConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		PointLineDistanceConstraint pointLineDistanceConstraint = new PointLineDistanceConstraint(null);
		CopyDataToObject(pointLineDistanceConstraint);
		return pointLineDistanceConstraint;
	}
}
