using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.IO;

internal sealed class ChunkedMemoryStream : Stream
{
	private sealed class MemoryChunkBuffer : IDisposable
	{
		private readonly List<MemoryChunk> memoryChunks = new List<MemoryChunk>();

		private readonly MemoryAllocator allocator;

		private readonly int allocatorCapacity;

		private bool isDisposed;

		public int ChunkCount => memoryChunks.Count;

		public long Length { get; private set; }

		public MemoryChunk this[int index] => memoryChunks[index];

		public MemoryChunkBuffer(MemoryAllocator allocator)
		{
			allocatorCapacity = allocator.GetBufferCapacityInBytes();
			this.allocator = allocator;
		}

		public void Expand()
		{
			IMemoryOwner<byte> buffer = allocator.Allocate<byte>(Math.Min(allocatorCapacity, GetChunkSize(ChunkCount)));
			MemoryChunk memoryChunk = new MemoryChunk(buffer)
			{
				Length = buffer.Length()
			};
			memoryChunks.Add(memoryChunk);
			Length += memoryChunk.Length;
		}

		public void Dispose()
		{
			if (isDisposed)
			{
				return;
			}
			foreach (MemoryChunk memoryChunk in memoryChunks)
			{
				memoryChunk.Dispose();
			}
			memoryChunks.Clear();
			Length = 0L;
			isDisposed = true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int GetChunkSize(int i)
		{
			if (i >= 16)
			{
				return 4194304;
			}
			return 131072 * (1 << (int)((uint)i / 4u));
		}
	}

	private sealed class MemoryChunk : IDisposable
	{
		private bool isDisposed;

		public IMemoryOwner<byte> Buffer { get; }

		public int Length { get; init; }

		public MemoryChunk(IMemoryOwner<byte> buffer)
		{
			Buffer = buffer;
		}

		public void Dispose()
		{
			if (!isDisposed)
			{
				Buffer.Dispose();
				isDisposed = true;
			}
		}
	}

	private readonly MemoryChunkBuffer memoryChunkBuffer;

	private long length;

	private long position;

	private int bufferIndex;

	private int chunkIndex;

	private bool isDisposed;

	public override bool CanRead => !isDisposed;

	public override bool CanSeek => !isDisposed;

	public override bool CanWrite => !isDisposed;

	public override long Length
	{
		get
		{
			EnsureNotDisposed();
			return length;
		}
	}

	public override long Position
	{
		get
		{
			EnsureNotDisposed();
			return position;
		}
		set
		{
			EnsureNotDisposed();
			SetPosition(value);
		}
	}

	public ChunkedMemoryStream(MemoryAllocator allocator)
	{
		memoryChunkBuffer = new MemoryChunkBuffer(allocator);
	}

