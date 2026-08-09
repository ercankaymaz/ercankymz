using System;
using System.Collections.Generic;
using System.Diagnostics;
using devDept.Eyeshot;
using devDept.Geometry;

internal sealed class _0023_003DzaiwNQEWTVEK48te_0024K2mGAx1XNPoTvI5g8x0_LNM_003D : IEqualityComparer<PointOnCircle>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzrs3b507aH5yJ;

	public _0023_003DzaiwNQEWTVEK48te_0024K2mGAx1XNPoTvI5g8x0_LNM_003D(double _0023_003DzEGKj_0024SNUUihi)
	{
		_0023_003Dzrs3b507aH5yJ = _0023_003DzEGKj_0024SNUUihi;
	}

	public bool Equals(PointOnCircle _0023_003DzFj_0024IqDQ_003D, PointOnCircle _0023_003DzjdeMMkk_003D)
	{
		double num = Math.Abs(_0023_003DzFj_0024IqDQ_003D.Angle - _0023_003DzjdeMMkk_003D.Angle);
		if (!(num < Utility._0023_003DzxhnLabVjXjPg / _0023_003Dzrs3b507aH5yJ))
		{
			return Math.Abs(num - Math.PI * 2.0) < 1E-12;
		}
		return true;
	}

	public int GetHashCode(PointOnCircle _0023_003DzFj_0024IqDQ_003D)
	{
		return 0;
	}
}
