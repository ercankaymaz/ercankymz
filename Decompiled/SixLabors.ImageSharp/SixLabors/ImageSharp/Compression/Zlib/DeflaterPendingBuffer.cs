using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Compression.Zlib;

internal sealed class DeflaterPendingBuffer : IDisposable
{
	private readonly Memory<byte> buffer;

	private unsafe readonly byte* pinnedBuffer;

	private IMemoryOwner<byte> bufferMemoryOwner;

	private MemoryHandle bufferMemoryHandle;

	private int start;

	private int end;

	private uint bits;

	private bool isDisposed;

	public int BitCount { get; private set; }

	public bool IsFlushed => end == 0;

	public unsafe DeflaterPendingBuffer(MemoryAllocator memoryAllocator)
	{
		bufferMemoryOwner = memoryAllocator.Allocate<byte>(65536);
		buffer = bufferMemoryOwner.Memory;
		bufferMemoryHandle = buffer.Pin();
		pinnedBuffer = (byte*)bufferMemoryHandle.Pointer;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Reset()
	{
		int num = (BitCount = 0);
		start = (end = num);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void WriteShort(int value)
	{
		byte* num = pinnedBuffer;
		num[end++] = (byte)value;
		num[end++] = (byte)(value >> 8);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void WriteBlock(ReadOnlySpan<byte> block, int offset, int length)
	{
		Unsafe.CopyBlockUnaligned(ref buffer.Span[end], ref MemoryMarshal.GetReference<byte>(block.Slice(offset, block.Length - offset)), (uint)length);
		end += length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void AlignToByte()
	{
		if (BitCount > 0)
		{
			byte* ptr = pinnedBuffer;
			ptr[end++] = (byte)bits;
			if (BitCount > 8)
			{
				ptr[end++] = (byte)(bits >> 8);
			}
		}
		bits = 0u;
		BitCount = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void WriteBits(int b, int count)
	{
		bits |= (uint)(b << BitCount);
		BitCount += count;
		if (BitCount >= 16)
		{
			byte* num = pinnedBuffer;
			num[end++] = (byte)bits;
			num[end++] = (byte)(bits >> 8);
			bits >>= 16;
			BitCount -= 16;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void WriteShortMSB(int value)
	{
		byte* num = pinnedBuffer;
		num[end++] = (byte)(value >> 8);
		num[end++] = (byte)value;
	}

	public unsafe int Flush(Span<byte> output, int offset, int length)
	{
		if (BitCount >= 8)
		{
			pinnedBuffer[end++] = (byte)bits;
			bits >>= 8;
			BitCount -= 8;
		}
		if (length > end - start)
		{
			length = end - start;
			Unsafe.CopyBlockUnaligned(ref output[offset], ref buffer.Span[start], (uint)length);
			start = 0;
			end = 0;
		}
		else
		{
			Unsafe.CopyBlockUnaligned(ref output[offset], ref buffer.Span[start], (uint)length);
			start += length;
		}
		return length;
	}

	public void Dispose()
	{
		if (!isDisposed)
		{
			bufferMemoryHandle.Dispose();
			bufferMemoryOwner.Dispose();
			isDisposed = true;
		}
	}
}
