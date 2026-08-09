using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GPlanarEntity : GEntity
{
	public Plane Plane;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GPlanarEntitySurrogate(this);
	}
}
