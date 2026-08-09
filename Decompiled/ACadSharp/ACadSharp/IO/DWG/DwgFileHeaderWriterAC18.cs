using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CSUtilities.Converters;
using CSUtilities.IO;
using CSUtilities.Text;

namespace ACadSharp.IO.DWG;

internal class DwgFileHeaderWriterAC18 : DwgFileHeaderWriterBase
{
	private List<DwgLocalSectionMap> _localSectionsMaps = new List<DwgLocalSectionMap>();

	public override int HandleSectionOffset => 0;

	protected override int _fileHeaderSize => 256;

	protected new DwgFileHeaderAC18 _fileHeader { get; } = new DwgFileHeaderAC18();

	protected virtual ICompressor compressor { get; } = new DwgLZ77AC18Compressor();

	private Dictionary<string, DwgSectionDescriptor> _descriptors => _fileHeader.Descriptors;

	public DwgFileHeaderWriterAC18(Stream stream, Encoding encoding, CadDocument document)
		: base(stream, encoding, document)
	{
		for (int i = 0; i < _fileHeaderSize; i++)
		{
			_stream.WriteByte(0);
		}
	}

	public override void WriteFile()
	{
		_fileHeader.SectionArrayPageSize = (uint)(_localSectionsMaps.Count + 2);
		_fileHeader.SectionPageMapId = _fileHeader.SectionArrayPageSize;
		_fileHeader.SectionMapId = _fileHeader.SectionArrayPageSize - 1;
		writeDescriptors();
		writeRecords();
		writeFileMetaData();
	}

	public override void AddSection(string name, MemoryStream stream, bool isCompressed, int decompsize = 29696)
	{
		DwgSectionDescriptor dwgSectionDescriptor = new DwgSectionDescriptor(name);
		_fileHeader.AddSection(dwgSectionDescriptor);
		dwgSectionDescriptor.DecompressedSize = (ulong)decompsize;
		dwgSectionDescriptor.CompressedSize = (ulong)stream.Length;
		dwgSectionDescriptor.CompressedCode = ((!isCompressed) ? 1 : 2);
		int num = (int)(stream.Length / (int)dwgSectionDescriptor.DecompressedSize);
		byte[] buffer = stream.GetBuffer();
		ulong num2 = 0uL;
		for (int i = 0; i < num; i++)
		{
			craeteLocalSection(dwgSectionDescriptor, buffer, (int)dwgSectionDescriptor.DecompressedSize, num2, (int)dwgSectionDescriptor.DecompressedSize, isCompressed);
			num2 += dwgSectionDescriptor.DecompressedSize;
		}
		int num3 = (int)(stream.Length % (int)dwgSectionDescriptor.DecompressedSize);
		if (num3 > 0 && !checkEmptyBytes(buffer, num2, (ulong)num3))
		{
			craeteLocalSection(dwgSectionDescriptor, buffer, (int)dwgSectionDescriptor.DecompressedSize, num2, num3, isCompressed);
		}
	}

