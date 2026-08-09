using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal class PlanarConstraintData : ConstraintData
{
	public Point3D Origin;

	public Vector3D AxisX;

	public Vector3D AxisY;

	public Vector3D AxisZ;

	internal override int Order => 0;

	public PlanarConstraintData(PlanarSurf planar, bool sense, Stack<BlockReference> parents)
		: base(parents)
	{
		Point3D point3D = (Point3D)planar.Plane.Origin.Clone();
		point3D.TransformBy(AccTrans);
		Vector3D vector3D = (Vector3D)planar.Plane.AxisX.Clone();
		vector3D.TransformBy(AccTrans);
		Vector3D vector3D2 = (Vector3D)planar.Plane.AxisY.Clone();
		vector3D2.TransformBy(AccTrans);
		Vector3D vector3D3 = (Vector3D)planar.Plane.AxisZ.Clone();
		if (sense)
		{
			vector3D3 *= -1.0;
		}
		vector3D3.TransformBy(AccTrans);
		AxisX = vector3D;
		AxisY = vector3D2;
		AxisZ = vector3D3;
		Origin = point3D;
	}

	protected internal PlanarConstraintData(PlanarConstraintDataSurrogate surrogate)
		: base(surrogate)
	{
		Origin = surrogate.Origin;
		AxisX = surrogate.AxisX;
		AxisY = surrogate.AxisY;
		AxisZ = surrogate.AxisZ;
	}

	public override ConstraintDataSurrogate ConvertToSurrogate()
	{
		return new PlanarConstraintDataSurrogate(this);
	}
}
