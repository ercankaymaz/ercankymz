using devDept.Geometry;

namespace devDept.Serialization;

internal class GPointCloudSurrogate : GEntitySurrogate
{
	public Point3D[] Vertices;

	public GPointCloudSurrogate(GPointCloud gPointCloud)
		: base(gPointCloud)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GPointCloud gPointCloud = new GPointCloud();
		CopyDataToObject(gPointCloud);
		return gPointCloud;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		((GPointCloud)gEntity).Vertices = Vertices;
		base.CopyDataToObject(gEntity);
	}
}
