using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Compression.Zlib;

internal sealed class DeflaterEngine : IDisposable
{
	private const int TooFar = 4096;

	private int insertHashIndex;

	private int matchStart;

	private int matchLen;

	private bool prevAvailable;

	private int blockStart;

	private int strstart;

	private int lookahead;

	private int compressionFunction;

	private byte[]? inputBuf;

	private int inputOff;

	private int inputEnd;

	private readonly DeflateStrategy strategy;

	private DeflaterHuffman huffman;

	private bool isDisposed;

	private IMemoryOwner<short> headMemoryOwner;

	private MemoryHandle headMemoryHandle;

	private readonly Memory<short> head;

	private unsafe readonly short* pinnedHeadPointer;

	private IMemoryOwner<short> prevMemoryOwner;

	private MemoryHandle prevMemoryHandle;

	private readonly Memory<short> prev;

	private unsafe readonly short* pinnedPrevPointer;

	private IMemoryOwner<byte> windowMemoryOwner;

	private MemoryHandle windowMemoryHandle;

	private readonly Memory<byte> window;

	private unsafe readonly byte* pinnedWindowPointer;

	private int maxChain;

	private int maxLazy;

	private int niceLength;

	private int goodLength;

	public DeflaterPendingBuffer Pending { get; }

	public unsafe DeflaterEngine(MemoryAllocator memoryAllocator, DeflateStrategy strategy)
	{
		huffman = new DeflaterHuffman(memoryAllocator);
		Pending = huffman.Pending;
		this.strategy = strategy;
		windowMemoryOwner = memoryAllocator.Allocate<byte>(65536);
		window = windowMemoryOwner.Memory;
		windowMemoryHandle = window.Pin();
		pinnedWindowPointer = (byte*)windowMemoryHandle.Pointer;
		headMemoryOwner = memoryAllocator.Allocate<short>(32768);
		head = headMemoryOwner.Memory;
		headMemoryHandle = head.Pin();
		pinnedHeadPointer = (short*)headMemoryHandle.Pointer;
		prevMemoryOwner = memoryAllocator.Allocate<short>(32768);
		prev = prevMemoryOwner.Memory;
		prevMemoryHandle = prev.Pin();
		pinnedPrevPointer = (short*)prevMemoryHandle.Pointer;
		blockStart = (strstart = 1);
	}

	public bool Deflate(bool flush, bool finish)
	{
		bool flag = false;
		do
		{
			FillWindow();
			bool flush2 = flush && inputOff == inputEnd;
			switch (compressionFunction)
			{
			case 0:
				flag = DeflateStored(flush2, finish);
				break;
			case 1:
				flag = DeflateFast(flush2, finish);
				break;
			case 2:
				flag = DeflateSlow(flush2, finish);
				break;
			default:
				DeflateThrowHelper.ThrowUnknownCompression();
				break;
			}
		}
		while (Pending.IsFlushed && flag);
		return flag;
	}

