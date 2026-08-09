using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ACadSharp.Classes;
using ACadSharp.Entities;
using ACadSharp.Exceptions;
using ACadSharp.Header;
using ACadSharp.IO.DXF;
using CSUtilities.IO;
using CSUtilities.Text;

namespace ACadSharp.IO;

public class DxfReader : CadReaderBase<DxfReaderConfiguration>
{
	private ACadVersion _version;

	private DxfDocumentBuilder _builder;

	private IDxfStreamReader _reader;

	public DxfReader(string filename, NotificationEventHandler notification = null)
		: base(filename, notification)
	{
	}

	public DxfReader(Stream stream, NotificationEventHandler notification = null)
		: base(stream, notification)
	{
	}

	public bool IsBinary()
	{
		return IsBinary(_fileStream.Stream);
	}

	public static bool IsBinary(string filename)
	{
		FileStream fileStream = File.OpenRead(filename);
		bool result = IsBinary(fileStream);
		fileStream.Close();
		return result;
	}

	public static bool IsBinary(Stream stream, bool resetPos = false)
	{
		bool result = new StreamIO(stream)
		{
			Position = 0L
		}.ReadString("AutoCAD Binary DXF\r\n\u001a\0".Length) == "AutoCAD Binary DXF\r\n\u001a\0";
		if (resetPos)
		{
			stream.Position = 0L;
		}
		return result;
	}

	public static CadDocument Read(string filename, DxfReaderConfiguration configuration, NotificationEventHandler notification = null)
	{
		CadDocument cadDocument = null;
		using DxfReader dxfReader = new DxfReader(filename, notification);
		dxfReader.Configuration = configuration;
		return dxfReader.Read();
	}

	public static CadDocument Read(Stream stream, NotificationEventHandler notification = null)
	{
		CadDocument cadDocument = null;
		using DxfReader dxfReader = new DxfReader(stream, notification);
		return dxfReader.Read();
	}

