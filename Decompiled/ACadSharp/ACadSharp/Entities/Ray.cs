using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("RAY")]
[DxfSubClass("AcDbRay")]
public class Ray : Entity
{
	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ Direction { get; set; } = XYZ.Zero;

	public override string ObjectName => "RAY";

	public override ObjectType ObjectType => ObjectType.RAY;

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ StartPoint { get; set; } = XYZ.Zero;

	public override string SubclassMarker => "AcDbRay";

	public override void ApplyTransform(Transform transform)
	{
		StartPoint = transform.ApplyTransform(StartPoint);
		Direction = transform.ApplyRotation(Direction);
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Infinite;
	}
}
