using ACadSharp.Attributes;
using ACadSharp.Objects;
using CSMath;

namespace ACadSharp.Tables;

[DxfName("VIEW")]
[DxfSubClass("AcDbViewTableRecord")]
public class View : TableEntry
{
	public override ObjectType ObjectType => ObjectType.VIEW;

	public override string ObjectName => "VIEW";

	public override string SubclassMarker => "AcDbViewTableRecord";

	[DxfCodeValue(new int[] { 40 })]
	public double Height { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double Width { get; set; }

	[DxfCodeValue(new int[] { 42 })]
	public double LensLength { get; set; }

	[DxfCodeValue(new int[] { 43 })]
	public double FrontClipping { get; set; }

	[DxfCodeValue(new int[] { 44 })]
	public double BackClipping { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double Angle { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public ViewModeType ViewMode { get; set; }

	[DxfCodeValue(new int[] { 72 })]
	public bool IsUcsAssociated { get; set; }

	[DxfCodeValue(new int[] { 73 })]
	public bool IsPlottable { get; set; }

	[DxfCodeValue(new int[] { 281 })]
	public RenderMode RenderMode { get; set; }

	[DxfCodeValue(new int[] { 10, 20 })]
	public XY Center { get; set; }

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ Direction { get; set; }

	[DxfCodeValue(new int[] { 12, 22, 32 })]
	public XYZ Target { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 348 })]
	public VisualStyle VisualStyle { get; set; }

	[DxfCodeValue(new int[] { 110, 120, 130 })]
	public XYZ UcsOrigin { get; set; }

	[DxfCodeValue(new int[] { 111, 121, 131 })]
	public XYZ UcsXAxis { get; set; }

	[DxfCodeValue(new int[] { 112, 122, 132 })]
	public XYZ UcsYAxis { get; set; }

	[DxfCodeValue(new int[] { 146 })]
	public double UcsElevation { get; set; }

	[DxfCodeValue(new int[] { 79 })]
	public OrthographicType UcsOrthographicType { get; set; }

	internal View()
	{
	}

	public View(string name)
		: base(name)
	{
	}

	public override CadObject Clone()
	{
		View obj = (View)base.Clone();
		obj.VisualStyle = (VisualStyle)(VisualStyle?.Clone());
		return obj;
	}
}
