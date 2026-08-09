using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadMLeaderStyleTemplate : CadTemplate<MultiLeaderStyle>
{
	public ulong? ArrowheadHandle { get; set; }

	public ulong? BlockContentHandle { get; set; }

	public ulong? LeaderLineTypeHandle { get; set; }

	public ulong? MTextStyleHandle { get; set; }

	public CadMLeaderStyleTemplate()
		: this(new MultiLeaderStyle())
	{
	}

	public CadMLeaderStyleTemplate(MultiLeaderStyle entry)
		: base(entry)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (builder.TryGetCadObject<LineType>(LeaderLineTypeHandle, out var value))
		{
			base.CadObject.LeaderLineType = value;
		}
		if (builder.TryGetCadObject<BlockRecord>(ArrowheadHandle, out var value2))
		{
			base.CadObject.Arrowhead = value2;
		}
		if (builder.TryGetCadObject<TextStyle>(MTextStyleHandle, out var value3))
		{
			base.CadObject.TextStyle = value3;
		}
		if (builder.TryGetCadObject<BlockRecord>(BlockContentHandle, out var value4))
		{
			base.CadObject.BlockContent = value4;
		}
	}
}
