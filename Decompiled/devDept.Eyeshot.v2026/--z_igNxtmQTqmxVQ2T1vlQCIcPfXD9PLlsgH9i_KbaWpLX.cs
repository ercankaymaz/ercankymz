using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003Dz_igNxtmQTqmxVQ2T1vlQCIcPfXD9PLlsgH9i_KbaWpLX : _0023_003Dz_igNxtmQTqmxVQ2T1vlQCOKtpQ5zXtH9BKsv39yYVPov
{
	public static void _0023_003Dz87PsHa5sRJbE(Curve _0023_003Dz8fpRyMu9aKjE, out Curve _0023_003Dzj9kq7RRev6fS, out Curve _0023_003DzWQkHZg1gwsuM)
	{
		double minKnotDist = _0023_003Dz8fpRyMu9aKjE._0023_003DziP9fFuA_003D.MinAcceptableKnotDistance(_0023_003Dz8fpRyMu9aKjE._0023_003DzB68dg9Q_003D);
		double u = _0023_003Dz8fpRyMu9aKjE.Domain.Mid;
		_0023_003Dz8fpRyMu9aKjE._0023_003DziP9fFuA_003D.FindSpanMult(ref u, _0023_003Dz8fpRyMu9aKjE._0023_003DzB68dg9Q_003D, minKnotDist, out var k, out var _);
		int splitPt;
		int num = _0023_003Dz8fpRyMu9aKjE._0023_003DziP9fFuA_003D.Split(u, k, _0023_003Dz8fpRyMu9aKjE._0023_003DzFNjygTLTZtF3(), _0023_003Dz8fpRyMu9aKjE.Degree, out splitPt);
		if (num > 0)
		{
			_0023_003Dz8fpRyMu9aKjE.InsertKnot(u, num);
		}
		_0023_003Dz8fpRyMu9aKjE._0023_003Dz6FU3i3VDkaNvS1Iafw_003D_003D(splitPt + _0023_003Dz8fpRyMu9aKjE.Degree, out _0023_003Dzj9kq7RRev6fS, out _0023_003DzWQkHZg1gwsuM);
	}

	public static Point3D[] _0023_003DzvKjleDzBEPeHTOWneerYzYE_003D(Curve _0023_003Dz4wZe_0024Xg_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz0mZ4_0024fFWxsTX)
	{
		List<PointTangentU> list = new List<PointTangentU>();
		List<Curve> list2 = new List<Curve>(1);
		Curve curve = (Curve)_0023_003Dz4wZe_0024Xg_003D.Clone();
		if (_0023_003Dz4wZe_0024Xg_003D.Degree > 1)
		{
			curve._0023_003Dzj12UrcVzpdm69cC9wcXWshYi0RL9(list2, 1, 0.001);
		}
		else
		{
			list2.Add(curve);
		}
		foreach (Curve item in list2)
		{
			_0023_003DzbL1v36D1POitf_0024XYc8ity7A_003D(list, item, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz0mZ4_0024fFWxsTX, 0);
		}
		list.Add(_0023_003DzJLfdvPw_003D(_0023_003Dz4wZe_0024Xg_003D, _0023_003Dz4wZe_0024Xg_003D._0023_003DzFNjygTLTZtF3(), _0023_003Dz4wZe_0024Xg_003D.Domain.High));
		return list.Cast<Point3D>().ToArray();
	}

	private static void _0023_003DzbL1v36D1POitf_0024XYc8ity7A_003D(List<PointTangentU> _0023_003DzrdSL0CI_003D, Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, double _0023_003Dz0mZ4_0024fFWxsTX, int _0023_003DzfNi7d4A_003D)
	{
		if (_0023_003Dz_igNxtmQTqmxVQ2T1vlQCOKtpQ5zXtH9BKsv39yYVPov._0023_003DznQ_0024Lpt8_0024jA_TU82zSQ_003D_003D(_0023_003Dz8fpRyMu9aKjE.Pw, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz0mZ4_0024fFWxsTX) && _0023_003DzfNi7d4A_003D > 0)
		{
			_0023_003DzrdSL0CI_003D.Add(_0023_003DzJLfdvPw_003D(_0023_003Dz8fpRyMu9aKjE, 0, _0023_003Dz8fpRyMu9aKjE.Domain.Low));
			return;
		}
		_0023_003Dz87PsHa5sRJbE(_0023_003Dz8fpRyMu9aKjE, out var _0023_003Dzj9kq7RRev6fS, out var _0023_003DzWQkHZg1gwsuM);
		_0023_003DzbL1v36D1POitf_0024XYc8ity7A_003D(_0023_003DzrdSL0CI_003D, _0023_003Dzj9kq7RRev6fS, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz0mZ4_0024fFWxsTX, _0023_003DzfNi7d4A_003D + 1);
		_0023_003DzbL1v36D1POitf_0024XYc8ity7A_003D(_0023_003DzrdSL0CI_003D, _0023_003DzWQkHZg1gwsuM, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz0mZ4_0024fFWxsTX, _0023_003DzfNi7d4A_003D + 1);
	}

	private static PointTangentU _0023_003DzJLfdvPw_003D(Curve _0023_003Dz8fpRyMu9aKjE, int _0023_003Dz437_00244ak_003D, double _0023_003Dz_eY3Y4c_003D)
	{
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzlY77YgY_003D = _0023_003Dz8fpRyMu9aKjE.Pw[_0023_003Dz437_00244ak_003D]._0023_003Dz53cmpTHe6Yih();
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzzzGF1TpipLsn = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003DzyWVxcUWfUOBv = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		if (_0023_003Dz437_00244ak_003D < _0023_003Dz8fpRyMu9aKjE.Pw.Length - 1)
		{
			_0023_003Dz_igNxtmQTqmxVQ2T1vlQCOKtpQ5zXtH9BKsv39yYVPov._0023_003DzAjVUKeRcDK1W(_0023_003Dz8fpRyMu9aKjE.Pw, ref _0023_003Dz437_00244ak_003D, in _0023_003DzlY77YgY_003D, ref _0023_003DzzzGF1TpipLsn, ref _0023_003DzyWVxcUWfUOBv);
		}
		else
		{
			_0023_003Dz_igNxtmQTqmxVQ2T1vlQCOKtpQ5zXtH9BKsv39yYVPov._0023_003Dz_0024R8AOQijyV6b(_0023_003Dz8fpRyMu9aKjE.Pw, ref _0023_003Dz437_00244ak_003D, in _0023_003DzlY77YgY_003D, ref _0023_003DzzzGF1TpipLsn, ref _0023_003DzyWVxcUWfUOBv);
		}
		return new PointTangentU(_0023_003DzlY77YgY_003D._0023_003Dzyk2fsPo_003D, _0023_003DzlY77YgY_003D._0023_003DzvXOLtKg_003D, _0023_003DzlY77YgY_003D._0023_003Dz8wjMonY_003D, _0023_003DzzzGF1TpipLsn._0023_003Dzyk2fsPo_003D, _0023_003DzzzGF1TpipLsn._0023_003DzvXOLtKg_003D, _0023_003DzzzGF1TpipLsn._0023_003Dz8wjMonY_003D, _0023_003Dz_eY3Y4c_003D);
	}

	private static void _0023_003DzIcCh_0024m0ace37MLueyw_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE, List<Curve> _0023_003DzTj1oJWREOpXS, int _0023_003DzSgf_0024TIQvcN_XBOc8Bg_003D_003D)
	{
		if (_0023_003Dz8fpRyMu9aKjE._0023_003DziP9fFuA_003D.FindMultipleKnots(_0023_003Dz8fpRyMu9aKjE._0023_003DzB68dg9Q_003D, _0023_003Dz8fpRyMu9aKjE._0023_003DzB68dg9Q_003D - _0023_003DzSgf_0024TIQvcN_XBOc8Bg_003D_003D + 1, out var j, out var _))
		{
			_0023_003Dz8fpRyMu9aKjE._0023_003Dz6FU3i3VDkaNvS1Iafw_003D_003D(j, out var _0023_003Dzj9kq7RRev6fS, out var _0023_003DzWQkHZg1gwsuM);
			_0023_003DzIcCh_0024m0ace37MLueyw_003D_003D(_0023_003Dzj9kq7RRev6fS, _0023_003DzTj1oJWREOpXS, 1);
			_0023_003DzIcCh_0024m0ace37MLueyw_003D_003D(_0023_003DzWQkHZg1gwsuM, _0023_003DzTj1oJWREOpXS, 1);
		}
		else
		{
			_0023_003DzTj1oJWREOpXS.Add(_0023_003Dz8fpRyMu9aKjE);
		}
	}

	public static List<Curve> _0023_003DzIcCh_0024m0ace37MLueyw_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE)
	{
		List<Curve> list = new List<Curve>();
		_0023_003DzIcCh_0024m0ace37MLueyw_003D_003D(_0023_003Dz8fpRyMu9aKjE, list, 1);
		return list;
	}
}
