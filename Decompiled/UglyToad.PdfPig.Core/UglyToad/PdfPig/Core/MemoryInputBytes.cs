using System;
using System.Diagnostics;

namespace UglyToad.PdfPig.Core;

public sealed class MemoryInputBytes : IInputBytes, IDisposable
{
	private readonly int upperBound;

	private readonly ReadOnlyMemory<byte> memory;

	private int currentOffset;

	public long CurrentOffset => currentOffset + 1;

	public byte CurrentByte { get; private set; }

	public long Length => memory.Span.Length;

	[DebuggerStepThrough]
	public MemoryInputBytes(ReadOnlyMemory<byte> memory)
	{
		this.memory = memory;
		upperBound = this.memory.Length - 1;
		currentOffset = -1;
	}

	public bool MoveNext()
	{
		if (currentOffset == upperBound)
		{
			return false;
		}
		currentOffset++;
		CurrentByte = memory.Span[currentOffset];
		return true;
	}

	public byte? Peek()
	{
		if (currentOffset == upperBound)
		{
			return null;
		}
		return memory.Span[currentOffset + 1];
	}

	public bool IsAtEnd()
	{
		return currentOffset == upperBound;
	}

	public void Seek(long position)
	{
		currentOffset = (int)position - 1;
		CurrentByte = (byte)((currentOffset >= 0) ? memory.Span[currentOffset] : 0);
	}

	public int Read(Span<byte> buffer)
	{
		if (buffer.IsEmpty)
		{
			return 0;
		}
		int num = memory.Length - currentOffset - 1;
		int num2 = ((num < buffer.Length) ? num : buffer.Length);
		int start = currentOffset + 1;
		memory.Span.Slice(start, num2).CopyTo(buffer);
		if (num2 > 0)
		{
			currentOffset += num2;
			CurrentByte = buffer[num2 - 1];
		}
		return num2;
	}

	public void Dispose()
	{
	}
}
