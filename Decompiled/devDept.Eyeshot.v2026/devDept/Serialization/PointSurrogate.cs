using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class PointSurrogate : EntitySurrogate
{
	internal GPoint Primitive;

	public Point3D[] Vertices;

	public PointSurrogate(Point point)
		: base(point)
	{
	}

	protected internal Point3D GetPosition()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Vertices[0];
		}
		return Primitive.Position;
	}

	protected override Entity ConvertToObject()
	{
		Point point = new Point(this);
		CopyDataToObject(point);
		return point;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Vertices = entity.Vertices;
		base.CopyDataFromObject(entity);
	}
}
