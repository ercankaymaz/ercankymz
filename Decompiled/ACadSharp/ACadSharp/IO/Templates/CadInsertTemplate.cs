using System.Collections.Generic;
using ACadSharp.Entities;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadInsertTemplate : CadEntityTemplate, ICadOwnerTemplate, ICadObjectTemplate, ICadTemplate
{
	public bool HasAtts { get; set; }

	public int OwnedObjectsCount { get; set; }

	public ulong? BlockHeaderHandle { get; set; }

	public string BlockName { get; set; }

	public ulong? FirstAttributeHandle { get; set; }

	public ulong? EndAttributeHandle { get; set; }

	public ulong? SeqendHandle { get; set; }

	public HashSet<ulong> OwnedObjectsHandlers { get; set; } = new HashSet<ulong>();

	public CadInsertTemplate()
		: base(new Insert())
	{
	}

	public CadInsertTemplate(Insert insert)
		: base(insert)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (!(base.CadObject is Insert insert))
		{
			return;
		}
		if (getTableReference<BlockRecord>(builder, BlockHeaderHandle, BlockName, out var reference))
		{
			insert.Block = reference;
		}
		else
		{
			builder.Notify($"Block {BlockHeaderHandle} | {BlockName} not found for Insert {base.CadObject.Handle}", NotificationType.Warning);
		}
		if (builder.TryGetCadObject<Seqend>(SeqendHandle, out var value))
		{
			insert.Attributes.Seqend = value;
		}
		if (FirstAttributeHandle.HasValue)
		{
			IEnumerable<AttributeEntity> entitiesCollection = getEntitiesCollection<AttributeEntity>(builder, FirstAttributeHandle.Value, EndAttributeHandle.Value);
			insert.Attributes.AddRange(entitiesCollection);
			return;
		}
		foreach (ulong ownedObjectsHandler in OwnedObjectsHandlers)
		{
			if (builder.TryGetCadObject<AttributeEntity>(ownedObjectsHandler, out var value2))
			{
				insert.Attributes.Add(value2);
			}
		}
	}
}
