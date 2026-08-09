using devDept.Geometry;

namespace devDept.Serialization;

internal class GRevolvedSurfaceSurrogate : GSurfaceSurrogate
{
	public GEntity Generatrix;

	public Plane SeamPlane;

	public GRevolvedSurfaceSurrogate(GRevolvedSurface revSurf)
		: base(revSurf)
	{
	}

	protected override GEntity ConvertToObject()
	{
		ControlPoints.ToArray();
		GRevolvedSurface gRevolvedSurface = new GRevolvedSurface();
		CopyDataToObject(gRevolvedSurface);
		return gRevolvedSurface;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		GRevolvedSurface obj = (GRevolvedSurface)entity;
		obj.Generatrix = Generatrix;
		obj.SeamPlane = SeamPlane;
		base.CopyDataToObject(entity);
	}
}
