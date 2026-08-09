using System.IO;
using System.Text;
using ACadSharp.IO.DXF;

namespace ACadSharp.IO;

public class DxfWriter : CadWriterBase<DxfWriterConfiguration>
{
	private IDxfStreamWriter _writer;

	private CadObjectHolder _objectHolder = new CadObjectHolder();

	public bool IsBinary { get; }

	public DxfWriter(string filename, CadDocument document, bool binary = false)
		: this(File.Create(filename), document, binary)
	{
	}

	public DxfWriter(Stream stream, CadDocument document, bool binary = false)
		: base(stream, document)
	{
		IsBinary = binary;
	}

	public override void Write()
	{
		base.Write();
		createStreamWriter();
		_objectHolder.Objects.Enqueue(_document.RootDictionary);
		writeHeader();
		writeDxfClasses();
		writeTables();
		writeBlocks();
		writeEntities();
		writeObjects();
		writeACDSData();
		_writer.Write(DxfCode.Start, "EOF");
		_writer.Flush();
		if (base.Configuration.CloseStream)
		{
			_writer.Close();
		}
	}

	public override void Dispose()
	{
		_writer.Dispose();
	}

	public static void Write(string filename, CadDocument document, bool binary = false, DxfWriterConfiguration configuration = null, NotificationEventHandler notification = null)
	{
		Write(File.Create(filename), document, binary, configuration, notification);
	}

	public static void Write(Stream stream, CadDocument document, bool binary = false, DxfWriterConfiguration configuration = null, NotificationEventHandler notification = null)
	{
		using DxfWriter dxfWriter = new DxfWriter(stream, document, binary);
		if (configuration != null)
		{
			dxfWriter.Configuration = configuration;
		}
		dxfWriter.OnNotification += notification;
		dxfWriter.Write();
	}

	private void createStreamWriter()
	{
		Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
		if (IsBinary)
		{
			_writer = new DxfBinaryWriter(new BinaryWriter(_stream, encoding));
		}
		else
		{
			_writer = new DxfAsciiWriter(new StreamWriter(_stream, encoding));
		}
		_writer.WriteOptional = base.Configuration.WriteOptionalValues;
	}

	private void writeHeader()
	{
		DxfHeaderSectionWriter dxfHeaderSectionWriter = new DxfHeaderSectionWriter(_writer, _document, _objectHolder, base.Configuration);
		dxfHeaderSectionWriter.OnNotification += base.triggerNotification;
		dxfHeaderSectionWriter.Write();
	}

	private void writeDxfClasses()
	{
		DxfClassesSectionWriter dxfClassesSectionWriter = new DxfClassesSectionWriter(_writer, _document, _objectHolder, base.Configuration);
		dxfClassesSectionWriter.OnNotification += base.triggerNotification;
		dxfClassesSectionWriter.Write();
	}

	private void writeTables()
	{
		DxfTablesSectionWriter dxfTablesSectionWriter = new DxfTablesSectionWriter(_writer, _document, _objectHolder, base.Configuration);
		dxfTablesSectionWriter.OnNotification += base.triggerNotification;
		dxfTablesSectionWriter.Write();
	}

	private void writeBlocks()
	{
		DxfBlocksSectionWriter dxfBlocksSectionWriter = new DxfBlocksSectionWriter(_writer, _document, _objectHolder, base.Configuration);
		dxfBlocksSectionWriter.OnNotification += base.triggerNotification;
		dxfBlocksSectionWriter.Write();
	}

	private void writeEntities()
	{
		DxfEntitiesSectionWriter dxfEntitiesSectionWriter = new DxfEntitiesSectionWriter(_writer, _document, _objectHolder, base.Configuration);
		dxfEntitiesSectionWriter.OnNotification += base.triggerNotification;
		dxfEntitiesSectionWriter.Write();
	}

	private void writeObjects()
	{
		DxfObjectsSectionWriter dxfObjectsSectionWriter = new DxfObjectsSectionWriter(_writer, _document, _objectHolder, base.Configuration);
		dxfObjectsSectionWriter.OnNotification += base.triggerNotification;
		dxfObjectsSectionWriter.Write();
	}

	private void writeACDSData()
	{
	}
}
