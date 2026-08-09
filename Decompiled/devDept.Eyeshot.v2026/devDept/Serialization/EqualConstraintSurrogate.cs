using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class EqualConstraintSurrogate : ValueConstraintSurrogate
{
	internal byte FirstLengthType;

	internal byte SecondLengthType;

	public EqualConstraintSurrogate(EqualConstraint equalConstraint)
		: base(equalConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		EqualConstraint equalConstraint = new EqualConstraint(null);
		CopyDataToObject(equalConstraint);
		return equalConstraint;
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		EqualConstraint equalConstraint = (EqualConstraint)sketchItem;
		FirstLengthType = (byte)equalConstraint._0023_003DzK2sb0FUNL1PY();
		SecondLengthType = (byte)equalConstraint._0023_003DzH1QXDd7oQqe5();
		base.CopyDataFromObject(sketchItem);
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		EqualConstraint obj = (EqualConstraint)sketchItem;
		obj.lengthType[0] = (EqualConstraint.LengthType)FirstLengthType;
		obj.lengthType[1] = (EqualConstraint.LengthType)SecondLengthType;
		base.CopyDataToObject(sketchItem);
	}
}
