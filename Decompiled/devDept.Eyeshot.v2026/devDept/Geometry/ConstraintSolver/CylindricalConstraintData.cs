using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal class CylindricalConstraintData : SphericalConstraintData
{
	public Vector3D AxisX;

	public Vector3D AxisY;

	public Vector3D AxisZ;

	internal override int Order => 1;

	public CylindricalConstraintData(CylindricalSurf cyl, bool sense, Stack<BlockReference> parents)
		: base(new SphericalSurf(cyl.Plane, cyl.Radius), parents)
	{
		Vector3D vector3D = (Vector3D)cyl.Plane.AxisX.Clone();
		vector3D.TransformBy(AccTrans);
		Vector3D vector3D2 = (Vector3D)cyl.Plane.AxisY.Clone();
		vector3D2.TransformBy(AccTrans);
		Vector3D vector3D3 = (Vector3D)cyl.Plane.AxisZ.Clone();
		if (sense)
		{
			vector3D3 *= -1.0;
		}
		vector3D3.TransformBy(AccTrans);
		AxisX = vector3D;
		AxisY = vector3D2;
		AxisZ = vector3D3;
	}

	protected internal CylindricalConstraintData(CylindricalConstraintDataSurrogate surrogate)
		: base(surrogate)
	{
		AxisX = surrogate.AxisX;
		AxisY = surrogate.AxisY;
		AxisZ = surrogate.AxisZ;
	}

	public override ConstraintDataSurrogate ConvertToSurrogate()
	{
		return new CylindricalConstraintDataSurrogate(this);
	}
}
