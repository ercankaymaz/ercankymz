using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GLine : GEntity
{
	public Point3D StartPoint;

	public Point3D EndPoint;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GLineSurrogate(this);
	}
}
