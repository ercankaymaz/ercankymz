using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ACadSharp.Classes;
using ACadSharp.Exceptions;
using ACadSharp.Header;
using ACadSharp.IO.DWG;
using ACadSharp.IO.DWG.DwgStreamReaders;
using CSUtilities.Converters;
using CSUtilities.IO;
using CSUtilities.Text;

namespace ACadSharp.IO;

public class DwgReader : CadReaderBase<DwgReaderConfiguration>
{
	private DwgDocumentBuilder _builder;

	private DwgFileHeader _fileHeader;

	public DwgReader(string filename, NotificationEventHandler notification = null)
		: base(filename, notification)
	{
	}

	public DwgReader(Stream stream, NotificationEventHandler notification = null)
		: base(stream, notification)
	{
	}

	public static CadDocument Read(Stream stream, NotificationEventHandler notification = null)
	{
		return Read(stream, new DwgReaderConfiguration(), notification);
	}

	public static CadDocument Read(Stream stream, DwgReaderConfiguration configuration, NotificationEventHandler notification = null)
	{
		CadDocument cadDocument = null;
		using DwgReader dwgReader = new DwgReader(stream, notification);
		dwgReader.Configuration = configuration;
		return dwgReader.Read();
	}

	public static CadDocument Read(string filename, NotificationEventHandler notification = null)
	{
		return Read(filename, new DwgReaderConfiguration(), notification);
	}

	public static CadDocument Read(string filename, DwgReaderConfiguration configuration, NotificationEventHandler notification = null)
	{
		CadDocument cadDocument = null;
		using DwgReader dwgReader = new DwgReader(filename, notification);
		dwgReader.Configuration = configuration;
		return dwgReader.Read();
	}

	public override CadDocument Read()
	{
		_document = new CadDocument(createDefaults: false);
		_fileHeader = readFileHeader();
		_builder = new DwgDocumentBuilder(_fileHeader.AcadVersion, _document, base.Configuration);
		_builder.OnNotification += base.onNotificationEvent;
		_document.SummaryInfo = ReadSummaryInfo();
		_document.Header = ReadHeader();
		_document.Header.Document = _document;
		_document.Classes = readClasses();
		readAppInfo();
		readObjects();
		_builder.BuildDocument();
		return _document;
	}

	public CadSummaryInfo ReadSummaryInfo()
	{
		_fileHeader = _fileHeader ?? readFileHeader();
		if (_fileHeader.AcadVersion < ACadVersion.AC1018 || !base.Configuration.ReadSummaryInfo)
		{
			return new CadSummaryInfo();
		}
		IDwgStreamReader sectionStream = getSectionStream("AcDb:SummaryInfo");
		if (sectionStream == null)
		{
			return new CadSummaryInfo();
		}
		return new DwgSummaryInfoReader(_fileHeader.AcadVersion, sectionStream).Read();
	}

	public DwgPreview ReadPreview()
	{
		_fileHeader = _fileHeader ?? readFileHeader();
		if (_fileHeader.PreviewAddress < 0)
		{
			return null;
		}
		IDwgStreamReader dwgStreamReader = getSectionStream("AcDb:Preview");
		if (dwgStreamReader == null)
		{
			dwgStreamReader = DwgStreamReaderBase.GetStreamHandler(_fileHeader.AcadVersion, _fileStream.Stream);
			dwgStreamReader.Position = _fileHeader.PreviewAddress;
		}
		return new DwgPreviewReader(_fileHeader.AcadVersion, dwgStreamReader, _fileHeader.PreviewAddress).Read();
	}

	public override CadHeader ReadHeader()
	{
		_fileHeader = _fileHeader ?? readFileHeader();
		CadHeader cadHeader = new CadHeader();
		cadHeader.CodePage = CadUtils.GetCodePageName(_fileHeader.DrawingCodePage);
		IDwgStreamReader sectionStream = getSectionStream("AcDb:Header");
		DwgHeaderReader dwgHeaderReader = new DwgHeaderReader(_fileHeader.AcadVersion, sectionStream, cadHeader);
		dwgHeaderReader.OnNotification += base.onNotificationEvent;
		dwgHeaderReader.Read(_fileHeader.AcadMaintenanceVersion, out var objectPointers);
		if (_builder != null)
		{
			_builder.HeaderHandles = objectPointers;
		}
		return cadHeader;
	}

