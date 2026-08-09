using devDept.Geometry;

namespace devDept.Serialization;

internal class GEllipseSurrogate : GEntitySurrogate
{
	public Plane Plane;

	public double RadiusX;

	public double RadiusY;

	public GEllipseSurrogate(GEllipse gEllipse)
		: base(gEllipse)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GEllipse gEllipse = new GEllipse();
		CopyDataToObject(gEllipse);
		return gEllipse;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		GEllipse obj = (GEllipse)gEntity;
		obj.Plane = Plane;
		obj.RadiusX = RadiusX;
		obj.RadiusY = RadiusY;
		base.CopyDataToObject(gEntity);
	}
}
