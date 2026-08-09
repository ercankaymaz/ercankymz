using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class LinearEntitySurrogate : EntitySurrogate
{
	public double SymbolSize;

	public Point3D Position;

	public Vector3D Direction;

	public LinearEntitySurrogate(LinearEntity xLine)
		: base(xLine)
	{
	}

	protected override Entity ConvertToObject()
	{
		LinearEntity linearEntity = new LinearEntity(this);
		CopyDataToObject(linearEntity);
		return linearEntity;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		LinearEntity linearEntity = (LinearEntity)entity;
		SymbolSize = linearEntity.SymbolSize;
		Position = linearEntity.Position;
		Direction = linearEntity.Direction;
		base.CopyDataFromObject(entity);
	}
}
