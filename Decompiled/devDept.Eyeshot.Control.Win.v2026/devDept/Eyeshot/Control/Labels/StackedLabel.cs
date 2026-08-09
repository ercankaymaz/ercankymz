using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;

namespace devDept.Eyeshot.Control.Labels;

[Serializable]
public class StackedLabel : ImageOnly, IStackedLabel, ILabel
{
	public enum orientationType : byte
	{
		Horizontal = 1,
		Vertical
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzJEDvNe4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal SketchCurve _0023_003DzFQoJmsjWPpodV7yemw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private VisualConstraint _0023_003Dz_0024urc8xm261m0rDB7dw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private orientationType _0023_003DzFVszQvVvIA6ISap7qwhtnms_003D = orientationType.Horizontal;

	public VisualConstraint Constraint
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_0024urc8xm261m0rDB7dw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_0024urc8xm261m0rDB7dw_003D_003D = value;
		}
	}

	public orientationType OrientationMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzFVszQvVvIA6ISap7qwhtnms_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzFVszQvVvIA6ISap7qwhtnms_003D = value;
		}
	}

	public StackedLabel(double x, double y, double z, Bitmap bitmap, int position)
		: base(x, y, z, bitmap, -4, -4)
	{
		_0023_003DzJEDvNe4_003D = position;
	}

	internal StackedLabel(Bitmap _0023_003DzmPRo6QY_003D, SketchCurve _0023_003DzSLnz75LnM5Rs)
		: base(0.0, 0.0, 0.0, _0023_003DzmPRo6QY_003D, -4, -4)
	{
		_0023_003DzFQoJmsjWPpodV7yemw_003D_003D = _0023_003DzSLnz75LnM5Rs;
	}

	internal Constraint _0023_003Dz6pzz0jpYcSyePZtY2g_003D_003D()
	{
		return Constraint.constraint;
	}

	public virtual void UpdateAnchorPoint(Transformation accumulatedTransform = null)
	{
		if (_0023_003DzFQoJmsjWPpodV7yemw_003D_003D != null)
		{
			base.AnchorPoint = _0023_003DzFQoJmsjWPpodV7yemw_003D_003D.PointAt(0.5);
			if (accumulatedTransform != null)
			{
				base.AnchorPoint.TransformBy(accumulatedTransform);
			}
		}
	}

	private void _0023_003DzwZ9QhuttrgkQmNnGflFgq0k52zNqSH074IJZzFk_003D()
	{
		_0023_003DzJEDvNe4_003D = 0;
	}

	void IStackedLabel.ResetPos()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zwZ9QhuttrgkQmNnGflFgq0k52zNqSH074IJZzFk=
		this._0023_003DzwZ9QhuttrgkQmNnGflFgq0k52zNqSH074IJZzFk_003D();
	}

	private void _0023_003DzhKfO01AqyJND_0024SfiNU_0024zl0wXjHU6R0r1caNpB6c_003D()
	{
		_0023_003DzJEDvNe4_003D++;
	}

	void IStackedLabel.IncrementPos()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zhKfO01AqyJND$SfiNU$zl0wXjHU6R0r1caNpB6c=
		this._0023_003DzhKfO01AqyJND_0024SfiNU_0024zl0wXjHU6R0r1caNpB6c_003D();
	}

	public override void Draw(RenderContextBase renderContext, float drawScale)
	{
		renderContext.PushModelView();
		_0023_003DzP78CzIY_XfNL(renderContext, _0023_003DznI_0024Vb2kPYhc_0024: false);
		base.Draw(renderContext, drawScale);
		renderContext.PopModelView();
	}

	protected internal override void DrawForSelection(RenderContextBase renderContext)
	{
		renderContext.PushModelView();
		_0023_003DzP78CzIY_XfNL(renderContext, _0023_003DznI_0024Vb2kPYhc_0024: true);
		base.DrawForSelection(renderContext);
		renderContext.PopModelView();
	}

	private void _0023_003DzP78CzIY_XfNL(RenderContextBase _0023_003DzmNZD0Zs_003D, bool _0023_003DznI_0024Vb2kPYhc_0024)
	{
		double num = ((_0023_003DznI_0024Vb2kPYhc_0024 && base.ImageForSelection != null) ? base.ImageForSelection.Width : base.Image.Width);
		double num2 = ((_0023_003DznI_0024Vb2kPYhc_0024 && base.ImageForSelection != null) ? base.ImageForSelection.Height : base.Image.Height);
		switch (OrientationMode)
		{
		case orientationType.Horizontal:
			_0023_003DzmNZD0Zs_003D.TranslateMatrixModelView((num + num / 4.0) * (double)_0023_003DzJEDvNe4_003D, 0.0, 0.0);
			break;
		case orientationType.Vertical:
			_0023_003DzmNZD0Zs_003D.TranslateMatrixModelView(0.0, (num2 + num2 / 4.0) * (double)_0023_003DzJEDvNe4_003D, 0.0);
			break;
		}
	}
}
