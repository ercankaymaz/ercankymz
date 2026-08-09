using System;

namespace devDept.Serialization;

[Serializable]
internal class GToroidalSurface : GSphericalSurface
{
	public double MajorRadius;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GToroidalSurfaceSurrogate(this);
	}
}
