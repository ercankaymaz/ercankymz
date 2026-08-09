using devDept.Geometry;

namespace devDept.Serialization;

internal class GSurfaceSurrogate : GNurbsBaseSurrogate
{
	public ProtoArray<Point4D> ControlPoints;

	public int DegreeV;

	public double[] KnotVectorV;

	public GRegion Trimming;

	public float TextureScaleU;

	public float TextureScaleV;

	public float TextureOffsetU;

	public float TextureOffsetV;

	public GSurfaceSurrogate(GSurface surf)
		: base(surf)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GSurface gSurface = new GSurface();
		CopyDataToObject(gSurface);
		return gSurface;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		if (entity is GSurface gSurface)
		{
			gSurface.ControlPoints = ControlPoints.ToArray() as Point4D[,];
			gSurface.DegreeV = DegreeV;
			gSurface.KnotVectorV = KnotVectorV;
			gSurface.Trimming = Trimming;
			gSurface.TextureScaleU = TextureScaleU;
			gSurface.TextureScaleV = TextureScaleV;
			gSurface.TextureOffsetU = TextureOffsetU;
			gSurface.TextureOffsetV = TextureOffsetV;
		}
		base.CopyDataToObject(entity);
	}
}
