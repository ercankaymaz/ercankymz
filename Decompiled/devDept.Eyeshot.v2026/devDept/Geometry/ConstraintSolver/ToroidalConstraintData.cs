using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal class ToroidalConstraintData : CylindricalConstraintData
{
	public double MinorRadius;

	internal override int Order => 4;

	public ToroidalConstraintData(ToroidalSurf tor, bool sense, Stack<BlockReference> parents)
		: base(new CylindricalSurf(tor.Plane, tor.MajorRadius), sense, parents)
	{
		MinorRadius = tor.MinorRadius;
	}

	protected internal ToroidalConstraintData(ToroidalConstraintDataSurrogate surrogate)
		: base(surrogate)
	{
		MinorRadius = surrogate.MinorRadius;
	}

	public override ConstraintDataSurrogate ConvertToSurrogate()
	{
		return new ToroidalConstraintDataSurrogate(this);
	}
}
