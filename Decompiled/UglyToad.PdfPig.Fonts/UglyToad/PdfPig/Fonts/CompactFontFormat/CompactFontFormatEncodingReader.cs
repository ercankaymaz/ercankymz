using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;
using UglyToad.PdfPig.Fonts.Encodings;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal static class CompactFontFormatEncodingReader
{
	public static Encoding ReadEncoding(CompactFontFormatData data, ICompactFontFormatCharset charset, ReadOnlySpan<string> stringIndex)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		byte b = data.ReadCard8();
		return (b & 0x7F) switch
		{
			0 => ReadFormat0Encoding(data, charset, stringIndex, b), 
			1 => ReadFormat1Encoding(data, charset, stringIndex, b), 
			_ => throw new InvalidFontFormatException($"The provided format {b} for this Compact Font Format encoding was invalid."), 
		};
	}

	private static CompactFontFormatFormat0Encoding ReadFormat0Encoding(CompactFontFormatData data, ICompactFontFormatCharset charset, ReadOnlySpan<string> stringIndex, byte format)
	{
		byte b = data.ReadCard8();
		using ArrayPoolBufferWriter<(int, int, string)> arrayPoolBufferWriter = new ArrayPoolBufferWriter<(int, int, string)>();
		for (int i = 1; i <= b; i++)
		{
			byte item = data.ReadCard8();
			int stringIdByGlyphId = charset.GetStringIdByGlyphId(i);
			string item2 = ReadString(stringIdByGlyphId, stringIndex);
			arrayPoolBufferWriter.Write((item, stringIdByGlyphId, item2));
		}
		IReadOnlyList<CompactFontFormatBuiltInEncoding.Supplement> supplements = Array.Empty<CompactFontFormatBuiltInEncoding.Supplement>();
		if (HasSupplement(format))
		{
			supplements = ReadSupplement(data, stringIndex);
		}
		return new CompactFontFormatFormat0Encoding(arrayPoolBufferWriter.WrittenSpan, supplements);
	}

	private static CompactFontFormatFormat1Encoding ReadFormat1Encoding(CompactFontFormatData data, ICompactFontFormatCharset charset, ReadOnlySpan<string> stringIndex, byte format)
	{
		byte b = data.ReadCard8();
		List<(int, int, string)> list = new List<(int, int, string)>();
		int num = 1;
		for (int i = 0; i < b; i++)
		{
			int num2 = data.ReadCard8();
			int num3 = data.ReadCard8();
			for (int j = 0; j < 1 + num3; j++)
			{
				int stringIdByGlyphId = charset.GetStringIdByGlyphId(num);
				int item = num2 + j;
				string item2 = ReadString(stringIdByGlyphId, stringIndex);
				list.Add((item, stringIdByGlyphId, item2));
				num++;
			}
		}
		IReadOnlyList<CompactFontFormatBuiltInEncoding.Supplement> supplements = new List<CompactFontFormatBuiltInEncoding.Supplement>();
		if (HasSupplement(format))
		{
			supplements = ReadSupplement(data, stringIndex);
		}
		return new CompactFontFormatFormat1Encoding(b, list, supplements);
	}

	private static IReadOnlyList<CompactFontFormatBuiltInEncoding.Supplement> ReadSupplement(CompactFontFormatData dataInput, ReadOnlySpan<string> stringIndex)
	{
		CompactFontFormatBuiltInEncoding.Supplement[] array = new CompactFontFormatBuiltInEncoding.Supplement[dataInput.ReadCard8()];
		for (int i = 0; i < array.Length; i++)
		{
			byte code = dataInput.ReadCard8();
			int num = dataInput.ReadSid();
			string name = ReadString(num, stringIndex);
			array[i] = new CompactFontFormatBuiltInEncoding.Supplement(code, num, name);
		}
		return array;
	}

	private static string ReadString(int index, ReadOnlySpan<string> stringIndex)
	{
		if (index >= 0 && index <= 390)
		{
			return CompactFontFormatStandardStrings.GetName(index);
		}
		if (index - 391 < stringIndex.Length)
		{
			return stringIndex[index - 391];
		}
		return "SID" + index;
	}

	private static bool HasSupplement(byte format)
	{
		return (format & 0x80) != 0;
	}
}
