using System;
using System.IO;

namespace Org.BouncyCastle.Utilities.IO;

public static class BinaryReaders
{
	public static byte[] ReadBytesFully(BinaryReader binaryReader, int count)
	{
		byte[] array = binaryReader.ReadBytes(count);
		if (array == null || array.Length != count)
		{
			throw new EndOfStreamException();
		}
		return array;
	}

	public static short ReadInt16BigEndian(BinaryReader binaryReader)
	{
		short num = binaryReader.ReadInt16();
		if (!BitConverter.IsLittleEndian)
		{
			return num;
		}
		return Shorts.ReverseBytes(num);
	}

	public static short ReadInt16LittleEndian(BinaryReader binaryReader)
	{
		short num = binaryReader.ReadInt16();
		if (!BitConverter.IsLittleEndian)
		{
			return Shorts.ReverseBytes(num);
		}
		return num;
	}

	public static int ReadInt32BigEndian(BinaryReader binaryReader)
	{
		int num = binaryReader.ReadInt32();
		if (!BitConverter.IsLittleEndian)
		{
			return num;
		}
		return Integers.ReverseBytes(num);
	}

	public static int ReadInt32LittleEndian(BinaryReader binaryReader)
	{
		int num = binaryReader.ReadInt32();
		if (!BitConverter.IsLittleEndian)
		{
			return Integers.ReverseBytes(num);
		}
		return num;
	}

	public static long ReadInt64BigEndian(BinaryReader binaryReader)
	{
		long num = binaryReader.ReadInt64();
		if (!BitConverter.IsLittleEndian)
		{
			return num;
		}
		return Longs.ReverseBytes(num);
	}

	public static long ReadInt64LittleEndian(BinaryReader binaryReader)
	{
		long num = binaryReader.ReadInt64();
		if (!BitConverter.IsLittleEndian)
		{
			return Longs.ReverseBytes(num);
		}
		return num;
	}

	[CLSCompliant(false)]
	public static ushort ReadUInt16BigEndian(BinaryReader binaryReader)
	{
		ushort num = binaryReader.ReadUInt16();
		if (!BitConverter.IsLittleEndian)
		{
			return num;
		}
		return Shorts.ReverseBytes(num);
	}

	[CLSCompliant(false)]
	public static ushort ReadUInt16LittleEndian(BinaryReader binaryReader)
	{
		ushort num = binaryReader.ReadUInt16();
		if (!BitConverter.IsLittleEndian)
		{
			return Shorts.ReverseBytes(num);
		}
		return num;
	}

	[CLSCompliant(false)]
	public static uint ReadUInt32BigEndian(BinaryReader binaryReader)
	{
		uint num = binaryReader.ReadUInt32();
		if (!BitConverter.IsLittleEndian)
		{
			return num;
		}
		return Integers.ReverseBytes(num);
	}

	[CLSCompliant(false)]
	public static uint ReadUInt32LittleEndian(BinaryReader binaryReader)
	{
		uint num = binaryReader.ReadUInt32();
		if (!BitConverter.IsLittleEndian)
		{
			return Integers.ReverseBytes(num);
		}
		return num;
	}

	[CLSCompliant(false)]
	public static ulong ReadUInt64BigEndian(BinaryReader binaryReader)
	{
		ulong num = binaryReader.ReadUInt64();
		if (!BitConverter.IsLittleEndian)
		{
			return num;
		}
		return Longs.ReverseBytes(num);
	}

	[CLSCompliant(false)]
	public static ulong ReadUInt64LittleEndian(BinaryReader binaryReader)
	{
		ulong num = binaryReader.ReadUInt64();
		if (!BitConverter.IsLittleEndian)
		{
			return Longs.ReverseBytes(num);
		}
		return num;
	}
}
