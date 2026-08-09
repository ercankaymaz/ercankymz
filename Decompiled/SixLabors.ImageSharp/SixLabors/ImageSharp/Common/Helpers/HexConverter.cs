using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.Common.Helpers;

internal static class HexConverter
{
	public static int HexStringToBytes(ReadOnlySpan<char> chars, Span<byte> bytes)
	{
		if (Numerics.Modulo2(chars.Length) != 0)
		{
			throw new ArgumentException("Input string length must be a multiple of 2", "chars");
		}
		if (bytes.Length << 1 < chars.Length)
		{
			throw new ArgumentException("Output span must be at least half the length of the input string");
		}
		bytes = bytes.Slice(0, chars.Length >> 1);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		while (num2 < bytes.Length)
		{
			num3 = FromChar(chars[num + 1]);
			num4 = FromChar(chars[num]);
			if ((num3 | num4) == 255)
			{
				break;
			}
			bytes[num2++] = (byte)((num4 << 4) | num3);
			num += 2;
		}
		if (num3 == 255)
		{
			num++;
		}
		if ((num3 | num4) == 255)
		{
			throw new ArgumentException("Input string contained non-hexadecimal characters", "chars");
		}
		return num2;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static int FromChar(int c)
		{
			ReadOnlySpan<byte> readOnlySpan = new byte[256]
			{
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 0, 1,
				2, 3, 4, 5, 6, 7, 8, 9, 255, 255,
				255, 255, 255, 255, 255, 10, 11, 12, 13, 14,
				15, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 10, 11, 12,
				13, 14, 15, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
				255, 255, 255, 255, 255, 255
			};
			if ((uint)c < (uint)readOnlySpan.Length)
			{
				return readOnlySpan[c];
			}
			return 255;
		}
	}
}
