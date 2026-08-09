using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Blocks;
using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Objects.Evaluations;
using ACadSharp.Types.Units;
using ACadSharp.XData;
using CSMath;

namespace ACadSharp.Tables;

[DxfName("BLOCK_RECORD")]
[DxfSubClass("AcDbBlockTableRecord")]
public class BlockRecord : TableEntry, IGeometricEntity
{
	public const string AnonymousPrefix = "*A";

	public const string ModelSpaceName = "*Model_Space";

	public const string PaperSpaceName = "*Paper_Space";

	private BlockEnd _blockEnd;

	private Block _blockEntity;

	private Layout _layout;

	public static BlockRecord ModelSpace
	{
		get
		{
			BlockRecord blockRecord = new BlockRecord("*Model_Space");
			new Layout
			{
				Name = "Model",
				AssociatedBlock = blockRecord
			};
			return blockRecord;
		}
	}

	public static BlockRecord PaperSpace
	{
		get
		{
			BlockRecord blockRecord = new BlockRecord("*Paper_Space");
			new Layout
			{
				Name = "Layout1",
				AssociatedBlock = blockRecord
			};
			return blockRecord;
		}
	}

	public IEnumerable<AttributeDefinition> AttributeDefinitions => Entities.OfType<AttributeDefinition>();

	public BlockEnd BlockEnd
	{
		get
		{
			return _blockEnd;
		}
		internal set
		{
			_blockEnd = value;
			_blockEnd.Owner = this;
		}
	}