	protected virtual void craeteLocalSection(DwgSectionDescriptor descriptor, byte[] buffer, int decompressedSize, ulong offset, int totalSize, bool isCompressed)
	{
		MemoryStream memoryStream = applyCompression(buffer, decompressedSize, offset, totalSize, isCompressed);
		writeMagicNumber();
		long position = _stream.Position;
		DwgLocalSectionMap dwgLocalSectionMap = new DwgLocalSectionMap();
		dwgLocalSectionMap.Offset = offset;
		dwgLocalSectionMap.Seeker = position;
		dwgLocalSectionMap.PageNumber = _localSectionsMaps.Count + 1;
		dwgLocalSectionMap.ODA = DwgCheckSumCalculator.Calculate(0u, memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		int num = DwgCheckSumCalculator.CompressionCalculator((int)memoryStream.Length);
		dwgLocalSectionMap.CompressedSize = (ulong)memoryStream.Length;
		dwgLocalSectionMap.DecompressedSize = (ulong)totalSize;
		dwgLocalSectionMap.PageSize = (long)(dwgLocalSectionMap.CompressedSize + 32) + (long)num;
		dwgLocalSectionMap.Checksum = 0uL;
		MemoryStream memoryStream2 = new MemoryStream(32);
		writeDataSection(memoryStream2, descriptor, dwgLocalSectionMap, (int)descriptor.PageType);
		dwgLocalSectionMap.Checksum = DwgCheckSumCalculator.Calculate(dwgLocalSectionMap.ODA, memoryStream2.GetBuffer(), 0, (int)memoryStream2.Length);
		memoryStream2.SetLength(0L);
		memoryStream2.Position = 0L;
		writeDataSection(memoryStream2, descriptor, dwgLocalSectionMap, (int)descriptor.PageType);
		applyMask(memoryStream2.GetBuffer(), 0, (int)memoryStream2.Length);
		_stream.Write(memoryStream2.GetBuffer(), 0, (int)memoryStream2.Length);
		_stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		if (isCompressed)
		{
			_stream.Write(DwgCheckSumCalculator.MagicSequence, 0, num);
		}
		else if (num != 0)
		{
			throw new Exception();
		}
		if (dwgLocalSectionMap.PageNumber > 0)
		{
			descriptor.PageCount++;
		}
		dwgLocalSectionMap.Size = _stream.Position - position;
		descriptor.LocalSections.Add(dwgLocalSectionMap);
		_localSectionsMaps.Add(dwgLocalSectionMap);
	}

	protected MemoryStream applyCompression(byte[] buffer, int decompressedSize, ulong offset, int totalSize, bool isCompressed)
	{
		MemoryStream memoryStream = new MemoryStream();
		if (isCompressed)
		{
			MemoryStream memoryStream2 = new MemoryStream(decompressedSize);
			memoryStream2.Write(buffer, (int)offset, totalSize);
			int num = decompressedSize - totalSize;
			for (int i = 0; i < num; i++)
			{
				memoryStream2.WriteByte(0);
			}
			compressor.Compress(memoryStream2.GetBuffer(), 0, decompressedSize, memoryStream);
		}
		else
		{
			memoryStream.Write(buffer, (int)offset, totalSize);
			int num2 = decompressedSize - totalSize;
			for (int j = 0; j < num2; j++)
			{
				memoryStream.WriteByte(0);
			}
		}
		return memoryStream;
	}

	private void writeDescriptors()
	{
		MemoryStream memoryStream = new MemoryStream();
		IDwgStreamWriter streamWriter = DwgStreamWriterBase.GetStreamWriter(_version, memoryStream, _encoding);
		streamWriter.WriteInt(_descriptors.Count);
		streamWriter.WriteInt(2);
		streamWriter.WriteInt(29696);
		streamWriter.WriteInt(0);
		streamWriter.WriteInt(_descriptors.Count);
		foreach (DwgSectionDescriptor value in _descriptors.Values)
		{
			streamWriter.WriteBytes(LittleEndianConverter.Instance.GetBytes(value.CompressedSize));
			streamWriter.WriteInt(value.PageCount);
			streamWriter.WriteInt((int)value.DecompressedSize);
			streamWriter.WriteInt(1);
			streamWriter.WriteInt(value.CompressedCode);
			streamWriter.WriteInt(value.SectionId);
			streamWriter.WriteInt(value.Encrypted);
			byte[] array = new byte[64];
			if (!string.IsNullOrEmpty(value.Name))
			{
				byte[] bytes = TextEncoding.Windows1252().GetBytes(value.Name);
				int num = Math.Min(bytes.Length, array.Length);
				for (int i = 0; i < num; i++)
				{
					array[i] = bytes[i];
				}
			}
			memoryStream.Write(array, 0, array.Length);
			foreach (DwgLocalSectionMap localSection in value.LocalSections)
			{
				if (localSection.PageNumber > 0)
				{
					streamWriter.WriteInt(localSection.PageNumber);
					streamWriter.WriteInt((int)localSection.CompressedSize);
					streamWriter.WriteBytes(LittleEndianConverter.Instance.GetBytes(localSection.Offset));
				}
			}
		}
		DwgLocalSectionMap dwgLocalSectionMap = setSeeker(1097007163, memoryStream);
		int count = DwgCheckSumCalculator.CompressionCalculator((int)(_stream.Position - dwgLocalSectionMap.Seeker));
		_stream.Write(DwgCheckSumCalculator.MagicSequence, 0, count);
		dwgLocalSectionMap.Size = _stream.Position - dwgLocalSectionMap.Seeker;
		addSection(dwgLocalSectionMap);
	}

	private void writeRecords()
	{
		writeMagicNumber();
		DwgLocalSectionMap dwgLocalSectionMap = new DwgLocalSectionMap
		{
			SectionMap = 1097010747
		};
		addSection(dwgLocalSectionMap);
		int num = _localSectionsMaps.Count * 8;
		dwgLocalSectionMap.Seeker = _stream.Position;
		int num2 = num + DwgCheckSumCalculator.CompressionCalculator(num);
		dwgLocalSectionMap.Size = num2;
		MemoryStream stream = new MemoryStream();
		StreamIO streamIO = new StreamIO(stream);
		foreach (DwgLocalSectionMap localSectionsMap in _localSectionsMaps)
		{
			if (localSectionsMap != null)
			{
				streamIO.Write(localSectionsMap.PageNumber);
				streamIO.Write((int)localSectionsMap.Size);
			}
		}
		compressChecksum(dwgLocalSectionMap, stream);
		DwgLocalSectionMap dwgLocalSectionMap2 = _localSectionsMaps[_localSectionsMaps.Count - 1];
		_fileHeader.GapAmount = 0u;
		_fileHeader.LastPageId = dwgLocalSectionMap2.PageNumber;
		_fileHeader.LastSectionAddr = (ulong)(dwgLocalSectionMap2.Seeker + num2 - 256);
		_fileHeader.SectionAmount = (uint)(_localSectionsMaps.Count - 1);
		_fileHeader.PageMapAddress = (ulong)dwgLocalSectionMap.Seeker;
	}

	protected void writeFileMetaData()
	{
		StreamIO streamIO = new StreamIO(_stream);
		_fileHeader.SecondHeaderAddr = (ulong)_stream.Position;
		MemoryStream memoryStream = new MemoryStream();
		writeFileHeader(memoryStream);
		_stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		_stream.Position = 0L;
		_stream.Write(Encoding.ASCII.GetBytes(_document.Header.VersionString), 0, 6);
		_stream.Write(new byte[5], 0, 5);
		_stream.WriteByte((byte)_document.Header.MaintenanceVersion);
		_stream.WriteByte(3);
		streamIO.Write((uint)((int)_descriptors["AcDb:Preview"].LocalSections[0].Seeker + 32));
		_stream.WriteByte(33);
		_stream.WriteByte((byte)_document.Header.MaintenanceVersion);
		streamIO.Write(getFileCodePage());
		_stream.Write(new byte[3], 0, 3);
		streamIO.Write(0);
		streamIO.Write(0);
		streamIO.Write((uint)((int)_descriptors["AcDb:SummaryInfo"].LocalSections[0].Seeker + 32));
		streamIO.Write(0u);
		streamIO.Write(128);
		streamIO.Write((uint)((int)_descriptors["AcDb:AppInfo"].LocalSections[0].Seeker + 32));
		byte[] buffer = new byte[80];
		_stream.Write(buffer, 0, 80);
		_stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		_stream.Write(DwgCheckSumCalculator.MagicSequence, 236, 20);
	}

	private void writeFileHeader(MemoryStream stream)
	{
		CRC32StreamHandler cRC32StreamHandler = new CRC32StreamHandler(stream, 0u);
		StreamIO streamIO = new StreamIO(cRC32StreamHandler);
		cRC32StreamHandler.Write(TextEncoding.Windows1252().GetBytes("AcFssFcAJMB"), 0, 11);
		cRC32StreamHandler.WriteByte(0);
		streamIO.Write(0);
		streamIO.Write(108);
		streamIO.Write(4);
		streamIO.Write(_fileHeader.RootTreeNodeGap);
		streamIO.Write(_fileHeader.LeftGap);
		streamIO.Write(_fileHeader.RigthGap);
		streamIO.Write(1);
		streamIO.Write(_fileHeader.LastPageId);
		streamIO.Write(_fileHeader.LastSectionAddr);
		streamIO.Write(_fileHeader.SecondHeaderAddr);
		streamIO.Write(_fileHeader.GapAmount);
		streamIO.Write(_fileHeader.SectionAmount);
		streamIO.Write(32);
		streamIO.Write(128);
		streamIO.Write(64);
		streamIO.Write(_fileHeader.SectionPageMapId);
		streamIO.Write(_fileHeader.PageMapAddress - 256);
		streamIO.Write(_fileHeader.SectionMapId);
		streamIO.Write(_fileHeader.SectionArrayPageSize);
		streamIO.Write(_fileHeader.GapArraySize);
		long position = cRC32StreamHandler.Position;
		streamIO.Write(0u);
		uint seed = cRC32StreamHandler.Seed;
		cRC32StreamHandler.Position = position;
		streamIO.Write(seed);
		cRC32StreamHandler.Flush();
		applyMagicSequence(stream);
	}

	private void addSection(DwgLocalSectionMap section)
	{
		section.PageNumber = _localSectionsMaps.Count + 1;
		_localSectionsMaps.Add(section);
	}

	private DwgLocalSectionMap setSeeker(int map, MemoryStream stream)
	{
		DwgLocalSectionMap dwgLocalSectionMap = new DwgLocalSectionMap
		{
			SectionMap = map
		};
		writeMagicNumber();
		dwgLocalSectionMap.Seeker = _stream.Position;
		compressChecksum(dwgLocalSectionMap, stream);
		return dwgLocalSectionMap;
	}

	private void compressChecksum(DwgLocalSectionMap section, MemoryStream stream)
	{
		section.DecompressedSize = (ulong)stream.Length;
		MemoryStream memoryStream = new MemoryStream();
		compressor.Compress(stream.GetBuffer(), 0, (int)stream.Length, memoryStream);
		section.CompressedSize = (ulong)memoryStream.Length;
		MemoryStream memoryStream2 = new MemoryStream();
		writePageHeaderData(section, memoryStream2);
		section.Checksum = DwgCheckSumCalculator.Calculate(0u, memoryStream2.GetBuffer(), 0, (int)memoryStream2.Length);
		section.Checksum = DwgCheckSumCalculator.Calculate((uint)section.Checksum, memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		writePageHeaderData(section, _stream);
		_stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}

	private void writePageHeaderData(DwgLocalSectionMap section, Stream stream)
	{
		StreamIO streamIO = new StreamIO(stream);
		streamIO.Write(section.SectionMap);
		streamIO.Write((int)section.DecompressedSize);
		streamIO.Write((int)section.CompressedSize);
		streamIO.Write(section.Compression);
		streamIO.Write((uint)section.Checksum);
	}

	private void writeDataSection(Stream stream, DwgSectionDescriptor descriptor, DwgLocalSectionMap map, int size)
	{
		StreamIO streamIO = new StreamIO(stream);
		streamIO.Write(size);
		streamIO.Write(descriptor.SectionId);
		streamIO.Write((int)map.CompressedSize);
		streamIO.Write((int)map.PageSize);
		streamIO.Write((long)map.Offset);
		streamIO.Write((uint)map.Checksum);
		streamIO.Write(map.ODA);
	}
}
