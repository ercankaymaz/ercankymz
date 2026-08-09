using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class CoincidentMateSurrogate : MateSurrogate
{
	public CoincidentMateSurrogate(Mate obj)
		: base(obj)
	{
	}

	protected override Mate ConvertToObject()
	{
		return new CoincidentMate(this);
	}
}