	internal DwgFileHeader readFileHeader()
	{
		_fileStream.Position = 0L;
		DwgFileHeader dwgFileHeader = DwgFileHeader.CreateFileHeader(CadUtils.GetVersionFromName(_fileStream.ReadString(6, Encoding.ASCII)));
		IDwgStreamReader streamHandler = DwgStreamReaderBase.GetStreamHandler(dwgFileHeader.AcadVersion, _fileStream.Stream);
		switch (dwgFileHeader.AcadVersion)
		{
		case ACadVersion.Unknown:
			throw new CadNotSupportedException();
		case ACadVersion.MC0_0:
		case ACadVersion.AC1_2:
		case ACadVersion.AC1_4:
		case ACadVersion.AC1_50:
		case ACadVersion.AC2_10:
		case ACadVersion.AC1002:
		case ACadVersion.AC1003:
		case ACadVersion.AC1004:
		case ACadVersion.AC1006:
		case ACadVersion.AC1009:
			throw new CadNotSupportedException(_fileHeader.AcadVersion);
		case ACadVersion.AC1012:
		case ACadVersion.AC1014:
		case ACadVersion.AC1015:
			readFileHeaderAC15(dwgFileHeader as DwgFileHeaderAC15, streamHandler);
			break;
		case ACadVersion.AC1018:
			readFileHeaderAC18(dwgFileHeader as DwgFileHeaderAC18, streamHandler);
			break;
		case ACadVersion.AC1021:
			readFileHeaderAC21(dwgFileHeader as DwgFileHeaderAC21, streamHandler);
			break;
		case ACadVersion.AC1024:
		case ACadVersion.AC1027:
		case ACadVersion.AC1032:
			readFileHeaderAC18(dwgFileHeader as DwgFileHeaderAC18, streamHandler);
			break;
		}
		return dwgFileHeader;
	}

	private DxfClassCollection readClasses()
	{
		_fileHeader = _fileHeader ?? readFileHeader();
		IDwgStreamReader sectionStream = getSectionStream("AcDb:Classes");
		DwgClassesReader dwgClassesReader = new DwgClassesReader(_fileHeader.AcadVersion, sectionStream, _fileHeader);
		dwgClassesReader.OnNotification += base.onNotificationEvent;
		return dwgClassesReader.Read();
	}

	private void readAppInfo()
	{
	}

	private Dictionary<ulong, long> readHandles()
	{
		_fileHeader = _fileHeader ?? readFileHeader();
		IDwgStreamReader sectionStream = getSectionStream("AcDb:Handles");
		DwgHandleReader dwgHandleReader = new DwgHandleReader(_fileHeader.AcadVersion, sectionStream);
		dwgHandleReader.OnNotification += base.onNotificationEvent;
		return dwgHandleReader.Read();
	}

	private uint readObjFreeSpace()
	{
		_fileHeader = _fileHeader ?? readFileHeader();
		if (_fileHeader.AcadVersion < ACadVersion.AC1018)
		{
			return 0u;
		}
		IDwgStreamReader sectionStream = getSectionStream("AcDb:ObjFreeSpace");
		sectionStream.Advance(16);
		return sectionStream.ReadUInt();
	}

	private void readTemplate()
	{
		_fileHeader = _fileHeader ?? readFileHeader();
		getSectionStream("AcDb:Template");
		throw new NotImplementedException();
	}

