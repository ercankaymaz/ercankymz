using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class SphericalSurfaceSurrogate : RevolvedSurfaceSurrogate
{
	public double Radius;

	public SphericalSurfaceSurrogate(SphericalSurface sphericalSurf)
		: base(sphericalSurf)
	{
	}

	protected internal double GetRadius()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Radius;
		}
		return ((GSphericalSurface)Primitive).Radius;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return base.ConvertToObject();
		}
		SphericalSurface sphericalSurface = new SphericalSurface(this);
		CopyDataToObject(sphericalSurface);
		return sphericalSurface;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		SphericalSurface sphericalSurface = (SphericalSurface)entity;
		Radius = sphericalSurface.Radius;
		base.CopyDataFromObject(entity);
	}
}
