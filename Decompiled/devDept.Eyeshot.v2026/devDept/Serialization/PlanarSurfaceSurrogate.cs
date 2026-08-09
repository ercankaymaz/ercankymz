using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class PlanarSurfaceSurrogate : SurfaceSurrogate
{
	public Plane Plane;

	public PlanarSurfaceSurrogate(PlanarSurface planarSurf)
		: base(planarSurf)
	{
	}

	protected internal Plane GetPlane()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Plane;
		}
		return ((GPlanarSurface)Primitive).Plane;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return base.ConvertToObject();
		}
		PlanarSurface planarSurface = new PlanarSurface(this);
		CopyDataToObject(planarSurface);
		return planarSurface;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		PlanarSurface planarSurface = (PlanarSurface)entity;
		Plane = planarSurface.Plane;
		base.CopyDataFromObject(entity);
	}
}
