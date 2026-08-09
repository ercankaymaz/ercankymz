using System;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Content;

public sealed class Catalog
{
	public DictionaryToken CatalogDictionary { get; }

	internal NamedDestinations NamedDestinations { get; }

	internal Pages Pages { get; }

	internal Catalog(DictionaryToken catalogDictionary, Pages pages, NamedDestinations namedDestinations)
	{
		CatalogDictionary = catalogDictionary ?? throw new ArgumentNullException("catalogDictionary");
		Pages = pages ?? throw new ArgumentNullException("pages");
		NamedDestinations = namedDestinations;
	}
}
