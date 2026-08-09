using System;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class CylindricalSurface : RevolvedSurface
{
	private double _radius;

	public double Radius
	{
		get
		{
			return _radius;
		}
		protected set
		{
			_radius = value;
		}
	}

	public CylindricalSurface(int uDegree, double[] uKnotVector, int vDegree, double[] vKnotVector, Point4D[,] ctrlPoints, ICurve generatrix, double radius, Plane seamPlane)
		: base(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints, generatrix, seamPlane)
	{
		_radius = radius;
	}

	protected CylindricalSurface(CylindricalSurface another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_radius = another._radius;
	}

	protected internal CylindricalSurface(CylindricalSurfaceSurrogate surrogate)
		: this(surrogate.GetP(), surrogate.GetU(), surrogate.GetQ(), surrogate.GetV(), surrogate.GetPw(), surrogate.GetGeneratrix() as ICurve, surrogate.GetRadius(), surrogate.GetSeamPlane())
	{
	}

	public CylindricalSurface(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_radius = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843));
	}

	public override object Clone()
	{
		return new CylindricalSurface(this);
	}

	public override object CloneWithTessellation()
	{
		return new CylindricalSurface(this, RegenMode != regenType.RegenAndCompile);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302965651) + _radius);
		return stringBuilder.ToString();
	}

	internal override AnalyticSurf _0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D()
	{
		return new CylindricalSurf((Point3D)base.Center.Clone(), (Vector3D)base.Axis.Clone(), (Vector3D)base.SeamPlane.AxisX.Clone(), _radius);
	}

	public override bool Project(Point3D P, double coincTol, bool allowOutside, out double u, out double v)
	{
		Point3D uAndRotation = GetUAndRotation(P, coincTol, allowOutside, out u);
		if (uAndRotation == null)
		{
			return base.Project(P, coincTol, allowOutside, out u, out v);
		}
		base.Generatrix.Project(uAndRotation, out v);
		v = base.DomainV.t0 + v * scaleV;
		return _0023_003DzhM2gxPHDylsG(P, coincTol, u, v);
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v)
	{
		Point3D uAndRotation = GetUAndRotation(P, out u);
		base.Generatrix.Project(uAndRotation, out v);
		v = base.DomainV.t0 + v * scaleV;
		return true;
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v, out Vector2D W)
	{
		Point3D uAndRotation = GetUAndRotation(P, out u);
		base.Generatrix.Project(uAndRotation, out v);
		v = base.DomainV.t0 + v * scaleV;
		W = null;
		if (P is PointTangent pt)
		{
			Vector3D[,] array = Evaluate(u, v, 1);
			Vector3D su = array[1, 0];
			Vector3D sv = array[0, 1];
			Surface.TangentVectorInversion(pt, su, sv, out W);
		}
		return true;
	}

	public override void TransformBy(Transformation xform)
	{
		base.TransformBy(xform);
		double num = base.Generatrix.Domain.Length / base.DomainV.Length;
		if (num != 1.0)
		{
			base.KnotVectorV.Scale(num);
			base.Trimming.Scale(1.0, num);
			if (xform.IsScaleFactorUniform())
			{
				_radius *= Math.Abs(xform.ScaleFactorX);
			}
		}
	}

	internal virtual void _0023_003DzQL1Y_YQxf9Nd(Transformation _0023_003DzJiBboSI_003D, Vector3D _0023_003Dz52qSKlQ_003D)
	{
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new CylindricalSurfaceSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), _radius);
	}

	internal override void _0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D()
	{
		if (_convexHull == null)
		{
			base._0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D();
		}
	}

	internal override bool _0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out PlanarSurface _0023_003DzaR3A1ks_003D, out Transformation _0023_003DzNDQ_E88_003D)
	{
		_0023_003DzNDQ_E88_003D = null;
		_0023_003DzaR3A1ks_003D = null;
		return false;
	}
}
