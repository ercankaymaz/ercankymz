using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

internal class CircleConstraintData : ConstraintData
{
	public Point3D Center;

	public Vector3D AxisX;

	public Vector3D AxisY;

	public Vector3D AxisZ;

	public double Radius;

	internal override int Order => 7;

	public CircleConstraintData(Circle circle, Stack<BlockReference> parents)
		: base(parents)
	{
		Point3D point3D = (Point3D)circle.Plane.Origin.Clone();
		point3D.TransformBy(AccTrans);
		Vector3D vector3D = (Vector3D)circle.Plane.AxisX.Clone();
		vector3D.TransformBy(AccTrans);
		Vector3D vector3D2 = (Vector3D)circle.Plane.AxisY.Clone();
		vector3D2.TransformBy(AccTrans);
		Vector3D vector3D3 = (Vector3D)circle.Plane.AxisZ.Clone();
		vector3D3.TransformBy(AccTrans);
		double radius = circle.Radius;
		Center = point3D;
		AxisX = vector3D;
		AxisY = vector3D2;
		AxisZ = vector3D3;
		Radius = radius;
	}

	protected internal CircleConstraintData(CircleConstraintDataSurrogate surrogate)
		: base(surrogate)
	{
		Center = surrogate.Center;
		AxisX = surrogate.AxisX;
		AxisY = surrogate.AxisY;
		AxisZ = surrogate.AxisZ;
		Radius = surrogate.Radius;
	}

	public override ConstraintDataSurrogate ConvertToSurrogate()
	{
		return new CircleConstraintDataSurrogate(this);
	}
}
