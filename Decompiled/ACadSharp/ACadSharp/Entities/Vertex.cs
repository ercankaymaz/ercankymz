using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfSubClass("AcDbVertex", true)]
public abstract class Vertex : Entity, IVertex
{
	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 42 })]
	public double Bulge { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double CurveTangent { get; set; }

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 41 })]
	public double EndWidth { get; set; }

	[DxfCodeValue(new int[] { 70 })]
	public VertexFlags Flags { get; set; }

	[DxfCodeValue(DxfReferenceType.Ignored, new int[] { 91 })]
	public int Id { get; set; }

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ Location { get; set; } = XYZ.Zero;

	IVector IVertex.Location
	{
		get
		{
			return Location;
		}
		set
		{
			Location = value.Convert<XYZ>();
		}
	}

	public override string ObjectName => "VERTEX";

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 40 })]
	public double StartWidth { get; set; }

	public Vertex()
	{
	}

	public Vertex(XYZ location)
	{
		Location = location;
	}

	public override void ApplyTransform(Transform transform)
	{
		Location = transform.ApplyTransform(Location);
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(Location);
	}

	public override string ToString()
	{
		return SubclassMarker + "|" + Location.ToString();
	}
}
