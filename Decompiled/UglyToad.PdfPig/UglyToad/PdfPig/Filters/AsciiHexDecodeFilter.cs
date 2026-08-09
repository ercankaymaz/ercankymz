using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters;

public sealed class AsciiHexDecodeFilter : IFilter
{
	private static readonly short[] ReverseHex = new short[103]
	{
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, 0, 1,
		2, 3, 4, 5, 6, 7, 8, 9, -1, -1,
		-1, -1, -1, -1, -1, 10, 11, 12, 13, 14,
		15, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, 10, 11, 12,
		13, 14, 15
	};

	public bool IsSupported { get; } = true;

	public Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex)
	{
		Span<byte> span = stackalloc byte[2];
		Span<byte> span2 = input.Span;
		int num = 0;
		using ArrayPoolBufferWriter<byte> arrayPoolBufferWriter = new ArrayPoolBufferWriter<byte>(input.Length);
		for (int i = 0; i < input.Length && span2[i] != 62; i++)
		{
			if (!IsWhitespace(span2[i]) && span2[i] != 60)
			{
				span[num] = span2[i];
				num++;
				if (num == 2)
				{
					WriteHexToByte(span, arrayPoolBufferWriter);
					num = 0;
				}
			}
		}
		if (num > 0)
		{
			if (num == 1)
			{
				span[1] = 48;
			}
			WriteHexToByte(span, arrayPoolBufferWriter);
		}
		return arrayPoolBufferWriter.WrittenMemory.ToArray();
	}

	private static void WriteHexToByte(ReadOnlySpan<byte> hexBytes, ArrayPoolBufferWriter<byte> writer)
	{
		short num = ReverseHex[hexBytes[0]];
		short num2 = ReverseHex[hexBytes[1]];
		if (num == -1)
		{
			throw new InvalidOperationException("Invalid character encountered in hex encoded stream: " + (char)hexBytes[0]);
		}
		if (num2 == -1)
		{
			throw new InvalidOperationException("Invalid character encountered in hex encoded stream: " + (char)hexBytes[0]);
		}
		byte value = (byte)(num * 16 + num2);
		writer.Write(value);
	}

	private static bool IsWhitespace(byte c)
	{
		if (c != 0 && c != 9 && c != 10 && c != 12 && c != 13)
		{
			return c == 32;
		}
		return true;
	}
}
