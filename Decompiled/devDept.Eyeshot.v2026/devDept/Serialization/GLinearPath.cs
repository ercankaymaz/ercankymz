using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GLinearPath : GEntity
{
	public Point3D[] Vertices;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GLinearPathSurrogate(this);
	}
}
