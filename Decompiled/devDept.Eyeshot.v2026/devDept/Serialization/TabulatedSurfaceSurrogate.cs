using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class TabulatedSurfaceSurrogate : SurfaceSurrogate
{
	public Vector3D Generatrix;

	public Entity Directrix;

	public TabulatedSurfaceSurrogate(TabulatedSurface tabSurf)
		: base(tabSurf)
	{
	}

	protected internal Vector3D GetGeneratrix()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Generatrix;
		}
		return ((GTabulatedSurface)Primitive).Generatrix;
	}

	protected internal Entity GetDirectrix()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Directrix;
		}
		return GEntity.CreateEntityFromPrimitive(((GTabulatedSurface)Primitive).Directrix);
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return base.ConvertToObject();
		}
		TabulatedSurface tabulatedSurface = new TabulatedSurface(this);
		CopyDataToObject(tabulatedSurface);
		return tabulatedSurface;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		TabulatedSurface tabulatedSurface = entity as TabulatedSurface;
		Generatrix = tabulatedSurface.Generatrix;
		Directrix = tabulatedSurface.Directrix as Entity;
		base.CopyDataFromObject(entity);
	}
}
