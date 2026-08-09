using System.Collections.Generic;
using System.IO;
using ACadSharp.Exceptions;
using ACadSharp.IO.DWG;
using ACadSharp.IO.DWG.DwgStreamWriters;
using ACadSharp.Tables.Collections;
using CSUtilities.IO;
using CSUtilities.Text;

namespace ACadSharp.IO;

public class DwgWriter : CadWriterBase<DwgWriterConfiguration>
{
	private DwgFileHeader _fileHeader;

	private IDwgFileHeaderWriter _fileHeaderWriter;

	private Dictionary<ulong, long> _handlesMap = new Dictionary<ulong, long>();

	public DwgPreview Preview { get; set; }

	private ACadVersion _version => _document.Header.Version;

	public DwgWriter(string filename, CadDocument document)
		: this(File.Create(filename), document)
	{
	}

	public DwgWriter(Stream stream, CadDocument document)
		: base(stream, document)
	{
		_fileHeader = DwgFileHeader.CreateFileHeader(_version);
	}

	public override void Write()
	{
		base.Write();
		if (_version < ACadVersion.AC1018)
		{
			CadDocument document = _document;
			if (document.VEntityControl == null)
			{
				ViewportEntityControl viewportEntityControl = (document.VEntityControl = new ViewportEntityControl(_document));
			}
		}
		getFileHeaderWriter();
		writeHeader();
		writeClasses();
		writeSummaryInfo();
		writePreview();
		writeAppInfo();
		writeFileDepList();
		writeRevHistory();
		writeAuxHeader();
		writeObjects();
		writeObjFreeSpace();
		writeTemplate();
		writeHandles();
		_fileHeaderWriter.WriteFile();
		_stream.Flush();
		if (base.Configuration.CloseStream)
		{
			_stream.Close();
		}
	}

	public override void Dispose()
	{
		_stream.Dispose();
	}

	public static void Write(string filename, CadDocument document, DwgWriterConfiguration configuration = null, NotificationEventHandler notification = null)
	{
		using DwgWriter dwgWriter = new DwgWriter(filename, document);
		if (configuration != null)
		{
			dwgWriter.Configuration = configuration;
		}
		dwgWriter.OnNotification += notification;
		dwgWriter.Write();
	}

	public static void Write(Stream stream, CadDocument document, DwgWriterConfiguration configuration = null, NotificationEventHandler notification = null)
	{
		using DwgWriter dwgWriter = new DwgWriter(stream, document);
		if (configuration != null)
		{
			dwgWriter.Configuration = configuration;
		}
		dwgWriter.OnNotification += notification;
		dwgWriter.Write();
	}

	private void getFileHeaderWriter()
	{
		switch (_document.Header.Version)
		{
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
		case ACadVersion.AC1012:
			throw new CadNotSupportedException(_document.Header.Version);
		case ACadVersion.AC1014:
		case ACadVersion.AC1015:
			_fileHeaderWriter = new DwgFileHeaderWriterAC15(_stream, _encoding, _document);
			break;
		case ACadVersion.AC1018:
			_fileHeaderWriter = new DwgFileHeaderWriterAC18(_stream, _encoding, _document);
			break;
		case ACadVersion.AC1021:
			throw new CadNotSupportedException(_document.Header.Version);
		case ACadVersion.AC1024:
		case ACadVersion.AC1027:
		case ACadVersion.AC1032:
			_fileHeaderWriter = new DwgFileHeaderWriterAC18(_stream, _encoding, _document);
			break;
		default:
			throw new CadNotSupportedException();
		}
	}

	private void writeHeader()
	{
		MemoryStream stream = new MemoryStream();
		DwgHeaderWriter dwgHeaderWriter = new DwgHeaderWriter(stream, _document, _encoding);
		dwgHeaderWriter.OnNotification += base.triggerNotification;
		dwgHeaderWriter.Write();
		_fileHeaderWriter.AddSection("AcDb:Header", stream, isCompressed: true);
	}

	private void writeClasses()
	{
		MemoryStream stream = new MemoryStream();
		new DwgClassesWriter(stream, _document, _encoding).Write();
		_fileHeaderWriter.AddSection("AcDb:Classes", stream, isCompressed: true);
	}

	private void writeSummaryInfo()
	{
		if (_fileHeader.AcadVersion < ACadVersion.AC1018)
		{
			return;
		}
		MemoryStream stream = new MemoryStream();
		IDwgStreamWriter streamWriter = DwgStreamWriterBase.GetStreamWriter(_version, stream, TextEncoding.Windows1252());
		CadSummaryInfo summaryInfo = _document.SummaryInfo;
		streamWriter.WriteTextUnicode(summaryInfo.Title);
		streamWriter.WriteTextUnicode(summaryInfo.Subject);
		streamWriter.WriteTextUnicode(summaryInfo.Author);
		streamWriter.WriteTextUnicode(summaryInfo.Keywords);
		streamWriter.WriteTextUnicode(summaryInfo.Comments);
		streamWriter.WriteTextUnicode(summaryInfo.LastSavedBy);
		streamWriter.WriteTextUnicode(summaryInfo.RevisionNumber);
		streamWriter.WriteTextUnicode(summaryInfo.HyperlinkBase);
		streamWriter.WriteInt(0);
		streamWriter.WriteInt(0);
		streamWriter.Write8BitJulianDate(summaryInfo.CreatedDate);
		streamWriter.Write8BitJulianDate(summaryInfo.ModifiedDate);
		streamWriter.WriteRawShort((ushort)summaryInfo.Properties.Count);
		foreach (KeyValuePair<string, string> property in summaryInfo.Properties)
		{
			streamWriter.WriteTextUnicode(property.Key);
			streamWriter.WriteTextUnicode(property.Value);
		}
		streamWriter.WriteInt(0);
		streamWriter.WriteInt(0);
		_fileHeaderWriter.AddSection("AcDb:SummaryInfo", stream, isCompressed: false, 256);
	}

