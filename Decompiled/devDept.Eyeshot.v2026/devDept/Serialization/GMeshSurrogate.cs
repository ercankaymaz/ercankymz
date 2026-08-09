using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

internal class GMeshSurrogate : GEntitySurrogate
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

	public GMeshSurrogate(GMesh Gmesh)
		: base(Gmesh)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GMesh gMesh = new GMesh();
		CopyDataToObject(gMesh);
		return gMesh;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		if (entity is GMesh gMesh)
		{
			gMesh.Vertices = Vertices;
			gMesh.Triangles = Triangles;
			gMesh.MeshNature = (Mesh.natureType)MeshNature;
			gMesh.EdgeStyle = (Mesh.edgeStyleType)EdgeStyle;
			gMesh.TextureCoords = TextureCoords;
			gMesh.Normals = Normals;
			gMesh.Edges = Edges;
			gMesh.SmoothingAngle = SmoothingAngle;
			gMesh.LightWeight = LightWeight;
		}
		base.CopyDataToObject(entity);
	}
}
