using System;
using System.Diagnostics;
using System.Text;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

public class CompactFontFormatData
{
	private readonly ReadOnlyMemory<byte> dataBytes;

	public int Position { get; private set; } = -1;

	public int Length => dataBytes.Length;

	[DebuggerStepThrough]
	public CompactFontFormatData(ReadOnlyMemory<byte> dataBytes)
	{
		this.dataBytes = dataBytes;
	}

	public string ReadString(int length, Encoding encoding)
	{
		return encoding.GetString(ReadSpan(length));
	}

	public byte ReadCard8()
	{
		return ReadByte();
	}

	public ushort ReadCard16()
	{
		return (ushort)((ReadByte() << 8) | ReadByte());
	}

	public byte ReadOffsize()
	{
		return ReadByte();
	}

	public int ReadOffset(int offsetSize)
	{
		int num = 0;
		for (int i = 0; i < offsetSize; i++)
		{
			num = (num << 8) | ReadByte();
		}
		return num;
	}

	internal ReadOnlySpan<byte> ReadSpan(int count)
	{
		if (Position + count >= dataBytes.Length)
		{
			throw new IndexOutOfRangeException($"Cannot read past end of data. Attempted to read to {Position + count} when the underlying data is {dataBytes.Length} bytes long.");
		}
		ReadOnlySpan<byte> result = dataBytes.Span.Slice(Position + 1, count);
		Position += count;
		return result;
	}

	public byte ReadByte()
	{
		Position++;
		if (Position >= dataBytes.Length)
		{
			throw new IndexOutOfRangeException($"Cannot read byte at position {Position} of an array which is {dataBytes.Length} bytes long.");
		}
		return dataBytes.Span[Position];
	}

	public byte Peek()
	{
		return dataBytes.Span[Position + 1];
	}

	public bool CanRead()
	{
		return Position < dataBytes.Length - 1;
	}

	public void Seek(int offset)
	{
		Position = offset - 1;
	}

	public long ReadLong()
	{
		return (ReadCard16() << 16) | ReadCard16();
	}

	public int ReadSid()
	{
		return (ReadByte() << 8) | ReadByte();
	}

	public byte[] ReadBytes(int length)
	{
		byte[] array = new byte[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = ReadByte();
		}
		return array;
	}

	public CompactFontFormatData SnapshotPortion(int startLocation, int length)
	{
		if (length == 0)
		{
			return new CompactFontFormatData(Array.Empty<byte>());
		}
		if (startLocation > dataBytes.Length - 1 || startLocation + length > dataBytes.Length)
		{
			throw new ArgumentException($"Attempted to create a snapshot of an invalid portion of the data. Length was {dataBytes.Length}, requested start: {startLocation} and requested length: {length}.");
		}
		byte[] array = new byte[length];
		int num = 0;
		for (int i = startLocation; i < startLocation + length; i++)
		{
			array[num] = dataBytes.Span[i];
			num++;
		}
		return new CompactFontFormatData(array);
	}
}
