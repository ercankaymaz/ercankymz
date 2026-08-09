using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class RadialDimSurrogate : DimensionSurrogate
{
	public double Radius;

	public byte Arrowhead;

	public double CenterMarkSize;

	public bool TrimLeader;

	public RadialDimSurrogate(RadialDim radialDim)
		: base(radialDim)
	{
	}

	protected override Entity ConvertToObject()
	{
		RadialDim radialDim = new RadialDim(this);
		CopyDataToObject(radialDim);
		return radialDim;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		RadialDim obj = entity as RadialDim;
		obj.Arrowhead = (arrowheadType)Arrowhead;
		obj.CenterMarkSize = CenterMarkSize;
		obj.TrimLeader = TrimLeader;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		RadialDim radialDim = entity as RadialDim;
		Radius = radialDim.Radius;
		Arrowhead = (byte)radialDim.Arrowhead;
		CenterMarkSize = radialDim.CenterMarkSize;
		TrimLeader = radialDim.TrimLeader;
		base.CopyDataFromObject(entity);
	}
}
