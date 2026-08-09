namespace devDept.Serialization;

internal class GSphericalSurfaceSurrogate : GRevolvedSurfaceSurrogate
{
	public double Radius;

	public GSphericalSurfaceSurrogate(GSphericalSurface sphericalSurf)
		: base(sphericalSurf)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GSphericalSurface gSphericalSurface = new GSphericalSurface();
		CopyDataToObject(gSphericalSurface);
		return gSphericalSurface;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		((GSphericalSurface)entity).Radius = Radius;
		base.CopyDataToObject(entity);
	}
}
