using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.CompactFontFormat.CharStrings;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Fonts.Type1.CharStrings;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

internal class CompactFontFormatIndividualFontParser
{
	private readonly CompactFontFormatTopLevelDictionaryReader topLevelDictionaryReader;

	private readonly CompactFontFormatPrivateDictionaryReader privateDictionaryReader;

	public CompactFontFormatIndividualFontParser(CompactFontFormatTopLevelDictionaryReader topLevelDictionaryReader, CompactFontFormatPrivateDictionaryReader privateDictionaryReader)
	{
		this.topLevelDictionaryReader = topLevelDictionaryReader;
		this.privateDictionaryReader = privateDictionaryReader;
	}

	public CompactFontFormatFont Parse(CompactFontFormatData data, string name, ReadOnlySpan<byte> topDictionaryIndex, ReadOnlySpan<string> stringIndex, CompactFontFormatIndex globalSubroutineIndex)
	{
		CompactFontFormatData data2 = new CompactFontFormatData(topDictionaryIndex.ToArray());
		CompactFontFormatTopLevelDictionary compactFontFormatTopLevelDictionary = topLevelDictionaryReader.Read(data2, stringIndex);
		CompactFontFormatPrivateDictionary compactFontFormatPrivateDictionary = CompactFontFormatPrivateDictionary.GetDefault();
		if (compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.HasValue && compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.Value.Size > 0)
		{
			CompactFontFormatData data3 = data.SnapshotPortion(compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.Value.Offset, compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.Value.Size);
			compactFontFormatPrivateDictionary = privateDictionaryReader.Read(data3, stringIndex);
		}
		if (compactFontFormatTopLevelDictionary.CharStringsOffset < 0)
		{
			throw new InvalidOperationException("Expected CFF to contain a CharString offset.");
		}
		CompactFontFormatIndex compactFontFormatIndex = CompactFontFormatIndex.None;
		if (compactFontFormatPrivateDictionary.LocalSubroutineOffset.HasValue && compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.HasValue)
		{
			data.Seek(compactFontFormatPrivateDictionary.LocalSubroutineOffset.Value + compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.Value.Offset);
			compactFontFormatIndex = CompactFontFormatIndexReader.ReadDictionaryData(data);
		}
		data.Seek(compactFontFormatTopLevelDictionary.CharStringsOffset);
		CompactFontFormatIndex compactFontFormatIndex2 = CompactFontFormatIndexReader.ReadDictionaryData(data);
		ICompactFontFormatCharset charset;
		if (compactFontFormatTopLevelDictionary.CharSetOffset < 0)
		{
			charset = ((!compactFontFormatTopLevelDictionary.IsCidFont) ? ((ICompactFontFormatCharset)CompactFontFormatIsoAdobeCharset.Value) : ((ICompactFontFormatCharset)new CompactFontFormatEmptyCharset(compactFontFormatIndex2.Count)));
		}
		else
		{
			int charSetOffset = compactFontFormatTopLevelDictionary.CharSetOffset;
			charset = ((!compactFontFormatTopLevelDictionary.IsCidFont && charSetOffset == 0) ? CompactFontFormatIsoAdobeCharset.Value : ((!compactFontFormatTopLevelDictionary.IsCidFont && charSetOffset == 1) ? CompactFontFormatExpertCharset.Value : ((compactFontFormatTopLevelDictionary.IsCidFont || charSetOffset != 2) ? ReadCharset(data, compactFontFormatTopLevelDictionary, compactFontFormatIndex2, stringIndex) : CompactFontFormatExpertSubsetCharset.Value)));
		}
		if (compactFontFormatTopLevelDictionary.IsCidFont)
		{
			return ReadCidFont(data, compactFontFormatTopLevelDictionary, compactFontFormatIndex2.Count, stringIndex, compactFontFormatPrivateDictionary, charset, globalSubroutineIndex, compactFontFormatIndex, compactFontFormatIndex2);
		}
		int encodingOffset = compactFontFormatTopLevelDictionary.EncodingOffset;
		Encoding fontEncoding = null;
		switch (encodingOffset)
		{
		case 0:
			fontEncoding = CompactFontFormatStandardEncoding.Instance;
			break;
		case 1:
			fontEncoding = CompactFontFormatExpertEncoding.Instance;
			break;
		default:
			data.Seek(encodingOffset);
			fontEncoding = CompactFontFormatEncodingReader.ReadEncoding(data, charset, stringIndex);
			break;
		case -1:
			break;
		}
		CompactFontFormatSubroutinesSelector subroutinesSelector = new CompactFontFormatSubroutinesSelector(globalSubroutineIndex, compactFontFormatIndex);
		Type2CharStrings item = ReadCharStrings(data, compactFontFormatTopLevelDictionary, compactFontFormatIndex2, subroutinesSelector, charset);
		return new CompactFontFormatFont(compactFontFormatTopLevelDictionary, compactFontFormatPrivateDictionary, charset, Union<Type1CharStrings, Type2CharStrings>.Two(item), fontEncoding);
	}

