using System;
using System.Collections.Generic;

namespace devDept.Serialization;

[Serializable]
internal class GCompositeCurve : GEntity
{
	public List<GEntity> CurveList;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GCompositeCurveSurrogate(this);
	}
}
