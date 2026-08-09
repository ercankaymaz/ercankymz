using System.IO;

namespace ACadSharp.IO.DWG;

internal class CRC8StreamHandler : Stream
{
	private Stream _stream;

	public override bool CanRead => _stream.CanRead;

	public override bool CanSeek => _stream.CanSeek;

	public override bool CanWrite => _stream.CanWrite;

	public override long Length => _stream.Length;

	public override long Position
	{
		get
		{
			return _stream.Position;
		}
		set
		{
			_stream.Position = value;
		}
	}

	public ushort Seed { get; private set; }

	public CRC8StreamHandler(Stream stream, ushort seed)
	{
		_stream = stream;
		Seed = seed;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int result = _stream.Read(buffer, offset, count);
		int num = offset + count;
		for (int i = offset; i < num; i++)
		{
			Seed = decode(Seed, buffer[i]);
		}
		return result;
	}

	public override void Flush()
	{
		_stream.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return _stream.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		_stream.SetLength(value);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		int num = offset + count;
		for (int i = offset; i < num; i++)
		{
			Seed = decode(Seed, buffer[i]);
		}
		_stream.Write(buffer, offset, count);
	}

	public static ushort GetCRCValue(ushort seed, byte[] buffer, long startPos, long endPos)
	{
		ushort num = seed;
		int num2 = (int)startPos;
		while (endPos-- > 0)
		{
			num = decode(num, buffer[num2]);
			num2++;
		}
		return num;
	}

	private static ushort decode(ushort key, byte value)
	{
		int num = value ^ (byte)key;
		key = (ushort)((key >>> 8) ^ CRC.CrcTable[num]);
		return key;
	}
}