	private void readObjects()
	{
		Dictionary<ulong, long> handleMap = readHandles();
		_document.Classes = readClasses();
		IDwgStreamReader dwgStreamReader = null;
		if (_fileHeader.AcadVersion <= ACadVersion.AC1015)
		{
			dwgStreamReader = DwgStreamReaderBase.GetStreamHandler(_fileHeader.AcadVersion, _fileStream.Stream, _encoding);
			dwgStreamReader.Position = 0L;
		}
		else
		{
			dwgStreamReader = getSectionStream("AcDb:AcDbObjects");
		}
		Queue<ulong> handles = new Queue<ulong>(from a in _builder.HeaderHandles.GetHandles()
			where a.HasValue
			select a.Value);
		new DwgObjectReader(_fileHeader.AcadVersion, _builder, dwgStreamReader, handles, handleMap, _document.Classes).Read();
	}

	private void readFileHeaderAC15(DwgFileHeaderAC15 fileheader, IDwgStreamReader sreader)
	{
		sreader.ReadBytes(7);
		fileheader.PreviewAddress = sreader.ReadInt();
		sreader.ReadBytes(2);
		fileheader.DrawingCodePage = CadUtils.GetCodePage(sreader.ReadShort());
		_encoding = getListedEncoding((int)fileheader.DrawingCodePage);
		int num = (int)sreader.ReadRawLong();
		for (int i = 0; i < num; i++)
		{
			DwgSectionLocatorRecord dwgSectionLocatorRecord = new DwgSectionLocatorRecord();
			dwgSectionLocatorRecord.Number = sreader.ReadByte();
			dwgSectionLocatorRecord.Seeker = sreader.ReadRawLong();
			dwgSectionLocatorRecord.Size = sreader.ReadRawLong();
			fileheader.Records.Add(dwgSectionLocatorRecord.Number.Value, dwgSectionLocatorRecord);
		}
		sreader.ResetShift();
		DwgSectionIO.CheckSentinel(sreader.ReadSentinel(), DwgFileHeaderAC15.EndSentinel);
	}

