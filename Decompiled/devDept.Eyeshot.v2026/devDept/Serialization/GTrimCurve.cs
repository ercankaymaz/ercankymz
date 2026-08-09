using System;

namespace devDept.Serialization;

[Serializable]
internal class GTrimCurve : GCurve
{
	public GEntity Edge;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GTrimCurveSurrogate(this);
	}
}
