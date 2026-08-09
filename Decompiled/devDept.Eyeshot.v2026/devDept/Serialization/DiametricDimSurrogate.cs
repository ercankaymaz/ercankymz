using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class DiametricDimSurrogate : RadialDimSurrogate
{
	public byte LeftArrowhead;

	public byte RightArrowhead;

	public DiametricDimSurrogate(DiametricDim diamentricDim)
		: base(diamentricDim)
	{
	}

	protected override Entity ConvertToObject()
	{
		DiametricDim diametricDim = new DiametricDim(this);
		CopyDataToObject(diametricDim);
		return diametricDim;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		DiametricDim obj = entity as DiametricDim;
		obj.LeftArrowhead = (arrowheadType)LeftArrowhead;
		obj.RightArrowhead = (arrowheadType)RightArrowhead;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		DiametricDim diametricDim = entity as DiametricDim;
		LeftArrowhead = (byte)diametricDim.LeftArrowhead;
		RightArrowhead = (byte)diametricDim.RightArrowhead;
		base.CopyDataFromObject(entity);
	}
}
