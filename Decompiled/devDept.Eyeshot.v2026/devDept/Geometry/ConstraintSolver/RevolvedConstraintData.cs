using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal class RevolvedConstraintData : PlanarConstraintData
{
	public Curve Generatrix;

	internal override int Order => 5;

	public RevolvedConstraintData(RevolvedSurf rev, bool sense, Stack<BlockReference> parents)
		: base(new PlanarSurf(rev.Plane), sense, parents)
	{
		Generatrix = rev.Generatrix.GetNurbsForm();
	}

	protected internal RevolvedConstraintData(RevolvedConstraintDataSurrogate surrogate)
		: base(surrogate)
	{
		Generatrix = surrogate.Generatrix;
	}

	public override ConstraintDataSurrogate ConvertToSurrogate()
	{
		return new RevolvedConstraintDataSurrogate(this);
	}
}
