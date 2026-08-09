using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class MateSurrogate : Surrogate<Mate>
{
	internal ConstraintData constraintData1;

	internal ConstraintData constraintData2;

	public bool Flipped;

	public MateSurrogate(Mate obj)
		: base(obj)
	{
	}

	protected override Mate ConvertToObject()
	{
		return null;
	}

	protected override void CopyDataToObject(Mate obj)
	{
	}

	protected override void CopyDataFromObject(Mate obj)
	{
		constraintData1 = obj._0023_003DzgM8TwmWg2tsG;
		constraintData2 = obj._0023_003DzdH0ws20LmJv0;
		Flipped = obj.Flipped;
	}

	public static implicit operator Mate(MateSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator MateSurrogate(Mate source)
	{
		return source?.ConvertToSurrogate();
	}
}
