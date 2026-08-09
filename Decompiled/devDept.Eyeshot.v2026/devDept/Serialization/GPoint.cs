using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GPoint : GEntity
{
	public Point3D Position;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GPointSurrogate(this);
	}
}
