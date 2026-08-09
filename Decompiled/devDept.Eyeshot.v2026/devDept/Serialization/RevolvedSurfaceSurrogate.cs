using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class RevolvedSurfaceSurrogate : SurfaceSurrogate
{
	public Entity Generatrix;

	public Plane SeamPlane;

	public RevolvedSurfaceSurrogate(RevolvedSurface revSurf)
		: base(revSurf)
	{
	}

	protected internal Plane GetSeamPlane()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return SeamPlane;
		}
		return ((GRevolvedSurface)Primitive).SeamPlane;
	}

	protected internal Entity GetGeneratrix()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Generatrix;
		}
		return GEntity.CreateEntityFromPrimitive(((GRevolvedSurface)Primitive).Generatrix);
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return base.ConvertToObject();
		}
		RevolvedSurface revolvedSurface = new RevolvedSurface(this);
		CopyDataToObject(revolvedSurface);
		return revolvedSurface;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		RevolvedSurface revolvedSurface = (RevolvedSurface)entity;
		Generatrix = revolvedSurface.Generatrix as Entity;
		SeamPlane = revolvedSurface.SeamPlane;
		base.CopyDataFromObject(entity);
	}
}
