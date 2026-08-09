using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser;

internal static class CatalogFactory
{
	public static Catalog Create(IndirectReference rootReference, DictionaryToken dictionary, IPdfTokenScanner scanner, PageFactory pageFactory, ILog log, bool isLenientParsing)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		if (dictionary.TryGet(NameToken.Type, out var token) && token != NameToken.Catalog && !isLenientParsing)
		{
			throw new PdfDocumentFormatException($"The type of the catalog dictionary was not Catalog: {dictionary}.");
		}
		if (!dictionary.TryGet(NameToken.Pages, out var token2))
		{
			throw new PdfDocumentFormatException($"No pages entry was found in the catalog dictionary: {dictionary}.");
		}
		IndirectReference pagesReference = rootReference;
		DictionaryToken dictionaryToken;
		if (token2 is IndirectReferenceToken indirectReferenceToken)
		{
			pagesReference = indirectReferenceToken.Data;
			dictionaryToken = DirectObjectFinder.Get<DictionaryToken>(indirectReferenceToken, scanner);
		}
		else
		{
			dictionaryToken = ((!(token2 is DictionaryToken dictionaryToken2)) ? DirectObjectFinder.Get<DictionaryToken>(token2, scanner) : dictionaryToken2);
		}
		if (dictionaryToken == null)
		{
			if (!isLenientParsing)
			{
				throw new PdfDocumentFormatException("Pages entry is null");
			}
			dictionaryToken = new DictionaryToken(new Dictionary<NameToken, IToken>());
		}
		Pages pages = PagesFactory.Create(pagesReference, dictionaryToken, scanner, pageFactory, log, isLenientParsing);
		NamedDestinations namedDestinations = NamedDestinationsProvider.Read(dictionary, scanner, pages, null);
		return new Catalog(dictionary, pages, namedDestinations);
	}
}
