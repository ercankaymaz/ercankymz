using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class FastPointCloudSurrogate : EntitySurrogate
{
	public float[] PointArray;

	public byte[] ColorArray;

	public byte Nature;

	public byte DrawingStyle;

	public int ZoomFitSpeed;

	public FastPointCloudSurrogate(FastPointCloud fpc)
		: base(fpc)
	{
	}

	protected override Entity ConvertToObject()
	{
		FastPointCloud fastPointCloud = new FastPointCloud(PointArray, ColorArray);
		CopyDataToObject(fastPointCloud);
		return fastPointCloud;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		FastPointCloud obj = entity as FastPointCloud;
		obj.Nature = (PointCloud.natureType)Nature;
		obj.DrawingStyle = (PointCloud.drawingStyleType)DrawingStyle;
		obj.ZoomFitSpeed = ZoomFitSpeed;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		FastPointCloud fastPointCloud = entity as FastPointCloud;
		PointArray = fastPointCloud.PointArray;
		ColorArray = fastPointCloud.ColorArray;
		Nature = (byte)fastPointCloud.Nature;
		DrawingStyle = (byte)fastPointCloud.DrawingStyle;
		ZoomFitSpeed = fastPointCloud.ZoomFitSpeed;
		base.CopyDataFromObject(entity);
	}
}
