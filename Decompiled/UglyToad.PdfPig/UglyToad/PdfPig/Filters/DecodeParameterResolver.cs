using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Filters;

public static class DecodeParameterResolver
{
	public static DictionaryToken GetFilterParameters(DictionaryToken streamDictionary, int index)
	{
		if (streamDictionary == null)
		{
			throw new ArgumentNullException("streamDictionary");
		}
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index", "Index must be 0 or greater");
		}
		IToken objectOrDefault = streamDictionary.GetObjectOrDefault(NameToken.Filter, NameToken.F);
		IToken objectOrDefault2 = streamDictionary.GetObjectOrDefault(NameToken.DecodeParms, NameToken.Dp);
		if (!(objectOrDefault is NameToken))
		{
			if (objectOrDefault is ArrayToken && objectOrDefault2 is ArrayToken arrayToken && index < arrayToken.Data.Count && arrayToken.Data[index] is DictionaryToken result)
			{
				return result;
			}
		}
		else if (objectOrDefault2 is DictionaryToken result2)
		{
			return result2;
		}
		return new DictionaryToken(new Dictionary<NameToken, IToken>());
	}
}
