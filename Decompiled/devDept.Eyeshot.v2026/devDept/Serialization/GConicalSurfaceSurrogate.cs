using devDept.Geometry;

namespace devDept.Serialization;

internal class GConicalSurfaceSurrogate : GCylindricalSurfaceSurrogate
{
	public double HalfAngle;

	public Point3D Tip;

	public GConicalSurfaceSurrogate(GConicalSurface conicalSurf)
		: base(conicalSurf)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GConicalSurface gConicalSurface = new GConicalSurface();
		CopyDataToObject(gConicalSurface);
		return gConicalSurface;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		GConicalSurface obj = (GConicalSurface)entity;
		obj.HalfAngle = HalfAngle;
		obj.Tip = Tip;
		base.CopyDataToObject(entity);
	}
}
