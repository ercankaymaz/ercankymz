using devDept.Geometry;

namespace devDept.Serialization;

internal class GEllipticalArcSurrogate : GEllipseSurrogate
{
	public Interval Domain;

	public GEllipticalArcSurrogate(GEllipticalArc gEllipticalArc)
		: base(gEllipticalArc)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GEllipticalArc gEllipticalArc = new GEllipticalArc();
		CopyDataToObject(gEllipticalArc);
		return gEllipticalArc;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		((GEllipticalArc)gEntity).Domain = Domain;
		base.CopyDataToObject(gEntity);
	}
}
