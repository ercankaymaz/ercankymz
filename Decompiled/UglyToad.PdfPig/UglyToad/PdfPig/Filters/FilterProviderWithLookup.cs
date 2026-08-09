using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Filters;

internal class FilterProviderWithLookup : ILookupFilterProvider, IFilterProvider
{
	private readonly IFilterProvider inner;

	public FilterProviderWithLookup(IFilterProvider inner)
	{
		this.inner = inner;
	}

	public IReadOnlyList<IFilter> GetFilters(DictionaryToken dictionary)
	{
		return inner.GetFilters(dictionary);
	}

	public IReadOnlyList<IFilter> GetNamedFilters(IReadOnlyList<NameToken> names)
	{
		return inner.GetNamedFilters(names);
	}

	public IReadOnlyList<IFilter> GetAllFilters()
	{
		return inner.GetAllFilters();
	}

	public IReadOnlyList<IFilter> GetFilters(DictionaryToken dictionary, IPdfTokenScanner scanner)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		IToken objectOrDefault = dictionary.GetObjectOrDefault(NameToken.Filter, NameToken.F);
		if (objectOrDefault == null)
		{
			return Array.Empty<IFilter>();
		}
		if (!(objectOrDefault is ArrayToken arrayToken))
		{
			if (!(objectOrDefault is NameToken nameToken))
			{
				if (objectOrDefault is IndirectReferenceToken token)
				{
					if (DirectObjectFinder.TryGet<NameToken>(token, scanner, out NameToken tokenResult))
					{
						return GetNamedFilters(new NameToken[1] { tokenResult });
					}
					if (DirectObjectFinder.TryGet<ArrayToken>(token, scanner, out ArrayToken tokenResult2))
					{
						return GetNamedFilters(tokenResult2.Data.Select((IToken x) => (NameToken)x).ToList());
					}
					throw new PdfDocumentFormatException($"The filter for the stream was not a valid object. Expected name or array, instead got: {objectOrDefault}.");
				}
				throw new PdfDocumentFormatException($"The filter for the stream was not a valid object. Expected name or array, instead got: {objectOrDefault}.");
			}
			return GetNamedFilters(new NameToken[1] { nameToken });
		}
		NameToken[] array = new NameToken[arrayToken.Data.Count];
		for (int num = 0; num < arrayToken.Data.Count; num++)
		{
			NameToken nameToken2 = (NameToken)arrayToken.Data[num];
			array[num] = nameToken2;
		}
		return GetNamedFilters(array);
	}
}