	public void SetInput(byte[]? buffer, int offset, int count)
	{
		if (buffer == null)
		{
			DeflateThrowHelper.ThrowNull("buffer");
		}
		if (offset < 0)
		{
			DeflateThrowHelper.ThrowOutOfRange("offset");
		}
		if (count < 0)
		{
			DeflateThrowHelper.ThrowOutOfRange("count");
		}
		if (inputOff < inputEnd)
		{
			DeflateThrowHelper.ThrowNotProcessed();
		}
		int num = offset + count;
		if (offset > num || num > buffer.Length)
		{
			DeflateThrowHelper.ThrowOutOfRange("count");
		}
		inputBuf = buffer;
		inputOff = offset;
		inputEnd = num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool NeedsInput()
	{
		return inputEnd == inputOff;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Reset()
	{
		huffman.Reset();
		blockStart = (strstart = 1);
		lookahead = 0;
		prevAvailable = false;
		matchLen = 2;
		Span<short> span = head.Span;
		span.Slice(0, 32768).Clear();
		span = prev.Span;
		span.Slice(0, 32768).Clear();
	}

	public unsafe void SetLevel(int level)
	{
		if ((level < 0 || level > 9) ? true : false)
		{
			DeflateThrowHelper.ThrowOutOfRange("level");
		}
		goodLength = DeflaterConstants.GOOD_LENGTH[level];
		maxLazy = DeflaterConstants.MAX_LAZY[level];
		niceLength = DeflaterConstants.NICE_LENGTH[level];
		maxChain = DeflaterConstants.MAX_CHAIN[level];
		if (DeflaterConstants.COMPR_FUNC[level] == compressionFunction)
		{
			return;
		}
		switch (compressionFunction)
		{
		case 0:
			if (strstart > blockStart)
			{
				huffman.FlushStoredBlock(window.Span, blockStart, strstart - blockStart, lastBlock: false);
				blockStart = strstart;
			}
			UpdateHash();
			break;
		case 1:
			if (strstart > blockStart)
			{
				huffman.FlushBlock(window.Span, blockStart, strstart - blockStart, lastBlock: false);
				blockStart = strstart;
			}
			break;
		case 2:
			if (prevAvailable)
			{
				huffman.TallyLit(pinnedWindowPointer[strstart - 1] & 0xFF);
			}
			if (strstart > blockStart)
			{
				huffman.FlushBlock(window.Span, blockStart, strstart - blockStart, lastBlock: false);
				blockStart = strstart;
			}
			prevAvailable = false;
			matchLen = 2;
			break;
		}
		compressionFunction = DeflaterConstants.COMPR_FUNC[level];
	}

	public void FillWindow()
	{
		if (strstart >= 65274)
		{
			SlideWindow();
		}
		if (lookahead < 262 && inputOff < inputEnd)
		{
			int num = 65536 - lookahead - strstart;
			if (num > inputEnd - inputOff)
			{
				num = inputEnd - inputOff;
			}
			ArgumentNullException.ThrowIfNull(inputBuf, "this.inputBuf");
			Unsafe.CopyBlockUnaligned(ref window.Span[strstart + lookahead], ref inputBuf[inputOff], (uint)num);
			inputOff += num;
			lookahead += num;
		}
		if (lookahead >= 3)
		{
			UpdateHash();
		}
	}

	public void Dispose()
	{
		if (!isDisposed)
		{
			huffman.Dispose();
			windowMemoryHandle.Dispose();
			windowMemoryOwner.Dispose();
			headMemoryHandle.Dispose();
			headMemoryOwner.Dispose();
			prevMemoryHandle.Dispose();
			prevMemoryOwner.Dispose();
			isDisposed = true;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe void UpdateHash()
	{
		byte* ptr = pinnedWindowPointer;
		insertHashIndex = (ptr[strstart] << 5) ^ ptr[strstart + 1];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private unsafe int InsertString()
	{
		int num = ((insertHashIndex << 5) ^ pinnedWindowPointer[strstart + 2]) & 0x7FFF;
		short* ptr = pinnedHeadPointer;
		short num2 = (pinnedPrevPointer[strstart & 0x7FFF] = ptr[num]);
		ptr[num] = (short)strstart;
		insertHashIndex = num;
		return num2 & 0xFFFF;
	}

	private unsafe void SlideWindow()
	{
		Unsafe.CopyBlockUnaligned(ref MemoryMarshal.GetReference<byte>(window.Span), ref Unsafe.Add(ref MemoryMarshal.GetReference<byte>(window.Span), 32768), 32768u);
		matchStart -= 32768;
		strstart -= 32768;
		blockStart -= 32768;
		short* ptr = pinnedHeadPointer;
		for (int i = 0; i < 32768; i++)
		{
			int num = ptr[i] & 0xFFFF;
			ptr[i] = (short)((num >= 32768) ? (num - 32768) : 0);
		}
		short* ptr2 = pinnedPrevPointer;
		for (int j = 0; j < 32768; j++)
		{
			int num2 = ptr2[j] & 0xFFFF;
			ptr2[j] = (short)((num2 >= 32768) ? (num2 - 32768) : 0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveOptimization)]
	private unsafe bool FindLongestMatch(int curMatch)
	{
		int num = strstart;
		int num2 = num + Math.Min(258, lookahead) - 1;
		int num3 = Math.Max(num - 32506, 0);
		int num4 = maxChain;
		int num5 = Math.Min(niceLength, lookahead);
		int num6 = matchStart;
		int val = matchLen;
		val = (matchLen = Math.Max(val, 2));
		if (num > num2 - val)
		{
			return false;
		}
		int num7 = num + val;
		byte* ptr = pinnedWindowPointer;
		int num8 = strstart;
		byte b = ptr[num7 - 1];
		byte b2 = ptr[num7];
		if (val >= goodLength)
		{
			num4 >>= 2;
		}
		short* ptr2 = pinnedPrevPointer;
		do
		{
			int num9 = curMatch;
			num = num8;
			int num10 = num9 + val;
			if (ptr[num10] != b2 || ptr[num10 - 1] != b || ptr[num9] != ptr[num] || ptr[++num9] != ptr[++num])
			{
				continue;
			}
			switch ((num2 - num) & 7)
			{
			case 1:
				if (ptr[++num] != ptr[++num9])
				{
				}
				break;
			case 2:
				if (ptr[++num] == ptr[++num9] && ptr[++num] != ptr[++num9])
				{
				}
				break;
			case 3:
				if (ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] != ptr[++num9])
				{
				}
				break;
			case 4:
				if (ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] != ptr[++num9])
				{
				}
				break;
			case 5:
				if (ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] != ptr[++num9])
				{
				}
				break;
			case 6:
				if (ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] != ptr[++num9])
				{
				}
				break;
			case 7:
				if (ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9])
				{
					_ = ptr[++num];
					_ = ptr[++num9];
				}
				break;
			}
			if (ptr[num] == ptr[num9])
			{
				do
				{
					if (num == num2)
					{
						num++;
						num9++;
						break;
					}
				}
				while (ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9] && ptr[++num] == ptr[++num9]);
			}
			if (num - num8 > val)
			{
				num6 = curMatch;
				val = num - num8;
				if (val >= num5)
				{
					break;
				}
				b = ptr[num - 1];
				b2 = ptr[num];
			}
		}
		while ((curMatch = ptr2[curMatch & 0x7FFF] & 0xFFFF) > num3 && --num4 != 0);
		matchStart = num6;
		matchLen = val;
		return val >= 3;
	}

