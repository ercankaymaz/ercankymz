namespace devDept.Serialization;

internal abstract class GNurbsBaseSurrogate : GEntitySurrogate
{
	public int p;

	public double[] U;

	protected GNurbsBaseSurrogate(GNurbsBase gNurbsBase)
		: base(gNurbsBase)
	{
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		if (gEntity is GNurbsBase gNurbsBase)
		{
			gNurbsBase.P = p;
			gNurbsBase.U = U;
		}
		base.CopyDataToObject(gEntity);
	}
}
