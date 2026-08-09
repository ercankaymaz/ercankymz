using System.Collections.Generic;
using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("3DFACE")]
[DxfSubClass("AcDbFace")]
public class Face3D : Entity
{
	public override ObjectType ObjectType => ObjectType.FACE3D;

	public override string ObjectName => "3DFACE";

	public override string SubclassMarker => "AcDbFace";

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ FirstCorner { get; set; }

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ SecondCorner { get; set; }

	[DxfCodeValue(new int[] { 12, 22, 32 })]
	public XYZ ThirdCorner { get; set; }

	[DxfCodeValue(new int[] { 13, 23, 33 })]
	public XYZ FourthCorner { get; set; }

	[DxfCodeValue(new int[] { 70 })]
	public InvisibleEdgeFlags Flags { get; set; }

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.FromPoints(new List<XYZ> { FirstCorner, SecondCorner, ThirdCorner, FourthCorner });
	}

	public override void ApplyTransform(Transform transform)
	{
		FirstCorner = transform.ApplyTransform(FirstCorner);
		SecondCorner = transform.ApplyTransform(SecondCorner);
		ThirdCorner = transform.ApplyTransform(ThirdCorner);
		FourthCorner = transform.ApplyTransform(FourthCorner);
	}
}
