using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GPlanarSurface : GSurface
{
	public Plane Plane;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GPlanarSurfaceSurrogate(this);
	}
}
