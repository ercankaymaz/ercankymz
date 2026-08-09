using System;
using System.IO;

namespace UglyToad.PdfPig.Core;

public sealed class StreamInputBytes : IInputBytes, IDisposable
{
	private readonly Stream stream;

	private readonly bool shouldDispose;

	private byte? peekByte;

	private bool isAtEnd;

	public long CurrentOffset
	{
		get
		{
			if (!peekByte.HasValue)
			{
				return stream.Position;
			}
			return stream.Position - 1;
		}
	}

	public byte CurrentByte { get; private set; }

	public long Length => stream.Length;

	public StreamInputBytes(Stream stream, bool shouldDispose = true)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (!stream.CanRead)
		{
			throw new ArgumentException("The provided stream did not support reading.", "stream");
		}
		if (!stream.CanSeek)
		{
			throw new ArgumentException("The provided stream did not support seeking.", "stream");
		}
		this.stream = stream;
		this.shouldDispose = shouldDispose;
	}

	public bool MoveNext()
	{
		int num = ((int?)peekByte) ?? stream.ReadByte();
		peekByte = null;
		if (num == -1)
		{
			isAtEnd = true;
			CurrentByte = 0;
			return false;
		}
		CurrentByte = (byte)num;
		return true;
	}

	public byte? Peek()
	{
		if (!peekByte.HasValue)
		{
			int num = stream.ReadByte();
			if (num < 0)
			{
				return null;
			}
			peekByte = (byte)num;
		}
		return peekByte;
	}

	public bool IsAtEnd()
	{
		return isAtEnd;
	}

	public void Seek(long position)
	{
		isAtEnd = false;
		peekByte = null;
		if (position == 0L)
		{
			stream.Seek(0L, SeekOrigin.Begin);
			CurrentByte = 0;
		}
		else
		{
			stream.Position = position - 1;
			MoveNext();
		}
	}

	public int Read(Span<byte> buffer)
	{
		if (buffer.IsEmpty)
		{
			return 0;
		}
		if (peekByte.HasValue)
		{
			buffer[0] = peekByte.Value;
			peekByte = null;
			return Read(buffer.Slice(1)) + 1;
		}
		int num = stream.Read(buffer);
		if (num > 0)
		{
			CurrentByte = buffer[num - 1];
		}
		isAtEnd = stream.Position == stream.Length;
		return num;
	}

	public void Dispose()
	{
		if (shouldDispose)
		{
			stream?.Dispose();
		}
	}
}
