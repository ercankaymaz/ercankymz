using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfName("TABLECONTENT")]
[DxfSubClass("AcDbTableContent")]
public class TableContent : FormattedTableData
{
	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string ObjectName => "TABLECONTENT";

	public override string SubclassMarker => "AcDbTableContent";

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public TableStyle Style { get; set; } = new TableStyle();

	public TableStyle StyleOverride { get; set; }
}
