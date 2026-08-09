using System.Collections.Generic;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class ConstraintSurrogate : SketchItemSurrogate
{
	public List<IdPath> Ids;

	public bool Visible;

	public ConstraintSurrogate(Constraint constraint)
		: base(constraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		Constraint constraint = new Constraint(null);
		CopyDataToObject(constraint);
		return constraint;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		if (sketchItem is Constraint constraint)
		{
			constraint._0023_003DzsiBrP5k_003D(Ids);
			constraint.Visible = Visible;
		}
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		Constraint constraint = (Constraint)sketchItem;
		Ids = constraint._ids;
		Visible = constraint.Visible;
		base.CopyDataFromObject(sketchItem);
	}
}
