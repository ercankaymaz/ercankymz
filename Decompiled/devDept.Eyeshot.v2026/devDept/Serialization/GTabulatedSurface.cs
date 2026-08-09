using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GTabulatedSurface : GSurface
{
	public Vector3D Generatrix;

	public GEntity Directrix;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GTabulatedSurfaceSurrogate(this);
	}
}
