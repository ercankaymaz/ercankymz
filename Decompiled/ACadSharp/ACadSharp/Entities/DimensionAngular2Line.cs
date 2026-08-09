using ACadSharp.Attributes;
using CSMath;
using CSMath.Geometry;

namespace ACadSharp.Entities;

[DxfName("DIMENSION")]
[DxfSubClass("AcDb2LineAngularDimension")]
public class DimensionAngular2Line : Dimension
{
	[DxfCodeValue(new int[] { 15, 25, 35 })]
	public XYZ AngleVertex { get; set; }

	public XYZ Center
	{
		get
		{
			Line3D line3D = LineExtensions.CreateFromPoints<Line3D, XYZ>(base.DefinitionPoint, AngleVertex);
			Line3D line3D2 = LineExtensions.CreateFromPoints<Line3D, XYZ>(FirstPoint, SecondPoint);
			return line3D.FindIntersection(line3D2);
		}
	}

	[DxfCodeValue(new int[] { 16, 26, 36 })]
	public XYZ DimensionArc { get; set; }

	[DxfCodeValue(new int[] { 13, 23, 33 })]
	public XYZ FirstPoint { get; set; }

	public override double Measurement
	{
		get
		{
			XYZ v = SecondPoint - FirstPoint;
			XYZ u = base.DefinitionPoint - AngleVertex;
			return v.AngleBetweenVectors(u);
		}
	}

	public override string ObjectName => "DIMENSION";

	public override ObjectType ObjectType => ObjectType.DIMENSION_ANG_2_Ln;

	public virtual double Offset
	{
		get
		{
			return SecondPoint.DistanceFrom(base.DefinitionPoint);
		}
		set
		{
			XYZ xyz = SecondPoint - FirstPoint;
			XYZ xYZ = XYZ.Cross(base.Normal, xyz).Normalize();
			base.DefinitionPoint = SecondPoint + xYZ * value;
		}
	}

	[DxfCodeValue(new int[] { 14, 24, 34 })]
	public XYZ SecondPoint { get; set; }

	public override string SubclassMarker => "AcDb2LineAngularDimension";

	public DimensionAngular2Line()
		: base(DimensionType.Angular)
	{
	}

	public override void ApplyTransform(Transform transform)
	{
		base.ApplyTransform(transform);
		FirstPoint = transform.ApplyTransform(FirstPoint);
		SecondPoint = transform.ApplyTransform(SecondPoint);
		AngleVertex = transform.ApplyTransform(AngleVertex);
		DimensionArc = transform.ApplyTransform(DimensionArc);
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(FirstPoint, SecondPoint);
	}

	public override void UpdateBlock()
	{
	}
}
