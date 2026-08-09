using devDept.Geometry;

namespace devDept.Serialization;

internal class GTabulatedSurfaceSurrogate : GSurfaceSurrogate
{
	public Vector3D Generatrix;

	public GEntity Directrix;

	public GTabulatedSurfaceSurrogate(GTabulatedSurface tabSurf)
		: base(tabSurf)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GTabulatedSurface gTabulatedSurface = new GTabulatedSurface();
		CopyDataToObject(gTabulatedSurface);
		return gTabulatedSurface;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		GTabulatedSurface obj = (GTabulatedSurface)entity;
		obj.Generatrix = Generatrix;
		obj.Directrix = Directrix;
		base.CopyDataToObject(entity);
	}
}
