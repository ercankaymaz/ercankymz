using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class ConcentricMateSurrogate : MateSurrogate
{
	public ConcentricMateSurrogate(Mate obj)
		: base(obj)
	{
	}

	protected override Mate ConvertToObject()
	{
		return new ConcentricMate(this);
	}
}
