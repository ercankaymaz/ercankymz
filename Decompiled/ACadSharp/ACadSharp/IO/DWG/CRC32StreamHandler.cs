using System.IO;

namespace ACadSharp.IO.DWG;

internal class CRC32StreamHandler : Stream
{
	private Stream _stream;

	private uint _seed;

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

	public uint Seed => ~_seed;

	public CRC32StreamHandler(byte[] arr, uint seed)
	{
		int num = 1;
		for (int i = 0; i < arr.Length; i++)
		{
			num *= 214013;
			num += 2531011;
			byte b = (byte)(num >> 16);
			arr[i] ^= b;
		}
		_stream = new MemoryStream(arr);
		_seed = ~seed;
	}

	public CRC32StreamHandler(Stream stream, uint seed)
	{
		_stream = stream;
		_seed = ~seed;
	}

	public override void Flush()
	{
		_stream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int result = _stream.Read(buffer, offset, count);
		int num = offset + count;
		for (int i = offset; i < num; i++)
		{
			_seed = (_seed >> 8) ^ CRC.Crc32Table[(_seed ^ buffer[i]) & 0xFF];
		}
		return result;
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
			_seed = (_seed >> 8) ^ CRC.Crc32Table[(_seed ^ buffer[i]) & 0xFF];
		}
		_stream.Write(buffer, offset, count);
	}
}
