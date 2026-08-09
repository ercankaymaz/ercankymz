using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using SixLabors.ImageSharp.IO;

namespace SixLabors.ImageSharp.Compression.Zlib;

internal sealed class ZlibInflateStream : Stream
{
	private static readonly byte[] ChecksumBuffer = new byte[4];

	private static readonly Func<int> GetDataNoOp = () => 0;

	private readonly BufferedReadStream innerStream;

	private bool isDisposed;

	private int currentDataRemaining;

	private readonly Func<int> getData;

	public override bool CanRead => innerStream.CanRead;

	public override bool CanSeek => false;

	public override bool CanWrite
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override long Length
	{
		get
		{
			throw new NotSupportedException();
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException();
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public DeflateStream? CompressedStream { get; private set; }

	public ZlibInflateStream(BufferedReadStream innerStream)
		: this(innerStream, GetDataNoOp)
	{
	}

	public ZlibInflateStream(BufferedReadStream innerStream, Func<int> getData)
	{
		this.innerStream = innerStream;
		this.getData = getData;
	}

	[MemberNotNullWhen(true, "CompressedStream")]
	public bool AllocateNewBytes(int bytes, bool isCriticalChunk)
	{
		currentDataRemaining = bytes;
		if (CompressedStream == null)
		{
			return InitializeInflateStream(isCriticalChunk);
		}
		return true;
	}

	public override void Flush()
	{
		throw new NotSupportedException();
	}

	public override int ReadByte()
	{
		currentDataRemaining--;
		return innerStream.ReadByte();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (currentDataRemaining == 0)
		{
			currentDataRemaining = getData();
			if (currentDataRemaining == 0)
			{
				return 0;
			}
		}
		int num = Math.Min(count, currentDataRemaining);
		currentDataRemaining -= num;
		int num2 = innerStream.Read(buffer, offset, num);
		long length = innerStream.Length;
		int num3 = 0;
		offset += num2;
		while (currentDataRemaining == 0 && num2 < count)
		{
			currentDataRemaining = getData();
			if (currentDataRemaining == 0)
			{
				return num2;
			}
			offset += num3;
			if (offset >= length || offset >= count)
			{
				return num2;
			}
			num = Math.Min(count - num2, currentDataRemaining);
			currentDataRemaining -= num;
			num3 = innerStream.Read(buffer, offset, num);
			if (num3 == 0)
			{
				return num2;
			}
			num2 += num3;
		}
		return num2;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}

	protected override void Dispose(bool disposing)
	{
		if (!isDisposed)
		{
			if (disposing && CompressedStream != null)
			{
				CompressedStream.Dispose();
				CompressedStream = null;
			}
			base.Dispose(disposing);
			isDisposed = true;
		}
	}

	[MemberNotNullWhen(true, "CompressedStream")]
	private bool InitializeInflateStream(bool isCriticalChunk)
	{
		int num = innerStream.ReadByte();
		int num2 = innerStream.ReadByte();
		currentDataRemaining -= 2;
		if (num == -1 || num2 == -1)
		{
			return false;
		}
		if ((num & 0xF) == 8)
		{
			int num3 = (num & 0xF0) >> 4;
			if (num3 > 7)
			{
				if (isCriticalChunk)
				{
					throw new ImageFormatException($"Invalid window size for ZLIB header: cinfo={num3}");
				}
				return false;
			}
			if ((num2 & 0x20) != 0)
			{
				if (innerStream.Read(ChecksumBuffer, 0, 4) != 4)
				{
					return false;
				}
				currentDataRemaining -= 4;
			}
			CompressedStream = new DeflateStream(this, CompressionMode.Decompress, leaveOpen: true);
			return true;
		}
		if (isCriticalChunk)
		{
			throw new ImageFormatException($"Bad method for ZLIB header: cmf={num}");
		}
		return false;
	}
}
