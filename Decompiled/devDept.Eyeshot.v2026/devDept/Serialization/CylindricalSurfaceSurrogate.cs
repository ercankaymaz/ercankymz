using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class CylindricalSurfaceSurrogate : RevolvedSurfaceSurrogate
{
	public double Radius;

	public CylindricalSurfaceSurrogate(CylindricalSurface cylSurf)
		: base(cylSurf)
	{
	}

	protected internal double GetRadius()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Radius;
		}
		return ((GCylindricalSurface)Primitive).Radius;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return base.ConvertToObject();
		}
		CylindricalSurface cylindricalSurface = new CylindricalSurface(this);
		CopyDataToObject(cylindricalSurface);
		return cylindricalSurface;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		CylindricalSurface cylindricalSurface = (CylindricalSurface)entity;
		Radius = cylindricalSurface.Radius;
		base.CopyDataFromObject(entity);
	}
}
