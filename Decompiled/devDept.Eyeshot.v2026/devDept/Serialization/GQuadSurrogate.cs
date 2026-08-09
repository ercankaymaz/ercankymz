using devDept.Geometry;

namespace devDept.Serialization;

internal class GQuadSurrogate : GEntitySurrogate
{
	public Point3D V1;

	public Point3D V2;

	public Point3D V3;

	public Point3D V4;

	public Vector3D Normal;

	public GQuadSurrogate(GQuad gQuad)
		: base(gQuad)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GQuad gQuad = new GQuad();
		CopyDataToObject(gQuad);
		return gQuad;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		GQuad obj = (GQuad)gEntity;
		obj.V1 = V1;
		obj.V2 = V2;
		obj.V3 = V3;
		obj.V4 = V4;
		obj.Normal = Normal;
		base.CopyDataToObject(gEntity);
	}
}
