using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class LinesDistanceConstraintSurrogate : ValueConstraintSurrogate
{
	public LinesDistanceConstraintSurrogate(LinesDistanceConstraint linesDistanceConstraint)
		: base(linesDistanceConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		LinesDistanceConstraint linesDistanceConstraint = new LinesDistanceConstraint(null);
		CopyDataToObject(linesDistanceConstraint);
		return linesDistanceConstraint;
	}
}
