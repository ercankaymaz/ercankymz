using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GCurve : GNurbsBase
{
	public Point4D[] Pw;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GCurveSurrogate(this);
	}
}
