using System;
using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

public class BoundingCone
{
	public Vector3D Axis;

	public double HalfAngle;

	public bool IsSubsetOf(BoundingCone other)
	{
		double num = Vector3D.AngleBetween(Axis, other.Axis);
		if (num + HalfAngle < other.HalfAngle || Math.PI - num + HalfAngle < other.HalfAngle)
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957449), Axis.X, Axis.Y, Axis.Z, HalfAngle, Utility.RadToDeg(HalfAngle));
	}

	public bool Contains(Vector3D v, double tol = 0.01)
	{
		Vector3D vector3D = (Vector3D)Axis.Clone();
		vector3D.Normalize();
		double num = Math.Acos(Vector3D.Dot(v, vector3D));
		if (!(num <= HalfAngle))
		{
			return Math.Abs(num - HalfAngle) <= tol;
		}
		return true;
	}
}
