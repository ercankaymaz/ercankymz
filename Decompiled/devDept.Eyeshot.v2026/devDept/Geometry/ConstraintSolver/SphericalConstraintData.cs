using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal class SphericalConstraintData : ConstraintData
{
	public Point3D Center;

	public double Radius;

	internal override int Order => 2;

	public SphericalConstraintData(SphericalSurf sph, Stack<BlockReference> parents)
		: base(parents)
	{
		Point3D point3D = (Point3D)sph.Plane.Origin.Clone();
		point3D.TransformBy(AccTrans);
		Center = point3D;
		Radius = sph.Radius;
	}

	protected internal SphericalConstraintData(SphericalConstraintDataSurrogate surrogate)
		: base(surrogate)
	{
		Center = surrogate.Center;
		Radius = surrogate.Radius;
	}

	public override ConstraintDataSurrogate ConvertToSurrogate()
	{
		return new SphericalConstraintDataSurrogate(this);
	}
}
