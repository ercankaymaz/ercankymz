using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ACadSharp.IO.DXF;

internal class DxfBinaryReader : DxfStreamReaderBase
{
	public const string Sentinel = "AutoCAD Binary DXF\r\n\u001a\0";

	protected BinaryReader _stream;

	private Encoding _encoding;

	public override int Position => (int)baseStream.Position;

	protected override Stream baseStream => _stream.BaseStream;

	public DxfBinaryReader(Stream stream)
		: this(stream, Encoding.ASCII)
	{
	}

	public DxfBinaryReader(Stream stream, Encoding encoding)
	{
		_encoding = encoding;
		_stream = new BinaryReader(stream, _encoding);
		Start();
	}

	public override void Start()
	{
		base.Start();
		byte[] bytes = _stream.ReadBytes(22);
		Encoding.ASCII.GetString(bytes);
	}

	protected override string readStringLine()
	{
		byte b = _stream.ReadByte();
		List<byte> list = new List<byte>();
		while (b != 0)
		{
			list.Add(b);
			b = _stream.ReadByte();
		}
		base.ValueRaw = _encoding.GetString(list.ToArray(), 0, list.Count);
		return base.ValueRaw;
	}

	protected override DxfCode readCode()
	{
		return (DxfCode)_stream.ReadInt16();
	}

	protected override bool lineAsBool()
	{
		return _stream.ReadByte() > 0;
	}

	protected override double lineAsDouble()
	{
		return _stream.ReadDouble();
	}

	protected override short lineAsShort()
	{
		return _stream.ReadInt16();
	}

	protected override int lineAsInt()
	{
		return _stream.ReadInt32();
	}

	protected override long lineAsLong()
	{
		return _stream.ReadInt64();
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
		byte count = _stream.ReadByte();
		return _stream.ReadBytes(count);
	}
}
