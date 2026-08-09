using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class RevolvedSurface : Surface
{
	private ICurve _generatrix;

	private Plane _seamPlane;

	internal Curve nurbsGeneratrix;

	internal Arc revArc;

	internal Curve nurbsRevArc;

	internal double scaleU = 1.0;

	internal double scaleV = 1.0;

	public ICurve Generatrix => _generatrix;

	public Point3D Center => _seamPlane.Origin;

	public Vector3D Axis => _seamPlane.AxisY;

	public Interval Angle => base.DomainU;

	public Plane SeamPlane => _seamPlane;

	public Plane Plane => new Plane(_seamPlane.Origin, _seamPlane.AxisX, -1.0 * _seamPlane.AxisZ);

	public RevolvedSurface(int uDegree, double[] uKnotVector, int vDegree, double[] vKnotVector, Point4D[,] ctrlPoints, ICurve generatrix, Plane seamPlane)
	{
		_0023_003Dzk__0024yqBPiVV__(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints);
		_generatrix = generatrix;
		_seamPlane = seamPlane;
		ICurve _0023_003DzCqUI6VbvL79X = IsocurveU(base.DomainV.Low);
		ICurve _0023_003DzzmPi46a_0024aQ2V = IsocurveV(base.DomainU.High);
		ICurve curve = IsocurveU(base.DomainV.High);
		curve.Reverse();
		ICurve curve2 = IsocurveV(base.DomainU.Low);
		curve2.Reverse();
		base.Trimming = _0023_003Dzrkte6ryoSSy1(base.DomainU.Low, base.DomainV.Low, base.DomainU.High, base.DomainV.High, _0023_003DzCqUI6VbvL79X, _0023_003DzzmPi46a_0024aQ2V, curve, curve2);
	}

	protected RevolvedSurface(RevolvedSurface another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_generatrix = (ICurve)another._generatrix.Clone();
		_seamPlane = (Plane)another._seamPlane.Clone();
		scaleU = another.scaleU;
		scaleV = another.scaleV;
	}

	protected internal RevolvedSurface(RevolvedSurfaceSurrogate surrogate)
		: this(surrogate.GetP(), surrogate.GetU(), surrogate.GetQ(), surrogate.GetV(), surrogate.GetPw(), surrogate.GetGeneratrix() as ICurve, surrogate.GetSeamPlane())
	{
	}

	public RevolvedSurface(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_seamPlane = (Plane)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976237), typeof(Plane));
		_generatrix = (ICurve)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976224), typeof(ICurve));
	}

	public override object Clone()
	{
		return new RevolvedSurface(this);
	}

	public override object CloneWithTessellation()
	{
		return new RevolvedSurface(this, RegenMode != regenType.RegenAndCompile);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976207) + Center);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976169) + Axis);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976129) + Angle.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955169) + Utility.RadToDeg(Angle.t0) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + Utility.RadToDeg(Angle.t1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955182));
		stringBuilder.AppendLine(Environment.NewLine);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976224));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.Append(((Entity)_generatrix).Dump(linearUnits, massUnits, layers, materials, blocks));
		return stringBuilder.ToString();
	}

	internal override AnalyticSurf _0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D()
	{
		return new RevolvedSurf((Point3D)Center.Clone(), (Vector3D)Axis.Clone(), (Vector3D)SeamPlane.AxisX.Clone(), (ICurve)_generatrix.Clone());
	}

	public override bool IsOnSeamU(ICurve curve, double tol = 0.0)
	{
		if (!_0023_003DzCq59RVw_003D)
		{
			return false;
		}
		Curve nurbsForm = curve.GetNurbsForm();
		Segment3D seg = new Segment3D(Center, Center + Axis);
		double num = 0.0;
		if (tol == 0.0)
		{
			Point4D[] pw = nurbsForm.Pw;
			for (int i = 0; i < pw.Length; i++)
			{
				double num2 = pw[i].Euclid.DistanceTo(seg);
				if (num2 > num)
				{
					num = num2;
				}
			}
			tol = num * 1E-05;
		}
		return _0023_003DzFLnWSp0IHNMRZ1NNctVU0C8_003D(nurbsForm, tol);
	}

	private bool _0023_003DzFLnWSp0IHNMRZ1NNctVU0C8_003D(Curve _0023_003Dzozi9I9M_003D, double _0023_003Dzm0CYiiE_003D)
	{
		int num = 0;
		Point4D[] pw = _0023_003Dzozi9I9M_003D.Pw;
		for (int i = 0; i < pw.Length; i++)
		{
			Point3D euclid = pw[i].Euclid;
			SeamPlane.Project(euclid, out var s, out var _);
			if (s >= 0.0 - Utility._0023_003DzheSR8QM7q9ya && Math.Abs(SeamPlane.DistanceTo(euclid)) < _0023_003Dzm0CYiiE_003D)
			{
				num++;
			}
		}
		if (num == _0023_003Dzozi9I9M_003D._0023_003DzMv2C5Tm1QMvc())
		{
			return true;
		}
		return false;
	}

	internal static bool _0023_003DzEePbTg3jDjyLcUHYsuGBkXc_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz6pajdGM_003D, Plane _0023_003Dzpyw2kZk_003D, Surface _0023_003Dz_0024KKopL9T7nzT)
	{
		Curve nurbsForm = _0023_003Dz8fpRyMu9aKjE.GetNurbsForm();
		int num = nurbsForm.Pw.Length;
		Transformation xform = new Rotation(0.0 - _0023_003Dz6pajdGM_003D, Vector3D.AxisZ, Point3D.Origin);
		Point2D point2D = _0023_003Dzpyw2kZk_003D.Project(nurbsForm.Pw[0].Euclid);
		point2D.TransformBy(xform);
		nurbsForm.ControlBoundingBox(out var min, out var max);
		double num2 = Math.Sqrt(new Size3D(min, max).Diagonal) * 1E-12;
		if (point2D.DistanceTo(Point2D.Origin) < num2)
		{
			return true;
		}
		for (int i = 1; i < num; i++)
		{
			Point2D point2D2 = _0023_003Dzpyw2kZk_003D.Project(nurbsForm.Pw[i].Euclid);
			point2D2.TransformBy(xform);
			if (_0023_003DzmgoKKO26S1hDH_0024wdySsmtAU_003D(point2D, point2D2))
			{
				return true;
			}
			point2D = point2D2;
		}
		return false;
	}

	internal static bool _0023_003Dzn1ibPKOvoEFIUB0PQGYsJtA_003D(Plane _0023_003Dzpyw2kZk_003D, Plane _0023_003DzjDNJ3umjT6Lf, ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003Dz6pajdGM_003D)
	{
		Curve nurbsForm = _0023_003Dz8fpRyMu9aKjE.GetNurbsForm();
		int num = nurbsForm.Pw.Length;
		Transformation xform = new Rotation(0.0 - _0023_003Dz6pajdGM_003D, Vector3D.AxisZ, Point3D.Origin);
		Point3D euclid = nurbsForm.Pw[0].Euclid;
		Vector2D asVector = _0023_003Dzpyw2kZk_003D.Project(euclid).AsVector;
		asVector.Normalize();
		euclid.TransformBy(new Rotation(0.0 - asVector.Angle, _0023_003Dzpyw2kZk_003D.AxisZ, _0023_003Dzpyw2kZk_003D.Origin));
		Point2D point2D = _0023_003DzjDNJ3umjT6Lf.Project(euclid);
		point2D.TransformBy(xform);
		for (int i = 1; i < num; i++)
		{
			Point3D euclid2 = nurbsForm.Pw[i].Euclid;
			asVector = _0023_003Dzpyw2kZk_003D.Project(euclid2).AsVector;
			asVector.Normalize();
			euclid2.TransformBy(new Rotation(0.0 - asVector.Angle, _0023_003Dzpyw2kZk_003D.AxisZ, _0023_003Dzpyw2kZk_003D.Origin));
			Point2D point2D2 = _0023_003DzjDNJ3umjT6Lf.Project(euclid2);
			point2D2.TransformBy(xform);
			if (_0023_003DzmgoKKO26S1hDH_0024wdySsmtAU_003D(point2D, point2D2))
			{
				return true;
			}
			point2D = point2D2;
		}
		return false;
	}

	private static bool _0023_003DzmgoKKO26S1hDH_0024wdySsmtAU_003D(Point2D _0023_003Dz1BPEjBg_003D, Point2D _0023_003Dz3Ftsho0_003D)
	{
		if (_0023_003Dz1BPEjBg_003D.Y * _0023_003Dz3Ftsho0_003D.Y < 1E-12 && (_0023_003Dz1BPEjBg_003D.X > 0.0 || _0023_003Dz3Ftsho0_003D.X > 0.0) && (_0023_003Dz1BPEjBg_003D.X * _0023_003Dz3Ftsho0_003D.X > 0.0 || _0023_003Dz1BPEjBg_003D.X + ((0.0 - _0023_003Dz3Ftsho0_003D.X) * _0023_003Dz1BPEjBg_003D.Y + _0023_003Dz1BPEjBg_003D.X * _0023_003Dz1BPEjBg_003D.Y) / (_0023_003Dz3Ftsho0_003D.Y - _0023_003Dz1BPEjBg_003D.Y) > 0.0))
		{
			return true;
		}
		return false;
	}

	public override bool IsOnSeamV(ICurve curve, double tol = 0.0)
	{
		if (_0023_003Dzoa6bboA_003D && this is ToroidalSurface)
		{
			ToroidalSurface toroidalSurface = (ToroidalSurface)this;
			double num = Math.Max(toroidalSurface.MajorRadius, toroidalSurface.MinorRadius);
			if (tol == 0.0)
			{
				tol = num * Utility._0023_003DzxhnLabVjXjPg;
			}
			double a;
			Point3D center;
			Vector3D axisZ;
			if (curve is Circle)
			{
				a = ((Circle)curve).Radius;
				center = ((Circle)curve).Center;
				axisZ = ((Circle)curve).Plane.AxisZ;
			}
			else
			{
				if (!(curve is Ellipse) || !((Ellipse)curve).IsCircle)
				{
					return base.IsOnSeamV(curve, tol);
				}
				a = ((Ellipse)curve).RadiusX;
				center = ((Ellipse)curve).Center;
				axisZ = ((Ellipse)curve).Plane.AxisZ;
			}
			if (center != null)
			{
				Segment3D seg = new Segment3D(Center, Center + Axis);
				double b = base.SeamV.StartPoint.DistanceTo(seg);
				if (Vector3D.AreParallel(Axis, axisZ) && Utility.AreEqual(a, b, num))
				{
					_seamPlane.Project(base.SeamV.StartPoint, out var _, out var t);
					_seamPlane.Project(curve.StartPoint, out var _, out var t2);
					if (Utility.Compare(tol, t, t2) == 0)
					{
						return true;
					}
				}
			}
			return false;
		}
		return base.IsOnSeamV(curve, tol);
	}

	public override void TransformBy(Transformation xform)
	{
		if (_generatrix is CompositeCurve)
		{
			CompositeCurve compositeCurve = (CompositeCurve)_generatrix;
			ICurve[] array = new ICurve[compositeCurve.CurveList.Count];
			for (int i = 0; i < compositeCurve.CurveList.Count; i++)
			{
				ICurve _0023_003Dz8fpRyMu9aKjE = compositeCurve.CurveList[i];
				array[i] = _0023_003DzF0LQtrYJkPzE(_0023_003Dz8fpRyMu9aKjE, xform);
			}
			_generatrix = new CompositeCurve(array);
		}
		else
		{
			ICurve generatrix = _0023_003DzF0LQtrYJkPzE(_generatrix, xform);
			_generatrix = generatrix;
		}
		_seamPlane.TransformBy(xform);
		base.TransformBy(xform);
		if (xform.HasReflection)
		{
			_seamPlane = new Plane(_seamPlane.Origin, _seamPlane.AxisX, -1.0 * _seamPlane.AxisY);
			if (this is ConicalSurface)
			{
				((ConicalSurface)this).halfAngle = 0.0 - ((ConicalSurface)this).HalfAngle;
			}
		}
		if (revArc != null)
		{
			revArc = new Arc(new Plane(_seamPlane.Origin, _seamPlane.AxisX, _seamPlane.AxisZ), _seamPlane.Origin, 10.0, (0.0 - Angle.t0) / scaleU, (0.0 - Angle.t1) / scaleU);
			nurbsRevArc = revArc.GetNurbsForm();
		}
		if (nurbsGeneratrix != null)
		{
			nurbsGeneratrix = _generatrix.GetNurbsForm();
		}
		if (this is ToroidalSurface && ((ToroidalSurface)this)._degeneratedTorus != null)
		{
			((ToroidalSurface)this)._degeneratedTorus.TransformBy(xform);
		}
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new RevolvedSurfaceSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976237), _seamPlane);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976224), _generatrix);
	}

	public override bool IsPlanar(double tol, out Plane plane)
	{
		return base.IsPlanar(tol, out plane);
	}

	public override bool Project(Point3D P, double coincTol, bool allowOutside, out double u, out double v)
	{
		Point3D uAndRotation = GetUAndRotation(P, coincTol, allowOutside, out u);
		if (uAndRotation == null)
		{
			return base.Project(P, coincTol, allowOutside, out u, out v);
		}
		nurbsGeneratrix = _0023_003DzsZ8Z_M1X5U0GbQ2SWWoHGfELK6XE();
		if (!nurbsGeneratrix.Project(uAndRotation, coincTol, allowOutside, out v) && !allowOutside)
		{
			nurbsGeneratrix.ClosestPointTo(uAndRotation, out v);
		}
		v *= scaleV;
		return _0023_003DzhM2gxPHDylsG(P, coincTol, u, v);
	}

	protected Point3D GetUAndRotation(Point3D P, double coincTol, bool allowOutside, out double u)
	{
		_0023_003DzeS3wBn4FObIHz9jfayb_coo_003D(_0023_003DzYd_82710IqfH: false);
		Point3D point3D = (Point3D)P.Clone();
		revArc.Project(point3D, out u);
		Transformation xform = new Rotation(0.0 - u, SeamPlane.AxisY, SeamPlane.Origin);
		point3D.TransformBy(xform);
		u *= scaleU;
		return point3D;
	}

	protected Point3D GetUAndRotation(Point3D P, out double u)
	{
		_0023_003DzeS3wBn4FObIHz9jfayb_coo_003D(_0023_003DzYd_82710IqfH: false);
		Point3D point3D = (Point3D)P.Clone();
		revArc.ClosestPointTo(point3D, out u);
		Transformation xform = new Rotation(0.0 - u, SeamPlane.AxisY, SeamPlane.Origin);
		point3D.TransformBy(xform);
		Utility.LimitRange(revArc.Domain.t0, ref u, revArc.Domain.t1);
		u *= scaleU;
		return point3D;
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v)
	{
		Point3D uAndRotation = GetUAndRotation(P, out u);
		nurbsGeneratrix = _0023_003DzsZ8Z_M1X5U0GbQ2SWWoHGfELK6XE();
		nurbsGeneratrix.ClosestPointTo(uAndRotation, out v);
		v *= scaleV;
		Point3D b = PointAt(u, v);
		if (Point3D.DistanceSquared(P, b) > coincTol * coincTol)
		{
			return false;
		}
		return true;
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v, out Vector2D W)
	{
		bool num = PointInversion(P, coincTol, out u, out v);
		W = null;
		if (num && P is PointTangent pt)
		{
			Vector3D[,] array = Evaluate(u, v, 1);
			Vector3D su = array[1, 0];
			Vector3D sv = array[0, 1];
			Surface.TangentVectorInversion(pt, su, sv, out W);
		}
		return num;
	}

	internal void _0023_003DzeVdMxiELXEc151iyuw_003D_003D(double _0023_003Dz_eY3Y4c_003D, double _0023_003Dz77g161c_003D, out double _0023_003Dz1joHRKl_0024Y4Ai, out double _0023_003DzatDUqTofKijn)
	{
		_0023_003DzeS3wBn4FObIHz9jfayb_coo_003D(_0023_003DzYd_82710IqfH: false);
		revArc.GetNurbsFormParameterFromRadian(_0023_003Dz_eY3Y4c_003D, out _0023_003Dz1joHRKl_0024Y4Ai, nurbsRevArc);
		_0023_003DzatDUqTofKijn = _0023_003Dz77g161c_003D;
		if (Generatrix is Arc)
		{
			_0023_003DzsZ8Z_M1X5U0GbQ2SWWoHGfELK6XE();
			((Arc)Generatrix).GetNurbsFormParameterFromRadian(_0023_003Dz77g161c_003D, out _0023_003DzatDUqTofKijn, nurbsGeneratrix);
		}
	}

	internal void _0023_003Dz9RFxeLB87sIedeZWLg_003D_003D(double _0023_003Dz1joHRKl_0024Y4Ai, double _0023_003DzatDUqTofKijn, out double _0023_003Dz_eY3Y4c_003D, out double _0023_003Dz77g161c_003D)
	{
		_0023_003DzatDUqTofKijn = Generatrix.Domain.Low - base.DomainV.Low / scaleV + _0023_003DzatDUqTofKijn / scaleV;
		_0023_003DzeS3wBn4FObIHz9jfayb_coo_003D(_0023_003DzYd_82710IqfH: false);
		revArc.GetRadianFromNurbFormParameter(_0023_003Dz1joHRKl_0024Y4Ai, out _0023_003Dz_eY3Y4c_003D, nurbsRevArc);
		_0023_003Dz77g161c_003D = _0023_003DzatDUqTofKijn;
		if (Generatrix is Arc)
		{
			nurbsGeneratrix = _0023_003DzsZ8Z_M1X5U0GbQ2SWWoHGfELK6XE();
			((Arc)Generatrix).GetRadianFromNurbFormParameter(_0023_003DzatDUqTofKijn, out _0023_003Dz77g161c_003D, nurbsGeneratrix);
		}
	}

	public override Point3D Evaluate(double uNurbs, double vNurbs)
	{
		Vector3D[,] array = Evaluate(uNurbs, vNurbs, 0);
		return new Point3D(array[0, 0].X, array[0, 0].Y, array[0, 0].Z);
	}

	public override Vector3D[,] Evaluate(double u, double v, int d)
	{
		v = Generatrix.Domain.Low - base.DomainV.Low / scaleV + v / scaleV;
		return _0023_003DzCfBKshBDES_EHnFxtg_003D_003D(u / scaleU, v, d);
	}

	public override bool ExtendAtU(double u)
	{
		if (u > base.DomainU.Low && !Utility.AreEqual(u, base.DomainU.Low, base.DomainU.Length) && u < base.DomainU.High && !Utility.AreEqual(u, base.DomainU.High, base.DomainU.Length))
		{
			return false;
		}
		if (u > base.DomainU.High)
		{
			RevolvedSurface _0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D = (RevolvedSurface)_generatrix.RevolveAsSurface(Angle.Low, u - Angle.Low, Axis, Center)[0];
			_0023_003Dz1BpTHWtTaxTUlCtlbrovK_M_003D(_0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D);
			return true;
		}
		RevolvedSurface _0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D2 = (RevolvedSurface)_generatrix.RevolveAsSurface(u, Angle.High - u, Axis, Center)[0];
		_0023_003Dz1BpTHWtTaxTUlCtlbrovK_M_003D(_0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D2);
		return true;
	}

	private void _0023_003Dz1BpTHWtTaxTUlCtlbrovK_M_003D(RevolvedSurface _0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D)
	{
		bool isTrimmed = base.IsTrimmed;
		_0023_003Dzk__0024yqBPiVV__(_0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D.DegreeU, _0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D.KnotVectorU, _0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D.DegreeV, _0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D.KnotVectorV, _0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D.ControlPoints);
		ICurve _0023_003DzCqUI6VbvL79X = IsocurveU(base.DomainV.Low);
		ICurve _0023_003DzzmPi46a_0024aQ2V = IsocurveV(base.DomainU.High);
		ICurve curve = IsocurveU(base.DomainV.High);
		curve.Reverse();
		ICurve curve2 = IsocurveV(base.DomainU.Low);
		curve2.Reverse();
		if (!isTrimmed)
		{
			base.Trimming = _0023_003Dzrkte6ryoSSy1(base.DomainU.Low, base.DomainV.Low, base.DomainU.High, base.DomainV.High, _0023_003DzCqUI6VbvL79X, _0023_003DzzmPi46a_0024aQ2V, curve, curve2);
		}
		_0023_003Dz7roAELUN1jwt();
	}

	public override bool ExtendAtV(double v)
	{
		if (!_generatrix.ExtendAt(v))
		{
			return false;
		}
		RevolvedSurface _0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D = (RevolvedSurface)_generatrix.RevolveAsSurface(Angle.Low, Angle.Length, Axis, Center)[0];
		_0023_003Dz1BpTHWtTaxTUlCtlbrovK_M_003D(_0023_003DzrcvHYAPVl81u7aWCmQ_003D_003D);
		return true;
	}

	private Vector3D[,] _0023_003DzCfBKshBDES_EHnFxtg_003D_003D(double _0023_003Dz_eY3Y4c_003D, double _0023_003Dz77g161c_003D, int _0023_003DzXrexKjY_003D)
	{
		Vector3D[,] array = new Vector3D[_0023_003DzXrexKjY_003D + 1, _0023_003DzXrexKjY_003D + 1];
		Vector3D[] array2;
		if (_generatrix is IEvaluable && !(_generatrix is CompositeCurve) && !(_generatrix is Ellipse))
		{
			array2 = ((IEvaluable)_generatrix).Evaluate(_0023_003Dz77g161c_003D, _0023_003DzXrexKjY_003D);
		}
		else
		{
			nurbsGeneratrix = _0023_003DzsZ8Z_M1X5U0GbQ2SWWoHGfELK6XE();
			array2 = nurbsGeneratrix.Evaluate(_0023_003Dz77g161c_003D, _0023_003DzXrexKjY_003D);
		}
		Vector2D[] array3 = new Vector2D[array2.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			Vector3D vector3D = array2[i];
			Point2D point2D = ((i != 0) ? SeamPlane.Project(SeamPlane.Origin + vector3D) : SeamPlane.Project(vector3D.AsPoint));
			array3[i] = point2D.AsVector;
		}
		for (int j = 0; j <= _0023_003DzXrexKjY_003D; j++)
		{
			for (int k = 0; k <= _0023_003DzXrexKjY_003D - j; k++)
			{
				double num = 0.0;
				double num2 = 0.0;
				switch (Math.Abs(j) % 4)
				{
				case 0:
					num = Math.Cos(_0023_003Dz_eY3Y4c_003D) / (Math.Pow(scaleU, j) * Math.Pow(scaleV, k));
					num2 = Math.Sin(_0023_003Dz_eY3Y4c_003D) / (Math.Pow(scaleU, j) * Math.Pow(scaleV, k));
					break;
				case 1:
					num = (0.0 - Math.Sin(_0023_003Dz_eY3Y4c_003D)) / (Math.Pow(scaleU, j) * Math.Pow(scaleV, k));
					num2 = Math.Cos(_0023_003Dz_eY3Y4c_003D) / (Math.Pow(scaleU, j) * Math.Pow(scaleV, k));
					break;
				case 2:
					num = (0.0 - Math.Cos(_0023_003Dz_eY3Y4c_003D)) / (Math.Pow(scaleU, j) * Math.Pow(scaleV, k));
					num2 = (0.0 - Math.Sin(_0023_003Dz_eY3Y4c_003D)) / (Math.Pow(scaleU, j) * Math.Pow(scaleV, k));
					break;
				case 3:
					num = Math.Sin(_0023_003Dz_eY3Y4c_003D) / (Math.Pow(scaleU, j) * Math.Pow(scaleV, k));
					num2 = (0.0 - Math.Cos(_0023_003Dz_eY3Y4c_003D)) / (Math.Pow(scaleU, j) * Math.Pow(scaleV, k));
					break;
				}
				double num3 = ((j == 0) ? (array3[k].Y / Math.Pow(scaleV, k)) : 0.0);
				array[j, k] = array3[k].X * num * SeamPlane.AxisX + array3[k].X * num2 * -1.0 * SeamPlane.AxisZ + num3 * SeamPlane.AxisY;
				if (j == 0 && k == 0)
				{
					Vector3D[,] array4 = array;
					int num4 = j;
					int num5 = k;
					array4[num4, num5] += new Vector3D(Point3D.Origin, SeamPlane.Origin);
				}
			}
		}
		return array;
	}

	public override Vector3D NormalAt(double u, double v)
	{
		new Vector3D();
		Transformation xform = new Rotation(u / scaleU, _seamPlane.AxisY, _seamPlane.Origin);
		nurbsGeneratrix = _0023_003DzsZ8Z_M1X5U0GbQ2SWWoHGfELK6XE();
		Vector3D vector3D = nurbsGeneratrix.TangentAt(v / scaleV);
		vector3D.TransformBy(xform);
		Vector3D vector3D2 = -1.0 * _seamPlane.AxisZ;
		vector3D2.TransformBy(xform);
		Vector3D vector3D3 = Vector3D.Cross(vector3D2, vector3D);
		vector3D3.Normalize();
		return vector3D3;
	}

	public override void ReverseU()
	{
		Mirror xform = new Mirror(new Plane(new Point3D(base.DomainU.Low + (base.DomainU.High - base.DomainU.Low) / 2.0, 0.0, 0.0), Vector3D.AxisY, Vector3D.AxisZ));
		foreach (ICurve contour in base.Trimming.ContourList)
		{
			ICurve[] individualCurves = contour.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				TrimCurve obj = (TrimCurve)individualCurves[i];
				obj.TransformBy(xform);
				obj.Translate(Math.PI * 2.0 * scaleU - Angle.t1 - Angle.t0, 0.0);
			}
			contour.Reverse();
		}
		Mirror xform2 = new Mirror(new Plane(_seamPlane.Origin, _seamPlane.AxisZ, _seamPlane.AxisX));
		_seamPlane.TransformBy(xform2);
		for (int j = 0; j < _0023_003Dz_0024Cc_PmC_0024ZTq7(); j++)
		{
			int num = _0023_003DzMv2C5Tm1QMvc() - 1;
			for (int k = 0; k < _0023_003DzMv2C5Tm1QMvc() / 2; k++)
			{
				Point4D point4D = Pw[k, j];
				Pw[k, j] = Pw[num, j];
				Pw[num, j] = point4D;
				num--;
			}
		}
		_0023_003DziP9fFuA_003D.Reverse(Math.PI * 2.0 * scaleU);
		if (this is ConicalSurface)
		{
			((ConicalSurface)this).halfAngle = 0.0 - ((ConicalSurface)this).HalfAngle;
		}
		_0023_003DzeS3wBn4FObIHz9jfayb_coo_003D(_0023_003DzYd_82710IqfH: true);
		RegenMode = regenType.RegenAndCompile;
	}

	public override void ReverseV()
	{
		_generatrix.Reverse();
		if (nurbsGeneratrix != null)
		{
			nurbsGeneratrix = _generatrix.GetNurbsForm();
		}
		base.ReverseV();
	}

	internal Curve _0023_003DzsZ8Z_M1X5U0GbQ2SWWoHGfELK6XE()
	{
		if (nurbsGeneratrix == null)
		{
			nurbsGeneratrix = _generatrix.GetNurbsForm();
		}
		return nurbsGeneratrix;
	}

	internal void _0023_003DzeS3wBn4FObIHz9jfayb_coo_003D(bool _0023_003DzYd_82710IqfH)
	{
		if (_0023_003DzYd_82710IqfH || revArc == null)
		{
			revArc = new Arc(new Plane(_seamPlane.Origin, _seamPlane.AxisX, _seamPlane.AxisZ), _seamPlane.Origin, 10.0, (0.0 - Angle.t0) / scaleU, (0.0 - Angle.t1) / scaleU);
			nurbsRevArc = revArc.GetNurbsForm();
		}
	}

	public override bool Offset(double amount, double tol, out Surface offsetSurf)
	{
		ICurve[] array = _generatrix.Offset((double)Math.Sign(Angle.Length) * amount, _seamPlane.AxisZ);
		Surface[] array2 = ((array != null) ? array[0] : null).RevolveAsSurface(Angle.t0, Angle.Length, Axis, Center);
		offsetSurf = array2[0];
		if (base.IsTrimmed)
		{
			offsetSurf.EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976892);
			bool flag = this is SphericalSurface || this is CylindricalSurface;
			if (flag)
			{
				offsetSurf.Trimming = (Region)base.Trimming.Clone();
			}
			else
			{
				offsetSurf.Trimming.ContourList.Clear();
			}
			for (int i = 0; i < base.Trimming.ContourList.Count; i++)
			{
				ICurve[] individualCurves = base.Trimming.ContourList[i].GetIndividualCurves();
				List<ICurve> list = new List<ICurve>();
				for (int j = 0; j < individualCurves.Length; j++)
				{
					TrimCurve trimCurve = (TrimCurve)individualCurves[j];
					if (flag)
					{
						ICurve curve = offsetSurf.Trimming.ContourList[i];
						TrimCurve trimCurve2 = ((!(curve is CompositeCurve)) ? ((TrimCurve)curve) : ((TrimCurve)((CompositeCurve)curve).CurveList[j]));
						ICurve edge = offsetSurf.LiftCurve(trimCurve, tol);
						trimCurve2.Edge = edge;
						continue;
					}
					if (!_0023_003DztOXazPhlCl2U(trimCurve, offsetSurf, amount, out var _0023_003Dza4SeUA_0024HGEBl))
					{
						ICurve edge = _0023_003Dz3JJdLbUPbfbS(trimCurve.Edge, offsetSurf, amount, tol);
						((Entity)edge).Regen(tol);
						bool flag2 = IsOnSeamU(edge);
						bool flag3 = IsOnSeamV(edge);
						new _0023_003DzGJERpBU4BDeOxTXWM4VD_r9439SEC8V22w_003D_003D(offsetSurf)._0023_003Dz9D8dDjb0uUoA(edge, tol * 100.0, out var _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D);
						if (_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D == null)
						{
							return false;
						}
						if (flag2 && !Utility.AreEqual(trimCurve.StartPoint.X, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.StartPoint.X, base.DomainU.Length))
						{
							Point4D[] pw = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Pw;
							for (int k = 0; k < pw.Length; k++)
							{
								pw[k].X = base.DomainU.High;
							}
						}
						if (flag3 && !Utility.AreEqual(trimCurve.StartPoint.Y, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.StartPoint.Y, base.DomainV.Length))
						{
							Point4D[] pw = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Pw;
							for (int k = 0; k < pw.Length; k++)
							{
								pw[k].Y = base.DomainV.High;
							}
						}
						_0023_003Dza4SeUA_0024HGEBl = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D._0023_003DzmGgqdRaHiXdg(edge);
					}
					list.Add(_0023_003Dza4SeUA_0024HGEBl);
				}
				if (!flag)
				{
					offsetSurf.Trimming.ContourList.Add(new CompositeCurve(list, sortAndOrient: false));
				}
			}
		}
		else
		{
			offsetSurf.Trimming = offsetSurf._0023_003Dzrkte6ryoSSy1((_0023_003DzQAHUODcCipZscKjjuw_003D_003D)0);
		}
		return true;
	}

	public override ICurve IsocurveU(double v)
	{
		Point3D point3D = PointAt(base.DomainU.Low, v);
		Segment3D segment3D = new Segment3D(Center, Center + Axis);
		Point3D point3D2 = segment3D.PointAt(segment3D.Project(point3D));
		double num = Point3D.Distance(point3D, point3D2);
		if (num > 1E-12)
		{
			return new Arc(new Plane(point3D2, _seamPlane.AxisX, -1.0 * _seamPlane.AxisZ), point3D2, num, Angle.Low / scaleU, Angle.High / scaleU);
		}
		return _0023_003DzAlfUFnKPryimd24Ct6UXtpA_003D(v);
	}

	public override ICurve IsocurveV(double u)
	{
		ICurve obj = (ICurve)_generatrix.Clone();
		Transformation xform = new Rotation(u / scaleU, _seamPlane.AxisY, _seamPlane.Origin);
		((Entity)obj).TransformBy(xform);
		return obj;
	}

	internal override bool _0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out PlanarSurface _0023_003DzaR3A1ks_003D, out Transformation _0023_003DzNDQ_E88_003D)
	{
		_0023_003DzNDQ_E88_003D = null;
		_0023_003DzaR3A1ks_003D = null;
		if (Generatrix.IsLinear(1E-12, out var line))
		{
			Vector3D vector3D = new Vector3D(line.P0, line.P1);
			vector3D.Normalize();
			if (Vector3D.AreOrthogonal(Axis, vector3D))
			{
				return GetPlanarFromPlanarCone(out _0023_003DzaR3A1ks_003D);
			}
		}
		return false;
	}

	protected bool GetPlanarFromPlanarCone(out PlanarSurface ps)
	{
		ps = null;
		ICurve[] individualCurves;
		if (!Utility.AreEqual(Angle.Length / scaleU, Math.PI * 2.0, 1.0))
		{
			ICurve[] array = new ICurve[base.Trimming.ContourList.Count];
			for (int i = 0; i < base.Trimming.ContourList.Count; i++)
			{
				ICurve curve = base.Trimming.ContourList[i];
				List<ICurve> list = new List<ICurve>();
				individualCurves = curve.GetIndividualCurves();
				for (int j = 0; j < individualCurves.Length; j++)
				{
					TrimCurve trimCurve = (TrimCurve)individualCurves[j];
					if (!trimCurve.Edge.IsPoint)
					{
						list.Add((ICurve)trimCurve.Edge.Clone());
					}
				}
				array[i] = new CompositeCurve(list);
			}
			ps = Surface.CreatePlanar(array);
			return true;
		}
		if (base.IsTrimmed)
		{
			return false;
		}
		List<ICurve> list2 = new List<ICurve>();
		individualCurves = base.Trimming.ContourList[0].GetIndividualCurves();
		for (int j = 0; j < individualCurves.Length; j++)
		{
			TrimCurve trimCurve2 = (TrimCurve)individualCurves[j];
			ICurve edge = trimCurve2.Edge;
			if (!edge.IsPoint && !edge.IsLinear(Utility._0023_003DzxhnLabVjXjPg, out var _))
			{
				list2.Add((ICurve)trimCurve2.Edge.Clone());
			}
		}
		ICurve[] array2 = new ICurve[list2.Count];
		for (int k = 0; k < list2.Count; k++)
		{
			array2[k] = list2[k];
		}
		ps = Surface.CreatePlanar(array2);
		return true;
	}

	protected static IndexTriangle[] CreateBoxConvexHullTriangles()
	{
		return new IndexTriangle[12]
		{
			new IndexTriangle(3, 2, 1),
			new IndexTriangle(3, 1, 0),
			new IndexTriangle(0, 1, 5),
			new IndexTriangle(0, 5, 4),
			new IndexTriangle(1, 2, 6),
			new IndexTriangle(1, 6, 5),
			new IndexTriangle(2, 3, 7),
			new IndexTriangle(2, 7, 6),
			new IndexTriangle(3, 0, 4),
			new IndexTriangle(3, 4, 7),
			new IndexTriangle(4, 5, 6),
			new IndexTriangle(4, 6, 7)
		};
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] array;
		if (Generatrix is CompositeCurve)
		{
			Surface[] individualSurfaces = Surface.GetIndividualSurfaces(this);
			array = new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[individualSurfaces.Length];
			for (int i = 0; i < individualSurfaces.Length; i++)
			{
				RevolvedSurface _0023_003DzQcLk4fU_003D = (RevolvedSurface)individualSurfaces[i];
				array[i] = _0023_003DzKw5kb5OTrXQJ(_0023_003DzQcLk4fU_003D, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
			}
		}
		else
		{
			array = new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzKw5kb5OTrXQJ(this, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ) };
		}
		return array;
	}

	internal _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzKw5kb5OTrXQJ(RevolvedSurface _0023_003DzQcLk4fU_003D, Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ)
	{
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = _0023_003DzTBgYs4ruey8A8uteS_AA__00248_003D(_0023_003DzQcLk4fU_003D.Generatrix, _0023_003DzQcLk4fU_003D.Center, _0023_003DzQcLk4fU_003D.Axis, _0023_003Dzx3pYiE0_003D: true);
		Surface._0023_003DzRJjg7TSwDjXLGDsfug_003D_003D(_0023_003DzQcLk4fU_003D.Trimming.ContourList, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
		_0023_003DzYe_6EnQecc8d(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2;
	}

	internal static _0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzTBgYs4ruey8A8uteS_AA__00248_003D(ICurve _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, Point3D _0023_003DzbUvT9Pc_003D, Vector3D _0023_003DzxuJqjrs_003D, bool _0023_003Dzx3pYiE0_003D)
	{
		_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv = TrimCurve._0023_003DzDj2isiZZZIae(_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D);
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D obj = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D();
		obj._0023_003DzHRuQO8h0I4fOFFi7OYQB2Nw_003D(_0023_003DzcX2HU0yGwowv, _0023_003DzbUvT9Pc_003D.ToArray(), _0023_003DzxuJqjrs_003D.ToArray());
		obj._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D);
		return obj;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		Surface surface = (Surface)Clone();
		if (Generatrix is Arc arc && Vector3D.AreOpposite(SeamPlane.AxisZ, arc.Plane.AxisZ))
		{
			surface.ReverseU();
		}
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = surface._0023_003DzuAMveDQA6vvk()[0];
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		int _0023_003DzpT6ZqTI_003D = _0023_003DzyzK8swU_003D;
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
		if (base.IsTrimmed)
		{
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DznXwBXUw4u1qB(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974921));
			_0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D obj = new _0023_003DzOqrWHudzVp1v35H_vsK2gKOjnxqMkRli9ie5GLqoLH7QYRVcuQ_003D_003D(_0023_003DzpT6ZqTI_003D, surface._0023_003Dzu1Nt2pFN_00246wu(), ColorMethod == colorMethodType.byEntity, LayerName, Color);
			obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
			obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
			obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
		}
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1]
		{
			new _0023_003DzYkQVv2Lb0egyGZnzeO8ydkyFt0lDEhHA4uvG2TxpWX6vfM3gdg_003D_003D(Angle.Low, Angle.High, Axis, Center, ((Entity)Generatrix)._0023_003DzuAMveDQA6vvk()[0], ColorMethod == colorMethodType.byEntity, LayerName, Color)
		};
	}
}
