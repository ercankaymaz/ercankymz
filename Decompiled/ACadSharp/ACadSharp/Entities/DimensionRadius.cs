using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("DIMENSION")]
[DxfSubClass("AcDbRadialDimension")]
public class DimensionRadius : Dimension
{
	[DxfCodeValue(new int[] { 15, 25, 35 })]
	public XYZ AngleVertex { get; set; }

	[DxfCodeValue(new int[] { 40 })]
	public double LeaderLength { get; set; }

	public override double Measurement => base.DefinitionPoint.DistanceFrom(AngleVertex);

	public override string ObjectName => "DIMENSION";

	public override ObjectType ObjectType => ObjectType.DIMENSION_RADIUS;

	public override string SubclassMarker => "AcDbRadialDimension";

	public DimensionRadius()
		: base(DimensionType.Radius)
	{
	}

	public override void ApplyTransform(Transform transform)
	{
		base.ApplyTransform(transform);
		AngleVertex = transform.ApplyTransform(AngleVertex);
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(base.InsertionPoint - AngleVertex, base.InsertionPoint + AngleVertex);
	}

	public override void UpdateBlock()
	{
		base.UpdateBlock();
		base.DefinitionPoint.DistanceFrom(base.TextMiddlePoint);
		XY centerRef = base.DefinitionPoint.Convert<XY>();
		XY @ref = AngleVertex.Convert<XY>();
		double minOffset = 2.0 * base.Style.ArrowSize * base.Style.ScaleFactor;
		angularBlock(Measurement, centerRef, @ref, minOffset, drawRef2: false);
	}
}