	private bool DeflateStored(bool flush, bool finish)
	{
		if (!flush && lookahead == 0)
		{
			return false;
		}
		strstart += lookahead;
		lookahead = 0;
		int num = strstart - blockStart;
		if (num >= DeflaterConstants.MAX_BLOCK_SIZE || (blockStart < 32768 && num >= 32506) || flush)
		{
			bool flag = finish;
			if (num > DeflaterConstants.MAX_BLOCK_SIZE)
			{
				num = DeflaterConstants.MAX_BLOCK_SIZE;
				flag = false;
			}
			huffman.FlushStoredBlock(window.Span, blockStart, num, flag);
			blockStart += num;
			if (!flag)
			{
				return num != 0;
			}
			return false;
		}
		return true;
	}

	private unsafe bool DeflateFast(bool flush, bool finish)
	{
		if (lookahead < 262 && !flush)
		{
			return false;
		}
		while (lookahead >= 262 || flush)
		{
			if (lookahead == 0)
			{
				huffman.FlushBlock(window.Span, blockStart, strstart - blockStart, finish);
				blockStart = strstart;
				return false;
			}
			if (strstart > 65274)
			{
				SlideWindow();
			}
			int num;
			if (lookahead >= 3 && (num = InsertString()) != 0 && strategy != DeflateStrategy.HuffmanOnly && strstart - num <= 32506 && FindLongestMatch(num))
			{
				bool flag = huffman.TallyDist(strstart - matchStart, matchLen);
				lookahead -= matchLen;
				if (matchLen <= maxLazy && lookahead >= 3)
				{
					while (--matchLen > 0)
					{
						strstart++;
						InsertString();
					}
					strstart++;
				}
				else
				{
					strstart += matchLen;
					if (lookahead >= 2)
					{
						UpdateHash();
					}
				}
				matchLen = 2;
				if (!flag)
				{
					continue;
				}
			}
			else
			{
				huffman.TallyLit(pinnedWindowPointer[strstart] & 0xFF);
				strstart++;
				lookahead--;
			}
			if (huffman.IsFull())
			{
				bool flag2 = finish && lookahead == 0;
				huffman.FlushBlock(window.Span, blockStart, strstart - blockStart, flag2);
				blockStart = strstart;
				return !flag2;
			}
		}
		return true;
	}

	private unsafe bool DeflateSlow(bool flush, bool finish)
	{
		if (lookahead < 262 && !flush)
		{
			return false;
		}
		while (lookahead >= 262 || flush)
		{
			if (lookahead == 0)
			{
				if (prevAvailable)
				{
					huffman.TallyLit(pinnedWindowPointer[strstart - 1] & 0xFF);
				}
				prevAvailable = false;
				huffman.FlushBlock(window.Span, blockStart, strstart - blockStart, finish);
				blockStart = strstart;
				return false;
			}
			if (strstart >= 65274)
			{
				SlideWindow();
			}
			int num = matchStart;
			int num2 = matchLen;
			if (lookahead >= 3)
			{
				int num3 = InsertString();
				if (strategy != DeflateStrategy.HuffmanOnly && num3 != 0 && strstart - num3 <= 32506 && FindLongestMatch(num3) && matchLen <= 5 && (strategy == DeflateStrategy.Filtered || (matchLen == 3 && strstart - matchStart > 4096)))
				{
					matchLen = 2;
				}
			}
			if (num2 >= 3 && matchLen <= num2)
			{
				huffman.TallyDist(strstart - 1 - num, num2);
				num2 -= 2;
				do
				{
					strstart++;
					lookahead--;
					if (lookahead >= 3)
					{
						InsertString();
					}
				}
				while (--num2 > 0);
				strstart++;
				lookahead--;
				prevAvailable = false;
				matchLen = 2;
			}
			else
			{
				if (prevAvailable)
				{
					huffman.TallyLit(pinnedWindowPointer[strstart - 1] & 0xFF);
				}
				prevAvailable = true;
				strstart++;
				lookahead--;
			}
			if (huffman.IsFull())
			{
				int num4 = strstart - blockStart;
				if (prevAvailable)
				{
					num4--;
				}
				bool flag = finish && lookahead == 0 && !prevAvailable;
				huffman.FlushBlock(window.Span, blockStart, num4, flag);
				blockStart += num4;
				return !flag;
			}
		}
		return true;
	}
}