	public static CadDocument Read(string filename, NotificationEventHandler notification = null)
	{
		return Read(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), notification);
	}

	public override CadDocument Read()
	{
		_document = new CadDocument(createDefaults: false);
		_document.SummaryInfo = new CadSummaryInfo();
		_reader = _reader ?? getReader();
		_builder = new DxfDocumentBuilder(_version, _document, base.Configuration);
		_builder.OnNotification += base.onNotificationEvent;
		while (_reader.ValueAsString != "EOF")
		{
			if (_reader.ValueAsString != "SECTION")
			{
				_reader.ReadNext();
				continue;
			}
			_reader.ReadNext();
			switch (_reader.ValueAsString)
			{
			case "HEADER":
				_document.Header = ReadHeader();
				_document.Header.Document = _document;
				_builder.InitialHandSeed = _document.Header.HandleSeed;
				break;
			case "CLASSES":
				_document.Classes = readClasses();
				break;
			case "TABLES":
				readTables();
				break;
			case "BLOCKS":
				readBlocks();
				break;
			case "ENTITIES":
				readEntities();
				break;
			case "OBJECTS":
				readObjects();
				break;
			default:
				triggerNotification("Section not implemented " + _reader.ValueAsString, NotificationType.NotImplemented);
				break;
			}
			_reader.ReadNext();
		}
		if (_document.Header == null)
		{
			_document.Header = new CadHeader(_document);
		}
		_builder.BuildDocument();
		return _document;
	}

	public override CadHeader ReadHeader()
	{
		_reader = goToSection("HEADER");
		CadHeader cadHeader = new CadHeader();
		Dictionary<string, CadSystemVariable> headerMap = CadHeader.GetHeaderMap();
		_reader.ReadNext();
		while (_reader.ValueAsString != "ENDSEC")
		{
			string valueAsString = _reader.ValueAsString;
			if (_reader.ValueAsString == null || !headerMap.TryGetValue(valueAsString, out var value))
			{
				_reader.ReadNext();
				continue;
			}
			object[] array = new object[value.DxfCodes.Length];
			for (int i = 0; i < value.DxfCodes.Length; i++)
			{
				_reader.ReadNext();
				if (_reader.DxfCode == DxfCode.CLShapeText)
				{
					switch (GroupCodeValue.TransformValue(value.DxfCodes[i]))
					{
					case GroupCodeValueType.Bool:
						array[i] = false;
						break;
					case GroupCodeValueType.Point3D:
					case GroupCodeValueType.Double:
					case GroupCodeValueType.Byte:
					case GroupCodeValueType.Int16:
					case GroupCodeValueType.Int32:
					case GroupCodeValueType.Int64:
						array[i] = 0;
						break;
					default:
						array[i] = null;
						break;
					}
					break;
				}
				array[i] = _reader.Value;
			}
			try
			{
				cadHeader.SetValue(valueAsString, array);
			}
			catch (Exception ex)
			{
				triggerNotification($"Invalid value for header variable {valueAsString} | {array.FirstOrDefault()}", NotificationType.Warning, ex);
			}
			if (_reader.DxfCode != DxfCode.CLShapeText)
			{
				_reader.ReadNext();
			}
		}
		return cadHeader;
	}

	public CadDocument ReadTables()
	{
		_reader = _reader ?? getReader();
		_builder = new DxfDocumentBuilder(_version, _document, base.Configuration);
		_builder.OnNotification += base.onNotificationEvent;
		readTables();
		_document.Header = new CadHeader(_document);
		_builder.RegisterTables();
		_builder.BuildTables();
		return _document;
	}

	public List<Entity> ReadEntities()
	{
		_reader = _reader ?? getReader();
		_builder = new DxfDocumentBuilder(_version, _document, base.Configuration);
		_builder.OnNotification += base.onNotificationEvent;
		readEntities();
		return _builder.BuildEntities();
	}

	public override void Dispose()
	{
		base.Dispose();
		if (base.Configuration.ClearCache)
		{
			DxfMap.ClearCache();
		}
	}

	private DxfClassCollection readClasses()
	{
		_reader = goToSection("CLASSES");
		DxfClassCollection dxfClassCollection = new DxfClassCollection();
		_reader.ReadNext();
		while (_reader.ValueAsString != "ENDSEC")
		{
			if (_reader.ValueAsString == "CLASS")
			{
				DxfClass dxfClass = readClass();
				if (dxfClass.ClassNumber < 500)
				{
					dxfClass.ClassNumber = (short)(500 + dxfClassCollection.Count);
				}
				dxfClassCollection.AddOrUpdate(dxfClass);
			}
			else
			{
				_reader.ReadNext();
			}
		}
		return dxfClassCollection;
	}

	private DxfClass readClass()
	{
		DxfClass dxfClass = new DxfClass();
		_reader.ReadNext();
		while (_reader.DxfCode != DxfCode.Start)
		{
			switch (_reader.Code)
			{
			case 1:
				dxfClass.DxfName = _reader.ValueAsString;
				break;
			case 2:
				dxfClass.CppClassName = _reader.ValueAsString;
				break;
			case 3:
				dxfClass.ApplicationName = _reader.ValueAsString;
				break;
			case 90:
				dxfClass.ProxyFlags = (ProxyFlags)_reader.ValueAsUShort;
				break;
			case 91:
				dxfClass.InstanceCount = _reader.ValueAsInt;
				break;
			case 280:
				dxfClass.WasZombie = _reader.ValueAsBool;
				break;
			case 281:
				dxfClass.IsAnEntity = _reader.ValueAsBool;
				break;
			}
			_reader.ReadNext();
		}
		return dxfClass;
	}

	private void readTables()
	{
		_reader = goToSection("TABLES");
		new DxfTablesSectionReader(_reader, _builder).Read();
	}

	private void readBlocks()
	{
		_reader = goToSection("BLOCKS");
		new DxfBlockSectionReader(_reader, _builder).Read();
	}

	private void readEntities()
	{
		_reader = goToSection("ENTITIES");
		new DxfEntitiesSectionReader(_reader, _builder).Read();
	}

	private void readObjects()
	{
		_reader = goToSection("OBJECTS");
		new DxfObjectsSectionReader(_reader, _builder).Read();
	}

	private void readThumbnailImage()
	{
		throw new NotImplementedException();
	}

	private IDxfStreamReader getReader()
	{
		IDxfStreamReader dxfStreamReader = null;
		_version = ACadVersion.Unknown;
		bool flag = IsBinary(_fileStream.Stream);
		bool isAC1009Format = false;
		if (flag && _fileStream.Stream.ReadByte() != -1)
		{
			int num = _fileStream.ReadByte();
			if (num != -1 && num != 0)
			{
				isAC1009Format = true;
			}
		}
		dxfStreamReader = createReader(flag, isAC1009Format);
		if (!dxfStreamReader.Find("HEADER"))
		{
			triggerNotification("Header section not found, using a generic reader.", NotificationType.Warning);
			_version = ACadVersion.Unknown;
			dxfStreamReader.Start();
			return dxfStreamReader;
		}
		while (dxfStreamReader.ValueAsString != "ENDSEC")
		{
			if (dxfStreamReader.ValueAsString == "$ACADVER")
			{
				dxfStreamReader.ReadNext();
				_version = CadUtils.GetVersionFromName(dxfStreamReader.ValueAsString);
				if (_version >= ACadVersion.AC1021)
				{
					_encoding = Encoding.UTF8;
					break;
				}
				if (_version < ACadVersion.AC1002)
				{
					if (_version == ACadVersion.Unknown)
					{
						throw new CadNotSupportedException();
					}
					throw new CadNotSupportedException(_version);
				}
			}
			else if (dxfStreamReader.ValueAsString == "$DWGCODEPAGE")
			{
				dxfStreamReader.ReadNext();
				CodePage codePage = CadUtils.GetCodePage(dxfStreamReader.ValueAsString.ToLower());
				_encoding = getListedEncoding((int)codePage);
			}
			dxfStreamReader.ReadNext();
		}
		if (_version == ACadVersion.Unknown)
		{
			triggerNotification("Dxf version not found, using a generic reader.", NotificationType.Warning);
		}
		return createReader(flag, isAC1009Format);
	}

	private IDxfStreamReader goToSection(string sectionName)
	{
		_reader = _reader ?? getReader();
		if (_reader.ValueAsString == sectionName)
		{
			return _reader;
		}
		_reader.Find(sectionName);
		return _reader;
	}

	private IDxfStreamReader createReader(bool isBinary, bool isAC1009Format)
	{
		Encoding encoding = _encoding;
		if (encoding == null)
		{
			encoding = Encoding.ASCII;
		}
		if (isBinary)
		{
			if (isAC1009Format)
			{
				return new DxfBinaryReaderAC1009(_fileStream.Stream, encoding);
			}
			return new DxfBinaryReader(_fileStream.Stream, encoding);
		}
		return new DxfTextReader(_fileStream.Stream, encoding);
	}
}
