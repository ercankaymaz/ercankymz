using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class PointCloudSurrogate : EntitySurrogate
{
	internal GPointCloud Primitive;

	public Point3D[] Vertices;

	public byte Nature;

	public byte DrawingStyle;

	public PointCloudSurrogate(PointCloud pc)
		: base(pc)
	{
	}

	protected internal Point3D[] GetVertices()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Vertices;
		}
		return Primitive.Vertices;
	}

	protected override Entity ConvertToObject()
	{
		PointCloud pointCloud = new PointCloud(this);
		CopyDataToObject(pointCloud);
		return pointCloud;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		PointCloud obj = entity as PointCloud;
		obj._0023_003DzScoU3aJTt_0024kunjs7lA_003D_003D((PointCloud.natureType)Nature);
		obj.DrawingStyle = (PointCloud.drawingStyleType)DrawingStyle;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		PointCloud pointCloud = entity as PointCloud;
		Vertices = pointCloud.Vertices;
		Nature = (byte)pointCloud.Nature;
		DrawingStyle = (byte)pointCloud.DrawingStyle;
		base.CopyDataFromObject(entity);
	}
}
