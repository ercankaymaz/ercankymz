using System;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Compression.Zlib;

internal sealed class Deflater : IDisposable
{
	public enum CompressionLevel
	{
		BestCompression = 9,
		BestSpeed = 1,
		DefaultCompression = -1,
		NoCompression = 0,
		Deflated = 8
	}

	public const int BestCompression = 9;

	public const int BestSpeed = 1;

	public const int DefaultCompression = -1;

	public const int NoCompression = 0;

	public const int Deflated = 8;

	private int level;

	private int state;

	private DeflaterEngine engine;

	private bool isDisposed;

	private const int IsFlushing = 4;

	private const int IsFinishing = 8;

	private const int BusyState = 16;

	private const int FlushingState = 20;

	private const int FinishingState = 28;

	private const int FinishedState = 30;

	private const int ClosedState = 127;

	public bool IsFinished
	{
		get
		{
			if (state == 30)
			{
				return engine.Pending.IsFlushed;
			}
			return false;
		}
	}

	public bool IsNeedingInput => engine.NeedsInput();

	public Deflater(MemoryAllocator memoryAllocator, int level)
	{
		switch (level)
		{
		case -1:
			level = 6;
			break;
		default:
			throw new ArgumentOutOfRangeException("level");
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
			break;
		}
		engine = new DeflaterEngine(memoryAllocator, DeflateStrategy.Default);
		SetLevel(level);
		Reset();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Reset()
	{
		state = 16;
		engine.Pending.Reset();
		engine.Reset();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Flush()
	{
		state |= 4;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Finish()
	{
		state |= 12;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetInput(byte[] input, int offset, int count)
	{
		if ((state & 8) != 0)
		{
			DeflateThrowHelper.ThrowAlreadyFinished();
		}
		engine.SetInput(input, offset, count);
	}

	public void SetLevel(int level)
	{
		switch (level)
		{
		case -1:
			level = 6;
			break;
		default:
			throw new ArgumentOutOfRangeException("level");
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
			break;
		}
		if (this.level != level)
		{
			this.level = level;
			engine.SetLevel(level);
		}
	}

	public int Deflate(Span<byte> output, int offset, int length)
	{
		int num = length;
		if (state == 127)
		{
			DeflateThrowHelper.ThrowAlreadyClosed();
		}
		while (true)
		{
			int num2 = engine.Pending.Flush(output, offset, length);
			offset += num2;
			length -= num2;
			if (length == 0 || state == 30)
			{
				break;
			}
			if (engine.Deflate((state & 4) != 0, (state & 8) != 0))
			{
				continue;
			}
			switch (state)
			{
			case 16:
				return num - length;
			case 20:
				if (level != 0)
				{
					for (int num3 = 8 + (-engine.Pending.BitCount & 7); num3 > 0; num3 -= 10)
					{
						engine.Pending.WriteBits(2, 10);
					}
				}
				state = 16;
				break;
			case 28:
				engine.Pending.AlignToByte();
				state = 30;
				break;
			}
		}
		return num - length;
	}

	public void Dispose()
	{
		if (!isDisposed)
		{
			engine.Dispose();
			isDisposed = true;
		}
	}
}
