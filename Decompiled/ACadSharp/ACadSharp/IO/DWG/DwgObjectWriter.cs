using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ACadSharp.Blocks;
using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Objects.Evaluations;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;
using ACadSharp.XData;
using CSMath;
using CSUtilities.Converters;
using CSUtilities.IO;
using CSUtilities.Text;

namespace ACadSharp.IO.DWG;

internal class DwgObjectWriter : DwgSectionIO
{
	private Dictionary<ulong, CadDictionary> _dictionaries = new Dictionary<ulong, CadDictionary>();

	private Queue<NonGraphicalObject> _objects = new Queue<NonGraphicalObject>();

	private MemoryStream _msmain;

	private IDwgStreamWriter _writer;

	private Stream _stream;

	private CadDocument _document;

	private Entity _prev;

	private Entity _next;

	public override string SectionName => "AcDb:AcDbObjects";

	public Dictionary<ulong, long> Map { get; } = new Dictionary<ulong, long>();

	public bool WriteXRecords { get; }

	public bool WriteXData { get; }

	public bool WriteShapes { get; } = true;

	private void registerObject(CadObject cadObject)
	{
		_writer.WriteSpearShift();
		long position = _stream.Position;
		CRC8StreamHandler cRC8StreamHandler = new CRC8StreamHandler(_stream, 49345);
		uint size = (uint)_msmain.Length;
		long size2 = (_msmain.Length << 3) - _writer.SavedPositionInBits;
		writeSize(cRC8StreamHandler, size);
		if (R2010Plus)
		{
			writeSizeInBits(cRC8StreamHandler, (ulong)size2);
		}
		cRC8StreamHandler.Write(_msmain.GetBuffer(), 0, (int)_msmain.Length);
		_stream.Write(LittleEndianConverter.Instance.GetBytes(cRC8StreamHandler.Seed), 0, 2);
		Map.Add(cadObject.Handle, position);
	}

	private void writeSize(Stream stream, uint size)
	{
		if (size >= 32768)
		{
			stream.WriteByte((byte)(size & 0xFF));
			stream.WriteByte((byte)(((size >> 8) & 0x7F) | 0x80));
			stream.WriteByte((byte)((size >> 15) & 0xFF));
			stream.WriteByte((byte)((size >> 23) & 0xFF));
		}
		else
		{
			stream.WriteByte((byte)(size & 0xFF));
			stream.WriteByte((byte)((size >> 8) & 0xFF));
		}
	}

	private void writeSizeInBits(Stream stream, ulong size)
	{
		if (size == 0L)
		{
			stream.WriteByte(0);
			return;
		}
		ulong num = size >> 7;
		while (size != 0L)
		{
			byte b = (byte)(size & 0x7F);
			if (num != 0L)
			{
				b |= 0x80;
			}
			stream.WriteByte(b);
			size = num;
			num = size >> 7;
		}
	}

	private void writeXrefDependantBit(TableEntry entry)
	{
		if (R2007Plus)
		{
			_writer.WriteBitShort((short)(entry.Flags.HasFlag(StandardFlags.XrefDependent) ? 256 : 0));
			return;
		}
		_writer.WriteBit(entry.Flags.HasFlag(StandardFlags.Referenced));
		_writer.WriteBitShort(0);
		_writer.WriteBit(entry.Flags.HasFlag(StandardFlags.XrefDependent));
	}

	private void writeCommonData(CadObject cadObject)
	{
		_writer.ResetStream();
		ObjectType objectType = cadObject.ObjectType;
		if (objectType != ObjectType.UNLISTED)
		{
			if ((uint)(objectType - -1) <= 1u)
			{
				notify($"CadObject type: {cadObject.ObjectType} fullname: {cadObject.GetType().FullName}", NotificationType.NotImplemented);
				return;
			}
			if (objectType != ObjectType.LAYOUT || !R2004Pre)
			{
				_writer.WriteObjectType(cadObject.ObjectType);
				goto IL_00c0;
			}
		}
		if (_document.Classes.TryGetByName(cadObject.ObjectName, out var result))
		{
			_writer.WriteObjectType(result.ClassNumber);
			goto IL_00c0;
		}
		notify($"Dxf Class not found for {cadObject.ObjectType} fullname: {cadObject.GetType().FullName}", NotificationType.Warning);
		return;
		IL_00c0:
		if (_version >= ACadVersion.AC1015 && _version < ACadVersion.AC1024)
		{
			_writer.SavePositonForSize();
		}
		_writer.Main.HandleReference(cadObject);
		writeExtendedData(cadObject.ExtendedData);
	}

	private void writeCommonNonEntityData(CadObject cadObject)
	{
		writeCommonData(cadObject);
		if (R13_14Only)
		{
			_writer.SavePositonForSize();
		}
		_writer.HandleReference(DwgReferenceType.SoftPointer, cadObject.Owner.Handle);
		writeReactorsAndDictionaryHandle(cadObject);
	}

