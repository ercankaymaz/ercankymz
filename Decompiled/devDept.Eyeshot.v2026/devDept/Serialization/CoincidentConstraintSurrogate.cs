using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class CoincidentConstraintSurrogate : ConstraintSurrogate
{
	public CoincidentConstraintSurrogate(CoincidentConstraint coincidentConstraint)
		: base(coincidentConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		CoincidentConstraint coincidentConstraint = new CoincidentConstraint(null);
		CopyDataToObject(coincidentConstraint);
		return coincidentConstraint;
	}
}
