using System;
using ACadSharp.Blocks;
using ACadSharp.Exceptions;
using ACadSharp.IO.Templates;
using ACadSharp.Tables;

namespace ACadSharp.IO.DXF;

internal class DxfBlockSectionReader : DxfSectionReaderBase
{
	public DxfBlockSectionReader(IDxfStreamReader reader, DxfDocumentBuilder builder)
		: base(reader, builder)
	{
	}

	public override void Read()
	{
		_reader.ReadNext();
		while (_reader.ValueAsString != "ENDSEC")
		{
			try
			{
				if (_reader.ValueAsString == "BLOCK")
				{
					readBlock();
					continue;
				}
				throw new DxfException("Unexpected token at the BLOCKS table: " + _reader.ValueAsString, _reader.Position);
			}
			catch (Exception exception)
			{
				if (!_builder.Configuration.Failsafe)
				{
					throw;
				}
				_builder.Notify($"Error while reading a block at line {_reader.Position}", NotificationType.Error, exception);
				while ((_reader.DxfCode != DxfCode.Start || !(_reader.ValueAsString == "ENDSEC")) && (_reader.DxfCode != DxfCode.Start || !(_reader.ValueAsString == "BLOCK")))
				{
					_reader.ReadNext();
				}
			}
		}
	}

	private void readBlock()
	{
		_reader.ReadNext();
		DxfMap dxfMap = DxfMap.Create<Block>();
		Block block = new Block();
		CadBlockEntityTemplate cadBlockEntityTemplate = new CadBlockEntityTemplate(block);
		string text = null;
		BlockRecord entry = null;
		CadBlockRecordTemplate value = null;
		while (_reader.DxfCode != DxfCode.Start)
		{
			switch (_reader.Code)
			{
			case 2:
			case 3:
				text = _reader.ValueAsString;
				if (text.Equals("$MODEL_SPACE", StringComparison.OrdinalIgnoreCase))
				{
					text = "*Model_Space";
				}
				else if (text.Equals("$PAPER_SPACE", StringComparison.OrdinalIgnoreCase))
				{
					text = "*Paper_Space";
				}
				if (entry == null && _builder.TryGetTableEntry<BlockRecord>(text, out entry))
				{
					entry.BlockEntity = block;
				}
				else if (entry == null)
				{
					_builder.Notify($"Block record [{text}] not found at line {_reader.Position}", NotificationType.Warning);
				}
				break;
			case 330:
				if (entry == null && _builder.TryGetCadObject<BlockRecord>(_reader.ValueAsHandle, out entry))
				{
					entry.BlockEntity = block;
				}
				else if (entry == null)
				{
					_builder.Notify($"Block record with handle [{_reader.ValueAsString}] not found at line {_reader.Position}", NotificationType.Warning);
				}
				break;
			default:
				if (!tryAssignCurrentValue(cadBlockEntityTemplate.CadObject, dxfMap.SubClasses["AcDbBlockBegin"]))
				{
					readCommonEntityCodes(cadBlockEntityTemplate, out var isExtendedData, dxfMap);
					if (isExtendedData)
					{
						continue;
					}
				}
				break;
			}
			_reader.ReadNext();
		}
		if (entry == null)
		{
			entry = new BlockRecord(text);
			entry.BlockEntity = block;
			value = new CadBlockRecordTemplate(entry);
			_builder.AddTemplate(value);
			_builder.BlockRecords.Add(entry);
			if (value.CadObject.Name.Equals("*Model_Space", StringComparison.OrdinalIgnoreCase))
			{
				_builder.ModelSpaceTemplate = value;
			}
		}
		else if (!_builder.TryGetObjectTemplate<CadBlockRecordTemplate>(entry.Handle, out value))
		{
			value = new CadBlockRecordTemplate(entry);
		}
		value.BlockEntityTemplate = cadBlockEntityTemplate;
		while (_reader.ValueAsString != "ENDBLK")
		{
			CadEntityTemplate cadEntityTemplate = null;
			try
			{
				cadEntityTemplate = readEntity();
			}
			catch (Exception exception)
			{
				if (!_builder.Configuration.Failsafe)
				{
					throw;
				}
				_builder.Notify($"Error while reading a block with name {entry.Name} at line {_reader.Position}", NotificationType.Error, exception);
				while (_reader.DxfCode != DxfCode.Start)
				{
					_reader.ReadNext();
				}
			}
			if (cadEntityTemplate != null)
			{
				_builder.AddTemplate(cadEntityTemplate);
				ICadOwnerTemplate value2;
				if (!cadEntityTemplate.OwnerHandle.HasValue)
				{
					value.OwnedObjectsHandlers.Add(cadEntityTemplate.CadObject.Handle);
				}
				else if (_builder.TryGetObjectTemplate<ICadOwnerTemplate>(cadEntityTemplate.OwnerHandle, out value2))
				{
					value2.OwnedObjectsHandlers.Add(cadEntityTemplate.CadObject.Handle);
				}
				else
				{
					_builder.OrphanTemplates.Add(cadEntityTemplate);
				}
			}
		}
		readBlockEnd(entry.BlockEnd);
		_builder.AddTemplate(cadBlockEntityTemplate);
	}

	private void readBlockEnd(BlockEnd block)
	{
		DxfMap dxfMap = DxfMap.Create<BlockEnd>();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(block);
		if (_reader.DxfCode == DxfCode.Start)
		{
			_reader.ReadNext();
		}
		while (_reader.DxfCode != DxfCode.Start)
		{
			_ = _reader.Code;
			if (!tryAssignCurrentValue(cadEntityTemplate.CadObject, dxfMap.SubClasses["AcDbBlockEnd"]))
			{
				readCommonEntityCodes(cadEntityTemplate, out var isExtendedData, dxfMap);
				if (isExtendedData)
				{
					continue;
				}
			}
			_reader.ReadNext();
		}
		_builder.AddTemplate(cadEntityTemplate);
	}
}
