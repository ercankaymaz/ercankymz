using devDept.Geometry;

namespace devDept.Serialization;

internal class GCurveSurrogate : GNurbsBaseSurrogate
{
	public Point4D[] Pw;

	public GCurveSurrogate(GCurve gCurve)
		: base(gCurve)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GCurve gCurve = new GCurve();
		CopyDataToObject(gCurve);
		return gCurve;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		if (entity is GCurve gCurve)
		{
			gCurve.Pw = Pw;
		}
		base.CopyDataToObject(entity);
	}
}
