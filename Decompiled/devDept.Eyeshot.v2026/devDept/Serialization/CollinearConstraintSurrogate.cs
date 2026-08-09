using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class CollinearConstraintSurrogate : ConstraintSurrogate
{
	public CollinearConstraintSurrogate(CollinearConstraint collinearConstraint)
		: base(collinearConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		CollinearConstraint collinearConstraint = new CollinearConstraint(null);
		CopyDataToObject(collinearConstraint);
		return collinearConstraint;
	}
}
