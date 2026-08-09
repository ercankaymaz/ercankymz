using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

internal class GPortionSurrogate : GEntitySurrogate
{
	public byte MeshNature;

	public byte EdgeStyle;

	public Point3D[] Vertices;

	public IndexTriangle[] Triangles;

	public PointF[] TextureCoords;

	public Vector3D[] Normals;

	public IndexLine[] Edges;

	public double SmoothingAngle;

	public bool LightWeight;

	public int Id;

	public Solid.EdgeData[] EdgeDatas;

	public Solid.Face[] Faces;

	public Solid.Cycle[] Cycles;

	internal int vertexCount;

	internal int edgeCount;

	internal int faceCount;

	internal int contourCount;

	internal int MaxNov;

	internal int MaxNoe;

	internal int MaxNof;

	internal int MaxNoc;

	internal int novTemp;

	internal List<IndexLine> isoCurves;

	public GPortionSurrogate(GSolid.Portion portion)
		: base(portion)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GSolid.Portion portion = new GSolid.Portion();
		CopyDataToObject(portion);
		return portion;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		GMesh obj = (GMesh)entity;
		obj.MeshNature = (Mesh.natureType)MeshNature;
		obj.EdgeStyle = (Mesh.edgeStyleType)EdgeStyle;
		obj.Triangles = Triangles;
		obj.TextureCoords = TextureCoords;
		obj.Normals = Normals;
		obj.Edges = Edges;
		obj.SmoothingAngle = SmoothingAngle;
		obj.LightWeight = LightWeight;
		GSolid.Portion portion = (GSolid.Portion)entity;
		portion.Id = Id;
		portion.EdgeDatas = EdgeDatas;
		portion.Faces = Faces;
		portion.Cycles = Cycles;
		portion.VertexCount = vertexCount;
		portion.EdgeCount = edgeCount;
		portion.FaceCount = faceCount;
		portion.ContourCount = contourCount;
		portion.MaxNov = MaxNov;
		portion.MaxNoe = MaxNoe;
		portion.MaxNof = MaxNof;
		portion.MaxNoc = MaxNoc;
		portion.NovTemp = novTemp;
		portion.IsoCurves = isoCurves ?? new List<IndexLine>();
		base.CopyDataToObject(entity);
		if (vertexCount > MaxNov)
		{
			MaxNov = (novTemp = vertexCount);
		}
		portion.Vertices = new Point3D[MaxNov];
		int i;
		for (i = 0; i < portion.VertexCount; i++)
		{
			portion.Vertices[i] = Vertices[i];
		}
		for (int j = novTemp; j < MaxNov; j++)
		{
			portion.Vertices[j] = Vertices[i++];
		}
	}
}
