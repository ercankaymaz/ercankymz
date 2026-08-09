using System;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class SphericalSurface : RevolvedSurface
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

	public SphericalSurface(int uDegree, double[] uKnotVector, int vDegree, double[] vKnotVector, Point4D[,] ctrlPoints, ICurve generatrix, double radius, Plane seamPlane)
		: base(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints, generatrix, seamPlane)
	{
		_radius = radius;
	}

	protected SphericalSurface(SphericalSurface another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_radius = another._radius;
	}

	protected internal SphericalSurface(SphericalSurfaceSurrogate surrogate)
		: this(surrogate.GetP(), surrogate.GetU(), surrogate.GetQ(), surrogate.GetV(), surrogate.GetPw(), surrogate.GetGeneratrix() as ICurve, surrogate.GetRadius(), surrogate.GetSeamPlane())
	{
	}

	public SphericalSurface(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_radius = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843));
	}

	public override object Clone()
	{
		return new SphericalSurface(this);
	}

	public override object CloneWithTessellation()
	{
		return new SphericalSurface(this, RegenMode != regenType.RegenAndCompile);
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
		return new SphericalSurf((Point3D)base.Center.Clone(), (Vector3D)base.Axis.Clone(), (Vector3D)base.SeamPlane.AxisX.Clone(), _radius);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new SphericalSurfaceSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955843), _radius);
	}

	public override bool Project(Point3D P, double coincTol, bool allowOutside, out double u, out double v)
	{
		Point3D uAndRotation = GetUAndRotation(P, coincTol, allowOutside, out u);
		if (uAndRotation == null)
		{
			return base.Project(P, coincTol, allowOutside, out u, out v);
		}
		base.Generatrix.Project(uAndRotation, out var t);
		if (Utility.AreEqual(t, base.Generatrix.Domain.Low, base.Generatrix.Domain.Length))
		{
			v = base.Generatrix.Domain.Low;
		}
		else if (Utility.AreEqual(t, base.Generatrix.Domain.High, base.Generatrix.Domain.Length))
		{
			v = base.Generatrix.Domain.High;
		}
		else
		{
			v = t;
		}
		v *= scaleV;
		return _0023_003DzhM2gxPHDylsG(P, coincTol, u, v);
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v)
	{
		return Project(P, coincTol, false, out u, out v);
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v, out Vector2D W)
	{
		bool result = Project(P, coincTol, false, out u, out v);
		W = null;
		if (P is PointTangent pt)
		{
			Vector3D[,] array = Evaluate(u, v, 1);
			Vector3D su = array[1, 0];
			Vector3D sv = array[0, 1];
			Surface.TangentVectorInversion(pt, su, sv, out W);
		}
		return result;
	}

	public override Vector3D NormalAt(double u, double v)
	{
		new Vector3D();
		Transformation xform = new Rotation(u / scaleU, base.SeamPlane.AxisY, Point3D.Origin);
		nurbsGeneratrix = _0023_003DzsZ8Z_M1X5U0GbQ2SWWoHGfELK6XE();
		double num = v / scaleV;
		Transformation xform2 = new Rotation(Math.Abs(((Arc)base.Generatrix).angle.t0 - num), ((Arc)base.Generatrix).Plane.AxisZ, Point3D.Origin);
		Vector3D startTangent = base.Generatrix.StartTangent;
		startTangent.TransformBy(xform2);
		startTangent.TransformBy(xform);
		Vector3D vector3D = -1.0 * base.SeamPlane.AxisZ;
		vector3D.TransformBy(xform);
		Vector3D vector3D2 = Vector3D.Cross(vector3D, startTangent);
		vector3D2.Normalize();
		return vector3D2;
	}

	private void _0023_003DzVkRhb_0024E_003D(out Vector3D _0023_003DzBaLIZT8_003D, out Vector3D _0023_003DzSbDTaOc_003D)
	{
		Vector3D[,] array = Evaluate(base.DomainU.Low + base.DomainU.Length / 2.0, base.DomainV.Low + base.DomainV.Length / 2.0, 1);
		_0023_003DzSbDTaOc_003D = array[1, 0];
		_0023_003DzSbDTaOc_003D.Normalize();
		_0023_003DzBaLIZT8_003D = Vector3D.Subtract(array[0, 0].AsPoint, base.SeamPlane.Origin);
		_0023_003DzBaLIZT8_003D.Normalize();
	}

	public override void TransformBy(Transformation xform)
	{
		base.TransformBy(xform);
		if (xform.IsScaleFactorUniform())
		{
			_radius *= Math.Abs(xform.ScaleFactorX);
		}
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
