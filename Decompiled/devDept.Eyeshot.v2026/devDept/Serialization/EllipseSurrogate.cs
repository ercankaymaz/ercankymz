using ProtoBuf;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class EllipseSurrogate : EntitySurrogate
{
	internal GEllipse Primitive;

	public Plane Plane;

	public Point3D[] Vertices;

	public double RadiusX;

	public double RadiusY;

	public EllipseSurrogate(Ellipse ellipse)
		: base(ellipse)
	{
	}

	protected internal Plane GetPlane()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Plane;
		}
		return Primitive.Plane;
	}

	protected internal double GetRadiusX()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return RadiusX;
		}
		return Primitive.RadiusX;
	}

	protected internal double GetRadiusY()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return RadiusY;
		}
		return Primitive.RadiusY;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateLinearPathOrGhostEntity(Vertices, typeof(Ellipse));
		}
		Ellipse ellipse = new Ellipse(this);
		CopyDataToObject(ellipse);
		return ellipse;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Ellipse ellipse)
		{
			ellipse.Vertices = Vertices;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Ellipse ellipse = (Ellipse)entity;
		Plane = ellipse.Plane;
		Vertices = ellipse.Vertices;
		RadiusX = ellipse.RadiusX;
		RadiusY = ellipse.RadiusY;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (Vertices == null || Vertices.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669892));
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
