using System.IO;
using System.Linq;
using System.Text;
using ACadSharp.Classes;
using CSUtilities.IO;

namespace ACadSharp.IO.DWG;

internal class DwgClassesWriter : DwgSectionIO
{
	private CadDocument _document;

	private MemoryStream _sectionStream;

	private IDwgStreamWriter _startWriter;

	private IDwgStreamWriter _writer;

	private readonly byte[] _startSentinel = new byte[16]
	{
		141, 161, 196, 184, 196, 169, 248, 197, 192, 220,
		244, 95, 231, 207, 182, 138
	};

	private readonly byte[] _endSentinel = new byte[16]
	{
		114, 94, 59, 71, 59, 86, 7, 58, 63, 35,
		11, 160, 24, 48, 73, 117
	};

	public override string SectionName => "AcDb:Classes";

	public DwgClassesWriter(Stream stream, CadDocument document, Encoding encoding)
		: base(document.Header.Version)
	{
		_document = document;
		_startWriter = DwgStreamWriterBase.GetStreamWriter(_version, stream, encoding);
		_sectionStream = new MemoryStream();
		_writer = DwgStreamWriterBase.GetMergedWriter(_version, _sectionStream, encoding);
	}

	public void Write()
	{
		if (R2007Plus)
		{
			_writer.SavePositonForSize();
		}
		short value = 0;
		if (_document.Classes.Any())
		{
			value = _document.Classes.Max((DxfClass c) => c.ClassNumber);
		}
		if (R2004Plus)
		{
			_writer.WriteBitShort(value);
			_writer.WriteByte(0);
			_writer.WriteByte(0);
			_writer.WriteBit(value: true);
		}
		foreach (DxfClass @class in _document.Classes)
		{
			_writer.WriteBitShort(@class.ClassNumber);
			_writer.WriteBitShort((short)@class.ProxyFlags);
			_writer.WriteVariableText(@class.ApplicationName);
			_writer.WriteVariableText(@class.CppClassName);
			_writer.WriteVariableText(@class.DxfName);
			_writer.WriteBit(@class.WasZombie);
			_writer.WriteBitShort(@class.ItemClassId);
			if (R2004Plus)
			{
				_writer.WriteBitLong(@class.InstanceCount);
				_writer.WriteBitLong((int)@class.DwgVersion);
				_writer.WriteBitLong(@class.MaintenanceVersion);
				_writer.WriteBitLong(0);
				_writer.WriteBitLong(0);
			}
		}
		_writer.WriteSpearShift();
		writeSizeAndCrc();
	}

	private void writeSizeAndCrc()
	{
		_startWriter.WriteBytes(_startSentinel);
		CRC8StreamHandler cRC8StreamHandler = new CRC8StreamHandler(_startWriter.Stream, 49345);
		StreamIO streamIO = new StreamIO(cRC8StreamHandler);
		streamIO.Write((int)_sectionStream.Length);
		if ((_document.Header.Version >= ACadVersion.AC1024 && _document.Header.MaintenanceVersion > 3) || _document.Header.Version > ACadVersion.AC1027)
		{
			streamIO.Write(0);
		}
		streamIO.Stream.Write(_sectionStream.GetBuffer(), 0, (int)_sectionStream.Length);
		_startWriter.WriteRawShort(cRC8StreamHandler.Seed);
		_startWriter.WriteBytes(_endSentinel);
		if (R2004Plus)
		{
			_startWriter.WriteRawLong(0L);
			_startWriter.WriteRawLong(0L);
		}
	}
}
