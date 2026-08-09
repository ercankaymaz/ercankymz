using devDept.Geometry;

namespace devDept.Serialization;

internal class GCircleSurrogate : GEntitySurrogate
{
	public Plane Plane;

	public double Radius;

	public GCircleSurrogate(GCircle gCircle)
		: base(gCircle)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GCircle gCircle = new GCircle();
		CopyDataToObject(gCircle);
		return gCircle;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		GCircle obj = (GCircle)entity;
		obj.Plane = Plane;
		obj.Radius = Radius;
		base.CopyDataToObject(entity);
	}
}
