using ProtoBuf;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class CircleSurrogate : EntitySurrogate
{
	internal GCircle Primitive;

	public Plane Plane;

	public Point3D[] Vertices;

	public double Radius;

	public CircleSurrogate(Circle circle)
		: base(circle)
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

	protected internal double GetRadius()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Radius;
		}
		return Primitive.Radius;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateLinearPathOrGhostEntity(Vertices, typeof(Circle));
		}
		Circle circle = new Circle(this);
		CopyDataToObject(circle);
		return circle;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Circle circle)
		{
			circle.Vertices = Vertices;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Circle circle = (Circle)entity;
		Plane = circle.Plane;
		Vertices = circle.Vertices;
		Radius = circle.Radius;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (Vertices == null || Vertices.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670166));
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
