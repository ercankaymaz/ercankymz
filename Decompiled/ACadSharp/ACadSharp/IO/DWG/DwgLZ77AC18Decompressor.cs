using System;
using System.IO;

namespace ACadSharp.IO.DWG;

internal static class DwgLZ77AC18Decompressor
{
	public static Stream Decompress(Stream compressed, long decompressedSize)
	{
		MemoryStream memoryStream = HugeMemoryStream.Create(decompressedSize);
		DecompressToDest(compressed, memoryStream);
		memoryStream.Position = 0L;
		return memoryStream;
	}

	public static void DecompressToDest(Stream src, Stream dst)
	{
		byte[] tempBuf = new byte[128];
		int num = (byte)src.ReadByte();
		if ((num & 0xF0) == 0)
		{
			num = copy(literalCount(num, src) + 3, src, dst, ref tempBuf);
		}
		while (num != 17)
		{
			int offset = 0;
			int num2 = 0;
			switch (num)
			{
			default:
			{
				num2 = (num >> 4) - 1;
				byte b = (byte)src.ReadByte();
				offset = (((num >> 2) & 3) | (b << 2)) + 1;
				break;
			}
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
				num2 = readCompressedBytes(num, 7, src);
				offset = (num & 8) << 11;
				num = twoByteOffset(ref offset, 16384, src);
				break;
			case 32:
			case 33:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
			case 58:
			case 59:
			case 60:
			case 61:
			case 62:
			case 63:
				if (num >= 32)
				{
					num2 = readCompressedBytes(num, 31, src);
					num = twoByteOffset(ref offset, 1, src);
				}
				break;
			}
			long position = dst.Position;
			if (tempBuf.Length < num2)
			{
				tempBuf = new byte[num2];
			}
			dst.Position = position - offset;
			dst.Read(tempBuf, 0, Math.Min(num2, offset));
			dst.Position = position;
			while (num2 > 0)
			{
				dst.Write(tempBuf, 0, Math.Min(num2, offset));
				num2 -= offset;
			}
			int num3 = num & 3;
			if (num3 == 0)
			{
				num = (byte)src.ReadByte();
				if ((num & 0xF0) == 0)
				{
					num3 = literalCount(num, src) + 3;
				}
			}
			if ((long)num3 > 0L)
			{
				num = copy(num3, src, dst, ref tempBuf);
			}
		}
	}

	private static byte copy(int count, Stream src, Stream dst, ref byte[] tempBuf)
	{
		if (tempBuf.Length < count)
		{
			tempBuf = new byte[count];
		}
		src.Read(tempBuf, 0, count);
		dst.Write(tempBuf, 0, count);
		return (byte)src.ReadByte();
	}

	private static int literalCount(int code, Stream src)
	{
		int num = code & 0xF;
		if (num == 0)
		{
			byte b;
			for (b = (byte)src.ReadByte(); b == 0; b = (byte)src.ReadByte())
			{
				num += 255;
			}
			num += 15 + b;
		}
		return num;
	}

	private static int readCompressedBytes(int opcode1, int validBits, Stream compressed)
	{
		int num = opcode1 & validBits;
		if (num == 0)
		{
			byte b;
			for (b = (byte)compressed.ReadByte(); b == 0; b = (byte)compressed.ReadByte())
			{
				num += 255;
			}
			num += b + validBits;
		}
		return num + 2;
	}

	private static int twoByteOffset(ref int offset, int addedValue, Stream stream)
	{
		int num = stream.ReadByte();
		offset |= num >> 2;
		offset |= stream.ReadByte() << 6;
		offset += addedValue;
		return num;
	}
}
