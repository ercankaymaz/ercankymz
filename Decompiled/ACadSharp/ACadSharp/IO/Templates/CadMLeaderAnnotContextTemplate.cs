using System.Collections.Generic;
using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadMLeaderAnnotContextTemplate : CadAnnotScaleObjectContextDataTemplate
{
	public class LeaderLineTemplate : ICadTemplate
	{
		public ulong? ArrowSymbolHandle { get; internal set; }

		public MultiLeaderObjectContextData.LeaderLine LeaderLine { get; }

		public ulong? LineTypeHandle { get; internal set; }

		public LeaderLineTemplate()
			: this(new MultiLeaderObjectContextData.LeaderLine())
		{
		}

		public LeaderLineTemplate(MultiLeaderObjectContextData.LeaderLine leaderLine)
		{
			LeaderLine = leaderLine;
		}

		public void Build(CadDocumentBuilder builder)
		{
			if (builder.TryGetCadObject<LineType>(LineTypeHandle, out var value))
			{
				LeaderLine.LineType = value;
			}
			if (builder.TryGetCadObject<BlockRecord>(ArrowSymbolHandle, out var value2))
			{
				LeaderLine.Arrowhead = value2;
			}
		}
	}

	public ulong BlockRecordHandle { get; internal set; }

	public IList<LeaderLineTemplate> LeaderLineTemplates { get; } = new List<LeaderLineTemplate>();

	public ulong TextStyleHandle { get; internal set; }

	public CadMLeaderAnnotContextTemplate(MultiLeaderObjectContextData cadObject)
		: base(cadObject)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		MultiLeaderObjectContextData multiLeaderObjectContextData = (MultiLeaderObjectContextData)base.CadObject;
		if (builder.TryGetCadObject<TextStyle>(TextStyleHandle, out var value))
		{
			multiLeaderObjectContextData.TextStyle = value;
		}
		if (builder.TryGetCadObject<BlockRecord>(BlockRecordHandle, out var value2))
		{
			multiLeaderObjectContextData.BlockContent = value2;
		}
		foreach (LeaderLineTemplate leaderLineTemplate in LeaderLineTemplates)
		{
			leaderLineTemplate.Build(builder);
		}
	}
}
