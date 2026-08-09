using devDept.Geometry;

namespace devDept.Serialization;

internal class GPointSurrogate : GEntitySurrogate
{
	public Point3D Position;

	public GPointSurrogate(GPoint gPoint)
		: base(gPoint)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GPoint gPoint = new GPoint();
		CopyDataToObject(gPoint);
		return gPoint;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		((GPoint)gEntity).Position = Position;
		base.CopyDataToObject(gEntity);
	}
}
