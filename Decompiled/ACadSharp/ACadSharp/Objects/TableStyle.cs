using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfName("STYLE")]
[DxfSubClass("AcDbTableStyle")]
public class TableStyle : NonGraphicalObject
{
	public const string DefaultName = "Standard";

	public override string ObjectName => "STYLE";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string SubclassMarker { get; } = "AcDbTableStyle";

	[DxfCodeValue(new int[] { 280 })]
	public bool SuppressTitle { get; set; }
}
