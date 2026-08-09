using System;
using System.Collections.Generic;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Geometry.ConstraintSolver;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public abstract class AnalyticSurf : IMateable
{
	internal Edges collapsedEdges = new Edges();

	public TranslationIdentifier TranslationID { get; set; }

	public abstract bool HasSeam { get; }

	protected AnalyticSurf(int index = 0)
	{
		TranslationID = new TranslationIdentifier(index);
	}

	protected AnalyticSurf(AnalyticSurf another)
	{
		TranslationID = another.TranslationID;
	}

	public abstract object Clone();

	public abstract AnalyticSurfSurrogate ConvertToSurrogate();

	public abstract Vector3D Normal(Point3D point, out Vector3D tu, out Vector3D tv);

	internal abstract bool _0023_003DziYlx1Dzq9Zgl(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd);

	internal abstract bool _0023_003Dzp2cxcSDr1evr(ICurve _0023_003Dz8fpRyMu9aKjE, out int _0023_003DzmnVJyP415JCd);

	public abstract Surface[] GetSurface(IList<ICurve> trimLoops, bool reverse = false);

	public abstract Surface GetUntrimmed(IList<ICurve> edgeCurves, bool sense, out Surface notRotated);

	public abstract Point3D PointAt(double u, double v);

	public virtual AnalyticSurf GetExtended(IList<ICurve> edgeCurves)
	{
		return this;
	}

	public virtual bool IsPlanar(double tol, out Plane pln)
	{
		pln = null;
		return false;
	}

	protected static bool TryToExtendAnalyticCurve(ICurve curve1, IList<ICurve> edgeCurves, out ICurve extendedCurve)
	{
		extendedCurve = null;
		if (!curve1.IsClosed)
		{
			double num = curve1.Domain.Min;
			double num2 = curve1.Domain.Max;
			foreach (ICurve edgeCurf in edgeCurves)
			{
				ICurve[] individualCurves = edgeCurf.GetIndividualCurves();
				foreach (ICurve curve2 in individualCurves)
				{
					curve1.Project(curve2.StartPoint, out var t);
					double num3 = t - curve1.Domain.Length * 0.1;
					double num4 = t + curve1.Domain.Length * 0.1;
					if (curve1 is Circle || curve1 is Ellipse)
					{
						if (num3 < 0.0)
						{
							num3 = 0.0;
						}
						if (num4 > Math.PI * 2.0)
						{
							num4 = Math.PI * 2.0;
						}
					}
					if (num3 < num)
					{
						num = num3;
					}
					if (num4 > num2)
					{
						num2 = num4;
					}
				}
			}
			if (num < curve1.Domain.Min || num2 > curve1.Domain.Max)
			{
				extendedCurve = Utility._0023_003Dzp4XhdBsfCih7(curve1, curve1.PointAt(num), curve1.PointAt(num2));
				return true;
			}
		}
		return false;
	}

	public abstract void TransformBy(Transformation xform);

	public virtual string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654870) + HasSeam);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957859) + TranslationID);
		return stringBuilder.ToString();
	}

	internal abstract void _0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromAnalyticSurf(this, parents);
	}
}
