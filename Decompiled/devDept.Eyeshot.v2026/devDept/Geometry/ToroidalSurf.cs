using System;
using System.Collections.Generic;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class ToroidalSurf : PlanarSurf
{
	private double _majorRadius;

	private double _minorRadius;

	public double MajorRadius => _majorRadius;

	public double MinorRadius => _minorRadius;

	public override bool HasSeam => true;

	public ToroidalSurf(Point3D location, Vector3D axis, Vector3D refDir, double majorRadius, double minorRadius, int index = 0)
		: base(location, axis, refDir, index)
	{
		_majorRadius = majorRadius;
		_minorRadius = minorRadius;
	}

	protected internal ToroidalSurf(Plane plane, double majorRadius, double minorRadius, int index = 0)
		: base(plane, index)
	{
		_majorRadius = majorRadius;
		_minorRadius = minorRadius;
	}

	protected ToroidalSurf(ToroidalSurf another)
		: base(another)
	{
		_majorRadius = another._majorRadius;
		_minorRadius = another._minorRadius;
	}

	public override object Clone()
	{
		return new ToroidalSurf(this);
	}

	public override AnalyticSurfSurrogate ConvertToSurrogate()
	{
		return new ToroidalSurfSurrogate(this);
	}

	public override Vector3D Normal(Point3D point, out Vector3D tu, out Vector3D tv)
	{
		Point3D p = base.Plane.PointAt(base.Plane.Project(point));
		Vector3D vector3D = new Vector3D(base.Plane.Origin, p);
		vector3D.Normalize();
		Point3D point3D = base.Plane.Origin + MajorRadius * vector3D;
		Vector3D vector3D2 = new Vector3D(point3D, point);
		vector3D2.Normalize();
		Vector3D vector3D3 = new Vector3D(base.Plane.Origin, point3D);
		double num = vector3D3 * base.Plane.AxisX / MajorRadius;
		double num2 = vector3D3 * base.Plane.AxisY / MajorRadius;
		double num3 = vector3D2 * vector3D3 / MajorRadius;
		double num4 = vector3D2 * base.Plane.AxisZ;
		tu = (MajorRadius + MinorRadius * num4) * (num * base.Plane.AxisY - num2 * base.Plane.AxisX);
		tu.Normalize();
		tv = (0.0 - MinorRadius) * num4 * (num * base.Plane.AxisX + num2 * base.Plane.AxisY) + MinorRadius * num3 * base.Plane.AxisZ;
		tv.Normalize();
		return vector3D2;
	}

	internal override bool _0023_003DziYlx1Dzq9Zgl(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = -1;
		if (!(_0023_003Dz8fpRyMu9aKjE is Circle))
		{
			return false;
		}
		bool flag = false;
		Circle circle = (Circle)_0023_003Dz8fpRyMu9aKjE;
		if (Utility._0023_003DzuW42NHK3HaLL(circle.Radius, MinorRadius, MinorRadius))
		{
			Plane plane = new Plane(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisZ);
			flag = circle.IsInPlane(plane, Utility._0023_003DzheSR8QM7q9ya);
			if (flag)
			{
				_0023_003DzmnVJyP415JCd = 0;
				if (plane.Project(_0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz8fpRyMu9aKjE.Domain.Mid)).X < 0.0)
				{
					flag = false;
				}
			}
		}
		else
		{
			Plane plane2 = base.Plane;
			flag = Utility._0023_003DzuW42NHK3HaLL(circle.Radius, MajorRadius + MinorRadius, MajorRadius + MinorRadius);
			if (flag)
			{
				_0023_003DzmnVJyP415JCd = 1;
				flag = circle.IsInPlane(plane2, Utility._0023_003DzheSR8QM7q9ya);
			}
		}
		return flag;
	}

	internal override bool _0023_003Dzp2cxcSDr1evr(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = -1;
		if (!(_0023_003Dz8fpRyMu9aKjE is Circle))
		{
			return false;
		}
		Circle circle = (Circle)_0023_003Dz8fpRyMu9aKjE;
		if (Utility._0023_003DzuW42NHK3HaLL(circle.Radius, MinorRadius, MinorRadius))
		{
			_0023_003DzmnVJyP415JCd = 0;
			return true;
		}
		if (Utility._0023_003DzuW42NHK3HaLL(circle.Radius, MajorRadius + MinorRadius, MajorRadius + MinorRadius))
		{
			_0023_003DzmnVJyP415JCd = 1;
			return true;
		}
		return false;
	}

	internal bool _0023_003DzLn_0024zdrqxxqIG(Point3D _0023_003Dzm9bQX1ehzIK5, Vector3D _0023_003DzA3qAyymrOI82, int _0023_003DzySq1FRBAAlFB)
	{
		Point3D point3D = base.Plane.Origin + base.Plane.AxisX * MajorRadius;
		bool flag = true;
		if (_0023_003DzySq1FRBAAlFB != 0)
		{
			if (Point3D.DistanceSquared(_0023_003Dzm9bQX1ehzIK5, point3D) > MinorRadius * MinorRadius)
			{
				flag = false;
			}
			Circle circle = new Circle(new Plane(point3D, base.Plane.AxisX, base.Plane.AxisZ), MinorRadius);
			circle.Project(_0023_003Dzm9bQX1ehzIK5, out var t);
			if (Vector3D.AreParallel(circle.TangentAt(t), _0023_003DzA3qAyymrOI82))
			{
				flag = false;
			}
		}
		bool flag2 = true;
		if (_0023_003DzySq1FRBAAlFB != 1)
		{
			double num = Point3D.DistanceSquared(_0023_003Dzm9bQX1ehzIK5, base.Plane.Origin);
			double num2 = MajorRadius + MinorRadius;
			if (num < num2 * num2)
			{
				flag2 = false;
			}
			Circle circle2 = new Circle(base.Plane, num2);
			circle2.Project(_0023_003Dzm9bQX1ehzIK5, out var t2);
			if (Vector3D.AreParallel(circle2.TangentAt(t2), _0023_003DzA3qAyymrOI82))
			{
				flag2 = false;
			}
		}
		return flag || flag2;
	}

	public override Surface[] GetSurface(IList<ICurve> trimLoops, bool reverse = false)
	{
		_0023_003Dz6VRTLeo_003D(trimLoops, out var _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D);
		_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D.rotAngleV = 0.0;
		_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D.TranslationID = base.TranslationID;
		if (reverse)
		{
			_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D.ReverseU();
		}
		if (trimLoops == null)
		{
			return new Surface[1] { _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D };
		}
		return Surface._0023_003DzNxaR6FzQJCTX(_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D, trimLoops, _0023_003Dz4IdClGB7rrJOo8FQbQ_003D_003D: true, _0023_003DzpGLMqOBpGtiN_0024iaD_0024A_003D_003D: true, _0023_003DzBBEA37cFU9UA_HEvnA_003D_003D: false, null);
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

	public override void TransformBy(Transformation xform)
	{
		if (xform.IsScaleFactorUniform())
		{
			_majorRadius *= Math.Abs(xform.ScaleFactorX);
			_minorRadius *= Math.Abs(xform.ScaleFactorX);
			base.TransformBy(xform);
			return;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657769));
	}

	private Surface _0023_003Dz6VRTLeo_003D(IList<ICurve> _0023_003DzRTbTK_0024KwG32W, out Surface _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D)
	{
		_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D = null;
		double radius = Math.Abs(_minorRadius);
		Plane arcPlane = new Plane(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisZ);
		Arc arc;
		if (_majorRadius > 0.0 && _majorRadius < _minorRadius)
		{
			double num = Math.Acos((0.0 - _majorRadius) / _minorRadius);
			arc = new Arc(arcPlane, new Point2D(_majorRadius, 0.0), radius, 0.0 - num, num);
		}
		else if (_majorRadius > 0.0)
		{
			arc = new Arc(arcPlane, new Point2D(_majorRadius, 0.0), radius, 0.0, Math.PI * 2.0);
		}
		else
		{
			if (!(_majorRadius < 0.0))
			{
				return null;
			}
			double num2 = Math.Acos(_majorRadius / _minorRadius);
			arc = new Arc(arcPlane, new Point2D(0.0 - _majorRadius, 0.0), radius, num2, Math.PI * 2.0 - num2);
			arc.Reverse();
		}
		Surface surface = arc.RevolveAsSurface(0.0, Math.PI * 2.0, base.Plane.AxisZ, base.Plane.Origin)[0];
		_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D = (Surface)surface.Clone();
		if (surface is RevolvedSurface revolvedSurface && _majorRadius > _minorRadius && _0023_003DzRTbTK_0024KwG32W != null)
		{
			Plane plane = (Plane)revolvedSurface.SeamPlane.Clone();
			plane.Translate(plane.AxisX * _majorRadius);
			if (Utility._0023_003DzeRbwL3dSLSRdPlz0gQ_003D_003D(base.Plane, plane, _0023_003DzRTbTK_0024KwG32W, out var _0023_003Dz6pajdGM_003D))
			{
				arc.Rotate(_0023_003Dz6pajdGM_003D, arc.Plane.AxisZ, arc.Plane.Origin);
				surface = arc.RevolveAsSurface(0.0, Math.PI * 2.0, base.Plane.AxisZ, base.Plane.Origin)[0];
				surface.rotAngleV = _0023_003Dz6pajdGM_003D;
			}
			if (Utility._0023_003Dzci5nLHpbsxCiqme1Bg_003D_003D(base.Plane, _0023_003DzRTbTK_0024KwG32W, surface, out _0023_003Dz6pajdGM_003D))
			{
				surface.Rotate(_0023_003Dz6pajdGM_003D, base.Plane.AxisZ, base.Plane.Origin);
				surface.rotAngleU = _0023_003Dz6pajdGM_003D;
			}
		}
		return surface;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981788) + _majorRadius);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659734) + _minorRadius);
		return stringBuilder.ToString();
	}

	public override Point3D PointAt(double u, double v)
	{
		double num = _majorRadius + _minorRadius * Math.Cos(v);
		return base.Plane.PointAt(num * Math.Cos(u), num * Math.Sin(u), _minorRadius * Math.Sin(v));
	}

	public Point3D[] IntersectWith(Segment3D line)
	{
		List<Point3D> list = new List<Point3D>();
		Transformation xform = Transformation.CreateAlignment(base.Plane, Plane.XY);
		Point3D point3D = (Point3D)line.P0.Clone();
		Point3D point3D2 = (Point3D)line.P1.Clone();
		point3D.TransformBy(xform);
		point3D2.TransformBy(xform);
		Vector3D vector3D = new Vector3D(point3D, point3D2);
		double length = vector3D.Length;
		vector3D.Normalize();
		if (base.Plane.Origin.DistanceTo(line) > _majorRadius + _minorRadius + Utility._0023_003DzheSR8QM7q9ya)
		{
			return list.ToArray();
		}
		double num = _majorRadius * _majorRadius;
		double num2 = _minorRadius * _minorRadius;
		double num3 = point3D.X * point3D.X + point3D.Y * point3D.Y + point3D.Z * point3D.Z;
		double num4 = vector3D.X * point3D.X + vector3D.Y * point3D.Y + vector3D.Z * point3D.Z;
		double num5 = 4.0 * num * (vector3D.X * vector3D.X + vector3D.Y * vector3D.Y);
		double num6 = 8.0 * num * (num4 - vector3D.Z * point3D.Z);
		double num7 = 4.0 * num * (num3 - point3D.Z * point3D.Z);
		double num8 = 2.0 * num4;
		double num9 = num3 + num - num2;
		double num10 = 2.0 * num8;
		double num11 = 2.0 * num9 + num8 * num8 - num5;
		double num12 = 2.0 * num8 * num9 - num6;
		double num13 = num9 * num9 - num7;
		double _0023_003Dzm0CYiiE_003D = (MajorRadius + MinorRadius) * Utility._0023_003DzheSR8QM7q9ya;
		List<double> list2 = EndMill._0023_003DzIcp8V_b9lTcpvTMD4vMInII_003D(num10, num11, num12, num13, _0023_003Dzm0CYiiE_003D);
		for (int i = 0; i < list2.Count; i++)
		{
			double num14 = list2[i];
			Point3D point3D3 = point3D + num14 * vector3D;
			if (num14 < 0.0 - Utility._0023_003DzxhnLabVjXjPg || num14 > (1.0 + Utility._0023_003DzxhnLabVjXjPg) * length)
			{
				continue;
			}
			double num15 = num14 * num14;
			double num16 = num14 * num15;
			if (Math.Abs(num14 * num16 + num10 * num16 + num11 * num15 + num12 * num14 + num13) > Utility._0023_003DzxhnLabVjXjPg * (MajorRadius + MinorRadius))
			{
				continue;
			}
			double num17 = Math.Atan2(point3D3.Y, point3D3.X);
			double num18 = Math.Sqrt(point3D3.X * point3D3.X + point3D3.Y * point3D3.Y) - Math.Abs(MajorRadius);
			double num19 = Math.Atan2(point3D3.Z, num18);
			if (Math.Abs(MajorRadius) < MinorRadius)
			{
				double num20 = MinorRadius - Math.Abs(MajorRadius);
				double num21 = Math.Sqrt(MinorRadius * MinorRadius - Math.Abs(MajorRadius) * Math.Abs(MajorRadius));
				bool num22 = Math.Abs(point3D3.X) <= num20;
				bool flag = Math.Abs(point3D3.Y) <= num21;
				if (num22 && flag)
				{
					num19 = Math.Atan2(point3D3.Z, 0.0 - (num18 + 2.0 * Math.Abs(MajorRadius)));
				}
				if (MajorRadius < 0.0)
				{
					num19 = Math.PI - num19;
					if (num19 < 0.0)
					{
						num19 += Math.PI * 2.0;
					}
					else if (num19 > Math.PI * 2.0)
					{
						num19 -= Math.PI * 2.0;
					}
				}
			}
			if (num19 < 0.0)
			{
				num19 += Math.PI * 2.0;
			}
			else if (num19 > Math.PI * 2.0)
			{
				num19 -= Math.PI * 2.0;
			}
			Point3D point3D4 = PointAt(num17, num19);
			list.Add(new InitialPoint(point3D4.X, point3D4.Y, point3D4.Z, num14, 0.0, num17, num19));
		}
		return list.ToArray();
	}
}
