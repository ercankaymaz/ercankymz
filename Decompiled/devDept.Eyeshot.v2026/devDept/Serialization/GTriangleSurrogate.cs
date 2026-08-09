using devDept.Geometry;

namespace devDept.Serialization;

internal class GTriangleSurrogate : GEntitySurrogate
{
	public Point3D V1;

	public Point3D V2;

	public Point3D V3;

	public Vector3D Normal;

	public GTriangleSurrogate(GTriangle gTriangle)
		: base(gTriangle)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GTriangle gTriangle = new GTriangle();
		CopyDataToObject(gTriangle);
		return gTriangle;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		GTriangle obj = (GTriangle)gEntity;
		obj.V1 = V1;
		obj.V2 = V2;
		obj.V3 = V3;
		obj.Normal = Normal;
		base.CopyDataToObject(gEntity);
	}
}
