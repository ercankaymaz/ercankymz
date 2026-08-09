using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("WIPEOUT")]
[DxfSubClass("AcDbWipeout")]
public class Wipeout : CadWipeoutBase
{
	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string ObjectName => "WIPEOUT";

	public override string SubclassMarker => "AcDbWipeout";

	public Wipeout()
	{
		base.Flags = ImageDisplayFlags.ShowImage | ImageDisplayFlags.ShowNotAlignedImage | ImageDisplayFlags.UseClippingBoundary;
	}
}
