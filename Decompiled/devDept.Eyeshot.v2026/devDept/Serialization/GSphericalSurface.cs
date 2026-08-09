using System;

namespace devDept.Serialization;

[Serializable]
internal class GSphericalSurface : GRevolvedSurface
{
	public double Radius;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GSphericalSurfaceSurrogate(this);
	}
}
