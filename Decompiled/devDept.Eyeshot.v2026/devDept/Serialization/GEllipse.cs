using System;

namespace devDept.Serialization;

[Serializable]
internal class GEllipse : GPlanarEntity
{
	public double RadiusX;

	public double RadiusY;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GEllipseSurrogate(this);
	}
}