	private void readFileHeaderAC18(DwgFileHeaderAC18 fileheader, IDwgStreamReader sreader)
	{
		readFileMetaData(fileheader, sreader);
		StreamIO streamIO = new StreamIO(new CRC32StreamHandler(sreader.ReadBytes(108), 0u));
		streamIO.Encoding = TextEncoding.GetListedEncoding(CodePage.Windows1252);
		sreader.ReadBytes(20);
		string text = streamIO.ReadString(12);
		if (text != "AcFssFcAJMB\0")
		{
			triggerNotification("File validation failed, id should be : AcFssFcAJMB\0, but is : " + text, NotificationType.Warning);
		}
		streamIO.ReadInt<LittleEndianConverter>();
		streamIO.ReadInt<LittleEndianConverter>();
		streamIO.ReadInt<LittleEndianConverter>();
		fileheader.RootTreeNodeGap = streamIO.ReadInt<LittleEndianConverter>();
		fileheader.LeftGap = streamIO.ReadInt<LittleEndianConverter>();
		fileheader.RigthGap = streamIO.ReadInt<LittleEndianConverter>();
		streamIO.ReadInt<LittleEndianConverter>();
		fileheader.LastPageId = streamIO.ReadInt<LittleEndianConverter>();
		fileheader.LastSectionAddr = streamIO.ReadULong<LittleEndianConverter>();
		fileheader.SecondHeaderAddr = streamIO.ReadULong<LittleEndianConverter>();
		fileheader.GapAmount = streamIO.ReadUInt<LittleEndianConverter>();
		fileheader.SectionAmount = streamIO.ReadUInt<LittleEndianConverter>();
		streamIO.ReadInt<LittleEndianConverter>();
		streamIO.ReadInt<LittleEndianConverter>();
		streamIO.ReadInt<LittleEndianConverter>();
		fileheader.SectionPageMapId = streamIO.ReadUInt<LittleEndianConverter>();
		fileheader.PageMapAddress = streamIO.ReadULong<LittleEndianConverter>() + 256;
		fileheader.SectionMapId = streamIO.ReadUInt<LittleEndianConverter>();
		fileheader.SectionArrayPageSize = streamIO.ReadUInt<LittleEndianConverter>();
		fileheader.GapArraySize = streamIO.ReadUInt<LittleEndianConverter>();
		fileheader.CRCSeed = streamIO.ReadUInt();
		sreader.Position = (long)fileheader.PageMapAddress;
		getPageHeaderData(sreader, out var sectionType, out var decompressedSize, out var compressedSize, out var compressionType, out var checksum);
		StreamIO streamIO2 = new StreamIO(DwgLZ77AC18Decompressor.Decompress(sreader.Stream, decompressedSize));
		int num = 256;
		while (streamIO2.Position < streamIO2.Length)
		{
			DwgSectionLocatorRecord dwgSectionLocatorRecord = new DwgSectionLocatorRecord();
			dwgSectionLocatorRecord.Number = streamIO2.ReadInt();
			dwgSectionLocatorRecord.Size = streamIO2.ReadInt();
			if (dwgSectionLocatorRecord.Number >= 0)
			{
				dwgSectionLocatorRecord.Seeker = num;
				fileheader.Records.Add(dwgSectionLocatorRecord.Number.Value, dwgSectionLocatorRecord);
			}
			else
			{
				streamIO2.ReadInt();
				streamIO2.ReadInt();
				streamIO2.ReadInt();
				streamIO2.ReadInt();
			}
			num += (int)dwgSectionLocatorRecord.Size;
		}
		sreader.Position = fileheader.Records[(int)fileheader.SectionMapId].Seeker;
		getPageHeaderData(sreader, out checksum, out decompressedSize, out compressionType, out compressedSize, out sectionType);
		StreamIO streamIO3 = new StreamIO(DwgLZ77AC18Decompressor.Decompress(sreader.Stream, decompressedSize));
		streamIO3.Encoding = TextEncoding.GetListedEncoding(CodePage.Windows1252);
		int num2 = streamIO3.ReadInt<LittleEndianConverter>();
		streamIO3.ReadInt<LittleEndianConverter>();
		streamIO3.ReadInt<LittleEndianConverter>();
		streamIO3.ReadInt<LittleEndianConverter>();
		streamIO3.ReadInt<LittleEndianConverter>();
		for (int i = 0; i < num2; i++)
		{
			DwgSectionDescriptor dwgSectionDescriptor = new DwgSectionDescriptor();
			dwgSectionDescriptor.CompressedSize = streamIO3.ReadULong();
			dwgSectionDescriptor.PageCount = streamIO3.ReadInt<LittleEndianConverter>();
			dwgSectionDescriptor.DecompressedSize = (ulong)streamIO3.ReadInt<LittleEndianConverter>();
			streamIO3.ReadInt<LittleEndianConverter>();
			dwgSectionDescriptor.CompressedCode = streamIO3.ReadInt<LittleEndianConverter>();
			dwgSectionDescriptor.SectionId = streamIO3.ReadInt<LittleEndianConverter>();
			dwgSectionDescriptor.Encrypted = streamIO3.ReadInt<LittleEndianConverter>();
			dwgSectionDescriptor.Name = streamIO3.ReadString(64).Split(default(char))[0];
			for (int j = 0; j < dwgSectionDescriptor.PageCount; j++)
			{
				DwgLocalSectionMap dwgLocalSectionMap = new DwgLocalSectionMap();
				dwgLocalSectionMap.PageNumber = streamIO3.ReadInt<LittleEndianConverter>();
				dwgLocalSectionMap.CompressedSize = (ulong)streamIO3.ReadInt<LittleEndianConverter>();
				dwgLocalSectionMap.Offset = streamIO3.ReadULong();
				dwgLocalSectionMap.DecompressedSize = dwgSectionDescriptor.DecompressedSize;
				dwgLocalSectionMap.Seeker = fileheader.Records[dwgLocalSectionMap.PageNumber].Seeker;
				dwgSectionDescriptor.LocalSections.Add(dwgLocalSectionMap);
			}
			uint num3 = (uint)(dwgSectionDescriptor.CompressedSize % dwgSectionDescriptor.DecompressedSize);
			if (num3 != 0 && dwgSectionDescriptor.LocalSections.Count > 0)
			{
				dwgSectionDescriptor.LocalSections[dwgSectionDescriptor.LocalSections.Count - 1].DecompressedSize = num3;
			}
			fileheader.Descriptors.Add(dwgSectionDescriptor.Name, dwgSectionDescriptor);
		}
	}

