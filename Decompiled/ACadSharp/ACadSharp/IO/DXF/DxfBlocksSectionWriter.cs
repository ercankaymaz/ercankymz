using ACadSharp.Blocks;
using ACadSharp.Entities;
using ACadSharp.Tables;

namespace ACadSharp.IO.DXF;

internal class DxfBlocksSectionWriter : DxfSectionWriterBase
{
	public override string SectionName => "BLOCKS";

	public DxfBlocksSectionWriter(IDxfStreamWriter writer, CadDocument document, CadObjectHolder objectHolder, DxfWriterConfiguration configuration)
		: base(writer, document, objectHolder, configuration)
	{
	}

	protected override void writeSection()
	{
		foreach (BlockRecord blockRecord in _document.BlockRecords)
		{
			writeBlock(blockRecord.BlockEntity);
			processEntities(blockRecord);
			writeBlockEnd(blockRecord.BlockEnd);
		}
	}

	private void writeBlock(Block block)
	{
		DxfClassMap map = DxfClassMap.Create<Block>();
		_writer.Write(DxfCode.Start, block.ObjectName);
		writeCommonObjectData(block);
		writeCommonEntityData(block);
		_writer.Write(DxfCode.Subclass, "AcDbBlockBegin");
		if (!string.IsNullOrEmpty(block.XRefPath))
		{
			_writer.Write(1, block.XRefPath, map);
		}
		_writer.Write(2, block.Name, map);
		_writer.Write(70, (short)block.Flags, map);
		if (base.Version >= ACadVersion.AC1015 && block.IsUnloaded)
		{
			_writer.Write(71, block.IsUnloaded ? 1 : 0, map);
		}
		_writer.Write(10, block.BasePoint, map);
		_writer.Write(3, block.Name, map);
		_writer.Write(4, block.Comments, map);
	}

	private void processEntities(BlockRecord b)
	{
		if (b.Name == "*Model_Space" || b.Name == "*Paper_Space")
		{
			foreach (Entity entity in b.Entities)
			{
				base.Holder.Entities.Enqueue(entity);
			}
			return;
		}
		foreach (Entity entity2 in b.Entities)
		{
			writeEntity(entity2);
		}
	}

	private void writeBlockEnd(BlockEnd block)
	{
		_writer.Write(DxfCode.Start, block.ObjectName);
		writeCommonObjectData(block);
		_writer.Write(DxfCode.Subclass, "AcDbEntity");
		_writer.Write(8, block.Layer.Name);
		_writer.Write(DxfCode.Subclass, "AcDbBlockEnd");
	}
}
