using System;

namespace UglyToad.PdfPig.Util;

internal static class Hex
{
	private static readonly char[] HexChars = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	public static void GetUtf8Chars(ReadOnlySpan<byte> bytes, Span<byte> utf8Chars)
	{
		int num = 0;
		ReadOnlySpan<byte> readOnlySpan = bytes;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			byte b = readOnlySpan[i];
			utf8Chars[num++] = (byte)HexChars[GetHighNibble(b)];
			utf8Chars[num++] = (byte)HexChars[GetLowNibble(b)];
		}
	}

	public static string GetString(ReadOnlySpan<byte> bytes)
	{
		char[] array = new char[bytes.Length * 2];
		int num = 0;
		ReadOnlySpan<byte> readOnlySpan = bytes;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			byte b = readOnlySpan[i];
			array[num++] = HexChars[GetHighNibble(b)];
			array[num++] = HexChars[GetLowNibble(b)];
		}
		return new string(array);
	}

	private static int GetHighNibble(byte b)
	{
		return (b & 0xF0) >> 4;
	}

	private static int GetLowNibble(byte b)
	{
		return b & 0xF;
	}
}
