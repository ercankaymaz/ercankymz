using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class MirrorConstraintSurrogate : ConstraintSurrogate
{
	public MirrorConstraintSurrogate(MirrorConstraint mirrorConstraint)
		: base(mirrorConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		MirrorConstraint mirrorConstraint = new MirrorConstraint(null);
		CopyDataToObject(mirrorConstraint);
		return mirrorConstraint;
	}
}
