using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GSurface : GNurbsBase
{
	public Point4D[,] ControlPoints;

	public int DegreeV;

	public double[] KnotVectorV;

	public GRegion Trimming;

	public float TextureScaleU;

	public float TextureScaleV;

	public float TextureOffsetU;

	public float TextureOffsetV;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GSurfaceSurrogate(this);
	}
}
