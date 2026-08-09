using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class MeshSurrogate : EntitySurrogate
{
	internal GMesh Primitive;

	public byte MeshNature;

	public byte EdgeStyle;

	public Point3D[] Vertices;

	public IndexTriangle[] Triangles;

	public PointF[] TextureCoords;

	public Vector3D[] Normals;

	public IndexLine[] Edges;

	public double SmoothingAngle;

	public bool LightWeight;

	public MeshSurrogate(Mesh mesh)
		: base(mesh)
	{
	}

	protected internal Mesh.natureType GetMeshNature()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return (Mesh.natureType)MeshNature;
		}
		return Primitive.MeshNature;
	}

	protected internal Mesh.edgeStyleType GetEdgeStyle()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return (Mesh.edgeStyleType)EdgeStyle;
		}
		return Primitive.EdgeStyle;
	}

	protected internal Point3D[] GetVertices()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Vertices;
		}
		return Primitive.Vertices;
	}

	protected internal IndexTriangle[] GetTriangles()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Triangles;
		}
		return Primitive.Triangles;
	}

	protected override Entity ConvertToObject()
	{
		if (CheckSurrogateData(string.Empty))
		{
			Mesh mesh = new Mesh(this);
			CopyDataToObject(mesh);
			return mesh;
		}
		WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671541));
		return CreateGhostEntity(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672254));
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Mesh mesh)
		{
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
			{
				mesh._vertices = Primitive.Vertices;
				mesh._triangles = Primitive.Triangles;
				mesh._meshNature = Primitive.MeshNature;
				mesh.EdgeStyle = Primitive.EdgeStyle;
				mesh.TextureCoords = Primitive.TextureCoords;
				mesh.Normals = Primitive.Normals;
				mesh.Edges = Primitive.Edges;
				mesh.SmoothingAngle = Primitive.SmoothingAngle;
				mesh.LightWeight = Primitive.LightWeight;
			}
			else
			{
				mesh._vertices = Vertices;
				mesh._triangles = Triangles;
				mesh._meshNature = (Mesh.natureType)MeshNature;
				mesh.EdgeStyle = (Mesh.edgeStyleType)EdgeStyle;
				mesh.TextureCoords = TextureCoords;
				mesh.Normals = Normals;
				mesh.Edges = Edges;
				mesh.SmoothingAngle = SmoothingAngle;
				mesh.LightWeight = LightWeight;
			}
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Mesh mesh = (Mesh)entity;
		Vertices = mesh.Vertices;
		Triangles = mesh.Triangles;
		MeshNature = (byte)mesh.MeshNature;
		EdgeStyle = (byte)mesh.EdgeStyle;
		TextureCoords = mesh.TextureCoords;
		Normals = mesh.Normals;
		Edges = mesh.Edges;
		SmoothingAngle = mesh.SmoothingAngle;
		LightWeight = mesh.LightWeight;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		Point3D[] vertices = GetVertices();
		IndexTriangle[] triangles = GetTriangles();
		if (vertices == null || vertices.Length == 0)
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672196));
			return false;
		}
		if (triangles == null || triangles.Length == 0)
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672167));
			return false;
		}
		return true;
	}
}
