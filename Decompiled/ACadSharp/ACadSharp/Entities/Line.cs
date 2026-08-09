using System;
using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("LINE")]
[DxfSubClass("AcDbLine")]
public class Line : Entity
{
	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ EndPoint { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "LINE";

	public override ObjectType ObjectType => ObjectType.LINE;

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ StartPoint { get; set; } = XYZ.Zero;

	public override string SubclassMarker => "AcDbLine";

	[DxfCodeValue(new int[] { 39 })]
	public double Thickness { get; set; }

	public Line()
	{
	}

	public Line(IVector start, IVector end)
	{
		StartPoint = start.Convert<XYZ>();
		EndPoint = end.Convert<XYZ>();
	}

	public Line(XYZ start, XYZ end)
	{
		StartPoint = start;
		EndPoint = end;
	}

	public override void ApplyTransform(Transform transform)
	{
		StartPoint = transform.ApplyTransform(StartPoint);
		EndPoint = transform.ApplyTransform(EndPoint);
		Normal = transformNormal(transform, Normal);
	}

	public override BoundingBox GetBoundingBox()
	{
		XYZ min = new XYZ(Math.Min(StartPoint.X, EndPoint.X), Math.Min(StartPoint.Y, EndPoint.Y), Math.Min(StartPoint.Z, EndPoint.Z));
		XYZ max = new XYZ(Math.Max(StartPoint.X, EndPoint.X), Math.Max(StartPoint.Y, EndPoint.Y), Math.Max(StartPoint.Z, EndPoint.Z));
		return new BoundingBox(min, max);
	}
}
