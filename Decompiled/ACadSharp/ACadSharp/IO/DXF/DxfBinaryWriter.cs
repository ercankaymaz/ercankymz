using System;
using System.Globalization;
using System.IO;
using ACadSharp.Exceptions;

namespace ACadSharp.IO.DXF;

internal class DxfBinaryWriter : DxfStreamWriterBase
{
	private BinaryWriter _stream;

	public DxfBinaryWriter(BinaryWriter stream)
	{
		_stream = stream;
		byte[] buffer = new byte[22]
		{
			65, 117, 116, 111, 67, 65, 68, 32, 66, 105,
			110, 97, 114, 121, 32, 68, 88, 70, 13, 10,
			26, 0
		};
		_stream.Write(buffer);
	}

	public override void Dispose()
	{
		_stream.Dispose();
	}

	public override void Flush()
	{
		_stream.Flush();
	}

	public override void Close()
	{
		_stream.Close();
	}

	protected override void writeDxfCode(int code)
	{
		_stream.Write((short)code);
	}

	protected override void writeValue(int code, object value)
	{
		switch (GroupCodeValue.TransformValue(code))
		{
		case GroupCodeValueType.String:
		case GroupCodeValueType.Comment:
		case GroupCodeValueType.ExtendedDataString:
			_stream.Write(value.ToString().ToCharArray());
			_stream.Write('\0');
			break;
		case GroupCodeValueType.Point3D:
		case GroupCodeValueType.Double:
		case GroupCodeValueType.ExtendedDataDouble:
			_stream.Write(Convert.ToDouble(value));
			break;
		case GroupCodeValueType.Byte:
		case GroupCodeValueType.Int16:
		case GroupCodeValueType.ExtendedDataInt16:
			_stream.Write(Convert.ToInt16(value));
			break;
		case GroupCodeValueType.Int32:
		case GroupCodeValueType.ExtendedDataInt32:
			_stream.Write(Convert.ToInt32(value));
			break;
		case GroupCodeValueType.Int64:
			_stream.Write(Convert.ToInt64(value));
			break;
		case GroupCodeValueType.Handle:
		case GroupCodeValueType.ObjectId:
		case GroupCodeValueType.ExtendedDataHandle:
			_stream.Write(((ulong)value).ToString("X", CultureInfo.InvariantCulture).ToCharArray());
			_stream.Write('\0');
			break;
		case GroupCodeValueType.Bool:
			_stream.Write(Convert.ToByte(value));
			break;
		case GroupCodeValueType.Chunk:
		case GroupCodeValueType.ExtendedDataChunk:
		{
			byte[] array = value as byte[];
			_stream.Write((byte)array.Length);
			_stream.Write(array);
			break;
		}
		default:
			throw new DxfException($"Code: {code} doesn't belong to any GroupCodeValueType");
		}
	}
}
