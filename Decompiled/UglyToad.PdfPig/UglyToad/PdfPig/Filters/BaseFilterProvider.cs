using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Filters;

public abstract class BaseFilterProvider : IFilterProvider
{
	protected readonly IReadOnlyDictionary<string, IFilter> FilterInstances;

	protected BaseFilterProvider(IReadOnlyDictionary<string, IFilter> filterInstances)
	{
		FilterInstances = filterInstances;
	}

	public IReadOnlyList<IFilter> GetFilters(DictionaryToken dictionary)
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
			if (objectOrDefault is NameToken nameToken)
			{
				return new IFilter[1] { GetFilterStrict(nameToken.Data) };
			}
			throw new PdfDocumentFormatException($"The filter for the stream was not a valid object. Expected name or array, instead got: {objectOrDefault}.");
		}
		IFilter[] array = new IFilter[arrayToken.Data.Count];
		for (int i = 0; i < arrayToken.Data.Count; i++)
		{
			string data = ((NameToken)arrayToken.Data[i]).Data;
			array[i] = GetFilterStrict(data);
		}
		return array;
	}

	public IReadOnlyList<IFilter> GetNamedFilters(IReadOnlyList<NameToken> names)
	{
		if (names == null)
		{
			throw new ArgumentNullException("names");
		}
		List<IFilter> list = new List<IFilter>();
		foreach (NameToken name in names)
		{
			list.Add(GetFilterStrict(name));
		}
		return list;
	}

	private IFilter GetFilterStrict(string name)
	{
		if (!FilterInstances.TryGetValue(name, out IFilter value))
		{
			throw new NotSupportedException("The filter with the name " + name + " is not supported yet. Please raise an issue.");
		}
		return value;
	}

	public IReadOnlyList<IFilter> GetAllFilters()
	{
		return FilterInstances.Values.Distinct().ToList();
	}
}
