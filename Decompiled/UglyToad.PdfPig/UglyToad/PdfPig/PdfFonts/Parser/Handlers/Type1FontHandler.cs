using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.AdobeFontMetrics;
using UglyToad.PdfPig.Fonts.CompactFontFormat;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Fonts.Type1;
using UglyToad.PdfPig.Fonts.Type1.Parser;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.PdfFonts.Simple;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Parser.Handlers;

internal class Type1FontHandler : IFontHandler
{
	private readonly IPdfTokenScanner pdfScanner;

	private readonly ILookupFilterProvider filterProvider;

	private readonly IEncodingReader encodingReader;

	private readonly CMapLocalCache cmapLocalCache;

	private readonly bool isLenientParsing;

	public Type1FontHandler(IPdfTokenScanner pdfScanner, ILookupFilterProvider filterProvider, IEncodingReader encodingReader, CMapLocalCache cmapLocalCache, bool isLenientParsing)
	{
		this.pdfScanner = pdfScanner;
		this.filterProvider = filterProvider;
		this.encodingReader = encodingReader;
		this.cmapLocalCache = cmapLocalCache;
		this.isLenientParsing = isLenientParsing;
	}

	public IFont Generate(DictionaryToken dictionary)
	{
		bool flag = !dictionary.ContainsKey(NameToken.FirstChar) || !dictionary.ContainsKey(NameToken.Widths);
		if (flag)
		{
			if (!dictionary.TryGet(NameToken.BaseFont, out var token) || !(token is NameToken nameToken))
			{
				throw new InvalidFontFormatException($"The Type 1 font did not contain a first character entry but also did not reference a standard 14 font: {dictionary}");
			}
			AdobeFontMetrics adobeFontMetrics = Standard14.GetAdobeFontMetrics(nameToken.Data);
			if (adobeFontMetrics != null)
			{
				Encoding overrideEncoding = encodingReader.Read(dictionary);
				return new Type1Standard14Font(adobeFontMetrics, overrideEncoding);
			}
		}
		int firstChar;
		int lastChar;
		double[] widths;
		if (!flag)
		{
			firstChar = FontDictionaryAccessHelper.GetFirstCharacter(dictionary);
			lastChar = FontDictionaryAccessHelper.GetLastCharacter(dictionary);
			widths = FontDictionaryAccessHelper.GetWidths(pdfScanner, dictionary);
		}
		else
		{
			firstChar = 0;
			lastChar = 0;
			widths = Array.Empty<double>();
		}
		if (!dictionary.TryGet(NameToken.FontDescriptor, out var _) && dictionary.TryGet<NameToken>(NameToken.BaseFont, pdfScanner, out NameToken token3))
		{
			AdobeFontMetrics adobeFontMetrics2 = Standard14.GetAdobeFontMetrics(token3.Data);
			if (adobeFontMetrics2 == null)
			{
				if (!isLenientParsing)
				{
					throw new PdfDocumentFormatException($"Type 1 Standard 14 font with name {token3} requested, this is an invalid name.");
				}
				adobeFontMetrics2 = Standard14.GetAdobeFontMetrics(Standard14Font.TimesRoman);
			}
			Encoding overrideEncoding2 = encodingReader.Read(dictionary);
			return new Type1Standard14Font(adobeFontMetrics2, overrideEncoding2);
		}
		FontDescriptor fontDescriptor = FontDictionaryAccessHelper.GetFontDescriptor(pdfScanner, dictionary);
		Union<Type1Font, CompactFontFormatFontCollection> union = ParseFontProgram(fontDescriptor);
		NameToken name = FontDictionaryAccessHelper.GetName(pdfScanner, dictionary, fontDescriptor);
		CMap result = null;
		if (dictionary.TryGet(NameToken.ToUnicode, out var token4))
		{
			StreamToken token5 = DirectObjectFinder.Get<StreamToken>(token4, pdfScanner);
			cmapLocalCache.TryGet(token5, out result);
		}
		Encoding fontEncoding = null;
		if (union != null)
		{
			CompactFontFormatFontCollection b;
			if (union.TryGetFirst(out var a))
			{
				fontEncoding = ((a.Encoding != null) ? new BuiltInEncoding(a.Encoding) : null);
			}
			else if (union.TryGetSecond(out b))
			{
				fontEncoding = b.FirstFont?.Encoding;
			}
		}
		Encoding encoding = encodingReader.Read(dictionary, fontDescriptor, fontEncoding);
		if (encoding == null && union != null && union.TryGetFirst(out var a2))
		{
			encoding = new BuiltInEncoding(a2.Encoding);
		}
		return new Type1FontSimple(name, firstChar, lastChar, widths, fontDescriptor, encoding, result, union);
	}

	private Union<Type1Font, CompactFontFormatFontCollection>? ParseFontProgram(FontDescriptor descriptor)
	{
		if (descriptor?.FontFile == null)
		{
			return null;
		}
		if (descriptor.FontFile.ObjectKey.Data.ObjectNumber == 0L)
		{
			return null;
		}
		try
		{
			if (!(pdfScanner.Get(descriptor.FontFile.ObjectKey.Data)?.Data is StreamToken streamToken))
			{
				return null;
			}
			Memory<byte> memory = streamToken.Decode(filterProvider, pdfScanner);
			if (streamToken.StreamDictionary.TryGet(NameToken.Subtype, out NameToken token) && NameToken.Type1C.Equals(token))
			{
				return Union<Type1Font, CompactFontFormatFontCollection>.Two(CompactFontFormatParser.Parse(new CompactFontFormatData(memory)));
			}
			NumericToken numericToken = streamToken.StreamDictionary.Get<NumericToken>(NameToken.Length1, pdfScanner);
			NumericToken numericToken2 = streamToken.StreamDictionary.Get<NumericToken>(NameToken.Length2, pdfScanner);
			return Union<Type1Font, CompactFontFormatFontCollection>.One(Type1FontParser.Parse(new MemoryInputBytes(memory), numericToken.Int, numericToken2.Int));
		}
		catch
		{
		}
		return null;
	}
}
