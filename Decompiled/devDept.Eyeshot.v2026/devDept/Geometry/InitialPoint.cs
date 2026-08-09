using System;
using System.Diagnostics;
using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

[Serializable]
public class InitialPoint : InterPoint
{
	public double curveTx;

	public double curveTy;

	public double curveTz;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dz4sg0Qp0_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal sbyte _0023_003DzuI5Ekdc_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Curve _0023_003DzutFG6gdoV0Ic;

	[NonSerialized]
	public Surface startPointCurveOwner;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Curve _0023_003DzAWeAyU4FWrA8I442mQ_003D_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Surface _0023_003Dzykss8zCkIIpmZGGp6g_003D_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzlWOnyq_0024UKjqEXiRxzQ_003D_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzL8NvYU0_003D = -1;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzSobLr5DEOQoE;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D;

	public Vector3D CurveTangent
	{
		get
		{
			return new Vector3D(curveTx, curveTy, curveTz);
		}
		set
		{
			curveTx = value.X;
			curveTy = value.Y;
			curveTz = value.Z;
		}
	}

	public InitialPoint(double x, double y, double z, double u, double v, double s, double t)
		: base(x, y, z, u, v, s, t)
	{
	}

	protected InitialPoint(InitialPoint another)
		: base(another)
	{
		curveTx = another.curveTx;
		curveTy = another.curveTy;
		curveTz = another.curveTz;
		_0023_003DzuI5Ekdc_003D = another._0023_003DzuI5Ekdc_003D;
		startPointCurveOwner = another.startPointCurveOwner;
		_0023_003DzutFG6gdoV0Ic = another._0023_003DzutFG6gdoV0Ic;
		_0023_003DzlWOnyq_0024UKjqEXiRxzQ_003D_003D = another._0023_003DzlWOnyq_0024UKjqEXiRxzQ_003D_003D;
		_0023_003DzL8NvYU0_003D = another._0023_003DzL8NvYU0_003D;
		_0023_003DzSobLr5DEOQoE = another._0023_003DzSobLr5DEOQoE;
		_0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D = another._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D;
		_0023_003Dzykss8zCkIIpmZGGp6g_003D_003D = another._0023_003Dzykss8zCkIIpmZGGp6g_003D_003D;
		_0023_003DzAWeAyU4FWrA8I442mQ_003D_003D = another._0023_003DzAWeAyU4FWrA8I442mQ_003D_003D;
	}

	public override object Clone()
	{
		return new InitialPoint(this);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657682), X, Y, Z, u, v, s, t, Tx, Ty, Tz, curveTx, curveTy, curveTz, _0023_003Dz4sg0Qp0_003D, _0023_003DzuI5Ekdc_003D);
	}

	internal void _0023_003Dzn6bPQr7PyIoe(bool _0023_003DzRVoDPs0_003D)
	{
		if (_0023_003DzutFG6gdoV0Ic == null || _0023_003DzutFG6gdoV0Ic.Pw.Length != 2 || _0023_003DzutFG6gdoV0Ic._0023_003DzB68dg9Q_003D != 1)
		{
			return;
		}
		if (startPointCurveOwner.IsClosedU && Utility.AreEqual(_0023_003DzutFG6gdoV0Ic.Pw[0].X, _0023_003DzutFG6gdoV0Ic.Pw[1].X, startPointCurveOwner.DomainU.Length))
		{
			if (Utility.AreEqual(_0023_003DzutFG6gdoV0Ic.Pw[0].X, startPointCurveOwner.DomainU.Low, startPointCurveOwner.DomainU.Length))
			{
				if (_0023_003DzRVoDPs0_003D)
				{
					s = startPointCurveOwner.DomainU.Low;
				}
				else
				{
					u = startPointCurveOwner.DomainU.Low;
				}
			}
			else if (Utility.AreEqual(_0023_003DzutFG6gdoV0Ic.Pw[0].X, startPointCurveOwner.DomainU.High, startPointCurveOwner.DomainU.Length))
			{
				if (_0023_003DzRVoDPs0_003D)
				{
					s = startPointCurveOwner.DomainU.High;
				}
				else
				{
					u = startPointCurveOwner.DomainU.High;
				}
			}
		}
		if (!startPointCurveOwner.IsClosedV || !Utility.AreEqual(_0023_003DzutFG6gdoV0Ic.Pw[0].Y, _0023_003DzutFG6gdoV0Ic.Pw[1].Y, startPointCurveOwner.DomainV.Length))
		{
			return;
		}
		if (Utility.AreEqual(_0023_003DzutFG6gdoV0Ic.Pw[0].Y, startPointCurveOwner.DomainV.Low, startPointCurveOwner.DomainV.Length))
		{
			if (_0023_003DzRVoDPs0_003D)
			{
				t = startPointCurveOwner.DomainV.Low;
			}
			else
			{
				v = startPointCurveOwner.DomainV.Low;
			}
		}
		else if (Utility.AreEqual(_0023_003DzutFG6gdoV0Ic.Pw[0].Y, startPointCurveOwner.DomainV.High, startPointCurveOwner.DomainV.Length))
		{
			if (_0023_003DzRVoDPs0_003D)
			{
				t = startPointCurveOwner.DomainV.High;
			}
			else
			{
				v = startPointCurveOwner.DomainV.High;
			}
		}
	}
}
