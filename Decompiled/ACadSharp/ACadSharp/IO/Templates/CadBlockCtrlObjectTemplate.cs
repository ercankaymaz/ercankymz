using ACadSharp.Tables;
using ACadSharp.Tables.Collections;

namespace ACadSharp.IO.Templates;

internal class CadBlockCtrlObjectTemplate : CadTableTemplate<BlockRecord>
{
	public ulong? ModelSpaceHandle { get; set; }

	public ulong? PaperSpaceHandle { get; set; }

	public CadBlockCtrlObjectTemplate(BlockRecordsTable blocks)
		: base((Table<BlockRecord>)blocks)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (builder.TryGetCadObject<BlockRecord>(ModelSpaceHandle, out var value))
		{
			base.CadObject.Add(value);
		}
		if (builder.TryGetCadObject<BlockRecord>(PaperSpaceHandle, out var value2))
		{
			base.CadObject.Add(value2);
		}
	}
}
