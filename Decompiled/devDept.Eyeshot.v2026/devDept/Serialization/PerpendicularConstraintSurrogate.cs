using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class PerpendicularConstraintSurrogate : ConstraintSurrogate
{
	public byte Option;

	public PerpendicularConstraintSurrogate(PerpendicularConstraint perpendicularConstraint)
		: base(perpendicularConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		PerpendicularConstraint perpendicularConstraint = new PerpendicularConstraint(null);
		CopyDataToObject(perpendicularConstraint);
		return perpendicularConstraint;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		((PerpendicularConstraint)sketchItem)._0023_003DzmJuZp_0024UcZA5h((PerpendicularConstraint.Option)Option);
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		PerpendicularConstraint perpendicularConstraint = (PerpendicularConstraint)sketchItem;
		Option = (byte)perpendicularConstraint._0023_003Dz0neAlmEyvmPj();
		base.CopyDataFromObject(sketchItem);
	}
}
