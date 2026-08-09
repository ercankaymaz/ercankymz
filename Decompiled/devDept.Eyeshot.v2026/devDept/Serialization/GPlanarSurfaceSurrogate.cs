using devDept.Geometry;

namespace devDept.Serialization;

internal class GPlanarSurfaceSurrogate : GSurfaceSurrogate
{
	public Plane Plane;

	public GPlanarSurfaceSurrogate(GPlanarSurface planarSurf)
		: base(planarSurf)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GPlanarSurface gPlanarSurface = new GPlanarSurface();
		CopyDataToObject(gPlanarSurface);
		return gPlanarSurface;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		if (entity is GPlanarSurface gPlanarSurface)
		{
			gPlanarSurface.Plane = Plane;
		}
		base.CopyDataToObject(entity);
	}
}
