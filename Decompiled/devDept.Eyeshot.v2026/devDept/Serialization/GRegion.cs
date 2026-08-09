using System;
using System.Collections.Generic;

namespace devDept.Serialization;

[Serializable]
internal class GRegion : GPlanarEntity
{
	public List<GEntity> ContourList;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GRegionSurrogate(this);
	}
}
