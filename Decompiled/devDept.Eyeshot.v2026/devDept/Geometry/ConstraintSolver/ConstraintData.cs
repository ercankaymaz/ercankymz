using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal abstract class ConstraintData
{
	public BlockReference Component;

	public Transformation AccTrans;

	public _0023_003DzZ2CGTF6Z1cUgAuYgtSpWCDzd_TwK Basis => Component._0023_003DzCvxG2A3KpWd8();

	internal virtual int Order { get; }

	protected ConstraintData(Stack<BlockReference> parents)
	{
		Stack<BlockReference> stack = Utility.CloneStack(parents);
		Component = stack.Last();
		AccTrans = Transformation.CreateIdentity();
		while (stack.Count > 1)
		{
			AccTrans = stack.Pop().Transformation * AccTrans;
		}
	}

	protected ConstraintData(Transformation accTrans, BlockReference component)
	{
		Component = component;
		AccTrans = accTrans;
	}

	protected internal ConstraintData(ConstraintDataSurrogate surrogate)
		: this(surrogate.AccTrans, surrogate.Component)
	{
	}

	internal static ConstraintData GetFromAnalyticSurf(AnalyticSurf surf, Stack<BlockReference> parents, bool sense = true)
	{
		if (surf == null || parents == null || parents.Count == 0)
		{
			return null;
		}
		if (surf.IsPlanar(0.1, out var pln))
		{
			return new PlanarConstraintData(new PlanarSurf(pln), sense, parents);
		}
		if (surf is RevolvedSurf rev)
		{
			return new RevolvedConstraintData(rev, sense, parents);
		}
		if (surf is SphericalSurf sph)
		{
			return new SphericalConstraintData(sph, parents);
		}
		if (surf is ConicalSurf con)
		{
			return new ConicalConstraintData(con, sense, parents);
		}
		if (surf is CylindricalSurf cyl)
		{
			return new CylindricalConstraintData(cyl, sense, parents);
		}
		if (surf is ToroidalSurf tor)
		{
			return new ToroidalConstraintData(tor, sense, parents);
		}
		if (surf is TabulatedSurf tabulatedSurf && tabulatedSurf.TryGetCylindrical(out var cyl2))
		{
			return new CylindricalConstraintData(cyl2, sense, parents);
		}
		return null;
	}

	internal static ConstraintData GetFromICurve(ICurve curve, Stack<BlockReference> parents)
	{
		if (curve == null || parents == null || parents.Count == 0)
		{
			return null;
		}
		if (curve.IsPoint)
		{
			return GetFromPoint3D(curve.StartPoint, parents);
		}
		if (curve.IsLinear(0.1, out var line))
		{
			return new LinearConstraintData(line, parents);
		}
		if (curve is Circle circle)
		{
			return new CircleConstraintData(circle, parents);
		}
		return null;
	}

	internal static ConstraintData GetFromPoint3D(Point3D point3D, Stack<BlockReference> parents)
	{
		if ((object)point3D == null || parents == null || parents.Count == 0)
		{
			return null;
		}
		return new PointConstraintData(point3D, parents);
	}

	public abstract ConstraintDataSurrogate ConvertToSurrogate();
}
