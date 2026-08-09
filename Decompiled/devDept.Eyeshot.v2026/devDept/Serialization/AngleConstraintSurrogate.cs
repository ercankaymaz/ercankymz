using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class AngleConstraintSurrogate : ValueConstraintSurrogate
{
	public bool Supplementary;

	public AngleConstraintSurrogate(AngleConstraint angleConstraint)
		: base(angleConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		AngleConstraint angleConstraint = new AngleConstraint(null);
		CopyDataToObject(angleConstraint);
		return angleConstraint;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		((AngleConstraint)sketchItem)._0023_003DzA_WUrzZQ5SEjFakyKPc32NE_003D(Supplementary);
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		AngleConstraint angleConstraint = (AngleConstraint)sketchItem;
		Supplementary = angleConstraint._0023_003Dz_eR8HRf3mFd11k584VDLJGw_003D();
		base.CopyDataFromObject(sketchItem);
	}
}