	private void writePreview()
	{
		MemoryStream memoryStream = new MemoryStream();
		DwgPreviewWriter dwgPreviewWriter = new DwgPreviewWriter(_version, memoryStream);
		if (Preview != null && Preview.Code != DwgPreview.PreviewType.Unknown)
		{
			dwgPreviewWriter.Write(Preview, _stream.Position);
			int decompsize = (int)(memoryStream.Length % 1024 * 1024 + 1024);
			_fileHeaderWriter.AddSection("AcDb:Preview", memoryStream, isCompressed: false, decompsize);
		}
		else
		{
			dwgPreviewWriter.Write();
			_fileHeaderWriter.AddSection("AcDb:Preview", memoryStream, isCompressed: false, 1024);
		}
	}

	private void writeAppInfo()
	{
		if (_fileHeader.AcadVersion >= ACadVersion.AC1018)
		{
			MemoryStream stream = new MemoryStream();
			new DwgAppInfoWriter(_version, stream).Write();
			_fileHeaderWriter.AddSection("AcDb:AppInfo", stream, isCompressed: false, 128);
		}
	}

	private void writeFileDepList()
	{
		if (_fileHeader.AcadVersion >= ACadVersion.AC1018)
		{
			MemoryStream stream = new MemoryStream();
			StreamIO streamIO = new StreamIO(stream);
			streamIO.Write(0u);
			streamIO.Write(0u);
			_fileHeaderWriter.AddSection("AcDb:FileDepList", stream, isCompressed: false, 128);
		}
	}

	private void writeRevHistory()
	{
		if (_fileHeader.AcadVersion >= ACadVersion.AC1018)
		{
			MemoryStream stream = new MemoryStream();
			StreamIO streamIO = new StreamIO(stream);
			streamIO.Write(0u);
			streamIO.Write(0u);
			streamIO.Write(0u);
			_fileHeaderWriter.AddSection("AcDb:RevHistory", stream, isCompressed: true);
		}
	}

	private void writeObjects()
	{
		MemoryStream stream = new MemoryStream();
		DwgObjectWriter dwgObjectWriter = new DwgObjectWriter(stream, _document, _encoding, base.Configuration.WriteXRecords, base.Configuration.WriteXData, base.Configuration.WriteShapes);
		dwgObjectWriter.OnNotification += base.triggerNotification;
		dwgObjectWriter.Write();
		_handlesMap = dwgObjectWriter.Map;
		_fileHeaderWriter.AddSection("AcDb:AcDbObjects", stream, isCompressed: true);
	}

	private void writeObjFreeSpace()
	{
		MemoryStream stream = new MemoryStream();
		StreamIO streamIO = new StreamIO(stream);
		streamIO.Write(0);
		streamIO.Write((uint)_handlesMap.Count);
		if (_version >= ACadVersion.AC1015)
		{
			CadUtils.DateToJulian(_document.Header.UniversalUpdateDateTime, out var jdate, out var miliseconds);
			streamIO.Write(jdate);
			streamIO.Write(miliseconds);
		}
		else
		{
			CadUtils.DateToJulian(_document.Header.UpdateDateTime, out var jdate2, out var miliseconds2);
			streamIO.Write(jdate2);
			streamIO.Write(miliseconds2);
		}
		streamIO.Write(0u);
		streamIO.Stream.WriteByte(4);
		streamIO.Write(50u);
		streamIO.Write(0u);
		streamIO.Write(100u);
		streamIO.Write(0u);
		streamIO.Write(512u);
		streamIO.Write(0u);
		streamIO.Write(uint.MaxValue);
		streamIO.Write(0u);
		_fileHeaderWriter.AddSection("AcDb:ObjFreeSpace", stream, isCompressed: true);
	}

	private void writeTemplate()
	{
		MemoryStream stream = new MemoryStream();
		StreamIO streamIO = new StreamIO(stream);
		streamIO.Write((short)0);
		streamIO.Write((ushort)1);
		_fileHeaderWriter.AddSection("AcDb:Template", stream, isCompressed: true);
	}

	private void writeHandles()
	{
		MemoryStream stream = new MemoryStream();
		new DwgHandleWriter(_version, stream, _handlesMap).Write(_fileHeaderWriter.HandleSectionOffset);
		_fileHeaderWriter.AddSection("AcDb:Handles", stream, isCompressed: true);
	}

	private void writeAuxHeader()
	{
		MemoryStream stream = new MemoryStream();
		new DwgAuxHeaderWriter(stream, _encoding, _document.Header).Write();
		_fileHeaderWriter.AddSection("AcDb:AuxHeader", stream, isCompressed: true);
	}
}