	private void getPageHeaderData(IDwgStreamReader sreader, out long sectionType, out long decompressedSize, out long compressedSize, out long compressionType, out long checksum)
	{
		sectionType = sreader.ReadRawLong();
		decompressedSize = sreader.ReadRawLong();
		compressedSize = sreader.ReadRawLong();
		compressionType = sreader.ReadRawLong();
		checksum = sreader.ReadRawLong();
	}

	private void readFileHeaderAC21(DwgFileHeaderAC21 fileheader, IDwgStreamReader sreader)
	{
		readFileMetaData(fileheader, sreader);
		byte[] encoded = sreader.ReadBytes(1024);
		byte[] array = new byte[717];
		reedSolomonDecoding(encoded, array, 3, 239);
		LittleEndianConverter.Instance.ToInt64(array, 0);
		LittleEndianConverter.Instance.ToInt64(array, 8);
		LittleEndianConverter.Instance.ToInt64(array, 16);
		int num = LittleEndianConverter.Instance.ToInt32(array, 24);
		LittleEndianConverter.Instance.ToInt32(array, 28);
		byte[] array2 = new byte[272];
		if (num < 0)
		{
			throw new NotImplementedException();
		}
		DwgLZ77AC21Decompressor.Decompress(array, 32u, (uint)num, array2);
		StreamIO streamIO = new StreamIO(array2);
		fileheader.CompressedMetadata = new Dwg21CompressedMetadata
		{
			HeaderSize = streamIO.ReadULong(),
			FileSize = streamIO.ReadULong(),
			PagesMapCrcCompressed = streamIO.ReadULong(),
			PagesMapCorrectionFactor = streamIO.ReadULong(),
			PagesMapCrcSeed = streamIO.ReadULong(),
			Map2Offset = streamIO.ReadULong(),
			Map2Id = streamIO.ReadULong(),
			PagesMapOffset = streamIO.ReadULong(),
			PagesMapId = streamIO.ReadULong(),
			Header2offset = streamIO.ReadULong(),
			PagesMapSizeCompressed = streamIO.ReadULong(),
			PagesMapSizeUncompressed = streamIO.ReadULong(),
			PagesAmount = streamIO.ReadULong(),
			PagesMaxId = streamIO.ReadULong(),
			Unknow0x20 = streamIO.ReadULong(),
			Unknow0x40 = streamIO.ReadULong(),
			PagesMapCrcUncompressed = streamIO.ReadULong(),
			Unknown0xF800 = streamIO.ReadULong(),
			Unknown4 = streamIO.ReadULong(),
			Unknown1 = streamIO.ReadULong(),
			SectionsAmount = streamIO.ReadULong(),
			SectionsMapCrcUncompressed = streamIO.ReadULong(),
			SectionsMapSizeCompressed = streamIO.ReadULong(),
			SectionsMap2Id = streamIO.ReadULong(),
			SectionsMapId = streamIO.ReadULong(),
			SectionsMapSizeUncompressed = streamIO.ReadULong(),
			SectionsMapCrcCompressed = streamIO.ReadULong(),
			SectionsMapCorrectionFactor = streamIO.ReadULong(),
			SectionsMapCrcSeed = streamIO.ReadULong(),
			StreamVersion = streamIO.ReadULong(),
			CrcSeed = streamIO.ReadULong(),
			CrcSeedEncoded = streamIO.ReadULong(),
			RandomSeed = streamIO.ReadULong(),
			HeaderCRC64 = streamIO.ReadULong()
		};
		StreamIO streamIO2 = new StreamIO(getPageBuffer(fileheader.CompressedMetadata.PagesMapOffset, fileheader.CompressedMetadata.PagesMapSizeCompressed, fileheader.CompressedMetadata.PagesMapSizeUncompressed, fileheader.CompressedMetadata.PagesMapCorrectionFactor, 239, sreader.Stream));
		long num2 = 0L;
		while (streamIO2.Position < streamIO2.Length)
		{
			long num3 = streamIO2.ReadLong();
			long num4 = Math.Abs(streamIO2.ReadLong());
			fileheader.Records.Add((int)num4, new DwgSectionLocatorRecord((int)num4, (int)num2, (int)num3));
			num2 += num3;
		}
		StreamIO streamIO3 = new StreamIO(getPageBuffer((ulong)fileheader.Records[(int)fileheader.CompressedMetadata.SectionsMapId].Seeker, fileheader.CompressedMetadata.SectionsMapSizeCompressed, fileheader.CompressedMetadata.SectionsMapSizeUncompressed, fileheader.CompressedMetadata.SectionsMapCorrectionFactor, 239, sreader.Stream));
		while (streamIO3.Position < streamIO3.Length)
		{
			DwgSectionDescriptor dwgSectionDescriptor = new DwgSectionDescriptor();
			dwgSectionDescriptor.CompressedSize = streamIO3.ReadULong<LittleEndianConverter>();
			dwgSectionDescriptor.DecompressedSize = streamIO3.ReadULong<LittleEndianConverter>();
			dwgSectionDescriptor.Encrypted = (int)streamIO3.ReadULong<LittleEndianConverter>();
			dwgSectionDescriptor.HashCode = streamIO3.ReadULong<LittleEndianConverter>();
			int num5 = (int)streamIO3.ReadLong<LittleEndianConverter>();
			streamIO3.ReadULong<LittleEndianConverter>();
			dwgSectionDescriptor.Encoding = streamIO3.ReadULong<LittleEndianConverter>();
			dwgSectionDescriptor.PageCount = (int)streamIO3.ReadULong<LittleEndianConverter>();
			if (num5 > 0)
			{
				dwgSectionDescriptor.Name = streamIO3.ReadString(num5, Encoding.Unicode);
				dwgSectionDescriptor.Name = dwgSectionDescriptor.Name.Replace("\0", "");
			}
			for (int i = 0; i < dwgSectionDescriptor.PageCount; i++)
			{
				DwgLocalSectionMap dwgLocalSectionMap = new DwgLocalSectionMap();
				dwgLocalSectionMap.Offset = streamIO3.ReadULong<LittleEndianConverter>();
				dwgLocalSectionMap.Size = streamIO3.ReadLong<LittleEndianConverter>();
				dwgLocalSectionMap.PageNumber = (int)streamIO3.ReadLong<LittleEndianConverter>();
				dwgLocalSectionMap.DecompressedSize = streamIO3.ReadULong<LittleEndianConverter>();
				dwgLocalSectionMap.CompressedSize = streamIO3.ReadULong<LittleEndianConverter>();
				dwgLocalSectionMap.Checksum = streamIO3.ReadULong<LittleEndianConverter>();
				dwgLocalSectionMap.CRC = streamIO3.ReadULong<LittleEndianConverter>();
				dwgSectionDescriptor.LocalSections.Add(dwgLocalSectionMap);
				_ = dwgLocalSectionMap.Offset;
				_ = dwgLocalSectionMap.DecompressedSize;
			}
			if (num5 > 0)
			{
				fileheader.Descriptors.Add(dwgSectionDescriptor.Name, dwgSectionDescriptor);
			}
		}
	}

