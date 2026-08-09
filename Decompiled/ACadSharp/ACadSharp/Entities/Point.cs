using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("POINT")]
[DxfSubClass("AcDbPoint")]
public class Point : Entity
{
	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ Location { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "POINT";

	public override ObjectType ObjectType => ObjectType.POINT;

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double Rotation { get; set; }

	public override string SubclassMarker => "AcDbPoint";

	[DxfCodeValue(new int[] { 39 })]
	public double Thickness { get; set; }

	public Point()
	{
	}

	public Point(XYZ location)
	{
		Location = location;
	}

	public override void ApplyTransform(Transform transform)
	{
		Location = transform.ApplyTransform(Location);
		Normal = transformNormal(transform, Normal);
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(Location);
	}
}
