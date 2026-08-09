using System;
using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzVXCY8RRd2zEKsW1l3zjL4oUoVpS4otW94tTu1414tHCIPjdw0w_003D_003D : BoundingCone
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Point3D _0023_003DzoiHOosYEUTee;

	public bool _0023_003DzOXKIhX_0024HfeFabQgSxw_003D_003D(Point3D _0023_003Dzl3DhHgI_003D, double _0023_003DzbvIFYko_003D)
	{
		Vector3D vector3D = Vector3D.Subtract(_0023_003Dzl3DhHgI_003D, _0023_003DzoiHOosYEUTee);
		vector3D.Normalize();
		if (Axis * vector3D < Math.Sin(_0023_003DzbvIFYko_003D))
		{
			return true;
		}
		return false;
	}
}