	private void readFileMetaData(DwgFileHeaderAC18 fileheader, IDwgStreamReader sreader)
	{
		sreader.Advance(5);
		fileheader.AcadMaintenanceVersion = sreader.ReadByte();
		sreader.Advance(1);
		fileheader.PreviewAddress = sreader.ReadRawLong();
		fileheader.DwgVersion = sreader.ReadByte();
		fileheader.AppReleaseVersion = sreader.ReadByte();
		fileheader.DrawingCodePage = CadUtils.GetCodePage(sreader.ReadShort());
		Encoding encoding = (sreader.Encoding = getListedEncoding((int)fileheader.DrawingCodePage));
		_encoding = encoding;
		sreader.Advance(3);
		fileheader.SecurityType = sreader.ReadRawLong();
		sreader.ReadRawLong();
		fileheader.SummaryInfoAddr = sreader.ReadRawLong();
		fileheader.VbaProjectAddr = sreader.ReadRawLong();
		sreader.ReadRawLong();
		sreader.ReadRawLong();
		sreader.Advance(80);
	}

	private IDwgStreamReader getSectionStream(string sectionName)
	{
		Stream stream = null;
		switch (_fileHeader.AcadVersion)
		{
		case ACadVersion.Unknown:
			throw new CadNotSupportedException();
		case ACadVersion.MC0_0:
		case ACadVersion.AC1_2:
		case ACadVersion.AC1_4:
		case ACadVersion.AC1_50:
		case ACadVersion.AC2_10:
		case ACadVersion.AC1002:
		case ACadVersion.AC1003:
		case ACadVersion.AC1004:
		case ACadVersion.AC1006:
		case ACadVersion.AC1009:
			throw new CadNotSupportedException(_fileHeader.AcadVersion);
		case ACadVersion.AC1012:
		case ACadVersion.AC1014:
		case ACadVersion.AC1015:
			stream = getSectionBuffer15(_fileHeader as DwgFileHeaderAC15, sectionName);
			break;
		case ACadVersion.AC1018:
			stream = getSectionBuffer18(_fileHeader as DwgFileHeaderAC18, sectionName);
			break;
		case ACadVersion.AC1021:
			stream = getSectionBuffer21(_fileHeader as DwgFileHeaderAC21, sectionName);
			break;
		case ACadVersion.AC1024:
		case ACadVersion.AC1027:
		case ACadVersion.AC1032:
			stream = getSectionBuffer18(_fileHeader as DwgFileHeaderAC18, sectionName);
			break;
		}
		if (stream == null)
		{
			return null;
		}
		IDwgStreamReader streamHandler = DwgStreamReaderBase.GetStreamHandler(_fileHeader.AcadVersion, stream);
		streamHandler.Encoding = _encoding;
		return streamHandler;
	}

