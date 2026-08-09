using devDept.Geometry;

namespace devDept.Serialization;

internal class GPlanarEntitySurrogate : GEntitySurrogate
{
	public Plane Plane;

	public GPlanarEntitySurrogate(GPlanarEntity gPlanarEntity)
		: base(gPlanarEntity)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GPlanarEntity gPlanarEntity = new GPlanarEntity();
		CopyDataToObject(gPlanarEntity);
		return gPlanarEntity;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		((GPlanarEntity)gEntity).Plane = Plane;
		base.CopyDataToObject(gEntity);
	}
}
