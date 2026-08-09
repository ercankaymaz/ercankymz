using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class MidPointConstraintSurrogate : PointAtConstraintSurrogate
{
	public MidPointConstraintSurrogate(MidPointConstraint midPointConstraint)
		: base(midPointConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		MidPointConstraint midPointConstraint = new MidPointConstraint(null);
		CopyDataToObject(midPointConstraint);
		return midPointConstraint;
	}
}
