using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class TangentMateSurrogate : MateSurrogate
{
	public TangentMateSurrogate(Mate obj)
		: base(obj)
	{
	}

	protected override Mate ConvertToObject()
	{
		return new TangentMate(this);
	}
}
