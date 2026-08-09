using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GQuad : GEntity
{
	public Point3D V1;

	public Point3D V2;

	public Point3D V3;

	public Point3D V4;

	public Vector3D Normal;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GQuadSurrogate(this);
	}
}
