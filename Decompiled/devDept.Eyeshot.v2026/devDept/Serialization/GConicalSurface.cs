using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GConicalSurface : GCylindricalSurface
{
	public double HalfAngle;

	public Point3D Tip;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GConicalSurfaceSurrogate(this);
	}
}
