using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

internal sealed class _0023_003Dz_p2RXz7Ce_dbmSFJ520GhUDSB4eGuCW_0024cBERiyU_003D
{
	private sealed class _0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D
	{
		public ISketchCurve _0023_003Dz3y08FkIciEqrAWxFLQ_003D_003D;

		public _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		internal bool _0023_003DzbEH3M3V_0024yTT5vURQj2xP2UCpepnUDXASxw_003D_003D(Constraint _0023_003DzV_0024oduG8_003D)
		{
			if (_0023_003DzV_0024oduG8_003D is PointOnConstraint pointOnConstraint && pointOnConstraint.Point == _0023_003Dz3y08FkIciEqrAWxFLQ_003D_003D.StartPoint)
			{
				return pointOnConstraint.Curve == _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzXxLAHrF4RIfc;
			}
			return false;
		}

		internal bool _0023_003DzBF3lBkFmW6iGNh_kVb44Ps1FMxyfhjI9Ig_003D_003D(Constraint _0023_003DzV_0024oduG8_003D)
		{
			if (_0023_003DzV_0024oduG8_003D is PointOnConstraint pointOnConstraint && pointOnConstraint.Point == _0023_003Dz3y08FkIciEqrAWxFLQ_003D_003D.EndPoint)
			{
				return pointOnConstraint.Curve == _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzXxLAHrF4RIfc;
			}
			return false;
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Comparison<Tuple<double, Point3D, Entity>> _0023_003Dz_gQxC_0024JsqURHoyEgbQ_003D_003D;

		internal int _0023_003Dzyr9VQy8tf1IWi8b6yejYXj8_003D(Tuple<double, Point3D, Entity> _0023_003DzjbqS1qE_003D, Tuple<double, Point3D, Entity> _0023_003Dz1v6oPQk_003D)
		{
			return _0023_003DzjbqS1qE_003D.Item1.CompareTo(_0023_003Dz1v6oPQk_003D.Item1);
		}
	}

	private sealed class _0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D
	{
		public SketchSpline _0023_003DznYbCLDUxnKSb;

		public double _0023_003DzPzO_0024GUk_003D;

		internal bool _0023_003DzjxD0Q8eqkxdM4UJoqhf47BQ_003D(Constraint _0023_003DzV_0024oduG8_003D)
		{
			if (_0023_003DzV_0024oduG8_003D is TangentConstraint tangentConstraint && tangentConstraint.GetEntities()[0] == _0023_003DznYbCLDUxnKSb)
			{
				return tangentConstraint.FirstParam == _0023_003DzPzO_0024GUk_003D;
			}
			return false;
		}

		internal bool _0023_003Dzurs3GBmq8RzhnA2lsCG94Ao_003D(Constraint _0023_003DzV_0024oduG8_003D)
		{
			if (_0023_003DzV_0024oduG8_003D is TangentConstraint tangentConstraint && tangentConstraint.GetEntities()[1] == _0023_003DznYbCLDUxnKSb)
			{
				return tangentConstraint.SecondParam == _0023_003DzPzO_0024GUk_003D;
			}
			return false;
		}
	}

	private sealed class _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D
	{
		public SketchCurve _0023_003DzdbWJotE_003D;

		public Point3D _0023_003DzVrTLtysJK_0024OJ;

		internal bool _0023_003DzyTHrh13S2DSMl8wvSlTtRvS19WZN(Constraint _0023_003DzV_0024oduG8_003D)
		{
			if (_0023_003DzV_0024oduG8_003D.GetType() == typeof(PointOnConstraint) && ((PointOnConstraint)_0023_003DzV_0024oduG8_003D).Curve == _0023_003DzdbWJotE_003D)
			{
				return ((SketchPoint)((PointOnConstraint)_0023_003DzV_0024oduG8_003D).Point).Position.DistanceTo(_0023_003DzVrTLtysJK_0024OJ) < Utility._0023_003Dzjyaz_Vfaky9X;
			}
			return false;
		}
	}

	private sealed class _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D
	{
		public SketchCurve _0023_003DzXxLAHrF4RIfc;

		public ICurve _0023_003DzmCM_0024s12le28l;

		public Func<Point3D, bool> _0023_003DzkqbsCVPMJ_0024g6;

		internal bool _0023_003DzPXiU268fi8OKxAieY2_1AYAbir9tJSJSjw_003D_003D(Point3D _0023_003DzlY77YgY_003D)
		{
			if (_0023_003DzlY77YgY_003D != _0023_003DzmCM_0024s12le28l.StartPoint)
			{
				return _0023_003DzlY77YgY_003D != _0023_003DzmCM_0024s12le28l.EndPoint;
			}
			return false;
		}
	}

	private readonly IDesign _0023_003DzgdMixgk_003D;

	private readonly SketchEntity _0023_003Dzx1UORhPlCefSChIbXA_003D_003D;

	private readonly bool _0023_003DzhJ0IytM_003D;

	private readonly Plane _0023_003DznksI_0024l2L21KB;

	public _0023_003Dz_p2RXz7Ce_dbmSFJ520GhUDSB4eGuCW_0024cBERiyU_003D(IDesign _0023_003DzDh_00246Paw_003D, Plane _0023_003Dzrgqz890sj_0024X9, bool _0023_003DzqNH2rCw_003D)
	{
		_0023_003DzgdMixgk_003D = _0023_003DzDh_00246Paw_003D;
		_0023_003DznksI_0024l2L21KB = _0023_003Dzrgqz890sj_0024X9;
		_0023_003DzhJ0IytM_003D = _0023_003DzqNH2rCw_003D;
	}

	public _0023_003Dz_p2RXz7Ce_dbmSFJ520GhUDSB4eGuCW_0024cBERiyU_003D(IDesign _0023_003DzDh_00246Paw_003D, SketchEntity _0023_003Dz94T3qb4CfToF, bool _0023_003DzqNH2rCw_003D = false)
		: this(_0023_003DzDh_00246Paw_003D, _0023_003Dz94T3qb4CfToF.DrawingPlane, _0023_003DzqNH2rCw_003D)
	{
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D = _0023_003Dz94T3qb4CfToF;
	}

	private bool _0023_003DzasV9syYHZmlHt85CnQ_003D_003D()
	{
		return _0023_003Dzx1UORhPlCefSChIbXA_003D_003D != null;
	}

