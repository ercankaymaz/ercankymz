using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("XLINE")]
[DxfSubClass("AcDbXline")]
public class XLine : Entity
{
	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ Direction { get; set; }

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ FirstPoint { get; set; }

	public override string ObjectName => "XLINE";

	public override ObjectType ObjectType => ObjectType.XLINE;

	public override string SubclassMarker => "AcDbXline";

	public override void ApplyTransform(Transform transform)
	{
		FirstPoint = transform.ApplyTransform(FirstPoint);
		Direction = transform.ApplyRotation(Direction);
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Infinite;
	}
}
