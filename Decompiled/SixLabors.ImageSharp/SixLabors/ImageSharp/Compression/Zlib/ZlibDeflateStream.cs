using System;
using System.IO;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Compression.Zlib;

internal sealed class ZlibDeflateStream : Stream
{
	private readonly Stream rawStream;

	private uint adler = 1u;

	private bool isDisposed;

	private DeflaterOutputStream deflateStream;

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => rawStream.CanWrite;

	public override long Length => rawStream.Length;

	public override long Position
	{
		get
		{
			return rawStream.Position;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public ZlibDeflateStream(MemoryAllocator memoryAllocator, Stream stream, DeflateCompressionLevel level)
		: this(memoryAllocator, stream, (PngCompressionLevel)level)
	{
	}

	public ZlibDeflateStream(MemoryAllocator memoryAllocator, Stream stream, PngCompressionLevel level)
	{
		rawStream = stream;
		int num = 218;
		if (level >= PngCompressionLevel.Level5 && level <= PngCompressionLevel.Level6)
		{
			num = 156;
		}
		else if (level >= PngCompressionLevel.Level3 && level <= PngCompressionLevel.Level4)
		{
			num = 94;
		}
		else if (level <= PngCompressionLevel.Level2)
		{
			num = 1;
		}
		num -= (30720 + num) % 31;
		if (num < 0)
		{
			num += 31;
		}
		rawStream.WriteByte(120);
		rawStream.WriteByte((byte)num);
		deflateStream = new DeflaterOutputStream(memoryAllocator, rawStream, (int)level);
	}

	public override void Flush()
	{
		deflateStream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override void Write(byte[] buffer, int offset, int count)
	{
		deflateStream.Write(buffer, offset, count);
		adler = Adler32.Calculate(adler, MemoryExtensions.AsSpan<byte>(buffer, offset, count));
	}

	protected override void Dispose(bool disposing)
	{
		if (!isDisposed)
		{
			if (disposing)
			{
				deflateStream.Dispose();
				uint num = adler;
				rawStream.WriteByte((byte)((num >> 24) & 0xFF));
				rawStream.WriteByte((byte)((num >> 16) & 0xFF));
				rawStream.WriteByte((byte)((num >> 8) & 0xFF));
				rawStream.WriteByte((byte)(num & 0xFF));
			}
			base.Dispose(disposing);
			isDisposed = true;
		}
	}
}
