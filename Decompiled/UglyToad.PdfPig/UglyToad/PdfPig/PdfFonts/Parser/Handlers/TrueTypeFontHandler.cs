using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.AdobeFontMetrics;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Fonts.SystemFonts;
using UglyToad.PdfPig.Fonts.TrueType;
using UglyToad.PdfPig.Fonts.TrueType.Parser;
using UglyToad.PdfPig.Fonts.TrueType.Tables;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.PdfFonts.Simple;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.PdfFonts.Parser.Handlers;

internal class TrueTypeFontHandler : IFontHandler
{
	private readonly ILog log;

	private readonly IPdfTokenScanner pdfScanner;

	private readonly ILookupFilterProvider filterProvider;

	private readonly IEncodingReader encodingReader;

	private readonly ISystemFontFinder systemFontFinder;

	private readonly IFontHandler type1FontHandler;

	private readonly CMapLocalCache cmapLocalCache;

	public TrueTypeFontHandler(ILog log, IPdfTokenScanner pdfScanner, ILookupFilterProvider filterProvider, IEncodingReader encodingReader, CMapLocalCache cmapLocalCache, ISystemFontFinder systemFontFinder, IFontHandler type1FontHandler)
	{
		this.log = log;
		this.filterProvider = filterProvider;
		this.encodingReader = encodingReader;
		this.systemFontFinder = systemFontFinder;
		this.type1FontHandler = type1FontHandler;
		this.pdfScanner = pdfScanner;
		this.cmapLocalCache = cmapLocalCache;
	}

	public IFont Generate(DictionaryToken dictionary)
	{
		int? num = null;
		if (!dictionary.TryGetOptionalTokenDirect<NumericToken>(NameToken.FirstChar, pdfScanner, out NumericToken result) || !dictionary.TryGet<IToken>(NameToken.FontDescriptor, pdfScanner, out IToken token) || !dictionary.TryGet(NameToken.Widths, out token))
		{
			bool flag = true;
			if (!dictionary.TryGetOptionalTokenDirect<NameToken>(NameToken.BaseFont, pdfScanner, out NameToken result2))
			{
				throw new InvalidFontFormatException($"The provided TrueType font dictionary did not contain a /FirstChar or a /BaseFont entry: {dictionary}.");
			}
			AdobeFontMetrics adobeFontMetrics = Standard14.GetAdobeFontMetrics(result2.Data);
			if (adobeFontMetrics == null)
			{
				if (!dictionary.TryGet<NumericToken>(NameToken.LastChar, pdfScanner, out NumericToken token2) || !dictionary.TryGet<ArrayToken>(NameToken.Widths, pdfScanner, out ArrayToken token3))
				{
					throw new InvalidFontFormatException($"The provided TrueType font dictionary did not have a /FirstChar and did not match a Standard 14 font: {dictionary}.");
				}
				num = token2.Int - token3.Length + 1;
				flag = false;
			}
			if (flag)
			{
				TrueTypeFont trueTypeFont = systemFontFinder.GetTrueTypeFont(result2.Data);
				Encoding encoding = encodingReader.Read(dictionary);
				if (encoding == null)
				{
					encoding = new AdobeFontMetricsEncoding(adobeFontMetrics);
				}
				double[] widths = null;
				if (dictionary.TryGet<NumericToken>(NameToken.FirstChar, pdfScanner, out result))
				{
					num = result.Int;
				}
				if (dictionary.TryGet<ArrayToken>(NameToken.Widths, pdfScanner, out ArrayToken token4))
				{
					widths = (from x in token4.Data.OfType<NumericToken>()
						select x.Double).ToArray();
				}
				return new TrueTypeStandard14FallbackSimpleFont(result2, adobeFontMetrics, encoding, trueTypeFont, new TrueTypeStandard14FallbackSimpleFont.MetricOverrides(num, widths));
			}
		}
		int firstCharacter = num ?? result.Int;
		double[] widths2 = FontDictionaryAccessHelper.GetWidths(pdfScanner, dictionary);
		FontDescriptor fontDescriptor = FontDictionaryAccessHelper.GetFontDescriptor(pdfScanner, dictionary);
		IFontHandler actualHandler;
		TrueTypeFont trueTypeFont2 = ParseTrueTypeFont(fontDescriptor, out actualHandler);
		if (trueTypeFont2 == null && actualHandler != null)
		{
			return actualHandler.Generate(dictionary);
		}
		NameToken name = FontDictionaryAccessHelper.GetName(pdfScanner, dictionary, fontDescriptor);
		CMap result3 = null;
		if (dictionary.TryGet(NameToken.ToUnicode, out var token5))
		{
			try
			{
				StreamToken token6 = DirectObjectFinder.Get<StreamToken>(token5, pdfScanner);
				if (!cmapLocalCache.TryGet(token6, out result3))
				{
					log.Error("Failed to decode ToUnicode CMap for a TrueType font in file.");
				}
			}
			catch (Exception ex)
			{
				log.Error("Failed to decode ToUnicode CMap for a TrueType font in file due to an exception.", ex);
			}
		}
		Encoding encoding2 = encodingReader.Read(dictionary, fontDescriptor);
		if (encoding2 == null && trueTypeFont2?.TableRegister?.CMapTable != null && trueTypeFont2.TableRegister.PostScriptTable?.GlyphNames != null)
		{
			PostScriptTable postScriptTable = trueTypeFont2.TableRegister.PostScriptTable;
			Dictionary<int, string> dictionary2 = new Dictionary<int, string>();
			for (int num2 = 0; num2 < 256; num2++)
			{
				if (trueTypeFont2.TableRegister.CMapTable.TryGetGlyphIndex(num2, out var glyphIndex))
				{
					string value = ((glyphIndex < 0 || glyphIndex >= postScriptTable.GlyphNames.Count) ? glyphIndex.ToString(CultureInfo.InvariantCulture) : postScriptTable.GlyphNames[glyphIndex]);
					dictionary2[num2] = value;
				}
			}
			encoding2 = new BuiltInEncoding(dictionary2);
		}
		return new TrueTypeSimpleFont(name, fontDescriptor, result3, encoding2, trueTypeFont2, firstCharacter, widths2);
	}

