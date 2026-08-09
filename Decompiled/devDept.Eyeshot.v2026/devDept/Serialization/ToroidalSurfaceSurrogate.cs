using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class ToroidalSurfaceSurrogate : SphericalSurfaceSurrogate
{
	public double MajorRadius;

	public ToroidalSurfaceSurrogate(ToroidalSurface toroidalSurf)
		: base(toroidalSurf)
	{
	}

	protected internal double GetMajorRadius()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return MajorRadius;
		}
		return ((GToroidalSurface)Primitive).MajorRadius;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return base.ConvertToObject();
		}
		ToroidalSurface toroidalSurface = new ToroidalSurface(this);
		CopyDataToObject(toroidalSurface);
		return toroidalSurface;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		ToroidalSurface toroidalSurface = entity as ToroidalSurface;
		MajorRadius = toroidalSurface.MajorRadius;
		base.CopyDataFromObject(entity);
	}
}
