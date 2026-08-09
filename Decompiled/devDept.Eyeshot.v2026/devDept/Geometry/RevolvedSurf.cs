using System;
using System.Collections.Generic;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class RevolvedSurf : PlanarSurf
{
	private ICurve _generatrix;

	public ICurve Generatrix => _generatrix;

	public override bool HasSeam => true;

	public RevolvedSurf(Point3D location, Vector3D normal, Vector3D refDir, ICurve generatrix, int index = 0)
		: base(location, normal, refDir, index)
	{
		_generatrix = generatrix;
	}

	protected internal RevolvedSurf(Plane plane, ICurve generatrix, int index = 0)
		: base(plane, index)
	{
		_generatrix = generatrix;
	}

	protected RevolvedSurf(RevolvedSurf another)
		: base(another)
	{
		_generatrix = (ICurve)another._generatrix.Clone();
	}

	protected internal RevolvedSurf(RevolvedSurfSurrogate surrogate)
		: this(surrogate.Plane, (ICurve)surrogate.GetGeneratrix())
	{
	}

	public override object Clone()
	{
		return new RevolvedSurf(this);
	}

	public override AnalyticSurfSurrogate ConvertToSurrogate()
	{
		return new RevolvedSurfSurrogate(this);
	}

	public override AnalyticSurf GetExtended(IList<ICurve> edgeCurves)
	{
		if (AnalyticSurf.TryToExtendAnalyticCurve(Generatrix, edgeCurves, out var extendedCurve))
		{
			return new RevolvedSurf(base.Plane, extendedCurve, (int)base.TranslationID.Index);
		}
		return base.GetExtended(edgeCurves);
	}

	public override Vector3D Normal(Point3D point, out Vector3D tu, out Vector3D tv)
	{
		Point2D point2D = base.Plane.Project(point);
		tu = (Vector3D)base.Plane.AxisY.Clone();
		ICurve curve = (ICurve)Generatrix.Clone();
		if (!point2D.AsVector.IsZero)
		{
			Rotation xform = new Rotation(point2D.AsVector.Angle, base.Plane.AxisZ, base.Plane.Origin);
			tu.TransformBy(xform);
			((Entity)curve).TransformBy(xform);
		}
		curve.Project(point, out var t);
		tv = curve.TangentAt(t);
		return Vector3D.Cross(tu, tv);
	}

	internal override bool _0023_003DziYlx1Dzq9Zgl(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = -1;
		Plane plane = new Plane(base.Plane.Origin, base.Plane.AxisX, base.Plane.AxisZ);
		bool flag = _0023_003Dz8fpRyMu9aKjE.IsInPlane(plane, Utility._0023_003DzheSR8QM7q9ya);
		if (flag)
		{
			_0023_003DzmnVJyP415JCd = 0;
			if (Curve._0023_003DzRGcO5v1wS2S_(_generatrix.GetNurbsForm(), _0023_003Dz8fpRyMu9aKjE.GetNurbsForm(), out var _, out var _, out var _, 1.0) == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)0)
			{
				flag = false;
			}
		}
		if (!flag && _generatrix.IsClosed)
		{
			Segment3D segment3D = new Segment3D(base.Plane.Origin, base.Plane.Origin + base.Plane.AxisZ);
			Point3D point3D = segment3D.PointAt(segment3D.Project(_generatrix.StartPoint));
			Vector3D vector3D = new Vector3D(point3D, _generatrix.StartPoint);
			vector3D.Normalize();
			Plane plane2 = new Plane(point3D, vector3D, Vector3D.Cross(base.Plane.AxisZ, vector3D));
			flag = _0023_003Dz8fpRyMu9aKjE.IsInPlane(plane2, Utility._0023_003DzheSR8QM7q9ya);
			if (flag)
			{
				_0023_003DzmnVJyP415JCd = 1;
				if (plane2.Project(_0023_003Dz8fpRyMu9aKjE.PointAt(_0023_003Dz8fpRyMu9aKjE.Domain.Mid)).X < 0.0)
				{
					flag = false;
				}
			}
		}
		return flag;
	}

	public override Surface GetUntrimmed(IList<ICurve> edgeCurves, bool sense, out Surface notRotated)
	{
		Surface surface = _generatrix.RevolveAsSurface(0.0, Math.PI * 2.0, base.Plane.AxisZ, base.Plane.Origin)[0];
		notRotated = (Surface)surface.Clone();
		if (Utility._0023_003Dzci5nLHpbsxCiqme1Bg_003D_003D(base.Plane, edgeCurves, surface, out var _0023_003Dz6pajdGM_003D))
		{
			surface.Rotate(_0023_003Dz6pajdGM_003D, base.Plane.AxisZ, base.Plane.Origin);
			surface.rotAngleU = _0023_003Dz6pajdGM_003D;
		}
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
		((Entity)_generatrix).TransformBy(xform);
		base.TransformBy(xform);
	}

	public override Surface[] GetSurface(IList<ICurve> trimLoops, bool reverse = false)
	{
		Surface surface = _generatrix.RevolveAsSurface(0.0, Math.PI * 2.0, base.Plane.AxisZ, base.Plane.Origin)[0];
		surface.TranslationID = base.TranslationID;
		if (reverse)
		{
			surface.ReverseU();
		}
		if (trimLoops == null)
		{
			return new Surface[1] { surface };
		}
		return Surface.DropLoops(surface, trimLoops);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976207) + base.Plane.Origin);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976169) + base.Plane.AxisZ);
		stringBuilder.AppendLine(Environment.NewLine);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976224));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.Append(((Entity)_generatrix).Dump(linearUnits, massUnits, layers, materials, blocks));
		return stringBuilder.ToString();
	}

	internal override void _0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D()
	{
		Segment3D seg = new Segment3D(base.Plane.Origin, base.Plane.Origin + base.Plane.AxisZ);
		double num = Math.PI / 100.0;
		double _0023_003DzheSR8QM7q9ya = Utility._0023_003DzheSR8QM7q9ya;
		if (_generatrix.StartPoint.DistanceTo(seg) < _0023_003DzheSR8QM7q9ya)
		{
			collapsedEdges._0023_003DzusxA4ZTGhQeL(_generatrix.StartPoint);
			collapsedEdges.Poles[2] = Math.Abs(Vector3D.AngleBetween(_generatrix.StartTangent, base.Plane.AxisZ) - Math.PI / 2.0) < num;
		}
		if (_generatrix.EndPoint.DistanceTo(seg) < _0023_003DzheSR8QM7q9ya)
		{
			collapsedEdges._0023_003DzvBU31wjltOH3(_generatrix.EndPoint);
			collapsedEdges.Poles[0] = Math.Abs(Vector3D.AngleBetween(_generatrix.EndTangent, base.Plane.AxisZ) - Math.PI / 2.0) < num;
		}
	}

	public override Point3D PointAt(double u, double v)
	{
		v = Utility.Clamp(in v, Generatrix.Domain.Low, Generatrix.Domain.High);
		Point3D point3D = Generatrix.PointAt(v);
		Transformation xform = Transformation.CreateRotation(u, base.Plane.AxisZ);
		point3D.TransformBy(xform);
		return point3D;
	}
}
