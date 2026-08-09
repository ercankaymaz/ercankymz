using System;
using System.Runtime.Serialization;
using System.Text;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class ConicalSurface : CylindricalSurface
{
	internal double halfAngle;

	private Point3D _tip;

	public double HalfAngle => halfAngle;

	public Point3D Tip => _tip;

	public ConicalSurface(int uDegree, double[] uKnotVector, int vDegree, double[] vKnotVector, Point4D[,] ctrlPoints, ICurve generatrix, double radius, Plane seamPlane, double halfAngle, Point3D coneTip)
		: base(uDegree, uKnotVector, vDegree, vKnotVector, ctrlPoints, generatrix, radius, seamPlane)
	{
		this.halfAngle = halfAngle;
		_tip = coneTip;
	}

	protected ConicalSurface(ConicalSurface another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		halfAngle = another.halfAngle;
		if (another._tip != null)
		{
			_tip = (Point3D)another._tip.Clone();
		}
	}

	protected internal ConicalSurface(ConicalSurfaceSurrogate surrogate)
		: this(surrogate.GetP(), surrogate.GetU(), surrogate.GetQ(), surrogate.GetV(), surrogate.GetPw(), surrogate.GetGeneratrix() as ICurve, surrogate.GetRadius(), surrogate.GetSeamPlane(), surrogate.GetHalfAngle(), surrogate.GetTip())
	{
	}

	public ConicalSurface(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		halfAngle = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963784));
	}

	public override object Clone()
	{
		return new ConicalSurface(this);
	}

	public override object CloneWithTessellation()
	{
		return new ConicalSurface(this, RegenMode != regenType.RegenAndCompile);
	}

	public override void TransformBy(Transformation xform)
	{
		_tip.TransformBy(xform);
		base.TransformBy(xform);
	}

	internal override AnalyticSurf _0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D()
	{
		return new ConicalSurf((Point3D)base.Center.Clone(), (Vector3D)base.Axis.Clone(), (Vector3D)base.SeamPlane.AxisX.Clone(), base.Radius, halfAngle);
	}

	internal override void _0023_003DzQL1Y_YQxf9Nd(Transformation _0023_003DzJiBboSI_003D, Vector3D _0023_003Dz52qSKlQ_003D)
	{
		_0023_003Dz52qSKlQ_003D.TransformBy(_0023_003DzJiBboSI_003D);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963767) + _tip);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963747) + halfAngle);
		return stringBuilder.ToString();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new ConicalSurfaceSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963784), halfAngle);
	}

	internal override bool _0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out PlanarSurface _0023_003DzaR3A1ks_003D, out Transformation _0023_003DzNDQ_E88_003D)
	{
		_0023_003DzNDQ_E88_003D = null;
		_0023_003DzaR3A1ks_003D = null;
		if (Utility.AreEqual(Math.PI / 2.0, Math.Abs(HalfAngle), 1.0))
		{
			return GetPlanarFromPlanarCone(out _0023_003DzaR3A1ks_003D);
		}
		return false;
	}
}
