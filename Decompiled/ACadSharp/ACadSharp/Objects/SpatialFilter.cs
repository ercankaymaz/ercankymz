using System.Collections.Generic;
using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Objects;

[DxfName("SPATIAL_FILTER")]
[DxfSubClass("AcDbSpatialFilter")]
public class SpatialFilter : Filter
{
	public const string SpatialFilterEntryName = "SPATIAL";

	[DxfCodeValue(new int[] { 41 })]
	public double BackDistance { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 70 })]
	[DxfCollectionCodeValue(new int[] { 10, 20 })]
	public List<XY> BoundaryPoints { get; set; } = new List<XY>();

	[DxfCodeValue(new int[] { 73 })]
	public bool ClipBackPlane { get; set; }

	[DxfCodeValue(new int[] { 72 })]
	public bool ClipFrontPlane { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public bool DisplayBoundary { get; set; }

	[DxfCodeValue(new int[] { 40 })]
	public double FrontDistance { get; set; }

	public Matrix4 InsertTransform { get; set; } = Matrix4.Identity;

	public Matrix4 InverseInsertTransform { get; set; } = Matrix4.Identity;

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "SPATIAL_FILTER";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ Origin { get; set; } = XYZ.AxisZ;

	public override string SubclassMarker => "AcDbSpatialFilter";

	public SpatialFilter()
	{
	}

	public SpatialFilter(string name)
		: base(name)
	{
	}
}
