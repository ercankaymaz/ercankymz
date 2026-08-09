using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Compression.Zlib;

internal sealed class DeflaterHuffman : IDisposable
{
	private sealed class Tree : IDisposable
	{
		private readonly int minNumCodes;

		private readonly int[] bitLengthCounts;

		private readonly int maxLength;

		private bool isDisposed;

		private readonly int elementCount;

		private readonly MemoryAllocator memoryAllocator;

		private IMemoryOwner<short> codesMemoryOwner;

		private MemoryHandle codesMemoryHandle;

		private unsafe readonly short* codes;

		private IMemoryOwner<short> frequenciesMemoryOwner;

		private MemoryHandle frequenciesMemoryHandle;

		private IMemoryOwner<byte> lengthsMemoryOwner;

		private MemoryHandle lengthsMemoryHandle;

		public int NumCodes { get; private set; }

		public unsafe short* Frequencies { get; }

		public unsafe byte* Length { get; }

		public unsafe Tree(MemoryAllocator memoryAllocator, int elements, int minCodes, int maxLength)
		{
			this.memoryAllocator = memoryAllocator;
			elementCount = elements;
			minNumCodes = minCodes;
			this.maxLength = maxLength;
			frequenciesMemoryOwner = memoryAllocator.Allocate<short>(elements);
			frequenciesMemoryHandle = frequenciesMemoryOwner.Memory.Pin();
			Frequencies = (short*)frequenciesMemoryHandle.Pointer;
			lengthsMemoryOwner = memoryAllocator.Allocate<byte>(elements);
			lengthsMemoryHandle = lengthsMemoryOwner.Memory.Pin();
			Length = (byte*)lengthsMemoryHandle.Pointer;
			codesMemoryOwner = memoryAllocator.Allocate<short>(elements);
			codesMemoryHandle = codesMemoryOwner.Memory.Pin();
			codes = (short*)codesMemoryHandle.Pointer;
			bitLengthCounts = new int[maxLength];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
			Memory<short> memory = frequenciesMemoryOwner.Memory;
			memory.Span.Clear();
			lengthsMemoryOwner.Memory.Span.Clear();
			memory = codesMemoryOwner.Memory;
			memory.Span.Clear();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe void WriteSymbol(DeflaterPendingBuffer pendingBuffer, int code)
		{
			pendingBuffer.WriteBits(codes[code] & 0xFFFF, Length[code]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetStaticCodes(ReadOnlySpan<short> staticCodes, ReadOnlySpan<byte> staticLengths)
		{
			staticCodes.CopyTo(codesMemoryOwner.Memory.Span);
			staticLengths.CopyTo(lengthsMemoryOwner.Memory.Span);
		}

		public unsafe void BuildCodes()
		{
			ref int reference = ref MemoryMarshal.GetReference<int>(stackalloc int[maxLength]);
			ref int reference2 = ref MemoryMarshal.GetReference<int>((Span<int>)bitLengthCounts);
			int num = 0;
			for (int i = 0; i < maxLength; i++)
			{
				Unsafe.Add(ref reference, (uint)i) = num;
				num += Unsafe.Add(ref reference2, (uint)i) << 15 - i;
			}
			for (int j = 0; j < NumCodes; j++)
			{
				int num2 = Length[j];
				if (num2 > 0)
				{
					codes[j] = BitReverse(Unsafe.Add(ref reference, (uint)(num2 - 1)));
					Unsafe.Add(ref reference, (uint)(num2 - 1)) += 1 << 16 - num2;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		public unsafe void BuildTree()
		{
			int num = elementCount;
			using IMemoryOwner<int> memoryOwner = memoryAllocator.Allocate<int>(num);
			Memory<int> memory = memoryOwner.Memory;
			ref int reference = ref MemoryMarshal.GetReference<int>(memory.Span);
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				int num4 = Frequencies[i];
				if (num4 != 0)
				{
					int num5 = num2++;
					int num6;
					while (num5 > 0 && Frequencies[Unsafe.Add(ref reference, (uint)(num6 = num5 - 1 >> 1))] > num4)
					{
						Unsafe.Add(ref reference, num5) = Unsafe.Add(ref reference, (uint)num6);
						num5 = num6;
					}
					Unsafe.Add(ref reference, (uint)num5) = i;
					num3 = i;
				}
			}
			while (num2 < 2)
			{
				Unsafe.Add(ref reference, (uint)num2++) = ((num3 < 2) ? (++num3) : 0);
			}
			NumCodes = Math.Max(num3 + 1, minNumCodes);
			int num7 = num2;
			int num8 = 4 * num2 - 2;
			using IMemoryOwner<int> memoryOwner2 = memoryAllocator.Allocate<int>(num8);
			using IMemoryOwner<int> memoryOwner3 = memoryAllocator.Allocate<int>(2 * num2 - 1);
			memory = memoryOwner2.Memory;
			ref int reference2 = ref MemoryMarshal.GetReference<int>(memory.Span);
			memory = memoryOwner3.Memory;
			ref int reference3 = ref MemoryMarshal.GetReference<int>(memory.Span);
			int num9 = num7;
			for (nuint num10 = 0u; num10 < (uint)num2; num10++)
			{
				int num11 = Unsafe.Add(ref reference, num10);
				nuint num12 = 2 * num10;
				Unsafe.Add(ref reference2, num12) = num11;
				Unsafe.Add(ref reference2, num12 + 1) = -1;
				Unsafe.Add(ref reference3, num10) = Frequencies[num11] << 8;
				Unsafe.Add(ref reference, num10) = (int)num10;
			}
			do
			{
				int num13 = Unsafe.Add(ref reference, 0);
				int num14 = Unsafe.Add(ref reference, (uint)(--num2));
				int num15 = 0;
				int num16;
				for (num16 = 1; num16 < num2; num16 = num16 * 2 + 1)
				{
					if (num16 + 1 < num2 && Unsafe.Add(ref reference3, (uint)Unsafe.Add(ref reference, (uint)num16)) > Unsafe.Add(ref reference3, (uint)Unsafe.Add(ref reference, (uint)(num16 + 1))))
					{
						num16++;
					}
					Unsafe.Add(ref reference, (uint)num15) = Unsafe.Add(ref reference, (uint)num16);
					num15 = num16;
				}
				int num17 = Unsafe.Add(ref reference3, (uint)num14);
				while ((num16 = num15) > 0 && Unsafe.Add(ref reference3, (uint)Unsafe.Add(ref reference, (uint)(num15 = num16 - 1 >> 1))) > num17)
				{
					Unsafe.Add(ref reference, (uint)num16) = Unsafe.Add(ref reference, (uint)num15);
				}
				Unsafe.Add(ref reference, (uint)num16) = num14;
				int num18 = Unsafe.Add(ref reference, 0);
				num14 = num9++;
				Unsafe.Add(ref reference2, (uint)(2 * num14)) = num13;
				Unsafe.Add(ref reference2, (uint)(2 * num14 + 1)) = num18;
				int num19 = Math.Min(Unsafe.Add(ref reference3, (uint)num13) & 0xFF, Unsafe.Add(ref reference3, (uint)num18) & 0xFF);
				num17 = (Unsafe.Add(ref reference3, (uint)num14) = Unsafe.Add(ref reference3, (uint)num13) + Unsafe.Add(ref reference3, (uint)num18) - num19 + 1);
				num15 = 0;
				for (num16 = 1; num16 < num2; num16 = num15 * 2 + 1)
				{
					if (num16 + 1 < num2 && Unsafe.Add(ref reference3, (uint)Unsafe.Add(ref reference, (uint)num16)) > Unsafe.Add(ref reference3, (uint)Unsafe.Add(ref reference, (uint)(num16 + 1))))
					{
						num16++;
					}
					Unsafe.Add(ref reference, (uint)num15) = Unsafe.Add(ref reference, (uint)num16);
					num15 = num16;
				}
				while ((num16 = num15) > 0 && Unsafe.Add(ref reference3, (uint)Unsafe.Add(ref reference, (uint)(num15 = num16 - 1 >> 1))) > num17)
				{
					Unsafe.Add(ref reference, (uint)num16) = Unsafe.Add(ref reference, (uint)num15);
				}
				Unsafe.Add(ref reference, (uint)num16) = num14;
			}
			while (num2 > 1);
			if (Unsafe.Add(ref reference, 0) != (num8 >> 1) - 1)
			{
				DeflateThrowHelper.ThrowHeapViolated();
			}
			memory = memoryOwner2.Memory;
			BuildLength(memory.Span);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe int GetEncodedLength()
		{
			int num = 0;
			for (int i = 0; i < elementCount; i++)
			{
				num += Frequencies[i] * Length[i];
			}
			return num;
		}

		public unsafe void CalcBLFreq(Tree blTree)
		{
			int num = -1;
			int num2 = 0;
			while (num2 < NumCodes)
			{
				int num3 = 1;
				int num4 = Length[num2];
				int num5;
				int num6;
				if (num4 == 0)
				{
					num5 = 138;
					num6 = 3;
				}
				else
				{
					num5 = 6;
					num6 = 3;
					if (num != num4)
					{
						blTree.Frequencies[num4]++;
						num3 = 0;
					}
				}
				num = num4;
				num2++;
				while (num2 < NumCodes && num == Length[num2])
				{
					num2++;
					if (++num3 >= num5)
					{
						break;
					}
				}
				if (num3 < num6)
				{
					blTree.Frequencies[num] += (short)num3;
				}
				else if (num != 0)
				{
					blTree.Frequencies[16]++;
				}
				else if (num3 <= 10)
				{
					blTree.Frequencies[17]++;
				}
				else
				{
					blTree.Frequencies[18]++;
				}
			}
		}

		public unsafe void WriteTree(DeflaterPendingBuffer pendingBuffer, Tree bitLengthTree)
		{
			int num = -1;
			int num2 = 0;
			while (num2 < NumCodes)
			{
				int num3 = 1;
				int num4 = Length[num2];
				int num5;
				int num6;
				if (num4 == 0)
				{
					num5 = 138;
					num6 = 3;
				}
				else
				{
					num5 = 6;
					num6 = 3;
					if (num != num4)
					{
						bitLengthTree.WriteSymbol(pendingBuffer, num4);
						num3 = 0;
					}
				}
				num = num4;
				num2++;
				while (num2 < NumCodes && num == Length[num2])
				{
					num2++;
					if (++num3 >= num5)
					{
						break;
					}
				}
				if (num3 < num6)
				{
					while (num3-- > 0)
					{
						bitLengthTree.WriteSymbol(pendingBuffer, num);
					}
				}
				else if (num != 0)
				{
					bitLengthTree.WriteSymbol(pendingBuffer, 16);
					pendingBuffer.WriteBits(num3 - 3, 2);
				}
				else if (num3 <= 10)
				{
					bitLengthTree.WriteSymbol(pendingBuffer, 17);
					pendingBuffer.WriteBits(num3 - 3, 3);
				}
				else
				{
					bitLengthTree.WriteSymbol(pendingBuffer, 18);
					pendingBuffer.WriteBits(num3 - 11, 7);
				}
			}
		}

		private unsafe void BuildLength(ReadOnlySpan<int> children)
		{
			byte* length = Length;
			ref int reference = ref MemoryMarshal.GetReference<int>(children);
			ref int reference2 = ref MemoryMarshal.GetReference<int>((Span<int>)bitLengthCounts);
			int num = maxLength;
			int num2 = children.Length >> 1;
			int num3 = num2 + 1 >> 1;
			int num4 = 0;
			Array.Clear(bitLengthCounts, 0, num);
			using (IMemoryOwner<int> memoryOwner = memoryAllocator.Allocate<int>(num2, AllocationOptions.Clean))
			{
				ref int reference3 = ref MemoryMarshal.GetReference<int>(memoryOwner.Memory.Span);
				for (int num5 = num2 - 1; num5 >= 0; num5--)
				{
					if (children[2 * num5 + 1] != -1)
					{
						int num6 = Unsafe.Add(ref reference3, (uint)num5) + 1;
						if (num6 > num)
						{
							num6 = num;
							num4++;
						}
						Unsafe.Add(ref reference3, (uint)Unsafe.Add(ref reference, (uint)(2 * num5))) = (Unsafe.Add(ref reference3, (uint)Unsafe.Add(ref reference, (uint)(2 * num5 + 1))) = num6);
					}
					else
					{
						int num7 = Unsafe.Add(ref reference3, (uint)num5);
						Unsafe.Add(ref reference2, (uint)(num7 - 1))++;
						length[Unsafe.Add(ref reference, (uint)(2 * num5))] = (byte)Unsafe.Add(ref reference3, (uint)num5);
					}
				}
			}
			if (num4 == 0)
			{
				return;
			}
			int num8 = num - 1;
			while (true)
			{
				if (Unsafe.Add(ref reference2, (uint)(--num8)) != 0)
				{
					do
					{
						Unsafe.Add(ref reference2, (uint)num8)--;
						Unsafe.Add(ref reference2, (uint)(++num8))++;
						num4 -= 1 << num - 1 - num8;
					}
					while (num4 > 0 && num8 < num - 1);
					if (num4 <= 0)
					{
						break;
					}
				}
			}
			Unsafe.Add(ref reference2, (uint)(num - 1)) += num4;
			Unsafe.Add(ref reference2, (uint)(num - 2)) -= num4;
			int num9 = 2 * num3;
			for (int num10 = num; num10 != 0; num10--)
			{
				int num11 = Unsafe.Add(ref reference2, (uint)(num10 - 1));
				while (num11 > 0)
				{
					int num12 = 2 * Unsafe.Add(ref reference, (uint)num9++);
					if (Unsafe.Add(ref reference, (uint)(num12 + 1)) == -1)
					{
						length[Unsafe.Add(ref reference, (uint)num12)] = (byte)num10;
						num11--;
					}
				}
			}
		}

		public void Dispose()
		{
			if (!isDisposed)
			{
				frequenciesMemoryHandle.Dispose();
				frequenciesMemoryOwner.Dispose();
				lengthsMemoryHandle.Dispose();
				lengthsMemoryOwner.Dispose();
				codesMemoryHandle.Dispose();
				codesMemoryOwner.Dispose();
				isDisposed = true;
			}
		}
	}

	private const int BufferSize = 16384;

	private const int LiteralNumber = 286;

	private const int DistanceNumber = 30;

	private const int BitLengthNumber = 19;

	private const int Repeat3To6 = 16;

	private const int Repeat3To10 = 17;

	private const int Repeat11To138 = 18;

	private const int EofSymbol = 256;

	private Tree literalTree;

	private Tree distTree;

	private Tree blTree;

	private readonly IMemoryOwner<short> distanceMemoryOwner;

	private unsafe readonly short* pinnedDistanceBuffer;

	private MemoryHandle distanceBufferHandle;

	private readonly IMemoryOwner<short> literalMemoryOwner;

	private unsafe readonly short* pinnedLiteralBuffer;

	private MemoryHandle literalBufferHandle;

	private int lastLiteral;

	private int extraBits;

	private bool isDisposed;

	private static readonly short[] StaticLCodes = new short[286]
	{
		12, 140, 76, 204, 44, 172, 108, 236, 28, 156,
		92, 220, 60, 188, 124, 252, 2, 130, 66, 194,
		34, 162, 98, 226, 18, 146, 82, 210, 50, 178,
		114, 242, 10, 138, 74, 202, 42, 170, 106, 234,
		26, 154, 90, 218, 58, 186, 122, 250, 6, 134,
		70, 198, 38, 166, 102, 230, 22, 150, 86, 214,
		54, 182, 118, 246, 14, 142, 78, 206, 46, 174,
		110, 238, 30, 158, 94, 222, 62, 190, 126, 254,
		1, 129, 65, 193, 33, 161, 97, 225, 17, 145,
		81, 209, 49, 177, 113, 241, 9, 137, 73, 201,
		41, 169, 105, 233, 25, 153, 89, 217, 57, 185,
		121, 249, 5, 133, 69, 197, 37, 165, 101, 229,
		21, 149, 85, 213, 53, 181, 117, 245, 13, 141,
		77, 205, 45, 173, 109, 237, 29, 157, 93, 221,
		61, 189, 125, 253, 19, 275, 147, 403, 83, 339,
		211, 467, 51, 307, 179, 435, 115, 371, 243, 499,
		11, 267, 139, 395, 75, 331, 203, 459, 43, 299,
		171, 427, 107, 363, 235, 491, 27, 283, 155, 411,
		91, 347, 219, 475, 59, 315, 187, 443, 123, 379,
		251, 507, 7, 263, 135, 391, 71, 327, 199, 455,
		39, 295, 167, 423, 103, 359, 231, 487, 23, 279,
		151, 407, 87, 343, 215, 471, 55, 311, 183, 439,
		119, 375, 247, 503, 15, 271, 143, 399, 79, 335,
		207, 463, 47, 303, 175, 431, 111, 367, 239, 495,
		31, 287, 159, 415, 95, 351, 223, 479, 63, 319,
		191, 447, 127, 383, 255, 511, 0, 64, 32, 96,
		16, 80, 48, 112, 8, 72, 40, 104, 24, 88,
		56, 120, 4, 68, 36, 100, 20, 84, 52, 116,
		3, 131, 67, 195, 35, 163
	};

	private static readonly short[] StaticDCodes = new short[30]
	{
		0, 16, 8, 24, 4, 20, 12, 28, 2, 18,
		10, 26, 6, 22, 14, 30, 1, 17, 9, 25,
		5, 21, 13, 29, 3, 19, 11, 27, 7, 23
	};

	private static ReadOnlySpan<byte> StaticLLength => new byte[286]
	{
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
		8, 8, 8, 8, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 9, 9, 9, 9,
		9, 9, 9, 9, 9, 9, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
		7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
		8, 8, 8, 8, 8, 8
	};

	private static ReadOnlySpan<byte> StaticDLength => new byte[30]
	{
		5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
		5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
		5, 5, 5, 5, 5, 5, 5, 5, 5, 5
	};

	private static ReadOnlySpan<byte> BitLengthOrder => new byte[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	private static ReadOnlySpan<byte> Bit4Reverse => new byte[16]
	{
		0, 8, 4, 12, 2, 10, 6, 14, 1, 9,
		5, 13, 3, 11, 7, 15
	};

	public DeflaterPendingBuffer Pending { get; private set; }

	public unsafe DeflaterHuffman(MemoryAllocator memoryAllocator)
	{
		Pending = new DeflaterPendingBuffer(memoryAllocator);
		literalTree = new Tree(memoryAllocator, 286, 257, 15);
		distTree = new Tree(memoryAllocator, 30, 1, 15);
		blTree = new Tree(memoryAllocator, 19, 4, 7);
		distanceMemoryOwner = memoryAllocator.Allocate<short>(16384);
		distanceBufferHandle = distanceMemoryOwner.Memory.Pin();
		pinnedDistanceBuffer = (short*)distanceBufferHandle.Pointer;
		literalMemoryOwner = memoryAllocator.Allocate<short>(16384);
		literalBufferHandle = literalMemoryOwner.Memory.Pin();
		pinnedLiteralBuffer = (short*)literalBufferHandle.Pointer;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Reset()
	{
		lastLiteral = 0;
		extraBits = 0;
		literalTree.Reset();
		distTree.Reset();
		blTree.Reset();
	}

	public unsafe void SendAllTrees(int blTreeCodes)
	{
		blTree.BuildCodes();
		literalTree.BuildCodes();
		distTree.BuildCodes();
		Pending.WriteBits(literalTree.NumCodes - 257, 5);
		Pending.WriteBits(distTree.NumCodes - 1, 5);
		Pending.WriteBits(blTreeCodes - 4, 4);
		for (int i = 0; i < blTreeCodes; i++)
		{
			Pending.WriteBits(blTree.Length[(int)BitLengthOrder[i]], 3);
		}
		literalTree.WriteTree(Pending, blTree);
		distTree.WriteTree(Pending, blTree);
	}

	public unsafe void CompressBlock()
	{
		DeflaterPendingBuffer pending = Pending;
		short* ptr = pinnedDistanceBuffer;
		short* ptr2 = pinnedLiteralBuffer;
		for (int i = 0; i < lastLiteral; i++)
		{
			int num = ptr2[i] & 0xFF;
			int num2 = ptr[i];
			if (num2-- != 0)
			{
				int num3 = Lcode(num);
				literalTree.WriteSymbol(pending, num3);
				int num4 = (int)((uint)(num3 - 261) / 4u);
				if (num4 > 0 && num4 <= 5)
				{
					Pending.WriteBits(num & ((1 << num4) - 1), num4);
				}
				int num5 = Dcode(num2);
				distTree.WriteSymbol(pending, num5);
				num4 = (num5 >> 1) - 1;
				if (num4 > 0)
				{
					Pending.WriteBits(num2 & ((1 << num4) - 1), num4);
				}
			}
			else
			{
				literalTree.WriteSymbol(pending, num);
			}
		}
		literalTree.WriteSymbol(pending, 256);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FlushStoredBlock(ReadOnlySpan<byte> stored, int storedOffset, int storedLength, bool lastBlock)
	{
		Pending.WriteBits(lastBlock ? 1 : 0, 3);
		Pending.AlignToByte();
		Pending.WriteShort(storedLength);
		Pending.WriteShort(~storedLength);
		Pending.WriteBlock(stored, storedOffset, storedLength);
		Reset();
	}

	public unsafe void FlushBlock(ReadOnlySpan<byte> stored, int storedOffset, int storedLength, bool lastBlock)
	{
		literalTree.Frequencies[256]++;
		literalTree.BuildTree();
		distTree.BuildTree();
		literalTree.CalcBLFreq(blTree);
		distTree.CalcBLFreq(blTree);
		blTree.BuildTree();
		int num = 4;
		for (int num2 = 18; num2 > num; num2--)
		{
			if (blTree.Length[(int)BitLengthOrder[num2]] > 0)
			{
				num = num2 + 1;
			}
		}
		int num3 = 14 + num * 3 + blTree.GetEncodedLength() + literalTree.GetEncodedLength() + distTree.GetEncodedLength() + extraBits;
		int num4 = extraBits;
		ref byte reference = ref MemoryMarshal.GetReference<byte>(StaticLLength);
		for (nuint num5 = 0u; num5 < 286; num5++)
		{
			num4 += literalTree.Frequencies[num5] * Unsafe.Add(ref reference, num5);
		}
		ref byte reference2 = ref MemoryMarshal.GetReference<byte>(StaticDLength);
		for (nuint num6 = 0u; num6 < 30; num6++)
		{
			num4 += distTree.Frequencies[num6] * Unsafe.Add(ref reference2, num6);
		}
		if (num3 >= num4)
		{
			num3 = num4;
		}
		if (storedOffset >= 0 && storedLength + 4 < num3 >> 3)
		{
			FlushStoredBlock(stored, storedOffset, storedLength, lastBlock);
		}
		else if (num3 == num4)
		{
			Pending.WriteBits(2 + (lastBlock ? 1 : 0), 3);
			literalTree.SetStaticCodes(StaticLCodes, StaticLLength);
			distTree.SetStaticCodes(StaticDCodes, StaticDLength);
			CompressBlock();
			Reset();
		}
		else
		{
			Pending.WriteBits(4 + (lastBlock ? 1 : 0), 3);
			SendAllTrees(num);
			CompressBlock();
			Reset();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool IsFull()
	{
		return lastLiteral >= 16384;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe bool TallyLit(int literal)
	{
		pinnedDistanceBuffer[lastLiteral] = 0;
		pinnedLiteralBuffer[lastLiteral++] = (byte)literal;
		literalTree.Frequencies[literal]++;
		return IsFull();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe bool TallyDist(int distance, int length)
	{
		pinnedDistanceBuffer[lastLiteral] = (short)distance;
		pinnedLiteralBuffer[lastLiteral++] = (byte)(length - 3);
		int num = Lcode(length - 3);
		literalTree.Frequencies[num]++;
		if (num >= 265 && num < 285)
		{
			extraBits += (int)((uint)(num - 261) / 4u);
		}
		int num2 = Dcode(distance - 1);
		distTree.Frequencies[num2]++;
		if (num2 >= 4)
		{
			extraBits += (num2 >> 1) - 1;
		}
		return IsFull();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short BitReverse(int toReverse)
	{
		int num = toReverse >> 12;
		Guard.MustBeLessThanOrEqualTo<uint>((uint)num, 15u, "toReverse");
		ref byte reference = ref MemoryMarshal.GetReference<byte>(Bit4Reverse);
		return (short)((Unsafe.Add(ref reference, (uint)(toReverse & 0xF)) << 12) | (Unsafe.Add(ref reference, (uint)((toReverse >> 4) & 0xF)) << 8) | (Unsafe.Add(ref reference, (uint)((toReverse >> 8) & 0xF)) << 4) | Unsafe.Add(ref reference, (uint)num));
	}

	public void Dispose()
	{
		if (!isDisposed)
		{
			Pending.Dispose();
			distanceBufferHandle.Dispose();
			distanceMemoryOwner.Dispose();
			literalBufferHandle.Dispose();
			literalMemoryOwner.Dispose();
			literalTree.Dispose();
			blTree.Dispose();
			distTree.Dispose();
			isDisposed = true;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Lcode(int length)
	{
		if (length == 255)
		{
			return 285;
		}
		int num = 257;
		while (length >= 8)
		{
			num += 4;
			length >>= 1;
		}
		return num + length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int Dcode(int distance)
	{
		int num = 0;
		while (distance >= 4)
		{
			num += 2;
			distance >>= 1;
		}
		return num + distance;
	}
}
