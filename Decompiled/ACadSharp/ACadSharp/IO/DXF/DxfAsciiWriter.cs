using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ACadSharp.IO.DXF;

internal class DxfAsciiWriter : DxfStreamWriterBase
{
	private TextWriter _stream;

	public DxfAsciiWriter(StreamWriter stream)
	{
		_stream = stream;
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
		if (code < 10)
		{
			_stream.WriteLine("  {0}", code.ToString(CultureInfo.InvariantCulture));
		}
		else if (code < 100)
		{
			_stream.WriteLine(" {0}", code.ToString(CultureInfo.InvariantCulture));
		}
		else
		{
			_stream.WriteLine(code.ToString(CultureInfo.InvariantCulture));
		}
	}

	protected override void writeValue(int code, object value)
	{
		switch (GroupCodeValue.TransformValue(code))
		{
		case GroupCodeValueType.String:
		case GroupCodeValueType.Comment:
		case GroupCodeValueType.ExtendedDataString:
			_stream.WriteLine(value.ToString());
			break;
		case GroupCodeValueType.Point3D:
		case GroupCodeValueType.Double:
		case GroupCodeValueType.ExtendedDataDouble:
			_stream.WriteLine(Convert.ToDouble(value).ToString("0.0###############", CultureInfo.InvariantCulture));
			break;
		case GroupCodeValueType.Byte:
		case GroupCodeValueType.Int16:
		case GroupCodeValueType.ExtendedDataInt16:
			_stream.WriteLine(Convert.ToInt16(value).ToString(CultureInfo.InvariantCulture));
			break;
		case GroupCodeValueType.Int32:
		case GroupCodeValueType.ExtendedDataInt32:
			_stream.WriteLine(Convert.ToInt32(value).ToString(CultureInfo.InvariantCulture));
			break;
		case GroupCodeValueType.Int64:
			_stream.WriteLine(Convert.ToInt64(value).ToString(CultureInfo.InvariantCulture));
			break;
		case GroupCodeValueType.Handle:
		case GroupCodeValueType.ObjectId:
		case GroupCodeValueType.ExtendedDataHandle:
			_stream.WriteLine(((ulong)value).ToString("X", CultureInfo.InvariantCulture));
			break;
		case GroupCodeValueType.Bool:
			_stream.WriteLine(Convert.ToInt16(value).ToString(CultureInfo.InvariantCulture));
			break;
		case GroupCodeValueType.Chunk:
		case GroupCodeValueType.ExtendedDataChunk:
		{
			byte[] array = value as byte[];
			MemoryStream memoryStream = new MemoryStream(array);
			List<string> list = new List<string>();
			int num = array.Length / 64;
			byte[] array2 = new byte[64];
			for (int i = 0; i < num; i++)
			{
				memoryStream.Read(array2, 0, 64);
				list.Add(new string(array2.SelectMany((byte b) => $"{b:X2}").ToArray()));
			}
			int num2 = array.Length % 64;
			if (num2 != 0)
			{
				_ = new byte[num2];
				memoryStream.Read(array2, 0, num2);
				list.Add(new string(array2.SelectMany((byte b) => $"{b:X2}").ToArray()));
			}
			_stream.WriteLine(list.First());
			{
				foreach (string item in list.Skip(1))
				{
					_stream.WriteLine(code);
					_stream.WriteLine(item);
				}
				break;
			}
		}
		default:
			_stream.WriteLine(value.ToString());
			break;
		}
	}
}
