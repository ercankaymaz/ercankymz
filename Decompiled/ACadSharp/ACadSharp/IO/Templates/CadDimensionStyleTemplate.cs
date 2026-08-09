using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadDimensionStyleTemplate : CadTableEntryTemplate<DimensionStyle>
{
	public string DIMBL_Name { get; set; }

	public ulong? DIMBLK { get; set; }

	public ulong? DIMBLK1 { get; set; }

	public string DIMBLK1_Name { get; set; }

	public ulong? DIMBLK2 { get; set; }

	public string DIMBLK2_Name { get; set; }

	public ulong? DIMLDRBLK { get; set; }

	public ulong Dimltex1 { get; set; }

	public ulong Dimltex2 { get; set; }

	public ulong? Dimltype { get; set; }

	public string TextStyle_Name { get; set; }

	public ulong? TextStyleHandle { get; set; }

	public ulong? BlockHandle { get; set; }

	public bool DxfFlagsAssigned { get; set; }

	public CadDimensionStyleTemplate()
		: base(new DimensionStyle())
	{
	}

	public CadDimensionStyleTemplate(DimensionStyle dimStyle)
		: base(dimStyle)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (getTableReference<TextStyle>(builder, TextStyleHandle, TextStyle_Name, out var reference))
		{
			base.CadObject.Style = reference;
		}
		if (getTableReference<LineType>(builder, Dimltype, null, out var reference2))
		{
			base.CadObject.LineType = reference2;
		}
		if (getTableReference<LineType>(builder, Dimltex1, null, out var reference3))
		{
			base.CadObject.LineTypeExt1 = reference3;
		}
		if (getTableReference<LineType>(builder, Dimltex2, null, out var reference4))
		{
			base.CadObject.LineTypeExt2 = reference4;
		}
		if (getTableReference<BlockRecord>(builder, DIMLDRBLK, DIMBL_Name, out var reference5))
		{
			base.CadObject.LeaderArrow = reference5;
		}
		if (getTableReference<BlockRecord>(builder, DIMBLK1, DIMBLK1_Name, out var reference6))
		{
			base.CadObject.DimArrow1 = reference6;
		}
		if (getTableReference<BlockRecord>(builder, DIMBLK2, DIMBLK2_Name, out var reference7))
		{
			base.CadObject.DimArrow2 = reference7;
		}
		getTableReference<BlockRecord>(builder, BlockHandle, null, out var _);
	}
}
