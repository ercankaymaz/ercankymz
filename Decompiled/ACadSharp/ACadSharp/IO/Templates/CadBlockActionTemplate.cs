using System.Collections.Generic;
using ACadSharp.Entities;
using ACadSharp.Objects.Evaluations;

namespace ACadSharp.IO.Templates;

internal class CadBlockActionTemplate : CadBlockElementTemplate
{
	public BlockAction BlockAction => base.CadObject as BlockAction;

	public HashSet<ulong> EntityHandles { get; } = new HashSet<ulong>();

	public CadBlockActionTemplate(BlockAction cadObject)
		: base(cadObject)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		foreach (ulong entityHandle in EntityHandles)
		{
			if (builder.TryGetCadObject<Entity>(entityHandle, out var value))
			{
				BlockAction.Entities.Add(value);
			}
			else
			{
				builder.Notify($"[{BlockAction.ToString()}] entity with handle {entityHandle} not found.");
			}
		}
	}
}
