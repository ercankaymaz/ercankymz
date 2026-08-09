using System;
using System.Buffers.Binary;

namespace UglyToad.PdfPig.Images;

internal static class Jpeg2000Helper
{
	public static byte GetBitsPerComponent(ReadOnlySpan<byte> jp2Bytes)
	{
		if (jp2Bytes.Length < 12)
		{
			throw new InvalidOperationException("Input is too short to be a valid JP2 file.");
		}
		uint num = BinaryPrimitives.ReadUInt32BigEndian(jp2Bytes.Slice(0, 4));
		if (num == 4283432785u)
		{
			return ParseCodestream(jp2Bytes);
		}
		uint num2 = BinaryPrimitives.ReadUInt32BigEndian(jp2Bytes.Slice(4, 4));
		uint num3 = BinaryPrimitives.ReadUInt32BigEndian(jp2Bytes.Slice(8, 4));
		if (num == 12 && num2 == 1783636000 && num3 == 218793738)
		{
			return ParseBoxes(jp2Bytes.Slice(12));
		}
		throw new InvalidOperationException("Invalid JP2 or J2K signature.");
	}

	private static byte ParseBoxes(ReadOnlySpan<byte> jp2Bytes)
	{
		uint num;
		for (int i = 0; i < jp2Bytes.Length; i += (int)((num != 0) ? num : 8))
		{
			if (i + 8 > jp2Bytes.Length)
			{
				throw new InvalidOperationException("Invalid JP2 or J2K box structure.");
			}
			num = BinaryPrimitives.ReadUInt32BigEndian(jp2Bytes.Slice(i, 4));
			if (BinaryPrimitives.ReadUInt32BigEndian(jp2Bytes.Slice(i + 4, 4)) == 1785737827)
			{
				return ParseCodestream(jp2Bytes.Slice(i + 8));
			}
		}
		throw new InvalidOperationException("Codestream box not found in JP2 or J2K file.");
	}

	private static byte ParseCodestream(ReadOnlySpan<byte> codestream)
	{
		for (int i = 0; i + 2 <= codestream.Length; i += 2)
		{
			if (BinaryPrimitives.ReadUInt16BigEndian(codestream.Slice(i, 2)) == 65361)
			{
				if (i + 38 > codestream.Length)
				{
					throw new InvalidOperationException("Invalid SIZ marker structure.");
				}
				i += 38;
				ushort num = BinaryPrimitives.ReadUInt16BigEndian(codestream.Slice(i, 2));
				i += 2;
				if (num < 1)
				{
					throw new InvalidOperationException("Invalid number of components in SIZ marker.");
				}
				return (byte)(codestream[i] + 1);
			}
		}
		throw new InvalidOperationException("SIZ marker not found in JPEG2000 codestream.");
	}
}
