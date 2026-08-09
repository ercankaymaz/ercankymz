using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class SphericalSurf : CylindricalSurf
{
	public SphericalSurf(Point3D location, Vector3D axis, Vector3D refDir, double radius, int index = 0)
		: base(location, axis, refDir, radius, index)
	{
	}

	protected internal SphericalSurf(Plane plane, double radius, int index = 0)
		: base(plane, radius, index)
	{
	}

	protected SphericalSurf(SphericalSurf another)
		: base(another)
	{
	}

	public override object Clone()
	{
		return new SphericalSurf(this);
	}

	internal override bool _0023_003DziYlx1Dzq9Zgl(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = 0;
		if (_0023_003Dz8fpRyMu9aKjE is Arc)
		{
			Plane plane = new Plane(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisZ);
			Arc arc = (Arc)_0023_003Dz8fpRyMu9aKjE;
			bool flag = false;
			if (Utility._0023_003DzuW42NHK3HaLL(arc.Radius, base.Radius, base.Radius))
			{
				flag = _0023_003Dz8fpRyMu9aKjE.IsInPlane(plane, Utility._0023_003DzheSR8QM7q9ya);
				if (flag && plane.Project(arc.PointAt(arc.Domain.Mid)).X < 0.0)
				{
					flag = false;
				}
				return flag;
			}
		}
		return false;
	}

	public override Vector3D Normal(Point3D point, out Vector3D tu, out Vector3D tv)
	{
		Vector3D vector3D = new Vector3D(base.Plane.Origin, point);
		vector3D.Normalize();
		Vector2D asVector = base.Plane.Project(point).AsVector;
		if (asVector.LengthSquared < 1E-12)
		{
			tu = null;
			tv = null;
			return vector3D;
		}
		double x = asVector.X;
		double y = asVector.Y;
		double num = vector3D * base.Plane.AxisZ;
		double num2 = Math.Sqrt(Math.Max(1.0 - num * num, 0.0));
		tu = (0.0 - y) * num2 * base.Plane.AxisX + x * num2 * base.Plane.AxisY;
		tv = (0.0 - x) * num * base.Plane.AxisX - y * num * base.Plane.AxisY + num2 * base.Plane.AxisZ;
		return vector3D;
	}

	internal override bool _0023_003Dzp2cxcSDr1evr(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = 0;
		if (_0023_003Dz8fpRyMu9aKjE is Arc)
		{
			Arc arc = (Arc)_0023_003Dz8fpRyMu9aKjE;
			if (Utility._0023_003DzuW42NHK3HaLL(arc.Radius, base.Radius, base.Radius))
			{
				Plane pln = new Plane(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisZ);
				Segment3D segment3D = new Segment3D(base.Plane.Origin, base.Plane.Origin + base.Plane.AxisZ);
				if (Plane.Intersection(pln, arc.Plane, Utility._0023_003DzheSR8QM7q9ya, out var pt, out var u) == planeIntersectionType.UniqueLine && segment3D.IsOnAxis(u, pt))
				{
					return true;
				}
			}
		}
		return false;
	}

	public override AnalyticSurfSurrogate ConvertToSurrogate()
	{
		return new SphericalSurfSurrogate(this);
	}

	public override Surface[] GetSurface(IList<ICurve> trimLoops, bool reverse = false)
	{
		_0023_003Dz6VRTLeo_003D(trimLoops, out var _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D);
		_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D.TranslationID = base.TranslationID;
		if (reverse)
		{
			_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D.ReverseU();
		}
		if (trimLoops == null)
		{
			return new Surface[1] { _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D };
		}
		return Surface._0023_003DzNxaR6FzQJCTX(_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D, trimLoops, _0023_003Dz4IdClGB7rrJOo8FQbQ_003D_003D: true, _0023_003DzpGLMqOBpGtiN_0024iaD_0024A_003D_003D: false, _0023_003DzBBEA37cFU9UA_HEvnA_003D_003D: true, null);
	}

	private Surface _0023_003Dz6VRTLeo_003D(IList<ICurve> _0023_003DzRTbTK_0024KwG32W, out Surface _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D)
	{
		Surface surface = new Arc(new Plane(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisZ), new Point2D(0.0, 0.0), base.Radius, -Math.PI / 2.0, Math.PI / 2.0).RevolveAsSurface(0.0, Math.PI * 2.0, base.Plane.AxisZ, base.Plane.Origin)[0];
		_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D = (Surface)surface.Clone();
		if (surface is RevolvedSurface && _0023_003DzRTbTK_0024KwG32W != null && Utility._0023_003Dzci5nLHpbsxCiqme1Bg_003D_003D(base.Plane, _0023_003DzRTbTK_0024KwG32W, surface, out var _0023_003Dz6pajdGM_003D))
		{
			surface.Rotate(_0023_003Dz6pajdGM_003D, base.Plane.AxisZ, base.Plane.Origin);
			surface.rotAngleU = _0023_003Dz6pajdGM_003D;
		}
		return surface;
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

	internal override void _0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D()
	{
		collapsedEdges._0023_003DzvBU31wjltOH3(base.Plane.Origin + base.Plane.AxisZ * base.Radius);
		collapsedEdges.Poles[0] = true;
		collapsedEdges._0023_003DzusxA4ZTGhQeL(base.Plane.Origin - base.Plane.AxisZ * base.Radius);
		collapsedEdges.Poles[2] = true;
	}

	public override Point3D PointAt(double u, double v)
	{
		return base.Plane.PointAt(base.Radius * Math.Cos(u) * Math.Cos(v), base.Radius * Math.Sin(u) * Math.Cos(v), base.Radius * Math.Sin(v));
	}

	public new Point3D[] IntersectWith(Segment3D line)
	{
		Transformation xform = Transformation.CreateAlignment(base.Plane, Plane.XY);
		Point3D point3D = (Point3D)line.P0.Clone();
		Point3D point3D2 = (Point3D)line.P1.Clone();
		point3D.TransformBy(xform);
		point3D2.TransformBy(xform);
		Vector3D vector3D = new Vector3D(point3D, point3D2);
		double length = vector3D.Length;
		vector3D.Normalize();
		Vector3D asVector = point3D.AsVector;
		double num = 1.0;
		double num2 = 2.0 * Vector3D.Dot(asVector, vector3D);
		double num3 = Vector3D.Dot(asVector, asVector) - base.Radius * base.Radius;
		double num4 = num2 * num2 - 4.0 * num * num3;
		List<double> list = new List<double>();
		if (num4 > 1E-12)
		{
			list.Add((0.0 - num2 + Math.Sqrt(num4)) / (2.0 * num));
			list.Add((0.0 - num2 - Math.Sqrt(num4)) / (2.0 * num));
		}
		else if (Math.Abs(num4) < 1E-12)
		{
			list.Add((0.0 - num2) / (2.0 * num));
		}
		List<Point3D> list2 = new List<Point3D>();
		for (int i = 0; i < list.Count; i++)
		{
			double num5 = list[i];
			Point3D point3D3 = point3D + num5 * vector3D;
			if (!(num5 < -1E-12) && !(num5 > 1.000000000001 * length))
			{
				double num6;
				double num7;
				if (Math.Abs(point3D3.Y) < 1E-12 && Math.Abs(point3D3.X) < 1E-12)
				{
					num6 = 0.0;
					num7 = (double)Math.Sign(point3D3.Z) * Math.PI / 2.0;
				}
				else
				{
					num7 = Math.Atan2(point3D3.Z, Math.Sqrt(point3D3.X * point3D3.X + point3D3.Y * point3D3.Y));
					num6 = Math.Atan2(point3D3.Y, point3D3.X);
				}
				if (num6 < 0.0)
				{
					num6 += Math.PI * 2.0;
				}
				Point3D point3D4 = PointAt(num6, num7);
				list2.Add(new InitialPoint(point3D4.X, point3D4.Y, point3D4.Z, num5, 0.0, num6, num7));
			}
		}
		return list2.ToArray();
	}
}
