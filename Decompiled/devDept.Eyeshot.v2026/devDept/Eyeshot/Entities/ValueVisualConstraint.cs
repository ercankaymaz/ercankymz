using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot.Entities;

public class ValueVisualConstraint : VisualConstraint
{
	public bool Reference
	{
		get
		{
			return ((ValueConstraint)base.GConstraint).Reference;
		}
		set
		{
			((ValueConstraint)base.GConstraint).Reference = value;
		}
	}

	public double Value
	{
		get
		{
			return ((ValueConstraint)base.GConstraint).GetValue();
		}
		set
		{
			((ValueConstraint)base.GConstraint).SetValue(value);
		}
	}

	internal ValueVisualConstraint(IViewportInternal _0023_003DzqkfbPc0_003D, Dimension _0023_003Dzv8Ba3NgNlg4v, ValueConstraint _0023_003Dz95Fqw_A_003D)
		: base(_0023_003DzqkfbPc0_003D, _0023_003Dzv8Ba3NgNlg4v, _0023_003Dz95Fqw_A_003D)
	{
		SketchEntity._0023_003Dz36TNao7oaYj6(_0023_003Dzv8Ba3NgNlg4v, _0023_003Dz95Fqw_A_003D);
	}
}
