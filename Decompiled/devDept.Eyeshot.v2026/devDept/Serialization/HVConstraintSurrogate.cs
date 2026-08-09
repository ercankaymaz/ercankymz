using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class HVConstraintSurrogate : ConstraintSurrogate
{
	internal byte Orientation;

	public HVConstraintSurrogate(HVConstraint collinearPointsConstraint)
		: base(collinearPointsConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		HVConstraint hVConstraint = new HVConstraint(null);
		CopyDataToObject(hVConstraint);
		return hVConstraint;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		((HVConstraint)sketchItem).orientation = (hvOrientation)Orientation;
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		HVConstraint hVConstraint = (HVConstraint)sketchItem;
		Orientation = (byte)hVConstraint.orientation;
		base.CopyDataFromObject(sketchItem);
	}
}