	private TrueTypeFont? ParseTrueTypeFont(FontDescriptor descriptor, out IFontHandler? actualHandler)
	{
		actualHandler = null;
		if (descriptor.FontFile == null)
		{
			try
			{
				return systemFontFinder.GetTrueTypeFont(descriptor.FontName.Data);
			}
			catch (Exception ex)
			{
				log.Error($"Failed finding system font by name: {descriptor.FontName}.", ex);
			}
			return null;
		}
		try
		{
			StreamToken streamToken = DirectObjectFinder.Get<StreamToken>(descriptor.FontFile.ObjectKey, pdfScanner);
			if (descriptor.FontFile.FileType == DescriptorFontFile.FontFileType.FromSubtype)
			{
				bool flag = true;
				if (streamToken.StreamDictionary.TryGet<NameToken>(NameToken.Subtype, pdfScanner, out NameToken token))
				{
					if (token == NameToken.Type1C)
					{
						actualHandler = type1FontHandler;
						return null;
					}
					if (token == NameToken.OpenType)
					{
						flag = false;
					}
				}
				if (flag)
				{
					throw new InvalidFontFormatException($"Expected a TrueType font in the TrueType font descriptor, instead it was {descriptor.FontFile.FileType}.");
				}
			}
			return TrueTypeFontParser.Parse(new TrueTypeDataBytes(new MemoryInputBytes(streamToken.Decode(filterProvider, pdfScanner))));
		}
		catch (Exception ex2)
		{
			log.Error("Could not parse the TrueType font.", ex2);
			return null;
		}
	}
}
