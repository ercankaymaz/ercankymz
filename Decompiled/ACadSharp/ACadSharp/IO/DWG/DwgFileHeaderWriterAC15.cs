using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal class DwgFileHeaderWriterAC15 : DwgFileHeaderWriterBase
{
	private readonly Dictionary<string, (DwgSectionLocatorRecord, MemoryStream)> _records;

	private byte[] _endSentinel = new byte[16]
	{
		149, 160, 78, 40, 153, 130, 26, 229, 94, 65,
		224, 95, 157, 58, 77, 0
	};

	public override int HandleSectionOffset
	{
		get
		{
			long num = _fileHeaderSize;
			foreach (KeyValuePair<string, (DwgSectionLocatorRecord, MemoryStream)> record in _records)
			{
				if (record.Key == "AcDb:AcDbObjects")
				{
					break;
				}
				num += record.Value.Item2.Length;
			}
			return (int)num;
		}
	}

	protected override int _fileHeaderSize => 97;

	public DwgFileHeaderWriterAC15(Stream stream, Encoding encoding, CadDocument model)
		: base(stream, encoding, model)
	{
		_records = new Dictionary<string, (DwgSectionLocatorRecord, MemoryStream)>
		{
			{
				"AcDb:Header",
				(new DwgSectionLocatorRecord(0), null)
			},
			{
				"AcDb:Classes",
				(new DwgSectionLocatorRecord(1), null)
			},
			{
				"AcDb:ObjFreeSpace",
				(new DwgSectionLocatorRecord(3), null)
			},
			{
				"AcDb:Template",
				(new DwgSectionLocatorRecord(4), null)
			},
			{
				"AcDb:AuxHeader",
				(new DwgSectionLocatorRecord(5), null)
			},
			{
				"AcDb:AcDbObjects",
				(new DwgSectionLocatorRecord(null), null)
			},
			{
				"AcDb:Handles",
				(new DwgSectionLocatorRecord(2), null)
			},
			{
				"AcDb:Preview",
				(new DwgSectionLocatorRecord(null), null)
			}
		};
	}

	public override void AddSection(string name, MemoryStream stream, bool isCompressed, int decompsize = 29696)
	{
		_records[name].Item1.Size = stream.Length;
		_records[name] = (_records[name].Item1, stream);
	}

	public override void WriteFile()
	{
		setRecordSeekers();
		writeFileHeader();
		writeRecordStreams();
	}

	private void setRecordSeekers()
	{
		long num = _fileHeaderSize;
		foreach (var value in _records.Values)
		{
			value.Item1.Seeker = num;
			num += value.Item2.Length;
		}
	}

	private void writeFileHeader()
	{
		MemoryStream memoryStream = new MemoryStream();
		IDwgStreamWriter streamWriter = DwgStreamWriterBase.GetStreamWriter(_version, memoryStream, _encoding);
		streamWriter.WriteBytes(Encoding.ASCII.GetBytes(_document.Header.VersionString));
		streamWriter.WriteBytes(new byte[7] { 0, 0, 0, 0, 0, 15, 1 });
		streamWriter.WriteRawLong(_records["AcDb:Preview"].Item1.Seeker);
		streamWriter.WriteByte(27);
		streamWriter.WriteByte(25);
		streamWriter.WriteBytes(LittleEndianConverter.Instance.GetBytes(getFileCodePage()));
		streamWriter.WriteBytes(LittleEndianConverter.Instance.GetBytes(6));
		foreach (DwgSectionLocatorRecord item in _records.Values.Select(((DwgSectionLocatorRecord, MemoryStream) r) => r.Item1))
		{
			if (item.Number.HasValue)
			{
				writeRecord(streamWriter, item);
			}
		}
		streamWriter.WriteSpearShift();
		streamWriter.WriteRawShort((short)CRC8StreamHandler.GetCRCValue(49345, memoryStream.GetBuffer(), 0L, memoryStream.Length));
		streamWriter.WriteBytes(_endSentinel);
		_stream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}

	private void writeRecord(IDwgStreamWriter writer, DwgSectionLocatorRecord record)
	{
		writer.WriteByte((byte)record.Number.Value);
		writer.WriteRawLong(record.Seeker);
		writer.WriteRawLong(record.Size);
	}

	private void writeRecordStreams()
	{
		foreach (MemoryStream item in _records.Values.Select(((DwgSectionLocatorRecord, MemoryStream) r) => r.Item2))
		{
			_stream.Write(item.GetBuffer(), 0, (int)item.Length);
		}
	}
}
