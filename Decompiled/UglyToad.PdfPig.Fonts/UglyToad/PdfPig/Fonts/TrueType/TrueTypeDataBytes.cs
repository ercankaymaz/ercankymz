using System;
using System.Buffers.Binary;
using System.Text;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType;

public class TrueTypeDataBytes
{
	private readonly IInputBytes inputBytes;

	public long Position => inputBytes.CurrentOffset;

	public long Length => inputBytes.Length;

	public TrueTypeDataBytes(byte[] bytes)
		: this(new MemoryInputBytes(bytes))
	{
	}

	public TrueTypeDataBytes(IInputBytes inputBytes)
	{
		this.inputBytes = inputBytes ?? throw new ArgumentNullException("inputBytes");
	}

	public float Read32Fixed()
	{
		return (float)ReadSignedShort() + (float)(int)ReadUnsignedShort() / 65536f;
	}

	public short ReadSignedShort()
	{
		Span<byte> buffer = stackalloc byte[2];
		ReadBuffered(buffer);
		return (short)((buffer[0] << 8) + buffer[1]);
	}

	public ushort ReadUnsignedShort()
	{
		Span<byte> buffer = stackalloc byte[2];
		ReadBuffered(buffer);
		return (ushort)((buffer[0] << 8) + buffer[1]);
	}

	public byte ReadByte()
	{
		Span<byte> buffer = stackalloc byte[1];
		ReadBuffered(buffer);
		return buffer[0];
	}

	public string ReadTag()
	{
		if (TryReadString(4, Encoding.UTF8, out string result))
		{
			return result;
		}
		throw new InvalidOperationException($"Could not read Tag from TrueType file at {inputBytes.CurrentOffset}.");
	}

	public bool TryReadString(int bytesToRead, Encoding encoding, out string result)
	{
		result = null;
		if (encoding == null)
		{
			return false;
		}
		Span<byte> span = ((bytesToRead > 64) ? ((Span<byte>)new byte[bytesToRead]) : stackalloc byte[bytesToRead]);
		Span<byte> span2 = span;
		if (ReadBuffered(span2))
		{
			result = encoding.GetString(span2);
			return true;
		}
		return false;
	}

	public uint ReadUnsignedInt()
	{
		Span<byte> span = stackalloc byte[4];
		ReadBuffered(span);
		return BinaryPrimitives.ReadUInt32BigEndian(span);
	}

	public int ReadSignedInt()
	{
		Span<byte> span = stackalloc byte[4];
		ReadBuffered(span);
		return BinaryPrimitives.ReadInt32BigEndian(span);
	}

	public long ReadLong()
	{
		long num = ReadSignedInt();
		int num2 = ReadSignedInt();
		return (num << 32) + (num2 & 0xFFFFFFFFu);
	}

	public DateTime ReadInternationalDate()
	{
		long num = ReadLong();
		DateTime dateTime = new DateTime(1904, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		try
		{
			return dateTime.AddSeconds(num);
		}
		catch (ArgumentOutOfRangeException)
		{
			throw new InvalidFontFormatException($"Invalid date offset ({num} seconds) encountered in TrueType header table.");
		}
	}

	public void Seek(long position)
	{
		inputBytes.Seek(position);
	}

	public int ReadSignedByte()
	{
		Span<byte> buffer = stackalloc byte[1];
		ReadBuffered(buffer);
		byte b = buffer[0];
		if (b >= 127)
		{
			return b - 256;
		}
		return b;
	}

	public ushort[] ReadUnsignedShortArray(int length)
	{
		ushort[] array = new ushort[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = ReadUnsignedShort();
		}
		return array;
	}

	public byte[] ReadByteArray(int length)
	{
		byte[] array = new byte[length];
		ReadBuffered(array);
		return array;
	}

	public uint[] ReadUnsignedIntArray(int length)
	{
		uint[] array = new uint[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = ReadUnsignedInt();
		}
		return array;
	}

	public short[] ReadShortArray(int length)
	{
		short[] array = new short[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = ReadSignedShort();
		}
		return array;
	}

	public override string ToString()
	{
		return $"@: {Position} of {inputBytes.Length} bytes.";
	}

	private bool ReadBuffered(Span<byte> buffer)
	{
		return inputBytes.Read(buffer) == buffer.Length;
	}
}
