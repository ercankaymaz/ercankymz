using System;
using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("DIMENSION")]
[DxfSubClass("AcDb3PointAngularDimension")]
public class DimensionAngular3Pt : Dimension
{
	[DxfCodeValue(new int[] { 15, 25, 35 })]
	public XYZ AngleVertex { get; set; }

	[DxfCodeValue(new int[] { 13, 23, 33 })]
	public XYZ FirstPoint { get; set; }

	public override double Measurement
	{
		get
		{
			XYZ xYZ = FirstPoint - AngleVertex;
			XYZ xYZ2 = SecondPoint - AngleVertex;
			if (xYZ.Equals(xYZ2))
			{
				return 0.0;
			}
			if (xYZ.IsParallel(xYZ2))
			{
				return Math.PI;
			}
			return xYZ.AngleBetweenVectors(xYZ2);
		}
	}

	public override string ObjectName => "DIMENSION";

	public override ObjectType ObjectType => ObjectType.DIMENSION_ANG_3_Pt;

	[DxfCodeValue(new int[] { 14, 24, 34 })]
	public XYZ SecondPoint { get; set; }

	public override string SubclassMarker => "AcDb3PointAngularDimension";

	public DimensionAngular3Pt()
		: base(DimensionType.Angular3Point)
	{
	}

	public override void ApplyTransform(Transform transform)
	{
		base.ApplyTransform(transform);
		FirstPoint = transform.ApplyTransform(FirstPoint);
		SecondPoint = transform.ApplyTransform(SecondPoint);
		AngleVertex = transform.ApplyTransform(AngleVertex);
	}

	public override void UpdateBlock()
	{
		base.UpdateBlock();
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(FirstPoint, SecondPoint);
	}
}
