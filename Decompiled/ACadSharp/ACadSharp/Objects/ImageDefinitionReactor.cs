using ACadSharp.Attributes;
using ACadSharp.Entities;

namespace ACadSharp.Objects;

[DxfName("IMAGEDEF_REACTOR")]
[DxfSubClass("AcDbRasterImageDefReactor")]
public class ImageDefinitionReactor : NonGraphicalObject
{
	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string ObjectName => "IMAGEDEF_REACTOR";

	public override string SubclassMarker => "AcDbRasterImageDefReactor";

	[DxfCodeValue(new int[] { 90 })]
	public int ClassVersion { get; set; } = 2;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 330 })]
	public RasterImage Image { get; set; }

	internal ImageDefinitionReactor()
	{
	}

	internal ImageDefinitionReactor(RasterImage image)
	{
		base.Owner = image;
		Image = image;
	}
}
