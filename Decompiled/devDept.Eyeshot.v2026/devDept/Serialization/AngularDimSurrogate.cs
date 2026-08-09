using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class AngularDimSurrogate : DimensionSurrogate
{
	public Point3D ExtLine1;

	public Point3D ExtLine2;

	public double ExtLineExt;

	public double ExtLineOffset;

	public byte LeftArrowhead;

	public byte RightArrowhead;

	public byte AngleFormat;

	public bool ShowExtLine1;

	public bool ShowExtLine2;

	public AngularDimSurrogate(AngularDim angularDim)
		: base(angularDim)
	{
	}

	protected override Entity ConvertToObject()
	{
		AngularDim angularDim = new AngularDim(this);
		angularDim.AngleFormat = (angleFormatType)AngleFormat;
		CopyDataToObject(angularDim);
		return angularDim;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		AngularDim angularDim = entity as AngularDim;
		angularDim.ExtLineExt = ExtLineExt;
		angularDim.ExtLineOffset = ExtLineOffset;
		angularDim.LeftArrowhead = (arrowheadType)LeftArrowhead;
		angularDim.RightArrowhead = (arrowheadType)RightArrowhead;
		if (base.Version < 7)
		{
			angularDim.AngleFormat = angleFormatType.DecimalDegrees;
		}
		else
		{
			angularDim.AngleFormat = (angleFormatType)AngleFormat;
			angularDim.ShowExtLine1 = ShowExtLine1;
			angularDim.ShowExtLine2 = ShowExtLine2;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		AngularDim angularDim = entity as AngularDim;
		ExtLine1 = angularDim.ExtLine1;
		ExtLine2 = angularDim.ExtLine2;
		ExtLineExt = angularDim.ExtLineExt;
		ExtLineOffset = angularDim.ExtLineOffset;
		LeftArrowhead = (byte)angularDim.LeftArrowhead;
		RightArrowhead = (byte)angularDim.RightArrowhead;
		AngleFormat = (byte)angularDim.AngleFormat;
		ShowExtLine1 = angularDim.ShowExtLine1;
		ShowExtLine2 = angularDim.ShowExtLine2;
		base.CopyDataFromObject(entity);
	}
}
