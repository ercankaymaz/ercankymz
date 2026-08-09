using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Gif;

internal sealed class LzwEncoder : IDisposable
{
	private const int HashSize = 5003;

	private const int HashShift = 4;

	private static readonly int[] Masks = new int[17]
	{
		0, 1, 3, 7, 15, 31, 63, 127, 255, 511,
		1023, 2047, 4095, 8191, 16383, 32767, 65535
	};

	private const int MaxBits = 12;

	private const int MaxMaxCode = 4096;

	private readonly int initialCodeSize;

	private readonly IMemoryOwner<int> hashTable;

	private readonly IMemoryOwner<int> codeTable;

	private readonly byte[] accumulators = new byte[256];

	private int bitCount;

	private int maxCode;

	private int freeEntry;

	private bool clearFlag;

	private int globalInitialBits;

	private int clearCode;

	private int eofCode;

	private int currentAccumulator;

	private int currentBits;

	private int accumulatorCount;

	public LzwEncoder(MemoryAllocator memoryAllocator, int colorDepth)
	{
		initialCodeSize = Math.Max(2, colorDepth);
		hashTable = memoryAllocator.Allocate<int>(5003, AllocationOptions.Clean);
		codeTable = memoryAllocator.Allocate<int>(5003, AllocationOptions.Clean);
	}

	public void Encode(Buffer2D<byte> indexedPixels, Stream stream)
	{
		stream.WriteByte((byte)initialCodeSize);
		Compress(indexedPixels, initialCodeSize + 1, stream);
		stream.WriteByte(0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int GetMaxCode(int bitCount)
	{
		return (1 << bitCount) - 1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void AddCharacter(byte c, ref byte accumulatorsRef, Stream stream)
	{
		Unsafe.Add(ref accumulatorsRef, (uint)accumulatorCount++) = c;
		if (accumulatorCount >= 254)
		{
			FlushPacket(stream);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ClearBlock(Stream stream)
	{
		ResetCodeTable();
		freeEntry = clearCode + 2;
		clearFlag = true;
		Output(clearCode, stream);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ResetCodeTable()
	{
		hashTable.GetSpan().Fill(-1);
	}

	private void Compress(Buffer2D<byte> indexedPixels, int initialBits, Stream stream)
	{
		globalInitialBits = initialBits;
		clearFlag = false;
		bitCount = globalInitialBits;
		maxCode = GetMaxCode(bitCount);
		clearCode = 1 << initialBits - 1;
		eofCode = clearCode + 1;
		freeEntry = clearCode + 2;
		accumulatorCount = 0;
		ResetCodeTable();
		Output(clearCode, stream);
		ref int reference = ref MemoryMarshal.GetReference<int>(hashTable.GetSpan());
		ref int reference2 = ref MemoryMarshal.GetReference<int>(codeTable.GetSpan());
		int num = indexedPixels[0, 0];
		for (int i = 0; i < indexedPixels.Height; i++)
		{
			ref byte reference3 = ref MemoryMarshal.GetReference<byte>(indexedPixels.DangerousGetRowSpan(i));
			for (int j = ((i == 0) ? 1 : 0); j < indexedPixels.Width; j++)
			{
				int num2 = Unsafe.Add(ref reference3, (uint)j);
				int num3 = (num2 << 12) + num;
				int num4 = (num2 << 4) ^ num;
				if (Unsafe.Add(ref reference, (uint)num4) == num3)
				{
					num = Unsafe.Add(ref reference2, (uint)num4);
					continue;
				}
				if (Unsafe.Add(ref reference, (uint)num4) >= 0)
				{
					int num5 = 1;
					if (num4 != 0)
					{
						num5 = 5003 - num4;
					}
					do
					{
						if ((num4 -= num5) < 0)
						{
							num4 += 5003;
						}
						if (Unsafe.Add(ref reference, (uint)num4) == num3)
						{
							num = Unsafe.Add(ref reference2, (uint)num4);
							break;
						}
					}
					while (Unsafe.Add(ref reference, (uint)num4) >= 0);
					if (Unsafe.Add(ref reference, (uint)num4) == num3)
					{
						continue;
					}
				}
				Output(num, stream);
				num = num2;
				if (freeEntry < 4096)
				{
					Unsafe.Add(ref reference2, (uint)num4) = freeEntry++;
					Unsafe.Add(ref reference, (uint)num4) = num3;
				}
				else
				{
					ClearBlock(stream);
				}
			}
		}
		Output(num, stream);
		Output(eofCode, stream);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void FlushPacket(Stream outStream)
	{
		outStream.WriteByte((byte)accumulatorCount);
		outStream.Write(accumulators, 0, accumulatorCount);
		accumulatorCount = 0;
	}

	private void Output(int code, Stream outs)
	{
		ref byte reference = ref MemoryMarshal.GetReference<byte>(MemoryExtensions.AsSpan<byte>(accumulators));
		currentAccumulator &= Masks[currentBits];
		if (currentBits > 0)
		{
			currentAccumulator |= code << currentBits;
		}
		else
		{
			currentAccumulator = code;
		}
		currentBits += bitCount;
		while (currentBits >= 8)
		{
			AddCharacter((byte)(currentAccumulator & 0xFF), ref reference, outs);
			currentAccumulator >>= 8;
			currentBits -= 8;
		}
		if (freeEntry > maxCode || clearFlag)
		{
			if (clearFlag)
			{
				maxCode = GetMaxCode(bitCount = globalInitialBits);
				clearFlag = false;
			}
			else
			{
				bitCount++;
				maxCode = ((bitCount == 12) ? 4096 : GetMaxCode(bitCount));
			}
		}
		if (code == eofCode)
		{
			while (currentBits > 0)
			{
				AddCharacter((byte)(currentAccumulator & 0xFF), ref reference, outs);
				currentAccumulator >>= 8;
				currentBits -= 8;
			}
			if (accumulatorCount > 0)
			{
				FlushPacket(outs);
			}
		}
	}

	public void Dispose()
	{
		hashTable?.Dispose();
		codeTable?.Dispose();
	}
}
