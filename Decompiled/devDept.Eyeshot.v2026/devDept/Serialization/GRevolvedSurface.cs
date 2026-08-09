using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GRevolvedSurface : GSurface
{
	public GEntity Generatrix;

	public Plane SeamPlane;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GRevolvedSurfaceSurrogate(this);
	}
}
