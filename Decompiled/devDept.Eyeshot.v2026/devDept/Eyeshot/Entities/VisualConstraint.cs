using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot.Entities;

public class VisualConstraint
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<VisualConstraint, Constraint> _0023_003DzhSxXfaw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dimension _0023_003DzTDeQYM_QyKFUlBqRo_0w1zE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IStackedLabel[] _0023_003Dz0IU1hqIyWjOstbCfmFfkxx8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected IViewportInternal _0023_003Dz3BW3eaE_003D;

	internal Constraint constraint
	{
		get
		{
			return _0023_003DzhSxXfaw_003D._0023_003DzUtOYa_o_003D();
		}
		set
		{
			_0023_003DzhSxXfaw_003D._0023_003Dzdlp53MQ_003D(value.constraintLink);
		}
	}

	public Dimension ConstraintDimension
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTDeQYM_QyKFUlBqRo_0w1zE_003D;
		}
	}

	public Constraint GConstraint => constraint;

	public bool Visible
	{
		get
		{
			return GConstraint.Visible;
		}
		set
		{
			GConstraint.Visible = value;
			if (ConstraintDimension != null)
			{
				ConstraintDimension.Visible = value;
			}
			if (_0023_003DzwTd_wmIwiPye() != null)
			{
				IStackedLabel[] array = _0023_003DzwTd_wmIwiPye();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Visible = value;
				}
			}
		}
	}

	internal VisualConstraint(Constraint _0023_003Dz9EdxXqI_003D)
	{
		_0023_003DzhSxXfaw_003D = new global::_0023_003DzBEedIFQsoSnWJL0MsMygMSsx_0024djL<VisualConstraint, Constraint>(this);
		constraint = _0023_003Dz9EdxXqI_003D;
	}

	internal VisualConstraint(IViewportInternal _0023_003DzqkfbPc0_003D, Dimension _0023_003DzGw7HTpAiPLx4, Constraint _0023_003Dz9EdxXqI_003D)
		: this(_0023_003Dz9EdxXqI_003D)
	{
		_0023_003DzTDeQYM_QyKFUlBqRo_0w1zE_003D = _0023_003DzGw7HTpAiPLx4;
		_0023_003Dz3BW3eaE_003D = _0023_003DzqkfbPc0_003D;
		Visible = _0023_003Dz9EdxXqI_003D.Visible;
	}

	internal VisualConstraint(IViewportInternal _0023_003DzqkfbPc0_003D, IStackedLabel[] _0023_003DzhnS4u9ZtBDlB, Constraint _0023_003Dz9EdxXqI_003D)
		: this(_0023_003Dz9EdxXqI_003D)
	{
		_0023_003Dz0IU1hqIyWjOstbCfmFfkxx8_003D = _0023_003DzhnS4u9ZtBDlB;
		IStackedLabel[] array = _0023_003DzwTd_wmIwiPye();
		foreach (IStackedLabel stackedLabel in array)
		{
			stackedLabel.Constraint = this;
			stackedLabel.UpdateAnchorPoint(_0023_003DzqkfbPc0_003D.parent.CurrentTransformation);
		}
		_0023_003Dz3BW3eaE_003D = _0023_003DzqkfbPc0_003D;
		Visible = _0023_003Dz9EdxXqI_003D.Visible;
	}

	internal IStackedLabel[] _0023_003DzwTd_wmIwiPye()
	{
		return _0023_003Dz0IU1hqIyWjOstbCfmFfkxx8_003D;
	}

	internal SketchCurve[] _0023_003DzIFukBjkqga2dbdlCxA_003D_003D()
	{
		return constraint.GetEntities().ToArray();
	}

	public void Destroy()
	{
		constraint.Destroy();
		if (_0023_003DzwTd_wmIwiPye() != null)
		{
			IStackedLabel[] array = _0023_003DzwTd_wmIwiPye();
			foreach (IStackedLabel stackedLabel in array)
			{
				_0023_003Dz3BW3eaE_003D.RemoveLabel(stackedLabel);
			}
		}
		if (ConstraintDimension != null)
		{
			_0023_003Dz3BW3eaE_003D.parent.Entities.Remove(ConstraintDimension);
		}
	}

	internal virtual void _0023_003DzRxMIdizdKQ7q(SketchEntity _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D)
	{
		if (_0023_003DzwTd_wmIwiPye().Length > 1)
		{
			for (int i = 0; i < _0023_003DzwTd_wmIwiPye().Length - 1; i++)
			{
				Line line = new Line(_0023_003DzwTd_wmIwiPye()[i].AnchorPoint, _0023_003DzwTd_wmIwiPye()[i + 1].AnchorPoint);
				line.Regen(new RegenParams(_0023_003Dz3BW3eaE_003D.parent.Entities));
				line.LineWeight = 1f;
				line.LineWeightMethod = colorMethodType.byEntity;
				line.Color = _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D.Params.HoveringColor;
				line.ColorMethod = colorMethodType.byEntity;
				_0023_003Dz3BW3eaE_003D.parent.TempEntities.Add(line);
			}
		}
	}
}
