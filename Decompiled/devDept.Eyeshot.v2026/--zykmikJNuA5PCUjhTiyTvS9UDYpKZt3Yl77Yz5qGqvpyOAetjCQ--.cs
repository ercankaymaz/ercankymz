using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzykmikJNuA5PCUjhTiyTvS9UDYpKZt3Yl77Yz5qGqvpyOAetjCQ_003D_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Comparison<Point2D> _0023_003Dz1_0024Aj5hrJaAa4ofcrCw_003D_003D;

		public static Comparison<Point2D> _0023_003Dzb1k3XlgLXpaOl9ZXog_003D_003D;

		internal int _0023_003DzuntlmSPL5xLlOFIiN7YnuZc_003D(Point2D _0023_003DzjR_8wWk_003D, Point2D _0023_003DzC_0024S_002404o_003D)
		{
			return _0023_003DzjR_8wWk_003D.X.CompareTo(_0023_003DzC_0024S_002404o_003D.X);
		}

		internal int _0023_003Dzi8bTdin8UmsjeYWLK6EDawY_003D(Point2D _0023_003DzjR_8wWk_003D, Point2D _0023_003DzC_0024S_002404o_003D)
		{
			return _0023_003DzjR_8wWk_003D.Y.CompareTo(_0023_003DzC_0024S_002404o_003D.Y);
		}
	}

	public static void _0023_003Dz06n9PkUun1HUgE6byQ_003D_003D(Curve _0023_003Dzt_m8zV0_003D, Surface _0023_003DzuwH5j5s_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003Dzvqibe_pMVtBK, out Point2D[] _0023_003DzoO2gpqfpFDsn, out Point3D[] _0023_003Dz2j2Iiqvpb50u)
	{
		List<Point2D> list = new List<Point2D>();
		List<Point3D> list2 = new List<Point3D>();
		double _0023_003Dzpm4hAvE_003D = _0023_003Dzt_m8zV0_003D.Domain.Low;
		double high = _0023_003Dzt_m8zV0_003D.Domain.High;
		list2.Add(_0023_003DzGWmO8VKYZ6tQ(_0023_003Dzpm4hAvE_003D, _0023_003Dzt_m8zV0_003D, _0023_003DzuwH5j5s_003D, out var _0023_003DzMlCq3wk_003D));
		list.Add(_0023_003DzMlCq3wk_003D);
		double num;
		do
		{
			num = _0023_003Dzbee4VnaRyEjO(_0023_003Dzpm4hAvE_003D, high, _0023_003Dzt_m8zV0_003D, _0023_003DzuwH5j5s_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, list[list.Count - 1], out _0023_003DzMlCq3wk_003D, out var _0023_003DzprQbddHJ5BU);
			if (num < high)
			{
				list.Add(_0023_003DzMlCq3wk_003D);
				list2.Add(_0023_003DzprQbddHJ5BU);
			}
			else if (_0023_003Dzvqibe_pMVtBK)
			{
				Point2D point2D = _0023_003Dzt_m8zV0_003D.Evaluate(high);
				list.Add(point2D);
				list2.Add(_0023_003DzuwH5j5s_003D.Evaluate(point2D));
			}
			_0023_003Dzpm4hAvE_003D = num;
		}
		while (high != num);
		if (_0023_003Dzt_m8zV0_003D.IsClosed && list.Count <= 3)
		{
			if (_0023_003Dzvqibe_pMVtBK)
			{
				_0023_003DzoO2gpqfpFDsn = new Point2D[5];
				_0023_003Dz2j2Iiqvpb50u = new Point3D[5];
			}
			else
			{
				_0023_003DzoO2gpqfpFDsn = new Point2D[4];
				_0023_003Dz2j2Iiqvpb50u = new Point3D[4];
			}
			_0023_003DzoO2gpqfpFDsn[0] = _0023_003Dzt_m8zV0_003D.Evaluate(_0023_003Dzt_m8zV0_003D.Domain.Low);
			_0023_003DzoO2gpqfpFDsn[1] = _0023_003Dzt_m8zV0_003D.Evaluate(_0023_003Dzt_m8zV0_003D.Domain.Low + 1.0 * (_0023_003Dzt_m8zV0_003D.Domain.High - _0023_003Dzt_m8zV0_003D.Domain.Low) / 4.0);
			_0023_003DzoO2gpqfpFDsn[2] = _0023_003Dzt_m8zV0_003D.Evaluate(_0023_003Dzt_m8zV0_003D.Domain.Low + 2.0 * (_0023_003Dzt_m8zV0_003D.Domain.High - _0023_003Dzt_m8zV0_003D.Domain.Low) / 4.0);
			_0023_003DzoO2gpqfpFDsn[3] = _0023_003Dzt_m8zV0_003D.Evaluate(_0023_003Dzt_m8zV0_003D.Domain.Low + 3.0 * (_0023_003Dzt_m8zV0_003D.Domain.High - _0023_003Dzt_m8zV0_003D.Domain.Low) / 4.0);
			_0023_003Dz2j2Iiqvpb50u[0] = _0023_003DzuwH5j5s_003D.Evaluate(_0023_003DzoO2gpqfpFDsn[0]);
			_0023_003Dz2j2Iiqvpb50u[1] = _0023_003DzuwH5j5s_003D.Evaluate(_0023_003DzoO2gpqfpFDsn[1]);
			_0023_003Dz2j2Iiqvpb50u[2] = _0023_003DzuwH5j5s_003D.Evaluate(_0023_003DzoO2gpqfpFDsn[2]);
			_0023_003Dz2j2Iiqvpb50u[3] = _0023_003DzuwH5j5s_003D.Evaluate(_0023_003DzoO2gpqfpFDsn[3]);
			if (_0023_003Dzvqibe_pMVtBK)
			{
				_0023_003DzoO2gpqfpFDsn[4] = _0023_003Dzt_m8zV0_003D.Evaluate(_0023_003Dzt_m8zV0_003D.Domain.High);
				_0023_003Dz2j2Iiqvpb50u[4] = _0023_003DzuwH5j5s_003D.Evaluate(_0023_003DzoO2gpqfpFDsn[4]);
			}
		}
		else if (list.Count < 3 && (_0023_003DzuwH5j5s_003D.DegreeU > 1 || _0023_003DzuwH5j5s_003D.DegreeV > 1))
		{
			if (_0023_003Dzvqibe_pMVtBK)
			{
				_0023_003DzoO2gpqfpFDsn = new Point2D[3];
				_0023_003Dz2j2Iiqvpb50u = new Point3D[3];
			}
			else
			{
				_0023_003DzoO2gpqfpFDsn = new Point2D[2];
				_0023_003Dz2j2Iiqvpb50u = new Point3D[2];
			}
			_0023_003DzoO2gpqfpFDsn[0] = _0023_003Dzt_m8zV0_003D.Evaluate(_0023_003Dzt_m8zV0_003D.Domain.Low);
			_0023_003DzoO2gpqfpFDsn[1] = _0023_003Dzt_m8zV0_003D.Evaluate(_0023_003Dzt_m8zV0_003D.Domain.Low + 1.0 * (_0023_003Dzt_m8zV0_003D.Domain.High - _0023_003Dzt_m8zV0_003D.Domain.Low) / 2.0);
			_0023_003Dz2j2Iiqvpb50u[0] = _0023_003DzuwH5j5s_003D.Evaluate(_0023_003DzoO2gpqfpFDsn[0]);
			_0023_003Dz2j2Iiqvpb50u[1] = _0023_003DzuwH5j5s_003D.Evaluate(_0023_003DzoO2gpqfpFDsn[1]);
			if (_0023_003Dzvqibe_pMVtBK)
			{
				_0023_003DzoO2gpqfpFDsn[2] = _0023_003Dzt_m8zV0_003D.Evaluate(_0023_003Dzt_m8zV0_003D.Domain.High);
				_0023_003Dz2j2Iiqvpb50u[2] = _0023_003DzuwH5j5s_003D.Evaluate(_0023_003DzoO2gpqfpFDsn[2]);
			}
		}
		else
		{
			_0023_003DzoO2gpqfpFDsn = list.ToArray();
			_0023_003Dz2j2Iiqvpb50u = list2.ToArray();
		}
	}

	private static void _0023_003Dzi2AecIl5hdF3o5ScYw_003D_003D(Point3D _0023_003Dz9hCZZpfTJWan, ref double _0023_003Dzviq4Xy8_003D, ICurve _0023_003DzTx2aqr8_003D)
	{
		if (_0023_003DzTx2aqr8_003D.Project(_0023_003Dz9hCZZpfTJWan, out var t))
		{
			Point3D b = _0023_003DzTx2aqr8_003D.PointAt(t);
			double num = Point3D.Distance(_0023_003Dz9hCZZpfTJWan, b);
			if (num > _0023_003Dzviq4Xy8_003D)
			{
				_0023_003Dzviq4Xy8_003D = num;
			}
		}
	}

	public static void _0023_003DzmNMBEK7Q7qoi(double _0023_003Dz77g161c_003D, Surface _0023_003DzuwH5j5s_003D, double _0023_003Dzm0CYiiE_003D, PolyRegion2D _0023_003DzdlEIsrfiCNyX)
	{
		Segment2D segment2D = new Segment2D(_0023_003DzuwH5j5s_003D.DomainU.Low, _0023_003Dz77g161c_003D, _0023_003DzuwH5j5s_003D.DomainU.High, _0023_003Dz77g161c_003D);
		if (_0023_003DzuwH5j5s_003D.IsTrimmed && _0023_003DzdlEIsrfiCNyX != null)
		{
			foreach (ICurve item in _0023_003Dz9e4uinVEJJ_sAnsaCQ_003D_003D(_0023_003DzdlEIsrfiCNyX, segment2D, _0023_003DzuwH5j5s_003D.IsocurveU(segment2D.P0.Y), _0023_003DzuwH5j5s_003D, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzuntlmSPL5xLlOFIiN7YnuZc_003D))
			{
				((Entity)item).Regen(_0023_003Dzm0CYiiE_003D);
				_0023_003DzuwH5j5s_003D.geomIsocurves.Add(((Entity)item)._vertices);
			}
			return;
		}
		ICurve curve = _0023_003DzuwH5j5s_003D.IsocurveU(_0023_003Dz77g161c_003D);
		((Entity)curve).Regen(_0023_003Dzm0CYiiE_003D);
		_0023_003DzuwH5j5s_003D.geomIsocurves.Add(((Entity)curve)._vertices);
	}

	public static void _0023_003DzHv51eKgsa6Dy(double _0023_003Dz_eY3Y4c_003D, Surface _0023_003DzuwH5j5s_003D, double _0023_003Dzm0CYiiE_003D, PolyRegion2D _0023_003DzdlEIsrfiCNyX)
	{
		Segment2D segment2D = new Segment2D(_0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D.DomainV.Low, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D.DomainV.High);
		if (_0023_003DzuwH5j5s_003D.IsTrimmed && _0023_003DzdlEIsrfiCNyX != null)
		{
			foreach (ICurve item in _0023_003Dz9e4uinVEJJ_sAnsaCQ_003D_003D(_0023_003DzdlEIsrfiCNyX, segment2D, _0023_003DzuwH5j5s_003D.IsocurveV(segment2D.P0.X), _0023_003DzuwH5j5s_003D, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzi8bTdin8UmsjeYWLK6EDawY_003D))
			{
				((Entity)item).Regen(_0023_003Dzm0CYiiE_003D);
				_0023_003DzuwH5j5s_003D.geomIsocurves.Add(((Entity)item)._vertices);
			}
			return;
		}
		ICurve curve = _0023_003DzuwH5j5s_003D.IsocurveV(_0023_003Dz_eY3Y4c_003D);
		((Entity)curve).Regen(_0023_003Dzm0CYiiE_003D);
		_0023_003DzuwH5j5s_003D.geomIsocurves.Add(((Entity)curve)._vertices);
	}

	private static double _0023_003Dzbee4VnaRyEjO(double _0023_003Dzpm4hAvE_003D, double _0023_003Dz7CNwMo8_003D, Curve _0023_003Dzt_m8zV0_003D, Surface _0023_003DzuwH5j5s_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Point2D _0023_003Dz4LtdgEyQrlUa, out Point2D _0023_003Dz1bw8FoXemkDS, out Point3D _0023_003DzprQbddHJ5BU2)
	{
		Point3D[] array = new Point3D[4]
		{
			_0023_003DzGWmO8VKYZ6tQ(_0023_003Dzpm4hAvE_003D, _0023_003Dzt_m8zV0_003D, _0023_003DzuwH5j5s_003D, out _0023_003Dz1bw8FoXemkDS),
			_0023_003DzGWmO8VKYZ6tQ((2.0 * _0023_003Dzpm4hAvE_003D + _0023_003Dz7CNwMo8_003D) / 3.0, _0023_003Dzt_m8zV0_003D, _0023_003DzuwH5j5s_003D, out _0023_003Dz1bw8FoXemkDS),
			null,
			null
		};
		if (array[0] == array[1])
		{
			_0023_003DzprQbddHJ5BU2 = _0023_003DzGWmO8VKYZ6tQ(_0023_003Dzpm4hAvE_003D, _0023_003Dzt_m8zV0_003D, _0023_003DzuwH5j5s_003D, out _0023_003Dz1bw8FoXemkDS);
			return _0023_003Dz7CNwMo8_003D;
		}
		array[2] = _0023_003DzGWmO8VKYZ6tQ((_0023_003Dzpm4hAvE_003D + 2.0 * _0023_003Dz7CNwMo8_003D) / 3.0, _0023_003Dzt_m8zV0_003D, _0023_003DzuwH5j5s_003D, out _0023_003Dz1bw8FoXemkDS);
		array[3] = _0023_003DzGWmO8VKYZ6tQ(_0023_003Dz7CNwMo8_003D, _0023_003Dzt_m8zV0_003D, _0023_003DzuwH5j5s_003D, out _0023_003Dz1bw8FoXemkDS);
		_0023_003DzprQbddHJ5BU2 = array[3];
		Curve curve = Curve.GlobalInterpolation(array, 3);
		int num = curve._0023_003DzMv2C5Tm1QMvc() - 1;
		Point3D euclid = curve.Pw[0].Euclid;
		double num2 = 0.0;
		Vector3D vector3D = new Vector3D();
		int num3 = num;
		while (num3 > 0 && num2 < Utility._0023_003DzheSR8QM7q9ya)
		{
			vector3D = Vector3D.Subtract(curve.Pw[num3].Euclid, euclid);
			num2 = vector3D.Length;
			num3--;
		}
		vector3D.Normalize();
		double num4 = double.MinValue;
		if (num2 > Utility._0023_003DzheSR8QM7q9ya)
		{
			for (int i = 1; i < num; i++)
			{
				Vector3D vector3D2 = Vector3D.Cross(Vector3D.Subtract(curve.Pw[i].Euclid, euclid), vector3D);
				if (vector3D2.Length > num4)
				{
					num4 = vector3D2.Length;
				}
			}
		}
		if (num4 > _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			return _0023_003Dzbee4VnaRyEjO(_0023_003Dzpm4hAvE_003D, _0023_003Dzpm4hAvE_003D + (_0023_003Dz7CNwMo8_003D - _0023_003Dzpm4hAvE_003D) / 2.0, _0023_003Dzt_m8zV0_003D, _0023_003DzuwH5j5s_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz4LtdgEyQrlUa, out _0023_003Dz1bw8FoXemkDS, out _0023_003DzprQbddHJ5BU2);
		}
		return _0023_003Dz7CNwMo8_003D;
	}

	private static Point3D _0023_003DzGWmO8VKYZ6tQ(double _0023_003Dzpm4hAvE_003D, Curve _0023_003Dzt_m8zV0_003D, Surface _0023_003DzuwH5j5s_003D, out Point2D _0023_003DzMlCq3wk_003D)
	{
		_0023_003DzMlCq3wk_003D = _0023_003Dzt_m8zV0_003D.Evaluate(_0023_003Dzpm4hAvE_003D);
		if (_0023_003DzMlCq3wk_003D.X < _0023_003DzuwH5j5s_003D.DomainU.Low)
		{
			_0023_003DzMlCq3wk_003D.X = _0023_003DzuwH5j5s_003D.DomainU.Low;
		}
		if (_0023_003DzMlCq3wk_003D.X > _0023_003DzuwH5j5s_003D.DomainU.High)
		{
			_0023_003DzMlCq3wk_003D.X = _0023_003DzuwH5j5s_003D.DomainU.High;
		}
		if (_0023_003DzMlCq3wk_003D.Y < _0023_003DzuwH5j5s_003D.DomainV.Low)
		{
			_0023_003DzMlCq3wk_003D.Y = _0023_003DzuwH5j5s_003D.DomainV.Low;
		}
		if (_0023_003DzMlCq3wk_003D.Y > _0023_003DzuwH5j5s_003D.DomainV.High)
		{
			_0023_003DzMlCq3wk_003D.Y = _0023_003DzuwH5j5s_003D.DomainV.High;
		}
		return _0023_003DzuwH5j5s_003D.Evaluate(_0023_003DzMlCq3wk_003D);
	}

	public static List<ICurve> _0023_003Dz9e4uinVEJJ_sAnsaCQ_003D_003D(PolyRegion2D _0023_003DzdlEIsrfiCNyX, Segment2D _0023_003DzmCM_0024s12le28l, ICurve _0023_003DzVdq7bbx4A3_7, Surface _0023_003Dz_0024KKopL9T7nzT, Comparison<Point2D> _0023_003DzZw5LunE_003D)
	{
		List<ICurve> list = new List<ICurve>();
		Tuple<Segment2D, bool>[] array = _0023_003Dz9y6F_0024pWf69VkHAqP5Ep4FcSlwwoD._0023_003Dz_0024VUbMK2T3M0s(_0023_003DzmCM_0024s12le28l, _0023_003DzdlEIsrfiCNyX, _0023_003DzZw5LunE_003D);
		foreach (Tuple<Segment2D, bool> tuple in array)
		{
			if (tuple.Item2)
			{
				_0023_003DzVdq7bbx4A3_7.SubCurve(_0023_003Dz_0024KKopL9T7nzT.Evaluate(tuple.Item1.P0), _0023_003Dz_0024KKopL9T7nzT.Evaluate(tuple.Item1.P1), out var sub);
				if (sub != null)
				{
					list.Add(sub);
				}
			}
		}
		return list;
	}
}
