using System;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class ToroidalSurface : SphericalSurface
{
	private double _major;

	private torusType _type;

	internal Surface _degeneratedTorus;

	public torusType Type => _type;

	public double MajorRadius => _major;

	public double MinorRadius => base.Radius;

	public ToroidalSurface(int uDegree, double[] uKnotVector, int vDegree, double[] vKnotVector, Point4D[,] ctrlPoints, ICurve generatrix, double major, double minor, Plane seamPlane)
		: base(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints, generatrix, minor, seamPlane)
	{
		_major = major;
		_type = _0023_003DzrGbSgLEhkB_K(_major, MinorRadius);
	}

	protected ToroidalSurface(ToroidalSurface another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_major = another._major;
		_type = another._type;
		if (another._degeneratedTorus != null)
		{
			_degeneratedTorus = (Surface)another._degeneratedTorus.Clone();
		}
	}

	protected internal ToroidalSurface(ToroidalSurfaceSurrogate surrogate)
		: this(surrogate.GetP(), surrogate.GetU(), surrogate.GetQ(), surrogate.GetV(), surrogate.GetPw(), surrogate.GetGeneratrix() as ICurve, surrogate.GetMajorRadius(), surrogate.GetRadius(), surrogate.GetSeamPlane())
	{
	}

	public ToroidalSurface(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_major = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966997));
	}

	public override object Clone()
	{
		return new ToroidalSurface(this);
	}

	public override object CloneWithTessellation()
	{
		return new ToroidalSurface(this, RegenMode != regenType.RegenAndCompile);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981788) + _major);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981775) + _type);
		return stringBuilder.ToString();
	}

	internal override AnalyticSurf _0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D()
	{
		bool flag = base.Generatrix.StartPoint.DistanceTo(new Segment3D(base.Center, base.Center + base.Axis)) < _major + base.Radius;
		Vector3D[,] array = Evaluate(0.0, 0.0, 1);
		array[1, 0].Normalize();
		array[0, 1].Normalize();
		if (!Vector3D.AreCoincident(array[1, 0], base.Plane.AxisY))
		{
			flag = true;
		}
		if (!Vector3D.AreCoincident(array[0, 1], base.Plane.AxisZ))
		{
			flag = true;
		}
		if (flag || _major <= base.Radius * 1E-12)
		{
			return new RevolvedSurf((Point3D)base.Center.Clone(), (Vector3D)base.Axis.Clone(), (Vector3D)base.SeamPlane.AxisX.Clone(), base.Generatrix);
		}
		return new ToroidalSurf((Point3D)base.Center.Clone(), (Vector3D)base.Axis.Clone(), (Vector3D)base.SeamPlane.AxisX.Clone(), _major, base.Radius);
	}

	private protected override void _0023_003Dz7roAELUN1jwt()
	{
		base._0023_003Dz7roAELUN1jwt();
		_degeneratedTorus = null;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new ToroidalSurfaceSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302966997), _major);
	}

	internal override void _0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D()
	{
		if (_convexHull == null)
		{
			base._0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D();
		}
	}

	internal static torusType _0023_003DzrGbSgLEhkB_K(double _0023_003Dzw2cdV10_003D, double _0023_003DzrGX1P9M_003D)
	{
		if (Math.Abs(_0023_003Dzw2cdV10_003D) > Math.Abs(_0023_003DzrGX1P9M_003D))
		{
			return torusType.Donut;
		}
		if (Math.Abs(_0023_003DzrGX1P9M_003D) > _0023_003Dzw2cdV10_003D + 1E-12 && _0023_003Dzw2cdV10_003D > 1E-12)
		{
			return torusType.Apple;
		}
		if (_0023_003Dzw2cdV10_003D < 1E-12 && 0.0 - _0023_003Dzw2cdV10_003D - 1E-12 < Math.Abs(_0023_003DzrGX1P9M_003D))
		{
			return torusType.Lemon;
		}
		return torusType.Vortex;
	}

	internal bool _0023_003DzeQ9KC85nZuWBbBNS9ndQqFc_003D()
	{
		if (_type != torusType.Donut)
		{
			return _type != torusType.Vortex;
		}
		return false;
	}

	public override bool Project(Point3D P, double coincTol, bool allowOutside, out double u, out double v)
	{
		if (_0023_003DzeQ9KC85nZuWBbBNS9ndQqFc_003D())
		{
			if (_degeneratedTorus == null)
			{
				_degeneratedTorus = GetGeneric();
			}
			return _degeneratedTorus.Project(P, coincTol, allowOutside, out u, out v);
		}
		return base.Project(P, coincTol, allowOutside, out u, out v);
	}

	public new bool Project(Point3D P, double coincTol, bool allowOutside, out double u, out double v, out Vector2D W)
	{
		if (_0023_003DzeQ9KC85nZuWBbBNS9ndQqFc_003D())
		{
			if (_degeneratedTorus == null)
			{
				_degeneratedTorus = GetGeneric();
			}
			return _degeneratedTorus.Project(P, coincTol, allowOutside, out u, out v, out W);
		}
		bool result = base.Project(P, coincTol, allowOutside, out u, out v);
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

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v)
	{
		if (_0023_003DzeQ9KC85nZuWBbBNS9ndQqFc_003D())
		{
			if (_degeneratedTorus == null)
			{
				_degeneratedTorus = GetGeneric();
			}
			if (!_degeneratedTorus.PointInversion(P, coincTol, out u, out v) || Point3D.Distance(P, _degeneratedTorus.PointAt(u, v)) > coincTol / 1000.0)
			{
				return Project(P, coincTol, false, out u, out v);
			}
			return true;
		}
		return Project(P, coincTol, false, out u, out v);
	}

	public override bool PointInversion(Point3D P, double coincTol, out double u, out double v, out Vector2D W)
	{
		if (_0023_003DzeQ9KC85nZuWBbBNS9ndQqFc_003D())
		{
			if (_degeneratedTorus == null)
			{
				_degeneratedTorus = GetGeneric();
			}
			if (!_degeneratedTorus.PointInversion(P, coincTol, out u, out v, out W) || Point3D.Distance(P, _degeneratedTorus.PointAt(u, v)) > coincTol / 1000.0)
			{
				return Project(P, coincTol, allowOutside: false, out u, out v, out W);
			}
			return true;
		}
		return Project(P, coincTol, allowOutside: false, out u, out v, out W);
	}

	public override Vector3D NormalAt(double u, double v)
	{
		if (_0023_003DzeQ9KC85nZuWBbBNS9ndQqFc_003D())
		{
			if (_degeneratedTorus == null)
			{
				_degeneratedTorus = GetGeneric();
			}
			return _degeneratedTorus.NormalAt(u, v);
		}
		return base.NormalAt(u, v);
	}

	public override void ReverseU()
	{
		base.ReverseU();
		_degeneratedTorus = null;
	}

	public override Vector3D[,] Evaluate(double u, double v, int d)
	{
		if (_0023_003DzeQ9KC85nZuWBbBNS9ndQqFc_003D())
		{
			if (_degeneratedTorus == null)
			{
				_degeneratedTorus = GetGeneric();
			}
			_0023_003DzeVdMxiELXEc151iyuw_003D_003D(u, v, out var _, out var _);
			return _degeneratedTorus.Evaluate(u, v, d);
		}
		return base.Evaluate(u, v, d);
	}
}
