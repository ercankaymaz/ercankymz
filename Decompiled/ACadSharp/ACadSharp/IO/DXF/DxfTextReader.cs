using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ACadSharp.IO.DXF;

internal class DxfTextReader : DxfStreamReaderBase
{
	private StreamReader _stream;

	protected override Stream baseStream => _stream.BaseStream;

	public DxfTextReader(Stream stream, Encoding encoding)
	{
		_stream = new StreamReader(stream, encoding);
		Start();
	}

	public override void Start()
	{
		base.Start();
		_stream.DiscardBufferedData();
	}

	public override void ReadNext()
	{
		base.ReadNext();
		Position += 2;
	}

	protected override string readStringLine()
	{
		base.ValueRaw = _stream.ReadLine();
		return base.ValueRaw;
	}

	protected override DxfCode readCode()
	{
		if (int.TryParse(readStringLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return (DxfCode)result;
		}
		Position++;
		return DxfCode.Invalid;
	}

	protected override bool lineAsBool()
	{
		if (byte.TryParse(readStringLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result > 0;
		}
		return false;
	}

	protected override double lineAsDouble()
	{
		if (double.TryParse(readStringLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		return 0.0;
	}

	protected override short lineAsShort()
	{
		if (short.TryParse(readStringLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		return 0;
	}

	protected override int lineAsInt()
	{
		if (int.TryParse(readStringLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		return 0;
	}

	protected override long lineAsLong()
	{
		if (long.TryParse(readStringLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		return 0L;
	}

	protected override ulong lineAsHandle()
	{
		if (ulong.TryParse(readStringLine(), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		return 0uL;
	}

	protected override byte[] lineAsBinaryChunk()
	{
		string text = readStringLine();
		List<byte> list = new List<byte>();
		int num = 0;
		while (num < text.Length)
		{
			if (byte.TryParse($"{text[num]}{text[++num]}", NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
			{
				list.Add(result);
				num++;
				continue;
			}
			return new byte[0];
		}
		return list.ToArray();
	}
}
