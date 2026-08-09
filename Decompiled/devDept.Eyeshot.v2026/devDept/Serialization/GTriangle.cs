using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GTriangle : GEntity
{
	public Point3D V1;

	public Point3D V2;

	public Point3D V3;

	public Vector3D Normal;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GTriangleSurrogate(this);
	}
}
