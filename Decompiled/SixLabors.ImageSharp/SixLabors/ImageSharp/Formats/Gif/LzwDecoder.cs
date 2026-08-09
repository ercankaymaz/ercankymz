using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.IO;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Gif;

internal sealed class LzwDecoder : IDisposable
{
	private const int MaxStackSize = 4096;

	private const int MaximumLzwBits = 12;

	private const int NullCode = -1;

	private readonly BufferedReadStream stream;

	private readonly IMemoryOwner<int> prefixOwner;

	private readonly IMemoryOwner<int> suffixOwner;

	private readonly IMemoryOwner<byte> bufferOwner;

	private readonly IMemoryOwner<int> pixelStackOwner;

	private readonly int minCodeSize;

	private readonly int clearCode;

	private readonly int endCode;

	private int code;

	private int codeSize;

	private int codeMask;

	private int availableCode;

	private int oldCode = -1;

	private int bits;

	private int top;

	private int count;

	private int bufferIndex;

	private int data;

	private int first;

	public LzwDecoder(MemoryAllocator memoryAllocator, BufferedReadStream stream, int minCodeSize)
	{
		this.stream = stream ?? throw new ArgumentNullException("stream");
		Guard.IsTrue(IsValidMinCodeSize(minCodeSize), "minCodeSize", "Invalid minimum code size.");
		prefixOwner = memoryAllocator.Allocate<int>(4096, AllocationOptions.Clean);
		suffixOwner = memoryAllocator.Allocate<int>(4096, AllocationOptions.Clean);
		pixelStackOwner = memoryAllocator.Allocate<int>(4097, AllocationOptions.Clean);
		bufferOwner = memoryAllocator.Allocate<byte>(255);
		this.minCodeSize = minCodeSize;
		clearCode = 1 << minCodeSize;
		codeSize = minCodeSize + 1;
		codeMask = (1 << codeSize) - 1;
		endCode = clearCode + 1;
		availableCode = clearCode + 2;
		Span<int> span = suffixOwner.GetSpan().Slice(0, clearCode);
		int i;
		for (i = 0; i < span.Length; i++)
		{
			span[i] = i;
		}
		code = i;
	}

	public static bool IsValidMinCodeSize(int minCodeSize)
	{
		if (minCodeSize < 2 || minCodeSize > 12 || 1 << minCodeSize > 4096)
		{
			return false;
		}
		return true;
	}

	public void DecodePixelRow(Span<byte> indices)
	{
		indices.Clear();
		Span<int> span = prefixOwner.GetSpan();
		Span<int> span2 = suffixOwner.GetSpan();
		Span<int> span3 = pixelStackOwner.GetSpan();
		Span<byte> span4 = bufferOwner.GetSpan();
		BufferedReadStream bufferedReadStream = stream;
		int num = top;
		int num2 = bits;
		int num3 = codeSize;
		int num4 = codeMask;
		int num5 = minCodeSize;
		int num6 = availableCode;
		int num7 = oldCode;
		int num8 = first;
		int num9 = data;
		int num10 = count;
		int num11 = bufferIndex;
		int num12 = code;
		int num13 = clearCode;
		int num14 = endCode;
		int num15 = 0;
		while (num15 < indices.Length)
		{
			if (num == 0)
			{
				if (num2 < num3)
				{
					if (num10 == 0)
					{
						num10 = ReadBlock(bufferedReadStream, span4);
						if (num10 == 0)
						{
							break;
						}
						num11 = 0;
					}
					num9 += span4[num11] << num2;
					num2 += 8;
					num11++;
					num10--;
					continue;
				}
				num12 = num9 & num4;
				num9 >>= num3;
				num2 -= num3;
				if (num12 > num6 || num12 == num14)
				{
					break;
				}
				if (num12 == num13)
				{
					num3 = num5 + 1;
					num4 = (1 << num3) - 1;
					num6 = num13 + 2;
					num7 = -1;
					continue;
				}
				if (num7 == -1)
				{
					span3[num++] = span2[num12];
					num7 = num12;
					num8 = num12;
					continue;
				}
				int num16 = num12;
				if (num12 == num6)
				{
					span3[num++] = num8;
					num12 = num7;
				}
				while (num12 > num13 && num < 4096)
				{
					span3[num++] = span2[num12];
					num12 = span[num12];
				}
				int num17 = span2[num12];
				num8 = num17;
				span3[num++] = num17;
				if (num6 < 4096)
				{
					span[num6] = num7;
					span2[num6] = num8;
					num6++;
					if (num6 == num4 + 1 && num6 < 4096)
					{
						num3++;
						num4 = (1 << num3) - 1;
					}
				}
				num7 = num16;
			}
			num--;
			indices[num15++] = (byte)span3[num];
		}
		top = num;
		bits = num2;
		codeSize = num3;
		codeMask = num4;
		availableCode = num6;
		oldCode = num7;
		first = num8;
		data = num9;
		count = num10;
		bufferIndex = num11;
		code = num12;
	}

