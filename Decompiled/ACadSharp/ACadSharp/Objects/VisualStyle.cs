using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfName("VISUALSTYLE")]
[DxfSubClass("AcDbVisualStyle")]
public class VisualStyle : NonGraphicalObject
{
	public const string DefaultName = "2dWireframe";

	[DxfCodeValue(new int[] { 44 })]
	public double Brightness { get; set; }

	[DxfCodeValue(new int[] { 62, 63 })]
	public Color Color { get; set; }

	[DxfCodeValue(new int[] { 2 })]
	public string Description { get; set; }

	[DxfCodeValue(new int[] { 93 })]
	public int DisplaySettings { get; set; }

	[DxfCodeValue(new int[] { 174 })]
	public short EdgeApplyStyleFlag { get; set; }

	[DxfCodeValue(new int[] { 66 })]
	public int EdgeColor { get; set; }

	[DxfCodeValue(new int[] { 42 })]
	public double EdgeCreaseAngle { get; set; }

	[DxfCodeValue(new int[] { 64 })]
	public Color EdgeIntersectionColor { get; set; }

	[DxfCodeValue(new int[] { 175 })]
	public int EdgeIntersectionLineType { get; set; }

	[DxfCodeValue(new int[] { 171 })]
	public short EdgeIsolineCount { get; set; }

	[DxfCodeValue(new int[] { 78 })]
	public int EdgeJitter { get; set; }

	[DxfCodeValue(new int[] { 92 })]
	public int EdgeModifiers { get; set; }

	[DxfCodeValue(new int[] { 65 })]
	public Color EdgeObscuredColor { get; set; }

	[DxfCodeValue(new int[] { 75 })]
	public int EdgeObscuredLineType { get; set; }

	[DxfCodeValue(new int[] { 77 })]
	public int EdgeOverhang { get; set; }

	[DxfCodeValue(new int[] { 67 })]
	public Color EdgeSilhouetteColor { get; set; }

	[DxfCodeValue(new int[] { 79 })]
	public int EdgeSilhouetteWidth { get; set; }

	[DxfCodeValue(new int[] { 91 })]
	public int EdgeStyle { get; set; }

	[DxfCodeValue(new int[] { 74 })]
	public EdgeStyleModel EdgeStyleModel { get; set; }

	[DxfCodeValue(new int[] { 76 })]
	public int EdgeWidth { get; set; }

	[DxfCodeValue(new int[] { 73 })]
	public FaceColorMode FaceColorMode { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public FaceLightingModelType FaceLightingModel { get; set; }

	[DxfCodeValue(new int[] { 72 })]
	public FaceLightingQualityType FaceLightingQuality { get; set; }

	[DxfCodeValue(new int[] { 90 })]
	public FaceModifierType FaceModifiers { get; set; }

	[DxfCodeValue(new int[] { 40 })]
	public double FaceOpacityLevel { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double FaceSpecularLevel { get; set; }

	[DxfCodeValue(new int[] { 421 })]
	public Color FaceStyleMonoColor { get; set; }

	[DxfCodeValue(new int[] { 170 })]
	public short HaloGap { get; set; }

	[DxfCodeValue(new int[] { 291 })]
	public bool InternalFlag { get; internal set; }

	public override string ObjectName => "VISUALSTYLE";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	[DxfCodeValue(new int[] { 43 })]
	public double OpacityLevel { get; set; }

	[DxfCodeValue(new int[] { 290 })]
	public bool PrecisionFlag { get; set; }

	[DxfCodeValue(new int[] { 1 })]
	public string RasterFile { get; set; }

	[DxfCodeValue(new int[] { 173 })]
	public short ShadowType { get; set; }

	public override string SubclassMarker => "AcDbVisualStyle";

	[DxfCodeValue(new int[] { 70 })]
	public int Type { get; set; }
}
