using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
internal sealed class Param : ICloneable
{
	public string name;

	public bool reduceable = true;

	private double v;

	public bool changed;

	public bool drag;

	[CompilerGenerated]
	private Exp _003Cexp_003Ek__BackingField;

	protected internal Param(Param _0023_003DzySgeilxprQOK)
	{
		name = _0023_003DzySgeilxprQOK.name;
		_0023_003DzO_0024HwSzQ_003D(_0023_003DzySgeilxprQOK._0023_003DzV29zQ3g_003D());
		reduceable = _0023_003DzySgeilxprQOK.reduceable;
		_0023_003DzSg4pYR_0024iF_0024fn(new Exp(this));
		changed = _0023_003DzySgeilxprQOK.changed;
	}

	public Param(string _0023_003DzS_00246o7tc_003D, bool _0023_003DziG55oRyj2zxanVvf0Q_003D_003D = true)
	{
		name = _0023_003DzS_00246o7tc_003D;
		reduceable = _0023_003DziG55oRyj2zxanVvf0Q_003D_003D;
		_0023_003DzSg4pYR_0024iF_0024fn(new Exp(this));
	}

	public Param(string _0023_003DzS_00246o7tc_003D, double _0023_003DzPzO_0024GUk_003D)
	{
		name = _0023_003DzS_00246o7tc_003D;
		_0023_003DzO_0024HwSzQ_003D(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzSg4pYR_0024iF_0024fn(new Exp(this));
	}

	protected Param(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
	{
		name = _0023_003Dz9lrNnXY_003D.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
		_0023_003DzO_0024HwSzQ_003D(_0023_003Dz9lrNnXY_003D.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955820)));
		_0023_003DzSg4pYR_0024iF_0024fn((Exp)_0023_003Dz9lrNnXY_003D.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656848), typeof(Exp)));
	}

	public double _0023_003DzV29zQ3g_003D()
	{
		return v;
	}

	public void _0023_003DzO_0024HwSzQ_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		if (v != _0023_003DzPzO_0024GUk_003D && !double.IsNaN(_0023_003DzPzO_0024GUk_003D))
		{
			changed = true;
			v = _0023_003DzPzO_0024GUk_003D;
		}
	}

	public Exp _0023_003Dzuc1z_scDJBr3()
	{
		return _003Cexp_003Ek__BackingField;
	}

	private void _0023_003DzSg4pYR_0024iF_0024fn(Exp _0023_003DzPzO_0024GUk_003D)
	{
		_003Cexp_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	public object Clone()
	{
		return new Param(this);
	}

	public Param _0023_003DzqZwFarHnpOoH()
	{
		return SketchInternal._0023_003DzqZwFarHnpOoH(this);
	}

	public virtual void _0023_003DzbS3szdI_003D(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
	{
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), name);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955820), _0023_003DzV29zQ3g_003D());
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656848), _0023_003Dzuc1z_scDJBr3());
	}
}
