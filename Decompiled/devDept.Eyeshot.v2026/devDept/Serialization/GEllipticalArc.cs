using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GEllipticalArc : GEllipse
{
	public Interval Domain;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GEllipticalArcSurrogate(this);
	}
}
