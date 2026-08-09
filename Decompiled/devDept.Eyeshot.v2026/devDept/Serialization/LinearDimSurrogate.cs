using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class LinearDimSurrogate : DimensionSurrogate
{
	public Point3D ExtLine1;

	public Point3D ExtLine2;

	public double ExtLineExt;

	public double ExtLineOffset;

	public byte LeftArrowhead;

	public byte RightArrowhead;

	public bool ShowExtLine1;

	public bool ShowExtLine2;

	public LinearDimSurrogate(LinearDim linearDim)
		: base(linearDim)
	{
	}

	protected override Entity ConvertToObject()
	{
		LinearDim linearDim = new LinearDim(this);
		CopyDataToObject(linearDim);
		return linearDim;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		LinearDim obj = entity as LinearDim;
		obj.ExtLineExt = ExtLineExt;
		obj.ExtLineOffset = ExtLineOffset;
		obj.LeftArrowhead = (arrowheadType)LeftArrowhead;
		obj.RightArrowhead = (arrowheadType)RightArrowhead;
		obj.ShowExtLine1 = ShowExtLine1;
		obj.ShowExtLine2 = ShowExtLine2;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		LinearDim linearDim = entity as LinearDim;
		ExtLine1 = linearDim.ExtLine1;
		ExtLine2 = linearDim.ExtLine2;
		ExtLineExt = linearDim.ExtLineExt;
		ExtLineOffset = linearDim.ExtLineOffset;
		LeftArrowhead = (byte)linearDim.LeftArrowhead;
		RightArrowhead = (byte)linearDim.RightArrowhead;
		ShowExtLine1 = linearDim.ShowExtLine1;
		ShowExtLine2 = linearDim.ShowExtLine2;
		base.CopyDataFromObject(entity);
	}
}
