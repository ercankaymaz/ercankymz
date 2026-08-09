using System.Collections.Generic;

namespace devDept.Serialization;

internal class GCompositeCurveSurrogate : GEntitySurrogate
{
	public List<GEntity> CurveList;

	public GCompositeCurveSurrogate(GCompositeCurve compositeCurve)
		: base(compositeCurve)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GCompositeCurve gCompositeCurve = new GCompositeCurve();
		CopyDataToObject(gCompositeCurve);
		return gCompositeCurve;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		((GCompositeCurve)gEntity).CurveList = CurveList;
		base.CopyDataToObject(gEntity);
	}
}
