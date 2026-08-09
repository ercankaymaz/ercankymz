using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class PerpendicularMateSurrogate : MateSurrogate
{
	public PerpendicularMateSurrogate(Mate obj)
		: base(obj)
	{
	}

	protected override Mate ConvertToObject()
	{
		return new PerpendicularMate(this);
	}
}
