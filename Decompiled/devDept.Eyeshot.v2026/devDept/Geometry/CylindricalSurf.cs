using System;
using System.Collections.Generic;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class CylindricalSurf : PlanarSurf
{
	private double _radius;

	public double Radius => _radius;

	public override bool HasSeam => true;

	public CylindricalSurf(Point3D location, Vector3D axis, Vector3D refDir, double radius, int index = 0)
		: base(location, axis, refDir, index)
	{
		_radius = radius;
	}

	protected internal CylindricalSurf(Plane plane, double radius, int index = 0)
		: base(plane, index)
	{
		_radius = radius;
	}

	protected CylindricalSurf(CylindricalSurf another)
		: base(another)
	{
		_radius = another._radius;
	}

	public override object Clone()
	{
		return new CylindricalSurf(this);
	}

	public override AnalyticSurfSurrogate ConvertToSurrogate()
	{
		return new CylindricalSurfSurrogate(this);
	}

	public override Vector3D Normal(Point3D point, out Vector3D tu, out Vector3D tv)
	{
		Point3D p = base.Plane.PointAt(base.Plane.Project(point));
		Vector3D vector3D = new Vector3D(base.Plane.Origin, p);
		vector3D.Normalize();
		tv = (Vector3D)base.Plane.AxisZ.Clone();
		tu = Vector3D.Cross(tv, vector3D);
		return vector3D;
	}

	internal override bool _0023_003DziYlx1Dzq9Zgl(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = 0;
		if (!(_0023_003Dz8fpRyMu9aKjE is Line))
		{
			return false;
		}
		Plane plane = (HasSeam ? new Plane(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisZ) : null);
		bool flag = false;
		if (plane != null)
		{
			flag = _0023_003Dz8fpRyMu9aKjE.IsInPlane(plane, Utility._0023_003DzheSR8QM7q9ya);
			if (flag && plane.Project(_0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz8fpRyMu9aKjE.Domain.Mid)).X < 0.0)
			{
				flag = false;
			}
		}
		return flag;
	}

	internal override bool _0023_003Dzp2cxcSDr1evr(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = 0;
		if (!Utility.IsLine(_0023_003Dz8fpRyMu9aKjE))
		{
			return false;
		}
		Segment3D segment3D = new Segment3D(base.Plane.Origin, base.Plane.Origin + base.Plane.AxisZ);
		double val = Point3D.DistanceSquared(segment3D.PointAt(segment3D.Project(_0023_003Dz8fpRyMu9aKjE.StartPoint)), _0023_003Dz8fpRyMu9aKjE.StartPoint);
		double val2 = Point3D.DistanceSquared(segment3D.PointAt(segment3D.Project(_0023_003Dz8fpRyMu9aKjE.EndPoint)), _0023_003Dz8fpRyMu9aKjE.EndPoint);
		double num = Radius * Radius;
		if (Utility.AreEqual(Math.Max(val2, val), num, num))
		{
			return true;
		}
		return false;
	}

	public override void TransformBy(Transformation xform)
	{
		if (xform.IsScaleFactorUniform())
		{
			_radius *= Math.Abs(xform.ScaleFactorX);
			base.TransformBy(xform);
			return;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657769));
	}

	public override Surface[] GetSurface(IList<ICurve> trimLoops, bool reverse = false)
	{
		Surface _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D;
		Surface surface = _0023_003Dz6VRTLeo_003D(trimLoops, out _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D);
		surface.TranslationID = base.TranslationID;
		if (reverse)
		{
			surface.ReverseU();
		}
		return Surface._0023_003DzNxaR6FzQJCTX(surface, trimLoops, _0023_003Dz4IdClGB7rrJOo8FQbQ_003D_003D: true, _0023_003DzpGLMqOBpGtiN_0024iaD_0024A_003D_003D: false, _0023_003DzBBEA37cFU9UA_HEvnA_003D_003D: false, null);
	}

	public override Surface GetUntrimmed(IList<ICurve> edgeCurves, bool sense, out Surface notRotated)
	{
		Surface surface = _0023_003Dz6VRTLeo_003D(edgeCurves, out notRotated);
		surface.TranslationID = base.TranslationID;
		notRotated.TranslationID = base.TranslationID;
		if (!sense)
		{
			surface.ReverseU();
			notRotated.ReverseU();
		}
		return surface;
	}

	private Surface _0023_003Dz6VRTLeo_003D(IList<ICurve> _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, out Surface _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D)
	{
		PlanarSurf._0023_003DzHNhzuamBoympuHB_8w_003D_003D(base.Plane, _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, out var _0023_003DzG0W_0024gTEMzheB);
		_0023_003DzQ07XuJ4yxy9j(ref _0023_003DzG0W_0024gTEMzheB);
		bool flag = true;
		if (_0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D.Count > 0 && _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D[0] is CompositeCurve)
		{
			CompositeCurve compositeCurve = (CompositeCurve)_0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D[0];
			if (compositeCurve.CurveList.Count == 2 && compositeCurve.CurveList[0] is Line && compositeCurve.CurveList[1] is Line)
			{
				flag = false;
			}
		}
		if (flag)
		{
			double t = _0023_003DzG0W_0024gTEMzheB.t0;
			double length = _0023_003DzG0W_0024gTEMzheB.Length;
			_0023_003DzG0W_0024gTEMzheB.t0 = t - length * base.ExtensionAmount;
			_0023_003DzG0W_0024gTEMzheB.t1 = t + length + length * base.ExtensionAmount;
		}
		Point3D point3D = base.Plane.Origin + base.Plane.AxisX * _radius;
		Point3D start = (Point3D)point3D.Clone();
		start += base.Plane.AxisZ * _0023_003DzG0W_0024gTEMzheB.t0;
		Point3D end = (Point3D)point3D.Clone();
		end += base.Plane.AxisZ * _0023_003DzG0W_0024gTEMzheB.t1;
		Surface surface = new Line(start, end).RevolveAsSurface(0.0, Math.PI * 2.0, base.Plane.AxisZ, base.Plane.Origin)[0];
		_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D = (Surface)surface.Clone();
		if (surface is RevolvedSurface && Utility._0023_003Dzci5nLHpbsxCiqme1Bg_003D_003D(base.Plane, _0023_003Dz6ETrwBDv4CMSxtQsjA_003D_003D, surface, out var _0023_003Dz6pajdGM_003D))
		{
			surface.Rotate(_0023_003Dz6pajdGM_003D, base.Plane.AxisZ, base.Plane.Origin);
			surface.rotAngleU = _0023_003Dz6pajdGM_003D;
		}
		return surface;
	}

	private static void _0023_003DzQ07XuJ4yxy9j(ref Interval _0023_003DzG0W_0024gTEMzheB)
	{
		if (_0023_003DzG0W_0024gTEMzheB.Length < 1E-12)
		{
			if (_0023_003DzG0W_0024gTEMzheB.Low > 0.0)
			{
				_0023_003DzG0W_0024gTEMzheB.t0 = 0.0;
			}
			else
			{
				_0023_003DzG0W_0024gTEMzheB.t1 = 0.0;
			}
		}
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965651) + _radius);
		return stringBuilder.ToString();
	}

	public override Point3D PointAt(double u, double v)
	{
		return base.Plane.PointAt(Radius * Math.Cos(u), Radius * Math.Sin(u), v);
	}

	public Point3D[] IntersectWith(Segment3D line)
	{
		Transformation xform = Transformation.CreateAlignment(base.Plane, Plane.XY);
		Point3D point3D = (Point3D)line.P0.Clone();
		Point3D point3D2 = (Point3D)line.P1.Clone();
		point3D.TransformBy(xform);
		point3D2.TransformBy(xform);
		Vector3D vector3D = new Vector3D(point3D, point3D2);
		Point2D[] array = _0023_003Dz6zMg4w80h1O0(point3D, point3D2, Point2D.Origin, Radius);
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < array.Length; i++)
		{
			double num = _0023_003DznvO45M4_003D(point3D, vector3D, array[i]);
			if (!(num < 0.0 - Utility._0023_003DzxhnLabVjXjPg) && !(num > 1.0 + Utility._0023_003DzxhnLabVjXjPg))
			{
				double num2 = point3D.Z + num * vector3D.Z;
				double num3 = Math.Atan2(array[i].Y, array[i].X);
				if (num3 < 0.0)
				{
					num3 += Math.PI * 2.0;
				}
				Point3D point3D3 = PointAt(num3, num2);
				num *= vector3D.Length;
				list.Add(new InitialPoint(point3D3.X, point3D3.Y, point3D3.Z, num, 0.0, num3, num2));
			}
		}
		return list.ToArray();
	}

	private static Point2D[] _0023_003Dz6zMg4w80h1O0(Point2D _0023_003DzFtLgbsIvLUi7, Point2D _0023_003Dz3D5ZLgnWSpzo, Point2D _0023_003DzbUvT9Pc_003D, double _0023_003DzEGKj_0024SNUUihi)
	{
		if (_0023_003DzFtLgbsIvLUi7 == _0023_003Dz3D5ZLgnWSpzo || _0023_003DzEGKj_0024SNUUihi == 0.0)
		{
			return new Point2D[0];
		}
		double angle = new Vector2D(_0023_003DzFtLgbsIvLUi7, _0023_003Dz3D5ZLgnWSpzo).Angle;
		Transformation transformation = Transformation.CreateRotation(0.0 - angle, Vector3D.AxisZ);
		Transformation transformation2 = Transformation.CreateTranslation(0.0 - _0023_003DzbUvT9Pc_003D.X, 0.0 - _0023_003DzbUvT9Pc_003D.Y);
		Transformation transformation3 = Transformation.CreateRotation(angle, Vector3D.AxisZ);
		Transformation transformation4 = Transformation.CreateTranslation(_0023_003DzbUvT9Pc_003D.X, _0023_003DzbUvT9Pc_003D.Y);
		Transformation transformation5 = transformation * transformation2;
		Transformation xform = transformation4 * transformation3;
		Point2D point2D = transformation5 * _0023_003DzFtLgbsIvLUi7;
		Point2D point2D2 = transformation5 * _0023_003Dz3D5ZLgnWSpzo;
		if (Utility.AreEqual(point2D.X, point2D2.X, _0023_003DzEGKj_0024SNUUihi) && Utility.AreEqual(point2D.Y, point2D2.Y, _0023_003DzEGKj_0024SNUUihi))
		{
			return new Point2D[0];
		}
		double num = (point2D.Y + point2D2.Y) / 2.0;
		double num2 = _0023_003DzEGKj_0024SNUUihi * _0023_003DzEGKj_0024SNUUihi - num * num;
		if (Math.Abs(num2) < _0023_003DzEGKj_0024SNUUihi * 1E-12)
		{
			Point2D[] obj = new Point2D[1]
			{
				new Point2D(0.0, num)
			};
			obj[0].TransformBy(xform);
			return obj;
		}
		if (num2 > 0.0)
		{
			Point2D[] array = new Point2D[2];
			array[0] = new Point2D(Math.Sqrt(num2), num);
			array[1] = new Point2D(0.0 - array[0].X, num);
			array[0].TransformBy(xform);
			array[1].TransformBy(xform);
			return array;
		}
		return new Point2D[0];
	}

	private static double _0023_003DznvO45M4_003D(Point2D _0023_003DzPo_ODtE_003D, Vector2D _0023_003DzCJkr8nY_003D, Point2D _0023_003DzB68dg9Q_003D)
	{
		if (Math.Abs(_0023_003DzCJkr8nY_003D.X) > Math.Abs(_0023_003DzCJkr8nY_003D.Y))
		{
			return (_0023_003DzB68dg9Q_003D.X - _0023_003DzPo_ODtE_003D.X) / _0023_003DzCJkr8nY_003D.X;
		}
		return (_0023_003DzB68dg9Q_003D.Y - _0023_003DzPo_ODtE_003D.Y) / _0023_003DzCJkr8nY_003D.Y;
	}
}
