using System;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.PdfFonts.CidFonts;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.PdfFonts.Composite;
using UglyToad.PdfPig.PdfFonts.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.PdfFonts.Parser.Handlers;

internal sealed class Type0FontHandler : IFontHandler
{
	private readonly CidFontFactory cidFontFactory;

	private readonly IPdfTokenScanner scanner;

	private readonly ILog logger;

	private readonly CMapLocalCache cmapLocalCache;

	private readonly ParsingOptions parsingOptions;

	public Type0FontHandler(CidFontFactory cidFontFactory, IPdfTokenScanner scanner, CMapLocalCache cmapLocalCache, ParsingOptions parsingOptions)
	{
		this.cidFontFactory = cidFontFactory;
		this.scanner = scanner;
		this.cmapLocalCache = cmapLocalCache;
		logger = parsingOptions.Logger;
		this.parsingOptions = parsingOptions;
	}

	public IFont Generate(DictionaryToken dictionary)
	{
		NameToken nameOrDefault = dictionary.GetNameOrDefault(NameToken.BaseFont);
		bool isCMapPredefined;
		CMap cmap = ReadEncoding(dictionary, out isCMapPredefined);
		if (!TryGetFirstDescendant(dictionary, out IToken descendant))
		{
			throw new InvalidFontFormatException("No descendant font dictionary was declared for this Type 0 font. This dictionary should contain the CIDFont for the Type 0 font. " + dictionary);
		}
		DictionaryToken dictionary2 = ((!(descendant is IndirectReferenceToken token)) ? ((DictionaryToken)descendant) : DirectObjectFinder.Get<DictionaryToken>(token, scanner));
		ICidFont cidFont = ParseDescendant(dictionary2);
		(CMap?, bool isChineseJapaneseOrKorean) ucs2CMap = GetUcs2CMap(dictionary, isCMapPredefined, cidFont);
		CMap item = ucs2CMap.Item1;
		bool item2 = ucs2CMap.isChineseJapaneseOrKorean;
		CMap result = null;
		if (dictionary.ContainsKey(NameToken.ToUnicode))
		{
			IToken token2 = dictionary.Data[NameToken.ToUnicode];
			if ((!DirectObjectFinder.TryGet<StreamToken>(token2, scanner, out StreamToken tokenResult) || !cmapLocalCache.TryGet(tokenResult, out result)) && (!DirectObjectFinder.TryGet<NameToken>(token2, scanner, out NameToken tokenResult2) || !cmapLocalCache.TryGet(tokenResult2.Data, out result)))
			{
				logger.Error($"Invalid type of toUnicode CMap encountered for font named {nameOrDefault}. Got: {token2}.");
			}
		}
		return new Type0Font(nameOrDefault, cidFont, cmap, result, item, parsingOptions, item2);
	}

	private static bool TryGetFirstDescendant(DictionaryToken dictionary, [NotNullWhen(true)] out IToken? descendant)
	{
		descendant = null;
		if (!dictionary.TryGet(NameToken.DescendantFonts, out var token))
		{
			return false;
		}
		if (token is IndirectReferenceToken indirectReferenceToken)
		{
			descendant = indirectReferenceToken;
			return true;
		}
		if (token is ArrayToken arrayToken && arrayToken.Data.Count > 0)
		{
			if (arrayToken.Data[0] is IndirectReferenceToken indirectReferenceToken2)
			{
				descendant = indirectReferenceToken2;
			}
			else
			{
				if (!(arrayToken.Data[0] is DictionaryToken dictionaryToken))
				{
					return false;
				}
				descendant = dictionaryToken;
			}
			return true;
		}
		return false;
	}

	private ICidFont? ParseDescendant(DictionaryToken dictionary)
	{
		NameToken nameOrDefault = dictionary.GetNameOrDefault(NameToken.Type);
		if ((object)nameOrDefault == null || !nameOrDefault.Equals(NameToken.Font))
		{
			throw new InvalidFontFormatException($"Expected 'Font' dictionary but found '{nameOrDefault}'");
		}
		return cidFontFactory.Generate(dictionary);
	}

	private CMap ReadEncoding(DictionaryToken dictionary, out bool isCMapPredefined)
	{
		isCMapPredefined = false;
		CMap result2;
		if (dictionary.TryGet<NameToken>(NameToken.Encoding, scanner, out NameToken token))
		{
			if (!cmapLocalCache.TryGet(token.Data, out CMap result))
			{
				throw new InvalidOperationException("Missing CMap named " + token.Data + ".");
			}
			result2 = result ?? throw new InvalidOperationException("Missing CMap named " + token.Data + ".");
			isCMapPredefined = true;
		}
		else
		{
			if (!dictionary.TryGet<StreamToken>(NameToken.Encoding, scanner, out StreamToken token2))
			{
				throw new InvalidOperationException($"Could not read the encoding, expected a name or a stream but it was not found in the dictionary: {dictionary}");
			}
			if (!cmapLocalCache.TryGet(token2, out CMap result3))
			{
				throw new InvalidOperationException($"Could not read CMap from stream in the dictionary: {dictionary}");
			}
			result2 = result3;
		}
		return result2;
	}

	private static (CMap?, bool isChineseJapaneseOrKorean) GetUcs2CMap(DictionaryToken dictionary, bool isCMapPredefined, ICidFont cidFont)
	{
		if (!isCMapPredefined)
		{
			return (null, isChineseJapaneseOrKorean: false);
		}
		NameToken nameOrDefault = dictionary.GetNameOrDefault(NameToken.Encoding);
		if ((object)nameOrDefault == null)
		{
			return (null, isChineseJapaneseOrKorean: false);
		}
		bool flag = false;
		if (cidFont != null && string.Equals(cidFont.SystemInfo.Registry, "Adobe", StringComparison.OrdinalIgnoreCase))
		{
			flag = string.Equals(cidFont.SystemInfo.Ordering, "GB1", StringComparison.OrdinalIgnoreCase) || string.Equals(cidFont.SystemInfo.Ordering, "CNS1", StringComparison.OrdinalIgnoreCase) || string.Equals(cidFont.SystemInfo.Ordering, "Japan1", StringComparison.OrdinalIgnoreCase) || string.Equals(cidFont.SystemInfo.Ordering, "Korea1", StringComparison.OrdinalIgnoreCase);
		}
		if ((nameOrDefault.Equals(NameToken.IdentityH) || nameOrDefault.Equals(NameToken.IdentityV)) && !flag)
		{
			return (null, isChineseJapaneseOrKorean: false);
		}
		if (!flag)
		{
			return (null, isChineseJapaneseOrKorean: false);
		}
		string registry;
		string ordering;
		if (CMapCache.TryGet(cidFont.SystemInfo.ToString(), out CMap result))
		{
			registry = result.Info.Registry;
			ordering = result.Info.Ordering;
		}
		else
		{
			registry = cidFont.SystemInfo.Registry;
			ordering = cidFont.SystemInfo.Ordering;
		}
		if (!CMapCache.TryGet(registry + "-" + ordering + "-UCS2", out CMap result2))
		{
			throw new InvalidFontFormatException($"Could not locate CMap by name: {result}.");
		}
		return (result2, isChineseJapaneseOrKorean: true);
	}
}
