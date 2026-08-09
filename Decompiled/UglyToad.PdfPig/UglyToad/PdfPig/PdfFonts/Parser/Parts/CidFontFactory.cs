using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.CompactFontFormat;
using UglyToad.PdfPig.Fonts.TrueType;
using UglyToad.PdfPig.Fonts.TrueType.Parser;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.PdfFonts.CidFonts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.PdfFonts.Parser.Parts;

internal sealed class CidFontFactory
{
	private readonly ILookupFilterProvider filterProvider;

	private readonly IPdfTokenScanner pdfScanner;

	private readonly ILog logger;

	public CidFontFactory(ILog log, IPdfTokenScanner pdfScanner, ILookupFilterProvider filterProvider)
	{
		logger = log;
		this.pdfScanner = pdfScanner;
		this.filterProvider = filterProvider;
	}

	public ICidFont? Generate(DictionaryToken dictionary)
	{
		NameToken nameOrDefault = dictionary.GetNameOrDefault(NameToken.Type);
		if (!NameToken.Font.Equals(nameOrDefault))
		{
			throw new InvalidFontFormatException($"Expected 'Font' dictionary but found '{nameOrDefault}'");
		}
		IReadOnlyDictionary<int, double> widths = ReadWidths(dictionary);
		double? defaultWidth = null;
		if (dictionary.TryGet<NumericToken>(NameToken.Dw, pdfScanner, out NumericToken token))
		{
			defaultWidth = token.Double;
		}
		VerticalWritingMetrics verticalWritingMetrics = ReadVerticalDisplacements(dictionary, pdfScanner);
		FontDescriptor fontDescriptor = null;
		if (TryGetFontDescriptor(dictionary, out DictionaryToken descriptorDictionary))
		{
			fontDescriptor = FontDescriptorFactory.Generate(descriptorDictionary, pdfScanner);
		}
		ICidFontProgram fontProgram = null;
		try
		{
			fontProgram = ReadDescriptorFile(fontDescriptor);
		}
		catch (Exception ex)
		{
			logger.Error($"Invalid descriptor in CID font named '{fontDescriptor?.FontName}': {ex.Message}.");
		}
		NameToken nameOrDefault2 = dictionary.GetNameOrDefault(NameToken.BaseFont);
		CharacterIdentifierSystemInfo systemInfo = GetSystemInfo(dictionary);
		NameToken nameOrDefault3 = dictionary.GetNameOrDefault(NameToken.Subtype);
		if (NameToken.CidFontType0.Equals(nameOrDefault3))
		{
			return new Type0CidFont(fontProgram, nameOrDefault, nameOrDefault3, nameOrDefault2, systemInfo, fontDescriptor, verticalWritingMetrics, widths, defaultWidth);
		}
		if (NameToken.CidFontType2.Equals(nameOrDefault3))
		{
			CharacterIdentifierToGlyphIndexMap characterIdentifierToGlyphIndexMap = GetCharacterIdentifierToGlyphIndexMap(dictionary);
			return new Type2CidFont(nameOrDefault, nameOrDefault3, nameOrDefault2, systemInfo, fontDescriptor, fontProgram, verticalWritingMetrics, widths, defaultWidth, characterIdentifierToGlyphIndexMap);
		}
		return null;
	}

	private bool TryGetFontDescriptor(DictionaryToken dictionary, [NotNullWhen(true)] out DictionaryToken? descriptorDictionary)
	{
		return dictionary.TryGet<DictionaryToken>(NameToken.FontDescriptor, pdfScanner, out descriptorDictionary);
	}

