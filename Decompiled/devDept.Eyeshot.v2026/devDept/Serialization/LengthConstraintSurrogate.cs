using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class LengthConstraintSurrogate : ValueConstraintSurrogate
{
	public LengthConstraintSurrogate(LengthConstraint lengthConstraint)
		: base(lengthConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		LengthConstraint lengthConstraint = new LengthConstraint(null);
		CopyDataToObject(lengthConstraint);
		return lengthConstraint;
	}
}