	public override void Flush()
	{
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		EnsureNotDisposed();
		Position = origin switch
		{
			SeekOrigin.Begin => (int)offset, 
			SeekOrigin.Current => (int)(Position + offset), 
			SeekOrigin.End => (int)(Length + offset), 
			_ => throw new ArgumentOutOfRangeException("offset"), 
		};
		return position;
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override int ReadByte()
	{
		Unsafe.SkipInit<byte>(out var value);
		if (Read(MemoryMarshal.CreateSpan<byte>(ref value, 1)) != 1)
		{
			return -1;
		}
		return value;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		Guard.NotNull(buffer, "buffer");
		Guard.MustBeGreaterThanOrEqualTo(offset, 0, "offset");
		Guard.MustBeGreaterThanOrEqualTo(count, 0, "count");
		Guard.IsFalse(buffer.Length - offset < count, "buffer", "Offset subtracted from the buffer length is less than count.");
		return Read(MemoryExtensions.AsSpan<byte>(buffer, offset, count));
	}

	public override int Read(Span<byte> buffer)
	{
		EnsureNotDisposed();
		int num = 0;
		int num2 = buffer.Length;
		long num3 = length - position;
		if (num3 <= 0)
		{
			return 0;
		}
		if (num3 > num2)
		{
			num3 = num2;
		}
		int num4 = (int)num3;
		int num5 = 0;
		while (num4 > 0 && bufferIndex != memoryChunkBuffer.Length)
		{
			bool flag = false;
			MemoryChunk memoryChunk = memoryChunkBuffer[bufferIndex];
			int num6 = num4;
			int num7 = memoryChunk.Length - chunkIndex;
			if (num6 >= num7)
			{
				num6 = num7;
				flag = true;
			}
			Span<byte> span = memoryChunk.Buffer.Memory.Span;
			span = span.Slice(chunkIndex, num6);
			span.CopyTo(buffer.Slice(num, num6));
			num4 -= num6;
			num += num6;
			num5 += num6;
			if (flag)
			{
				chunkIndex = 0;
				bufferIndex++;
			}
			else
			{
				chunkIndex += num6;
			}
		}
		position += num5;
		return num5;
	}

	public override void WriteByte(byte value)
	{
		Write(MemoryMarshal.CreateSpan<byte>(ref value, 1));
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		Guard.NotNull(buffer, "buffer");
		Guard.MustBeGreaterThanOrEqualTo(offset, 0, "offset");
		Guard.MustBeGreaterThanOrEqualTo(count, 0, "count");
		Guard.IsFalse(buffer.Length - offset < count, "buffer", "Offset subtracted from the buffer length is less than count.");
		Write(MemoryExtensions.AsSpan<byte>(buffer, offset, count));
	}

	public override void Write(ReadOnlySpan<byte> buffer)
	{
		EnsureNotDisposed();
		int num = 0;
		int num2 = buffer.Length;
		for (long num3 = memoryChunkBuffer.Length - position; num3 < num2; num3 = memoryChunkBuffer.Length - position)
		{
			memoryChunkBuffer.Expand();
		}
		int num4 = num2;
		int num5 = 0;
		while (num4 > 0 && bufferIndex != memoryChunkBuffer.Length)
		{
			bool flag = false;
			MemoryChunk memoryChunk = memoryChunkBuffer[bufferIndex];
			int num6 = num4;
			int num7 = memoryChunk.Length - chunkIndex;
			if (num6 >= num7)
			{
				num6 = num7;
				flag = true;
			}
			buffer.Slice(num, num6).CopyTo(memoryChunk.Buffer.Slice(chunkIndex, num6));
			num4 -= num6;
			num += num6;
			num5 += num6;
			if (flag)
			{
				chunkIndex = 0;
				bufferIndex++;
			}
			else
			{
				chunkIndex += num6;
			}
		}
		position += num5;
		length += num5;
	}

	public void WriteTo(Stream stream)
	{
		Guard.NotNull(stream, "stream");
		EnsureNotDisposed();
		Position = 0L;
		long num = length - position;
		if (num <= 0)
		{
			return;
		}
		int num2 = (int)num;
		int num3 = 0;
		while (num2 > 0 && bufferIndex != memoryChunkBuffer.Length)
		{
			bool flag = false;
			MemoryChunk memoryChunk = memoryChunkBuffer[bufferIndex];
			int num4 = num2;
			int num5 = memoryChunk.Length - chunkIndex;
			if (num4 >= num5)
			{
				num4 = num5;
				flag = true;
			}
			stream.Write(memoryChunk.Buffer.Memory.Span.Slice(chunkIndex, num4));
			num2 -= num4;
			num3 += num4;
			if (flag)
			{
				chunkIndex = 0;
				bufferIndex++;
			}
			else
			{
				chunkIndex += num4;
			}
		}
		position += num3;
	}

	public byte[] ToArray()
	{
		EnsureNotDisposed();
		long num = position;
		byte[] array = new byte[length];
		Position = 0L;
		Read(array, 0, array.Length);
		Position = num;
		return array;
	}

	protected override void Dispose(bool disposing)
	{
		if (isDisposed)
		{
			return;
		}
		try
		{
			isDisposed = true;
			if (disposing)
			{
				memoryChunkBuffer.Dispose();
			}
			bufferIndex = 0;
			chunkIndex = 0;
			position = 0L;
			length = 0L;
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void SetPosition(long value)
	{
		if (value < 0)
		{
			throw new ArgumentOutOfRangeException("value");
		}
		position = value;
		int num = 0;
		long num2 = value;
		if (num2 > 0 && num2 >= memoryChunkBuffer.Length)
		{
			bufferIndex = memoryChunkBuffer.ChunkCount - 1;
			chunkIndex = memoryChunkBuffer[bufferIndex].Length - 1;
			return;
		}
		while (num2 != 0L)
		{
			int num3 = memoryChunkBuffer[num].Length;
			if (num2 < num3)
			{
				break;
			}
			num2 -= num3;
			num++;
		}
		bufferIndex = num;
		chunkIndex = (int)num2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void EnsureNotDisposed()
	{
		if (isDisposed)
		{
			ThrowDisposed();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ThrowDisposed()
	{
		throw new ObjectDisposedException("ChunkedMemoryStream", "The stream is closed.");
	}
}
