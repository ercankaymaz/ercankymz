using System;

namespace devDept.Serialization;

[Serializable]
internal class GCircle : GPlanarEntity
{
	public double Radius;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GCircleSurrogate(this);
	}
}
