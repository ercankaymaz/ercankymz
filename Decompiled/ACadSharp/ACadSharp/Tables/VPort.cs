using ACadSharp.Attributes;
using ACadSharp.Objects;
using CSMath;

namespace ACadSharp.Tables;

[DxfName("VPORT")]
[DxfSubClass("AcDbViewportTableRecord")]
public class VPort : TableEntry
{
	public const string DefaultName = "*Active";

	private XYZ _direction = XYZ.AxisZ;

	public override ObjectType ObjectType => ObjectType.VPORT;

	public override string ObjectName => "VPORT";

	public override string SubclassMarker => "AcDbViewportTableRecord";

	public static VPort Default => new VPort("*Active");

	[DxfCodeValue(new int[] { 10, 20 })]
	public XY BottomLeft { get; set; } = XY.Zero;

	[DxfCodeValue(new int[] { 11, 21 })]
	public XY TopRight { get; set; } = new XY(1.0, 1.0);

	[DxfCodeValue(new int[] { 12, 22 })]
	public XY Center { get; set; } = XY.Zero;

	[DxfCodeValue(new int[] { 13, 23 })]
	public XY SnapBasePoint { get; set; }

	[DxfCodeValue(new int[] { 14, 24 })]
	public XY SnapSpacing { get; set; } = new XY(0.5, 0.5);

	[DxfCodeValue(new int[] { 15, 25 })]
	public XY GridSpacing { get; set; } = new XY(10.0, 10.0);

	[DxfCodeValue(new int[] { 16, 26, 36 })]
	public XYZ Direction
	{
		get
		{
			return _direction;
		}
		set
		{
			_direction = value.Normalize();
		}
	}

	[DxfCodeValue(new int[] { 17, 27, 37 })]
	public XYZ Target { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 40 })]
	public double ViewHeight { get; set; } = 10.0;

	[DxfCodeValue(new int[] { 41 })]
	public double AspectRatio { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 42 })]
	public double LensLength { get; set; } = 50.0;

	[DxfCodeValue(new int[] { 43 })]
	public double FrontClippingPlane { get; set; }

	[DxfCodeValue(new int[] { 44 })]
	public double BackClippingPlane { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double SnapRotation { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 51 })]
	public double TwistAngle { get; set; }

	[DxfCodeValue(new int[] { 72 })]
	public short CircleZoomPercent { get; set; } = 1000;

	[DxfCodeValue(new int[] { 281 })]
	public RenderMode RenderMode { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public ViewModeType ViewMode { get; set; } = ViewModeType.FrontClippingZ;

	[DxfCodeValue(new int[] { 74 })]
	public UscIconType UcsIconDisplay { get; set; } = UscIconType.OnOrigin;

	[DxfCodeValue(new int[] { 75 })]
	public bool SnapOn { get; set; }

	[DxfCodeValue(new int[] { 76 })]
	public bool ShowGrid { get; set; } = true;

	[DxfCodeValue(new int[] { 77 })]
	public bool IsometricSnap { get; set; }

	[DxfCodeValue(new int[] { 78 })]
	public short SnapIsoPair { get; set; }

	[DxfCodeValue(new int[] { 110, 120, 130 })]
	public XYZ Origin { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 111, 121, 131 })]
	public XYZ XAxis { get; set; } = XYZ.AxisX;

	[DxfCodeValue(new int[] { 112, 122, 132 })]
	public XYZ YAxis { get; set; } = XYZ.AxisY;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 345 })]
	public UCS NamedUcs { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 346 })]
	public UCS BaseUcs { get; set; }

	[DxfCodeValue(new int[] { 79 })]
	public OrthographicType OrthographicType { get; set; }

	[DxfCodeValue(new int[] { 146 })]
	public double Elevation { get; set; }

	[DxfCodeValue(new int[] { 60 })]
	public GridFlags GridFlags { get; set; } = GridFlags._1 | GridFlags._2;

	[DxfCodeValue(new int[] { 61 })]
	public short MinorGridLinesPerMajorGridLine { get; set; } = 5;

	[DxfCodeValue(DxfReferenceType.Handle | DxfReferenceType.Optional, new int[] { 348 })]
	public VisualStyle VisualStyle { get; set; }

	[DxfCodeValue(new int[] { 292 })]
	public bool UseDefaultLighting { get; set; } = true;

	[DxfCodeValue(new int[] { 282 })]
	public DefaultLightingType DefaultLighting { get; set; } = DefaultLightingType.TwoDistantLights;

	[DxfCodeValue(new int[] { 141 })]
	public double Brightness { get; set; }

	[DxfCodeValue(new int[] { 142 })]
	public double Contrast { get; set; }

	[DxfCodeValue(new int[] { 63, 421, 431 })]
	public Color AmbientColor { get; set; }

	public VPort()
	{
	}

	public VPort(string name)
		: base(name)
	{
	}

	public override CadObject Clone()
	{
		VPort obj = (VPort)base.Clone();
		obj.BaseUcs = (UCS)(BaseUcs?.Clone());
		obj.NamedUcs = (UCS)(NamedUcs?.Clone());
		return obj;
	}
}
