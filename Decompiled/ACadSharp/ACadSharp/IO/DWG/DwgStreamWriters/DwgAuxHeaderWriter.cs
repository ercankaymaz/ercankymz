using System.IO;
using System.Text;
using ACadSharp.Header;

namespace ACadSharp.IO.DWG.DwgStreamWriters;

internal class DwgAuxHeaderWriter : DwgSectionIO
{
	private MemoryStream _stream;

	private Encoding _encoding;

	private CadHeader _header;

	private IDwgStreamWriter _writer;

	public override string SectionName => "AcDb:AuxHeader";

	public DwgAuxHeaderWriter(MemoryStream stream, Encoding encoding, CadHeader header)
		: base(header.Version)
	{
		_stream = stream;
		_encoding = encoding;
		_header = header;
		_writer = DwgStreamWriterBase.GetStreamWriter(_version, _stream, encoding);
	}

	public void Write()
	{
		_writer.WriteByte(byte.MaxValue);
		_writer.WriteByte(119);
		_writer.WriteByte(1);
		_writer.WriteRawShort((short)_version);
		_writer.WriteRawShort(_header.MaintenanceVersion);
		_writer.WriteRawLong(1L);
		_writer.WriteRawLong(-1L);
		_writer.WriteRawShort(1);
		_writer.WriteRawShort(0);
		_writer.WriteRawLong(0L);
		_writer.WriteRawShort((short)_version);
		_writer.WriteRawShort(_header.MaintenanceVersion);
		_writer.WriteRawShort((short)_version);
		_writer.WriteRawShort(_header.MaintenanceVersion);
		_writer.WriteRawShort(5);
		_writer.WriteRawShort(2195);
		_writer.WriteRawShort(5);
		_writer.WriteRawShort(2195);
		_writer.WriteRawShort(0);
		_writer.WriteRawShort(1);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(0L);
		_writer.Write8BitJulianDate(_header.CreateDateTime);
		_writer.Write8BitJulianDate(_header.UpdateDateTime);
		int num = -1;
		if (_header.HandleSeed <= int.MaxValue)
		{
			num = (int)_header.HandleSeed;
		}
		_writer.WriteRawLong(num);
		_writer.WriteRawLong(0L);
		_writer.WriteRawShort(0);
		_writer.WriteRawShort(1);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(1L);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(0L);
		_writer.WriteRawLong(0L);
		if (R2018Plus)
		{
			_writer.WriteRawShort(0);
			_writer.WriteRawShort(0);
			_writer.WriteRawShort(0);
		}
	}
}
