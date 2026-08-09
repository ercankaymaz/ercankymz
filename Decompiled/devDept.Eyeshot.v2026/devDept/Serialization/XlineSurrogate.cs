using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

internal class XlineSurrogate : PointSurrogate
{
	public Vector3D Direction;

	public XlineSurrogate(LinearEntity linearEntity)
		: base(null)
	{
	}

	protected internal new Point3D GetPosition()
	{
		return base.GetPosition();
	}

	protected override Entity ConvertToObject()
	{
		LinearEntity linearEntity = new LinearEntity(GetPosition(), Direction, 1.0);
		linearEntity._0023_003DzKBTqdfsMT5pPIyN8xg_003D_003D();
		CopyDataToObject(linearEntity);
		return linearEntity;
	}
}