	private Stream getSectionBuffer15(DwgFileHeaderAC15 fileheader, string sectionName)
	{
		Stream stream = null;
		int? sectionLocatorByName = DwgSectionDefinition.GetSectionLocatorByName(sectionName);
		if (!sectionLocatorByName.HasValue)
		{
			return null;
		}
		if (fileheader.Records.TryGetValue(sectionLocatorByName.Value, out var value))
		{
			stream = _fileStream.Stream;
			stream.Position = value.Seeker;
		}
		return stream;
	}

	private Stream getSectionBuffer18(DwgFileHeaderAC18 fileheader, string sectionName)
	{
		if (!fileheader.Descriptors.TryGetValue(sectionName, out var value))
		{
			return null;
		}
		MemoryStream memoryStream = HugeMemoryStream.Create((long)value.DecompressedSize * (long)value.LocalSections.Count);
		foreach (DwgLocalSectionMap localSection in value.LocalSections)
		{
			if (localSection.IsEmpty)
			{
				for (int i = 0; i < (int)localSection.DecompressedSize; i++)
				{
					memoryStream.WriteByte(0);
				}
				continue;
			}
			IDwgStreamReader streamHandler = DwgStreamReaderBase.GetStreamHandler(fileheader.AcadVersion, _fileStream.Stream);
			streamHandler.Position = localSection.Seeker;
			decryptDataSection(localSection, streamHandler);
			if (value.IsCompressed)
			{
				DwgLZ77AC18Decompressor.DecompressToDest(_fileStream.Stream, memoryStream);
				continue;
			}
			byte[] buffer = new byte[localSection.CompressedSize];
			streamHandler.Stream.Read(buffer, 0, (int)localSection.CompressedSize);
			memoryStream.Write(buffer, 0, (int)localSection.CompressedSize);
		}
		memoryStream.Position = 0L;
		return memoryStream;
	}

