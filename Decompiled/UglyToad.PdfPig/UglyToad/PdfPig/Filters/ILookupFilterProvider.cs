using System.Collections.Generic;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters;

public interface ILookupFilterProvider : IFilterProvider
{
	IReadOnlyList<IFilter> GetFilters(DictionaryToken dictionary, IPdfTokenScanner scanner);
}
