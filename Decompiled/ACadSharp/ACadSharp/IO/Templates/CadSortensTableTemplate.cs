using System.Collections.Generic;
using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadSortensTableTemplate : CadTemplate<SortEntitiesTable>
{
	public ulong? BlockOwnerHandle { get; set; }

	public List<(ulong?, ulong?)> Values { get; } = new List<(ulong?, ulong?)>();

	public CadSortensTableTemplate()
		: base(new SortEntitiesTable())
	{
	}

	public CadSortensTableTemplate(SortEntitiesTable cadObject)
		: base(cadObject)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (builder.TryGetCadObject<CadObject>(BlockOwnerHandle, out var value))
		{
			if (!(value is BlockRecord blockOwner))
			{
				if (value == null)
				{
					builder.Notify($"Block owner for SortEntitiesTable {base.CadObject.Handle} not found", NotificationType.Warning);
				}
				else
				{
					builder.Notify($"Block owner for SortEntitiesTable {base.CadObject.Handle} is not a block {value.GetType().FullName} | {value.Handle}", NotificationType.Warning);
				}
				return;
			}
			base.CadObject.BlockOwner = blockOwner;
		}
		foreach (var value3 in Values)
		{
			if (builder.TryGetCadObject<Entity>(value3.Item2, out var value2))
			{
				base.CadObject.Add(value2, value3.Item1.Value);
			}
			else
			{
				builder.Notify($"Entity in SortEntitiesTable {base.CadObject.Handle} not found {value3.Item2}", NotificationType.Warning);
			}
		}
	}
}