	public Block BlockEntity
	{
		get
		{
			return _blockEntity;
		}
		internal set
		{
			_blockEntity = value;
			_blockEntity.Owner = this;
		}
	}

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 281 })]
	public bool CanScale { get; set; } = true;

	public CadObjectCollection<Entity> Entities { get; private set; }

	public EvaluationGraph EvaluationGraph
	{
		get
		{
			if (base.XDictionary == null)
			{
				return null;
			}
			if (base.XDictionary.TryGetEntry<EvaluationGraph>("ACAD_ENHANCEDBLOCK", out var value))
			{
				return value;
			}
			return null;
		}
	}

	public new BlockTypeFlags Flags
	{
		get
		{
			return BlockEntity.Flags;
		}
		set
		{
			BlockEntity.Flags = value;
		}
	}

	public bool HasAttributes => Entities.OfType<AttributeDefinition>().Any();

	public bool IsAnonymous
	{
		get
		{
			return (Flags & BlockTypeFlags.Anonymous) != 0;
		}
		set
		{
			if (value)
			{
				Flags |= BlockTypeFlags.Anonymous;
			}
			else
			{
				Flags &= ~BlockTypeFlags.Anonymous;
			}
		}
	}

	public bool IsDynamic => EvaluationGraph != null;

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 280 })]
	public bool IsExplodable { get; set; }

	public bool IsUnloaded
	{
		get
		{
			return BlockEntity.IsUnloaded;
		}
		set
		{
			BlockEntity.IsUnloaded = value;
		}
	}

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public Layout Layout
	{
		get
		{
			return _layout;
		}
		internal set
		{
			_layout = value;
		}
	}

	public override string ObjectName => "BLOCK_RECORD";

	public override ObjectType ObjectType => ObjectType.BLOCK_HEADER;

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 310 })]
	public byte[] Preview { get; set; }

	public SortEntitiesTable SortEntitiesTable
	{
		get
		{
			if (base.XDictionary == null)
			{
				return null;
			}
			if (base.XDictionary.TryGetEntry<SortEntitiesTable>("ACAD_SORTENTS", out var value))
			{
				return value;
			}
			return null;
		}
	}

	public BlockRecord Source
	{
		get
		{
			if (base.Document == null || !IsAnonymous || base.ExtendedData == null)
			{
				return null;
			}
			if (base.ExtendedData.TryGet("AcDbBlockRepBTag", out var value))
			{
				return (BlockRecord)value.Records.OfType<ExtendedDataHandle>().FirstOrDefault().ResolveReference(base.Document);
			}
			return null;
		}
	}

	public override string SubclassMarker => "AcDbBlockTableRecord";

	public UnitsType Units { get; set; }

	public IEnumerable<Viewport> Viewports => Entities.OfType<Viewport>();

	public BlockRecord(string name)
		: base(name)
	{
		BlockEntity = new Block(this);
		BlockEnd = new BlockEnd(this);
		Entities = new CadObjectCollection<Entity>(this);
	}

	public BlockRecord(string name, string xrefFile, bool isOverlay = false)
		: this(name)
	{
		if (string.IsNullOrEmpty(xrefFile))
		{
			throw new ArgumentNullException("xrefFile");
		}
		if (xrefFile.IndexOfAny(Path.GetInvalidPathChars()) == 0)
		{
			throw new ArgumentException("File path contains invalid characters.", "xrefFile");
		}
		BlockEntity.XRefPath = xrefFile;
		Flags = BlockTypeFlags.XRef | BlockTypeFlags.XRefResolved;
		if (isOverlay)
		{
			Flags |= BlockTypeFlags.XRefOverlay;
		}
	}

	internal BlockRecord()
	{
		BlockEntity = new Block(this);
		BlockEnd = new BlockEnd(this);
		Entities = new CadObjectCollection<Entity>(this);
	}

	public void ApplyTransform(Transform transform)
	{
		foreach (Entity entity in Entities)
		{
			entity.ApplyTransform(transform);
		}
	}

	public override CadObject Clone()
	{
		BlockRecord blockRecord = (BlockRecord)base.Clone();
		blockRecord.Layout = null;
		if (SortEntitiesTable != null)
		{
			blockRecord.SortEntitiesTable.BlockOwner = blockRecord;
		}
		blockRecord.Entities = new CadObjectCollection<Entity>(blockRecord);
		foreach (Entity entity2 in Entities)
		{
			Entity entity = (Entity)entity2.Clone();
			blockRecord.Entities.Add(entity);
			if (SortEntitiesTable != null)
			{
				blockRecord.SortEntitiesTable.Add(entity, SortEntitiesTable.GetSorterHandle(entity2));
			}
		}
		blockRecord.BlockEntity = (Block)BlockEntity.Clone();
		blockRecord.BlockEntity.Owner = blockRecord;
		blockRecord.BlockEnd = (BlockEnd)BlockEnd.Clone();
		blockRecord.BlockEnd.Owner = blockRecord;
		return blockRecord;
	}

	public SortEntitiesTable CreateSortEntitiesTable()
	{
		CadDictionary cadDictionary = CreateExtendedDictionary();
		if (cadDictionary.TryGetEntry<SortEntitiesTable>("ACAD_SORTENTS", out var value))
		{
			return value;
		}
		value = new SortEntitiesTable(this);
		cadDictionary.Add(value);
		return value;
	}

	public BoundingBox GetBoundingBox()
	{
		return GetBoundingBox(ignoreInfinite: true);
	}

	public BoundingBox GetBoundingBox(bool ignoreInfinite)
	{
		BoundingBox result = BoundingBox.Null;
		foreach (Entity entity in Entities)
		{
			if (!(entity.GetBoundingBox().Extent == BoundingBoxExtent.Infinite && ignoreInfinite))
			{
				result = result.Merge(entity.GetBoundingBox());
			}
		}
		return result;
	}

	public IEnumerable<Entity> GetSortedEntities()
	{
		if (SortEntitiesTable == null)
		{
			return Entities.OrderBy((Entity e) => e.Handle);
		}
		List<(ulong, Entity)> list = new List<(ulong, Entity)>();
		foreach (Entity entity in Entities)
		{
			ulong sorterHandle = SortEntitiesTable.GetSorterHandle(entity);
			list.Add((sorterHandle, entity));
		}
		return from e in list
			orderby e.Item1
			select e.Item2;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		doc.RegisterCollection(Entities);
	}

	internal override void UnassignDocument()
	{
		base.Document.UnregisterCollection(Entities);
		base.UnassignDocument();
	}
}
