using System;
using System.Collections.Generic;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class TabulatedSurf : AnalyticSurf
{
	private Vector3D _generatrix;

	private ICurve _directrix;

	public Vector3D Generatrix => _generatrix;

	public ICurve Directrix => _directrix;

	public override bool HasSeam
	{
		get
		{
			if (_directrix.IsClosed)
			{
				return true;
			}
			return false;
		}
	}

	public TabulatedSurf(ICurve directrix, Vector3D generatrix, int index = 0)
		: base(index)
	{
		_generatrix = generatrix;
		_directrix = directrix;
	}

	protected TabulatedSurf(TabulatedSurf another)
		: base(another)
	{
		_generatrix = (Vector3D)another._generatrix.Clone();
		_directrix = (ICurve)another._directrix.Clone();
	}

	protected internal TabulatedSurf(TabulatedSurfSurrogate surrogate)
		: this((ICurve)surrogate.GetDirectrix(), surrogate.Generatrix)
	{
	}

	public bool TryGetCylindrical(out CylindricalSurf cyl)
	{
		cyl = null;
		if (Directrix is Circle circle)
		{
			Vector3D vector3D = (Vector3D)Generatrix.Clone();
			vector3D.Normalize();
			if (Vector3D.AreParallel(circle.Plane.AxisZ, vector3D))
			{
				cyl = new CylindricalSurf(circle.Plane, circle.Radius);
				return true;
			}
		}
		return false;
	}

	public override Vector3D Normal(Point3D point, out Vector3D tu, out Vector3D tv)
	{
		Line line = new Line(point, point - _generatrix);
		tu = null;
		tv = (Vector3D)_generatrix.Clone();
		tv.Normalize();
		if (_directrix is PlanarEntity planarEntity)
		{
			Utility.LinePlaneIntersection(line.StartPoint, line.EndPoint, planarEntity.Plane.Equation, out var intPoint);
			_directrix.Project(intPoint, out var t);
			ICurve curve = (ICurve)planarEntity;
			if (curve.Domain.Includes(t, testOpenInterval: false) && curve.PointAt(t).DistanceTo(intPoint) < 0.01 * curve.Length())
			{
				tu = curve.TangentAt(t);
				return Vector3D.Cross(tu, tv);
			}
		}
		Curve nurbsForm = _directrix.GetNurbsForm();
		double maxGap = 0.01 * nurbsForm.ControlLength();
		Point3D[] array = nurbsForm.IntersectWith(line, maxGap);
		if (array.Length == 0)
		{
			double[] array2 = new double[nurbsForm.Pw.Length];
			for (int i = 0; i < nurbsForm.Pw.Length; i++)
			{
				line.Project(nurbsForm.Pw[i].Euclid, out array2[i]);
			}
			Array.Sort(array2);
			Point3D point3D = ((array2[0] < line.Domain.Low) ? line.PointAt(array2[0]) : line.Vertices[0]);
			Point3D point3D2 = ((array2[nurbsForm.Pw.Length - 1] > line.Domain.High) ? line.PointAt(array2[nurbsForm.Pw.Length - 1]) : line.Vertices[1]);
			line.Vertices = new Point3D[2] { point3D, point3D2 };
			double t2 = line.Domain.ParameterAt(-0.05);
			double t3 = line.Domain.ParameterAt(1.05);
			point3D = line.PointAt(t2);
			point3D2 = line.PointAt(t3);
			line.Vertices = new Point3D[2] { point3D, point3D2 };
			array = nurbsForm.IntersectWith(line, maxGap);
		}
		if (array.Length != 0)
		{
			tu = nurbsForm.TangentAt(((InterPoint)array[0]).u);
			return Vector3D.Cross(tu, tv);
		}
		return null;
	}

	public override AnalyticSurf GetExtended(IList<ICurve> edgeCurves)
	{
		if (AnalyticSurf.TryToExtendAnalyticCurve(Directrix, edgeCurves, out var extendedCurve))
		{
			return new TabulatedSurf(extendedCurve, Generatrix, (int)base.TranslationID.Index);
		}
		return base.GetExtended(edgeCurves);
	}

	internal override bool _0023_003DziYlx1Dzq9Zgl(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = -1;
		return false;
	}

	internal override bool _0023_003Dzp2cxcSDr1evr(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd)
	{
		_0023_003DzmnVJyP415JCd = -1;
		return false;
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

	public override object Clone()
	{
		return new TabulatedSurf(this);
	}

	public override bool IsPlanar(double tol, out Plane pln)
	{
		return Directrix.ExtrudeAsSurface(Generatrix)[0].IsPlanar(tol, out pln);
	}

	public override AnalyticSurfSurrogate ConvertToSurrogate()
	{
		return new TabulatedSurfSurrogate(this);
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
		_generatrix.TransformBy(xform);
		((Entity)_directrix).TransformBy(xform);
		if (xform.HasReflection)
		{
			_generatrix.Negate();
		}
	}

	private Surface _0023_003Dz6VRTLeo_003D(IList<ICurve> _0023_003DzRTbTK_0024KwG32W, out Surface _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D)
	{
		Curve nurbsForm = _directrix.GetNurbsForm();
		bool num = !(_directrix is PlanarEntity) && nurbsForm._0023_003Dzwgr9T_H7WkW7(_generatrix);
		_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D = null;
		Surface surface;
		if (!num)
		{
			PlanarSurf._0023_003DzvyAuVZcDxArs6XmJHcj7N_00248_003D(_0023_003DzRTbTK_0024KwG32W, nurbsForm, _generatrix, out var _0023_003Dz6Jdj4TI_003D, out var _0023_003DzYNjcavt9guh, out var _0023_003Dz_EiucSU_003D);
			if (_0023_003DzYNjcavt9guh.IsZero)
			{
				_0023_003DzYNjcavt9guh = Vector3D.AxisZ;
			}
			if (_directrix is Curve)
			{
				surface = ((Curve)_directrix)._0023_003DzAjG_vHUZdBmnqt5QDQ_003D_003D(_0023_003DzYNjcavt9guh, _directrix);
			}
			else
			{
				ICurve curve = _directrix;
				double _0023_003Dz6pajdGM_003D = 0.0;
				if (_directrix is Arc)
				{
					Arc arc = Utility._0023_003DzCVWMRix_XDAPR23xLg_003D_003D((Arc)_directrix, out _0023_003Dz6pajdGM_003D);
					if (arc != null)
					{
						_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D = curve.ExtrudeAsSurface(_0023_003DzYNjcavt9guh)[0];
						curve = arc;
					}
				}
				surface = curve.ExtrudeAsSurface(_0023_003DzYNjcavt9guh)[0];
				surface.rotAngleU = _0023_003Dz6pajdGM_003D;
			}
			Vector3D v = (_0023_003Dz6Jdj4TI_003D.Low - _0023_003Dz_EiucSU_003D * _0023_003Dz6Jdj4TI_003D.Length) * _generatrix;
			surface.Translate(v);
			if (surface.SeamU != null)
			{
				surface.SeamU.Translate(v);
			}
		}
		else
		{
			surface = _directrix.ExtrudeAsSurface(_generatrix)[0];
		}
		if (_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D == null)
		{
			_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D = (Surface)surface.Clone();
		}
		return surface;
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981489) + Generatrix);
		stringBuilder.AppendLine(Environment.NewLine);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302980737));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.Append(((Entity)_directrix).Dump());
		return stringBuilder.ToString();
	}

	internal override void _0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D()
	{
	}

	public override Point3D PointAt(double u, double v)
	{
		u = Utility.Clamp(in u, Directrix.Domain.Low, Directrix.Domain.High);
		return Directrix.PointAt(u) + v * Generatrix;
	}
}
