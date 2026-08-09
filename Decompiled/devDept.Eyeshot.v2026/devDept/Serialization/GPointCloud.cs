using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GPointCloud : GEntity
{
	public Point3D[] Vertices;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GPointCloudSurrogate(this);
	}
}
