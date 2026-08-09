using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ACadSharp.IO;

internal class HugeMemoryStream : MemoryStream
{
	private const long _maxChunkSize = 1073741824L;

	private const int _maxChunkShift = 30;

	private const long _maxChunkMask = 1073741823L;

	private byte[] _currentChunk;

	private int _currentInChunk;

	private readonly long _length;

	private long _position;

	private readonly List<byte[]> _chunks;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => true;

	public override long Length => _length;

	public override long Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
			_currentChunk = _chunks[(int)(value >> 30)];
			_currentInChunk = (int)(value & 0x3FFFFFFF);
		}
	}

	public static MemoryStream Create(long length)
	{
		if (length <= int.MaxValue)
		{
			return new MemoryStream(new byte[(int)length], 0, (int)length, writable: true, publiclyVisible: true);
		}
		return new HugeMemoryStream(length);
	}

	public HugeMemoryStream(long length)
	{
		_length = length;
		_position = 0L;
		_chunks = new List<byte[]>();
		long num = length;
		while (num > 0)
		{
			int num2 = (int)Math.Min(num, 1073741824L);
			_chunks.Add(new byte[num2]);
			num -= num2;
		}
		Position = 0L;
	}

	public HugeMemoryStream(List<byte[]> chunks)
	{
		_chunks = chunks;
		_length = ((IEnumerable<byte[]>)chunks).Sum((Func<byte[], long>)((byte[] x) => x.Length));
		Position = 0L;
	}

	public override void Flush()
	{
		throw new NotImplementedException();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (count == 1)
		{
			buffer[offset] = _currentChunk[_currentInChunk];
			Position++;
			return 1;
		}
		if ((long)(_currentInChunk + count) > 1073741824L)
		{
			int num = (int)(1073741824L - (long)_currentInChunk);
			Buffer.BlockCopy(_currentChunk, _currentInChunk, buffer, offset, num);
			Position += num;
			return num + Read(buffer, offset + num, count - num);
		}
		Buffer.BlockCopy(_currentChunk, _currentInChunk, buffer, offset, count);
		Position += count;
		return count;
	}

	public override int ReadByte()
	{
		byte result = _currentChunk[_currentInChunk];
		Position++;
		return result;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (count == 1)
		{
			_currentChunk[_currentInChunk] = buffer[offset];
			Position++;
		}
		else if ((long)(_currentInChunk + count) > 1073741824L)
		{
			int num = (int)(1073741824L - (long)_currentInChunk);
			Buffer.BlockCopy(buffer, offset, _currentChunk, _currentInChunk, num);
			Position += num;
			Write(buffer, offset + num, count - num);
		}
		else
		{
			Buffer.BlockCopy(buffer, offset, _currentChunk, _currentInChunk, count);
			Position += count;
		}
	}

	public override void WriteByte(byte value)
	{
		_currentChunk[_currentInChunk] = value;
		Position++;
	}

	internal HugeMemoryStream Clone()
	{
		return new HugeMemoryStream(_chunks);
	}

	internal static Stream Clone(Stream memoryStream)
	{
		if (memoryStream is HugeMemoryStream hugeMemoryStream)
		{
			return hugeMemoryStream.Clone();
		}
		if (memoryStream is MemoryStream memoryStream2)
		{
			return new MemoryStream(memoryStream2.GetBuffer());
		}
		throw new NotSupportedException("The provided stream type is not supported for cloning.");
	}
}
