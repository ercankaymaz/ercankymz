using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters;

public interface IFilterProvider
{
	IReadOnlyList<IFilter> GetFilters(DictionaryToken dictionary);

	IReadOnlyList<IFilter> GetNamedFilters(IReadOnlyList<NameToken> names);

	IReadOnlyList<IFilter> GetAllFilters();
}