	private ICidFontProgram? ReadDescriptorFile(FontDescriptor? descriptor)
	{
		if (descriptor?.FontFile == null)
		{
			return null;
		}
		StreamToken streamToken = DirectObjectFinder.Get<StreamToken>(descriptor.FontFile.ObjectKey, pdfScanner);
		if (streamToken == null)
		{
			return null;
		}
		Memory<byte> memory = streamToken.Decode(filterProvider, pdfScanner);
		switch (descriptor.FontFile.FileType)
		{
		case DescriptorFontFile.FontFileType.TrueType:
			if (IsTrueTypeCff(memory.Span))
			{
				logger.Warn("The CID TrueType font has the signature of a CFF font. Using CID CFF instead.");
				return new PdfCidCompactFontFormatFont(CompactFontFormatParser.Parse(new CompactFontFormatData(memory)));
			}
			return new PdfCidTrueTypeFont(TrueTypeFontParser.Parse(new TrueTypeDataBytes(new MemoryInputBytes(memory))));
		case DescriptorFontFile.FontFileType.FromSubtype:
		{
			if (!DirectObjectFinder.TryGet<StreamToken>(descriptor.FontFile.ObjectKey, pdfScanner, out StreamToken tokenResult))
			{
				throw new NotSupportedException("Cannot read CID font from subtype.");
			}
			if (!tokenResult.StreamDictionary.TryGet(NameToken.Subtype, out NameToken token))
			{
				throw new PdfDocumentFormatException($"The font file stream did not contain a subtype entry: {tokenResult.StreamDictionary}.");
			}
			if (token == NameToken.CidFontType0C || token == NameToken.Type1C)
			{
				return new PdfCidCompactFontFormatFont(CompactFontFormatParser.Parse(new CompactFontFormatData(tokenResult.Decode(filterProvider, pdfScanner))));
			}
			if (token == NameToken.OpenType)
			{
				return new PdfCidTrueTypeFont(TrueTypeFontParser.Parse(new TrueTypeDataBytes(new MemoryInputBytes(tokenResult.Decode(filterProvider, pdfScanner)))));
			}
			throw new PdfDocumentFormatException($"Unexpected subtype for CID font: {token}.");
		}
		default:
			throw new NotSupportedException("Currently only TrueType fonts are supported.");
		}
	}

	private IReadOnlyDictionary<int, double> ReadWidths(DictionaryToken dict)
	{
		Dictionary<int, double> dictionary = new Dictionary<int, double>();
		if (!dict.TryGet<ArrayToken>(NameToken.W, pdfScanner, out ArrayToken token))
		{
			return dictionary;
		}
		int count = token.Data.Count;
		int num = 0;
		while (num < count)
		{
			NumericToken numericToken = DirectObjectFinder.Get<NumericToken>(token.Data[num++], pdfScanner);
			IToken token2 = token.Data[num++];
			if (DirectObjectFinder.TryGet<ArrayToken>(token2, pdfScanner, out ArrayToken tokenResult))
			{
				int num2 = numericToken.Int;
				int count2 = tokenResult.Data.Count;
				for (int i = 0; i < count2; i++)
				{
					NumericToken numericToken2 = DirectObjectFinder.Get<NumericToken>(tokenResult.Data[i], pdfScanner);
					dictionary[num2 + i] = numericToken2.Double;
				}
				continue;
			}
			NumericToken numericToken3 = DirectObjectFinder.Get<NumericToken>(token2, pdfScanner);
			NumericToken numericToken4 = DirectObjectFinder.Get<NumericToken>(token.Data[num++], pdfScanner);
			int num3 = numericToken.Int;
			int num4 = numericToken3.Int;
			double value = numericToken4.Double;
			for (int j = num3; j <= num4; j++)
			{
				dictionary[j] = value;
			}
		}
		return dictionary;
	}

