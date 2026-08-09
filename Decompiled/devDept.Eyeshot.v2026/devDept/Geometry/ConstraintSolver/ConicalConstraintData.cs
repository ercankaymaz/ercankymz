using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal class ConicalConstraintData : CylindricalConstraintData
{
	public double HalfAngle;

	public Point3D Tip;

	internal override int Order => 3;

	public ConicalConstraintData(ConicalSurf con, bool sense, Stack<BlockReference> parents)
		: base(con, sense, parents)
	{
		if (sense)
		{
			AxisZ *= -1.0;
		}
		HalfAngle = con.HalfAngle;
		Tip = con.Tip;
	}

	protected internal ConicalConstraintData(ConicalConstraintDataSurrogate surrogate)
		: base(surrogate)
	{
		HalfAngle = surrogate.HalfAngle;
		Tip = surrogate.Tip;
	}

	public override ConstraintDataSurrogate ConvertToSurrogate()
	{
		return new ConicalConstraintDataSurrogate(this);
	}
}