	private EllipticalArc _0023_003Dz_0024kXiR_IEww1B_0024OdzILtrI0s_003D(EllipticalArc _0023_003DzN4MDZ_0024c_003D, SketchEllipse _0023_003DzlvSYVUCV4yA5, Point3D _0023_003Dz3k5Uze_VdwnF, Point3D _0023_003DzMnu3zKCWb6Kc)
	{
		SketchEllipticalArc sketchEllipticalArc = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.AddEllipticalArc(_0023_003DzlvSYVUCV4yA5, _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003Dz3k5Uze_VdwnF), _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003DzMnu3zKCWb6Kc));
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchEllipticalArc.StartPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchEllipticalArc.EndPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzUQJXD50_003D(sketchEllipticalArc, _0023_003DzN4MDZ_0024c_003D, _0023_003DzgdMixgk_003D.Entities);
		return _0023_003DzN4MDZ_0024c_003D;
	}

	private void _0023_003Dz_0024kXiR_IEww1B_0024OdzILtrI0s_003D(EllipticalArc _0023_003DzN4MDZ_0024c_003D, SketchEllipse _0023_003DzlvSYVUCV4yA5, SketchPoint _0023_003Dz3k5Uze_VdwnF, Point3D _0023_003DzMnu3zKCWb6Kc)
	{
		SketchEllipticalArc sketchEllipticalArc = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.AddEllipticalArc(_0023_003DzlvSYVUCV4yA5, _0023_003Dz3k5Uze_VdwnF, _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003DzMnu3zKCWb6Kc));
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchEllipticalArc.EndPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzUQJXD50_003D(sketchEllipticalArc, _0023_003DzN4MDZ_0024c_003D, _0023_003DzgdMixgk_003D.Entities);
	}

	private void _0023_003Dz_0024kXiR_IEww1B_0024OdzILtrI0s_003D(EllipticalArc _0023_003DzN4MDZ_0024c_003D, SketchEllipse _0023_003DzlvSYVUCV4yA5, Point3D _0023_003DzbUvT9Pc_003D, Point3D _0023_003Dz3k5Uze_VdwnF, SketchPoint _0023_003DzMnu3zKCWb6Kc)
	{
		SketchEllipticalArc sketchEllipticalArc = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.AddEllipticalArc(_0023_003DzlvSYVUCV4yA5, _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003DzbUvT9Pc_003D), _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003Dz3k5Uze_VdwnF), _0023_003DzMnu3zKCWb6Kc);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchEllipticalArc.StartPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchEllipticalArc.Center, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzUQJXD50_003D(sketchEllipticalArc, _0023_003DzN4MDZ_0024c_003D, _0023_003DzgdMixgk_003D.Entities);
	}

	private Arc _0023_003DzndMX0HC_m4LJ(Arc _0023_003DzN4MDZ_0024c_003D, SketchPoint _0023_003DzbUvT9Pc_003D, Point3D _0023_003Dz3k5Uze_VdwnF, Point3D _0023_003DzMnu3zKCWb6Kc)
	{
		SketchArc sketchArc = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.AddArc(_0023_003DzbUvT9Pc_003D, _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003Dz3k5Uze_VdwnF), _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003DzMnu3zKCWb6Kc));
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchArc.StartPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchArc.EndPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzUQJXD50_003D(sketchArc, _0023_003DzN4MDZ_0024c_003D, _0023_003DzgdMixgk_003D.Entities);
		return _0023_003DzN4MDZ_0024c_003D;
	}

	private void _0023_003DzndMX0HC_m4LJ(Arc _0023_003DzN4MDZ_0024c_003D, SketchPoint _0023_003DzbUvT9Pc_003D, SketchPoint _0023_003Dz3k5Uze_VdwnF, Point3D _0023_003DzMnu3zKCWb6Kc)
	{
		SketchArc sketchArc = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.AddArc(_0023_003DzbUvT9Pc_003D, _0023_003Dz3k5Uze_VdwnF, _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003DzMnu3zKCWb6Kc));
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchArc.EndPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzUQJXD50_003D(sketchArc, _0023_003DzN4MDZ_0024c_003D, _0023_003DzgdMixgk_003D.Entities);
	}

	private void _0023_003DzndMX0HC_m4LJ(Arc _0023_003DzN4MDZ_0024c_003D, Point3D _0023_003DzbUvT9Pc_003D, Point3D _0023_003Dz3k5Uze_VdwnF, SketchPoint _0023_003DzMnu3zKCWb6Kc)
	{
		SketchArc sketchArc = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.AddArc(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003DzbUvT9Pc_003D), _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003Dz3k5Uze_VdwnF), _0023_003DzMnu3zKCWb6Kc);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchArc.StartPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchArc.Center, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzUQJXD50_003D(sketchArc, _0023_003DzN4MDZ_0024c_003D, _0023_003DzgdMixgk_003D.Entities);
	}

	private void _0023_003DzQOwqB_f6J_0024S_(Curve _0023_003Dz8fpRyMu9aKjE, SketchPoint _0023_003Dz3k5Uze_VdwnF, bool _0023_003DzAqOpw0w_003D)
	{
		SketchSpline sketchSpline = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.AddSpline(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz3k5Uze_VdwnF, _0023_003DzAqOpw0w_003D);
		if (_0023_003DzAqOpw0w_003D)
		{
			for (int i = 1; i < sketchSpline.ControlPoints.Length; i++)
			{
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchSpline.ControlPoints[i], _0023_003DzgdMixgk_003D.Entities);
			}
		}
		else
		{
			for (int j = 0; j < sketchSpline.ControlPoints.Length - 1; j++)
			{
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchSpline.ControlPoints[j], _0023_003DzgdMixgk_003D.Entities);
			}
		}
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzUQJXD50_003D(sketchSpline, _0023_003Dz8fpRyMu9aKjE, _0023_003DzgdMixgk_003D.Entities);
	}

	private void _0023_003DzBYn89lR_prFN(Line _0023_003DzQ9zpGF0_003D, SketchPoint _0023_003DzLxQW3eiASmKM, Point3D _0023_003DzMnu3zKCWb6Kc)
	{
		SketchLine sketchLine = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.AddLine(_0023_003DzLxQW3eiASmKM, _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003DzMnu3zKCWb6Kc));
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchLine.EndPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzUQJXD50_003D(sketchLine, _0023_003DzQ9zpGF0_003D, _0023_003DzgdMixgk_003D.Entities);
	}

	private void _0023_003DzBYn89lR_prFN(Line _0023_003DzQ9zpGF0_003D, Point3D _0023_003Dz3k5Uze_VdwnF, SketchPoint _0023_003DzLxQW3eiASmKM)
	{
		SketchLine sketchLine = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.AddLine(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Plane.Project(_0023_003Dz3k5Uze_VdwnF), _0023_003DzLxQW3eiASmKM);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz40alAqE_003D(sketchLine.StartPoint, _0023_003DzgdMixgk_003D.Entities);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzUQJXD50_003D(sketchLine, _0023_003DzQ9zpGF0_003D, _0023_003DzgdMixgk_003D.Entities);
	}

	private bool _0023_003DzbUyiDLZofvTlxALE7F_0024DGIE_003D(EllipticalArc _0023_003DzN4MDZ_0024c_003D, double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D, Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<Entity> _0023_003DzijSR7_0024YYLNcm, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		bool flag = Utility.Compare(1E-12, _0023_003DzDSaZWik_003D, _0023_003DzN4MDZ_0024c_003D.Domain.Low) == 0;
		bool flag2 = Utility.Compare(1E-12, _0023_003DzsK_Xndk_003D, _0023_003DzN4MDZ_0024c_003D.Domain.High) == 0;
		if (flag && flag2)
		{
			return false;
		}
		SketchEllipticalArc sketchEllipticalArc = null;
		SketchItem sketchItem = _0023_003DzN4MDZ_0024c_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
		{
			if (sketchItem == null)
			{
				return false;
			}
			sketchEllipticalArc = sketchItem as SketchEllipticalArc;
		}
		if (flag || flag2)
		{
			if (flag)
			{
				if (_0023_003DzhJ0IytM_003D)
				{
					_0023_003DzcM_Q3U04H3Bt.Add(new EllipticalArc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Center, _0023_003DzN4MDZ_0024c_003D.RadiusX, _0023_003DzN4MDZ_0024c_003D.RadiusY, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D), _0023_003DzN4MDZ_0024c_003D.EndPoint, flip: false));
					return true;
				}
				if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
				{
					sketchEllipticalArc.StartPoint.SetPosition(_0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D));
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dze5G1YDQ3JaMH(sketchEllipticalArc.StartPoint);
					if (!_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchEllipticalArc.StartPoint, sketchEllipticalArc, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D)))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(_0023_003DzN4MDZ_0024c_003D), _0023_003DzNpfDgu2nb0Hr);
					}
				}
				else
				{
					EllipticalArc ellipticalArc = new EllipticalArc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Center, _0023_003DzN4MDZ_0024c_003D.RadiusX, _0023_003DzN4MDZ_0024c_003D.RadiusY, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D), _0023_003DzN4MDZ_0024c_003D.EndPoint, flip: false);
					_0023_003DzN4MDZ_0024c_003D.Domain = ellipticalArc.Domain;
				}
			}
			else
			{
				if (_0023_003DzhJ0IytM_003D)
				{
					_0023_003DzcM_Q3U04H3Bt.Add(new EllipticalArc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Center, _0023_003DzN4MDZ_0024c_003D.RadiusX, _0023_003DzN4MDZ_0024c_003D.RadiusY, _0023_003DzN4MDZ_0024c_003D.StartPoint, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D), flip: false));
					return true;
				}
				if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
				{
					sketchEllipticalArc.EndPoint.SetPosition(_0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D));
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dze5G1YDQ3JaMH(sketchEllipticalArc.EndPoint);
					if (!_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchEllipticalArc.EndPoint, sketchEllipticalArc, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D)))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(_0023_003DzN4MDZ_0024c_003D), _0023_003Dzv_7IeQibaTXs);
					}
				}
				else
				{
					EllipticalArc ellipticalArc2 = new EllipticalArc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Center, _0023_003DzN4MDZ_0024c_003D.RadiusX, _0023_003DzN4MDZ_0024c_003D.RadiusY, _0023_003DzN4MDZ_0024c_003D.StartPoint, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D), flip: false);
					_0023_003DzN4MDZ_0024c_003D.Domain = ellipticalArc2.Domain;
				}
			}
			if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
			{
				Constraint[] constraints = ((SketchCurve)sketchItem).Constraints;
				foreach (Constraint constraint in constraints)
				{
					if (constraint is LengthConstraint)
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzHRlsxtgiikwy(constraint);
					}
				}
			}
		}
		else
		{
			EllipticalArc ellipticalArc3 = new EllipticalArc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Center, _0023_003DzN4MDZ_0024c_003D.RadiusX, _0023_003DzN4MDZ_0024c_003D.RadiusY, _0023_003DzN4MDZ_0024c_003D.StartPoint, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D), flip: false);
			EllipticalArc ellipticalArc4 = new EllipticalArc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Center, _0023_003DzN4MDZ_0024c_003D.RadiusX, _0023_003DzN4MDZ_0024c_003D.RadiusY, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D), _0023_003DzN4MDZ_0024c_003D.EndPoint, flip: false);
			if (_0023_003DzhJ0IytM_003D)
			{
				_0023_003DzcM_Q3U04H3Bt.Add(ellipticalArc3);
				_0023_003DzcM_Q3U04H3Bt.Add(ellipticalArc4);
				return true;
			}
			if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
			{
				_0023_003Dz_0024kXiR_IEww1B_0024OdzILtrI0s_003D(ellipticalArc3, sketchEllipticalArc, sketchEllipticalArc.StartPoint, ellipticalArc3.EndPoint);
				SketchEllipticalArc sketchEllipticalArc2 = ellipticalArc3._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchEllipticalArc;
				_0023_003Dz_0024kXiR_IEww1B_0024OdzILtrI0s_003D(ellipticalArc4, sketchEllipticalArc, ellipticalArc4.Center, ellipticalArc4.StartPoint, sketchEllipticalArc.EndPoint);
				SketchEllipticalArc sketchEllipticalArc3 = ellipticalArc4._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchEllipticalArc;
				if (_0023_003Dzv_7IeQibaTXs != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchEllipticalArc2.EndPoint, sketchEllipticalArc, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D)))
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(ellipticalArc3), _0023_003Dzv_7IeQibaTXs);
				}
				if (_0023_003DzNpfDgu2nb0Hr != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchEllipticalArc3.StartPoint, sketchEllipticalArc, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D)))
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(ellipticalArc4), _0023_003DzNpfDgu2nb0Hr);
				}
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintJoin(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.CenterPoint(ellipticalArc3), _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.CenterPoint(ellipticalArc4));
				Constraint[] _0023_003DzheZZscU_003D = _0023_003DzmOdhacA4GzOvAHQ1uw_003D_003D(_0023_003DzN4MDZ_0024c_003D);
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz1sKlGcomVW_00249(_0023_003DzN4MDZ_0024c_003D, _0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D: false);
				_0023_003DzQYOkUu7IqoiX(_0023_003DzheZZscU_003D, _0023_003DzN4MDZ_0024c_003D, ellipticalArc3, ellipticalArc4, sketchEllipticalArc2, sketchEllipticalArc3, sketchEllipticalArc);
			}
			else
			{
				_0023_003DzN4MDZ_0024c_003D.Domain = ellipticalArc3.Domain;
				ellipticalArc4.CopyAttributes(_0023_003DzN4MDZ_0024c_003D);
				_0023_003DzijSR7_0024YYLNcm.Add(ellipticalArc4);
			}
		}
		return true;
	}

	private bool _0023_003DzvCDDJ98zKm4t(Ellipse _0023_003DzWUywqIo_003D, double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D, Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		if (!_0023_003Dz6bFXLKOKlJWU(_0023_003DzWUywqIo_003D, _0023_003DzDSaZWik_003D, _0023_003DzsK_Xndk_003D))
		{
			return false;
		}
		SketchEllipse sketchEllipse = null;
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
		{
			sketchEllipse = ((SketchCurve)_0023_003DzWUywqIo_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()) as SketchEllipse;
		}
		EllipticalArc ellipticalArc = ((_0023_003DzWUywqIo_003D is EllipticalArc) ? ((EllipticalArc)_0023_003DzWUywqIo_003D) : new EllipticalArc(_0023_003DzWUywqIo_003D.Plane, _0023_003DzWUywqIo_003D.Center, _0023_003DzWUywqIo_003D.RadiusX, _0023_003DzWUywqIo_003D.RadiusY, Math.PI * 2.0));
		EllipticalArc ellipticalArc2 = new EllipticalArc(_0023_003DzWUywqIo_003D.Plane, _0023_003DzWUywqIo_003D.Center, _0023_003DzWUywqIo_003D.RadiusX, _0023_003DzWUywqIo_003D.RadiusY, _0023_003DzWUywqIo_003D.PointAt(_0023_003DzsK_Xndk_003D), _0023_003DzWUywqIo_003D.PointAt(_0023_003DzDSaZWik_003D), flip: false);
		ellipticalArc2.CopyAttributes(_0023_003DzWUywqIo_003D);
		if (_0023_003DzhJ0IytM_003D)
		{
			_0023_003DzcM_Q3U04H3Bt.Add(ellipticalArc2);
			return true;
		}
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
		{
			SketchEllipticalArc sketchEllipticalArc = _0023_003Dz_0024kXiR_IEww1B_0024OdzILtrI0s_003D(ellipticalArc, sketchEllipse, _0023_003DzWUywqIo_003D.PointAt(_0023_003DzsK_Xndk_003D), _0023_003DzWUywqIo_003D.PointAt(_0023_003DzDSaZWik_003D))._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchEllipticalArc;
			if (_0023_003Dzv_7IeQibaTXs != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchEllipticalArc.EndPoint, sketchEllipse, _0023_003DzWUywqIo_003D.PointAt(_0023_003DzDSaZWik_003D)))
			{
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(ellipticalArc), _0023_003Dzv_7IeQibaTXs);
			}
			if (_0023_003DzNpfDgu2nb0Hr != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchEllipticalArc.StartPoint, sketchEllipse, _0023_003DzWUywqIo_003D.PointAt(_0023_003DzsK_Xndk_003D)))
			{
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(ellipticalArc), _0023_003DzNpfDgu2nb0Hr);
			}
			Constraint[] constraints = _0023_003DzmOdhacA4GzOvAHQ1uw_003D_003D(_0023_003DzWUywqIo_003D);
			_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz1sKlGcomVW_00249(_0023_003DzWUywqIo_003D, _0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D: false);
			Utility.ReplaceOldConstraints(constraints, sketchEllipticalArc, sketchEllipse, out var cloned);
			Constraint[] array = cloned;
			foreach (Constraint _0023_003Dz9EdxXqI_003D in array)
			{
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzIrs5MDJ5nmrc(_0023_003Dz9EdxXqI_003D, _0023_003DzgdMixgk_003D.Entities);
			}
		}
		else
		{
			_0023_003DzgdMixgk_003D.Entities.Remove(_0023_003DzWUywqIo_003D);
			_0023_003DzgdMixgk_003D.Entities.Add(ellipticalArc2);
		}
		return true;
	}

	private static bool _0023_003Dz6bFXLKOKlJWU(ICurve _0023_003DzGuTH3G_Qr7AE, double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D)
	{
		bool num = Utility.Compare(1E-12, _0023_003DzDSaZWik_003D, _0023_003DzGuTH3G_Qr7AE.Domain.Low) == 0;
		bool flag = Utility.Compare(1E-12, _0023_003DzsK_Xndk_003D, _0023_003DzGuTH3G_Qr7AE.Domain.High) == 0;
		if (num && flag)
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzlrBg_0024xtJksjg6X6qYQ_003D_003D(Circle _0023_003Dzw6jQxH4k7cf_0024, double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D, Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		if (!_0023_003Dz6bFXLKOKlJWU(_0023_003Dzw6jQxH4k7cf_0024, _0023_003DzDSaZWik_003D, _0023_003DzsK_Xndk_003D))
		{
			return false;
		}
		SketchCircle sketchCircle = null;
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
		{
			sketchCircle = _0023_003Dzw6jQxH4k7cf_0024._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchCircle;
		}
		Arc _0023_003DzN4MDZ_0024c_003D = ((_0023_003Dzw6jQxH4k7cf_0024 is Arc) ? ((Arc)_0023_003Dzw6jQxH4k7cf_0024) : new Arc(_0023_003Dzw6jQxH4k7cf_0024.Plane, _0023_003Dzw6jQxH4k7cf_0024.Center, _0023_003Dzw6jQxH4k7cf_0024.Radius, Math.PI * 2.0));
		Arc arc = new Arc(_0023_003Dzw6jQxH4k7cf_0024.Plane, _0023_003Dzw6jQxH4k7cf_0024.Plane.Origin, _0023_003Dzw6jQxH4k7cf_0024.Radius, _0023_003Dzw6jQxH4k7cf_0024.PointAt(_0023_003DzsK_Xndk_003D), _0023_003Dzw6jQxH4k7cf_0024.PointAt(_0023_003DzDSaZWik_003D), flip: false);
		arc.CopyAttributes(_0023_003Dzw6jQxH4k7cf_0024);
		if (_0023_003DzhJ0IytM_003D)
		{
			_0023_003DzcM_Q3U04H3Bt.Add(arc);
			return true;
		}
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
		{
			Arc arc2 = _0023_003DzndMX0HC_m4LJ(_0023_003DzN4MDZ_0024c_003D, sketchCircle.Center, _0023_003Dzw6jQxH4k7cf_0024.PointAt(_0023_003DzsK_Xndk_003D), _0023_003Dzw6jQxH4k7cf_0024.PointAt(_0023_003DzDSaZWik_003D));
			SketchArc sketchArc = arc2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchArc;
			if (_0023_003Dzv_7IeQibaTXs != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchArc.EndPoint, sketchCircle, _0023_003Dzw6jQxH4k7cf_0024.PointAt(_0023_003DzDSaZWik_003D)))
			{
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(arc2), _0023_003Dzv_7IeQibaTXs);
			}
			if (_0023_003DzNpfDgu2nb0Hr != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchArc.StartPoint, sketchCircle, _0023_003Dzw6jQxH4k7cf_0024.PointAt(_0023_003DzsK_Xndk_003D)))
			{
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(arc2), _0023_003DzNpfDgu2nb0Hr);
			}
			Constraint[] constraints = _0023_003DzmOdhacA4GzOvAHQ1uw_003D_003D(_0023_003Dzw6jQxH4k7cf_0024);
			_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz1sKlGcomVW_00249(_0023_003Dzw6jQxH4k7cf_0024, _0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D: false);
			Utility.ReplaceOldConstraints(constraints, sketchArc, sketchCircle, out var cloned);
			Constraint[] array = cloned;
			foreach (Constraint _0023_003Dz9EdxXqI_003D in array)
			{
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzIrs5MDJ5nmrc(_0023_003Dz9EdxXqI_003D, _0023_003DzgdMixgk_003D.Entities);
			}
		}
		else
		{
			_0023_003DzgdMixgk_003D.Entities.Remove(_0023_003Dzw6jQxH4k7cf_0024);
			_0023_003DzgdMixgk_003D.Entities.Add(arc);
		}
		return true;
	}

	private bool _0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(SketchPoint _0023_003DzlY77YgY_003D, SketchCurve _0023_003DzdbWJotE_003D, Point3D _0023_003DzVrTLtysJK_0024OJ)
	{
		_0023_003DzamxzvRQygkvWesg0uvJZMCo_003D _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D2 = new _0023_003DzamxzvRQygkvWesg0uvJZMCo_003D();
		_0023_003DzamxzvRQygkvWesg0uvJZMCo_003D2._0023_003DzdbWJotE_003D = _0023_003DzdbWJotE_003D;
		_0023_003DzamxzvRQygkvWesg0uvJZMCo_003D2._0023_003DzVrTLtysJK_0024OJ = _0023_003DzVrTLtysJK_0024OJ;
		IEnumerable<Constraint> source = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz1cTWX1fK2A6e().Where(_0023_003DzamxzvRQygkvWesg0uvJZMCo_003D2._0023_003DzyTHrh13S2DSMl8wvSlTtRvS19WZN);
		if (source.Count() == 0)
		{
			return false;
		}
		PointOnConstraint pointOnConstraint = source.FirstOrDefault() as PointOnConstraint;
		devDept.Eyeshot.Entities.Point ent = (devDept.Eyeshot.Entities.Point)pointOnConstraint.Point._0023_003DzZ_ilKakl9sw5();
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzHRlsxtgiikwy(pointOnConstraint);
		_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintJoin(_0023_003DzlY77YgY_003D._0023_003DzZ_ilKakl9sw5() as devDept.Eyeshot.Entities.Point, ent);
		return true;
	}

	private bool _0023_003DzIbEvQLg_003D(Line _0023_003DzQ9zpGF0_003D, double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D, Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<Entity> _0023_003DzijSR7_0024YYLNcm, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		bool flag = Utility.Compare(1E-12, _0023_003DzDSaZWik_003D, _0023_003DzQ9zpGF0_003D.Domain.Low) == 0;
		bool flag2 = Utility.Compare(1E-12, _0023_003DzsK_Xndk_003D, _0023_003DzQ9zpGF0_003D.Domain.High) == 0;
		if (flag && flag2)
		{
			return false;
		}
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D() && _0023_003DzQ9zpGF0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() == null)
		{
			return false;
		}
		SketchLine sketchLine = _0023_003DzQ9zpGF0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine;
		if (flag || flag2)
		{
			if (flag)
			{
				if (_0023_003DzhJ0IytM_003D)
				{
					Line line = (Line)_0023_003DzQ9zpGF0_003D.Clone();
					line.StartPoint = _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzsK_Xndk_003D);
					_0023_003DzcM_Q3U04H3Bt.Add(line);
					return true;
				}
				if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
				{
					sketchLine.StartPoint.SetPosition(_0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzsK_Xndk_003D));
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dze5G1YDQ3JaMH(sketchLine.StartPoint);
					if (!_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchLine.StartPoint, sketchLine, _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzsK_Xndk_003D)))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(_0023_003DzQ9zpGF0_003D), _0023_003DzNpfDgu2nb0Hr);
					}
				}
				else
				{
					_0023_003DzQ9zpGF0_003D.StartPoint = _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzsK_Xndk_003D);
				}
			}
			else
			{
				if (_0023_003DzhJ0IytM_003D)
				{
					Line line2 = (Line)_0023_003DzQ9zpGF0_003D.Clone();
					line2.EndPoint = _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzDSaZWik_003D);
					_0023_003DzcM_Q3U04H3Bt.Add(line2);
					return true;
				}
				if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
				{
					sketchLine.EndPoint.SetPosition(_0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzDSaZWik_003D));
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dze5G1YDQ3JaMH(sketchLine.EndPoint);
					if (!_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchLine.EndPoint, sketchLine, _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzDSaZWik_003D)))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(_0023_003DzQ9zpGF0_003D), _0023_003Dzv_7IeQibaTXs);
					}
				}
				else
				{
					_0023_003DzQ9zpGF0_003D.EndPoint = _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzDSaZWik_003D);
				}
			}
			if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
			{
				Constraint[] constraints = sketchLine.Constraints;
				foreach (Constraint constraint in constraints)
				{
					if (constraint is LengthConstraint || constraint is PolygonConstraint)
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzHRlsxtgiikwy(constraint);
					}
				}
			}
		}
		else
		{
			Line line3 = (Line)_0023_003DzQ9zpGF0_003D.Clone();
			line3.EndPoint = _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzDSaZWik_003D);
			Line line4 = (Line)_0023_003DzQ9zpGF0_003D.Clone();
			line4.StartPoint = _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzsK_Xndk_003D);
			if (_0023_003DzhJ0IytM_003D)
			{
				_0023_003DzcM_Q3U04H3Bt.Add(line3);
				_0023_003DzcM_Q3U04H3Bt.Add(line4);
				return true;
			}
			if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
			{
				_0023_003DzBYn89lR_prFN(line3, sketchLine.StartPoint, line3.EndPoint);
				_0023_003DzBYn89lR_prFN(line4, line4.StartPoint, sketchLine.EndPoint);
				SketchLine sketchLine2 = line3._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine;
				SketchLine sketchLine3 = line4._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine;
				if (_0023_003Dzv_7IeQibaTXs != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchLine2.EndPoint, sketchLine, _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzDSaZWik_003D)))
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(line3), _0023_003Dzv_7IeQibaTXs);
				}
				if (_0023_003DzNpfDgu2nb0Hr != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchLine3.StartPoint, sketchLine, _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzsK_Xndk_003D)))
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(line4), _0023_003DzNpfDgu2nb0Hr);
				}
				Constraint[] constraints2 = _0023_003DzmOdhacA4GzOvAHQ1uw_003D_003D(_0023_003DzQ9zpGF0_003D);
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz1sKlGcomVW_00249(_0023_003DzQ9zpGF0_003D, _0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D: false);
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintCollinear(line3, line4);
				Utility.ReplaceOldConstraints(constraints2, sketchLine2, sketchLine, out var cloned);
				Constraint[] constraints = cloned;
				foreach (Constraint _0023_003Dz9EdxXqI_003D in constraints)
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzIrs5MDJ5nmrc(_0023_003Dz9EdxXqI_003D, _0023_003DzgdMixgk_003D.Entities);
				}
			}
			else
			{
				line4.CopyAttributes(_0023_003DzQ9zpGF0_003D);
				_0023_003DzijSR7_0024YYLNcm.Add(line4);
				_0023_003DzQ9zpGF0_003D.EndPoint = _0023_003DzQ9zpGF0_003D.PointAt(_0023_003DzDSaZWik_003D);
			}
		}
		return true;
	}

	private void _0023_003DzQYOkUu7IqoiX(Constraint[] _0023_003DzheZZscU_003D, ICurve _0023_003Dz8fpRyMu9aKjE, ICurve _0023_003Dz8EhW_0024omtFk2M, ICurve _0023_003DzWB5w2Msi2ASb, SketchCurve _0023_003DzEem_0024IGL9lwmVH8tdfA_003D_003D, SketchCurve _0023_003Dzq2pyCsb14uJVISOJVg_003D_003D, SketchCurve _0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D)
	{
		foreach (Constraint constraint in _0023_003DzheZZscU_003D)
		{
			if (constraint is LengthConstraint)
			{
				continue;
			}
			Constraint constraint2 = Utility.CloneConstraintAtRightParameter(constraint, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz8EhW_0024omtFk2M, _0023_003DzWB5w2Msi2ASb, _0023_003DzEem_0024IGL9lwmVH8tdfA_003D_003D, _0023_003Dzq2pyCsb14uJVISOJVg_003D_003D, _0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D);
			if (constraint2 != null)
			{
				if (!_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.IsValid(constraint2))
				{
					constraint2.Destroy();
				}
				else
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzIrs5MDJ5nmrc(constraint2, _0023_003DzgdMixgk_003D.Entities);
				}
			}
		}
	}

	private Constraint[] _0023_003DzmOdhacA4GzOvAHQ1uw_003D_003D(Entity _0023_003Dz9j7EUB0_003D)
	{
		if (!_0023_003Dz9j7EUB0_003D.IsSketchEntity())
		{
			return null;
		}
		return ((SketchCurve)_0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Constraints;
	}

	private bool _0023_003DzgSEyNepBTjf8(Arc _0023_003DzN4MDZ_0024c_003D, double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D, Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<Entity> _0023_003DzijSR7_0024YYLNcm, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		bool flag = Utility.Compare(1E-12, _0023_003DzDSaZWik_003D, _0023_003DzN4MDZ_0024c_003D.Domain.Low) == 0;
		bool flag2 = Utility.Compare(1E-12, _0023_003DzsK_Xndk_003D, _0023_003DzN4MDZ_0024c_003D.Domain.High) == 0;
		if (flag && flag2)
		{
			return false;
		}
		SketchCurve sketchCurve = null;
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
		{
			sketchCurve = (SketchCurve)_0023_003DzN4MDZ_0024c_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
			if (sketchCurve == null)
			{
				return false;
			}
		}
		SketchArc sketchArc = sketchCurve as SketchArc;
		if (flag || flag2)
		{
			if (flag)
			{
				if (_0023_003DzhJ0IytM_003D)
				{
					_0023_003DzcM_Q3U04H3Bt.Add(new Arc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Plane.Origin, _0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D), _0023_003DzN4MDZ_0024c_003D.EndPoint, flip: false));
					return true;
				}
				if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
				{
					sketchArc.StartPoint.SetPosition(_0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D));
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dze5G1YDQ3JaMH(sketchArc.StartPoint);
					if (!_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchArc.StartPoint, sketchArc, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D)))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(_0023_003DzN4MDZ_0024c_003D), _0023_003DzNpfDgu2nb0Hr);
					}
				}
				else
				{
					Arc arc = new Arc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Plane.Origin, _0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D), _0023_003DzN4MDZ_0024c_003D.EndPoint, flip: false);
					_0023_003DzN4MDZ_0024c_003D.Domain = arc.Domain;
				}
			}
			else
			{
				if (_0023_003DzhJ0IytM_003D)
				{
					_0023_003DzcM_Q3U04H3Bt.Add(new Arc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Plane.Origin, _0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzN4MDZ_0024c_003D.StartPoint, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D), flip: false));
					return true;
				}
				if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
				{
					sketchArc.EndPoint.SetPosition(_0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D));
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dze5G1YDQ3JaMH(sketchArc.EndPoint);
					if (!_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchArc.EndPoint, sketchArc, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D)))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(_0023_003DzN4MDZ_0024c_003D), _0023_003Dzv_7IeQibaTXs);
					}
				}
				else
				{
					Arc arc2 = new Arc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Plane.Origin, _0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzN4MDZ_0024c_003D.StartPoint, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D), flip: false);
					_0023_003DzN4MDZ_0024c_003D.Domain = arc2.Domain;
				}
			}
			if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
			{
				Constraint[] constraints = sketchCurve.Constraints;
				foreach (Constraint constraint in constraints)
				{
					if (constraint is LengthConstraint)
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzHRlsxtgiikwy(constraint);
					}
				}
			}
		}
		else
		{
			Arc arc3 = new Arc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Plane.Origin, _0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzN4MDZ_0024c_003D.StartPoint, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D), flip: false);
			Arc arc4 = new Arc(_0023_003DzN4MDZ_0024c_003D.Plane, _0023_003DzN4MDZ_0024c_003D.Plane.Origin, _0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D), _0023_003DzN4MDZ_0024c_003D.EndPoint, flip: false);
			if (_0023_003DzhJ0IytM_003D)
			{
				_0023_003DzcM_Q3U04H3Bt.Add(arc3);
				_0023_003DzcM_Q3U04H3Bt.Add(arc4);
				return true;
			}
			if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
			{
				_0023_003DzndMX0HC_m4LJ(arc3, sketchArc.Center, sketchArc.StartPoint, arc3.EndPoint);
				SketchArc sketchArc2 = arc3._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchArc;
				_0023_003DzndMX0HC_m4LJ(arc4, arc4.Center, arc4.StartPoint, sketchArc.EndPoint);
				SketchArc sketchArc3 = arc4._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchArc;
				if (_0023_003Dzv_7IeQibaTXs != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchArc2.EndPoint, sketchArc, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzDSaZWik_003D)))
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(arc3), _0023_003Dzv_7IeQibaTXs);
				}
				if (_0023_003DzNpfDgu2nb0Hr != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchArc3.StartPoint, sketchArc, _0023_003DzN4MDZ_0024c_003D.PointAt(_0023_003DzsK_Xndk_003D)))
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(arc4), _0023_003DzNpfDgu2nb0Hr);
				}
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintJoin(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.CenterPoint(arc3), _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.CenterPoint(arc4));
				Constraint[] _0023_003DzheZZscU_003D = _0023_003DzmOdhacA4GzOvAHQ1uw_003D_003D(_0023_003DzN4MDZ_0024c_003D);
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz1sKlGcomVW_00249(_0023_003DzN4MDZ_0024c_003D, _0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D: false);
				_0023_003DzQYOkUu7IqoiX(_0023_003DzheZZscU_003D, _0023_003DzN4MDZ_0024c_003D, arc3, arc4, sketchArc2, sketchArc3, sketchArc);
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintEqual(arc3, arc4, eqRadius: true);
			}
			else
			{
				_0023_003DzN4MDZ_0024c_003D.Domain = arc3.Domain;
				arc4.CopyAttributes(_0023_003DzN4MDZ_0024c_003D);
				_0023_003DzijSR7_0024YYLNcm.Add(arc4);
			}
		}
		return true;
	}

	public bool _0023_003Dz6PsRlFc_003D(System.Drawing.Point _0023_003DzFNDApuVLTtJd, List<Entity> _0023_003DzijSR7_0024YYLNcm, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		SelectedItem itemUnderMouseCursor = ((IWorkspaceInternal)_0023_003DzgdMixgk_003D).GetItemUnderMouseCursor(_0023_003DzFNDApuVLTtJd);
		if (itemUnderMouseCursor == null || itemUnderMouseCursor.Item == null)
		{
			return false;
		}
		Entity entity = itemUnderMouseCursor.Item as Entity;
		if (!(entity is ICurve _0023_003DzmCM_0024s12le28l) || entity is devDept.Eyeshot.Entities.Point)
		{
			return false;
		}
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
		{
			if (!entity.IsSketchEntity() || entity.IsConstruction())
			{
				return false;
			}
			if (entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() == null)
			{
				return false;
			}
			if (entity.IsFixed())
			{
				return false;
			}
		}
		if (!_0023_003DzgdMixgk_003D.ScreenToPlane(_0023_003DzFNDApuVLTtJd, _0023_003DznksI_0024l2L21KB, out var intPoint))
		{
			return false;
		}
		if (_0023_003DzgdMixgk_003D.CurrentTransformation != null)
		{
			intPoint.TransformBy(((IWorkspaceInternal)_0023_003DzgdMixgk_003D).CurrentTransformationInverse);
		}
		Dictionary<Entity, Point3D[]> _0023_003DzeQRO6RKgCT8c = new Dictionary<Entity, Point3D[]>();
		return _0023_003Dz6PsRlFc_003D(_0023_003DzmCM_0024s12le28l, intPoint, _0023_003DzeQRO6RKgCT8c, _0023_003DzijSR7_0024YYLNcm, _0023_003DzcM_Q3U04H3Bt);
	}

	public bool _0023_003Dz6PsRlFc_003D(Point2D _0023_003DzpdeSbFA_003D, List<Entity> _0023_003DzijSR7_0024YYLNcm)
	{
		Point3D point = _0023_003DznksI_0024l2L21KB.PointAt(_0023_003DzpdeSbFA_003D);
		Point3D point3D = _0023_003DzgdMixgk_003D.ActiveViewport.WorldToScreen(point);
		System.Drawing.Point _0023_003DzFNDApuVLTtJd = new System.Drawing.Point(Convert.ToInt32(point3D.X), _0023_003DzgdMixgk_003D.ActiveViewport.Size.Height - Convert.ToInt32(point3D.Y));
		return _0023_003Dz6PsRlFc_003D(_0023_003DzFNDApuVLTtJd, _0023_003DzijSR7_0024YYLNcm, new List<Entity>());
	}

	private bool _0023_003Dz6PsRlFc_003D(ICurve _0023_003DzmCM_0024s12le28l, Point3D _0023_003Dzvyg7cd9TjwQh, Dictionary<Entity, Point3D[]> _0023_003DzeQRO6RKgCT8c, List<Entity> _0023_003DzijSR7_0024YYLNcm, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		Entity _0023_003Dz9j7EUB0_003D = (Entity)_0023_003DzmCM_0024s12le28l;
		_0023_003DzmCM_0024s12le28l.ClosestPointTo(_0023_003Dzvyg7cd9TjwQh, out var t);
		_0023_003DztQWLWdGPMiET3w3ST7foPkBT9euH(_0023_003DzeQRO6RKgCT8c, _0023_003DzmCM_0024s12le28l);
		if (_0023_003DzeQRO6RKgCT8c.Count == 0)
		{
			return false;
		}
		List<Tuple<double, Point3D, Entity>> list = new List<Tuple<double, Point3D, Entity>>(_0023_003DzeQRO6RKgCT8c.Count + 2);
		_0023_003DzjsEohgXo48WH(list, _0023_003DzmCM_0024s12le28l, _0023_003DzeQRO6RKgCT8c);
		double item = list.First().Item1;
		Entity item2 = list.First().Item3;
		double item3 = list.Last().Item1;
		Entity item4 = list.Last().Item3;
		Entity _0023_003Dzv_7IeQibaTXs = null;
		Entity _0023_003DzNpfDgu2nb0Hr = null;
		Point3D item5 = list.First().Item2;
		Point3D item6 = list.Last().Item2;
		bool flag = false;
		for (int i = 0; i < list.Count - 1; i++)
		{
			if (list[i].Item1 < t && list[i + 1].Item1 > t)
			{
				flag = true;
				item = list[i].Item1;
				item5 = list[i].Item2;
				_0023_003Dzv_7IeQibaTXs = list[i].Item3;
				item3 = list[i + 1].Item1;
				item6 = list[i + 1].Item2;
				_0023_003DzNpfDgu2nb0Hr = list[i + 1].Item3;
				break;
			}
		}
		if (!flag)
		{
			return _0023_003Dz68bspubRg5a7(_0023_003Dz9j7EUB0_003D, item3, item, item5, item6, item4, item2, _0023_003DzijSR7_0024YYLNcm, _0023_003DzcM_Q3U04H3Bt);
		}
		return _0023_003Dz68bspubRg5a7(_0023_003Dz9j7EUB0_003D, item, item3, item5, item6, _0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzijSR7_0024YYLNcm, _0023_003DzcM_Q3U04H3Bt);
	}

	private bool _0023_003Dz68bspubRg5a7(Entity _0023_003Dz9j7EUB0_003D, double _0023_003DzSOVRV5I_003D, double _0023_003Dzjy5MYbs_003D, Point3D _0023_003DzrNyhm6g_003D, Point3D _0023_003DztY_anuo_003D, Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<Entity> _0023_003DzijSR7_0024YYLNcm, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		bool flag = ((!(_0023_003Dz9j7EUB0_003D is Arc _0023_003DzN4MDZ_0024c_003D)) ? ((!(_0023_003Dz9j7EUB0_003D is Circle _0023_003Dzw6jQxH4k7cf_0024)) ? ((!(_0023_003Dz9j7EUB0_003D is Line _0023_003DzQ9zpGF0_003D)) ? ((!(_0023_003Dz9j7EUB0_003D is EllipticalArc _0023_003DzN4MDZ_0024c_003D2)) ? ((!(_0023_003Dz9j7EUB0_003D is Ellipse _0023_003DzWUywqIo_003D)) ? ((!(_0023_003Dz9j7EUB0_003D is Curve _0023_003Dz8fpRyMu9aKjE)) ? _0023_003DzjSexx6BgBjUv((ICurve)_0023_003Dz9j7EUB0_003D, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003DzijSR7_0024YYLNcm, _0023_003DzcM_Q3U04H3Bt) : _0023_003DzY8ng6LRBZYbX(_0023_003Dz8fpRyMu9aKjE, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzijSR7_0024YYLNcm, _0023_003DzcM_Q3U04H3Bt)) : _0023_003DzvCDDJ98zKm4t(_0023_003DzWUywqIo_003D, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzcM_Q3U04H3Bt)) : _0023_003DzbUyiDLZofvTlxALE7F_0024DGIE_003D(_0023_003DzN4MDZ_0024c_003D2, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzijSR7_0024YYLNcm, _0023_003DzcM_Q3U04H3Bt)) : _0023_003DzIbEvQLg_003D(_0023_003DzQ9zpGF0_003D, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzijSR7_0024YYLNcm, _0023_003DzcM_Q3U04H3Bt)) : _0023_003DzlrBg_0024xtJksjg6X6qYQ_003D_003D(_0023_003Dzw6jQxH4k7cf_0024, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzcM_Q3U04H3Bt)) : _0023_003DzgSEyNepBTjf8(_0023_003DzN4MDZ_0024c_003D, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzijSR7_0024YYLNcm, _0023_003DzcM_Q3U04H3Bt));
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D() && flag && !_0023_003DzhJ0IytM_003D)
		{
			_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.UpdateAndInvalidate();
		}
		return flag;
	}

	private bool _0023_003DzY8ng6LRBZYbX(Curve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D, Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<Entity> _0023_003DzijSR7_0024YYLNcm, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		bool flag = Utility.Compare(1E-12, _0023_003DzDSaZWik_003D, _0023_003Dz8fpRyMu9aKjE.Domain.Low) == 0;
		bool flag2 = Utility.Compare(1E-12, _0023_003DzsK_Xndk_003D, _0023_003Dz8fpRyMu9aKjE.Domain.High) == 0;
		if (flag && flag2)
		{
			return false;
		}
		SketchSpline sketchSpline = null;
		if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
		{
			sketchSpline = _0023_003Dz8fpRyMu9aKjE._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchSpline;
		}
		Curve curve = _0023_003Dz8fpRyMu9aKjE.Clone() as Curve;
		if (flag || flag2)
		{
			if (flag)
			{
				curve.TrimAt(_0023_003DzsK_Xndk_003D, flipSide: true);
				if (_0023_003DzhJ0IytM_003D)
				{
					_0023_003DzcM_Q3U04H3Bt.Add(curve);
					return true;
				}
				if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
				{
					foreach (Entity item in _0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz485JMIMmTVuuyF12gg_003D_003D(_0023_003Dz8fpRyMu9aKjE))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dzr0gJ7b7EF0Dt(item, _0023_003Dz8fpRyMu9aKjE);
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.DeleteEntity(item);
					}
					Constraint[] constraints = sketchSpline.StartPoint.Constraints;
					foreach (Constraint _0023_003DzV_0024oduG8_003D in constraints)
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzHRlsxtgiikwy(_0023_003DzV_0024oduG8_003D);
					}
					_0023_003DzB0YYx_Eb1830q9DV0Q_003D_003D(sketchSpline, 0.0);
					SketchPoint[] _0023_003DzTkPhA8X_2C3n = sketchSpline.Vertices.ToArray();
					if (!_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchSpline.StartPoint, sketchSpline, _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003DzsK_Xndk_003D)))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(_0023_003Dz8fpRyMu9aKjE), _0023_003DzNpfDgu2nb0Hr);
					}
					for (int j = 0; j < curve.ControlPoints.Length; j++)
					{
						sketchSpline.ControlPoints[j].SetPosition(curve.ControlPoints[j].Euclid);
					}
					_0023_003Dz8fpRyMu9aKjE.KnotVector = curve.KnotVector;
					_0023_003DzzGRwZQa8c_4WaLYuUA_003D_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003DzTkPhA8X_2C3n);
				}
				else
				{
					_0023_003Dz8fpRyMu9aKjE.TrimAt(_0023_003DzsK_Xndk_003D, flipSide: true);
				}
			}
			else
			{
				curve.TrimAt(_0023_003DzDSaZWik_003D, flipSide: false);
				if (_0023_003DzhJ0IytM_003D)
				{
					_0023_003DzcM_Q3U04H3Bt.Add(curve);
					return true;
				}
				if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
				{
					foreach (Entity item2 in _0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz485JMIMmTVuuyF12gg_003D_003D(_0023_003Dz8fpRyMu9aKjE))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dzr0gJ7b7EF0Dt(item2, _0023_003Dz8fpRyMu9aKjE);
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.DeleteEntity(item2);
					}
					Constraint[] constraints = sketchSpline.EndPoint.Constraints;
					foreach (Constraint _0023_003DzV_0024oduG8_003D2 in constraints)
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzHRlsxtgiikwy(_0023_003DzV_0024oduG8_003D2);
					}
					_0023_003DzB0YYx_Eb1830q9DV0Q_003D_003D(sketchSpline, 1.0);
					SketchPoint[] _0023_003DzTkPhA8X_2C3n2 = sketchSpline.Vertices.ToArray();
					if (!_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchSpline.EndPoint, sketchSpline, _0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003DzDSaZWik_003D)))
					{
						_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(_0023_003Dz8fpRyMu9aKjE), _0023_003Dzv_7IeQibaTXs);
					}
					for (int k = 0; k < curve.ControlPoints.Length; k++)
					{
						sketchSpline.ControlPoints[k].SetPosition(curve.ControlPoints[k].Euclid);
					}
					_0023_003Dz8fpRyMu9aKjE.KnotVector = curve.KnotVector;
					_0023_003DzzGRwZQa8c_4WaLYuUA_003D_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003DzTkPhA8X_2C3n2);
				}
				else
				{
					_0023_003Dz8fpRyMu9aKjE.TrimAt(_0023_003DzDSaZWik_003D, flipSide: false);
				}
			}
		}
		else
		{
			Curve curve2 = _0023_003Dz8fpRyMu9aKjE.Clone() as Curve;
			curve.TrimAt(_0023_003DzsK_Xndk_003D, flipSide: true);
			curve2.TrimAt(_0023_003DzDSaZWik_003D, flipSide: false);
			if (_0023_003DzhJ0IytM_003D)
			{
				_0023_003DzcM_Q3U04H3Bt.Add(curve);
				_0023_003DzcM_Q3U04H3Bt.Add(curve2);
				return true;
			}
			if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
			{
				Curve curve3 = curve2;
				Curve curve4 = curve;
				_0023_003DzQOwqB_f6J_0024S_(curve3, sketchSpline.StartPoint, _0023_003DzAqOpw0w_003D: true);
				_0023_003DzQOwqB_f6J_0024S_(curve4, sketchSpline.EndPoint, _0023_003DzAqOpw0w_003D: false);
				SketchSpline sketchSpline2 = curve3._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchSpline;
				SketchSpline sketchSpline3 = curve4._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchSpline;
				if (_0023_003Dzv_7IeQibaTXs != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchSpline2.EndPoint, sketchSpline, sketchSpline.PointAt(_0023_003DzDSaZWik_003D)))
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(curve3), _0023_003Dzv_7IeQibaTXs);
				}
				if (_0023_003DzNpfDgu2nb0Hr != null && !_0023_003DzdsYVbrpnWa_LjF79xA_003D_003D(sketchSpline3.StartPoint, sketchSpline, sketchSpline.PointAt(_0023_003DzsK_Xndk_003D)))
				{
					_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintPointOn(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(curve4), _0023_003DzNpfDgu2nb0Hr);
				}
				_0023_003DzzGRwZQa8c_4WaLYuUA_003D_003D(curve3, sketchSpline2.Vertices.ToArray());
				_0023_003DzzGRwZQa8c_4WaLYuUA_003D_003D(curve4, sketchSpline3.Vertices.ToArray());
				Constraint[] _0023_003DzheZZscU_003D = _0023_003DzmOdhacA4GzOvAHQ1uw_003D_003D(_0023_003Dz8fpRyMu9aKjE);
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzrSUfOY0HOz5O(sketchSpline.ControlPoints[1]._0023_003DzZ_ilKakl9sw5());
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzrSUfOY0HOz5O(sketchSpline.ControlPoints[2]._0023_003DzZ_ilKakl9sw5());
				_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz1sKlGcomVW_00249(_0023_003Dz8fpRyMu9aKjE, _0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D: false);
				_0023_003DzQYOkUu7IqoiX(_0023_003DzheZZscU_003D, _0023_003Dz8fpRyMu9aKjE, curve3, curve4, sketchSpline2, sketchSpline3, sketchSpline);
			}
			else
			{
				_0023_003Dz8fpRyMu9aKjE.TrimAt(_0023_003DzsK_Xndk_003D, flipSide: true);
				curve2.CopyAttributes(_0023_003Dz8fpRyMu9aKjE);
				_0023_003DzijSR7_0024YYLNcm.Add(curve2);
			}
		}
		return true;
	}

	private bool _0023_003DzjSexx6BgBjUv(ICurve _0023_003DzEZ_0024X0WU_003D, double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D, List<Entity> _0023_003DzijSR7_0024YYLNcm, List<Entity> _0023_003DzcM_Q3U04H3Bt)
	{
		bool flag = Utility.Compare(1E-12, _0023_003DzDSaZWik_003D, _0023_003DzEZ_0024X0WU_003D.Domain.Low) == 0;
		bool flag2 = Utility.Compare(1E-12, _0023_003DzsK_Xndk_003D, _0023_003DzEZ_0024X0WU_003D.Domain.High) == 0;
		if (flag && flag2)
		{
			return false;
		}
		ICurve curve = _0023_003DzEZ_0024X0WU_003D.Clone() as ICurve;
		if (flag || flag2)
		{
			if (flag)
			{
				curve.TrimAt(_0023_003DzsK_Xndk_003D, flipSide: true);
				if (_0023_003DzhJ0IytM_003D)
				{
					_0023_003DzcM_Q3U04H3Bt.Add((Entity)curve);
					return true;
				}
				_0023_003DzEZ_0024X0WU_003D.TrimAt(_0023_003DzsK_Xndk_003D, flipSide: true);
			}
			else
			{
				curve.TrimAt(_0023_003DzDSaZWik_003D, flipSide: false);
				if (_0023_003DzhJ0IytM_003D)
				{
					_0023_003DzcM_Q3U04H3Bt.Add((Entity)curve);
					return true;
				}
				_0023_003DzEZ_0024X0WU_003D.TrimAt(_0023_003DzDSaZWik_003D, flipSide: false);
			}
		}
		else
		{
			ICurve curve2 = _0023_003DzEZ_0024X0WU_003D.Clone() as ICurve;
			curve.TrimAt(_0023_003DzsK_Xndk_003D, flipSide: true);
			curve2.TrimAt(_0023_003DzDSaZWik_003D, flipSide: false);
			if (_0023_003DzhJ0IytM_003D)
			{
				_0023_003DzcM_Q3U04H3Bt.Add((Entity)curve);
				_0023_003DzcM_Q3U04H3Bt.Add((Entity)curve2);
				return true;
			}
			_0023_003DzEZ_0024X0WU_003D.TrimAt(_0023_003DzsK_Xndk_003D, flipSide: true);
			((Entity)curve2).CopyAttributes((Entity)_0023_003DzEZ_0024X0WU_003D);
			_0023_003DzijSR7_0024YYLNcm.Add((Entity)curve2);
		}
		return true;
	}

	private void _0023_003DzB0YYx_Eb1830q9DV0Q_003D_003D(SketchSpline _0023_003DznYbCLDUxnKSb, double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D _0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D2 = new _0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D();
		_0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D2._0023_003DznYbCLDUxnKSb = _0023_003DznYbCLDUxnKSb;
		_0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D2._0023_003DzPzO_0024GUk_003D = _0023_003DzPzO_0024GUk_003D;
		Constraint constraint = _0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D2._0023_003DznYbCLDUxnKSb.Constraints.Where(_0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D2._0023_003DzjxD0Q8eqkxdM4UJoqhf47BQ_003D).FirstOrDefault();
		Constraint constraint2 = _0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D2._0023_003DznYbCLDUxnKSb.Constraints.Where(_0023_003DzNT3pVhQxHT66v9dbLx86wZ0_003D2._0023_003Dzurs3GBmq8RzhnA2lsCG94Ao_003D).FirstOrDefault();
		if (constraint != null)
		{
			_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzHRlsxtgiikwy(constraint);
		}
		if (constraint2 != null)
		{
			_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003DzHRlsxtgiikwy(constraint2);
		}
	}

	private void _0023_003DzzGRwZQa8c_4WaLYuUA_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE, SketchPoint[] _0023_003DzTkPhA8X_2C3n)
	{
		for (int i = 0; i < _0023_003DzTkPhA8X_2C3n.Length - 1; i += 2)
		{
			Line line = _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddLine(_0023_003DzTkPhA8X_2C3n[i].PlanePosition, _0023_003DzTkPhA8X_2C3n[i + 1].PlanePosition);
			_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintJoin(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.StartPoint(line), _0023_003DzTkPhA8X_2C3n[i]._0023_003DzZ_ilKakl9sw5());
			_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.AddConstraintJoin(_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.EndPoint(line), _0023_003DzTkPhA8X_2C3n[i + 1]._0023_003DzZ_ilKakl9sw5());
			_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.SetConstruction(line, status: true);
			_0023_003Dzx1UORhPlCefSChIbXA_003D_003D._0023_003Dz5c_0024UHl9YMBzg(line, _0023_003Dz8fpRyMu9aKjE);
		}
	}

	private void _0023_003DzjsEohgXo48WH(List<Tuple<double, Point3D, Entity>> _0023_003DzvZypkKBOBwwv, ICurve _0023_003DzmCM_0024s12le28l, Dictionary<Entity, Point3D[]> _0023_003DzeQRO6RKgCT8c)
	{
		if (!_0023_003DzmCM_0024s12le28l.IsClosed)
		{
			_0023_003DzvZypkKBOBwwv.Add(new Tuple<double, Point3D, Entity>(_0023_003DzmCM_0024s12le28l.Domain.Low, _0023_003DzmCM_0024s12le28l.StartPoint, null));
		}
		foreach (KeyValuePair<Entity, Point3D[]> item in _0023_003DzeQRO6RKgCT8c)
		{
			Point3D[] value = item.Value;
			foreach (Point3D point3D in value)
			{
				double t = 0.0;
				if (point3D is InterPoint interPoint)
				{
					t = interPoint.u;
				}
				else
				{
					_0023_003DzmCM_0024s12le28l.ClosestPointTo(point3D, out t);
				}
				_0023_003DzvZypkKBOBwwv.Add(new Tuple<double, Point3D, Entity>(t, point3D, item.Key));
			}
		}
		if (!_0023_003DzmCM_0024s12le28l.IsClosed)
		{
			_0023_003DzvZypkKBOBwwv.Add(new Tuple<double, Point3D, Entity>(_0023_003DzmCM_0024s12le28l.Domain.High, _0023_003DzmCM_0024s12le28l.EndPoint, null));
		}
		if (!_0023_003DzasV9syYHZmlHt85CnQ_003D_003D() && _0023_003DzmCM_0024s12le28l.IsClosed && !(_0023_003DzmCM_0024s12le28l is Circle) && !(_0023_003DzmCM_0024s12le28l is Ellipse))
		{
			_0023_003DzvZypkKBOBwwv.Add(new Tuple<double, Point3D, Entity>(_0023_003DzmCM_0024s12le28l.Domain.High, _0023_003DzmCM_0024s12le28l.EndPoint, null));
			_0023_003DzvZypkKBOBwwv.Add(new Tuple<double, Point3D, Entity>(_0023_003DzmCM_0024s12le28l.Domain.Low, _0023_003DzmCM_0024s12le28l.StartPoint, null));
		}
		_0023_003DzvZypkKBOBwwv.Sort(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzyr9VQy8tf1IWi8b6yejYXj8_003D);
	}

	private void _0023_003DztQWLWdGPMiET3w3ST7foPkBT9euH(Dictionary<Entity, Point3D[]> _0023_003DzeQRO6RKgCT8c, ICurve _0023_003DzmCM_0024s12le28l)
	{
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2 = new _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D();
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzmCM_0024s12le28l = _0023_003DzmCM_0024s12le28l;
		_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzXxLAHrF4RIfc = (SketchCurve)((Entity)_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzmCM_0024s12le28l)._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		foreach (Entity item in _0023_003DzasV9syYHZmlHt85CnQ_003D_003D() ? _0023_003Dzx1UORhPlCefSChIbXA_003D_003D.CurveList.Cast<Entity>().ToList() : _0023_003DzgdMixgk_003D.Entities.ToList())
		{
			if (!(item is ICurve curve) || curve == _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzmCM_0024s12le28l || curve is devDept.Eyeshot.Entities.Point || (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D() && (!item.IsSketchEntity() || item.IsConstruction())) || !item.IsVisible(_0023_003DzgdMixgk_003D.Layers))
			{
				continue;
			}
			List<Point3D> list = new List<Point3D>();
			if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D())
			{
				_0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D CS_0024_003C_003E8__locals6 = new _0023_003Dz1gwfMQKtzjb8ls26lmShgss_003D();
				CS_0024_003C_003E8__locals6._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2;
				CS_0024_003C_003E8__locals6._0023_003Dz3y08FkIciEqrAWxFLQ_003D_003D = item._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as ISketchCurve;
				if (CS_0024_003C_003E8__locals6._0023_003Dz3y08FkIciEqrAWxFLQ_003D_003D != null)
				{
					if (_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.Constraints.Any((Constraint _0023_003DzV_0024oduG8_003D) => _0023_003DzV_0024oduG8_003D is PointOnConstraint pointOnConstraint && pointOnConstraint.Point == CS_0024_003C_003E8__locals6._0023_003Dz3y08FkIciEqrAWxFLQ_003D_003D.StartPoint && pointOnConstraint.Curve == CS_0024_003C_003E8__locals6._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzXxLAHrF4RIfc))
					{
						list.Add(curve.StartPoint);
					}
					if (_0023_003Dzx1UORhPlCefSChIbXA_003D_003D.Sketch.Constraints.Any(CS_0024_003C_003E8__locals6._0023_003DzBF3lBkFmW6iGNh_kVb44Ps1FMxyfhjI9Ig_003D_003D))
					{
						list.Add(curve.EndPoint);
					}
				}
			}
			Point3D[] array = _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzmCM_0024s12le28l.IntersectWith(curve);
			if (_0023_003DzasV9syYHZmlHt85CnQ_003D_003D() && _0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzXxLAHrF4RIfc is ISketchCurve)
			{
				array = array.Where(_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzPXiU268fi8OKxAieY2_1AYAbir9tJSJSjw_003D_003D).ToArray();
			}
			if (array.Length != 0)
			{
				Point3D[] array2 = array;
				foreach (Point3D point3D in array2)
				{
					if (point3D.IsValid() && (!_0023_003DzasV9syYHZmlHt85CnQ_003D_003D() || !(_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzXxLAHrF4RIfc is ISketchCurve) || (!point3D.Equals(_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzmCM_0024s12le28l.StartPoint) && !point3D.Equals(_0023_003Dzg0KSNREqCDRek1sqN70ygG8_003D2._0023_003DzmCM_0024s12le28l.EndPoint))))
					{
						list.Add(point3D);
					}
				}
			}
			if (list.Count > 0)
			{
				_0023_003DzeQRO6RKgCT8c.Add(item, list.ToArray());
			}
		}
	}
}
