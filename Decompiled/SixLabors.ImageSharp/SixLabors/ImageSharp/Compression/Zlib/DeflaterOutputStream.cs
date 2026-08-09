using System;
using System.Buffers;
using System.IO;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Compression.Zlib;

internal sealed class DeflaterOutputStream : Stream
{
	private const int BufferLength = 512;

	private IMemoryOwner<byte> memoryOwner;

	private readonly Memory<byte> buffer;

	private Deflater deflater;

	private readonly Stream rawStream;

	private bool isDisposed;

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

	public DeflaterOutputStream(MemoryAllocator memoryAllocator, Stream rawStream, int compressionLevel)
	{
		this.rawStream = rawStream;
		memoryOwner = memoryAllocator.Allocate<byte>(512);
		buffer = memoryOwner.Memory;
		deflater = new Deflater(memoryAllocator, compressionLevel);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override int ReadByte()
	{
		throw new NotSupportedException();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}

	public override void Flush()
	{
		deflater.Flush();
		Deflate(flushing: true);
		rawStream.Flush();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		deflater.SetInput(buffer, offset, count);
		Deflate();
	}

	private void Deflate()
	{
		Deflate(flushing: false);
	}

	private void Deflate(bool flushing)
	{
		while (flushing || !deflater.IsNeedingInput)
		{
			int num = deflater.Deflate(buffer.Span, 0, 512);
			if (num <= 0)
			{
				break;
			}
			rawStream.Write(buffer.Span.Slice(0, num));
		}
		if (!deflater.IsNeedingInput)
		{
			DeflateThrowHelper.ThrowNoDeflate();
		}
	}

	private void Finish()
	{
		deflater.Finish();
		while (!deflater.IsFinished)
		{
			int num = deflater.Deflate(buffer.Span, 0, 512);
			if (num <= 0)
			{
				break;
			}
			rawStream.Write(buffer.Span.Slice(0, num));
		}
		if (!deflater.IsFinished)
		{
			DeflateThrowHelper.ThrowNoDeflate();
		}
		rawStream.Flush();
	}

	protected override void Dispose(bool disposing)
	{
		if (!isDisposed)
		{
			if (disposing)
			{
				Finish();
				deflater.Dispose();
				memoryOwner.Dispose();
			}
			isDisposed = true;
			base.Dispose(disposing);
		}
	}
}
