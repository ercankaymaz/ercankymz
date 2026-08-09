using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class MirrorConstraint : Constraint
{
	private Point2D p0;

	private Point2D p1;

	private SketchLine _axis;

	private SketchCurve _entA;

	private SketchCurve _entB;

	private double a;

	private double b;

	protected MirrorConstraint(MirrorConstraint another)
		: base(another)
	{
	}

	internal MirrorConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal MirrorConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003Dzmjv5NMqUZjM4, SketchCurve _0023_003Dz_ZfERpnclquK, SketchLine _0023_003DzxuJqjrs_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003Dzmjv5NMqUZjM4);
		_0023_003DzRCrpdGA_003D(_0023_003Dz_ZfERpnclquK);
		_0023_003DzRCrpdGA_003D(_0023_003DzxuJqjrs_003D);
	}

	protected MirrorConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	private void _0023_003DzwffUlylJRKLa()
	{
		_entA = _0023_003Dzjrbkyo8_003D(0);
		_entB = _0023_003Dzjrbkyo8_003D(1);
		_axis = _0023_003Dzjrbkyo8_003D(2) as SketchLine;
		p0 = _axis.StartPoint.PlanePosition;
		p1 = _axis.EndPoint.PlanePosition;
		double num = p1.X - p0.X;
		double num2 = p1.Y - p0.Y;
		a = (num * num - num2 * num2) / (num * num + num2 * num2);
		b = 2.0 * num * num2 / (num * num + num2 * num2);
	}

	[SpecialName]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		List<Exp> list = new List<Exp>();
		_0023_003DzwffUlylJRKLa();
		List<ExpVector> list2 = _entA._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().ToList();
		List<ExpVector> list3 = _entB._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().ToList();
		if (!(_entA is SketchArc _0023_003Dzfm4oGj8_003D))
		{
			for (int i = 0; i < list2.Count; i++)
			{
				list.Add(a * (list2[i].x - p0.X) + b * (list2[i].y - p0.Y) + p0.X - list3[i].x);
				list.Add(b * (list2[i].x - p0.X) - a * (list2[i].y - p0.Y) + p0.Y - list3[i].y);
			}
			if (_entA is SketchEllipse _0023_003Dz2T4sy2I_003D)
			{
				list.AddRange(_0023_003DzzI0cNK818p_glsJdn6_YaN8_003D(_0023_003Dz2T4sy2I_003D, _entB as SketchEllipse));
			}
			else if (_entA is SketchCircle)
			{
				list.Add(_0023_003Dz_3RPLPYfEyRBePvkeYVyhVsKbyUE(_entA as SketchCircle, _entB as SketchCircle));
			}
		}
		else
		{
			list.AddRange(_0023_003DzApKNQjFEqsjf_W17BzrrtYA_003D(_0023_003Dzfm4oGj8_003D, _entB as SketchArc));
		}
		return list;
	}

	private List<Exp> _0023_003DzzI0cNK818p_glsJdn6_YaN8_003D(SketchEllipse _0023_003Dz2T4sy2I_003D, SketchEllipse _0023_003DzO91j_0024fQ_003D)
	{
		List<Exp> list = new List<Exp>();
		List<ExpVector> list2 = _0023_003Dz2T4sy2I_003D._0023_003Dz5YatEap4_vPP().ToList();
		List<ExpVector> list3 = _0023_003DzO91j_0024fQ_003D._0023_003Dz5YatEap4_vPP().ToList();
		list.Add(a * (list2[0].x - p0.X) + b * (list2[0].y - p0.Y) + p0.X - list3[0].x);
		list.Add(b * (list2[0].x - p0.X) - a * (list2[0].y - p0.Y) + p0.Y - list3[0].y);
		list.Add(_0023_003Dz2T4sy2I_003D.r1._0023_003Dzuc1z_scDJBr3() - _0023_003DzO91j_0024fQ_003D.r1._0023_003Dzuc1z_scDJBr3());
		return list;
	}

	private Exp _0023_003Dz_3RPLPYfEyRBePvkeYVyhVsKbyUE(SketchCircle _0023_003Dzfm4oGj8_003D, SketchCircle _0023_003DzCVdPoWM_003D)
	{
		return _0023_003Dzfm4oGj8_003D._0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D() - _0023_003DzCVdPoWM_003D._0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D();
	}

	private List<Exp> _0023_003DzApKNQjFEqsjf_W17BzrrtYA_003D(SketchArc _0023_003Dzfm4oGj8_003D, SketchArc _0023_003DzCVdPoWM_003D)
	{
		List<Exp> list = new List<Exp>();
		List<ExpVector> list2 = _entA._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().ToList();
		List<ExpVector> list3 = _entB._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().ToList();
		list.Add(a * (list2[0].x - p0.X) + b * (list2[0].y - p0.Y) + p0.X - list3[1].x);
		list.Add(b * (list2[0].x - p0.X) - a * (list2[0].y - p0.Y) + p0.Y - list3[1].y);
		list.Add(a * (list2[1].x - p0.X) + b * (list2[1].y - p0.Y) + p0.X - list3[0].x);
		list.Add(b * (list2[1].x - p0.X) - a * (list2[1].y - p0.Y) + p0.Y - list3[0].y);
		list.Add(a * (list2[2].x - p0.X) + b * (list2[2].y - p0.Y) + p0.X - list3[2].x);
		return list;
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new MirrorConstraintSurrogate(this);
	}

	public override object Clone()
	{
		return new MirrorConstraint(this);
	}
}
