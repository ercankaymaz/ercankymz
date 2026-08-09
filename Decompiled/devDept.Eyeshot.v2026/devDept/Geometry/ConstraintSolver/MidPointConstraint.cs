using System;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class MidPointConstraint : PointAtConstraint
{
	protected MidPointConstraint(MidPointConstraint another)
		: base(another)
	{
	}

	internal MidPointConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal MidPointConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzlY77YgY_003D, SketchCurve _0023_003DzdbWJotE_003D)
		: base(_0023_003DzjCETKTg_003D, _0023_003DzlY77YgY_003D, _0023_003DzdbWJotE_003D, 0.5)
	{
	}

	protected MidPointConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override void SetValue(double val)
	{
		value._0023_003DzO_0024HwSzQ_003D(0.5);
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new MidPointConstraintSurrogate(this);
	}

	public override object Clone()
	{
		return new MidPointConstraint(this);
	}
}
