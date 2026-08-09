using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("SOLID")]
[DxfSubClass("AcDbTrace")]
public class Solid : Entity
{
	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ FirstCorner { get; set; }

	[DxfCodeValue(new int[] { 13, 23, 33 })]
	public XYZ FourthCorner { get; set; }

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "SOLID";

	public override ObjectType ObjectType => ObjectType.SOLID;

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ SecondCorner { get; set; }

	public override string SubclassMarker => "AcDbTrace";

	[DxfCodeValue(new int[] { 39 })]
	public double Thickness { get; set; }

	[DxfCodeValue(new int[] { 12, 22, 32 })]
	public XYZ ThirdCorner { get; set; }

	public override void ApplyTransform(Transform transform)
	{
		FirstCorner = transform.ApplyTransform(FirstCorner);
		SecondCorner = transform.ApplyTransform(SecondCorner);
		ThirdCorner = transform.ApplyTransform(ThirdCorner);
		FourthCorner = transform.ApplyTransform(FourthCorner);
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.FromPoints(new XYZ[4] { FirstCorner, SecondCorner, ThirdCorner, FourthCorner });
	}
}
