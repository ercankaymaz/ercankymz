using System;
using System.Buffers.Binary;
using System.IO;

namespace UglyToad.PdfPig.Images.Png;

internal sealed class PngStreamWriteHelper : Stream
{
	private readonly Stream inner;

	private readonly Crc32 crc = new Crc32();

	public override bool CanRead => inner.CanRead;

	public override bool CanSeek => inner.CanSeek;

	public override bool CanWrite => inner.CanWrite;

	public override long Length => inner.Length;

	public override long Position
	{
		get
		{
			return inner.Position;
		}
		set
		{
			inner.Position = value;
		}
	}

	public PngStreamWriteHelper(Stream inner)
	{
		this.inner = inner ?? throw new ArgumentNullException("inner");
	}

	public override void Flush()
	{
		inner.Flush();
	}

	public void WriteChunkHeader(ReadOnlySpan<byte> header)
	{
		crc.Reset();
		Write(header);
	}

	public void WriteChunkLength(int length)
	{
		StreamHelper.WriteBigEndianInt32(inner, length);
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return inner.Read(buffer, offset, count);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return inner.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		inner.SetLength(value);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		crc.Append(buffer.AsSpan(offset, count));
		inner.Write(buffer, offset, count);
	}

	public void Write(ReadOnlySpan<byte> buffer)
	{
		crc.Append(buffer);
		inner.Write(buffer);
	}

	public void WriteCrc()
	{
		Span<byte> span = stackalloc byte[4];
		uint currentHashAsUInt = crc.GetCurrentHashAsUInt32();
		BinaryPrimitives.WriteUInt32BigEndian(span, currentHashAsUInt);
		inner.Write(span);
	}
}
