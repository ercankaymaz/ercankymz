using System;
using System.Collections.Generic;
using System.Diagnostics;
using devDept.Geometry;

internal class _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D : IVertex
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003DzWy_0024UOU65OoM7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int _0023_003DzyzK8swU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public long _0023_003DzFuXfk4k_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public long _0023_003DzZ_0024Wvtoc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point2D _0023_003DzIHt45I8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point3D _0023_003Dzyjwk8PdbSXxQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public double _0023_003Dz_0024pfZB54_003D = -1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public LinkedList<Point3D> _0023_003DzyA3T2Zg_003D;

	public _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(Point2D _0023_003DzMlCq3wk_003D)
	{
		_0023_003DzIHt45I8_003D = _0023_003DzMlCq3wk_003D;
		_0023_003DzWy_0024UOU65OoM7 = false;
		_0023_003DzyzK8swU_003D = -1;
	}

	public _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(int _0023_003DzyzK8swU_003D, Point2D _0023_003DzMlCq3wk_003D)
	{
		_0023_003DzIHt45I8_003D = _0023_003DzMlCq3wk_003D;
		this._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
		_0023_003DzWy_0024UOU65OoM7 = false;
	}

	public _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(int _0023_003DzyzK8swU_003D, Point2D _0023_003DzMlCq3wk_003D, long _0023_003Dz1rZ3w2I_003D, long _0023_003DzNGFpltQ_003D)
	{
		_0023_003DzIHt45I8_003D = _0023_003DzMlCq3wk_003D;
		_0023_003DzFuXfk4k_003D = _0023_003Dz1rZ3w2I_003D;
		_0023_003DzZ_0024Wvtoc_003D = _0023_003DzNGFpltQ_003D;
		this._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
		_0023_003DzWy_0024UOU65OoM7 = false;
	}

	public _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(int _0023_003DzyzK8swU_003D, long _0023_003Dz1rZ3w2I_003D, long _0023_003DzNGFpltQ_003D, IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		_0023_003DzOSo8vaE_003D.ScaleToWorld(_0023_003Dz1rZ3w2I_003D, _0023_003DzNGFpltQ_003D, out var x, out var y);
		_0023_003DzFuXfk4k_003D = _0023_003Dz1rZ3w2I_003D;
		_0023_003DzZ_0024Wvtoc_003D = _0023_003DzNGFpltQ_003D;
		_0023_003DzIHt45I8_003D = new Point2D(x, y);
		this._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
		_0023_003DzWy_0024UOU65OoM7 = false;
	}

	public _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(Point3D _0023_003DzkEYxO1SuR1Kw, Point3D _0023_003DzF7v9r2A_003D, Size2D _0023_003DzNnmvTM0_003D, int _0023_003DzaOnlhyY_003D)
	{
		double a = (_0023_003DzkEYxO1SuR1Kw.X - _0023_003DzF7v9r2A_003D.X) / _0023_003DzNnmvTM0_003D.Max * (double)_0023_003DzaOnlhyY_003D;
		_0023_003DzFuXfk4k_003D = (long)Math.Round(a);
		double a2 = (_0023_003DzkEYxO1SuR1Kw.Y - _0023_003DzF7v9r2A_003D.Y) / _0023_003DzNnmvTM0_003D.Max * (double)_0023_003DzaOnlhyY_003D;
		_0023_003DzZ_0024Wvtoc_003D = (long)Math.Round(a2);
		_0023_003DzIHt45I8_003D = _0023_003DzkEYxO1SuR1Kw;
	}

	public _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(int _0023_003DzBJFJHwk_003D, int _0023_003Dz40R7bAU_003D, Point3D _0023_003DzF7v9r2A_003D, Size2D _0023_003DzNnmvTM0_003D, int _0023_003DzaOnlhyY_003D)
	{
		_0023_003DzFuXfk4k_003D = _0023_003DzBJFJHwk_003D;
		_0023_003DzZ_0024Wvtoc_003D = _0023_003Dz40R7bAU_003D;
		_0023_003DzIHt45I8_003D = new Point3D(_0023_003DzF7v9r2A_003D.X + (double)_0023_003DzBJFJHwk_003D * _0023_003DzNnmvTM0_003D.Max / (double)_0023_003DzaOnlhyY_003D, _0023_003DzF7v9r2A_003D.Y + (double)_0023_003Dz40R7bAU_003D * _0023_003DzNnmvTM0_003D.Max / (double)_0023_003DzaOnlhyY_003D);
	}

	public _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(int _0023_003DzqhsKlJc_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003Dz1NtQM9wHyYaT)
		: this(_0023_003DzqhsKlJc_003D, _0023_003Dz1NtQM9wHyYaT._0023_003DzIHt45I8_003D)
	{
		_0023_003DzFuXfk4k_003D = _0023_003Dz1NtQM9wHyYaT._0023_003DzFuXfk4k_003D;
		_0023_003DzZ_0024Wvtoc_003D = _0023_003Dz1NtQM9wHyYaT._0023_003DzZ_0024Wvtoc_003D;
		_0023_003Dz_0024pfZB54_003D = _0023_003Dz1NtQM9wHyYaT._0023_003Dz_0024pfZB54_003D;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653048), base.ToString(), _0023_003DzWy_0024UOU65OoM7, _0023_003DzyzK8swU_003D);
	}

	public static bool _0023_003DzlXwoCr7br7_7(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzFj_0024IqDQ_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzjdeMMkk_003D)
	{
		if (_0023_003DzFj_0024IqDQ_003D._0023_003DzFuXfk4k_003D == _0023_003DzjdeMMkk_003D._0023_003DzFuXfk4k_003D)
		{
			return _0023_003DzFj_0024IqDQ_003D._0023_003DzZ_0024Wvtoc_003D == _0023_003DzjdeMMkk_003D._0023_003DzZ_0024Wvtoc_003D;
		}
		return false;
	}

	public static double _0023_003DzIXhOPxB2Djci(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzjbqS1qE_003D, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003Dz1v6oPQk_003D)
	{
		double num = _0023_003Dz1v6oPQk_003D._0023_003DzFuXfk4k_003D - _0023_003DzjbqS1qE_003D._0023_003DzFuXfk4k_003D;
		double num2 = _0023_003Dz1v6oPQk_003D._0023_003DzZ_0024Wvtoc_003D - _0023_003DzjbqS1qE_003D._0023_003DzZ_0024Wvtoc_003D;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public double[] ToArray()
	{
		return _0023_003DzIHt45I8_003D.ToArray();
	}
}
