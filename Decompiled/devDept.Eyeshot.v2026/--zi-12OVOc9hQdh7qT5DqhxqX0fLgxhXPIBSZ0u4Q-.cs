using System;
using System.Collections.Generic;
using System.Diagnostics;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal abstract class _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D : ICloneable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point3D[] _0023_003DzFsatqHw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public bool _0023_003Dz46iWwIQ_003D;

	protected _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D(Point3D[] _0023_003DzrdSL0CI_003D)
	{
		if (_0023_003DzrdSL0CI_003D.Length < 1)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996123));
		}
		_0023_003DzFsatqHw_003D = _0023_003DzrdSL0CI_003D;
	}

	protected _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dzl_0024MIsC0_003D)
		: this(Utility.DeepCopy(_0023_003Dzl_0024MIsC0_003D._0023_003DzFsatqHw_003D))
	{
	}

	public double _0023_003Dz2_OZI5A_003D()
	{
		return _0023_003DzFsatqHw_003D[0].Z;
	}

	public static bool _0023_003Dz9h5MY_A_003D(Point3D[] _0023_003Dz9BM_0024JJOnfyrP, Point3D[] _0023_003Dzsuiz4uo_003D, double _0023_003Dzm0CYiiE_003D)
	{
		Point2D point2D = null;
		for (int i = 0; i < _0023_003Dzsuiz4uo_003D.Length - 1; i++)
		{
			Vector3D vector3D = new Vector3D(_0023_003Dzsuiz4uo_003D[i], _0023_003Dzsuiz4uo_003D[i + 1]);
			vector3D.Normalize();
			vector3D *= _0023_003Dzm0CYiiE_003D;
			Segment2D segment2D = new Segment2D(_0023_003Dzsuiz4uo_003D[i] + vector3D, _0023_003Dzsuiz4uo_003D[i + 1] - vector3D);
			if (point2D != null)
			{
				Segment2D segment = new Segment2D(point2D, segment2D.P0);
				if (Utility.Intersection2D(_0023_003Dz9BM_0024JJOnfyrP, segment, tIntersections: false))
				{
					return true;
				}
			}
			if (Utility.Intersection2D(_0023_003Dz9BM_0024JJOnfyrP, segment2D, tIntersections: false))
			{
				return true;
			}
			point2D = segment2D.P1;
		}
		return false;
	}

	internal virtual bool _0023_003DzlPrfzfc_003D(_0023_003DzEZ5ffIm4XtP4sNXURu9lrinvBTIMLCfe3lEU6wRXuTUl _0023_003DzS3WVCr8Gsb__0024, cutDirectionType _0023_003DzCIpOJSfcMrGo, double _0023_003Dzm0CYiiE_003D)
	{
		return !_0023_003Dz9h5MY_A_003D(_0023_003DzFsatqHw_003D, _0023_003DzS3WVCr8Gsb__0024._0023_003DzDKVESdcjwYUE, _0023_003Dzm0CYiiE_003D);
	}

	public virtual bool _0023_003Dz9h5MY_A_003D(Point3D[] _0023_003DzrdSL0CI_003D)
	{
		return Utility.Intersection2D(_0023_003DzrdSL0CI_003D, _0023_003DzFsatqHw_003D);
	}

	public virtual Toolpath.Motion[] _0023_003DzRwuOq0Upg_0024zq(double _0023_003Dz1v8WebVg_QJi, double _0023_003Dz4w6tHu4_003D, int _0023_003DzT77IOkXWdT4C)
	{
		if (_0023_003DzT77IOkXWdT4C < 0 || _0023_003DzT77IOkXWdT4C >= _0023_003DzFsatqHw_003D.Length)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996827));
		}
		List<Toolpath.Motion> list = new List<Toolpath.Motion>(_0023_003DzFsatqHw_003D.Length - 1);
		for (int i = 0; i < _0023_003DzFsatqHw_003D.Length; i++)
		{
			int num = (_0023_003DzT77IOkXWdT4C + i) % _0023_003DzFsatqHw_003D.Length;
			int num2 = (num + 1) % _0023_003DzFsatqHw_003D.Length;
			if (num != _0023_003DzFsatqHw_003D.Length - 1)
			{
				list.Add(new Toolpath.LinearMotion((Point3D)_0023_003DzFsatqHw_003D[num].Clone(), _0023_003DzFsatqHw_003D[num2], motionType.G01, _0023_003Dz1v8WebVg_QJi, _0023_003Dz4w6tHu4_003D, string.Empty)
				{
					Approach = approachType.None
				});
			}
		}
		return list.ToArray();
	}

	public abstract object Clone();
}
