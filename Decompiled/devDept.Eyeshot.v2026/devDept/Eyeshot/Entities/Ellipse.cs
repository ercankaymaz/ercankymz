using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Ellipse : PlanarEntity, ICurve, ICloneable, IEvaluable
{
	private static class _0023_003DzQm9ltrs_003D
	{
		public static _0023_003DzbI4liJ6BQ8ja _0023_003DzyOu_0024xQAy1j5HjNJkDzmvbZ0_003D;
	}

	private sealed class _0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D
	{
		public double _0023_003DzN6G05Lg_003D;

		internal double _0023_003DzRRNf2mp7pD9JESgtEwev5lx3r8i9jOwwM2Rkrln5RRxe(double _0023_003DzBJFJHwk_003D)
		{
			return Math.Sqrt(_0023_003DzN6G05Lg_003D * Math.Sin(_0023_003DzBJFJHwk_003D) * Math.Sin(_0023_003DzBJFJHwk_003D) + 1.0);
		}
	}

	private delegate int _0023_003DzbI4liJ6BQ8ja(double[] _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, out double _0023_003Dzt_m8zV0_003D, out double _0023_003DzXrexKjY_003D);

	private int _edgeIndex = -1;

	private bool _fromBooleanIntersection;

	internal double _radiusY;

	internal double _radiusX;

	public int EdgeIndex
	{
		get
		{
			return _edgeIndex;
		}
		set
		{
			_edgeIndex = value;
		}
	}

	public bool FromBooleanIntersection
	{
		get
		{
			return _fromBooleanIntersection;
		}
		set
		{
			_fromBooleanIntersection = value;
		}
	}

	public bool IsCircle => Math.Abs(_radiusX - _radiusY) <= Math.Abs(_radiusX) * 1E-12;

	public double RadiusX
	{
		get
		{
			return _radiusX;
		}
		set
		{
			if (value < 1E-12)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966958));
			}
			_radiusX = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public double RadiusY
	{
		get
		{
			return _radiusY;
		}
		set
		{
			if (value < 1E-12)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966958));
			}
			_radiusY = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Point3D Center => base.Plane.Origin;

	public double FocalDistance
	{
		get
		{
			double[] array = new double[2] { _radiusX, _radiusY };
			int num = ((!(Math.Abs(_radiusX) >= Math.Abs(_radiusY))) ? 1 : 0);
			double num2 = Math.Abs(array[num]);
			double num3 = ((num2 > 0.0) ? (Math.Abs(array[1 - num]) / num2) : 0.0);
			return num2 * Math.Sqrt(1.0 - num3 * num3);
		}
	}

	public virtual Vector3D StartTangent
	{
		get
		{
			Vector3D vector3D = _0023_003DzDY8DgLzNJbK6(0.0, base.Plane, _radiusX, _radiusY);
			vector3D.Normalize();
			return vector3D;
		}
	}

	public virtual Vector3D EndTangent
	{
		get
		{
			Vector3D vector3D = _0023_003DzDY8DgLzNJbK6(0.0, base.Plane, _radiusX, _radiusY);
			vector3D.Normalize();
			return vector3D;
		}
	}

	public virtual Point3D StartPoint => PointAt(0.0);

	public virtual Interval Domain
	{
		get
		{
			return new Interval(0.0, Math.PI * 2.0);
		}
		set
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967652));
		}
	}

	public virtual Point3D EndPoint => PointAt(0.0);

	public virtual bool IsClosed => true;

	public virtual bool IsPoint
	{
		get
		{
			if (_radiusX < 1E-12)
			{
				return _radiusY < 1E-12;
			}
			return false;
		}
	}

	public Ellipse(Point3D center, double rx, double ry)
	{
		if (!_0023_003DzuvS5KTE_003D(center, rx, ry))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966786));
		}
	}

	public Ellipse(double x, double y, double z, double rx, double ry)
	{
		if (!_0023_003DzuvS5KTE_003D(new Point3D(x, y, z), rx, ry))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966786));
		}
	}

	public Ellipse(Plane ellipsePlane, Point2D center, double rx, double ry)
		: base((Plane)ellipsePlane.Clone())
	{
		if (!_0023_003DzuvS5KTE_003D(base.Plane.PointAt(center.X, center.Y), rx, ry))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966786));
		}
	}

	public Ellipse(Plane ellipsePlane, Point3D center, double rx, double ry)
		: base((Plane)ellipsePlane.Clone())
	{
		if (!_0023_003DzuvS5KTE_003D(center, rx, ry))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966786));
		}
	}

	public Ellipse(Plane plane, double rx, double ry)
		: base((Plane)plane.Clone())
	{
		if (!_0023_003DzuvS5KTE_003D(rx, ry))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966786));
		}
	}

	protected Ellipse(Ellipse another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_radiusY = another._radiusY;
		_radiusX = another._radiusX;
	}

	protected internal Ellipse(EllipseSurrogate surrogate)
		: base(surrogate.GetPlane())
	{
		_radiusX = surrogate.GetRadiusX();
		_radiusY = surrogate.GetRadiusY();
	}

	internal Ellipse(GEllipse _0023_003DzQwa1qM0_003D)
		: this(_0023_003DzQwa1qM0_003D.Plane, _0023_003DzQwa1qM0_003D.RadiusX, _0023_003DzQwa1qM0_003D.RadiusY)
	{
	}

	protected Ellipse(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_radiusY = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967012));
		_radiusX = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966997));
	}

	public override object Clone()
	{
		return new Ellipse(this);
	}

	public override object CloneWithTessellation()
	{
		return new Ellipse(this, RegenMode != regenType.RegenAndCompile);
	}

	private bool _0023_003DzuvS5KTE_003D(double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D)
	{
		_radiusX = _0023_003DzTAvzjIc_003D;
		_radiusY = _0023_003DzpbGuOuw_003D;
		if (base.IsValid((StringBuilder)null) && _radiusY > 1E-12)
		{
			return _radiusX > 1E-12;
		}
		return false;
	}

	private bool _0023_003DzuvS5KTE_003D(Point3D _0023_003DzshZYG54_003D, double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D)
	{
		base.Plane.Origin.X = _0023_003DzshZYG54_003D.X;
		base.Plane.Origin.Y = _0023_003DzshZYG54_003D.Y;
		base.Plane.Origin.Z = _0023_003DzshZYG54_003D.Z;
		base.Plane.UpdateEquation();
		return _0023_003DzuvS5KTE_003D(_0023_003DzTAvzjIc_003D, _0023_003DzpbGuOuw_003D);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966986) + _radiusX);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966972) + _radiusY);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963264) + Length().ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + linearUnits.ToString().ToLower());
		return stringBuilder.ToString();
	}

	public bool GetNurbsFormParameterFromRadian(double radianParam, out double nurbsParam)
	{
		Curve nurbsForm = GetNurbsForm();
		return _0023_003DzkIYRqMrwTtoQ7uOV_dn3JAI_003D(radianParam, out nurbsParam, nurbsForm);
	}

	public bool GetNurbsFormParameterFromRadian(double radianParam, out double nurbsParam, Curve crv)
	{
		return _0023_003DzkIYRqMrwTtoQ7uOV_dn3JAI_003D(radianParam, out nurbsParam, crv);
	}

	internal bool _0023_003DzkIYRqMrwTtoQ7uOV_dn3JAI_003D(double _0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D, out double _0023_003Dz_0024FpxbSgArNoa, Curve _0023_003DzzmfUkNI_003D)
	{
		Utility.LimitRange(_0023_003DzzmfUkNI_003D.Domain.t0, ref _0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D, _0023_003DzzmfUkNI_003D.Domain.t1);
		if (_0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D == Math.PI / 2.0 && Point3D.DistanceSquared(PointAt(_0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D), _0023_003DzzmfUkNI_003D.PointAt(_0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D)) < 1E-12)
		{
			_0023_003Dz_0024FpxbSgArNoa = _0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D;
			return true;
		}
		Interval domain = Domain;
		double num = 1E-12 * (Math.Abs(domain.t0) + Math.Abs(domain.t1));
		double num2 = _0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D - domain.t0;
		if (num2 <= num && num2 >= 0.0 - Utility._0023_003DzheSR8QM7q9ya)
		{
			_0023_003Dz_0024FpxbSgArNoa = domain.t0;
			return true;
		}
		num2 = domain.t1 - _0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D;
		if (num2 <= num && num2 >= 0.0 - Utility._0023_003DzheSR8QM7q9ya)
		{
			_0023_003Dz_0024FpxbSgArNoa = domain.t1;
			return true;
		}
		_0023_003Dz_0024FpxbSgArNoa = 0.0;
		if (!domain.Includes(_0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D, testOpenInterval: false))
		{
			return false;
		}
		int num3 = _0023_003DzzmfUkNI_003D._0023_003DzKxlE1oQ_003D();
		double num4 = Domain.Left;
		Point3D p = _0023_003DzzmfUkNI_003D.PointAt(_0023_003DzzmfUkNI_003D.Domain.Low) - Center;
		double x = Vector3D.Dot(base.Plane.AxisX, p) / RadiusX;
		double num5 = Math.Atan2(Vector3D.Dot(base.Plane.AxisY, p) / RadiusY, x);
		int num6 = 0;
		int num7 = 0;
		while (num6 < num3)
		{
			p = _0023_003DzzmfUkNI_003D.PointAt(_0023_003DzzmfUkNI_003D._0023_003DziP9fFuA_003D[(num7 == 0) ? (num7 + 3) : (num7 + 2)]) - Center;
			x = Vector3D.Dot(base.Plane.AxisX, p) / RadiusX;
			double num8 = Math.Atan2(Vector3D.Dot(base.Plane.AxisY, p) / RadiusY, x);
			num4 = ((!(num8 > num5)) ? (num4 + (Math.PI * 2.0 + num8 - num5)) : (num4 + (num8 - num5)));
			num5 = num8;
			if (num4 > _0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D || Utility.Compare(num4, _0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D) == 0)
			{
				break;
			}
			num6++;
			num7 += _0023_003DzzmfUkNI_003D._0023_003Dz85p_8V2nSlkt(num7);
		}
		Interval interval = new Interval(_0023_003DzzmfUkNI_003D._0023_003DziP9fFuA_003D[num7], _0023_003DzzmfUkNI_003D._0023_003DziP9fFuA_003D[(num7 == 0) ? (num7 + 3) : (num7 + 2)]);
		Curve curve = _0023_003DzzmfUkNI_003D.Decompose()[num6];
		Transformation transformation = new Transformation();
		transformation.ChangeBasis(Plane.XY, base.Plane);
		curve.TransformBy(transformation);
		double[] array = new double[3];
		for (int i = 0; i < 3; i++)
		{
			Point4D point4D = curve.Pw[i];
			array[i] = Math.Tan(_0023_003DzuOgkaXrwUiS_Pz7aYA_003D_003D) * point4D.X / RadiusX - point4D.Y / RadiusY;
		}
		double d = array[1] * array[1] - array[0] * array[2];
		double num9;
		if (Math.Abs(array[0] - 2.0 * array[1] + array[2]) > 1E-12 * (RadiusX + RadiusY) / 2.0)
		{
			d = Math.Sqrt(d);
			num9 = (array[0] - array[1] + d) / (array[0] - 2.0 * array[1] + array[2]);
			if (num9 < 0.0 || num9 > 1.0)
			{
				double num10 = (array[0] - array[1] - d) / (array[0] - 2.0 * array[1] + array[2]);
				if (Math.Abs(num10 - 0.5) < Math.Abs(num9 - 0.5))
				{
					num9 = num10;
				}
			}
		}
		else
		{
			num9 = 1.0;
			if (array[0] - array[2] != 0.0)
			{
				num9 = array[0] / (array[0] - array[2]);
			}
		}
		if (num9 < 0.0)
		{
			num9 = 0.0;
		}
		else if (num9 > 1.0)
		{
			num9 = 1.0;
		}
		_0023_003Dz_0024FpxbSgArNoa = interval.ParameterAt(num9);
		return true;
	}

	public bool GetRadianFromNurbFormParameter(double nurbParameter, out double radianParameter)
	{
		Curve nurbsForm = GetNurbsForm();
		return _0023_003DziF9U0ToEO_0024ZpwCK8UCiW2dw_003D(nurbParameter, out radianParameter, nurbsForm, _0023_003DzNLR5KV3Ce3_0024s: true);
	}

	public bool GetRadianFromNurbFormParameter(double nurbParameter, out double radianParameter, Curve nurbsArc)
	{
		return _0023_003DziF9U0ToEO_0024ZpwCK8UCiW2dw_003D(nurbParameter, out radianParameter, nurbsArc, _0023_003DzNLR5KV3Ce3_0024s: true);
	}

	internal bool _0023_003DziF9U0ToEO_0024ZpwCK8UCiW2dw_003D(double _0023_003DzksmEARwaX5Ju, out double _0023_003DzddcZZIYy54yB, Curve _0023_003DzzmfUkNI_003D, bool _0023_003DzNLR5KV3Ce3_0024s)
	{
		_0023_003DzddcZZIYy54yB = 1000.0;
		double num = 1E-06;
		double t = Domain.t0;
		double t2 = Domain.t1;
		if (!IsValid())
		{
			return false;
		}
		if (Math.Abs(_0023_003DzksmEARwaX5Ju - t) <= 2.0 * num * Math.Abs(t))
		{
			_0023_003DzddcZZIYy54yB = t;
			return true;
		}
		if (Math.Abs(_0023_003DzksmEARwaX5Ju - t2) <= 2.0 * num * Math.Abs(t2))
		{
			_0023_003DzddcZZIYy54yB = t2;
			return true;
		}
		Point3D p = _0023_003DzzmfUkNI_003D.PointAt(_0023_003DzksmEARwaX5Ju);
		p -= Center;
		double x = Vector3D.Dot(base.Plane.AxisX, p) / RadiusX;
		double num2 = Math.Atan2(Vector3D.Dot(base.Plane.AxisY, p) / RadiusY, x);
		num2 -= Math.Floor((num2 - t) / (Math.PI * 2.0)) * 2.0 * Math.PI;
		if (_0023_003DzNLR5KV3Ce3_0024s && (num2 < t || num2 > t2))
		{
			num2 = ((!(_0023_003DzksmEARwaX5Ju < (t + t2) / 2.0)) ? t2 : t);
		}
		_0023_003DzddcZZIYy54yB = num2;
		return true;
	}

	public bool IsPlanar(double tol, out Plane plane)
	{
		plane = (Plane)base.Plane.Clone();
		return true;
	}

	public bool IsInPlane(Plane testPlane, double tolerance)
	{
		bool flag = IsValid();
		int num = 0;
		while (flag && num < 3)
		{
			if (Math.Abs(testPlane.Equation.ValueAt(PointAt(Math.PI * 2.0 * (double)num / 3.0))) > tolerance)
			{
				flag = false;
				break;
			}
			num++;
		}
		return flag;
	}

	public double DistanceTo(ICurve curve, out Point3D[] closestPointOnFirst, out Point3D[] closestPointOnSecond)
	{
		double num = double.MaxValue;
		closestPointOnFirst = null;
		closestPointOnSecond = null;
		if (curve is CompositeCurve)
		{
			ICurve[] individualCurves = curve.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				Curve[] array = individualCurves[i].GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
				foreach (Curve b in array)
				{
					MinimumDistance minimumDistance = new MinimumDistance(this, b);
					minimumDistance.DoWork();
					if (minimumDistance.Result.Length < num)
					{
						num = minimumDistance.Result.Length;
						closestPointOnFirst = new Point3D[1] { minimumDistance.Result.P0 };
						closestPointOnSecond = new Point3D[1] { minimumDistance.Result.P1 };
					}
				}
			}
		}
		else
		{
			Curve[] array2 = curve.GetNurbsForm().SplitAtDiscontinuities(speedChange: false);
			foreach (Curve b2 in array2)
			{
				MinimumDistance minimumDistance2 = new MinimumDistance(this, b2);
				minimumDistance2.DoWork();
				if (minimumDistance2.Result.Length < num)
				{
					num = minimumDistance2.Result.Length;
					closestPointOnFirst = new Point3D[1] { minimumDistance2.Result.P0 };
					closestPointOnSecond = new Point3D[1] { minimumDistance2.Result.P1 };
				}
			}
		}
		return num;
	}

	public bool IsPointInside(Point3D testPoint)
	{
		Point2D p = new Point2D(0.0, 0.0);
		Vector2D u = new Vector2D(p, base.Plane.Project(StartPoint));
		Point2D p2 = base.Plane.Project(testPoint);
		Vector2D vector2D = new Vector2D(p, p2);
		double _0023_003Dzv3_XI_A_003D = Vector2D.SignedAngleBetween(u, vector2D);
		Point3D a = PointAt(EllipticalArc._0023_003DzwNEfHBMh6b57(RadiusX, RadiusY, _0023_003Dzv3_XI_A_003D));
		double lengthSquared = vector2D.LengthSquared;
		double num = Point3D.DistanceSquared(a, base.Plane.Origin);
		if (lengthSquared < num)
		{
			return true;
		}
		return false;
	}

	public bool IsLinear(double tol, out Segment3D line)
	{
		line = null;
		return false;
	}

	public void GetFoci(out Point3D F1, out Point3D F2)
	{
		double focalDistance = FocalDistance;
		F1 = base.Plane.Origin + focalDistance * base.Plane.AxisX;
		F2 = base.Plane.Origin - focalDistance * base.Plane.AxisX;
	}

	public Point3D PointAt(double t)
	{
		return PointOnEllipseAt(t, base.Plane, _radiusX, _radiusY);
	}

	public Vector3D TangentAt(double t)
	{
		Vector3D vector3D = _0023_003DzDY8DgLzNJbK6(t, base.Plane, _radiusX, _radiusY);
		vector3D.Normalize();
		return vector3D;
	}

	public static Point3D PointOnEllipseAt(double t, Plane plane, double r0, double r1)
	{
		return plane.PointAt(Math.Cos(t) * r0, Math.Sin(t) * r1);
	}

	internal static Vector3D _0023_003DzDY8DgLzNJbK6(double _0023_003DzNDQ_E88_003D, Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003DzjvR56vw_003D, double _0023_003Dzkzf4gQ0_003D)
	{
		return _0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(1, _0023_003DzNDQ_E88_003D, _0023_003Dzrgqz890sj_0024X9, _0023_003DzjvR56vw_003D, _0023_003Dzkzf4gQ0_003D);
	}

	internal static Vector3D _0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(int _0023_003DzXrexKjY_003D, double _0023_003DzNDQ_E88_003D, Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003DzjvR56vw_003D, double _0023_003Dzkzf4gQ0_003D)
	{
		switch (Math.Abs(_0023_003DzXrexKjY_003D) % 4)
		{
		case 0:
			_0023_003DzjvR56vw_003D *= Math.Cos(_0023_003DzNDQ_E88_003D);
			_0023_003Dzkzf4gQ0_003D *= Math.Sin(_0023_003DzNDQ_E88_003D);
			break;
		case 1:
			_0023_003DzjvR56vw_003D *= 0.0 - Math.Sin(_0023_003DzNDQ_E88_003D);
			_0023_003Dzkzf4gQ0_003D *= Math.Cos(_0023_003DzNDQ_E88_003D);
			break;
		case 2:
			_0023_003DzjvR56vw_003D *= 0.0 - Math.Cos(_0023_003DzNDQ_E88_003D);
			_0023_003Dzkzf4gQ0_003D *= 0.0 - Math.Sin(_0023_003DzNDQ_E88_003D);
			break;
		case 3:
			_0023_003DzjvR56vw_003D *= Math.Sin(_0023_003DzNDQ_E88_003D);
			_0023_003Dzkzf4gQ0_003D *= 0.0 - Math.Cos(_0023_003DzNDQ_E88_003D);
			break;
		}
		return _0023_003DzjvR56vw_003D * _0023_003Dzrgqz890sj_0024X9.AxisX + _0023_003Dzkzf4gQ0_003D * _0023_003Dzrgqz890sj_0024X9.AxisY;
	}

	public Vector3D NormalAt(double t)
	{
		Vector3D vector3D = _0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(2, t, base.Plane, _radiusY, _radiusX);
		vector3D.Normalize();
		return vector3D;
	}

	public ICurve[] Offset(double amount, Vector3D planeNormal, bool sharp = false)
	{
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		try
		{
			return GetNurbsForm().Offset(amount, planeNormal);
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
	}

	public virtual Region OffsetToRegion(double amount, bool sharp)
	{
		ICurve curve = (ICurve)Clone();
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		try
		{
			ICurve[] array = Offset(amount, base.Plane.AxisZ, sharp);
			ICurve curve2 = ((array != null) ? array[0] : null);
			if (amount > 0.0)
			{
				curve.Reverse();
			}
			else
			{
				curve2.Reverse();
			}
			return new Region(new ICurve[2] { curve, curve2 }, base.Plane);
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
	}

	public Point3D[] GetPointsByLength(double length)
	{
		return _0023_003DzuXerNrvfk4L802foSQ_003D_003D(length);
	}

	private double _0023_003DzXsMKXGr8i9igmMOWj36CBYmdo9994F8llA_003D_003D(double _0023_003DzDSaZWik_003D, double _0023_003DzsK_Xndk_003D)
	{
		_0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D _0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D2 = new _0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D();
		double num = RadiusX * RadiusX;
		double num2 = RadiusY * RadiusY;
		_0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D2._0023_003DzN6G05Lg_003D = (num - num2) / num2;
		double _0023_003DzpduTDKBJsIQh = Domain.Length * Utility._0023_003DzheSR8QM7q9ya / (Math.PI * 2.0);
		int _0023_003DztlbGKC7GtKDN1adZAw_003D_003D;
		double _0023_003DzSkwcd6MT2HxSd_0024MPdg_003D_003D;
		return RadiusY * Utility._0023_003Dz8s608KleYwNYvOtWkA_003D_003D(_0023_003DzbA9BWw35n0GRK26J8k_4ZfE_003D2._0023_003DzRRNf2mp7pD9JESgtEwev5lx3r8i9jOwwM2Rkrln5RRxe, _0023_003DzDSaZWik_003D, _0023_003DzsK_Xndk_003D, _0023_003DzpduTDKBJsIQh, 20, out _0023_003DztlbGKC7GtKDN1adZAw_003D_003D, out _0023_003DzSkwcd6MT2HxSd_0024MPdg_003D_003D);
	}

	private Point3D[] _0023_003DzuXerNrvfk4L802foSQ_003D_003D(double _0023_003Dz736ekIs_003D)
	{
		double num = Length();
		double num2 = num / _0023_003Dz736ekIs_003D;
		int num3 = (int)Math.Ceiling(num2);
		int num4 = (int)Math.Truncate(num2);
		int num5 = ((num2 - (double)num4 < _0023_003Dz736ekIs_003D * Utility._0023_003DzxhnLabVjXjPg) ? num4 : num3);
		double num6 = num / (double)num5;
		double[] array = new double[num5 + 1];
		if (num5 <= 1)
		{
			array[0] = Domain.Low;
		}
		else
		{
			SortedList<double, double> _0023_003Dzd7nry7g_003D = new SortedList<double, double>
			{
				{ Domain.Low, 0.0 },
				{ Domain.High, num }
			};
			array[0] = Domain.Low;
			array[num5] = Domain.High;
			for (int i = 1; i < num5; i++)
			{
				array[i] = _0023_003DzY_0024O_0024tpQ_003D((double)i * num6, _0023_003Dzd7nry7g_003D, num);
			}
		}
		Point3D[] array2 = new Point3D[array.Length];
		for (int j = 0; j < array.Length; j++)
		{
			array2[j] = PointAt(array[j]);
		}
		return array2;
	}

	private double _0023_003DzY_0024O_0024tpQ_003D(double _0023_003DztrV0J0_0024vsVfb, SortedList<double, double> _0023_003Dzd7nry7g_003D, double _0023_003Dz9JZgoew_003D)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		bool flag = false;
		foreach (KeyValuePair<double, double> item in _0023_003Dzd7nry7g_003D)
		{
			if (_0023_003DztrV0J0_0024vsVfb > num3)
			{
				if (Math.Abs(num3 - _0023_003DztrV0J0_0024vsVfb) < Utility._0023_003DzheSR8QM7q9ya)
				{
					return num;
				}
				num2 = num;
				num = item.Key;
				num4 = num3;
				num3 = item.Value;
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				break;
			}
		}
		double num5 = num;
		num = num2;
		double num6 = (num + num5) / 2.0;
		num3 = num4 + _0023_003DzXsMKXGr8i9igmMOWj36CBYmdo9994F8llA_003D_003D(num2, num6);
		if (Math.Abs(num3 - _0023_003DztrV0J0_0024vsVfb) < Utility._0023_003DzheSR8QM7q9ya)
		{
			return num6;
		}
		_0023_003Dzd7nry7g_003D.Add(num6, num3);
		while (Math.Abs(num3 - _0023_003DztrV0J0_0024vsVfb) > Utility._0023_003DzheSR8QM7q9ya)
		{
			if (_0023_003DztrV0J0_0024vsVfb < num3)
			{
				num4 = num3;
				num5 = num6;
				num6 = (num5 + num) / 2.0;
				if (Math.Abs(num - num5) < 1E-12)
				{
					break;
				}
				num3 = num4 - _0023_003DzXsMKXGr8i9igmMOWj36CBYmdo9994F8llA_003D_003D(num6, num5);
				_0023_003Dzd7nry7g_003D.Add(num6, num3);
			}
			else
			{
				num4 = num3;
				num = num6;
				num6 = (num5 + num) / 2.0;
				if (Math.Abs(num - num5) < 1E-12)
				{
					break;
				}
				num3 = num4 + _0023_003DzXsMKXGr8i9igmMOWj36CBYmdo9994F8llA_003D_003D(num, num6);
				_0023_003Dzd7nry7g_003D.Add(num6, num3);
			}
		}
		return num6;
	}

	public Point3D[] GetPointsByLengthPerSegment(double length)
	{
		return GetPointsByLength(length);
	}

	public virtual void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		double[,] matrix = new Align3D(Plane.XY, base.Plane).Matrix;
		double num = matrix[0, 0];
		double num2 = matrix[1, 1];
		double num3 = matrix[2, 2];
		double num4 = matrix[0, 1];
		_ = matrix[0, 2];
		double num5 = matrix[1, 0];
		_ = matrix[1, 2];
		double num6 = matrix[2, 0];
		double num7 = matrix[2, 1];
		double num8 = matrix[0, 3];
		double num9 = matrix[1, 3];
		double num10 = matrix[2, 3];
		double num11 = Math.Sqrt(num * num * RadiusX * RadiusX + num4 * num4 * RadiusY * RadiusY + num6 * num6 * 0.0 * 0.0);
		double num12 = Math.Sqrt(num5 * num5 * RadiusX * RadiusX + num2 * num2 * RadiusY * RadiusY + num7 * num7 * 0.0 * 0.0);
		double num13 = Math.Sqrt(num6 * num6 * RadiusX * RadiusX + num7 * num7 * RadiusY * RadiusY + num3 * num3 * 0.0 * 0.0);
		double num14 = num9;
		double num15 = num10;
		double x = num8 - num11;
		double x2 = num8 + num11;
		double y = num14 - num12;
		double y2 = num14 + num12;
		double z = num15 - num13;
		double z2 = num15 + num13;
		Utility.ComputeBoundingBox(new Point3D[2]
		{
			new Point3D(x, y, z),
			new Point3D(x2, y2, z2)
		}, out boxMin, out boxMax);
	}

	public Vector3D CurvatureAt(double t)
	{
		Utility.EvaluateCurvature(_0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(1, t, base.Plane, _radiusX, _radiusY), _0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(2, t, base.Plane, _radiusX, _radiusY), out var _, out var K);
		return K;
	}

	public override void Regen(RegenParams data)
	{
		int num = Utility.NumberOfSegments(Math.Max(_radiusY, _radiusX), Math.PI * 2.0, data.Deviation, data.Angle);
		_vertices = new Point3D[num + 1];
		for (int i = 0; i < num + 1; i++)
		{
			double t = (double)(i * 2) * Math.PI / (double)num;
			Point3D point3D = PointAt(t);
			Vector3D vector3D = TangentAt(t);
			_vertices[i] = new PointTangent(point3D.X, point3D.Y, point3D.Z, vector3D.X, vector3D.Y, vector3D.Z);
		}
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	public override void TransformBy(Transformation xform)
	{
		Plane pl = (Plane)base.Plane.Clone();
		base.TransformBy(xform);
		double scaleFactor = Math.Abs(xform.ScaleFactorX);
		if (xform.IsScaleFactorUniform() || xform.IsScaleFactorUniformForPlanar(pl, ref scaleFactor))
		{
			_radiusX *= scaleFactor;
			_radiusY *= scaleFactor;
		}
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new EllipseSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967012), _radiusY);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966997), _radiusX);
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			Point3D[] array = new Point3D[4];
			double num = Math.PI * 2.0;
			array[0] = PointAt(0.0 * num / 4.0);
			array[1] = PointAt(num / 4.0);
			array[2] = PointAt(2.0 * num / 4.0);
			array[3] = PointAt(3.0 * num / 4.0);
			return array;
		}
		return new Point3D[2] { base.BoxMin, base.BoxMax };
	}

	public virtual double Length()
	{
		return _0023_003DzXsMKXGr8i9igmMOWj36CBYmdo9994F8llA_003D_003D(Domain.t0, Domain.t1);
	}

	public virtual void Reverse()
	{
		Vector3D axisY = base.Plane.AxisY;
		axisY.Negate();
		base.Plane = new Plane(base.Plane.Origin, base.Plane.AxisX, axisY);
		RegenMode = regenType.RegenAndCompile;
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (_radiusX <= 1E-12)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967586));
			return false;
		}
		if (_radiusY <= 1E-12)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967578));
			return false;
		}
		return base.IsValid(log);
	}

	public virtual Curve GetNurbsForm()
	{
		double length = Domain.Length;
		double[] array = new double[12];
		array[0] = (array[1] = (array[2] = 0.0));
		array[3] = (array[4] = 0.25 * length);
		array[5] = (array[6] = 0.5 * length);
		array[7] = (array[8] = 0.75 * length);
		array[9] = (array[10] = (array[11] = length));
		Point4D[] array2 = new Point4D[9];
		array2[0] = new Point4D(base.Plane.PointAt(_radiusX, 0.0));
		array2[1] = new Point4D(base.Plane.PointAt(_radiusX, _radiusY));
		array2[2] = new Point4D(base.Plane.PointAt(0.0, _radiusY));
		array2[3] = new Point4D(base.Plane.PointAt(0.0 - _radiusX, _radiusY));
		array2[4] = new Point4D(base.Plane.PointAt(0.0 - _radiusX, 0.0));
		array2[5] = new Point4D(base.Plane.PointAt(0.0 - _radiusX, 0.0 - _radiusY));
		array2[6] = new Point4D(base.Plane.PointAt(0.0, 0.0 - _radiusY));
		array2[7] = new Point4D(base.Plane.PointAt(_radiusX, 0.0 - _radiusY));
		array2[8] = (Point4D)array2[0].Clone();
		double num = 1.0 / Math.Sqrt(2.0);
		for (int i = 1; i < 8; i += 2)
		{
			array2[i].X *= num;
			array2[i].Y *= num;
			array2[i].Z *= num;
			array2[i].W = num;
		}
		Curve curve = new Curve(2, array, array2, checkKnotsAndCtrlPts: false);
		curve.CopyAttributes(this);
		return curve;
	}

	public bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub)
	{
		ClosestPointTo(startPt, out var t);
		ClosestPointTo(endPt, out var t2);
		if (SubCurve(t, t2, out sub))
		{
			return true;
		}
		return false;
	}

	public virtual bool SubCurve(double t0, double t1, out ICurve sub)
	{
		if (!Circle._0023_003DzJUU5L0s5zlzq(_0023_003DzbErHvVw_003D: true, 0.0, Math.PI * 2.0, Math.PI * 2.0, ref t0, ref t1))
		{
			sub = null;
			return false;
		}
		sub = new EllipticalArc(base.Plane, base.Plane.Origin, _radiusX, _radiusY, t0, t1);
		((Entity)sub).CopyAttributes(this);
		return true;
	}

	public bool GetParamFromLength(double length, out double t)
	{
		double curveLength = Length();
		return GetParamFromLength(length, curveLength, out t);
	}

	public virtual bool GetParamFromLength(double length, double curveLength, out double t)
	{
		if (Utility.AreEqual(length, 0.0, curveLength))
		{
			t = Domain.Low;
			return true;
		}
		if (Utility.AreEqual(length, curveLength, curveLength))
		{
			t = Domain.High;
			return true;
		}
		if (length < 0.0 || length > curveLength)
		{
			t = Domain.Low;
			return false;
		}
		double num = curveLength / 4.0;
		double num2 = ((length <= num) ? 0.0 : ((length <= 2.0 * num) ? (Math.PI / 2.0) : ((!(length <= 3.0 * num)) ? 4.71238898038469 : Math.PI)));
		t = num2 + Math.PI / 4.0;
		if (_0023_003DzcUx5Y7fq28Sc(this, Domain.Low, Domain.High, length, ref t) && SubCurve(StartPoint, PointAt(t), out var sub) && Utility.AreEqual(sub.Length() - length, 0.0, curveLength * 1000.0))
		{
			return true;
		}
		return _0023_003DzfBAEGQbap942tumNKRuGZg1QNxBX(length, curveLength, ref t);
	}

	private protected bool _0023_003DzfBAEGQbap942tumNKRuGZg1QNxBX(double _0023_003Dz736ekIs_003D, double _0023_003DzaUF77KfxjxOo, ref double _0023_003DzNDQ_E88_003D)
	{
		if (_0023_003DzcUx5Y7fq28Sc(this, Domain.Low, Domain.High, _0023_003Dz736ekIs_003D, ref _0023_003DzNDQ_E88_003D) && SubCurve(StartPoint, PointAt(_0023_003DzNDQ_E88_003D), out var sub) && Utility.AreEqual(sub.Length() - _0023_003Dz736ekIs_003D, 0.0, _0023_003DzaUF77KfxjxOo * 1000.0))
		{
			return true;
		}
		_0023_003DzNDQ_E88_003D = Domain.Low + Domain.Length / 4.0;
		if (_0023_003DzcUx5Y7fq28Sc(this, Domain.Low, Domain.High, _0023_003Dz736ekIs_003D, ref _0023_003DzNDQ_E88_003D) && SubCurve(StartPoint, PointAt(_0023_003DzNDQ_E88_003D), out sub) && Utility.AreEqual(sub.Length() - _0023_003Dz736ekIs_003D, 0.0, _0023_003DzaUF77KfxjxOo * 1000.0))
		{
			return true;
		}
		_0023_003DzNDQ_E88_003D = Domain.Low + Domain.Length * 3.0 / 4.0;
		if (_0023_003DzcUx5Y7fq28Sc(this, Domain.Low, Domain.High, _0023_003Dz736ekIs_003D, ref _0023_003DzNDQ_E88_003D) && SubCurve(StartPoint, PointAt(_0023_003DzNDQ_E88_003D), out sub) && Utility.AreEqual(sub.Length() - _0023_003Dz736ekIs_003D, 0.0, _0023_003DzaUF77KfxjxOo * 1000.0))
		{
			return true;
		}
		return false;
	}

	public bool GetLengthFromParam(double t, out double length)
	{
		if (Utility.AreEqual(t, Domain.Low, Domain.Length))
		{
			length = 0.0;
			return true;
		}
		if (Utility.AreEqual(t, Domain.High, Domain.Length))
		{
			length = Length();
			return true;
		}
		if (t < Domain.Low || t > Domain.High)
		{
			length = 0.0;
			return false;
		}
		if (SplitAt(t, out var lower, out var _))
		{
			length = lower.Length();
			return true;
		}
		length = 0.0;
		return false;
	}

	public Point3D[] IntersectWith(ICurve C2, double maxGap = 0.0, bool computeParameters = true)
	{
		List<Point3D> list = new List<Point3D>();
		GetApproximatedBoundingBox(out var boxMin, out var boxMax);
		Size3D size3D = new Size3D(boxMin, boxMax);
		C2.GetApproximatedBoundingBox(out var boxMin2, out var boxMax2);
		Size3D size3D2 = new Size3D(boxMin2, boxMax2);
		double _0023_003DzccAR5G0_003D = size3D.Diagonal + size3D2.Diagonal;
		Utility._0023_003DzJrQHke2galGyBPw2iQ_003D_003D(maxGap, boxMin, boxMax);
		Utility._0023_003DzJrQHke2galGyBPw2iQ_003D_003D(maxGap, boxMin2, boxMax2);
		if (Utility.DoOverlapOrTouch(boxMin, boxMax, boxMin2, boxMax2))
		{
			if (C2 is Line)
			{
				if (Utility._0023_003Dzjkn37He1Dc0IA_0024_CNA_003D_003D((Line)C2, this, _0023_003DzccAR5G0_003D, out var _0023_003Dz348XSZM_003D, out var _0023_003DzVxmwB6Y_003D))
				{
					if (!computeParameters)
					{
						list.Add(_0023_003Dz348XSZM_003D);
						if (_0023_003DzVxmwB6Y_003D != null)
						{
							list.Add(_0023_003DzVxmwB6Y_003D);
						}
					}
					else
					{
						InterPoint item = Utility._0023_003DzOwZw6cav8LYtJDODzQ_003D_003D(this, C2, _0023_003Dz348XSZM_003D);
						list.Add(item);
						if (_0023_003DzVxmwB6Y_003D != null)
						{
							item = Utility._0023_003DzOwZw6cav8LYtJDODzQ_003D_003D(this, C2, _0023_003DzVxmwB6Y_003D);
							list.Add(item);
						}
					}
				}
				return list.ToArray();
			}
			return Utility.Intersection(this, C2, maxGap, computeParameters);
		}
		return list.ToArray();
	}

	internal static bool _0023_003DzcUx5Y7fq28Sc(Ellipse _0023_003Dzx63Fsgc_003D, double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dz736ekIs_003D, ref double _0023_003Dz_eY3Y4c_003D)
	{
		int num = 0;
		do
		{
			double num2 = _0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D;
			Vector3D vector3D = _0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(1, _0023_003Dz_eY3Y4c_003D, _0023_003Dzx63Fsgc_003D.Plane, _0023_003Dzx63Fsgc_003D.RadiusX, _0023_003Dzx63Fsgc_003D.RadiusY);
			double num3 = 0.0;
			if (!Utility.AreEqual(_0023_003DzjbqS1qE_003D, _0023_003Dz_eY3Y4c_003D, num2))
			{
				if (!_0023_003Dzx63Fsgc_003D.SubCurve(_0023_003DzjbqS1qE_003D, _0023_003Dz_eY3Y4c_003D, out var sub))
				{
					return false;
				}
				if (sub != null)
				{
					num3 = sub.Length();
				}
			}
			double num4 = num3 - _0023_003Dz736ekIs_003D;
			if (Utility.AreEqual(0.0, num4, 1.0))
			{
				return true;
			}
			double length = vector3D.Length;
			double num5 = _0023_003Dz_eY3Y4c_003D - num4 / length;
			if (Utility.AreEqual(num2, Math.PI * 2.0, num2))
			{
				while (num5 < _0023_003DzjbqS1qE_003D)
				{
					num5 = _0023_003Dz1v6oPQk_003D - (_0023_003DzjbqS1qE_003D - num5);
				}
				while (num5 > _0023_003Dz1v6oPQk_003D)
				{
					num5 = _0023_003DzjbqS1qE_003D + (num5 - _0023_003Dz1v6oPQk_003D);
				}
			}
			else if (num5 < _0023_003DzjbqS1qE_003D)
			{
				num5 = _0023_003DzjbqS1qE_003D;
			}
			else if (num5 > _0023_003Dz1v6oPQk_003D)
			{
				num5 = _0023_003Dz1v6oPQk_003D;
			}
			if (_0023_003Dz_eY3Y4c_003D == num5)
			{
				break;
			}
			_0023_003Dz_eY3Y4c_003D = num5;
		}
		while (num++ < 8);
		if (_0023_003Dz_eY3Y4c_003D >= _0023_003DzjbqS1qE_003D)
		{
			return _0023_003Dz_eY3Y4c_003D <= _0023_003Dz1v6oPQk_003D;
		}
		return false;
	}

	public virtual bool SplitAt(double t, out ICurve lower, out ICurve upper)
	{
		if (!Utility.AreEqual(t, 0.0, Math.PI * 2.0) && !Utility.AreEqual(t, Math.PI * 2.0, Math.PI * 2.0) && t > 0.0 && t < Math.PI * 2.0)
		{
			lower = new EllipticalArc(base.Plane, (Point3D)Center.Clone(), _radiusX, _radiusY, 0.0, t);
			upper = new EllipticalArc(base.Plane, (Point3D)Center.Clone(), _radiusX, _radiusY, t, Math.PI * 2.0);
			((Entity)lower).CopyAttributes(this);
			((Entity)upper).CopyAttributes(this);
			return true;
		}
		lower = null;
		upper = null;
		return false;
	}

	public bool SplitBy(Point3D pt, out ICurve lower, out ICurve upper)
	{
		ClosestPointTo(pt, out var t);
		return SplitAt(t, out lower, out upper);
	}

	public bool SplitBy(IList<Point3D> points, out ICurve[] segments)
	{
		bool result = Utility._0023_003Dz01EVtoUdEn9B(this, points, out segments);
		ICurve[] array = segments;
		for (int i = 0; i < array.Length; i++)
		{
			((Entity)array[i]).CopyAttributes(this);
		}
		return result;
	}

	public virtual bool TrimAt(double t, bool flipSide)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967794));
	}

	public virtual bool TrimBy(Point3D pt, bool flipSide)
	{
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967794));
	}

	public virtual bool ExtendAt(double t)
	{
		return false;
	}

	public virtual bool ExtendBy(Point3D pt, bool curveEnd = true)
	{
		return false;
	}

	public virtual bool Project(Point3D point, out double t)
	{
		bool flag = true;
		base.Plane.Project(point, out var s, out var t2);
		Point2D point2D = new Point2D(s, t2);
		if (point2D.X == 0.0)
		{
			if (point2D.Y == 0.0)
			{
				t = ((_radiusX <= _radiusY) ? 0.0 : (Math.PI / 2.0));
				return true;
			}
			if (point2D.Y >= _radiusY)
			{
				t = Math.PI / 2.0;
				return true;
			}
			if (point2D.Y <= 0.0 - _radiusY)
			{
				t = 4.71238898038469;
				return true;
			}
		}
		else if (point2D.Y == 0.0)
		{
			if (point2D.X >= _radiusX)
			{
				t = 0.0;
				return true;
			}
			if (point2D.X <= 0.0 - _radiusX)
			{
				t = Math.PI;
				return true;
			}
		}
		t = Math.Atan2(point2D.Y, point2D.X);
		if (t < 0.0)
		{
			t += Math.PI * 2.0;
			if (Math.PI * 2.0 <= t)
			{
				t = 0.0;
			}
		}
		if (_radiusX != _radiusY)
		{
			double num;
			double num2;
			if (point2D.X >= 0.0)
			{
				if (point2D.Y >= 0.0)
				{
					num = 0.0;
					num2 = Math.PI / 2.0;
				}
				else
				{
					num = 4.71238898038469;
					num2 = Math.PI * 2.0;
				}
			}
			else if (point2D.Y >= 0.0)
			{
				num = Math.PI / 2.0;
				num2 = Math.PI;
			}
			else
			{
				num = Math.PI;
				num2 = 4.71238898038469;
			}
			double[] array = new double[4] { _radiusX, _radiusY, point2D.X, point2D.Y };
			double _0023_003DztWSM9sF_0024cbbq = t;
			if (_0023_003DztWSM9sF_0024cbbq <= num)
			{
				_0023_003DztWSM9sF_0024cbbq = 0.9 * num + 0.1 * num2;
			}
			else if (_0023_003DztWSM9sF_0024cbbq >= num2)
			{
				_0023_003DztWSM9sF_0024cbbq = 0.9 * num2 + 0.1 * num;
			}
			_0023_003DzvRBVoWA1btg9aalflA_003D_003D(array, num, out var _0023_003DzhidJeNw_003D, out var _0023_003Dz1FOQgC8_003D);
			_0023_003DzvRBVoWA1btg9aalflA_003D_003D(array, num2, out var _0023_003DzhidJeNw_003D2, out _0023_003Dz1FOQgC8_003D);
			if (_0023_003DzhidJeNw_003D == 0.0)
			{
				t = ((num == Math.PI * 2.0) ? 0.0 : num);
				return true;
			}
			if (_0023_003DzhidJeNw_003D2 == 0.0)
			{
				t = ((num2 == Math.PI * 2.0) ? 0.0 : num2);
				return true;
			}
			double num3;
			if (_0023_003DzhidJeNw_003D > _0023_003DzhidJeNw_003D2)
			{
				num3 = num;
				num = num2;
				num2 = num3;
				num3 = _0023_003DzhidJeNw_003D;
				_0023_003DzhidJeNw_003D = _0023_003DzhidJeNw_003D2;
				_0023_003DzhidJeNw_003D2 = num3;
			}
			t = ((num == Math.PI * 2.0) ? 0.0 : num);
			int num4 = 0;
			while (true)
			{
				_0023_003DzvRBVoWA1btg9aalflA_003D_003D(array, _0023_003DztWSM9sF_0024cbbq, out num3, out _0023_003Dz1FOQgC8_003D);
				if (num3 < _0023_003DzhidJeNw_003D)
				{
					break;
				}
				if (num4 >= 100)
				{
					Point3D point3D = PointAt(num);
					if (Math.Sqrt(_0023_003DzhidJeNw_003D) <= 1E-12 || Math.Sqrt(_0023_003DzhidJeNw_003D) <= 1.490116119385E-08 * point3D.DistanceTo(Center))
					{
						return true;
					}
					Vector3D vector3D = TangentAt(num);
					Vector3D vector3D2 = Vector3D.Subtract(point3D, point);
					if (vector3D2.Normalize() && Math.Abs(vector3D2 * vector3D) <= 0.08715574274765818)
					{
						return true;
					}
					return false;
				}
				_0023_003DztWSM9sF_0024cbbq = ((num4 != 0) ? (0.5 * (num + _0023_003DztWSM9sF_0024cbbq)) : (0.5 * (num + num2)));
				if (_0023_003DztWSM9sF_0024cbbq == num)
				{
					return true;
				}
				num4++;
			}
			t = ((_0023_003DztWSM9sF_0024cbbq >= Math.PI * 2.0) ? 0.0 : _0023_003DztWSM9sF_0024cbbq);
			flag = _0023_003DzAgquiO4jsojt(_0023_003DzvRBVoWA1btg9aalflA_003D_003D, array, num, _0023_003DztWSM9sF_0024cbbq, num2, Utility._0023_003DzheSR8QM7q9ya * Utility._0023_003DzheSR8QM7q9ya, Utility._0023_003DzheSR8QM7q9ya, 100, out _0023_003DztWSM9sF_0024cbbq) > 0;
			if (flag)
			{
				t = ((_0023_003DztWSM9sF_0024cbbq >= Math.PI * 2.0) ? 0.0 : _0023_003DztWSM9sF_0024cbbq);
			}
		}
		return flag;
	}

	public virtual void ClosestPointTo(Point3D point, out double t)
	{
		Project(point, out t);
	}

	public ICurve[] GetIndividualCurves()
	{
		return new ICurve[1] { this };
	}

	private static int _0023_003DzvRBVoWA1btg9aalflA_003D_003D(double[] _0023_003DzjbqS1qE_003D, double _0023_003DzNDQ_E88_003D, out double _0023_003DzhidJeNw_003D, out double _0023_003Dz1FOQgC8_003D)
	{
		double num = Math.Cos(_0023_003DzNDQ_E88_003D);
		double num2 = Math.Sin(_0023_003DzNDQ_E88_003D);
		double num3 = num * _0023_003DzjbqS1qE_003D[0] - _0023_003DzjbqS1qE_003D[2];
		double num4 = num2 * _0023_003DzjbqS1qE_003D[1] - _0023_003DzjbqS1qE_003D[3];
		_0023_003DzhidJeNw_003D = num3 * num3 + num4 * num4;
		_0023_003Dz1FOQgC8_003D = 2.0 * (num4 * _0023_003DzjbqS1qE_003D[1] * num - num3 * _0023_003DzjbqS1qE_003D[0] * num2);
		return 0;
	}

	private int _0023_003DzAgquiO4jsojt(_0023_003DzbI4liJ6BQ8ja _0023_003DzhidJeNw_003D, double[] _0023_003DzBeP8Ndxc0aFe, double _0023_003DzC82wi0s_003D, double _0023_003DzWK94pPk_003D, double _0023_003Dzz0HVFKY_003D, double _0023_003DzaqIqUZsxwpfuAT_ThtgIMps_003D, double _0023_003DzyyBJnz4kRrnn41So1hfsvuQ_003D, int _0023_003DzI_0024UryoU_0024LQDg, out double _0023_003DztWSM9sF_0024cbbq)
	{
		double num2;
		double num = (num2 = 0.0);
		_0023_003DztWSM9sF_0024cbbq = _0023_003DzWK94pPk_003D;
		double num3 = ((_0023_003DzC82wi0s_003D < _0023_003Dzz0HVFKY_003D) ? _0023_003DzC82wi0s_003D : _0023_003Dzz0HVFKY_003D);
		double num4 = ((_0023_003DzC82wi0s_003D > _0023_003Dzz0HVFKY_003D) ? _0023_003DzC82wi0s_003D : _0023_003Dzz0HVFKY_003D);
		double num6;
		double num7;
		double num5 = (num6 = (num7 = _0023_003DzWK94pPk_003D));
		int num8 = _0023_003DzhidJeNw_003D(_0023_003DzBeP8Ndxc0aFe, num5, out var _0023_003Dzt_m8zV0_003D, out var _0023_003DzXrexKjY_003D);
		if (num8 != 0)
		{
			_0023_003DztWSM9sF_0024cbbq = num5;
			return (num8 > 0) ? 1 : 0;
		}
		double num10;
		double num9 = (num10 = _0023_003Dzt_m8zV0_003D);
		double num12;
		double num11 = (num12 = _0023_003DzXrexKjY_003D);
		while (_0023_003DzI_0024UryoU_0024LQDg-- > 0)
		{
			double num13 = 0.5 * (num3 + num4);
			double num14 = _0023_003DzaqIqUZsxwpfuAT_ThtgIMps_003D * Math.Abs(num5) + _0023_003DzyyBJnz4kRrnn41So1hfsvuQ_003D;
			double num15 = 2.0 * num14;
			if (Math.Abs(num5 - num13) <= num15 - 0.5 * (num4 - num3))
			{
				_0023_003DztWSM9sF_0024cbbq = num5;
				return 1;
			}
			double num21;
			if (Math.Abs(num2) > num14)
			{
				double num16 = 2.0 * (num4 - num3);
				double num17 = num16;
				if (num11 != _0023_003DzXrexKjY_003D)
				{
					num16 = (num6 - num5) * _0023_003DzXrexKjY_003D / (_0023_003DzXrexKjY_003D - num11);
				}
				if (num12 != _0023_003DzXrexKjY_003D)
				{
					num17 = (num7 - num5) * _0023_003DzXrexKjY_003D / (_0023_003DzXrexKjY_003D - num12);
				}
				double num18 = num5 + num16;
				double num19 = num5 + num17;
				bool flag = (num3 - num18) * (num18 - num4) > 0.0 && _0023_003DzXrexKjY_003D * num16 <= 0.0;
				bool flag2 = (num3 - num19) * (num19 - num4) > 0.0 && _0023_003DzXrexKjY_003D * num17 <= 0.0;
				double num20 = num2;
				num2 = num;
				if (flag || flag2)
				{
					num = ((flag && flag2) ? ((Math.Abs(num16) < Math.Abs(num17)) ? num16 : num17) : ((!flag) ? num17 : num16));
					if (Math.Abs(num) <= Math.Abs(0.5 * num20))
					{
						num21 = num5 + num;
						if (num21 - num3 < num15 || num4 - num21 < num15)
						{
							num = ((num13 >= num5) ? num14 : (0.0 - num14));
						}
					}
					else
					{
						num = 0.5 * (num2 = ((_0023_003DzXrexKjY_003D >= 0.0) ? (num3 - num5) : (num4 - num5)));
					}
				}
				else
				{
					num = 0.5 * (num2 = ((_0023_003DzXrexKjY_003D >= 0.0) ? (num3 - num5) : (num4 - num5)));
				}
			}
			else
			{
				num = 0.5 * (num2 = ((_0023_003DzXrexKjY_003D >= 0.0) ? (num3 - num5) : (num4 - num5)));
			}
			double _0023_003Dzt_m8zV0_003D2;
			double _0023_003DzXrexKjY_003D2;
			if (Math.Abs(num) >= num14)
			{
				num21 = num5 + num;
				num8 = _0023_003DzhidJeNw_003D(_0023_003DzBeP8Ndxc0aFe, num21, out _0023_003Dzt_m8zV0_003D2, out _0023_003DzXrexKjY_003D2);
			}
			else
			{
				num21 = ((num >= 0.0) ? (num5 + num14) : (num5 - num14));
				num8 = _0023_003DzhidJeNw_003D(_0023_003DzBeP8Ndxc0aFe, num21, out _0023_003Dzt_m8zV0_003D2, out _0023_003DzXrexKjY_003D2);
				if (num8 >= 0 && _0023_003Dzt_m8zV0_003D2 > _0023_003Dzt_m8zV0_003D)
				{
					_0023_003DztWSM9sF_0024cbbq = num5;
					return 1;
				}
			}
			if (num8 != 0)
			{
				if (num8 >= 0)
				{
					_0023_003DztWSM9sF_0024cbbq = ((_0023_003Dzt_m8zV0_003D2 < _0023_003Dzt_m8zV0_003D) ? num21 : num5);
				}
				return (num8 > 0) ? 1 : 0;
			}
			if (_0023_003Dzt_m8zV0_003D2 <= _0023_003Dzt_m8zV0_003D)
			{
				if (num21 >= num5)
				{
					num3 = num5;
				}
				else
				{
					num4 = num5;
				}
				num7 = num6;
				num10 = num9;
				num12 = num11;
				num6 = num5;
				num9 = _0023_003Dzt_m8zV0_003D;
				num11 = _0023_003DzXrexKjY_003D;
				num5 = num21;
				_0023_003Dzt_m8zV0_003D = _0023_003Dzt_m8zV0_003D2;
				_0023_003DzXrexKjY_003D = _0023_003DzXrexKjY_003D2;
				continue;
			}
			if (num21 < num5)
			{
				num3 = num21;
			}
			else
			{
				num4 = num21;
			}
			if (_0023_003Dzt_m8zV0_003D2 <= num9 || num6 == num5)
			{
				num7 = num6;
				num10 = num9;
				num12 = num11;
				num6 = num21;
				num9 = _0023_003Dzt_m8zV0_003D2;
				num11 = _0023_003DzXrexKjY_003D2;
			}
			else if (_0023_003Dzt_m8zV0_003D2 < num10 || num7 == num5 || num7 == num6)
			{
				num7 = num21;
				num10 = _0023_003Dzt_m8zV0_003D2;
				num12 = _0023_003DzXrexKjY_003D2;
			}
		}
		_0023_003DztWSM9sF_0024cbbq = num5;
		return 2;
	}

	public LinearPath ConvertToLinearPath(double deviation = 0.0, double angle = 0.0)
	{
		if (deviation == 0.0)
		{
			return _0023_003DztgI92lDISTaw0QRVK9fD0NM_003D();
		}
		Ellipse obj = (Ellipse)Clone();
		obj.Regen(new RegenParams(deviation, angle));
		return obj.ConvertToLinearPath();
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<Mesh>(amount, tolerance, meshNature);
	}

	public Mesh ExtrudeAsMesh(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<Mesh>(new Vector3D(dx, dy, dz), tolerance, meshNature);
	}

	public T ExtrudeAsMesh<T>(Vector3D amount, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(amount, tolerance, meshNature);
	}

	public T ExtrudeAsMesh<T>(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D<T>(new Vector3D(dx, dy, dz), tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<Mesh>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<Mesh>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<T>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D<T>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public Mesh SweepAsMesh(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		Mesh[] array = _0023_003Dz789GXCk_003D<Mesh>(rail, tol, methodType, meshNature, _0023_003DzjepEGXc_003D: true);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		T[] array = _0023_003Dz789GXCk_003D<T>(rail, tol, methodType, meshNature, _0023_003DzjepEGXc_003D: true);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Mesh[] SweepAsMesh(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth)
	{
		return _0023_003Dz789GXCk_003D<Mesh>(rail, tol, methodType, meshNature, merge);
	}

	public T[] SweepAsMesh<T>(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		return _0023_003Dz789GXCk_003D<T>(rail, tol, methodType, meshNature, merge);
	}

	public Surface[] ExtrudeAsSurface(Line line)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(line.Direction);
	}

	public Surface[] ExtrudeAsSurface(double dx, double dy, double dz)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(new Vector3D(dx, dy, dz));
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount);
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount, double draftAngleInRadians, double tolerance)
	{
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount);
		}
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Normalize();
		Curve nurbsForm = GetNurbsForm();
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, draftAngleInRadians);
		Curve _0023_003Dz6nnnQo75Qjsf;
		Curve curve = nurbsForm._0023_003Dz3JJdLbUPbfbS(offsetDistance, vector3D, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: true, out _0023_003Dz6nnnQo75Qjsf);
		curve.Translate(amount);
		return new Surface[1] { Surface.Ruled(_0023_003Dz6nnnQo75Qjsf, curve) };
	}

	public Brep ExtrudeAsBrep(Line line, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, line.Direction, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep ExtrudeAsBrep(double dx, double dy, double dz, double tolerance = 0.0)
	{
		return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, new Vector3D(dx, dy, dz), _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public virtual Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (Math.Abs(draftAngleInRadians) > 1.5707963257948965)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955152));
		}
		if (Utility.AreEqual(0.0, draftAngleInRadians, Math.PI * 2.0))
		{
			return Brep._0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(this, null, amount, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D: false, tolerance);
		}
		Vector3D vector3D = (Vector3D)amount.Clone();
		vector3D.Normalize();
		Curve nurbsForm = GetNurbsForm();
		double offsetDistance = Entity.GetOffsetDistance(vector3D, amount, draftAngleInRadians);
		Curve _0023_003Dz6nnnQo75Qjsf;
		Curve curve = nurbsForm._0023_003Dz3JJdLbUPbfbS(offsetDistance, vector3D, _0023_003Dzys_6_0024WmuuZ6Mzp_FbA_003D_003D: true, out _0023_003Dz6nnnQo75Qjsf);
		curve.Translate(amount);
		Point3D[] array = new Brep.Vertex[2];
		Point3D[] array2 = array;
		array2[0] = new Brep.Vertex(_0023_003Dz6nnnQo75Qjsf.StartPoint.X, _0023_003Dz6nnnQo75Qjsf.StartPoint.Y, _0023_003Dz6nnnQo75Qjsf.StartPoint.Z);
		array2[1] = new Brep.Vertex(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
		Brep.Edge[] edges = new Brep.Edge[3]
		{
			new Brep.Edge((ICurve)_0023_003Dz6nnnQo75Qjsf.Clone(), 0, 0),
			new Brep.Edge((ICurve)curve.Clone(), 1, 1),
			new Brep.Edge(new Line((Point3D)array2[0].Clone(), (Point3D)array2[1].Clone()), 0, 1)
		};
		Brep.OrientedEdge[] segments = new Brep.OrientedEdge[4]
		{
			new Brep.OrientedEdge(0),
			new Brep.OrientedEdge(2),
			new Brep.OrientedEdge(1, sense: false),
			new Brep.OrientedEdge(2, sense: false)
		};
		Surface surface = Surface.Ruled(_0023_003Dz6nnnQo75Qjsf, curve);
		NurbsSurf surface2 = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints);
		return new Brep(array2, edges, new Brep.Face[1]
		{
			new Brep.Face(surface2, new Brep.Loop(segments))
		}, null, tolerance);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis, center);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Line axis)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis.Direction, axis.StartPoint);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, startAngle, deltaAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Brep._0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(this, null, intervalAngle, axis, center, _0023_003DzbErHvVw_003D: false, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return RevolveAsBrep(intervalAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, tolerance);
	}

	public Brep RevolveAsBrep(double startAngle, double deltaAngle, Line axis, double tolerance = 0.0)
	{
		return RevolveAsBrep(startAngle, deltaAngle, axis.Direction, axis.StartPoint, tolerance);
	}

	public Brep RevolveAsBrep(Interval intervalAngle, Line axis, double tolerance = 0.0)
	{
		return RevolveAsBrep(intervalAngle, axis.Direction, axis.StartPoint, tolerance);
	}

	public Surface[] SweepAsSurface(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003Dz789GXCk_003D(rail, tol, methodType);
	}

	public Brep SweepAsBrep(ICurve rail, double tolerance, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Brep[] array = Brep._0023_003Dz1A9iP9WIToC5(rail, this, null, tolerance, _0023_003DzbErHvVw_003D: false, _0023_003DzjepEGXc_003D: true, methodType);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Brep[] SweepAsBrep(ICurve rail, double tolerance, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return Brep._0023_003Dz1A9iP9WIToC5(rail, this, null, tolerance, _0023_003DzbErHvVw_003D: false, merge, methodType);
	}

	public Solid ExtrudeAsSolid(Vector3D amount, double tolerance)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(amount, tolerance);
	}

	public Solid ExtrudeAsSolid(double dx, double dy, double dz, double tolerance)
	{
		return _0023_003Dz_r7oN51KQAA_0024CY5Ppw_003D_003D(new Vector3D(dx, dy, dz), tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(intervalAngle.Low, intervalAngle.Length, axis, center, slices, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return _0023_003DzDj8PtdJ_uqiEolHf0Q_003D_003D(intervalAngle.Low, intervalAngle.Length, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid SweepAsSolid(ICurve rail, double tol, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		Solid[] array = _0023_003DzggPwIWi3oqtM(rail, tol, _0023_003DzjepEGXc_003D: true, sweepMethod);
		if (array == null)
		{
			return null;
		}
		return array[0];
	}

	public Solid[] SweepAsSolid(ICurve rail, double tol, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return _0023_003DzggPwIWi3oqtM(rail, tol, merge, sweepMethod);
	}

	public Vector3D[] Evaluate(double u, int d)
	{
		Vector3D[] array = new Vector3D[d + 1];
		for (int i = 0; i < d + 1; i++)
		{
			array[i] = _0023_003Dz4Kz0qHm3qFfWJeisxY_ewk0_003D(i, u, base.Plane, _radiusX, _radiusY);
		}
		return array;
	}

	public void GetApproximatedBoundingBox(out Point3D boxMin, out Point3D boxMax)
	{
		GetTightBBox(out boxMin, out boxMax);
	}

	protected internal override void Draw(DrawParams data)
	{
		DrawWire(data);
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		Draw(data);
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		Utility.DrawArrowOnView(data, EndTangent, EndPoint);
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		CompileWire(data);
		RegenMode = regenType.NotNeeded;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = _0023_003DzuAMveDQA6vvk()[0];
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		double radiusX = RadiusX;
		double radiusY = RadiusY;
		double _0023_003DzjbqS1qE_003D = 1.0 / (radiusX * radiusX);
		double _0023_003Dzt_m8zV0_003D = 1.0 / (radiusY * radiusY);
		Transformation transformation = new Transformation(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisY, base.Plane.AxisZ);
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = new _0023_003Dzdqr8UI0Jipc_0024TuuKDhHIJvVq3Tj138M0mHUw_gY_003D(_0023_003DzjbqS1qE_003D, 0.0, _0023_003Dzt_m8zV0_003D, 0.0, 0.0, -1.0, radiusX, 0.0, radiusX, 0.0, transformation.Matrix, ColorMethod == colorMethodType.byEntity, LayerName, Color, _0023_003Dz_KjZG5vEM9v9: false);
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1] { _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 };
	}

	internal override bool _0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzD5Gs7jmmc9uK, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		if (!_0023_003DzjZRgeJk_003D || _localOB == null)
		{
			_localOB = new OrientedBoundingRect(base.Plane.Origin - base.Plane.AxisX * RadiusX - base.Plane.AxisY * RadiusY, new Vector2D(base.Plane.AxisX.X, base.Plane.AxisX.Y), new Vector2D(base.Plane.AxisY.X, base.Plane.AxisY.Y), RadiusX * 2.0, RadiusY * 2.0);
		}
		base._0023_003Dzx8kz5PbHANjMBSWqdAepaxo_003D(_0023_003DzELu0Pss_003D, out _0023_003DzrdSL0CI_003D, out _0023_003DzD5Gs7jmmc9uK, out _0023_003DzHhJEwwk_003D, _0023_003DzjZRgeJk_003D: true);
		return true;
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003Dz0LctmUj4I00X_0024hFVBQ_003D_003D _0023_003Dz0LctmUj4I00X_0024hFVBQ_003D_003D2 = new _0023_003Dz0LctmUj4I00X_0024hFVBQ_003D_003D(base.Plane.Origin.ToArray(), RadiusX, RadiusY, base.Plane.AxisX.ToArray(), base.Plane.AxisY.ToArray());
		_0023_003DzYe_6EnQecc8d(_0023_003Dz0LctmUj4I00X_0024hFVBQ_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003Dz0LctmUj4I00X_0024hFVBQ_003D_003D2 };
	}
}
