using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class LineSurrogate : EntitySurrogate
{
	internal GLine Primitive;

	public Point3D[] Vertices;

	public LineSurrogate(Line line)
		: base(line)
	{
	}

	protected internal Point3D GetStartPoint()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Vertices[0];
		}
		return Primitive.StartPoint;
	}

	protected internal Point3D GetEndPoint()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Vertices[1];
		}
		return Primitive.EndPoint;
	}

	protected override Entity ConvertToObject()
	{
		Line line = new Line(this);
		CopyDataToObject(line);
		return line;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Vertices = entity.Vertices;
		base.CopyDataFromObject(entity);
	}
}
