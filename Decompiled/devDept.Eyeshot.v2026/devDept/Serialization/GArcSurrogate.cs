using devDept.Geometry;

namespace devDept.Serialization;

internal class GArcSurrogate : GCircleSurrogate
{
	public Interval Domain;

	public GArcSurrogate(GArc gArc)
		: base(gArc)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GArc gArc = new GArc();
		CopyDataToObject(gArc);
		return gArc;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		((GArc)entity).Domain = Domain;
		base.CopyDataToObject(entity);
	}
}
