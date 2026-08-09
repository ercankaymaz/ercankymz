using System;
using System.IO;

namespace UglyToad.PdfPig.Filters;

internal sealed class Adler32ChecksumStream : Stream
{
	private readonly Stream underlyingStream;

	public override bool CanRead => underlyingStream.CanRead;

	public override bool CanSeek => false;

	public override bool CanWrite => underlyingStream.CanWrite;

	public override long Length => underlyingStream.Length;

	public override long Position
	{
		get
		{
			return underlyingStream.Position;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public uint Checksum { get; private set; } = 1u;

	public Adler32ChecksumStream(Stream writeStream)
	{
		underlyingStream = writeStream ?? throw new ArgumentNullException("writeStream");
	}

	public override void Flush()
	{
		underlyingStream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = underlyingStream.Read(buffer, offset, count);
		if (num > 0)
		{
			UpdateAdler(buffer.AsSpan(offset, num));
		}
		return num;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new InvalidOperationException();
	}

	public override void SetLength(long value)
	{
		throw new InvalidOperationException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		underlyingStream.Write(buffer, offset, count);
		if (count > 0)
		{
			UpdateAdler(buffer.AsSpan(offset, count));
		}
	}

	private void UpdateAdler(Span<byte> span)
	{
		uint num = Checksum & 0xFFFF;
		uint num2 = (Checksum >> 16) & 0xFFFF;
		Span<byte> span2 = span;
		for (int i = 0; i < span2.Length; i++)
		{
			byte b = span2[i];
			num = (num + b) % 65521;
			num2 = (num2 + num) % 65521;
		}
		Checksum = (num2 << 16) | num;
	}

	public override void Close()
	{
		underlyingStream.Close();
	}
}
