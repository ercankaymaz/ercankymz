using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

public static class CompactFontFormatParser
{
	private const string TagOtto = "OTTO";

	private const string TagTtcf = "ttcf";

	private const string TagTtfonly = "\0\u0001\0\0";

	public static CompactFontFormatFontCollection Parse(CompactFontFormatData data)
	{
		switch (ReadTag(data))
		{
		case "OTTO":
			throw new NotSupportedException("Currently tagged CFF data is not supported.");
		case "ttcf":
			throw new NotSupportedException("True Type Collection fonts are not currently supported.");
		case "\0\u0001\0\0":
			throw new NotSupportedException("OpenType fonts containing a true type font are not currently supported.");
		default:
		{
			data.Seek(0);
			CompactFontFormatHeader header = ReadHeader(data);
			string[] array = ReadStringIndex(data);
			CompactFontFormatIndex compactFontFormatIndex = CompactFontFormatIndexReader.ReadDictionaryData(data);
			string[] array2 = ReadStringIndex(data);
			CompactFontFormatIndex globalSubroutineIndex = CompactFontFormatIndexReader.ReadDictionaryData(data);
			Dictionary<string, CompactFontFormatFont> dictionary = new Dictionary<string, CompactFontFormatFont>();
			CompactFontFormatIndividualFontParser compactFontFormatIndividualFontParser = new CompactFontFormatIndividualFontParser(new CompactFontFormatTopLevelDictionaryReader(), new CompactFontFormatPrivateDictionaryReader());
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				dictionary[text] = compactFontFormatIndividualFontParser.Parse(data, text, compactFontFormatIndex[i].Span, array2, globalSubroutineIndex);
			}
			return new CompactFontFormatFontCollection(header, dictionary);
		}
		}
	}

	private static string ReadTag(CompactFontFormatData data)
	{
		return data.ReadString(4, OtherEncodings.Iso88591);
	}

	private static CompactFontFormatHeader ReadHeader(CompactFontFormatData data)
	{
		byte majorVersion = data.ReadCard8();
		byte minorVersion = data.ReadCard8();
		byte sizeInBytes = data.ReadCard8();
		byte offsetSize = data.ReadOffsize();
		return new CompactFontFormatHeader(majorVersion, minorVersion, sizeInBytes, offsetSize);
	}

	private static string[] ReadStringIndex(CompactFontFormatData data)
	{
		int[] array = CompactFontFormatIndexReader.ReadIndex(data);
		if (array.Length == 0)
		{
			return Array.Empty<string>();
		}
		int num = array.Length - 1;
		string[] array2 = new string[num];
		for (int i = 0; i < num; i++)
		{
			int num2 = array[i + 1] - array[i];
			if (num2 < 0)
			{
				throw new InvalidOperationException($"Negative object length {num2} at {i}. Current position: {data.Position}.");
			}
			array2[i] = data.ReadString(num2, OtherEncodings.Iso88591);
		}
		return array2;
	}
}