	private static ICompactFontFormatCharset ReadCharset(CompactFontFormatData data, CompactFontFormatTopLevelDictionary topDictionary, CompactFontFormatIndex charStringIndex, ReadOnlySpan<string> stringIndex)
	{
		data.Seek(topDictionary.CharSetOffset);
		byte b = data.ReadCard8();
		switch (b)
		{
		case 0:
		{
			using ArrayPoolBufferWriter<(int, int, string)> arrayPoolBufferWriter2 = new ArrayPoolBufferWriter<(int, int, string)>();
			for (int k = 1; k < charStringIndex.Count; k++)
			{
				int num4 = data.ReadSid();
				arrayPoolBufferWriter2.Write((k, num4, ReadString(num4, stringIndex)));
			}
			return new CompactFontFormatFormat0Charset(arrayPoolBufferWriter2.WrittenSpan);
		}
		case 1:
		case 2:
		{
			using ArrayPoolBufferWriter<(int, int, string)> arrayPoolBufferWriter = new ArrayPoolBufferWriter<(int, int, string)>();
			for (int i = 1; i < charStringIndex.Count; i++)
			{
				int num = data.ReadSid();
				ushort num2 = ((b == 1) ? data.ReadCard8() : data.ReadCard16());
				arrayPoolBufferWriter.Write((i, num, ReadString(num, stringIndex)));
				for (int j = 0; j < num2; j++)
				{
					i++;
					int num3 = num + j + 1;
					arrayPoolBufferWriter.Write((i, num3, ReadString(num3, stringIndex)));
				}
			}
			if (b == 1)
			{
				return new CompactFontFormatFormat1Charset(arrayPoolBufferWriter.WrittenSpan);
			}
			return new CompactFontFormatFormat2Charset(arrayPoolBufferWriter.WrittenSpan);
		}
		default:
			throw new InvalidOperationException($"Unrecognized format for the Charset table in a CFF font. Got: {b}.");
		}
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

	private static Type2CharStrings ReadCharStrings(CompactFontFormatData data, CompactFontFormatTopLevelDictionary topDictionary, CompactFontFormatIndex charStringIndex, CompactFontFormatSubroutinesSelector subroutinesSelector, ICompactFontFormatCharset charset)
	{
		data.Seek(topDictionary.CharStringsOffset);
		return topDictionary.CharStringType switch
		{
			CompactFontFormatCharStringType.Type1 => throw new NotImplementedException("Type 1 CharStrings are not currently supported in CFF font."), 
			CompactFontFormatCharStringType.Type2 => Type2CharStringParser.Parse(charStringIndex, subroutinesSelector, charset), 
			_ => throw new ArgumentOutOfRangeException($"Unexpected CharString type in CFF font: {topDictionary.CharStringType}."), 
		};
	}

	private CompactFontFormatCidFont ReadCidFont(CompactFontFormatData data, CompactFontFormatTopLevelDictionary topLevelDictionary, int numberOfGlyphs, ReadOnlySpan<string> stringIndex, CompactFontFormatPrivateDictionary privateDictionary, ICompactFontFormatCharset charset, CompactFontFormatIndex globalSubroutines, CompactFontFormatIndex localSubroutinesTop, CompactFontFormatIndex charStringIndex)
	{
		int fontDictionaryArray = topLevelDictionary.CidFontOperators.FontDictionaryArray;
		data.Seek(fontDictionaryArray);
		CompactFontFormatIndex compactFontFormatIndex = CompactFontFormatIndexReader.ReadDictionaryData(data);
		List<CompactFontFormatPrivateDictionary> list = new List<CompactFontFormatPrivateDictionary>();
		List<CompactFontFormatTopLevelDictionary> list2 = new List<CompactFontFormatTopLevelDictionary>();
		List<CompactFontFormatIndex> list3 = new List<CompactFontFormatIndex>();
		foreach (ReadOnlyMemory<byte> item2 in compactFontFormatIndex)
		{
			CompactFontFormatTopLevelDictionary compactFontFormatTopLevelDictionary = topLevelDictionaryReader.Read(new CompactFontFormatData(item2), stringIndex);
			if (!compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.HasValue)
			{
				throw new InvalidFontFormatException("The CID keyed Compact Font Format font did not contain a private dictionary for the font dictionary.");
			}
			CompactFontFormatData data2 = data.SnapshotPortion(compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.Value.Offset, compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.Value.Size);
			CompactFontFormatPrivateDictionary compactFontFormatPrivateDictionary = privateDictionaryReader.Read(data2, stringIndex);
			if (compactFontFormatPrivateDictionary.LocalSubroutineOffset.HasValue && compactFontFormatPrivateDictionary.LocalSubroutineOffset.Value > 0)
			{
				data.Seek(compactFontFormatTopLevelDictionary.PrivateDictionaryLocation.Value.Offset + compactFontFormatPrivateDictionary.LocalSubroutineOffset.Value);
				CompactFontFormatIndex item = CompactFontFormatIndexReader.ReadDictionaryData(data);
				list3.Add(item);
			}
			else
			{
				list3.Add(null);
			}
			list2.Add(compactFontFormatTopLevelDictionary);
			list.Add(compactFontFormatPrivateDictionary);
		}
		data.Seek(topLevelDictionary.CidFontOperators.FontDictionarySelect);
		byte b = data.ReadCard8();
		ICompactFontFormatFdSelect fdSelect = b switch
		{
			0 => ReadFormat0FdSelect(data, numberOfGlyphs, topLevelDictionary.CidFontOperators.Ros), 
			3 => ReadFormat3FdSelect(data, topLevelDictionary.CidFontOperators.Ros), 
			_ => throw new InvalidFontFormatException($"Invalid Font Dictionary Select format: {b}."), 
		};
		CompactFontFormatSubroutinesSelector subroutinesSelector = new CompactFontFormatSubroutinesSelector(globalSubroutines, localSubroutinesTop, fdSelect, list3);
		Union<Type1CharStrings, Type2CharStrings>.Case2 charStrings = Union<Type1CharStrings, Type2CharStrings>.Two(ReadCharStrings(data, topLevelDictionary, charStringIndex, subroutinesSelector, charset));
		return new CompactFontFormatCidFont(topLevelDictionary, privateDictionary, charset, charStrings, list2, list, fdSelect);
	}

	private static CompactFontFormat0FdSelect ReadFormat0FdSelect(CompactFontFormatData data, int numberOfGlyphs, RegistryOrderingSupplement registryOrderingSupplement)
	{
		int[] array = new int[numberOfGlyphs];
		for (int i = 0; i < numberOfGlyphs; i++)
		{
			array[i] = data.ReadCard8();
		}
		return new CompactFontFormat0FdSelect(registryOrderingSupplement, array);
	}

	private static CompactFontFormat3FdSelect ReadFormat3FdSelect(CompactFontFormatData data, RegistryOrderingSupplement registryOrderingSupplement)
	{
		ushort num = data.ReadCard16();
		CompactFontFormat3FdSelect.Range3[] array = new CompactFontFormat3FdSelect.Range3[num];
		for (int i = 0; i < num; i++)
		{
			ushort first = data.ReadCard16();
			byte fontDictionary = data.ReadCard8();
			array[i] = new CompactFontFormat3FdSelect.Range3(first, fontDictionary);
		}
		ushort sentinel = data.ReadCard16();
		return new CompactFontFormat3FdSelect(registryOrderingSupplement, array, sentinel);
	}
}
