using System.Collections.Generic;
using System.Diagnostics;
using devDept.Geometry;

internal class _0023_003DznhE6nBcx_00243RtCTZj99SXz6_0024_scowomsqk_dL6AvwMiBpqsE4hA_003D_003D : _0023_003Dzi7XR59NGN6Cp
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Segment2D _0023_003Dz1ayrkO8UhMou;

	public _0023_003DznhE6nBcx_00243RtCTZj99SXz6_0024_scowomsqk_dL6AvwMiBpqsE4hA_003D_003D(_0023_003DzmKBPh7nOT6nY _0023_003DzsiQjbwmUNI0y, _0023_003DzmKBPh7nOT6nY _0023_003DzSElTn3BlQAJY, Segment2D _0023_003DzFDJdA7A_003D)
		: base(_0023_003DzsiQjbwmUNI0y, _0023_003DzSElTn3BlQAJY)
	{
		_0023_003Dz1ayrkO8UhMou = _0023_003DzFDJdA7A_003D;
	}

	public _0023_003DznhE6nBcx_00243RtCTZj99SXz6_0024_scowomsqk_dL6AvwMiBpqsE4hA_003D_003D(_0023_003Dzi7XR59NGN6Cp _0023_003DzhidJeNw_003D)
		: base(_0023_003DzhidJeNw_003D)
	{
	}

	public bool _0023_003DzxcI8W_00248_003D(Segment2D _0023_003DzgPsOl1A_003D)
	{
		if (_0023_003DzgPsOl1A_003D.P0 == _0023_003Dz1ayrkO8UhMou.P0 && _0023_003DzgPsOl1A_003D.P1 == _0023_003Dz1ayrkO8UhMou.P1)
		{
			return true;
		}
		return false;
	}

	public bool _0023_003Dz7rYaZTBgikVZmQm2Vw_003D_003D(double _0023_003Dz9NrCn_o_003D, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003Dz6tVBpdk_003D, double _0023_003DzvAxV_0024Ic_003D, Point2D _0023_003DzDPCfzJM_003D, out Point3D _0023_003DzkAcmnJ1o3LTq)
	{
		List<Point3D> list = new List<Point3D>();
		foreach (_0023_003DznZQ9NSjF878u item in _0023_003DzhoegMB067LVL)
		{
			_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = _0023_003DzlY77YgY_003D(item._0023_003Dz6V_0024QadA_003D);
			_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY3 = _0023_003DzlY77YgY_003D(item._0023_003DzCskoEKg_003D);
			Point3D point3D = new Point3D(_0023_003DzmKBPh7nOT6nY2._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY2._0023_003Dz40R7bAU_003D, _0023_003DzmKBPh7nOT6nY2._0023_003DzId5C3LA_003D);
			Point3D point3D2 = new Point3D(_0023_003DzmKBPh7nOT6nY3._0023_003DzBJFJHwk_003D, _0023_003DzmKBPh7nOT6nY3._0023_003Dz40R7bAU_003D, _0023_003DzmKBPh7nOT6nY3._0023_003DzId5C3LA_003D);
			if (_0023_003DzfOKwZ_RDvmdd(point3D, new Point2D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D), new Point2D(_0023_003DzBJFJHwk_003D + _0023_003Dz6tVBpdk_003D, _0023_003Dz40R7bAU_003D + _0023_003DzvAxV_0024Ic_003D)))
			{
				list.Add(point3D);
			}
			if (_0023_003DzfOKwZ_RDvmdd(point3D2, new Point2D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D), new Point2D(_0023_003DzBJFJHwk_003D + _0023_003Dz6tVBpdk_003D, _0023_003Dz40R7bAU_003D + _0023_003DzvAxV_0024Ic_003D)))
			{
				list.Add(point3D2);
			}
		}
		_0023_003DzkAcmnJ1o3LTq = null;
		if (list.Count == 2)
		{
			double num = Point2D.DistanceSquared(_0023_003DzDPCfzJM_003D, list[0]);
			double num2 = Point2D.DistanceSquared(_0023_003DzDPCfzJM_003D, list[1]);
			if (num < num2)
			{
				_0023_003DzkAcmnJ1o3LTq = list[0];
			}
			else
			{
				_0023_003DzkAcmnJ1o3LTq = list[1];
			}
			return true;
		}
		if (list.Count == 1)
		{
			_0023_003DzkAcmnJ1o3LTq = list[0];
			return true;
		}
		return false;
	}

	private bool _0023_003DzfOKwZ_RDvmdd(Point2D _0023_003DzZTe_0024jFG9ebLg, Point2D _0023_003DzctILmi4BTxnP, Point2D _0023_003Dz8CEpxh5dXoqe)
	{
		if (_0023_003DzZTe_0024jFG9ebLg.X >= _0023_003DzctILmi4BTxnP.X && _0023_003DzZTe_0024jFG9ebLg.X <= _0023_003Dz8CEpxh5dXoqe.X && _0023_003DzZTe_0024jFG9ebLg.Y >= _0023_003DzctILmi4BTxnP.Y && _0023_003DzZTe_0024jFG9ebLg.Y <= _0023_003Dz8CEpxh5dXoqe.Y)
		{
			return true;
		}
		return false;
	}
}
