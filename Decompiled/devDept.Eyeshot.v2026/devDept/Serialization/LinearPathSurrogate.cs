using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class LinearPathSurrogate : EntitySurrogate
{
	internal GLinearPath Primitive;

	public Point3D[] Vertices;

	public double GlobalWidth;

	private List<Point3D> GlobalWidthVertices;

	public LinearPathSurrogate(LinearPath linearPath)
		: base(linearPath)
	{
	}

	protected internal Point3D[] GetVertices()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Vertices;
		}
		return Primitive.Vertices;
	}

	protected override Entity ConvertToObject()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return CreateLinearPathOrGhostEntity(Vertices, typeof(LinearPath));
		}
		return _0023_003DzlhB2gVPTKbvi9Its0Q_003D_003D(Primitive, typeof(LinearPath));
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is LinearPath linearPath)
		{
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version) && Primitive.Vertices != null)
			{
				linearPath._vertices = Primitive.Vertices;
			}
			linearPath.GlobalWidth = GlobalWidth;
			linearPath.GlobalWidthVertices = GlobalWidthVertices;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		LinearPath linearPath = (LinearPath)entity;
		Vertices = linearPath.Vertices;
		GlobalWidth = linearPath.GlobalWidth;
		GlobalWidthVertices = linearPath.GlobalWidthVertices;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			if (Primitive.Vertices == null || Primitive.Vertices.Length == 0)
			{
				WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671379));
				return false;
			}
		}
		else if (Vertices == null || Vertices.Length == 0)
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671596));
			return false;
		}
		return true;
	}
}
