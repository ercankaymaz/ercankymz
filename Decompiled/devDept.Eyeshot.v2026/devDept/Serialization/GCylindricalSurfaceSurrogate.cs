namespace devDept.Serialization;

internal class GCylindricalSurfaceSurrogate : GRevolvedSurfaceSurrogate
{
	public double Radius;

	public GCylindricalSurfaceSurrogate(GCylindricalSurface cylSurf)
		: base(cylSurf)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GCylindricalSurface gCylindricalSurface = new GCylindricalSurface();
		CopyDataToObject(gCylindricalSurface);
		return gCylindricalSurface;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		((GCylindricalSurface)entity).Radius = Radius;
		base.CopyDataToObject(entity);
	}
}
