using System.Collections.Generic;
using System.Linq;
using ProtoBuf;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class RegionSurrogate : EntitySurrogate
{
	internal GRegion Primitive;

	internal LinearPath[] GraphicalContours;

	public Plane Plane;

	public List<Entity> ContourList;

	public Point3D[] Vertices;

	public IndexTriangle[] Triangles;

	public IndexLine[] Edges;

	public RegionSurrogate(Region region)
		: base(region)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateMeshOrGhostEntity(Vertices, Triangles, typeof(Region));
		}
		Region region = new Region(this);
		CopyDataToObject(region);
		return region;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Region region)
		{
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
			{
				region.contourList = GEntity.CreateEntitiesFromPrimitives(Primitive.ContourList).Cast<ICurve>().ToList();
				region.Plane = Primitive.Plane;
				CompositeCurveSurrogate._0023_003DzRg_0024kh6sN6YXfeaJKgQ_003D_003D(region.ContourList, GraphicalContours);
			}
			else
			{
				region.contourList = ContourList.Cast<ICurve>().ToList();
				region.Plane = Plane;
			}
			region.Vertices = Vertices;
			region.Triangles = Triangles;
			region.Edges = Edges;
		}
		else if (entity is Mesh mesh)
		{
			mesh.Edges = Edges;
			mesh.UpdateNormals();
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Region region = (Region)entity;
		Plane = region.Plane;
		ContourList = region.ContourList.Cast<Entity>().ToList();
		Vertices = region.Vertices;
		Triangles = region.Triangles;
		Edges = region.Edges;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (Vertices == null || ((Vertices.Length == 0) | (Triangles == null)) || Triangles.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672044));
			return false;
		}
		return true;
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
