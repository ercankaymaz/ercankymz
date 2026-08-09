using ACadSharp.Attributes;
using ACadSharp.Types.Units;

namespace ACadSharp.Objects;

[DxfName("RASTERVARIABLES")]
[DxfSubClass("AcDbRasterVariables")]
public class RasterVariables : NonGraphicalObject
{
	[DxfCodeValue(new int[] { 90 })]
	public int ClassVersion { get; internal set; }

	[DxfCodeValue(new int[] { 71 })]
	public ImageDisplayQuality DisplayQuality { get; set; } = ImageDisplayQuality.High;

	[DxfCodeValue(new int[] { 70 })]
	public bool IsDisplayFrameShown { get; set; }

	public override string ObjectName => "RASTERVARIABLES";

	public override string SubclassMarker => "AcDbRasterVariables";

	[DxfCodeValue(new int[] { 72 })]
	public ImageUnits Units { get; set; }
}
