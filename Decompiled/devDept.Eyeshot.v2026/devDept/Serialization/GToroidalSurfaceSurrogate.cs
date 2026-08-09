namespace devDept.Serialization;

internal class GToroidalSurfaceSurrogate : GSphericalSurfaceSurrogate
{
	public double MajorRadius;

	public GToroidalSurfaceSurrogate(GToroidalSurface toroidalSurf)
		: base(toroidalSurf)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GToroidalSurface gToroidalSurface = new GToroidalSurface();
		CopyDataToObject(gToroidalSurface);
		return gToroidalSurface;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		((GToroidalSurface)entity).MajorRadius = MajorRadius;
		base.CopyDataToObject(entity);
	}
}