	public void SkipIndices(int length)
	{
		Span<int> span = prefixOwner.GetSpan();
		Span<int> span2 = suffixOwner.GetSpan();
		Span<int> span3 = pixelStackOwner.GetSpan();
		Span<byte> span4 = bufferOwner.GetSpan();
		BufferedReadStream bufferedReadStream = stream;
		int num = top;
		int num2 = bits;
		int num3 = codeSize;
		int num4 = codeMask;
		int num5 = minCodeSize;
		int num6 = availableCode;
		int num7 = oldCode;
		int num8 = first;
		int num9 = data;
		int num10 = count;
		int num11 = bufferIndex;
		int num12 = code;
		int num13 = clearCode;
		int num14 = endCode;
		int num15 = 0;
		while (num15 < length)
		{
			if (num == 0)
			{
				if (num2 < num3)
				{
					if (num10 == 0)
					{
						num10 = ReadBlock(bufferedReadStream, span4);
						if (num10 == 0)
						{
							break;
						}
						num11 = 0;
					}
					num9 += span4[num11] << num2;
					num2 += 8;
					num11++;
					num10--;
					continue;
				}
				num12 = num9 & num4;
				num9 >>= num3;
				num2 -= num3;
				if (num12 > num6 || num12 == num14)
				{
					break;
				}
				if (num12 == num13)
				{
					num3 = num5 + 1;
					num4 = (1 << num3) - 1;
					num6 = num13 + 2;
					num7 = -1;
					continue;
				}
				if (num7 == -1)
				{
					span3[num++] = span2[num12];
					num7 = num12;
					num8 = num12;
					continue;
				}
				int num16 = num12;
				if (num12 == num6)
				{
					span3[num++] = num8;
					num12 = num7;
				}
				while (num12 > num13 && num < 4096)
				{
					span3[num++] = span2[num12];
					num12 = span[num12];
				}
				int num17 = span2[num12];
				num8 = num17;
				span3[num++] = num17;
				if (num6 < 4096)
				{
					span[num6] = num7;
					span2[num6] = num8;
					num6++;
					if (num6 == num4 + 1 && num6 < 4096)
					{
						num3++;
						num4 = (1 << num3) - 1;
					}
				}
				num7 = num16;
			}
			num--;
			num15++;
		}
		top = num;
		bits = num2;
		codeSize = num3;
		codeMask = num4;
		availableCode = num6;
		oldCode = num7;
		first = num8;
		data = num9;
		count = num10;
		bufferIndex = num11;
		code = num12;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int ReadBlock(BufferedReadStream stream, Span<byte> buffer)
	{
		int num = stream.ReadByte();
		if (num < 1)
		{
			return 0;
		}
		if (stream.Read(buffer, 0, num) == num)
		{
			return num;
		}
		return 0;
	}

	public void Dispose()
	{
		prefixOwner.Dispose();
		suffixOwner.Dispose();
		pixelStackOwner.Dispose();
		bufferOwner.Dispose();
	}
}
