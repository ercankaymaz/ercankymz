using System.Collections.Generic;
using devDept.Geometry;

namespace devDept.Serialization;

internal class GRegionSurrogate : GEntitySurrogate
{
	public Plane Plane;

	public List<GEntity> ContourList;

	public GRegionSurrogate(GRegion region)
		: base(region)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GRegion gRegion = new GRegion();
		CopyDataToObject(gRegion);
		return gRegion;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		GRegion obj = (GRegion)entity;
		obj.ContourList = ContourList;
		obj.Plane = Plane;
		base.CopyDataToObject(entity);
	}
}
