using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class ParallelMateSurrogate : MateSurrogate
{
	public ParallelMateSurrogate(Mate obj)
		: base(obj)
	{
	}

	protected override Mate ConvertToObject()
	{
		return new ParallelMate(this);
	}
}
