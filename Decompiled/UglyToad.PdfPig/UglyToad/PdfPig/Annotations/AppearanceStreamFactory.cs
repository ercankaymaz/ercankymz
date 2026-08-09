using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Annotations;

internal static class AppearanceStreamFactory
{
	public static bool TryCreate(DictionaryToken appearanceDictionary, NameToken name, IPdfTokenScanner tokenScanner, [NotNullWhen(true)] out AppearanceStream? appearanceStream)
	{
		if (appearanceDictionary.TryGet(name, out IndirectReferenceToken token))
		{
			StreamToken streamToken = tokenScanner.Get(token.Data)?.Data as StreamToken;
			appearanceStream = new AppearanceStream(streamToken);
			return true;
		}
		if (appearanceDictionary.TryGet(name, out DictionaryToken token2))
		{
			Dictionary<string, StreamToken> dictionary = new Dictionary<string, StreamToken>();
			foreach (string key in token2.Data.Keys)
			{
				if (token2.Data.TryGetValue(key, out var value) && value is IndirectReferenceToken indirectReferenceToken)
				{
					StreamToken value2 = tokenScanner.Get(indirectReferenceToken.Data)?.Data as StreamToken;
					dictionary[key] = value2;
				}
			}
			if (dictionary.Count > 0)
			{
				appearanceStream = new AppearanceStream(dictionary);
				return true;
			}
		}
		appearanceStream = null;
		return false;
	}
}
