using System.Collections.Generic;
using System.Drawing;
using ProtoBuf;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class PortionSurrogate : EntitySurrogate
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

	internal GSolid.Portion Primitive;

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

	public PortionSurrogate(Solid.Portion portion)
		: base(portion)
	{
	}

	protected internal Solid.EdgeData[] GetEdgeDatas()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return EdgeDatas;
		}
		return Primitive.EdgeDatas;
	}

	protected internal Solid.Face[] GetFaces()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Faces;
		}
		return Primitive.Faces;
	}

	protected internal Solid.Cycle[] GetCycles()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Cycles;
		}
		return Primitive.Cycles;
	}

	protected internal Point3D[] GetVertices()
	{
		Point3D[] array = (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version) ? Primitive.Vertices : Vertices);
		if (vertexCount > MaxNov)
		{
			MaxNov = (novTemp = vertexCount);
		}
		Point3D[] array2 = new Point3D[MaxNov];
		for (int i = 0; i < vertexCount; i++)
		{
			array2[i] = array[i];
		}
		if (MaxNov - novTemp == array.Length - vertexCount)
		{
			int num = vertexCount;
			for (int j = novTemp; j < MaxNov; j++)
			{
				array2[j] = array[num++];
			}
		}
		return array2;
	}

	protected internal int GetId()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Id;
		}
		return Primitive.Id;
	}

	protected override Entity ConvertToObject()
	{
		Solid.Portion portion = new Solid.Portion(this);
		CopyDataToObject(portion);
		return portion;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Mesh mesh = (Mesh)entity;
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
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
			mesh._triangles = Triangles;
			mesh._meshNature = (Mesh.natureType)MeshNature;
			mesh.EdgeStyle = (Mesh.edgeStyleType)EdgeStyle;
			mesh.TextureCoords = TextureCoords;
			mesh.Normals = Normals;
			mesh.Edges = Edges;
			mesh.SmoothingAngle = SmoothingAngle;
			mesh.LightWeight = LightWeight;
		}
		Solid.Portion portion = (Solid.Portion)entity;
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			portion.isoCurves = Primitive.IsoCurves ?? new List<IndexLine>();
		}
		else
		{
			portion.isoCurves = isoCurves ?? new List<IndexLine>();
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Mesh mesh = entity as Mesh;
		Vertices = mesh.Vertices;
		Triangles = mesh.Triangles;
		MeshNature = (byte)mesh.MeshNature;
		EdgeStyle = (byte)mesh.EdgeStyle;
		TextureCoords = mesh.TextureCoords;
		Normals = mesh.Normals;
		Edges = mesh.Edges;
		SmoothingAngle = mesh.SmoothingAngle;
		LightWeight = mesh.LightWeight;
		Solid.Portion portion = entity as Solid.Portion;
		Id = portion.Id;
		EdgeDatas = portion.EdgeDatas;
		Faces = portion.Faces;
		Cycles = portion.Cycles;
		vertexCount = portion.vertexCount;
		edgeCount = portion.edgeCount;
		faceCount = portion.faceCount;
		contourCount = portion.contourCount;
		MaxNov = portion.MaxNov;
		MaxNoe = portion.MaxNoe;
		MaxNof = portion.MaxNof;
		MaxNoc = portion.MaxNoc;
		novTemp = portion.novTemp;
		isoCurves = portion.isoCurves;
		base.CopyDataFromObject(entity);
	}

	protected override void AfterDeserialize(SerializationContext serializationContext)
	{
		base.AfterDeserialize(serializationContext);
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version) && Primitive?.EntityData != null)
		{
			EntityData = new ProtoObject(Primitive.EntityData);
		}
	}
}
