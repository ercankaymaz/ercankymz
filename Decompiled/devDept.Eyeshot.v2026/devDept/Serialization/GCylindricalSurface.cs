using System;

namespace devDept.Serialization;

[Serializable]
internal class GCylindricalSurface : GRevolvedSurface
{
	public double Radius;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GCylindricalSurfaceSurrogate(this);
	}
}
