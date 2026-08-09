using System;
using System.Collections.Generic;
using ACadSharp.Blocks;
using ACadSharp.Entities;
using ACadSharp.IO.DWG;
using ACadSharp.Objects;
using ACadSharp.Tables;
using CSUtilities.Extensions;

namespace ACadSharp.IO.Templates;

internal class CadBlockRecordTemplate : CadTableEntryTemplate<BlockRecord>, ICadOwnerTemplate, ICadObjectTemplate, ICadTemplate
{
	public ulong? FirstEntityHandle { get; set; }

	public ulong? LastEntityHandle { get; set; }

	public ulong? BeginBlockHandle { get; set; }

	public ulong? EndBlockHandle { get; set; }

	public ulong? LayoutHandle { get; set; }

	public HashSet<ulong> OwnedObjectsHandlers { get; set; } = new HashSet<ulong>();

	public List<ulong> InsertHandles { get; set; } = new List<ulong>();

	public CadBlockEntityTemplate BlockEntityTemplate { get; set; }

	public CadBlockRecordTemplate()
		: base(new BlockRecord())
	{
	}

	public CadBlockRecordTemplate(BlockRecord block)
		: base(block)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (builder.TryGetCadObject<Layout>(LayoutHandle, out var value))
		{
			base.CadObject.Layout = value;
		}
		if (FirstEntityHandle.HasValue && FirstEntityHandle.Value != 0L)
		{
			foreach (Entity item in getEntitiesCollection<Entity>(builder, FirstEntityHandle.Value, LastEntityHandle.Value))
			{
				addEntity(builder, item);
			}
			return;
		}
		if (BlockEntityTemplate != null)
		{
			OwnedObjectsHandlers.UnionWith(BlockEntityTemplate.OwnedObjectsHandlers);
		}
		foreach (ulong ownedObjectsHandler in OwnedObjectsHandlers)
		{
			if (builder.TryGetCadObject<Entity>(ownedObjectsHandler, out var value2))
			{
				addEntity(builder, value2);
			}
		}
	}

	public void SetBlockToRecord(CadDocumentBuilder builder, DwgHeaderHandlesCollection headerHandles)
	{
		if (builder.TryGetCadObject<Block>(BeginBlockHandle, out var value))
		{
			if (!value.Name.IsNullOrEmpty())
			{
				base.CadObject.Name = value.Name;
			}
			value.Flags = base.CadObject.BlockEntity.Flags;
			value.BasePoint = base.CadObject.BlockEntity.BasePoint;
			value.XRefPath = base.CadObject.BlockEntity.XRefPath;
			value.Comments = base.CadObject.BlockEntity.Comments;
			value.IsUnloaded = base.CadObject.BlockEntity.IsUnloaded;
			base.CadObject.BlockEntity = value;
		}
		if (builder.TryGetCadObject<BlockEnd>(EndBlockHandle, out var value2))
		{
			base.CadObject.BlockEnd = value2;
		}
		ensureCorrectNaming(builder, headerHandles.MODEL_SPACE, "*Model_Space");
		ensureCorrectNaming(builder, headerHandles.PAPER_SPACE, "*Paper_Space");
	}

	private void ensureCorrectNaming(CadDocumentBuilder builder, ulong? handle, string expected)
	{
		if (base.CadObject.Handle == handle && !base.CadObject.Name.Equals(expected, StringComparison.InvariantCultureIgnoreCase))
		{
			builder.Notify("Invalid name for " + base.CadObject.Name + " changed to " + expected, NotificationType.Warning);
			base.CadObject.Name = expected;
		}
	}

	private void addEntity(CadDocumentBuilder builder, Entity entity)
	{
		if (builder.KeepUnknownEntities || !(entity is UnknownEntity))
		{
			base.CadObject.Entities.Add(entity);
		}
	}
}
