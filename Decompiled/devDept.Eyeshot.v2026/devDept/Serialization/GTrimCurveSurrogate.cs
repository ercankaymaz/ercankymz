namespace devDept.Serialization;

internal class GTrimCurveSurrogate : GCurveSurrogate
{
	public GEntity Edge;

	public GTrimCurveSurrogate(GTrimCurve gTrimCurve)
		: base(gTrimCurve)
	{
	}

	protected override GEntity ConvertToObject()
	{
		GTrimCurve gTrimCurve = new GTrimCurve();
		CopyDataToObject(gTrimCurve);
		return gTrimCurve;
	}

	protected override void CopyDataToObject(GEntity entity)
	{
		if (entity is GTrimCurve gTrimCurve)
		{
			gTrimCurve.Edge = Edge;
		}
		base.CopyDataToObject(entity);
	}
}
