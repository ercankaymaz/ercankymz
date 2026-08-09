using System;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GArc : GCircle
{
	public Interval Domain;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GArcSurrogate(this);
	}
}
