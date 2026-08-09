using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class PlanarEntitySurrogate : EntitySurrogate
{
	internal GPlanarEntity Primitive;

	public Plane Plane;

	public double SymbolSize;

	public Point3D[] Vertices;

	public PlanarEntitySurrogate(PlanarEntity planarEntity)
		: base(planarEntity)
	{
	}

	internal Plane _0023_003DzNY5YUv279_SW()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Plane;
		}
		return Primitive.Plane;
	}

	protected override Entity ConvertToObject()
	{
		PlanarEntity planarEntity = new PlanarEntity(this);
		CopyDataToObject(planarEntity);
		return planarEntity;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		entity.Vertices = Vertices;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		PlanarEntity planarEntity = (PlanarEntity)entity;
		Vertices = planarEntity.Vertices;
		Plane = planarEntity.Plane;
		SymbolSize = planarEntity.SymbolSize;
		base.CopyDataFromObject(entity);
	}
}