	private static VerticalWritingMetrics ReadVerticalDisplacements(DictionaryToken dict, IPdfTokenScanner pdfScanner)
	{
		Dictionary<int, double> dictionary = new Dictionary<int, double>();
		Dictionary<int, PdfVector> dictionary2 = new Dictionary<int, PdfVector>();
		VerticalVectorComponents defaultVerticalWritingMetrics;
		if (!dict.TryGet(NameToken.Dw2, out var token) || !(token is ArrayToken arrayToken))
		{
			defaultVerticalWritingMetrics = VerticalVectorComponents.Default;
		}
		else
		{
			double position = ((NumericToken)arrayToken.Data[0]).Double;
			double displacement = ((NumericToken)arrayToken.Data[1]).Double;
			defaultVerticalWritingMetrics = new VerticalVectorComponents(position, displacement);
		}
		if (dict.TryGet<ArrayToken>(NameToken.W2, pdfScanner, out ArrayToken token2))
		{
			int num;
			for (num = 0; num < token2.Data.Count; num++)
			{
				NumericToken numericToken = DirectObjectFinder.Get<NumericToken>(token2.Data[num], pdfScanner);
				IToken token3 = token2.Data[++num];
				if (DirectObjectFinder.TryGet<ArrayToken>(token3, pdfScanner, out ArrayToken tokenResult))
				{
					int num2;
					for (num2 = 0; num2 < tokenResult.Data.Count; num2++)
					{
						int key = numericToken.Int + num2;
						NumericToken numericToken2 = DirectObjectFinder.Get<NumericToken>(tokenResult.Data[num2], pdfScanner);
						NumericToken numericToken3 = DirectObjectFinder.Get<NumericToken>(tokenResult.Data[++num2], pdfScanner);
						NumericToken numericToken4 = DirectObjectFinder.Get<NumericToken>(tokenResult.Data[++num2], pdfScanner);
						dictionary[key] = numericToken2.Double;
						dictionary2[key] = new PdfVector(numericToken3.Double, numericToken4.Double);
					}
				}
				else
				{
					int num3 = numericToken.Int;
					int num4 = ((NumericToken)token3).Int;
					NumericToken numericToken5 = DirectObjectFinder.Get<NumericToken>(token2.Data[++num], pdfScanner);
					NumericToken numericToken6 = DirectObjectFinder.Get<NumericToken>(token2.Data[++num], pdfScanner);
					NumericToken numericToken7 = DirectObjectFinder.Get<NumericToken>(token2.Data[++num], pdfScanner);
					for (int i = num3; i <= num4; i++)
					{
						dictionary[i] = numericToken5.Double;
						dictionary2[i] = new PdfVector(numericToken6.Double, numericToken7.Double);
					}
				}
			}
		}
		return new VerticalWritingMetrics(defaultVerticalWritingMetrics, dictionary, dictionary2);
	}

	private CharacterIdentifierSystemInfo GetSystemInfo(DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.CidSystemInfo, out var token))
		{
			throw new InvalidFontFormatException($"No CID System Info was found in the CID Font dictionary: {dictionary}");
		}
		DictionaryToken dictionaryToken = token as DictionaryToken;
		if (dictionaryToken == null)
		{
			dictionaryToken = DirectObjectFinder.Get<DictionaryToken>(token, pdfScanner);
		}
		string registry = SafeKeyAccess(dictionaryToken, NameToken.Registry);
		string ordering = SafeKeyAccess(dictionaryToken, NameToken.Ordering);
		int intOrDefault = dictionaryToken.GetIntOrDefault(NameToken.Supplement);
		return new CharacterIdentifierSystemInfo(registry, ordering, intOrDefault);
	}

	private CharacterIdentifierToGlyphIndexMap GetCharacterIdentifierToGlyphIndexMap(DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.CidToGidMap, out var token))
		{
			return new CharacterIdentifierToGlyphIndexMap();
		}
		if (DirectObjectFinder.TryGet<NameToken>(token, pdfScanner, out NameToken _))
		{
			return new CharacterIdentifierToGlyphIndexMap();
		}
		if (!DirectObjectFinder.TryGet<StreamToken>(token, pdfScanner, out StreamToken tokenResult2))
		{
			throw new PdfDocumentFormatException($"No stream or name token found for /CIDToGIDMap in dictionary: {dictionary}.");
		}
		return new CharacterIdentifierToGlyphIndexMap(tokenResult2.Decode(filterProvider, pdfScanner).Span);
	}

	private string SafeKeyAccess(DictionaryToken dictionary, NameToken keyName)
	{
		if (!dictionary.TryGet(keyName, out var token))
		{
			return string.Empty;
		}
		if (token is StringToken stringToken)
		{
			return stringToken.Data;
		}
		if (token is HexToken hexToken)
		{
			return hexToken.Data;
		}
		if (token is IndirectReferenceToken token2)
		{
			if (DirectObjectFinder.TryGet<StringToken>(token2, pdfScanner, out StringToken tokenResult))
			{
				return tokenResult.Data;
			}
			if (DirectObjectFinder.TryGet<HexToken>(token2, pdfScanner, out HexToken tokenResult2))
			{
				return tokenResult2.Data;
			}
			throw new PdfDocumentFormatException($"Could not get key for name: {keyName} in {dictionary}.");
		}
		return string.Empty;
	}

	private static bool IsTrueTypeCff(ReadOnlySpan<byte> data)
	{
		if (data.Length < 4)
		{
			return false;
		}
		byte num = data[0];
		byte b = data[1];
		byte b2 = data[2];
		byte b3 = data[3];
		if (num == 1 && b == 0 && b2 >= 4 && b3 >= 1)
		{
			return b3 <= 4;
		}
		return false;
	}
}