	private void writeCommonEntityData(Entity entity)
	{
		writeCommonData(entity);
		_writer.WriteBit(value: false);
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1014)
		{
			_writer.SavePositonForSize();
		}
		writeEntityMode(entity);
	}

	private void writeEntityMode(Entity entity)
	{
		byte entMode = getEntMode(entity);
		_writer.Write2Bits(entMode);
		if (entMode == 0)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, entity.Owner);
		}
		writeReactorsAndDictionaryHandle(entity);
		if (R13_14Only)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, entity.Layer);
			bool flag = entity.LineType.Name == "ByLayer";
			_writer.WriteBit(flag);
			if (flag)
			{
				_writer.HandleReference(DwgReferenceType.HardPointer, entity.LineType);
			}
		}
		if (!R2004Plus)
		{
			bool flag2 = _prev != null && _prev.Handle == entity.Handle - 1 && _next != null && _next.Handle == entity.Handle + 1;
			_writer.WriteBit(flag2);
			if (!flag2)
			{
				_writer.HandleReference(DwgReferenceType.SoftPointer, _prev);
				_writer.HandleReference(DwgReferenceType.SoftPointer, _next);
			}
		}
		_writer.WriteEnColor(entity.Color, entity.Transparency, entity.BookColor != null);
		if (_version >= ACadVersion.AC1018 && entity.BookColor != null)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, entity.BookColor);
		}
		_writer.WriteBitDouble(entity.LineTypeScale);
		if (_version < ACadVersion.AC1015)
		{
			_writer.WriteBitShort((!entity.IsInvisible) ? ((short)1) : ((short)0));
			return;
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, entity.Layer);
		if (entity.LineType.Name == "ByLayer")
		{
			_writer.Write2Bits(0);
		}
		else if (entity.LineType.Name == "ByBlock")
		{
			_writer.Write2Bits(1);
		}
		else if (entity.LineType.Name == "Continuous")
		{
			_writer.Write2Bits(2);
		}
		else
		{
			_writer.Write2Bits(3);
			_writer.HandleReference(DwgReferenceType.HardPointer, entity.LineType);
		}
		if (R2007Plus)
		{
			_writer.Write2Bits(0);
			_writer.WriteByte(0);
		}
		_writer.Write2Bits(0);
		if (_version > ACadVersion.AC1021)
		{
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
		}
		_writer.WriteBitShort(entity.IsInvisible ? ((short)1) : ((short)0));
		_writer.WriteByte(CadUtils.ToIndex(entity.LineWeight));
	}

	private void writeExtendedData(ExtendedDataDictionary data)
	{
		if (WriteXData)
		{
			foreach (KeyValuePair<AppId, ExtendedData> datum in data)
			{
				writeExtendedDataEntry(datum.Key, datum.Value);
			}
		}
		_writer.WriteBitShort(0);
	}

	private void writeExtendedDataEntry(AppId app, ExtendedData entry)
	{
		using MemoryStream memoryStream = new MemoryStream();
		foreach (ExtendedDataRecord record in entry.Records)
		{
			memoryStream.WriteByte((byte)(record.Code - 1000));
			if (!(record is ExtendedDataBinaryChunk extendedDataBinaryChunk))
			{
				if (!(record is ExtendedDataControlString extendedDataControlString))
				{
					if (!(record is ExtendedDataInteger16 extendedDataInteger))
					{
						if (!(record is ExtendedDataInteger32 extendedDataInteger2))
						{
							if (!(record is ExtendedDataReal extendedDataReal))
							{
								if (!(record is ExtendedDataScale extendedDataScale))
								{
									if (!(record is ExtendedDataDistance extendedDataDistance))
									{
										if (!(record is ExtendedDataDirection extendedDataDirection))
										{
											if (!(record is ExtendedDataDisplacement extendedDataDisplacement))
											{
												if (!(record is ExtendedDataCoordinate extendedDataCoordinate))
												{
													if (!(record is ExtendedDataWorldCoordinate extendedDataWorldCoordinate))
													{
														if (!(record is IExtendedDataHandleReference { Value: var value } extendedDataHandleReference))
														{
															if (!(record is ExtendedDataString extendedDataString))
															{
																throw new NotSupportedException("ExtendedDataRecord of type " + record.GetType().FullName + " not supported.");
															}
															if (R2007Plus)
															{
																memoryStream.Write(LittleEndianConverter.Instance.GetBytes((ushort)extendedDataString.Value.Length + 1), 0, 2);
																byte[] bytes = Encoding.Unicode.GetBytes(extendedDataString.Value);
																memoryStream.Write(bytes, 0, bytes.Length);
																memoryStream.WriteByte(0);
																memoryStream.WriteByte(0);
															}
															else
															{
																int codeIndex = CadUtils.GetCodeIndex((CodePage)_writer.Encoding.CodePage);
																byte[] bytes2 = _writer.Encoding.GetBytes(string.IsNullOrEmpty(extendedDataString.Value) ? string.Empty : extendedDataString.Value);
																memoryStream.Write(LittleEndianConverter.Instance.GetBytes((ushort)extendedDataString.Value.Length), 0, 2);
																memoryStream.WriteByte((byte)codeIndex);
																memoryStream.Write(bytes2, 0, bytes2.Length);
															}
														}
														else
														{
															if (extendedDataHandleReference.ResolveReference(_document) == null)
															{
																value = 0uL;
															}
															memoryStream.Write(BigEndianConverter.Instance.GetBytes(value), 0, 8);
														}
													}
													else
													{
														memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataWorldCoordinate.Value.X), 0, 8);
														memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataWorldCoordinate.Value.Y), 0, 8);
														memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataWorldCoordinate.Value.Z), 0, 8);
													}
												}
												else
												{
													memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataCoordinate.Value.X), 0, 8);
													memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataCoordinate.Value.Y), 0, 8);
													memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataCoordinate.Value.Z), 0, 8);
												}
											}
											else
											{
												memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataDisplacement.Value.X), 0, 8);
												memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataDisplacement.Value.Y), 0, 8);
												memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataDisplacement.Value.Z), 0, 8);
											}
										}
										else
										{
											memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataDirection.Value.X), 0, 8);
											memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataDirection.Value.Y), 0, 8);
											memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataDirection.Value.Z), 0, 8);
										}
									}
									else
									{
										memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataDistance.Value), 0, 8);
									}
								}
								else
								{
									memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataScale.Value), 0, 8);
								}
							}
							else
							{
								memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataReal.Value), 0, 8);
							}
						}
						else
						{
							memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataInteger2.Value), 0, 4);
						}
					}
					else
					{
						memoryStream.Write(LittleEndianConverter.Instance.GetBytes(extendedDataInteger.Value), 0, 2);
					}
				}
				else
				{
					memoryStream.WriteByte((extendedDataControlString.Value == '}') ? ((byte)1) : ((byte)0));
				}
			}
			else
			{
				memoryStream.WriteByte((byte)extendedDataBinaryChunk.Value.Length);
				memoryStream.Write(extendedDataBinaryChunk.Value, 0, extendedDataBinaryChunk.Value.Length);
			}
		}
		_writer.WriteBitShort((short)memoryStream.Length);
		_writer.Main.HandleReference(DwgReferenceType.HardPointer, app.Handle);
		_writer.WriteBytes(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}

	private void writeReactorsAndDictionaryHandle(CadObject cadObject)
	{
		cadObject.CleanReactors();
		_writer.WriteBitLong(cadObject.Reactors.Count());
		foreach (CadObject reactor in cadObject.Reactors)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, reactor);
		}
		bool flag = cadObject.XDictionary == null;
		if (R2004Plus)
		{
			_writer.WriteBit(flag);
			if (!flag)
			{
				_writer.HandleReference(DwgReferenceType.HardOwnership, cadObject.XDictionary);
			}
		}
		else
		{
			_writer.HandleReference(DwgReferenceType.HardOwnership, cadObject.XDictionary);
		}
		if (R2013Plus)
		{
			_writer.WriteBit(value: false);
		}
		if (!flag)
		{
			_dictionaries.Add(cadObject.XDictionary.Handle, cadObject.XDictionary);
			_objects.Enqueue(cadObject.XDictionary);
		}
	}

	private byte getEntMode(Entity entity)
	{
		if (entity.Owner == null)
		{
			return 0;
		}
		if (entity.Owner.Handle == _document.PaperSpace.Handle)
		{
			return 1;
		}
		if (entity.Owner.Handle == _document.ModelSpace.Handle)
		{
			return 2;
		}
		return 0;
	}

	public DwgObjectWriter(Stream stream, CadDocument document, Encoding encoding, bool writeXRecords = true, bool writeXData = true, bool writeShapes = true)
		: base(document.Header.Version)
	{
		_stream = stream;
		_document = document;
		_msmain = new MemoryStream();
		_writer = DwgStreamWriterBase.GetMergedWriter(document.Header.Version, _msmain, encoding);
		WriteXRecords = writeXRecords;
		WriteXData = writeXData;
		WriteShapes = writeShapes;
	}

	public void Write()
	{
		if (R2004Plus)
		{
			byte[] bytes = LittleEndianConverter.Instance.GetBytes(3530);
			_stream.Write(bytes, 0, bytes.Length);
		}
		_objects.Enqueue(_document.RootDictionary);
		writeBlockControl();
		writeTable(_document.Layers);
		writeTable(_document.TextStyles);
		writeLTypeControlObject();
		writeTable(_document.Views);
		writeTable(_document.UCSs);
		writeTable(_document.VPorts);
		writeTable(_document.AppIds);
		writeTable(_document.DimensionStyles);
		if (R2004Pre)
		{
			writeTable(_document.VEntityControl);
		}
		writeBlockEntities();
		writeObjects();
	}

	private void writeLTypeControlObject()
	{
		writeCommonNonEntityData(_document.LineTypes);
		_writer.WriteBitLong(_document.LineTypes.Count - 2);
		foreach (LineType lineType in _document.LineTypes)
		{
			if (!lineType.Name.Equals("ByBlock", StringComparison.OrdinalIgnoreCase) && !lineType.Name.Equals("ByLayer", StringComparison.OrdinalIgnoreCase))
			{
				_writer.HandleReference(DwgReferenceType.SoftOwnership, lineType);
			}
		}
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.LineTypes.ByBlock);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.LineTypes.ByLayer);
		registerObject(_document.LineTypes);
		writeEntries(_document.LineTypes);
	}

	private void writeBlockControl()
	{
		writeCommonNonEntityData(_document.BlockRecords);
		_writer.WriteBitLong(_document.BlockRecords.Count - 2);
		foreach (BlockRecord blockRecord in _document.BlockRecords)
		{
			if (!blockRecord.Name.Equals("*Model_Space", StringComparison.OrdinalIgnoreCase) && !blockRecord.Name.Equals("*Paper_Space", StringComparison.OrdinalIgnoreCase))
			{
				_writer.HandleReference(DwgReferenceType.SoftOwnership, blockRecord);
			}
		}
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.ModelSpace);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.PaperSpace);
		registerObject(_document.BlockRecords);
		writeEntries(_document.BlockRecords);
	}

	private void writeTable<T>(Table<T> table) where T : TableEntry
	{
		writeCommonNonEntityData(table);
		_writer.WriteBitLong(table.Count);
		if (R2000Plus && table is DimensionStylesTable)
		{
			_writer.WriteByte(0);
		}
		foreach (T item in table)
		{
			_writer.HandleReference(DwgReferenceType.SoftOwnership, item);
		}
		registerObject(table);
		writeEntries(table);
	}

	private void writeEntries<T>(Table<T> table) where T : TableEntry
	{
		foreach (T item in table)
		{
			if (!(item is AppId app))
			{
				if (!(item is BlockRecord blkRecord))
				{
					if (!(item is Layer layer))
					{
						if (!(item is LineType ltype))
						{
							if (!(item is TextStyle style))
							{
								if (!(item is UCS ucs))
								{
									if (!(item is View view))
									{
										if (!(item is DimensionStyle dimStyle))
										{
											if (item is VPort vport)
											{
												writeVPort(vport);
											}
											else
											{
												notify("Table entry not implemented : " + item.GetType().FullName, NotificationType.NotImplemented);
											}
										}
										else
										{
											writeDimensionStyle(dimStyle);
										}
									}
									else
									{
										writeView(view);
									}
								}
								else
								{
									writeUCS(ucs);
								}
							}
							else
							{
								writeTextStyle(style);
							}
						}
						else
						{
							writeLineType(ltype);
						}
					}
					else
					{
						writeLayer(layer);
					}
				}
				else
				{
					writeBlockRecord(blkRecord);
				}
			}
			else
			{
				writeAppId(app);
			}
		}
	}

	private void writeBlockEntities()
	{
		foreach (BlockRecord blockRecord in _document.BlockRecords)
		{
			writeBlockBegin(blockRecord.BlockEntity);
			_prev = null;
			_next = null;
			Entity[] compatibleEntities = getCompatibleEntities(blockRecord.Entities);
			for (int i = 0; i < compatibleEntities.Length; i++)
			{
				_prev = compatibleEntities.ElementAtOrDefault(i - 1);
				Entity entity = compatibleEntities[i];
				_next = compatibleEntities.ElementAtOrDefault(i + 1);
				writeEntity(entity);
			}
			_prev = null;
			_next = null;
			writeBlockEnd(blockRecord.BlockEnd);
		}
	}

	private Entity[] getCompatibleEntities(IEnumerable<Entity> entities)
	{
		return entities.Where((Entity e) => isEntitySupported(e)).ToArray();
	}

	private bool isEntitySupported(Entity entity)
	{
		if (!(entity is UnknownEntity))
		{
			if (!(entity is Shape))
			{
				if (entity is ProxyEntity || entity is TableEntity || entity is Solid3D || entity is CadBody || entity is Region)
				{
					notify("Entity type not implemented " + entity.GetType().FullName, NotificationType.NotImplemented);
					return false;
				}
				return true;
			}
			return WriteShapes;
		}
		return false;
	}

	private void writeAppId(AppId app)
	{
		writeCommonNonEntityData(app);
		_writer.WriteVariableText(app.Name);
		writeXrefDependantBit(app);
		_writer.WriteByte(0);
		_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		registerObject(app);
	}

	private void writeBlockRecord(BlockRecord blkRecord)
	{
		writeBlockHeader(blkRecord);
	}

	private void writeBlockHeader(BlockRecord record)
	{
		Entity[] compatibleEntities = getCompatibleEntities(record.Entities);
		writeCommonNonEntityData(record);
		if (record.Flags.HasFlag(BlockTypeFlags.Anonymous))
		{
			_writer.WriteVariableText(record.Name.Substring(0, 2));
		}
		else if (record.Layout != null)
		{
			string value = new string(record.Name.Where((char c) => !char.IsDigit(c)).ToArray());
			_writer.WriteVariableText(value);
		}
		else
		{
			_writer.WriteVariableText(record.Name);
		}
		writeXrefDependantBit(record);
		_writer.WriteBit(record.Flags.HasFlag(BlockTypeFlags.Anonymous));
		_writer.WriteBit(record.HasAttributes);
		_writer.WriteBit(record.Flags.HasFlag(BlockTypeFlags.XRef));
		_writer.WriteBit(record.Flags.HasFlag(BlockTypeFlags.XRefOverlay));
		if (R2000Plus)
		{
			_writer.WriteBit(record.IsUnloaded);
		}
		if (R2004Plus && !record.Flags.HasFlag(BlockTypeFlags.XRef) && !record.Flags.HasFlag(BlockTypeFlags.XRefOverlay))
		{
			_writer.WriteBitLong(compatibleEntities.Length);
		}
		_writer.Write3BitDouble(record.BlockEntity.BasePoint);
		_writer.WriteVariableText(record.BlockEntity.XRefPath);
		if (R2000Plus)
		{
			foreach (Insert item in from i in _document.Entities.OfType<Insert>()
				where i.Block?.Name == record?.Name
				select i)
			{
				_ = item;
				_writer.WriteByte(1);
			}
			_writer.WriteByte(0);
			_writer.WriteVariableText(record.BlockEntity.Comments);
			_writer.WriteBitLong(0);
		}
		if (R2007Plus)
		{
			_writer.WriteBitShort((short)record.Units);
			_writer.WriteBit(record.IsExplodable);
			_writer.WriteByte(record.CanScale ? ((byte)1) : ((byte)0));
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		_writer.HandleReference(DwgReferenceType.HardOwnership, record.BlockEntity);
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015 && !record.Flags.HasFlag(BlockTypeFlags.XRef) && !record.Flags.HasFlag(BlockTypeFlags.XRefOverlay))
		{
			if (compatibleEntities.Any())
			{
				_writer.HandleReference(DwgReferenceType.SoftPointer, compatibleEntities.First());
				_writer.HandleReference(DwgReferenceType.SoftPointer, compatibleEntities.Last());
			}
			else
			{
				_writer.HandleReference(DwgReferenceType.SoftPointer, 0uL);
				_writer.HandleReference(DwgReferenceType.SoftPointer, 0uL);
			}
		}
		if (R2004Plus)
		{
			Entity[] array = compatibleEntities;
			foreach (Entity cadObject in array)
			{
				_writer.HandleReference(DwgReferenceType.HardOwnership, cadObject);
			}
		}
		_writer.HandleReference(DwgReferenceType.HardOwnership, record.BlockEnd);
		if (R2000Plus)
		{
			foreach (Insert item2 in from i in _document.Entities.OfType<Insert>()
				where i.Block?.Name == record.Name
				select i)
			{
				_writer.HandleReference(DwgReferenceType.SoftPointer, item2);
			}
			_writer.HandleReference(DwgReferenceType.HardPointer, record.Layout);
		}
		registerObject(record);
	}

	private void writeBlockBegin(Block block)
	{
		writeCommonEntityData(block);
		_writer.WriteVariableText(block.Name);
		registerObject(block);
	}

	private void writeBlockEnd(BlockEnd blkEnd)
	{
		writeCommonEntityData(blkEnd);
		registerObject(blkEnd);
	}

	private void writeLayer(Layer layer)
	{
		writeCommonNonEntityData(layer);
		_writer.WriteVariableText(layer.Name);
		writeXrefDependantBit(layer);
		if (R13_14Only)
		{
			_writer.WriteBit(layer.Flags.HasFlag(LayerFlags.Frozen));
			_writer.WriteBit(layer.IsOn);
			_writer.WriteBit(layer.Flags.HasFlag(LayerFlags.FrozenNewViewports));
			_writer.WriteBit(layer.Flags.HasFlag(LayerFlags.Locked));
		}
		if (R2000Plus)
		{
			short num = (short)(CadUtils.ToIndex(layer.LineWeight) << 5);
			if (layer.Flags.HasFlag(LayerFlags.Frozen))
			{
				num |= 1;
			}
			if (!layer.IsOn)
			{
				num |= 2;
			}
			if (layer.Flags.HasFlag(LayerFlags.Frozen))
			{
				num |= 4;
			}
			if (layer.Flags.HasFlag(LayerFlags.Locked))
			{
				num |= 8;
			}
			if (layer.PlotFlag)
			{
				num |= 0x10;
			}
			_writer.WriteBitShort(num);
		}
		_writer.WriteCmColor(layer.Color);
		_writer.HandleReference(DwgReferenceType.HardPointer, null);
		if (R2000Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		}
		if (R2007Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, layer.LineType.Handle);
		if (R2013Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		}
		registerObject(layer);
	}

	private void writeLineType(LineType ltype)
	{
		writeCommonNonEntityData(ltype);
		_writer.WriteVariableText(ltype.Name);
		writeXrefDependantBit(ltype);
		_writer.WriteVariableText(ltype.Description);
		_writer.WriteBitDouble(ltype.PatternLength);
		_writer.WriteByte((byte)ltype.Alignment);
		_writer.WriteByte((byte)ltype.Segments.Count());
		bool flag = false;
		foreach (LineType.Segment segment in ltype.Segments)
		{
			if (segment.Flags.HasFlag(LineTypeShapeFlags.Text))
			{
				flag = true;
				break;
			}
		}
		Encoding encoding = (R2007Plus ? Encoding.Unicode : _writer.Encoding);
		byte[] array = null;
		int num = 0;
		byte[] bytes = encoding.GetBytes("\0");
		if (_version <= ACadVersion.AC1018)
		{
			array = new byte[256];
			if (_version <= ACadVersion.AC1014)
			{
				num = 1;
			}
		}
		else if (R2007Plus && flag)
		{
			array = new byte[512];
		}
		foreach (LineType.Segment segment2 in ltype.Segments)
		{
			if (segment2.Flags.HasFlag(LineTypeShapeFlags.Text))
			{
				if (array == null || string.IsNullOrEmpty(segment2.Text))
				{
					segment2.ShapeNumber = 0;
				}
				else
				{
					byte[] bytes2 = encoding.GetBytes(segment2.Text);
					int num2 = bytes2.Length + bytes.Length;
					if (num + num2 <= array.Length)
					{
						segment2.ShapeNumber = (short)num;
						Buffer.BlockCopy(bytes2, 0, array, num, bytes2.Length);
						num += bytes2.Length;
						Buffer.BlockCopy(bytes, 0, array, num, bytes.Length);
						num += bytes.Length;
					}
					else
					{
						segment2.ShapeNumber = 0;
					}
				}
			}
			_writer.WriteBitDouble(segment2.Length);
			_writer.WriteBitShort(segment2.ShapeNumber);
			_writer.WriteRawDouble(segment2.Offset.X);
			_writer.WriteRawDouble(segment2.Offset.Y);
			_writer.WriteBitDouble(segment2.Scale);
			_writer.WriteBitDouble(segment2.Rotation);
			_writer.WriteBitShort((short)segment2.Flags);
		}
		if (_version <= ACadVersion.AC1018)
		{
			byte[] array2 = array ?? new byte[256];
			for (int i = 0; i < array2.Length; i++)
			{
				_writer.WriteByte(array2[i]);
			}
		}
		if (R2007Plus && flag)
		{
			byte[] array3 = array ?? new byte[512];
			for (int j = 0; j < array3.Length; j++)
			{
				_writer.WriteByte(array3[j]);
			}
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		foreach (LineType.Segment segment3 in ltype.Segments)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, segment3.Style);
		}
		registerObject(ltype);
	}

	private void writeTextStyle(TextStyle style)
	{
		writeCommonNonEntityData(style);
		if (style.IsShapeFile)
		{
			_writer.WriteVariableText(string.Empty);
		}
		else
		{
			_writer.WriteVariableText(style.Name);
		}
		writeXrefDependantBit(style);
		_writer.WriteBit(style.Flags.HasFlag(StyleFlags.IsShape));
		_writer.WriteBit(style.Flags.HasFlag(StyleFlags.VerticalText));
		_writer.WriteBitDouble(style.Height);
		_writer.WriteBitDouble(style.Width);
		_writer.WriteBitDouble(style.ObliqueAngle);
		_writer.WriteByte((byte)style.MirrorFlag);
		_writer.WriteBitDouble(style.LastHeight);
		_writer.WriteVariableText(style.Filename);
		_writer.WriteVariableText(style.BigFontFilename);
		_writer.HandleReference(DwgReferenceType.HardPointer, _document.TextStyles);
		registerObject(style);
	}

	private void writeUCS(UCS ucs)
	{
		writeCommonNonEntityData(ucs);
		_writer.WriteVariableText(ucs.Name);
		writeXrefDependantBit(ucs);
		_writer.Write3BitDouble(ucs.Origin);
		_writer.Write3BitDouble(ucs.XAxis);
		_writer.Write3BitDouble(ucs.YAxis);
		if (R2000Plus)
		{
			_writer.WriteBitDouble(ucs.Elevation);
			_writer.WriteBitShort((short)ucs.OrthographicViewType);
			_writer.WriteBitShort((short)ucs.OrthographicType);
		}
		_writer.HandleReference(DwgReferenceType.SoftPointer, _document.UCSs);
		if (R2000Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
			_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		}
		registerObject(ucs);
	}

	private void writeView(View view)
	{
		writeCommonNonEntityData(view);
		_writer.WriteVariableText(view.Name);
		writeXrefDependantBit(view);
		_writer.WriteBitDouble(view.Height);
		_writer.WriteBitDouble(view.Width);
		_writer.Write2RawDouble(view.Center);
		_writer.Write3BitDouble(view.Target);
		_writer.Write3BitDouble(view.Direction);
		_writer.WriteBitDouble(view.Angle);
		_writer.WriteBitDouble(view.LensLength);
		_writer.WriteBitDouble(view.FrontClipping);
		_writer.WriteBitDouble(view.BackClipping);
		_writer.WriteBit(view.ViewMode.HasFlag(ViewModeType.PerspectiveView));
		_writer.WriteBit(view.ViewMode.HasFlag(ViewModeType.FrontClipping));
		_writer.WriteBit(view.ViewMode.HasFlag(ViewModeType.BackClipping));
		_writer.WriteBit(view.ViewMode.HasFlag(ViewModeType.FrontClippingZ));
		if (R2000Plus)
		{
			_writer.WriteByte((byte)view.RenderMode);
		}
		if (R2007Plus)
		{
			_writer.WriteBit(value: true);
			_writer.WriteByte(1);
			_writer.WriteBitDouble(0.0);
			_writer.WriteBitDouble(0.0);
			_writer.WriteCmColor(new Color(250));
		}
		_writer.WriteBit(view.Flags.HasFlag((StandardFlags)1));
		if (R2000Plus)
		{
			_writer.WriteBit(view.IsUcsAssociated);
			if (view.IsUcsAssociated)
			{
				_writer.Write3BitDouble(view.UcsOrigin);
				_writer.Write3BitDouble(view.UcsXAxis);
				_writer.Write3BitDouble(view.UcsYAxis);
				_writer.WriteBitDouble(view.UcsElevation);
				_writer.WriteBitShort((short)view.UcsOrthographicType);
			}
		}
		_writer.HandleReference(DwgReferenceType.SoftPointer, _document.Views);
		if (R2007Plus)
		{
			_writer.WriteBit(view.IsPlottable);
			_writer.HandleReference(DwgReferenceType.SoftPointer, 0uL);
			_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
			_writer.HandleReference(DwgReferenceType.HardOwnership, 0uL);
		}
		if (R2000Plus && view.IsUcsAssociated)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
			_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		}
		if (R2007Plus)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, 0uL);
		}
		registerObject(view);
	}

	private void writeDimensionStyle(DimensionStyle dimStyle)
	{
		writeCommonNonEntityData(dimStyle);
		_writer.WriteVariableText(dimStyle.Name);
		writeXrefDependantBit(dimStyle);
		if (R13_14Only)
		{
			_writer.WriteBit(dimStyle.GenerateTolerances);
			_writer.WriteBit(dimStyle.LimitsGeneration);
			_writer.WriteBit(dimStyle.TextOutsideHorizontal);
			_writer.WriteBit(dimStyle.SuppressFirstExtensionLine);
			_writer.WriteBit(dimStyle.SuppressSecondExtensionLine);
			_writer.WriteBit(dimStyle.TextInsideHorizontal);
			_writer.WriteBit(dimStyle.AlternateUnitDimensioning);
			_writer.WriteBit(dimStyle.TextOutsideExtensions);
			_writer.WriteBit(dimStyle.SeparateArrowBlocks);
			_writer.WriteBit(dimStyle.TextInsideExtensions);
			_writer.WriteBit(dimStyle.SuppressOutsideExtensions);
			_writer.WriteByte((byte)dimStyle.AlternateUnitDecimalPlaces);
			_writer.WriteByte((byte)dimStyle.ZeroHandling);
			_writer.WriteBit(dimStyle.SuppressFirstDimensionLine);
			_writer.WriteBit(dimStyle.SuppressSecondDimensionLine);
			_writer.WriteByte((byte)dimStyle.ToleranceAlignment);
			_writer.WriteByte((byte)dimStyle.TextHorizontalAlignment);
			_writer.WriteByte((byte)dimStyle.DimensionFit);
			_writer.WriteBit(dimStyle.CursorUpdate);
			_writer.WriteByte((byte)dimStyle.ToleranceZeroHandling);
			_writer.WriteByte((byte)dimStyle.AlternateUnitZeroHandling);
			_writer.WriteByte((byte)dimStyle.AlternateUnitToleranceZeroHandling);
			_writer.WriteByte((byte)dimStyle.TextVerticalAlignment);
			_writer.WriteBitShort(dimStyle.DimensionUnit);
			_writer.WriteBitShort((short)dimStyle.AngularUnit);
			_writer.WriteBitShort(dimStyle.DecimalPlaces);
			_writer.WriteBitShort(dimStyle.ToleranceDecimalPlaces);
			_writer.WriteBitShort((short)dimStyle.AlternateUnitFormat);
			_writer.WriteBitShort(dimStyle.AlternateUnitToleranceDecimalPlaces);
			_writer.WriteBitDouble(dimStyle.ScaleFactor);
			_writer.WriteBitDouble(dimStyle.ArrowSize);
			_writer.WriteBitDouble(dimStyle.ExtensionLineOffset);
			_writer.WriteBitDouble(dimStyle.DimensionLineIncrement);
			_writer.WriteBitDouble(dimStyle.ExtensionLineExtension);
			_writer.WriteBitDouble(dimStyle.Rounding);
			_writer.WriteBitDouble(dimStyle.DimensionLineExtension);
			_writer.WriteBitDouble(dimStyle.PlusTolerance);
			_writer.WriteBitDouble(dimStyle.MinusTolerance);
			_writer.WriteBitDouble(dimStyle.TextHeight);
			_writer.WriteBitDouble(dimStyle.CenterMarkSize);
			_writer.WriteBitDouble(dimStyle.TickSize);
			_writer.WriteBitDouble(dimStyle.AlternateUnitScaleFactor);
			_writer.WriteBitDouble(dimStyle.LinearScaleFactor);
			_writer.WriteBitDouble(dimStyle.TextVerticalPosition);
			_writer.WriteBitDouble(dimStyle.ToleranceScaleFactor);
			_writer.WriteBitDouble(dimStyle.DimensionLineGap);
			_writer.WriteVariableText(dimStyle.PostFix);
			_writer.WriteVariableText(dimStyle.AlternateDimensioningSuffix);
			_writer.WriteVariableText(dimStyle.ArrowBlock?.Name);
			_writer.WriteVariableText(dimStyle.DimArrow1?.Name);
			_writer.WriteVariableText(dimStyle.DimArrow2?.Name);
			_writer.WriteCmColor(dimStyle.DimensionLineColor);
			_writer.WriteCmColor(dimStyle.ExtensionLineColor);
			_writer.WriteCmColor(dimStyle.TextColor);
		}
		if (R2000Plus)
		{
			_writer.WriteVariableText(dimStyle.PostFix);
			_writer.WriteVariableText(dimStyle.AlternateDimensioningSuffix);
			_writer.WriteBitDouble(dimStyle.ScaleFactor);
			_writer.WriteBitDouble(dimStyle.ArrowSize);
			_writer.WriteBitDouble(dimStyle.ExtensionLineOffset);
			_writer.WriteBitDouble(dimStyle.DimensionLineIncrement);
			_writer.WriteBitDouble(dimStyle.ExtensionLineExtension);
			_writer.WriteBitDouble(dimStyle.Rounding);
			_writer.WriteBitDouble(dimStyle.DimensionLineExtension);
			_writer.WriteBitDouble(dimStyle.PlusTolerance);
			_writer.WriteBitDouble(dimStyle.MinusTolerance);
		}
		if (R2007Plus)
		{
			_writer.WriteBitDouble(dimStyle.FixedExtensionLineLength);
			_writer.WriteBitDouble(dimStyle.JoggedRadiusDimensionTransverseSegmentAngle);
			_writer.WriteBitShort((short)dimStyle.TextBackgroundFillMode);
			_writer.WriteCmColor(dimStyle.TextBackgroundColor);
		}
		if (R2000Plus)
		{
			_writer.WriteBit(dimStyle.GenerateTolerances);
			_writer.WriteBit(dimStyle.LimitsGeneration);
			_writer.WriteBit(dimStyle.TextInsideHorizontal);
			_writer.WriteBit(dimStyle.TextOutsideHorizontal);
			_writer.WriteBit(dimStyle.SuppressFirstExtensionLine);
			_writer.WriteBit(dimStyle.SuppressSecondExtensionLine);
			_writer.WriteBitShort((short)dimStyle.TextVerticalAlignment);
			_writer.WriteBitShort((short)dimStyle.ZeroHandling);
			_writer.WriteBitShort((short)dimStyle.AngularZeroHandling);
		}
		if (R2007Plus)
		{
			_writer.WriteBitShort((short)dimStyle.ArcLengthSymbolPosition);
		}
		if (R2000Plus)
		{
			_writer.WriteBitDouble(dimStyle.TextHeight);
			_writer.WriteBitDouble(dimStyle.CenterMarkSize);
			_writer.WriteBitDouble(dimStyle.TickSize);
			_writer.WriteBitDouble(dimStyle.AlternateUnitScaleFactor);
			_writer.WriteBitDouble(dimStyle.LinearScaleFactor);
			_writer.WriteBitDouble(dimStyle.TextVerticalPosition);
			_writer.WriteBitDouble(dimStyle.ToleranceScaleFactor);
			_writer.WriteBitDouble(dimStyle.DimensionLineGap);
			_writer.WriteBitDouble(dimStyle.AlternateUnitRounding);
			_writer.WriteBit(dimStyle.AlternateUnitDimensioning);
			_writer.WriteBitShort(dimStyle.AlternateUnitDecimalPlaces);
			_writer.WriteBit(dimStyle.TextOutsideExtensions);
			_writer.WriteBit(dimStyle.SeparateArrowBlocks);
			_writer.WriteBit(dimStyle.TextInsideExtensions);
			_writer.WriteBit(dimStyle.SuppressOutsideExtensions);
			_writer.WriteCmColor(dimStyle.DimensionLineColor);
			_writer.WriteCmColor(dimStyle.ExtensionLineColor);
			_writer.WriteCmColor(dimStyle.TextColor);
			_writer.WriteBitShort(dimStyle.AngularDecimalPlaces);
			_writer.WriteBitShort(dimStyle.DecimalPlaces);
			_writer.WriteBitShort(dimStyle.ToleranceDecimalPlaces);
			_writer.WriteBitShort((short)dimStyle.AlternateUnitFormat);
			_writer.WriteBitShort(dimStyle.AlternateUnitToleranceDecimalPlaces);
			_writer.WriteBitShort((short)dimStyle.AngularUnit);
			_writer.WriteBitShort((short)dimStyle.FractionFormat);
			_writer.WriteBitShort((short)dimStyle.LinearUnitFormat);
			_writer.WriteBitShort((short)dimStyle.DecimalSeparator);
			_writer.WriteBitShort((short)dimStyle.TextMovement);
			_writer.WriteBitShort((short)dimStyle.TextHorizontalAlignment);
			_writer.WriteBit(dimStyle.SuppressFirstDimensionLine);
			_writer.WriteBit(dimStyle.SuppressSecondDimensionLine);
			_writer.WriteBitShort((short)dimStyle.ToleranceAlignment);
			_writer.WriteBitShort((short)dimStyle.ToleranceZeroHandling);
			_writer.WriteBitShort((short)dimStyle.AlternateUnitZeroHandling);
			_writer.WriteBitShort((short)dimStyle.AlternateUnitToleranceZeroHandling);
			_writer.WriteBit(dimStyle.CursorUpdate);
			_writer.WriteBitShort(3);
		}
		if (R2007Plus)
		{
			_writer.WriteBit(dimStyle.IsExtensionLineLengthFixed);
		}
		if (R2010Plus)
		{
			_writer.WriteBit(dimStyle.TextDirection == TextDirection.RightToLeft);
			_writer.WriteBitDouble(dimStyle.AltMzf);
			_writer.WriteVariableText(dimStyle.AltMzs);
			_writer.WriteBitDouble(dimStyle.Mzf);
			_writer.WriteVariableText(dimStyle.Mzs);
		}
		if (R2000Plus)
		{
			_writer.WriteBitShort((short)dimStyle.DimensionLineWeight);
			_writer.WriteBitShort((short)dimStyle.ExtensionLineWeight);
		}
		_writer.WriteBit(value: false);
		_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		_writer.HandleReference(DwgReferenceType.HardPointer, dimStyle.Style);
		if (R2000Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, dimStyle.LeaderArrow);
			_writer.HandleReference(DwgReferenceType.HardPointer, dimStyle.ArrowBlock);
			_writer.HandleReference(DwgReferenceType.HardPointer, dimStyle.DimArrow1);
			_writer.HandleReference(DwgReferenceType.HardPointer, dimStyle.DimArrow2);
		}
		if (R2007Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, dimStyle.LineType);
			_writer.HandleReference(DwgReferenceType.HardPointer, dimStyle.LineTypeExt1);
			_writer.HandleReference(DwgReferenceType.HardPointer, dimStyle.LineTypeExt2);
		}
		registerObject(dimStyle);
	}

	private void writeVPort(VPort vport)
	{
		writeCommonNonEntityData(vport);
		_writer.WriteVariableText(vport.Name);
		writeXrefDependantBit(vport);
		_writer.WriteBitDouble(vport.ViewHeight);
		_writer.WriteBitDouble(vport.AspectRatio * vport.ViewHeight);
		_writer.Write2RawDouble(vport.Center);
		_writer.Write3BitDouble(vport.Target);
		_writer.Write3BitDouble(vport.Direction);
		_writer.WriteBitDouble(vport.TwistAngle);
		_writer.WriteBitDouble(vport.LensLength);
		_writer.WriteBitDouble(vport.FrontClippingPlane);
		_writer.WriteBitDouble(vport.BackClippingPlane);
		_writer.WriteBit(vport.ViewMode.HasFlag(ViewModeType.PerspectiveView));
		_writer.WriteBit(vport.ViewMode.HasFlag(ViewModeType.FrontClipping));
		_writer.WriteBit(vport.ViewMode.HasFlag(ViewModeType.BackClipping));
		_writer.WriteBit(vport.ViewMode.HasFlag(ViewModeType.FrontClippingZ));
		if (R2000Plus)
		{
			_writer.WriteByte((byte)vport.RenderMode);
		}
		if (R2007Plus)
		{
			_writer.WriteBit(vport.UseDefaultLighting);
			_writer.WriteByte((byte)vport.DefaultLighting);
			_writer.WriteBitDouble(vport.Brightness);
			_writer.WriteBitDouble(vport.Contrast);
			_writer.WriteCmColor(vport.AmbientColor);
		}
		_writer.Write2RawDouble(vport.BottomLeft);
		_writer.Write2RawDouble(vport.TopRight);
		_writer.WriteBit(vport.ViewMode.HasFlag(ViewModeType.Follow));
		_writer.WriteBitShort(vport.CircleZoomPercent);
		_writer.WriteBit(value: true);
		_writer.WriteBit(vport.UcsIconDisplay.HasFlag(UscIconType.OnLower));
		_writer.WriteBit(vport.UcsIconDisplay.HasFlag(UscIconType.OnOrigin));
		_writer.WriteBit(vport.ShowGrid);
		_writer.Write2RawDouble(vport.GridSpacing);
		_writer.WriteBit(vport.SnapOn);
		_writer.WriteBit(vport.IsometricSnap);
		_writer.WriteBitShort(vport.SnapIsoPair);
		_writer.WriteBitDouble(vport.SnapRotation);
		_writer.Write2RawDouble(vport.SnapBasePoint);
		_writer.Write2RawDouble(vport.SnapSpacing);
		if (R2000Plus)
		{
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: true);
			_writer.Write3BitDouble(vport.Origin);
			_writer.Write3BitDouble(vport.XAxis);
			_writer.Write3BitDouble(vport.YAxis);
			_writer.WriteBitDouble(vport.Elevation);
			_writer.WriteBitShort((short)vport.OrthographicType);
		}
		if (R2007Plus)
		{
			_writer.WriteBitShort((short)vport.GridFlags);
			_writer.WriteBitShort(vport.MinorGridLinesPerMajorGridLine);
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
		if (R2007Plus)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, 0uL);
			_writer.HandleReference(DwgReferenceType.SoftPointer, 0uL);
			_writer.HandleReference(DwgReferenceType.SoftPointer, 0uL);
		}
		if (R2000Plus)
		{
			if (vport.OrthographicType == OrthographicType.None)
			{
				_writer.HandleReference(DwgReferenceType.HardPointer, vport.NamedUcs);
				_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
			}
			else
			{
				_writer.HandleReference(DwgReferenceType.HardPointer, 0uL);
				_writer.HandleReference(DwgReferenceType.HardPointer, vport.BaseUcs);
			}
		}
		registerObject(vport);
	}

	private void writeEntity(Entity entity)
	{
		List<Entity> list = new List<Entity>();
		Seqend seqend = null;
		writeCommonEntityData(entity);
		if (!(entity is Arc arc))
		{
			if (!(entity is Circle circle))
			{
				if (!(entity is Dimension dimension))
				{
					if (!(entity is Ellipse ellipse))
					{
						if (!(entity is Insert insert))
						{
							if (!(entity is Face3D face))
							{
								if (!(entity is Hatch hatch))
								{
									if (!(entity is Leader leader))
									{
										if (!(entity is Line line))
										{
											if (!(entity is LwPolyline lwPolyline))
											{
												if (!(entity is Mesh mesh))
												{
													if (!(entity is MLine mline))
													{
														if (!(entity is MText mtext))
														{
															if (!(entity is MultiLeader multiLeader))
															{
																if (!(entity is Ole2Frame ole2Frame))
																{
																	if (!(entity is PdfUnderlay underlay))
																	{
																		if (!(entity is Point point))
																		{
																			if (!(entity is IPolyline polyline))
																			{
																				if (!(entity is Ray ray))
																				{
																					if (!(entity is Shape shape))
																					{
																						if (!(entity is Solid solid))
																						{
																							if (!(entity is Solid3D solid2))
																							{
																								if (!(entity is Spline spline))
																								{
																									if (!(entity is CadWipeoutBase image))
																									{
																										if (!(entity is TextEntity textEntity))
																										{
																											if (!(entity is Tolerance tolerance))
																											{
																												if (!(entity is Vertex vertex))
																												{
																													if (!(entity is Viewport viewport))
																													{
																														if (!(entity is XLine xline))
																														{
																															throw new NotImplementedException("Entity not implemented : " + entity.GetType().FullName);
																														}
																														writeXLine(xline);
																													}
																													else
																													{
																														writeViewport(viewport);
																													}
																												}
																												else if (!(vertex is Vertex2D vertex2))
																												{
																													if (!(vertex is VertexFaceRecord face2))
																													{
																														if (!(vertex is Vertex3D) && !(vertex is VertexFaceMesh))
																														{
																															throw new NotImplementedException("Vertex not implemented : " + entity.GetType().FullName);
																														}
																														writeVertex(vertex);
																													}
																													else
																													{
																														writeFaceRecord(face2);
																													}
																												}
																												else
																												{
																													writeVertex2D(vertex2);
																												}
																											}
																											else
																											{
																												writeTolerance(tolerance);
																											}
																										}
																										else if (!(textEntity is AttributeEntity att))
																										{
																											if (!(textEntity is AttributeDefinition attdef))
																											{
																												if (textEntity == null)
																												{
																													throw new NotImplementedException("TextEntity not implemented : " + entity.GetType().FullName);
																												}
																												TextEntity text = textEntity;
																												writeTextEntity(text);
																											}
																											else
																											{
																												writeAttDefinition(attdef);
																											}
																										}
																										else
																										{
																											writeAttribute(att);
																										}
																									}
																									else
																									{
																										writeCadImage(image);
																									}
																								}
																								else
																								{
																									writeSpline(spline);
																								}
																							}
																							else
																							{
																								writeSolid3D(solid2);
																							}
																						}
																						else
																						{
																							writeSolid(solid);
																						}
																					}
																					else
																					{
																						writeShape(shape);
																					}
																				}
																				else
																				{
																					writeRay(ray);
																				}
																			}
																			else if (!(polyline is PolyfaceMesh polyfaceMesh))
																			{
																				if (!(polyline is Polyline2D polyline2D))
																				{
																					if (!(polyline is Polyline3D polyline3D))
																					{
																						throw new NotImplementedException("Polyline not implemented : " + entity.GetType().FullName);
																					}
																					writePolyline3D(polyline3D);
																					list.AddRange(polyline3D.Vertices);
																					seqend = polyline3D.Vertices.Seqend;
																				}
																				else
																				{
																					writePolyline2D(polyline2D);
																					list.AddRange(polyline2D.Vertices);
																					seqend = polyline2D.Vertices.Seqend;
																				}
																			}
																			else
																			{
																				writePolyfaceMesh(polyfaceMesh);
																				list.AddRange(polyfaceMesh.Faces);
																				list.AddRange(polyfaceMesh.Vertices);
																				seqend = polyfaceMesh.Vertices.Seqend;
																			}
																		}
																		else
																		{
																			writePoint(point);
																		}
																	}
																	else
																	{
																		writePdfUnderlay(underlay);
																	}
																}
																else
																{
																	writeOle2Frame(ole2Frame);
																}
															}
															else
															{
																writeMultiLeader(multiLeader);
															}
														}
														else
														{
															writeMText(mtext);
														}
													}
													else
													{
														writeMLine(mline);
													}
												}
												else
												{
													writeMesh(mesh);
												}
											}
											else
											{
												writeLwPolyline(lwPolyline);
											}
										}
										else
										{
											writeLine(line);
										}
									}
									else
									{
										writeLeader(leader);
									}
								}
								else
								{
									writeHatch(hatch);
								}
							}
							else
							{
								writeFace3D(face);
							}
						}
						else
						{
							writeInsert(insert);
							list.AddRange(insert.Attributes);
							seqend = insert.Attributes.Seqend;
						}
					}
					else
					{
						writeEllipse(ellipse);
					}
				}
				else
				{
					writeCommonDimensionData(dimension);
					if (!(dimension is DimensionLinear dimension2))
					{
						if (!(dimension is DimensionAligned dimension3))
						{
							if (!(dimension is DimensionRadius dimension4))
							{
								if (!(dimension is DimensionAngular2Line dimension5))
								{
									if (!(dimension is DimensionAngular3Pt dimension6))
									{
										if (!(dimension is DimensionDiameter dimension7))
										{
											if (!(dimension is DimensionOrdinate dimension8))
											{
												throw new NotImplementedException("Dimension not implemented : " + entity.GetType().FullName);
											}
											writeDimensionOrdinate(dimension8);
										}
										else
										{
											writeDimensionDiameter(dimension7);
										}
									}
									else
									{
										writeDimensionAngular3Pt(dimension6);
									}
								}
								else
								{
									writeDimensionAngular2Line(dimension5);
								}
							}
							else
							{
								writeDimensionRadius(dimension4);
							}
						}
						else
						{
							writeDimensionAligned(dimension3);
						}
					}
					else
					{
						writeDimensionLinear(dimension2);
					}
				}
			}
			else
			{
				writeCircle(circle);
			}
		}
		else
		{
			writeArc(arc);
		}
		registerObject(entity);
		writeChildEntities(list, seqend);
	}

	private void writePdfUnderlay(PdfUnderlay underlay)
	{
		_writer.Write3BitDouble(underlay.Normal);
		_writer.Write3BitDouble(underlay.InsertPoint);
		_writer.WriteBitDouble(underlay.Rotation);
		_writer.WriteBitDouble(underlay.XScale);
		_writer.WriteBitDouble(underlay.YScale);
		_writer.WriteBitDouble(underlay.ZScale);
		_writer.WriteByte((byte)underlay.Flags);
		_writer.WriteByte(underlay.Contrast);
		_writer.WriteByte(underlay.Fade);
		_writer.HandleReference(DwgReferenceType.HardPointer, underlay.Definition);
		_writer.WriteBitLong(underlay.ClipBoundaryVertices.Count);
		foreach (XY clipBoundaryVertex in underlay.ClipBoundaryVertices)
		{
			_writer.Write2RawDouble(clipBoundaryVertex);
		}
	}

	private void writeArc(Arc arc)
	{
		writeCircle(arc);
		_writer.WriteBitDouble(arc.StartAngle);
		_writer.WriteBitDouble(arc.EndAngle);
	}

	private void writeAttribute(AttributeEntity att)
	{
		writeCommonAttData(att);
	}

	private void writeAttDefinition(AttributeDefinition attdef)
	{
		writeCommonAttData(attdef);
		if (R2010Plus)
		{
			_writer.WriteByte(attdef.Version);
		}
		_writer.WriteVariableText(attdef.Prompt);
	}

	private void writeCommonAttData(AttributeBase att)
	{
		writeTextEntity(att);
		if (R2010Plus)
		{
			_writer.WriteByte(att.Version);
		}
		if (R2018Plus)
		{
			_writer.WriteByte((byte)att.AttributeType);
			if (att.AttributeType == AttributeType.MultiLine || att.AttributeType == AttributeType.ConstantMultiLine)
			{
				writeEntityMode(att.MText);
				writeMText(att.MText);
				_writer.WriteBitShort(0);
			}
		}
		_writer.WriteVariableText(att.Tag);
		_writer.WriteBitShort(0);
		_writer.WriteByte((byte)att.Flags);
		if (R2007Plus)
		{
			_writer.WriteBit(att.IsReallyLocked);
		}
	}

	private void writeCircle(Circle circle)
	{
		_writer.Write3BitDouble(circle.Center);
		_writer.WriteBitDouble(circle.Radius);
		_writer.WriteBitThickness(circle.Thickness);
		_writer.WriteBitExtrusion(circle.Normal);
	}

	private void writeCommonDimensionData(Dimension dimension)
	{
		if (R2010Plus)
		{
			_writer.WriteByte(dimension.Version);
		}
		_writer.Write3BitDouble(dimension.Normal);
		_writer.Write2RawDouble((XY)dimension.TextMiddlePoint);
		_writer.WriteBitDouble(dimension.InsertionPoint.Z);
		byte b = 0;
		b = (byte)((uint)b | ((!dimension.IsTextUserDefinedLocation) ? 1u : 0u));
		_writer.WriteByte(b);
		_writer.WriteVariableText(dimension.Text);
		_writer.WriteBitDouble(dimension.TextRotation);
		_writer.WriteBitDouble(dimension.HorizontalDirection);
		_writer.Write3BitDouble(new XYZ(1.0));
		_writer.WriteBitDouble(0.0);
		if (R2000Plus)
		{
			_writer.WriteBitShort((short)dimension.AttachmentPoint);
			_writer.WriteBitShort((short)dimension.LineSpacingStyle);
			_writer.WriteBitDouble(dimension.LineSpacingFactor);
			_writer.WriteBitDouble(dimension.Measurement);
		}
		if (R2007Plus)
		{
			_writer.WriteBit(value: false);
			_writer.WriteBit(dimension.FlipArrow1);
			_writer.WriteBit(dimension.FlipArrow2);
		}
		_writer.Write2RawDouble((XY)dimension.InsertionPoint);
		_writer.HandleReference(DwgReferenceType.HardPointer, dimension.Style);
		_writer.HandleReference(DwgReferenceType.HardPointer, dimension.Block);
	}

	private void writeDimensionLinear(DimensionLinear dimension)
	{
		writeDimensionAligned(dimension);
		_writer.WriteBitDouble(dimension.Rotation);
	}

	private void writeDimensionAligned(DimensionAligned dimension)
	{
		_writer.Write3BitDouble(dimension.FirstPoint);
		_writer.Write3BitDouble(dimension.SecondPoint);
		_writer.Write3BitDouble(dimension.DefinitionPoint);
		_writer.WriteBitDouble(dimension.ExtLineRotation);
	}

	private void writeDimensionRadius(DimensionRadius dimension)
	{
		_writer.Write3BitDouble(dimension.DefinitionPoint);
		_writer.Write3BitDouble(dimension.AngleVertex);
		_writer.WriteBitDouble(dimension.LeaderLength);
	}

	private void writeDimensionAngular2Line(DimensionAngular2Line dimension)
	{
		_writer.Write2RawDouble((XY)dimension.DimensionArc);
		_writer.Write3BitDouble(dimension.FirstPoint);
		_writer.Write3BitDouble(dimension.SecondPoint);
		_writer.Write3BitDouble(dimension.AngleVertex);
		_writer.Write3BitDouble(dimension.DefinitionPoint);
	}

	private void writeDimensionAngular3Pt(DimensionAngular3Pt dimension)
	{
		_writer.Write3BitDouble(dimension.DefinitionPoint);
		_writer.Write3BitDouble(dimension.FirstPoint);
		_writer.Write3BitDouble(dimension.SecondPoint);
		_writer.Write3BitDouble(dimension.AngleVertex);
	}

	private void writeDimensionDiameter(DimensionDiameter dimension)
	{
		_writer.Write3BitDouble(dimension.DefinitionPoint);
		_writer.Write3BitDouble(dimension.AngleVertex);
		_writer.WriteBitDouble(dimension.LeaderLength);
	}

	private void writeDimensionOrdinate(DimensionOrdinate dimension)
	{
		_writer.Write3BitDouble(dimension.DefinitionPoint);
		_writer.Write3BitDouble(dimension.FeatureLocation);
		_writer.Write3BitDouble(dimension.LeaderEndpoint);
		byte value = (dimension.IsOrdinateTypeX ? ((byte)1) : ((byte)0));
		_writer.WriteByte(value);
	}

	private void writeEllipse(Ellipse ellipse)
	{
		_writer.Write3BitDouble(ellipse.Center);
		_writer.Write3BitDouble(ellipse.MajorAxisEndPoint);
		_writer.Write3BitDouble(ellipse.Normal);
		_writer.WriteBitDouble(ellipse.RadiusRatio);
		_writer.WriteBitDouble(ellipse.StartParameter);
		_writer.WriteBitDouble(ellipse.EndParameter);
	}

	private void writeInsert(Insert insert)
	{
		_writer.Write3BitDouble(insert.InsertPoint);
		if (R13_14Only)
		{
			_writer.WriteBitDouble(insert.XScale);
			_writer.WriteBitDouble(insert.YScale);
			_writer.WriteBitDouble(insert.ZScale);
		}
		if (R2000Plus)
		{
			if (insert.XScale == 1.0 && insert.YScale == 1.0 && insert.ZScale == 1.0)
			{
				_writer.Write2Bits(3);
			}
			else if (insert.XScale == insert.YScale && insert.XScale == insert.ZScale)
			{
				_writer.Write2Bits(2);
				_writer.WriteRawDouble(insert.XScale);
			}
			else if (insert.XScale == 1.0)
			{
				_writer.Write2Bits(1);
				_writer.WriteBitDoubleWithDefault(insert.YScale, 1.0);
				_writer.WriteBitDoubleWithDefault(insert.ZScale, 1.0);
			}
			else
			{
				_writer.Write2Bits(0);
				_writer.WriteRawDouble(insert.XScale);
				_writer.WriteBitDoubleWithDefault(insert.YScale, insert.XScale);
				_writer.WriteBitDoubleWithDefault(insert.ZScale, insert.XScale);
			}
		}
		_writer.WriteBitDouble(insert.Rotation);
		_writer.Write3BitDouble(insert.Normal);
		_writer.WriteBit(insert.HasAttributes);
		if (R2004Plus && insert.HasAttributes)
		{
			_writer.WriteBitLong(insert.Attributes.Count);
		}
		if (insert.IsMultiple)
		{
			_writer.WriteBitShort((short)insert.ColumnCount);
			_writer.WriteBitShort((short)insert.RowCount);
			_writer.WriteBitDouble(insert.ColumnSpacing);
			_writer.WriteBitDouble(insert.RowSpacing);
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, insert.Block);
		if (!insert.HasAttributes)
		{
			return;
		}
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, insert.Attributes.First());
			_writer.HandleReference(DwgReferenceType.SoftPointer, insert.Attributes.Last());
		}
		else if (R2004Plus)
		{
			foreach (AttributeEntity attribute in insert.Attributes)
			{
				_writer.HandleReference(DwgReferenceType.HardOwnership, attribute);
			}
		}
		_writer.HandleReference(DwgReferenceType.HardOwnership, insert.Attributes.Seqend);
	}

	private void writeFace3D(Face3D face)
	{
		if (R13_14Only)
		{
			_writer.Write3BitDouble(face.FirstCorner);
			_writer.Write3BitDouble(face.SecondCorner);
			_writer.Write3BitDouble(face.ThirdCorner);
			_writer.Write3BitDouble(face.FourthCorner);
			_writer.WriteBitShort((short)face.Flags);
		}
		if (R2000Plus)
		{
			bool flag = face.Flags == InvisibleEdgeFlags.None;
			_writer.WriteBit(flag);
			bool flag2 = face.FirstCorner.Z == 0.0;
			_writer.WriteBit(flag2);
			_writer.WriteRawDouble(face.FirstCorner.X);
			_writer.WriteRawDouble(face.FirstCorner.Y);
			if (!flag2)
			{
				_writer.WriteRawDouble(face.FirstCorner.Z);
			}
			_writer.Write3BitDoubleWithDefault(face.SecondCorner, face.FirstCorner);
			_writer.Write3BitDoubleWithDefault(face.ThirdCorner, face.SecondCorner);
			_writer.Write3BitDoubleWithDefault(face.FourthCorner, face.ThirdCorner);
			if (!flag)
			{
				_writer.WriteBitShort((short)face.Flags);
			}
		}
	}

	private void writeMesh(Mesh mesh)
	{
		_writer.WriteBitShort(mesh.Version);
		_writer.WriteBit(mesh.BlendCrease);
		_writer.WriteBitLong(mesh.SubdivisionLevel);
		_writer.WriteBitLong(mesh.Vertices.Count);
		foreach (XYZ vertex in mesh.Vertices)
		{
			_writer.Write3BitDouble(vertex);
		}
		int value = mesh.Faces.Sum((int[] f) => 1 + f.Length);
		_writer.WriteBitLong(value);
		foreach (int[] face in mesh.Faces)
		{
			_writer.WriteBitLong(face.Length);
			int[] array = face;
			foreach (int value2 in array)
			{
				_writer.WriteBitLong(value2);
			}
		}
		_writer.WriteBitLong(mesh.Edges.Count);
		foreach (Mesh.Edge edge in mesh.Edges)
		{
			_writer.WriteBitLong(edge.Start);
			_writer.WriteBitLong(edge.End);
		}
		_writer.WriteBitLong(mesh.Edges.Count);
		foreach (Mesh.Edge edge2 in mesh.Edges)
		{
			if (edge2.Crease.HasValue)
			{
				_writer.WriteBitDouble(edge2.Crease.Value);
			}
			else
			{
				_writer.WriteBitDouble(0.0);
			}
		}
		_writer.WriteBitLong(0);
	}

	private void writeMLine(MLine mline)
	{
		_writer.WriteBitDouble(mline.ScaleFactor);
		_writer.WriteByte((byte)mline.Justification);
		_writer.Write3BitDouble(mline.StartPoint);
		_writer.Write3BitDouble(mline.Normal);
		_writer.WriteBitShort((short)((!mline.Flags.HasFlag(MLineFlags.Closed)) ? 1 : 3));
		int num = 0;
		if (mline.Vertices.Count > 0)
		{
			num = mline.Vertices.First().Segments.Count;
		}
		_writer.WriteByte((byte)num);
		_writer.WriteBitShort((short)mline.Vertices.Count);
		foreach (MLine.Vertex vertex in mline.Vertices)
		{
			_writer.Write3BitDouble(vertex.Position);
			_writer.Write3BitDouble(vertex.Direction);
			_writer.Write3BitDouble(vertex.Miter);
			for (int i = 0; i < num; i++)
			{
				MLine.Vertex.Segment segment = vertex.Segments[i];
				_writer.WriteBitShort((short)segment.Parameters.Count);
				foreach (double parameter in segment.Parameters)
				{
					_writer.WriteBitDouble(parameter);
				}
				_writer.WriteBitShort((short)segment.AreaFillParameters.Count);
				foreach (double areaFillParameter in segment.AreaFillParameters)
				{
					_writer.WriteBitDouble(areaFillParameter);
				}
			}
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, mline.Style);
	}

	private void writeLwPolyline(LwPolyline lwPolyline)
	{
		bool flag = false;
		bool flag2 = false;
		foreach (LwPolyline.Vertex vertex3 in lwPolyline.Vertices)
		{
			if (!flag && vertex3.Bulge != 0.0)
			{
				flag = true;
			}
			if (!flag2 && (vertex3.StartWidth != 0.0 || vertex3.EndWidth != 0.0))
			{
				flag2 = true;
			}
		}
		short num = 0;
		if (lwPolyline.Flags.HasFlag(LwPolylineFlags.Plinegen))
		{
			num |= 0x100;
		}
		if (lwPolyline.Flags.HasFlag(LwPolylineFlags.Closed))
		{
			num |= 0x200;
		}
		if (lwPolyline.ConstantWidth != 0.0)
		{
			num |= 4;
		}
		if (lwPolyline.Elevation != 0.0)
		{
			num |= 8;
		}
		if (lwPolyline.Thickness != 0.0)
		{
			num |= 2;
		}
		if (lwPolyline.Normal != XYZ.AxisZ)
		{
			num |= 1;
		}
		if (flag)
		{
			num |= 0x10;
		}
		if (flag2)
		{
			num |= 0x20;
		}
		_writer.WriteBitShort(num);
		if (lwPolyline.ConstantWidth != 0.0)
		{
			_writer.WriteBitDouble(lwPolyline.ConstantWidth);
		}
		if (lwPolyline.Elevation != 0.0)
		{
			_writer.WriteBitDouble(lwPolyline.Elevation);
		}
		if (lwPolyline.Thickness != 0.0)
		{
			_writer.WriteBitDouble(lwPolyline.Thickness);
		}
		if (lwPolyline.Normal != XYZ.AxisZ)
		{
			_writer.Write3BitDouble(lwPolyline.Normal);
		}
		_writer.WriteBitLong(lwPolyline.Vertices.Count);
		if (flag)
		{
			_writer.WriteBitLong(lwPolyline.Vertices.Count);
		}
		if (flag2)
		{
			_writer.WriteBitLong(lwPolyline.Vertices.Count);
		}
		if (R13_14Only)
		{
			for (int i = 0; i < lwPolyline.Vertices.Count; i++)
			{
				_writer.Write2RawDouble(lwPolyline.Vertices[i].Location);
			}
		}
		if (R2000Plus && lwPolyline.Vertices.Count > 0)
		{
			LwPolyline.Vertex vertex = lwPolyline.Vertices[0];
			_writer.Write2RawDouble(vertex.Location);
			for (int j = 1; j < lwPolyline.Vertices.Count; j++)
			{
				LwPolyline.Vertex vertex2 = lwPolyline.Vertices[j];
				_writer.Write2BitDoubleWithDefault(vertex2.Location, vertex.Location);
				vertex = vertex2;
			}
		}
		if (flag)
		{
			for (int k = 0; k < lwPolyline.Vertices.Count; k++)
			{
				_writer.WriteBitDouble(lwPolyline.Vertices[k].Bulge);
			}
		}
		if (flag2)
		{
			for (int l = 0; l < lwPolyline.Vertices.Count; l++)
			{
				_writer.WriteBitDouble(lwPolyline.Vertices[l].StartWidth);
				_writer.WriteBitDouble(lwPolyline.Vertices[l].EndWidth);
			}
		}
	}

	private void writeHatch(Hatch hatch)
	{
		if (R2004Plus)
		{
			HatchGradientPattern gradientColor = hatch.GradientColor;
			_writer.WriteBitLong(gradientColor.Enabled ? 1 : 0);
			_writer.WriteBitLong(gradientColor.Reserved);
			_writer.WriteBitDouble(gradientColor.Angle);
			_writer.WriteBitDouble(gradientColor.Shift);
			_writer.WriteBitLong(gradientColor.IsSingleColorGradient ? 1 : 0);
			_writer.WriteBitDouble(gradientColor.ColorTint);
			_writer.WriteBitLong(gradientColor.Colors.Count);
			foreach (GradientColor color in gradientColor.Colors)
			{
				_writer.WriteBitDouble(color.Value);
				_writer.WriteCmColor(color.Color);
			}
			_writer.WriteVariableText(gradientColor.Name);
		}
		_writer.WriteBitDouble(hatch.Elevation);
		_writer.Write3BitDouble(hatch.Normal);
		_writer.WriteVariableText(hatch.Pattern.Name);
		_writer.WriteBit(hatch.IsSolid);
		_writer.WriteBit(hatch.IsAssociative);
		_writer.WriteBitLong(hatch.Paths.Count);
		bool flag = false;
		foreach (Hatch.BoundaryPath path in hatch.Paths)
		{
			_writer.WriteBitLong((int)path.Flags);
			if (path.Flags.HasFlag(BoundaryPathFlags.Derived))
			{
				flag = true;
			}
			if (path.Flags.HasFlag(BoundaryPathFlags.Polyline))
			{
				Hatch.BoundaryPath.Polyline polyline = path.Edges.First() as Hatch.BoundaryPath.Polyline;
				_writer.WriteBit(polyline.HasBulge);
				_writer.WriteBit(polyline.IsClosed);
				_writer.WriteBitLong(polyline.Vertices.Count);
				for (int i = 0; i < polyline.Vertices.Count; i++)
				{
					XYZ xYZ = polyline.Vertices[i];
					_writer.Write2RawDouble(new XY(xYZ.X, xYZ.Y));
					if (polyline.HasBulge)
					{
						_writer.WriteBitDouble(xYZ.Z);
					}
				}
			}
			else
			{
				_writer.WriteBitLong(path.Edges.Count);
				foreach (Hatch.BoundaryPath.Edge edge in path.Edges)
				{
					_writer.WriteByte((byte)edge.Type);
					if (!(edge is Hatch.BoundaryPath.Line line))
					{
						if (!(edge is Hatch.BoundaryPath.Arc arc))
						{
							if (!(edge is Hatch.BoundaryPath.Ellipse ellipse))
							{
								if (!(edge is Hatch.BoundaryPath.Spline spline))
								{
									throw new ArgumentException("Unrecognized Boundary type: " + path.GetType().FullName);
								}
								_writer.WriteBitLong(spline.Degree);
								_writer.WriteBit(spline.Rational);
								_writer.WriteBit(spline.Periodic);
								_writer.WriteBitLong(spline.Knots.Count);
								_writer.WriteBitLong(spline.ControlPoints.Count);
								foreach (double knot in spline.Knots)
								{
									_writer.WriteBitDouble(knot);
								}
								for (int j = 0; j < spline.ControlPoints.Count; j++)
								{
									_writer.Write2RawDouble((XY)spline.ControlPoints[j]);
									if (spline.Rational)
									{
										_writer.WriteBitDouble(spline.ControlPoints[j].Z);
									}
								}
								if (!R2010Plus)
								{
									continue;
								}
								_writer.WriteBitLong(spline.FitPoints.Count);
								if (!spline.FitPoints.Any())
								{
									continue;
								}
								foreach (XY fitPoint in spline.FitPoints)
								{
									_writer.Write2RawDouble(fitPoint);
								}
								_writer.Write2RawDouble(spline.StartTangent);
								_writer.Write2RawDouble(spline.EndTangent);
							}
							else
							{
								_writer.Write2RawDouble(ellipse.Center);
								_writer.Write2RawDouble(ellipse.MajorAxisEndPoint);
								_writer.WriteBitDouble(ellipse.MinorToMajorRatio);
								_writer.WriteBitDouble(ellipse.StartAngle);
								_writer.WriteBitDouble(ellipse.EndAngle);
								_writer.WriteBit(ellipse.CounterClockWise);
							}
						}
						else
						{
							_writer.Write2RawDouble(arc.Center);
							_writer.WriteBitDouble(arc.Radius);
							_writer.WriteBitDouble(arc.StartAngle);
							_writer.WriteBitDouble(arc.EndAngle);
							_writer.WriteBit(arc.CounterClockWise);
						}
					}
					else
					{
						_writer.Write2RawDouble(line.Start);
						_writer.Write2RawDouble(line.End);
					}
				}
			}
			_writer.WriteBitLong(path.Entities.Count);
			foreach (Entity entity in path.Entities)
			{
				_writer.HandleReference(DwgReferenceType.SoftPointer, entity);
			}
		}
		_writer.WriteBitShort((short)hatch.Style);
		_writer.WriteBitShort((short)hatch.PatternType);
		if (!hatch.IsSolid)
		{
			HatchPattern pattern = hatch.Pattern;
			_writer.WriteBitDouble(hatch.PatternAngle);
			_writer.WriteBitDouble(hatch.PatternScale);
			_writer.WriteBit(hatch.IsDouble);
			_writer.WriteBitShort((short)pattern.Lines.Count);
			foreach (HatchPattern.Line line2 in pattern.Lines)
			{
				_writer.WriteBitDouble(line2.Angle);
				_writer.Write2BitDouble(line2.BasePoint);
				_writer.Write2BitDouble(line2.Offset);
				_writer.WriteBitShort((short)line2.DashLengths.Count);
				foreach (double dashLength in line2.DashLengths)
				{
					_writer.WriteBitDouble(dashLength);
				}
			}
		}
		if (flag)
		{
			_writer.WriteBitDouble(hatch.PixelSize);
		}
		_writer.WriteBitLong(hatch.SeedPoints.Count);
		foreach (XY seedPoint in hatch.SeedPoints)
		{
			_writer.Write2RawDouble(seedPoint);
		}
	}

	private void writeLeader(Leader leader)
	{
		_writer.WriteBit(value: false);
		_writer.WriteBitShort((short)leader.CreationType);
		_writer.WriteBitShort((short)leader.PathType);
		_writer.WriteBitLong(leader.Vertices.Count);
		foreach (XYZ vertex in leader.Vertices)
		{
			_writer.Write3BitDouble(vertex);
		}
		_writer.Write3BitDouble(leader.Vertices.FirstOrDefault());
		_writer.Write3BitDouble(leader.Normal);
		_writer.Write3BitDouble(leader.HorizontalDirection);
		_writer.Write3BitDouble(leader.BlockOffset);
		if (_version >= ACadVersion.AC1014)
		{
			_writer.Write3BitDouble(leader.AnnotationOffset);
		}
		if (R13_14Only)
		{
			_writer.WriteBitDouble(leader.Style.DimensionLineGap);
		}
		if (_version <= ACadVersion.AC1021)
		{
			_writer.WriteBitDouble(leader.TextHeight);
			_writer.WriteBitDouble(leader.TextWidth);
		}
		_writer.WriteBit(leader.HookLineDirection == HookLineDirection.Same);
		_writer.WriteBit(leader.ArrowHeadEnabled);
		if (R13_14Only)
		{
			_writer.WriteBitShort(0);
			_writer.WriteBitDouble(leader.Style.ArrowSize * leader.Style.ScaleFactor);
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
			_writer.WriteBitShort(0);
			_writer.WriteBitShort(0);
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
		}
		if (R2000Plus)
		{
			_writer.WriteBitShort(0);
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, null);
		_writer.HandleReference(DwgReferenceType.HardPointer, leader.Style);
	}

	private void writeOle2Frame(Ole2Frame ole2Frame)
	{
		_writer.WriteBitShort(ole2Frame.Version);
		if (R2000Plus)
		{
			_writer.WriteBitShort(0);
		}
		_writer.WriteBitLong(ole2Frame.BinaryData.Length);
		_writer.WriteBytes(ole2Frame.BinaryData);
		if (R2000Plus)
		{
			_writer.WriteByte(3);
		}
	}

	private void writeMultiLeader(MultiLeader multiLeader)
	{
		if (R2010Plus)
		{
			_writer.WriteBitShort(2);
		}
		writeMultiLeaderAnnotContextSubObject(writeLeaderRootsCount: true, multiLeader.ContextData);
		_writer.HandleReference(DwgReferenceType.HardPointer, multiLeader.Style);
		_writer.WriteBitLong((int)multiLeader.PropertyOverrideFlags);
		_writer.WriteBitShort((short)multiLeader.PathType);
		_writer.WriteCmColor(multiLeader.LineColor);
		_writer.HandleReference(DwgReferenceType.HardPointer, multiLeader.LeaderLineType);
		_writer.WriteBitLong((int)multiLeader.LeaderLineWeight);
		_writer.WriteBit(multiLeader.EnableLanding);
		_writer.WriteBit(multiLeader.EnableDogleg);
		_writer.WriteBitDouble(multiLeader.LandingDistance);
		_writer.HandleReference(DwgReferenceType.HardPointer, multiLeader.Arrowhead);
		_writer.WriteBitDouble(multiLeader.ArrowheadSize);
		_writer.WriteBitShort((short)multiLeader.ContentType);
		_writer.HandleReference(DwgReferenceType.HardPointer, multiLeader.TextStyle);
		_writer.WriteBitShort((short)multiLeader.TextLeftAttachment);
		_writer.WriteBitShort((short)multiLeader.TextRightAttachment);
		_writer.WriteBitShort((short)multiLeader.TextAngle);
		_writer.WriteBitShort((short)multiLeader.TextAlignment);
		_writer.WriteCmColor(multiLeader.TextColor);
		_writer.WriteBit(multiLeader.TextFrame);
		_writer.HandleReference(DwgReferenceType.HardPointer, multiLeader.BlockContent);
		_writer.WriteCmColor(multiLeader.BlockContentColor);
		_writer.Write3BitDouble(multiLeader.BlockContentScale);
		_writer.WriteBitDouble(multiLeader.BlockContentRotation);
		_writer.WriteBitShort((short)multiLeader.BlockContentConnection);
		_writer.WriteBit(multiLeader.EnableAnnotationScale);
		int count = multiLeader.BlockAttributes.Count;
		_writer.WriteBitLong(count);
		for (int i = 0; i < count; i++)
		{
			MultiLeader.BlockAttribute blockAttribute = multiLeader.BlockAttributes[i];
			_writer.HandleReference(DwgReferenceType.HardPointer, blockAttribute.AttributeDefinition);
			_writer.WriteVariableText(blockAttribute.Text);
			_writer.WriteBitShort(blockAttribute.Index);
			_writer.WriteBitDouble(blockAttribute.Width);
		}
		_writer.WriteBit(multiLeader.TextDirectionNegative);
		_writer.WriteBitShort(multiLeader.TextAligninIPE);
		_writer.WriteBitShort((short)multiLeader.TextAttachmentPoint);
		_writer.WriteBitDouble(multiLeader.ScaleFactor);
		if (R2010Plus)
		{
			_writer.WriteBitShort((short)multiLeader.TextAttachmentDirection);
			_writer.WriteBitShort((short)multiLeader.TextBottomAttachment);
			_writer.WriteBitShort((short)multiLeader.TextTopAttachment);
		}
		if (R2013Plus)
		{
			_writer.WriteBit(multiLeader.ExtendedToText);
		}
	}

	private void writeMultiLeaderAnnotContextSubObject(bool writeLeaderRootsCount, MultiLeaderObjectContextData annotContext)
	{
		int count = annotContext.LeaderRoots.Count;
		if (writeLeaderRootsCount)
		{
			_writer.WriteBitLong(count);
		}
		else
		{
			_writer.WriteBitLong(0);
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
			_writer.WriteBit(count == 2);
			_writer.WriteBit(count == 1);
		}
		for (int i = 0; i < count; i++)
		{
			writeLeaderRoot(annotContext.LeaderRoots[i]);
		}
		_writer.WriteBitDouble(annotContext.ScaleFactor);
		_writer.Write3BitDouble(annotContext.ContentBasePoint);
		_writer.WriteBitDouble(annotContext.TextHeight);
		_writer.WriteBitDouble(annotContext.ArrowheadSize);
		_writer.WriteBitDouble(annotContext.LandingGap);
		_writer.WriteBitShort((short)annotContext.TextLeftAttachment);
		_writer.WriteBitShort((short)annotContext.TextRightAttachment);
		_writer.WriteBitShort((short)annotContext.TextAlignment);
		_writer.WriteBitShort((short)annotContext.BlockContentConnection);
		_writer.WriteBit(annotContext.HasTextContents);
		if (annotContext.HasTextContents)
		{
			_writer.WriteVariableText(annotContext.TextLabel);
			_writer.Write3BitDouble(annotContext.TextNormal);
			_writer.HandleReference(DwgReferenceType.HardPointer, annotContext.TextStyle);
			_writer.Write3BitDouble(annotContext.TextLocation);
			_writer.Write3BitDouble(annotContext.Direction);
			_writer.WriteBitDouble(annotContext.TextRotation);
			_writer.WriteBitDouble(annotContext.BoundaryWidth);
			_writer.WriteBitDouble(annotContext.BoundaryHeight);
			_writer.WriteBitDouble(annotContext.LineSpacingFactor);
			_writer.WriteBitShort((short)annotContext.LineSpacing);
			_writer.WriteCmColor(annotContext.TextColor);
			_writer.WriteBitShort((short)annotContext.TextAttachmentPoint);
			_writer.WriteBitShort((short)annotContext.FlowDirection);
			_writer.WriteCmColor(annotContext.BackgroundFillColor);
			_writer.WriteBitDouble(annotContext.BackgroundScaleFactor);
			_writer.WriteBitLong(annotContext.BackgroundTransparency);
			_writer.WriteBit(annotContext.BackgroundFillEnabled);
			_writer.WriteBit(annotContext.BackgroundMaskFillOn);
			_writer.WriteBitShort(annotContext.ColumnType);
			_writer.WriteBit(annotContext.TextHeightAutomatic);
			_writer.WriteBitDouble(annotContext.ColumnWidth);
			_writer.WriteBitDouble(annotContext.ColumnGutter);
			_writer.WriteBit(annotContext.ColumnFlowReversed);
			int count2 = annotContext.ColumnSizes.Count;
			_writer.WriteBitLong(count2);
			for (int j = 0; j < count2; j++)
			{
				_writer.WriteBitDouble(annotContext.ColumnSizes[j]);
			}
			_writer.WriteBit(annotContext.WordBreak);
			_writer.WriteBit(value: false);
		}
		else if (annotContext.HasContentsBlock)
		{
			_writer.WriteBit(annotContext.HasContentsBlock);
			_writer.HandleReference(DwgReferenceType.SoftPointer, annotContext.BlockContent);
			_writer.Write3BitDouble(annotContext.BlockContentNormal);
			_writer.Write3BitDouble(annotContext.BlockContentLocation);
			_writer.Write3BitDouble(annotContext.BlockContentScale);
			_writer.WriteBitDouble(annotContext.BlockContentRotation);
			_writer.WriteCmColor(annotContext.BlockContentColor);
			Matrix4 transformationMatrix = annotContext.TransformationMatrix;
			_writer.WriteBitDouble(transformationMatrix.M00);
			_writer.WriteBitDouble(transformationMatrix.M10);
			_writer.WriteBitDouble(transformationMatrix.M20);
			_writer.WriteBitDouble(transformationMatrix.M30);
			_writer.WriteBitDouble(transformationMatrix.M01);
			_writer.WriteBitDouble(transformationMatrix.M11);
			_writer.WriteBitDouble(transformationMatrix.M21);
			_writer.WriteBitDouble(transformationMatrix.M31);
			_writer.WriteBitDouble(transformationMatrix.M02);
			_writer.WriteBitDouble(transformationMatrix.M12);
			_writer.WriteBitDouble(transformationMatrix.M22);
			_writer.WriteBitDouble(transformationMatrix.M32);
			_writer.WriteBitDouble(transformationMatrix.M03);
			_writer.WriteBitDouble(transformationMatrix.M13);
			_writer.WriteBitDouble(transformationMatrix.M23);
			_writer.WriteBitDouble(transformationMatrix.M33);
		}
		_writer.Write3BitDouble(annotContext.BasePoint);
		_writer.Write3BitDouble(annotContext.BaseDirection);
		_writer.Write3BitDouble(annotContext.BaseVertical);
		_writer.WriteBit(annotContext.NormalReversed);
		if (R2010Plus)
		{
			_writer.WriteBitShort((short)annotContext.TextTopAttachment);
			_writer.WriteBitShort((short)annotContext.TextBottomAttachment);
		}
	}

	private void writeLeaderRoot(MultiLeaderObjectContextData.LeaderRoot leaderRoot)
	{
		_writer.WriteBit(leaderRoot.ContentValid);
		_writer.WriteBit(value: true);
		_writer.Write3BitDouble(leaderRoot.ConnectionPoint);
		_writer.Write3BitDouble(leaderRoot.Direction);
		_writer.WriteBitLong(leaderRoot.BreakStartEndPointsPairs.Count);
		foreach (MultiLeaderObjectContextData.StartEndPointPair breakStartEndPointsPair in leaderRoot.BreakStartEndPointsPairs)
		{
			_writer.Write3BitDouble(breakStartEndPointsPair.StartPoint);
			_writer.Write3BitDouble(breakStartEndPointsPair.EndPoint);
		}
		_writer.WriteBitLong(leaderRoot.LeaderIndex);
		_writer.WriteBitDouble(leaderRoot.LandingDistance);
		_writer.WriteBitLong(leaderRoot.Lines.Count);
		foreach (MultiLeaderObjectContextData.LeaderLine line in leaderRoot.Lines)
		{
			writeLeaderLine(line);
		}
		if (R2010Plus)
		{
			_writer.WriteBitShort((short)leaderRoot.TextAttachmentDirection);
		}
	}

	private void writeLeaderLine(MultiLeaderObjectContextData.LeaderLine leaderLine)
	{
		_writer.WriteBitLong(leaderLine.Points.Count);
		foreach (XYZ point in leaderLine.Points)
		{
			_writer.Write3BitDouble(point);
		}
		_writer.WriteBitLong(leaderLine.BreakInfoCount);
		if (leaderLine.BreakInfoCount > 0)
		{
			_writer.WriteBitLong(leaderLine.SegmentIndex);
			_writer.WriteBitLong(leaderLine.StartEndPoints.Count);
			foreach (MultiLeaderObjectContextData.StartEndPointPair startEndPoint in leaderLine.StartEndPoints)
			{
				_writer.Write3BitDouble(startEndPoint.StartPoint);
				_writer.Write3BitDouble(startEndPoint.EndPoint);
			}
		}
		_writer.WriteBitLong(leaderLine.Index);
		if (R2010Plus)
		{
			_writer.WriteBitShort((short)leaderLine.PathType);
			_writer.WriteCmColor(leaderLine.LineColor);
			_writer.HandleReference(DwgReferenceType.HardPointer, leaderLine.LineType);
			_writer.WriteBitLong((int)leaderLine.LineWeight);
			_writer.WriteBitDouble(leaderLine.ArrowheadSize);
			_writer.HandleReference(DwgReferenceType.HardPointer, leaderLine.Arrowhead);
			_writer.WriteBitLong((short)leaderLine.OverrideFlags);
		}
	}

	private void writeLine(Line line)
	{
		if (R13_14Only)
		{
			_writer.Write3BitDouble(line.StartPoint);
			_writer.Write3BitDouble(line.EndPoint);
		}
		if (R2000Plus)
		{
			bool flag = line.StartPoint.Z == 0.0 && line.EndPoint.Z == 0.0;
			_writer.WriteBit(flag);
			_writer.WriteRawDouble(line.StartPoint.X);
			_writer.WriteBitDoubleWithDefault(line.EndPoint.X, line.StartPoint.X);
			_writer.WriteRawDouble(line.StartPoint.Y);
			_writer.WriteBitDoubleWithDefault(line.EndPoint.Y, line.StartPoint.Y);
			if (!flag)
			{
				_writer.WriteRawDouble(line.StartPoint.Z);
				_writer.WriteBitDoubleWithDefault(line.EndPoint.Z, line.StartPoint.Z);
			}
		}
		_writer.WriteBitThickness(line.Thickness);
		_writer.WriteBitExtrusion(line.Normal);
	}

	private void writePoint(Point point)
	{
		_writer.Write3BitDouble(point.Location);
		_writer.WriteBitThickness(point.Thickness);
		_writer.WriteBitExtrusion(point.Normal);
		_writer.WriteBitDouble(point.Rotation);
	}

	private void writePolyfaceMesh(PolyfaceMesh fm)
	{
		_writer.WriteBitShort((short)fm.Vertices.Count);
		_writer.WriteBitShort((short)fm.Faces.Count);
		if (R2004Plus)
		{
			_writer.WriteBitLong(fm.Vertices.Count + fm.Faces.Count);
			foreach (VertexFaceMesh vertex in fm.Vertices)
			{
				_writer.HandleReference(DwgReferenceType.SoftPointer, vertex);
			}
			foreach (VertexFaceRecord face in fm.Faces)
			{
				_writer.HandleReference(DwgReferenceType.SoftPointer, face);
			}
		}
		if (R13_15Only)
		{
			List<CadObject> list = new List<CadObject>(fm.Vertices);
			list.AddRange(fm.Faces);
			CadObject cadObject = list.FirstOrDefault();
			CadObject cadObject2 = list.LastOrDefault();
			_writer.HandleReference(DwgReferenceType.SoftPointer, cadObject);
			_writer.HandleReference(DwgReferenceType.SoftPointer, cadObject2);
		}
		_writer.HandleReference(DwgReferenceType.SoftPointer, fm.Vertices.Seqend);
	}

	private void writePolyline2D(Polyline2D pline)
	{
		_writer.WriteBitShort((short)pline.Flags);
		_writer.WriteBitShort((short)pline.SmoothSurface);
		_writer.WriteBitDouble(pline.StartWidth);
		_writer.WriteBitDouble(pline.EndWidth);
		_writer.WriteBitThickness(pline.Thickness);
		_writer.WriteBitDouble(pline.Elevation);
		_writer.WriteBitExtrusion(pline.Normal);
		if (R2004Plus)
		{
			_writer.WriteBitLong(pline.Vertices.Count);
			foreach (Vertex2D vertex in pline.Vertices)
			{
				_writer.HandleReference(DwgReferenceType.HardOwnership, vertex);
			}
		}
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, pline.Vertices.FirstOrDefault());
			_writer.HandleReference(DwgReferenceType.SoftPointer, pline.Vertices.LastOrDefault());
		}
		_writer.HandleReference(DwgReferenceType.HardOwnership, pline.Vertices.Seqend);
	}

	private void writePolyline3D(Polyline3D pline)
	{
		_writer.WriteByte(0);
		_writer.WriteByte(pline.Flags.HasFlag(PolylineFlags.ClosedPolylineOrClosedPolygonMeshInM) ? ((byte)1) : ((byte)0));
		if (R2004Plus)
		{
			_writer.WriteBitLong(pline.Vertices.Count);
			foreach (Vertex3D vertex in pline.Vertices)
			{
				_writer.HandleReference(DwgReferenceType.HardOwnership, vertex);
			}
		}
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, pline.Vertices.FirstOrDefault());
			_writer.HandleReference(DwgReferenceType.SoftPointer, pline.Vertices.LastOrDefault());
		}
		_writer.HandleReference(DwgReferenceType.HardOwnership, pline.Vertices.Seqend);
	}

	private void writeSeqend(Seqend seqend)
	{
		if (seqend != null)
		{
			Entity prev = _prev;
			Entity next = _next;
			_prev = null;
			_next = null;
			writeCommonEntityData(seqend);
			registerObject(seqend);
			_prev = prev;
			_next = next;
		}
	}

	private void writeShape(Shape shape)
	{
		_writer.Write3BitDouble(shape.InsertionPoint);
		_writer.WriteBitDouble(shape.Size);
		_writer.WriteBitDouble(shape.Rotation);
		_writer.WriteBitDouble(shape.RelativeXScale);
		_writer.WriteBitDouble(shape.ObliqueAngle);
		_writer.WriteBitDouble(shape.Thickness);
		_writer.WriteBitShort((short)shape.ShapeIndex);
		_writer.Write3BitDouble(shape.Normal);
		_writer.HandleReference(DwgReferenceType.HardPointer, null);
	}

	private void writeSolid(Solid solid)
	{
		_writer.WriteBitThickness(solid.Thickness);
		_writer.WriteBitDouble(solid.FirstCorner.Z);
		_writer.WriteRawDouble(solid.FirstCorner.X);
		_writer.WriteRawDouble(solid.FirstCorner.Y);
		_writer.WriteRawDouble(solid.SecondCorner.X);
		_writer.WriteRawDouble(solid.SecondCorner.Y);
		_writer.WriteRawDouble(solid.ThirdCorner.X);
		_writer.WriteRawDouble(solid.ThirdCorner.Y);
		_writer.WriteRawDouble(solid.FourthCorner.X);
		_writer.WriteRawDouble(solid.FourthCorner.Y);
		_writer.WriteBitExtrusion(solid.Normal);
	}

	private void writeSolid3D(Solid3D solid)
	{
	}

	private void writeCadImage(CadWipeoutBase image)
	{
		_writer.WriteBitLong(image.ClassVersion);
		_writer.Write3BitDouble(image.InsertPoint);
		_writer.Write3BitDouble(image.UVector);
		_writer.Write3BitDouble(image.VVector);
		_writer.Write2RawDouble(image.Size);
		_writer.WriteBitShort((short)image.Flags);
		_writer.WriteBit(image.ClippingState);
		_writer.WriteByte(image.Brightness);
		_writer.WriteByte(image.Contrast);
		_writer.WriteByte(image.Fade);
		if (R2010Plus)
		{
			_writer.WriteBit(image.ClipMode == ClipMode.Inside);
		}
		_writer.WriteBitShort((short)image.ClipType);
		switch (image.ClipType)
		{
		case ClipType.Rectangular:
			_writer.Write2RawDouble(image.ClipBoundaryVertices[0]);
			_writer.Write2RawDouble(image.ClipBoundaryVertices[1]);
			break;
		case ClipType.Polygonal:
		{
			_writer.WriteBitLong(image.ClipBoundaryVertices.Count);
			for (int i = 0; i < image.ClipBoundaryVertices.Count; i++)
			{
				_writer.Write2RawDouble(image.ClipBoundaryVertices[i]);
			}
			break;
		}
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, image.Definition);
		_writer.HandleReference(image.DefinitionReactor);
		if (image.DefinitionReactor != null)
		{
			_objects.Enqueue(image.DefinitionReactor);
		}
	}

	private void writeSpline(Spline spline)
	{
		int num;
		if (R2013Plus)
		{
			if (spline.KnotParametrization == KnotParametrization.Custom || spline.FitPoints.Count == 0)
			{
				num = 1;
				spline.Flags1 &= ~SplineFlags1.UseKnotParameter;
			}
			else
			{
				num = 2;
				spline.Flags1 |= SplineFlags1.MethodFitPoints | SplineFlags1.UseKnotParameter;
			}
			_writer.WriteBitLong(num);
			_writer.WriteBitLong((int)spline.Flags1);
			_writer.WriteBitLong((int)spline.KnotParametrization);
		}
		else
		{
			num = ((spline.FitPoints.Count <= 0) ? 1 : 2);
			if (num == 2 && spline.KnotParametrization != KnotParametrization.Chord)
			{
				num = 1;
			}
			_writer.WriteBitLong(num);
		}
		_writer.WriteBitLong(spline.Degree);
		bool flag = spline.Weights.Count > 0;
		switch (num)
		{
		case 1:
		{
			_writer.WriteBit(spline.Flags.HasFlag(SplineFlags.Rational));
			_writer.WriteBit(spline.Flags.HasFlag(SplineFlags.Closed));
			_writer.WriteBit(spline.Flags.HasFlag(SplineFlags.Periodic));
			_writer.WriteBitDouble(spline.KnotTolerance);
			_writer.WriteBitDouble(spline.ControlPointTolerance);
			_writer.WriteBitLong(spline.Knots.Count);
			_writer.WriteBitLong(spline.ControlPoints.Count);
			_writer.WriteBit(flag);
			foreach (double knot in spline.Knots)
			{
				_writer.WriteBitDouble(knot);
			}
			for (int i = 0; i < spline.ControlPoints.Count; i++)
			{
				_writer.Write3BitDouble(spline.ControlPoints[i]);
				if (flag)
				{
					_writer.WriteBitDouble(spline.Weights[i]);
				}
			}
			break;
		}
		case 2:
			_writer.WriteBitDouble(spline.FitTolerance);
			_writer.Write3BitDouble(spline.StartTangent);
			_writer.Write3BitDouble(spline.EndTangent);
			_writer.WriteBitLong(spline.FitPoints.Count);
			{
				foreach (XYZ fitPoint in spline.FitPoints)
				{
					_writer.Write3BitDouble(fitPoint);
				}
				break;
			}
		}
	}

	private void writeRay(Ray ray)
	{
		_writer.Write3BitDouble(ray.StartPoint);
		_writer.Write3BitDouble(ray.Direction);
	}

	private void writeTextEntity(TextEntity text)
	{
		if (R13_14Only)
		{
			_writer.WriteBitDouble(text.InsertPoint.Z);
			_writer.WriteRawDouble(text.InsertPoint.X);
			_writer.WriteRawDouble(text.InsertPoint.Y);
			_writer.WriteRawDouble(text.AlignmentPoint.X);
			_writer.WriteRawDouble(text.AlignmentPoint.Y);
			_writer.Write3BitDouble(text.Normal);
			_writer.WriteBitDouble(text.Thickness);
			_writer.WriteBitDouble(text.ObliqueAngle);
			_writer.WriteBitDouble(text.Rotation);
			_writer.WriteBitDouble(text.Height);
			_writer.WriteBitDouble(text.WidthFactor);
			_writer.WriteVariableText(text.Value);
			_writer.WriteBitShort((short)text.Mirror);
			_writer.WriteBitShort((short)text.HorizontalAlignment);
			_writer.WriteBitShort((short)text.VerticalAlignment);
		}
		else
		{
			byte b = 0;
			if (text.InsertPoint.Z == 0.0)
			{
				b |= 1;
			}
			if (text.AlignmentPoint == XYZ.Zero)
			{
				b |= 2;
			}
			if (text.ObliqueAngle == 0.0)
			{
				b |= 4;
			}
			if (text.Rotation == 0.0)
			{
				b |= 8;
			}
			if (text.WidthFactor == 1.0)
			{
				b |= 0x10;
			}
			if (text.Mirror == TextMirrorFlag.None)
			{
				b |= 0x20;
			}
			if (text.HorizontalAlignment == TextHorizontalAlignment.Left)
			{
				b |= 0x40;
			}
			if (text.VerticalAlignment == TextVerticalAlignmentType.Baseline)
			{
				b |= 0x80;
			}
			_writer.WriteByte(b);
			if ((b & 1) == 0)
			{
				_writer.WriteRawDouble(text.InsertPoint.Z);
			}
			_writer.WriteRawDouble(text.InsertPoint.X);
			_writer.WriteRawDouble(text.InsertPoint.Y);
			if ((b & 2) == 0)
			{
				_writer.WriteBitDoubleWithDefault(text.AlignmentPoint.X, text.InsertPoint.X);
				_writer.WriteBitDoubleWithDefault(text.AlignmentPoint.Y, text.InsertPoint.Y);
			}
			_writer.WriteBitExtrusion(text.Normal);
			_writer.WriteBitThickness(text.Thickness);
			if ((b & 4) == 0)
			{
				_writer.WriteRawDouble(text.ObliqueAngle);
			}
			if ((b & 8) == 0)
			{
				_writer.WriteRawDouble(text.Rotation);
			}
			_writer.WriteRawDouble(text.Height);
			if ((b & 0x10) == 0)
			{
				_writer.WriteRawDouble(text.WidthFactor);
			}
			_writer.WriteVariableText(text.Value);
			if ((b & 0x20) == 0)
			{
				_writer.WriteBitShort((short)text.Mirror);
			}
			if ((b & 0x40) == 0)
			{
				_writer.WriteBitShort((short)text.HorizontalAlignment);
			}
			if ((b & 0x80) == 0)
			{
				_writer.WriteBitShort((short)text.VerticalAlignment);
			}
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, text.Style);
	}

	private void writeMText(MText mtext)
	{
		_writer.Write3BitDouble(mtext.InsertPoint);
		_writer.Write3BitDouble(mtext.Normal);
		_writer.Write3BitDouble(mtext.AlignmentPoint);
		_writer.WriteBitDouble(mtext.RectangleWidth);
		if (R2007Plus)
		{
			_writer.WriteBitDouble(mtext.RectangleHeight);
		}
		_writer.WriteBitDouble(mtext.Height);
		_writer.WriteBitShort((short)mtext.AttachmentPoint);
		_writer.WriteBitShort((short)mtext.DrawingDirection);
		_writer.WriteBitDouble(0.0);
		_writer.WriteBitDouble(0.0);
		_writer.WriteVariableText(mtext.Value);
		_writer.HandleReference(DwgReferenceType.HardPointer, mtext.Style);
		if (R2000Plus)
		{
			_writer.WriteBitShort((short)mtext.LineSpacingStyle);
			_writer.WriteBitDouble(mtext.LineSpacing);
			_writer.WriteBit(value: false);
		}
		if (R2004Plus)
		{
			_writer.WriteBitLong((int)mtext.BackgroundFillFlags);
			if ((mtext.BackgroundFillFlags & BackgroundFillFlags.UseBackgroundFillColor) != BackgroundFillFlags.None || (_version > ACadVersion.AC1027 && (int)(mtext.BackgroundFillFlags & BackgroundFillFlags.TextFrame) > 0))
			{
				_writer.WriteBitDouble(mtext.BackgroundScale);
				_writer.WriteCmColor(mtext.BackgroundColor);
				_writer.WriteBitLong(mtext.BackgroundTransparency.Value);
			}
		}
		if (!R2018Plus)
		{
			return;
		}
		_writer.WriteBit(!mtext.IsAnnotative);
		if (mtext.IsAnnotative)
		{
			return;
		}
		_writer.WriteBitShort(4);
		_writer.WriteBit(value: true);
		_writer.HandleReference(DwgReferenceType.HardPointer, null);
		_writer.WriteBitLong((int)mtext.AttachmentPoint);
		_writer.Write3BitDouble(mtext.AlignmentPoint);
		_writer.Write3BitDouble(mtext.InsertPoint);
		_writer.WriteBitDouble(mtext.RectangleWidth);
		_writer.WriteBitDouble(mtext.RectangleHeight);
		_writer.WriteBitDouble(mtext.HorizontalWidth);
		_writer.WriteBitDouble(mtext.VerticalHeight);
		_writer.WriteBitShort((short)mtext.Column.ColumnType);
		if (mtext.Column.ColumnType == ColumnType.NoColumns)
		{
			return;
		}
		_writer.WriteBitLong(mtext.Column.ColumnCount);
		_writer.WriteBitDouble(mtext.Column.ColumnWidth);
		_writer.WriteBitDouble(mtext.Column.ColumnGutter);
		_writer.WriteBit(mtext.Column.ColumnAutoHeight);
		_writer.WriteBit(mtext.Column.ColumnFlowReversed);
		if (mtext.Column.ColumnAutoHeight || mtext.Column.ColumnType != ColumnType.DynamicColumns)
		{
			return;
		}
		foreach (double columnHeight in mtext.Column.ColumnHeights)
		{
			_writer.WriteBitDouble(columnHeight);
		}
	}

	private void writeFaceRecord(VertexFaceRecord face)
	{
		_writer.WriteBitShort(face.Index1);
		_writer.WriteBitShort(face.Index2);
		_writer.WriteBitShort(face.Index3);
		_writer.WriteBitShort(face.Index4);
	}

	private void writeVertex2D(Vertex2D vertex)
	{
		_writer.WriteByte((byte)vertex.Flags);
		_writer.WriteBitDouble(vertex.Location.X);
		_writer.WriteBitDouble(vertex.Location.Y);
		_writer.WriteBitDouble(0.0);
		if (vertex.StartWidth != 0.0 && vertex.EndWidth == vertex.StartWidth)
		{
			_writer.WriteBitDouble(0.0 - vertex.StartWidth);
		}
		else
		{
			_writer.WriteBitDouble(vertex.StartWidth);
			_writer.WriteBitDouble(vertex.EndWidth);
		}
		_writer.WriteBitDouble(vertex.Bulge);
		if (R2010Plus)
		{
			_writer.WriteBitLong(vertex.Id);
		}
		_writer.WriteBitDouble(vertex.CurveTangent);
	}

	private void writeVertex(Vertex vertex)
	{
		_writer.WriteByte((byte)vertex.Flags);
		_writer.Write3BitDouble(vertex.Location);
	}

	private void writeTolerance(Tolerance tolerance)
	{
		if (R13_14Only)
		{
			_writer.WriteBitShort(0);
			_writer.WriteBitDouble(0.0);
			_writer.WriteBitDouble(0.0);
		}
		_writer.Write3BitDouble(tolerance.InsertionPoint);
		_writer.Write3BitDouble(tolerance.Direction);
		_writer.Write3BitDouble(tolerance.Normal);
		_writer.WriteVariableText(tolerance.Text);
		_writer.HandleReference(DwgReferenceType.HardPointer, tolerance.Style);
	}

	private void writeViewport(Viewport viewport)
	{
		_writer.Write3BitDouble(viewport.Center);
		_writer.WriteBitDouble(viewport.Width);
		_writer.WriteBitDouble(viewport.Height);
		if (R2000Plus)
		{
			_writer.Write3BitDouble(viewport.ViewTarget);
			_writer.Write3BitDouble(viewport.ViewDirection);
			_writer.WriteBitDouble(viewport.TwistAngle);
			_writer.WriteBitDouble(viewport.ViewHeight);
			_writer.WriteBitDouble(viewport.LensLength);
			_writer.WriteBitDouble(viewport.FrontClipPlane);
			_writer.WriteBitDouble(viewport.BackClipPlane);
			_writer.WriteBitDouble(viewport.SnapAngle);
			_writer.Write2RawDouble(viewport.ViewCenter);
			_writer.Write2RawDouble(viewport.SnapBase);
			_writer.Write2RawDouble(viewport.SnapSpacing);
			_writer.Write2RawDouble(viewport.GridSpacing);
			_writer.WriteBitShort(viewport.CircleZoomPercent);
		}
		if (R2007Plus)
		{
			_writer.WriteBitShort(viewport.MajorGridLineFrequency);
		}
		if (R2000Plus)
		{
			_writer.WriteBitLong(viewport.FrozenLayers.Count);
			_writer.WriteBitLong((int)viewport.Status);
			_writer.WriteVariableText(string.Empty);
			_writer.WriteByte((byte)viewport.RenderMode);
			_writer.WriteBit(viewport.DisplayUcsIcon);
			_writer.WriteBit(viewport.UcsPerViewport);
			_writer.Write3BitDouble(viewport.UcsOrigin);
			_writer.Write3BitDouble(viewport.UcsXAxis);
			_writer.Write3BitDouble(viewport.UcsYAxis);
			_writer.WriteBitDouble(viewport.Elevation);
			_writer.WriteBitShort((short)viewport.UcsOrthographicType);
		}
		if (R2004Plus)
		{
			_writer.WriteBitShort((short)viewport.ShadePlotMode);
		}
		if (R2007Plus)
		{
			_writer.WriteBit(viewport.UseDefaultLighting);
			_writer.WriteByte((byte)viewport.DefaultLightingType);
			_writer.WriteBitDouble(viewport.Brightness);
			_writer.WriteBitDouble(viewport.Contrast);
			_writer.WriteCmColor(viewport.AmbientLightColor);
		}
		if (R13_14Only)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		if (R2000Plus)
		{
			foreach (Layer frozenLayer in viewport.FrozenLayers)
			{
				if (R2004Plus)
				{
					_writer.HandleReference(DwgReferenceType.SoftPointer, frozenLayer);
				}
				else
				{
					_writer.HandleReference(DwgReferenceType.HardPointer, frozenLayer);
				}
			}
			_writer.HandleReference(DwgReferenceType.HardPointer, viewport.Boundary);
		}
		if (_version == ACadVersion.AC1015)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		if (R2000Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		if (R2007Plus)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.SoftPointer, null);
			_writer.HandleReference(DwgReferenceType.HardOwnership, null);
		}
	}

	private void writeXLine(XLine xline)
	{
		_writer.Write3BitDouble(xline.FirstPoint);
		_writer.Write3BitDouble(xline.Direction);
	}

	private void writeChildEntities(IEnumerable<Entity> entities, Seqend seqend)
	{
		if (entities.Any())
		{
			Entity prev = _prev;
			Entity next = _next;
			_prev = null;
			_next = null;
			Entity entity = entities.First();
			for (int i = 1; i < entities.Count(); i++)
			{
				_next = entities.ElementAt(i);
				writeEntity(entity);
				_prev = entity;
				entity = _next;
			}
			_next = null;
			writeEntity(entity);
			_prev = prev;
			_next = next;
			if (seqend != null)
			{
				writeSeqend(seqend);
			}
		}
	}

	private void writeObjects()
	{
		while (_objects.Any())
		{
			NonGraphicalObject obj = _objects.Dequeue();
			writeObject(obj);
		}
	}

	private void writeObject(NonGraphicalObject obj)
	{
		if (skipEntry(obj, out var flag))
		{
			if (flag)
			{
				notify("Object type not implemented " + obj.GetType().FullName, NotificationType.NotImplemented);
			}
			return;
		}
		writeCommonNonEntityData(obj);
		if (!(obj is AcdbPlaceHolder acdbPlaceHolder))
		{
			if (!(obj is BookColor color))
			{
				if (!(obj is CadDictionaryWithDefault dictionary))
				{
					if (!(obj is CadDictionary dictionary2))
					{
						if (!(obj is DictionaryVariable dictionaryVariable))
						{
							if (!(obj is GeoData geodata))
							{
								if (!(obj is Group obj2))
								{
									if (!(obj is ImageDefinitionReactor definitionReactor))
									{
										if (!(obj is ImageDefinition definition))
										{
											if (!(obj is Layout layout))
											{
												if (!(obj is MLineStyle mlineStyle))
												{
													if (!(obj is MultiLeaderStyle mLeaderStyle))
													{
														if (!(obj is MultiLeaderObjectContextData multiLeaderObjectContextData))
														{
															if (!(obj is PdfUnderlayDefinition definition2))
															{
																if (!(obj is PlotSettings plot))
																{
																	if (!(obj is RasterVariables vars))
																	{
																		if (!(obj is Scale scale))
																		{
																			if (!(obj is SortEntitiesTable sortEntitiesTable))
																			{
																				if (!(obj is SpatialFilter filter))
																				{
																					if (!(obj is XRecord xrecord))
																					{
																						throw new NotImplementedException("Object not implemented : " + obj.GetType().FullName);
																					}
																					writeXRecord(xrecord);
																				}
																				else
																				{
																					writeSpatialFilter(filter);
																				}
																			}
																			else
																			{
																				writeSortEntitiesTable(sortEntitiesTable);
																			}
																		}
																		else
																		{
																			writeScale(scale);
																		}
																	}
																	else
																	{
																		writeRasterVariables(vars);
																	}
																}
																else
																{
																	writePlotSettings(plot);
																}
															}
															else
															{
																writePdfDefinition(definition2);
															}
														}
														else
														{
															writeObjectContextData(multiLeaderObjectContextData);
															writeAnnotScaleObjectContextData(multiLeaderObjectContextData);
															writeMultiLeaderAnnotContext(multiLeaderObjectContextData);
														}
													}
													else
													{
														writeMultiLeaderStyle(mLeaderStyle);
													}
												}
												else
												{
													writeMLineStyle(mlineStyle);
												}
											}
											else
											{
												writeLayout(layout);
											}
										}
										else
										{
											writeImageDefinition(definition);
										}
									}
									else
									{
										writeImageDefinitionReactor(definitionReactor);
									}
								}
								else
								{
									writeGroup(obj2);
								}
							}
							else
							{
								writeGeoData(geodata);
							}
						}
						else
						{
							writeDictionaryVariable(dictionaryVariable);
						}
					}
					else
					{
						writeDictionary(dictionary2);
					}
				}
				else
				{
					writeCadDictionaryWithDefault(dictionary);
				}
			}
			else
			{
				writeBookColor(color);
			}
		}
		else
		{
			writeAcdbPlaceHolder(acdbPlaceHolder);
		}
		registerObject(obj);
	}

	private void writeAcdbPlaceHolder(AcdbPlaceHolder acdbPlaceHolder)
	{
	}

	private void writeBookColor(BookColor color)
	{
		_writer.WriteBitShort(0);
		if (R2004Plus)
		{
			byte[] bytes = new byte[4]
			{
				color.Color.B,
				color.Color.G,
				color.Color.R,
				194
			};
			uint value = LittleEndianConverter.Instance.ToUInt32(bytes);
			_writer.WriteBitLong((int)value);
			byte b = 0;
			if (!string.IsNullOrEmpty(color.Name))
			{
				b |= 1;
			}
			if (!string.IsNullOrEmpty(color.BookName))
			{
				b |= 2;
			}
			_writer.WriteByte(b);
			if (!string.IsNullOrEmpty(color.ColorName))
			{
				_writer.WriteVariableText(color.ColorName);
			}
			if (!string.IsNullOrEmpty(color.BookName))
			{
				_writer.WriteVariableText(color.BookName);
			}
		}
	}

	private void writeCadDictionaryWithDefault(CadDictionaryWithDefault dictionary)
	{
		writeDictionary(dictionary);
		_writer.HandleReference(DwgReferenceType.HardPointer, dictionary.DefaultEntry);
	}

	private void writeDictionary(CadDictionary dictionary)
	{
		List<NonGraphicalObject> list = new List<NonGraphicalObject>();
		foreach (NonGraphicalObject item in dictionary)
		{
			if (!skipEntry(item))
			{
				list.Add(item);
			}
		}
		_writer.WriteBitLong(list.Count);
		if (_version == ACadVersion.AC1014)
		{
			_writer.WriteByte(0);
		}
		if (R2000Plus)
		{
			_writer.WriteBitShort((short)dictionary.ClonningFlags);
			_writer.WriteByte(dictionary.HardOwnerFlag ? ((byte)1) : ((byte)0));
		}
		foreach (NonGraphicalObject item2 in list)
		{
			if (!skipEntry(item2))
			{
				_writer.WriteVariableText(item2.Name);
				_writer.HandleReference(DwgReferenceType.SoftOwnership, item2.Handle);
			}
		}
		addEntriesToWriter(dictionary);
	}

	private bool skipEntry(NonGraphicalObject entry)
	{
		bool flag;
		return skipEntry(entry, out flag);
	}

	private bool skipEntry(NonGraphicalObject entry, out bool notify)
	{
		notify = true;
		if (!(entry is XRecord))
		{
			if (entry is EvaluationGraph || entry is Material || entry is UnknownNonGraphicalObject || entry is VisualStyle || entry is ProxyObject)
			{
				return true;
			}
		}
		else if (!WriteXRecords)
		{
			notify = false;
			return true;
		}
		return false;
	}

	private void addEntriesToWriter(CadDictionary dictionary)
	{
		foreach (NonGraphicalObject item in dictionary)
		{
			_objects.Enqueue(item);
		}
	}

	private void writeDictionaryVariable(DictionaryVariable dictionaryVariable)
	{
		_writer.WriteByte(0);
		_writer.WriteVariableText(dictionaryVariable.Value);
	}

	private void writeGeoData(GeoData geodata)
	{
		_writer.WriteBitLong((int)geodata.Version);
		_writer.HandleReference(DwgReferenceType.SoftPointer, geodata.HostBlock);
		_writer.WriteBitShort((short)geodata.CoordinatesType);
		switch (geodata.Version)
		{
		case GeoDataVersion.R2009:
			_writer.Write3BitDouble(geodata.ReferencePoint);
			_writer.WriteBitLong((int)geodata.HorizontalUnits);
			_writer.Write3BitDouble(geodata.DesignPoint);
			_writer.Write3BitDouble(XYZ.Zero);
			_writer.Write3BitDouble(geodata.UpDirection);
			_writer.WriteBitDouble(Math.PI / 2.0 - geodata.NorthDirection.GetAngle());
			_writer.Write3BitDouble(new XYZ(1.0, 1.0, 1.0));
			_writer.WriteVariableText(geodata.CoordinateSystemDefinition);
			_writer.WriteVariableText(geodata.GeoRssTag);
			_writer.WriteBitDouble(geodata.HorizontalUnitScale);
			geodata.VerticalUnitScale = geodata.HorizontalUnitScale;
			_writer.WriteVariableText(string.Empty);
			_writer.WriteVariableText(string.Empty);
			break;
		case GeoDataVersion.R2010:
		case GeoDataVersion.R2013:
			_writer.Write3BitDouble(geodata.DesignPoint);
			_writer.Write3BitDouble(geodata.ReferencePoint);
			_writer.WriteBitDouble(geodata.HorizontalUnitScale);
			_writer.WriteBitLong((int)geodata.HorizontalUnits);
			_writer.WriteBitDouble(geodata.VerticalUnitScale);
			_writer.WriteBitLong((int)geodata.HorizontalUnits);
			_writer.Write3BitDouble(geodata.UpDirection);
			_writer.Write2RawDouble(geodata.NorthDirection);
			_writer.WriteBitLong((int)geodata.ScaleEstimationMethod);
			_writer.WriteBitDouble(geodata.UserSpecifiedScaleFactor);
			_writer.WriteBit(geodata.EnableSeaLevelCorrection);
			_writer.WriteBitDouble(geodata.SeaLevelElevation);
			_writer.WriteBitDouble(geodata.CoordinateProjectionRadius);
			_writer.WriteVariableText(geodata.CoordinateSystemDefinition);
			_writer.WriteVariableText(geodata.GeoRssTag);
			break;
		}
		_writer.WriteVariableText(geodata.ObservationFromTag);
		_writer.WriteVariableText(geodata.ObservationToTag);
		_writer.WriteVariableText(geodata.ObservationCoverageTag);
		_writer.WriteBitLong(geodata.Points.Count);
		foreach (GeoData.GeoMeshPoint point in geodata.Points)
		{
			_writer.Write2RawDouble(point.Source);
			_writer.Write2RawDouble(point.Destination);
		}
		_writer.WriteBitLong(geodata.Faces.Count);
		foreach (GeoData.GeoMeshFace face in geodata.Faces)
		{
			_writer.WriteBitLong(face.Index1);
			_writer.WriteBitLong(face.Index2);
			_writer.WriteBitLong(face.Index3);
		}
	}

	private void writeGroup(Group group)
	{
		_writer.WriteVariableText(group.Description);
		_writer.WriteBitShort(group.IsUnnamed ? ((short)1) : ((short)0));
		_writer.WriteBitShort(group.Selectable ? ((short)1) : ((short)0));
		_writer.WriteBitLong(group.Entities.Count());
		foreach (Entity entity in group.Entities)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, entity);
		}
	}

	private void writeImageDefinitionReactor(ImageDefinitionReactor definitionReactor)
	{
		_writer.WriteBitLong(definitionReactor.ClassVersion);
	}

	private void writePdfDefinition(PdfUnderlayDefinition definition)
	{
		_writer.WriteVariableText(definition.File);
		_writer.WriteVariableText(definition.Page);
	}

	private void writeImageDefinition(ImageDefinition definition)
	{
		_writer.WriteBitLong(definition.ClassVersion);
		_writer.Write2RawDouble(definition.Size);
		_writer.WriteVariableText(definition.FileName);
		_writer.WriteBit(definition.IsLoaded);
		_writer.WriteByte((byte)definition.Units);
		_writer.Write2RawDouble(definition.DefaultSize);
	}

	private void writeLayout(Layout layout)
	{
		writePlotSettings(layout);
		_writer.WriteVariableText(layout.Name);
		_writer.WriteBitLong(layout.TabOrder);
		_writer.WriteBitShort((short)layout.LayoutFlags);
		_writer.Write3BitDouble(layout.Origin);
		_writer.Write2RawDouble(layout.MinLimits);
		_writer.Write2RawDouble(layout.MinLimits);
		_writer.Write3BitDouble(layout.InsertionBasePoint);
		_writer.Write3BitDouble(layout.XAxis);
		_writer.Write3BitDouble(layout.YAxis);
		_writer.WriteBitDouble(layout.Elevation);
		_writer.WriteBitShort((short)layout.UcsOrthographicType);
		_writer.Write3BitDouble(layout.MinExtents);
		_writer.Write3BitDouble(layout.MaxExtents);
		if (R2004Plus)
		{
			_writer.WriteBitLong(layout.Viewports.Count());
		}
		_writer.HandleReference(DwgReferenceType.SoftPointer, layout.AssociatedBlock);
		_writer.HandleReference(DwgReferenceType.SoftPointer, layout.Viewport);
		if (layout.UcsOrthographicType == OrthographicType.None)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, layout.UCS);
		}
		else
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, layout.BaseUCS);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		if (!R2004Plus)
		{
			return;
		}
		foreach (Viewport viewport in layout.Viewports)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, viewport);
		}
	}

	private void writeMLineStyle(MLineStyle mlineStyle)
	{
		_writer.WriteVariableText(mlineStyle.Name);
		_writer.WriteVariableText(mlineStyle.Description);
		short num = 0;
		if (mlineStyle.Flags.HasFlag(MLineStyleFlags.DisplayJoints))
		{
			num = (short)((long)num | 1L);
		}
		if (mlineStyle.Flags.HasFlag(MLineStyleFlags.FillOn))
		{
			num = (short)((long)num | 2L);
		}
		if (mlineStyle.Flags.HasFlag(MLineStyleFlags.StartSquareCap))
		{
			num = (short)((long)num | 0x10L);
		}
		if (mlineStyle.Flags.HasFlag(MLineStyleFlags.StartRoundCap))
		{
			num |= 0x20;
		}
		if (mlineStyle.Flags.HasFlag(MLineStyleFlags.StartInnerArcsCap))
		{
			num |= 0x40;
		}
		if (mlineStyle.Flags.HasFlag(MLineStyleFlags.EndSquareCap))
		{
			num |= 0x100;
		}
		if (mlineStyle.Flags.HasFlag(MLineStyleFlags.EndRoundCap))
		{
			num |= 0x200;
		}
		if (mlineStyle.Flags.HasFlag(MLineStyleFlags.EndInnerArcsCap))
		{
			num |= 0x400;
		}
		_writer.WriteBitShort(num);
		_writer.WriteCmColor(mlineStyle.FillColor);
		_writer.WriteBitDouble(mlineStyle.StartAngle);
		_writer.WriteBitDouble(mlineStyle.EndAngle);
		_writer.WriteByte((byte)mlineStyle.Elements.Count());
		foreach (MLineStyle.Element element in mlineStyle.Elements)
		{
			_writer.WriteBitDouble(element.Offset);
			_writer.WriteCmColor(element.Color);
			if (R2018Plus)
			{
				_writer.HandleReference(DwgReferenceType.HardPointer, element.LineType);
			}
			else
			{
				_writer.WriteBitShort(0);
			}
		}
	}

	private void writeMultiLeaderStyle(MultiLeaderStyle mLeaderStyle)
	{
		if (R2010Plus)
		{
			_writer.WriteBitShort(2);
		}
		_writer.WriteBitShort((short)mLeaderStyle.ContentType);
		_writer.WriteBitShort((short)mLeaderStyle.MultiLeaderDrawOrder);
		_writer.WriteBitShort((short)mLeaderStyle.LeaderDrawOrder);
		_writer.WriteBitLong((short)mLeaderStyle.MaxLeaderSegmentsPoints);
		_writer.WriteBitDouble(mLeaderStyle.FirstSegmentAngleConstraint);
		_writer.WriteBitDouble(mLeaderStyle.SecondSegmentAngleConstraint);
		_writer.WriteBitShort((short)mLeaderStyle.PathType);
		_writer.WriteCmColor(mLeaderStyle.LineColor);
		_writer.HandleReference(DwgReferenceType.HardPointer, mLeaderStyle.LeaderLineType);
		_writer.WriteBitLong((int)mLeaderStyle.LeaderLineWeight);
		_writer.WriteBit(mLeaderStyle.EnableLanding);
		_writer.WriteBitDouble(mLeaderStyle.LandingGap);
		_writer.WriteBit(mLeaderStyle.EnableDogleg);
		_writer.WriteBitDouble(mLeaderStyle.LandingDistance);
		_writer.WriteVariableText(mLeaderStyle.Description);
		_writer.HandleReference(DwgReferenceType.HardPointer, mLeaderStyle.Arrowhead);
		_writer.WriteBitDouble(mLeaderStyle.ArrowheadSize);
		_writer.WriteVariableText(mLeaderStyle.DefaultTextContents);
		_writer.HandleReference(DwgReferenceType.HardPointer, mLeaderStyle.TextStyle);
		_writer.WriteBitShort((short)mLeaderStyle.TextLeftAttachment);
		_writer.WriteBitShort((short)mLeaderStyle.TextRightAttachment);
		_writer.WriteBitShort((short)mLeaderStyle.TextAngle);
		_writer.WriteBitShort((short)mLeaderStyle.TextAlignment);
		_writer.WriteCmColor(mLeaderStyle.TextColor);
		_writer.WriteBitDouble(mLeaderStyle.TextHeight);
		_writer.WriteBit(mLeaderStyle.TextFrame);
		_writer.WriteBit(mLeaderStyle.TextAlignAlwaysLeft);
		_writer.WriteBitDouble(mLeaderStyle.AlignSpace);
		_writer.HandleReference(DwgReferenceType.HardPointer, mLeaderStyle.BlockContent);
		_writer.WriteCmColor(mLeaderStyle.BlockContentColor);
		_writer.Write3BitDouble(mLeaderStyle.BlockContentScale);
		_writer.WriteBit(mLeaderStyle.EnableBlockContentScale);
		_writer.WriteBitDouble(mLeaderStyle.BlockContentRotation);
		_writer.WriteBit(mLeaderStyle.EnableBlockContentRotation);
		_writer.WriteBitShort((short)mLeaderStyle.BlockContentConnection);
		_writer.WriteBitDouble(mLeaderStyle.ScaleFactor);
		_writer.WriteBit(mLeaderStyle.OverwritePropertyValue);
		_writer.WriteBit(mLeaderStyle.IsAnnotative);
		_writer.WriteBitDouble(mLeaderStyle.BreakGapSize);
		if (R2010Plus)
		{
			_writer.WriteBitShort((short)mLeaderStyle.TextAttachmentDirection);
			_writer.WriteBitShort((short)mLeaderStyle.TextBottomAttachment);
			_writer.WriteBitShort((short)mLeaderStyle.TextTopAttachment);
		}
		if (R2013Plus)
		{
			_writer.WriteBit(mLeaderStyle.UnknownFlag298);
		}
	}

	private void writeObjectContextData(ObjectContextData objectContextData)
	{
		_writer.WriteBitShort(objectContextData.Version);
		_writer.WriteBit(objectContextData.HasFileToExtensionDictionary);
		_writer.WriteBit(objectContextData.Default);
	}

	private void writeAnnotScaleObjectContextData(AnnotScaleObjectContextData annotScaleObjectContextData)
	{
		_writer.HandleReference(DwgReferenceType.HardPointer, annotScaleObjectContextData.Scale);
	}

	private void writeMultiLeaderAnnotContext(MultiLeaderObjectContextData multiLeaderAnnotContext)
	{
		writeMultiLeaderAnnotContextSubObject(writeLeaderRootsCount: false, multiLeaderAnnotContext);
	}

	private void writePlotSettings(PlotSettings plot)
	{
		_writer.WriteVariableText(plot.PageName);
		_writer.WriteVariableText(plot.SystemPrinterName);
		_writer.WriteBitShort((short)plot.Flags);
		_writer.WriteBitDouble(plot.UnprintableMargin.Left);
		_writer.WriteBitDouble(plot.UnprintableMargin.Bottom);
		_writer.WriteBitDouble(plot.UnprintableMargin.Right);
		_writer.WriteBitDouble(plot.UnprintableMargin.Top);
		_writer.WriteBitDouble(plot.PaperWidth);
		_writer.WriteBitDouble(plot.PaperHeight);
		_writer.WriteVariableText(plot.PaperSize);
		_writer.WriteBitDouble(plot.PlotOriginX);
		_writer.WriteBitDouble(plot.PlotOriginY);
		_writer.WriteBitShort((short)plot.PaperUnits);
		_writer.WriteBitShort((short)plot.PaperRotation);
		_writer.WriteBitShort((short)plot.PlotType);
		_writer.WriteBitDouble(plot.WindowLowerLeftX);
		_writer.WriteBitDouble(plot.WindowLowerLeftY);
		_writer.WriteBitDouble(plot.WindowUpperLeftX);
		_writer.WriteBitDouble(plot.WindowUpperLeftY);
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015)
		{
			_writer.WriteVariableText(plot.PlotViewName);
		}
		_writer.WriteBitDouble(plot.NumeratorScale);
		_writer.WriteBitDouble(plot.DenominatorScale);
		_writer.WriteVariableText(plot.StyleSheet);
		_writer.WriteBitShort((short)plot.ScaledFit);
		_writer.WriteBitDouble(plot.StandardScale);
		_writer.Write2BitDouble(plot.PaperImageOrigin);
		if (R2004Plus)
		{
			_writer.WriteBitShort((short)plot.ShadePlotMode);
			_writer.WriteBitShort((short)plot.ShadePlotResolutionMode);
			_writer.WriteBitShort(plot.ShadePlotDPI);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		if (R2007Plus)
		{
			_writer.HandleReference(DwgReferenceType.SoftPointer, null);
		}
	}

	private void writeRasterVariables(RasterVariables vars)
	{
		_writer.WriteBitLong(vars.ClassVersion);
		_writer.WriteBitShort(vars.IsDisplayFrameShown ? ((short)1) : ((short)0));
		_writer.WriteBitShort((short)vars.DisplayQuality);
		_writer.WriteBitShort((short)vars.Units);
	}

	private void writeScale(Scale scale)
	{
		_writer.WriteBitShort(0);
		_writer.WriteVariableText(scale.Name);
		_writer.WriteBitDouble(scale.PaperUnits);
		_writer.WriteBitDouble(scale.DrawingUnits);
		_writer.WriteBit(scale.IsUnitScale);
	}

	private void writeSpatialFilter(SpatialFilter filter)
	{
		_writer.WriteBitShort((short)filter.BoundaryPoints.Count);
		foreach (XY boundaryPoint in filter.BoundaryPoints)
		{
			_writer.Write2RawDouble(boundaryPoint);
		}
		_writer.Write3BitDouble(filter.Normal);
		_writer.Write3BitDouble(filter.Origin);
		_writer.WriteBitShort(filter.DisplayBoundary ? ((short)1) : ((short)0));
		_writer.WriteBitShort(filter.ClipFrontPlane ? ((short)1) : ((short)0));
		if (filter.ClipFrontPlane)
		{
			_writer.WriteBitDouble(filter.FrontDistance);
		}
		_writer.WriteBitShort(filter.ClipBackPlane ? ((short)1) : ((short)0));
		if (filter.ClipBackPlane)
		{
			_writer.WriteBitDouble(filter.BackDistance);
		}
		write4x3Matrix(filter.InverseInsertTransform);
		write4x3Matrix(filter.InsertTransform);
	}

	private void write4x3Matrix(Matrix4 matrix)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				_writer.WriteBitDouble(matrix[i, j]);
			}
		}
	}

	private void writeSortEntitiesTable(SortEntitiesTable sortEntitiesTable)
	{
		_writer.HandleReference(DwgReferenceType.SoftPointer, sortEntitiesTable.BlockOwner);
		_writer.WriteBitLong(sortEntitiesTable.Count());
		foreach (SortEntitiesTable.Sorter item in sortEntitiesTable)
		{
			_writer.Main.HandleReference(item.SortHandle);
			_writer.HandleReference(DwgReferenceType.SoftPointer, item.Entity);
		}
	}

	private void writeXRecord(XRecord xrecord)
	{
		MemoryStream memoryStream = new MemoryStream();
		StreamIO streamIO = new StreamIO(memoryStream);
		streamIO.EndianConverter = new LittleEndianConverter();
		foreach (XRecord.Entry entry in xrecord.Entries)
		{
			if (entry.Value == null)
			{
				continue;
			}
			streamIO.Write<short, LittleEndianConverter>((short)entry.Code);
			switch (GroupCodeValue.TransformValue(entry.Code))
			{
			case GroupCodeValueType.Byte:
			case GroupCodeValueType.Bool:
				streamIO.Write(Convert.ToByte(entry.Value, CultureInfo.InvariantCulture));
				break;
			case GroupCodeValueType.Int16:
			case GroupCodeValueType.ExtendedDataInt16:
				streamIO.Write(Convert.ToInt16(entry.Value, CultureInfo.InvariantCulture));
				break;
			case GroupCodeValueType.Int32:
			case GroupCodeValueType.ExtendedDataInt32:
				streamIO.Write(Convert.ToInt32(entry.Value, CultureInfo.InvariantCulture));
				break;
			case GroupCodeValueType.Int64:
				streamIO.Write(Convert.ToInt64(entry.Value, CultureInfo.InvariantCulture));
				break;
			case GroupCodeValueType.Double:
			case GroupCodeValueType.ExtendedDataDouble:
			{
				double value2 = (entry.Value as double?).Value;
				streamIO.Write<double, LittleEndianConverter>(value2);
				break;
			}
			case GroupCodeValueType.Point3D:
			{
				XYZ value = (entry.Value as XYZ?).Value;
				streamIO.Write<double, LittleEndianConverter>(value.X);
				streamIO.Write<double, LittleEndianConverter>(value.Y);
				streamIO.Write<double, LittleEndianConverter>(value.Z);
				break;
			}
			case GroupCodeValueType.Chunk:
			case GroupCodeValueType.ExtendedDataChunk:
			{
				byte[] array = (byte[])entry.Value;
				streamIO.Write((byte)array.Length);
				streamIO.WriteBytes(array);
				break;
			}
			case GroupCodeValueType.Handle:
			{
				CadObject reference = entry.GetReference();
				if (reference == null)
				{
					writeStringInStream(streamIO, string.Empty);
				}
				else
				{
					writeStringInStream(streamIO, reference.Handle.ToString("X", CultureInfo.InvariantCulture));
				}
				break;
			}
			case GroupCodeValueType.String:
			case GroupCodeValueType.ExtendedDataString:
			{
				string text = (string)entry.Value;
				writeStringInStream(streamIO, text);
				break;
			}
			case GroupCodeValueType.ObjectId:
			case GroupCodeValueType.ExtendedDataHandle:
				if (entry.GetReference() == null)
				{
					streamIO.Write<ulong, LittleEndianConverter>(0uL);
				}
				else
				{
					streamIO.Write<ulong, LittleEndianConverter>(entry.GetReference().Handle);
				}
				break;
			default:
				throw new NotSupportedException();
			}
		}
		_writer.WriteBitLong((int)streamIO.Length);
		_writer.WriteBytes(memoryStream.GetBuffer(), 0, (int)streamIO.Length);
		if (R2000Plus)
		{
			_writer.WriteBitShort((short)xrecord.CloningFlags);
		}
	}

	private void writeStringInStream(StreamIO ms, string text)
	{
		if (R2007Plus)
		{
			if (string.IsNullOrEmpty(text))
			{
				ms.Write<short, LittleEndianConverter>(0);
				return;
			}
			ms.Write<short, LittleEndianConverter>((short)text.Length);
			ms.Write(text, Encoding.Unicode);
		}
		else if (string.IsNullOrEmpty(text))
		{
			ms.Write<short, LittleEndianConverter>(0);
			ms.Write((byte)CadUtils.GetCodeIndex((CodePage)_writer.Encoding.CodePage));
		}
		else
		{
			ms.Write<short, LittleEndianConverter>((short)text.Length);
			ms.Write((byte)CadUtils.GetCodeIndex((CodePage)_writer.Encoding.CodePage));
			ms.Write(text, _writer.Encoding);
		}
	}
}
