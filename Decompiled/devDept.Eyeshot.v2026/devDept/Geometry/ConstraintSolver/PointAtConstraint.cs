using System;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class PointAtConstraint : PointOnConstraint
{
	public override bool Reference
	{
		get
		{
			return false;
		}
		set
		{
			base.Reference = false;
		}
	}

	protected PointAtConstraint(PointOnConstraint another)
		: base(another)
	{
	}

	internal PointAtConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal PointAtConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzlY77YgY_003D, SketchCurve _0023_003DzdbWJotE_003D, double _0023_003DzPzO_0024GUk_003D)
		: base(_0023_003DzjCETKTg_003D, _0023_003DzlY77YgY_003D, _0023_003DzdbWJotE_003D, _0023_003DzYWqyvPg_003D: false)
	{
		SetValue(_0023_003DzPzO_0024GUk_003D);
	}

	protected PointAtConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new PointAtConstraintSurrogate(this);
	}

	public override object Clone()
	{
		return new PointAtConstraint(this);
	}

	internal override Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, SketchCurve _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D = null)
	{
		if (_0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D is SketchPoint)
		{
			return new PointAtConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D, value._0023_003DzV29zQ3g_003D());
		}
		return new PointAtConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003DzDcIV_0024IrpvPA8eyHeBg_003D_003D, _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, value._0023_003DzV29zQ3g_003D());
	}
}
