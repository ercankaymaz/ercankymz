using System.Collections.Generic;
using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadMLeaderTemplate : CadEntityTemplate<MultiLeader>
{
	public ulong ArrowheadHandle { get; set; }

	public IDictionary<ulong, bool> ArrowheadHandles { get; } = new Dictionary<ulong, bool>();

	public IDictionary<MultiLeader.BlockAttribute, ulong> BlockAttributeHandles { get; } = new Dictionary<MultiLeader.BlockAttribute, ulong>();

	public ulong BlockContentHandle { get; set; }

	public CadMLeaderAnnotContextTemplate CadMLeaderAnnotContextTemplate { get; set; }

	public ulong? LeaderLineTypeHandle { get; set; }

	public ulong LeaderStyleHandle { get; set; }

	public ulong MTextStyleHandle { get; set; }

	public CadMLeaderTemplate()
		: this(new MultiLeader())
	{
	}

	public CadMLeaderTemplate(MultiLeader entity)
		: base(entity)
	{
		CadMLeaderAnnotContextTemplate = new CadMLeaderAnnotContextTemplate(entity.ContextData);
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		CadMLeaderAnnotContextTemplate.Build(builder);
		MultiLeader cadObject = base.CadObject;
		if (builder.TryGetCadObject<MultiLeaderStyle>(LeaderStyleHandle, out var value))
		{
			cadObject.Style = value;
		}
		if (builder.TryGetCadObject<LineType>(LeaderLineTypeHandle, out var value2))
		{
			cadObject.LeaderLineType = value2;
		}
		if (builder.TryGetCadObject<TextStyle>(MTextStyleHandle, out var value3))
		{
			cadObject.TextStyle = value3;
		}
		if (builder.TryGetCadObject<BlockRecord>(BlockContentHandle, out var value4))
		{
			cadObject.BlockContent = value4;
		}
		if (builder.TryGetCadObject<BlockRecord>(ArrowheadHandle, out var value5))
		{
			cadObject.Arrowhead = value5;
		}
		foreach (KeyValuePair<ulong, bool> arrowheadHandle in ArrowheadHandles)
		{
			_ = arrowheadHandle;
		}
		foreach (MultiLeader.BlockAttribute blockAttribute in cadObject.BlockAttributes)
		{
			ulong value6 = BlockAttributeHandles[blockAttribute];
			if (builder.TryGetCadObject<AttributeDefinition>(value6, out var value7))
			{
				blockAttribute.AttributeDefinition = value7;
			}
		}
	}
}
