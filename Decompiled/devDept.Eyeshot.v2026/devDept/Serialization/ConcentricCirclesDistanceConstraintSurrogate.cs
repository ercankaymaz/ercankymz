using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class ConcentricCirclesDistanceConstraintSurrogate : ValueConstraintSurrogate
{
	public ConcentricCirclesDistanceConstraintSurrogate(ConcentricCirclesDistanceConstraint coincidentConstraint)
		: base(coincidentConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		ConcentricCirclesDistanceConstraint concentricCirclesDistanceConstraint = new ConcentricCirclesDistanceConstraint(null);
		CopyDataToObject(concentricCirclesDistanceConstraint);
		return concentricCirclesDistanceConstraint;
	}
}