	private void decryptDataSection(DwgLocalSectionMap section, IDwgStreamReader sreader)
	{
		int num = 0x4164536B ^ (int)sreader.Position;
		sreader.ReadRawLong();
		sreader.ReadRawLong();
		section.CompressedSize = (ulong)(sreader.ReadRawLong() ^ num);
		section.PageSize = sreader.ReadRawLong() ^ num;
		long num2 = sreader.ReadRawLong() ^ num;
		long num3 = sreader.ReadRawLong() ^ num;
		section.Offset = (ulong)(num3 + num2);
		section.Checksum = (uint)(sreader.ReadRawLong() ^ num);
		sreader.ReadRawLong();
	}

	private Stream getSectionBuffer21(DwgFileHeaderAC21 fileheader, string sectionName)
	{
		if (!fileheader.Descriptors.TryGetValue(sectionName, out var value))
		{
			return null;
		}
		ulong num = 0uL;
		foreach (DwgLocalSectionMap localSection in value.LocalSections)
		{
			num += localSection.DecompressedSize;
		}
		MemoryStream memoryStream = HugeMemoryStream.Create((long)num);
		foreach (DwgLocalSectionMap localSection2 in value.LocalSections)
		{
			if (localSection2.IsEmpty)
			{
				for (int i = 0; i < (int)localSection2.DecompressedSize; i++)
				{
					memoryStream.WriteByte(0);
				}
				continue;
			}
			DwgSectionLocatorRecord dwgSectionLocatorRecord = fileheader.Records[localSection2.PageNumber];
			_fileStream.Position = dwgSectionLocatorRecord.Seeker + 1152;
			byte[] array = new byte[dwgSectionLocatorRecord.Size];
			_fileStream.Stream.Read(array, 0, (int)dwgSectionLocatorRecord.Size);
			if (value.Encoding == 4)
			{
				int num2 = (int)((((localSection2.CompressedSize + 7) & 0xFFFFFFF8u) + 251 - 1) / 251);
				byte[] array2 = new byte[num2 * 251];
				reedSolomonDecoding(array, array2, num2, 251);
				array = array2;
			}
			if (localSection2.CompressedSize != localSection2.DecompressedSize)
			{
				byte[] array3 = new byte[localSection2.DecompressedSize];
				DwgLZ77AC21Decompressor.Decompress(array, 0u, (uint)localSection2.CompressedSize, array3);
				array = array3;
			}
			memoryStream.Write(array, 0, (int)localSection2.DecompressedSize);
		}
		memoryStream.Position = 0L;
		return memoryStream;
	}

	private void reedSolomonDecoding(byte[] encoded, byte[] buffer, int factor, int blockSize)
	{
		int num = 0;
		int num2 = 0;
		int num3 = buffer.Length;
		for (int i = 0; i < factor; i++)
		{
			int num4 = num2;
			if (num2 < encoded.Length)
			{
				int num5 = Math.Min(num3, blockSize);
				num3 -= num5;
				int num6 = num + num5;
				while (num < num6)
				{
					buffer[num] = encoded[num4];
					num++;
					num4 += factor;
				}
			}
			num2++;
		}
	}

	private byte[] getPageBuffer(ulong pageOffset, ulong compressedSize, ulong uncompressedSize, ulong correctionFactor, int blockSize, Stream stream)
	{
		int num = (int)(((compressedSize + 7) & 0xFFFFFFF8u) * correctionFactor);
		int num2 = (int)((uint)num + blockSize - 1) / blockSize;
		int num3 = num2 * 255;
		byte[] array = new byte[num3];
		stream.Position = (long)(1152 + pageOffset);
		stream.Read(array, 0, num3);
		byte[] array2 = new byte[num];
		reedSolomonDecoding(array, array2, num2, blockSize);
		byte[] array3 = new byte[uncompressedSize];
		DwgLZ77AC21Decompressor.Decompress(array2, 0u, (uint)compressedSize, array3);
		return array3;
	}
}
