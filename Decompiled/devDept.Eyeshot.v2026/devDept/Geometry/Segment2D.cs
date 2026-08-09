using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class Segment2D : ICloneable
{
	public Point2D P0;

	public Point2D P1;

	public double LengthSquared
	{
		get
		{
			double num = P1.X - P0.X;
			double num2 = P1.Y - P0.Y;
			return num * num + num2 * num2;
		}
	}

	public Point2D MidPoint => Point2D.MidPoint(P0, P1);

	public double Length => Point2D.Distance(P0, P1);

	public Vector2D Normal => new Vector2D(0.0 - (P1.Y - P0.Y), P1.X - P0.X);

	public bool IsPoint
	{
		get
		{
			if (P0 != P1)
			{
				return false;
			}
			return true;
		}
	}

	public Segment2D()
	{
		P0 = new Point2D(0.0, 0.0);
		P1 = new Point2D(0.0, 0.0);
	}

	public Segment2D(Point2D p0, Point2D p1)
	{
		P0 = p0;
		P1 = p1;
	}

	public Segment2D(Point p0, Point p1)
	{
		P0 = new Point2D(p0.X, p0.Y);
		P1 = new Point2D(p1.X, p1.Y);
	}

	public Segment2D(double x0, double y0, double x1, double y1)
	{
		P0 = new Point2D(x0, y0);
		P1 = new Point2D(x1, y1);
	}

	protected Segment2D(Segment2D another)
	{
		P0 = (Point2D)another.P0.Clone();
		P1 = (Point2D)another.P1.Clone();
	}

	protected Segment2D(SerializationInfo info, StreamingContext context)
	{
		P0 = (Point2D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659979), typeof(Point2D));
		P1 = (Point2D)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659702), typeof(Point2D));
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659979), P0);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659702), P1);
	}

	public virtual object Clone()
	{
		return new Segment2D(this);
	}

	public static implicit operator Vector2D(Segment2D s)
	{
		return new Vector2D(s.P1.X - s.P0.X, s.P1.Y - s.P0.Y);
	}

	public double Project(Point2D pt)
	{
		Vector2D vector2D = Vector2D.Subtract(P1, P0);
		double lengthSquared = vector2D.LengthSquared;
		Point2D p = P0;
		Point2D p2 = P1;
		Vector2D vector2D2 = Vector2D.Subtract(pt, p);
		Vector2D vector2D3 = Vector2D.Subtract(pt, p2);
		double result = 0.0;
		if (lengthSquared > 0.0)
		{
			result = ((!(vector2D2.LengthSquared <= vector2D3.LengthSquared)) ? (1.0 + Vector2D.Dot(vector2D3, vector2D) / lengthSquared) : (Vector2D.Dot(vector2D2, vector2D) / lengthSquared));
		}
		return result;
	}

	public double ClosestPointTo(Point2D pt)
	{
		double num = Project(pt);
		if (num < 0.0)
		{
			num = 0.0;
		}
		else if (num > 1.0)
		{
			num = 1.0;
		}
		return num;
	}

	public Point2D PointAt(double t)
	{
		double num = 1.0 - t;
		Point2D p = P0;
		Point2D p2 = P1;
		return new Point2D((p.X == p2.X) ? p.X : (num * p.X + t * p2.X), (p.Y == p2.Y) ? p.Y : (num * p.Y + t * p2.Y));
	}

	public static segmentIntersectionType Intersection(Segment2D s1, Segment2D s2, out Point2D i0, out Point2D i1, double domainSize, double parallelTol = 1E-09)
	{
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz_eY3Y4c_003D = s1.P1._0023_003DzwY26hvo2cSE0() - s1.P0._0023_003DzwY26hvo2cSE0();
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz77g161c_003D = s2.P1._0023_003DzwY26hvo2cSE0() - s2.P0._0023_003DzwY26hvo2cSE0();
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzAvn2b38_003D = s1.P0._0023_003DzwY26hvo2cSE0() - s2.P0._0023_003DzwY26hvo2cSE0();
		double value;
		double value2;
		if (Math.Abs(_0023_003DzeDl1F_0024AsI93j1tV5ug_003D_003D(_0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D, out var _0023_003DzatyvRdw_003D, out var _0023_003DzM9YhqY8_003D)) < parallelTol)
		{
			_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2 = default(_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D);
			double num = _0023_003DzAvn2b38_003D._0023_003Dz4m952JDFwKpj();
			if (num > 2.2250738585072014E-308)
			{
				_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2 = new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003DzAvn2b38_003D._0023_003Dzyk2fsPo_003D / num, _0023_003DzAvn2b38_003D._0023_003DzvXOLtKg_003D / num);
			}
			value = _0023_003DzM9YhqY8_003D._0023_003Dzyk2fsPo_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003DzvXOLtKg_003D - _0023_003DzM9YhqY8_003D._0023_003DzvXOLtKg_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003Dzyk2fsPo_003D;
			value2 = _0023_003DzatyvRdw_003D._0023_003Dzyk2fsPo_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003DzvXOLtKg_003D - _0023_003DzatyvRdw_003D._0023_003DzvXOLtKg_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003Dzyk2fsPo_003D;
			if (Math.Abs(value2) > parallelTol || Math.Abs(value) > parallelTol)
			{
				i0 = null;
				i1 = null;
				return segmentIntersectionType.Disjoint;
			}
			if (!_0023_003DzRGcO5v1wS2S_(s1, s2, _0023_003Dz77g161c_003D, _0023_003DzAvn2b38_003D, _0023_003DzM9YhqY8_003D, out var _0023_003DzDSaZWik_003D, out var _0023_003DzsK_Xndk_003D))
			{
				i0 = null;
				i1 = null;
				return segmentIntersectionType.Disjoint;
			}
			_0023_003DzDSaZWik_003D = ((_0023_003DzDSaZWik_003D < 0.0) ? 0.0 : _0023_003DzDSaZWik_003D);
			_0023_003DzsK_Xndk_003D = ((_0023_003DzsK_Xndk_003D > 1.0) ? 1.0 : _0023_003DzsK_Xndk_003D);
			if (Math.Abs(_0023_003DzDSaZWik_003D - _0023_003DzsK_Xndk_003D) < 1E-09)
			{
				i0 = new Point2D(s2.P0.X + _0023_003DzDSaZWik_003D * _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D, s2.P0.Y + _0023_003DzDSaZWik_003D * _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D);
				i1 = null;
				return segmentIntersectionType.CollinearEndPointTouch;
			}
			i0 = new Point2D(s2.P0.X + _0023_003DzDSaZWik_003D * _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D, s2.P0.Y + _0023_003DzDSaZWik_003D * _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D);
			i1 = new Point2D(s2.P0.X + _0023_003DzsK_Xndk_003D * _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D, s2.P0.Y + _0023_003DzsK_Xndk_003D * _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D);
			return segmentIntersectionType.OverlapInSegment;
		}
		double num2 = _0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D * _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D - _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D * _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D;
		value = _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D * _0023_003DzAvn2b38_003D._0023_003DzvXOLtKg_003D - _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D * _0023_003DzAvn2b38_003D._0023_003Dzyk2fsPo_003D;
		value2 = _0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D * _0023_003DzAvn2b38_003D._0023_003DzvXOLtKg_003D - _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D * _0023_003DzAvn2b38_003D._0023_003Dzyk2fsPo_003D;
		double num3 = value / num2;
		double num4 = Math.Sqrt(_0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D * _0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D + _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D * _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D);
		bool flag = Math.Abs(num3 * num4) / domainSize < Utility._0023_003DzxhnLabVjXjPg;
		bool flag2 = Math.Abs(1.0 - num3) * num4 / domainSize < Utility._0023_003DzxhnLabVjXjPg;
		if (!flag && !flag2 && (num3 < -1E-09 || num3 > 1.000000001))
		{
			i0 = null;
			i1 = null;
			return segmentIntersectionType.Disjoint;
		}
		double num5 = value2 / num2;
		double num6 = Math.Sqrt(_0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D * _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D + _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D * _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D);
		bool flag3 = Math.Abs(num5 * num6) / domainSize < Utility._0023_003DzxhnLabVjXjPg;
		bool flag4 = Math.Abs(1.0 - num5) * num6 / domainSize < Utility._0023_003DzxhnLabVjXjPg;
		if (!flag3 && !flag4 && (num5 < -1E-09 || num5 > 1.000000001))
		{
			i0 = null;
			i1 = null;
			return segmentIntersectionType.Disjoint;
		}
		i0 = new Point2D(s1.P0.X + num3 * _0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D, s1.P0.Y + num3 * _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D);
		i1 = null;
		bool flag5 = !flag && !flag2;
		bool flag6 = !flag3 && !flag4;
		if (flag5 && flag6)
		{
			return segmentIntersectionType.Cross;
		}
		if (flag5 || flag6)
		{
			return segmentIntersectionType.Touch;
		}
		return segmentIntersectionType.EndPointTouch;
	}

	private static bool _0023_003DzRGcO5v1wS2S_(Segment2D _0023_003DzgPsOl1A_003D, Segment2D _0023_003DzD5YCi2M_003D, _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz77g161c_003D, _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzAvn2b38_003D, _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzM9YhqY8_003D, out double _0023_003DzDSaZWik_003D, out double _0023_003DzsK_Xndk_003D)
	{
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2 = _0023_003DzgPsOl1A_003D.P1._0023_003DzwY26hvo2cSE0() - _0023_003DzD5YCi2M_003D.P0._0023_003DzwY26hvo2cSE0();
		if (Math.Abs(_0023_003DzM9YhqY8_003D._0023_003Dzyk2fsPo_003D) > 0.7071067811865476)
		{
			_0023_003DzDSaZWik_003D = _0023_003DzAvn2b38_003D._0023_003Dzyk2fsPo_003D / _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D;
			_0023_003DzsK_Xndk_003D = _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003Dzyk2fsPo_003D / _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D;
		}
		else
		{
			_0023_003DzDSaZWik_003D = _0023_003DzAvn2b38_003D._0023_003DzvXOLtKg_003D / _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D;
			_0023_003DzsK_Xndk_003D = _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003DzvXOLtKg_003D / _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D;
		}
		if (_0023_003DzDSaZWik_003D > _0023_003DzsK_Xndk_003D)
		{
			Utility.Swap(ref _0023_003DzDSaZWik_003D, ref _0023_003DzsK_Xndk_003D);
		}
		if (_0023_003DzDSaZWik_003D > 1.0 || _0023_003DzsK_Xndk_003D < 0.0)
		{
			return false;
		}
		return true;
	}

	public static bool IntersectionLine(Segment2D s1, Segment2D s2, out Point2D i0)
	{
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz_eY3Y4c_003D = s1.P1._0023_003DzwY26hvo2cSE0() - s1.P0._0023_003DzwY26hvo2cSE0();
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz77g161c_003D = s2.P1._0023_003DzwY26hvo2cSE0() - s2.P0._0023_003DzwY26hvo2cSE0();
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2 = s1.P0._0023_003DzwY26hvo2cSE0() - s2.P0._0023_003DzwY26hvo2cSE0();
		if (Math.Abs(_0023_003DzeDl1F_0024AsI93j1tV5ug_003D_003D(_0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D, out var _, out var _)) < Utility._0023_003DzheSR8QM7q9ya)
		{
			i0 = null;
			return false;
		}
		double num = _0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D * _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D - _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D * _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D;
		double num2 = (_0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003DzvXOLtKg_003D - _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003Dzyk2fsPo_003D) / num;
		i0 = new Point2D(s1.P0.X + num2 * _0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D, s1.P0.Y + num2 * _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D);
		return true;
	}

	public static bool Intersection(Segment2D s1, Segment2D s2, out Point2D i0)
	{
		double s3;
		double t;
		bool result = IntersectionLineInternal(s1, s2, out s3, out t, out i0);
		if (i0 == null)
		{
			return result;
		}
		if (s3 > Utility._0023_003DzheSR8QM7q9ya && s3 < 1.0 - Utility._0023_003DzheSR8QM7q9ya && t > Utility._0023_003DzheSR8QM7q9ya && t < 1.0 - Utility._0023_003DzheSR8QM7q9ya)
		{
			return true;
		}
		i0 = null;
		return false;
	}

	public static bool IntersectionLineInternal(Segment2D s1, Segment2D s2, out double s, out double t, out Point2D i0)
	{
		s = double.MinValue;
		t = double.MinValue;
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz_eY3Y4c_003D = s1.P1._0023_003DzwY26hvo2cSE0() - s1.P0._0023_003DzwY26hvo2cSE0();
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz77g161c_003D = s2.P1._0023_003DzwY26hvo2cSE0() - s2.P0._0023_003DzwY26hvo2cSE0();
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzAvn2b38_003D = s1.P0._0023_003DzwY26hvo2cSE0() - s2.P0._0023_003DzwY26hvo2cSE0();
		double value;
		double value2;
		if (Math.Abs(_0023_003DzeDl1F_0024AsI93j1tV5ug_003D_003D(_0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D, out var _0023_003DzatyvRdw_003D, out var _0023_003DzM9YhqY8_003D)) < Utility._0023_003DzheSR8QM7q9ya)
		{
			i0 = null;
			double num = _0023_003DzAvn2b38_003D._0023_003Dz4m952JDFwKpj();
			if (num > 2.2250738585072014E-308)
			{
				_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2 = new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003DzAvn2b38_003D._0023_003Dzyk2fsPo_003D / num, _0023_003DzAvn2b38_003D._0023_003DzvXOLtKg_003D / num);
				value = _0023_003DzM9YhqY8_003D._0023_003Dzyk2fsPo_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003DzvXOLtKg_003D - _0023_003DzM9YhqY8_003D._0023_003DzvXOLtKg_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003Dzyk2fsPo_003D;
				value2 = _0023_003DzatyvRdw_003D._0023_003Dzyk2fsPo_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003DzvXOLtKg_003D - _0023_003DzatyvRdw_003D._0023_003DzvXOLtKg_003D * _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D2._0023_003Dzyk2fsPo_003D;
				if (Math.Abs(value2) > 1E-09 || Math.Abs(value) > 1E-09)
				{
					return false;
				}
				if (!_0023_003DzRGcO5v1wS2S_(s1, s2, _0023_003Dz77g161c_003D, _0023_003DzAvn2b38_003D, _0023_003DzM9YhqY8_003D, out var _, out var _))
				{
					return false;
				}
				return true;
			}
			return true;
		}
		double num2 = _0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D * _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D - _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D * _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D;
		value = _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D * _0023_003DzAvn2b38_003D._0023_003DzvXOLtKg_003D - _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D * _0023_003DzAvn2b38_003D._0023_003Dzyk2fsPo_003D;
		value2 = _0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D * _0023_003DzAvn2b38_003D._0023_003DzvXOLtKg_003D - _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D * _0023_003DzAvn2b38_003D._0023_003Dzyk2fsPo_003D;
		s = value / num2;
		t = value2 / num2;
		i0 = new Point2D(s1.P0.X + s * _0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D, s1.P0.Y + s * _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D);
		return true;
	}

	private static double _0023_003DzeDl1F_0024AsI93j1tV5ug_003D_003D(_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz_eY3Y4c_003D, _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz77g161c_003D, out _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzatyvRdw_003D, out _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzM9YhqY8_003D)
	{
		double num = _0023_003Dz_eY3Y4c_003D._0023_003Dz4m952JDFwKpj();
		if (num > 2.2250738585072014E-308)
		{
			_0023_003DzatyvRdw_003D = new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003Dz_eY3Y4c_003D._0023_003Dzyk2fsPo_003D / num, _0023_003Dz_eY3Y4c_003D._0023_003DzvXOLtKg_003D / num);
		}
		else
		{
			_0023_003DzatyvRdw_003D = default(_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D);
		}
		double num2 = _0023_003Dz77g161c_003D._0023_003Dz4m952JDFwKpj();
		if (num2 > 2.2250738585072014E-308)
		{
			_0023_003DzM9YhqY8_003D = new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D / num2, _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D / num2);
		}
		else
		{
			_0023_003DzM9YhqY8_003D = default(_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D);
		}
		return _0023_003DzatyvRdw_003D._0023_003Dzyk2fsPo_003D * _0023_003DzM9YhqY8_003D._0023_003DzvXOLtKg_003D - _0023_003DzatyvRdw_003D._0023_003DzvXOLtKg_003D * _0023_003DzM9YhqY8_003D._0023_003Dzyk2fsPo_003D;
	}

	public static bool IntersectionAndT(Segment2D s1, Segment2D s2, out Point2D i0)
	{
		double s3;
		double t;
		bool result = IntersectionLineInternal(s1, s2, out s3, out t, out i0);
		if (i0 == null)
		{
			return result;
		}
		bool flag = s3 > Utility._0023_003DzheSR8QM7q9ya && s3 < 1.0 - Utility._0023_003DzheSR8QM7q9ya;
		bool flag2 = t > Utility._0023_003DzheSR8QM7q9ya && t < 1.0 - Utility._0023_003DzheSR8QM7q9ya;
		if (flag && flag2)
		{
			return true;
		}
		bool flag3 = (s3 > 0.0 - Utility._0023_003DzheSR8QM7q9ya && s3 < 1E-09) || (s3 > 0.999999999 && s3 < 1.0 + Utility._0023_003DzheSR8QM7q9ya);
		bool flag4 = (t > 0.0 - Utility._0023_003DzheSR8QM7q9ya && t < 1E-09) || (t > 0.999999999 && t < 1.0 + Utility._0023_003DzheSR8QM7q9ya);
		if ((flag && flag4) || (flag3 && flag2))
		{
			return true;
		}
		i0 = null;
		return false;
	}

	public bool DoesIntersectBox(Point2D min, Point2D max)
	{
		double first = P0.X;
		double second = P1.X;
		double first2 = P0.Y;
		double second2 = P1.Y;
		if (first > second)
		{
			Utility.Swap(ref first, ref second);
		}
		if (first2 > second2)
		{
			Utility.Swap(ref first2, ref second2);
		}
		if (!Utility.DoOverlapOrTouch(min.X, max.X, first, second))
		{
			return false;
		}
		if (!Utility.DoOverlapOrTouch(min.Y, max.Y, first2, second2))
		{
			return false;
		}
		double num = P1.Y - P0.Y;
		double num2 = P0.X - P1.X;
		double num3 = P1.X * P0.Y - P0.X * P1.Y;
		double num4 = num * min.X + num2 * min.Y + num3;
		double num5 = num * max.X + num2 * max.Y + num3;
		double num6 = num * min.X + num2 * max.Y + num3;
		double num7 = num * max.X + num2 * min.Y + num3;
		if (num4 == 0.0)
		{
			return true;
		}
		if (num4 > 0.0 && (num5 <= 0.0 || num6 <= 0.0 || num7 <= 0.0))
		{
			return true;
		}
		if (num4 < 0.0 && (num5 >= 0.0 || num6 >= 0.0 || num7 >= 0.0))
		{
			return true;
		}
		return false;
	}

	public Vector2D Tan()
	{
		Vector2D vector2D = new Vector2D(P1.X - P0.X, P1.Y - P0.Y);
		vector2D.Normalize();
		return vector2D;
	}

	public Segment2D Offset(double amount)
	{
		Vector3D vector3D = new Vector3D(P1.X - P0.X, P1.Y - P0.Y, 0.0);
		vector3D.Normalize();
		Vector2D vector2D = new Vector2D(vector3D.Y, 0.0 - vector3D.X) * amount;
		return new Segment2D(P0 + vector2D, P1 + vector2D);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656886), P0, P1);
	}

	public void ExtendBy(double atStart, double atEnd)
	{
		Vector2D vector2D = Vector2D.Subtract(P1, P0);
		vector2D.Normalize();
		if (atStart != 0.0)
		{
			Point2D point2D = P0 - atStart * vector2D;
			P0.X = point2D.X;
			P0.Y = point2D.Y;
		}
		if (atEnd != 0.0)
		{
			Point2D point2D2 = P1 + atEnd * vector2D;
			P1.X = point2D2.X;
			P1.Y = point2D2.Y;
		}
	}

	public static bool AreCollinear(Segment2D s1, Segment2D s2)
	{
		Vector2D vector2D = s1;
		Vector2D vector2D2 = s2;
		vector2D.Normalize();
		vector2D2.Normalize();
		if (Utility.AreEqual(0.0, Vector2D.PerpDotProduct(vector2D, vector2D2), 1.0))
		{
			Vector2D vector2D3 = new Vector2D(s1.P0, s2.P0);
			if (Utility.AreEqual(0.0, vector2D3.Length, 1.0))
			{
				return true;
			}
			vector2D3.Normalize();
			if (Utility.AreEqual(0.0, Vector2D.PerpDotProduct(vector2D3, vector2D2), 1.0))
			{
				return true;
			}
		}
		return false;
	}

	public static bool AreOverlapping(Segment2D s1, Segment2D s2)
	{
		double num = Utility._0023_003DzheSR8QM7q9ya * Math.Min(s1.Length, s2.Length);
		Vector2D vector2D = s1;
		Vector2D vector2D2 = s2;
		vector2D.Normalize();
		vector2D2.Normalize();
		if (!Vector2D.AreParallel(vector2D, vector2D2))
		{
			return false;
		}
		Point2D p = s1.P0;
		Point2D p2 = s1.P1;
		double num2 = s2.Project(p);
		double num3 = s2.Project(p2);
		if ((num2 < num && num3 < num) || (1.0 - num < num2 && 1.0 - num < num3))
		{
			return false;
		}
		if (Utility.Compare(s2.PointAt(num2).DistanceTo(p), 0.0, 1E-12) < 0)
		{
			return true;
		}
		return false;
	}

	public bool IntersectWith(Point2D rectMin, Point2D rectMax, out double t)
	{
		Vector2D vector2D = Vector2D.Subtract(P1, P0);
		vector2D.Normalize();
		Vector3D _0023_003DzHjQZ1_Aor1Dc = new Vector3D(1.0 / vector2D.X, 1.0 / vector2D.Y);
		return _0023_003DzDfB4fS0_003D(_0023_003DzHjQZ1_Aor1Dc, rectMin, rectMax, out t);
	}

	internal bool _0023_003DzDfB4fS0_003D(Vector2D _0023_003DzHjQZ1_Aor1Dc, Point2D _0023_003DzOY0DOStBUFkD, Point2D _0023_003DzgUE_0024_TGx_0024xWd, out double _0023_003DzNDQ_E88_003D)
	{
		double val = (_0023_003DzOY0DOStBUFkD.X - P0.X) * _0023_003DzHjQZ1_Aor1Dc.X;
		double val2 = (_0023_003DzgUE_0024_TGx_0024xWd.X - P0.X) * _0023_003DzHjQZ1_Aor1Dc.X;
		double val3 = (_0023_003DzOY0DOStBUFkD.Y - P0.Y) * _0023_003DzHjQZ1_Aor1Dc.Y;
		double val4 = (_0023_003DzgUE_0024_TGx_0024xWd.Y - P0.Y) * _0023_003DzHjQZ1_Aor1Dc.Y;
		double num = Math.Max(Math.Min(val, val2), Math.Min(val3, val4));
		double num2 = Math.Min(Math.Max(val, val2), Math.Max(val3, val4));
		if (num2 < 0.0)
		{
			_0023_003DzNDQ_E88_003D = num2;
			return false;
		}
		if (num > num2)
		{
			_0023_003DzNDQ_E88_003D = num2;
			return false;
		}
		_0023_003DzNDQ_E88_003D = num;
		return true;
	}

	public virtual Segment2DSurrogate ConvertToSurrogate()
	{
		return new Segment2DSurrogate(this);
	}
}
