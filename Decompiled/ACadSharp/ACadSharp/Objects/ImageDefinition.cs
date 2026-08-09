using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Objects;

[DxfName("IMAGEDEF")]
[DxfSubClass("AcDbRasterImageDef")]
public class ImageDefinition : NonGraphicalObject
{
	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string ObjectName => "IMAGEDEF";

	public override string SubclassMarker => "AcDbRasterImageDef";

	[DxfCodeValue(new int[] { 90 })]
	public int ClassVersion { get; internal set; }

	[DxfCodeValue(new int[] { 1 })]
	public string FileName { get; set; }

	[DxfCodeValue(new int[] { 10, 20 })]
	public XY Size { get; set; }

	[DxfCodeValue(new int[] { 11, 21 })]
	public XY DefaultSize { get; set; } = new XY(1.0, 1.0);

	[DxfCodeValue(new int[] { 280 })]
	public bool IsLoaded { get; set; } = true;

	[DxfCodeValue(new int[] { 281 })]
	public ResolutionUnit Units { get; set; }
}
