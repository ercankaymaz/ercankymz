using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser.Parts;

internal static class NameTreeParser
{
	public static IReadOnlyDictionary<string, TResult> FlattenNameTreeToDictionary<TResult>(DictionaryToken nameTreeNodeDictionary, IPdfTokenScanner pdfScanner, Func<IToken, TResult> valuesFactory) where TResult : class
	{
		Dictionary<string, TResult> result = new Dictionary<string, TResult>();
		FlattenNameTree(nameTreeNodeDictionary, pdfScanner, valuesFactory, result);
		return result;
	}

	public static void FlattenNameTree<TResult>(DictionaryToken nameTreeNodeDictionary, IPdfTokenScanner pdfScanner, Func<IToken, TResult> valuesFactory, Dictionary<string, TResult> result) where TResult : class
	{
		if (nameTreeNodeDictionary.TryGet<ArrayToken>(NameToken.Names, pdfScanner, out ArrayToken token))
		{
			for (int i = 0; i < token.Length; i += 2)
			{
				if (token[i] is IDataToken<string> dataToken)
				{
					IToken arg = token[i + 1];
					TResult val = valuesFactory(arg);
					if (val != null)
					{
						result[dataToken.Data] = val;
					}
				}
			}
		}
		if (!nameTreeNodeDictionary.TryGet<ArrayToken>(NameToken.Kids, pdfScanner, out ArrayToken token2))
		{
			return;
		}
		foreach (IToken datum in token2.Data)
		{
			if (DirectObjectFinder.TryGet<DictionaryToken>(datum, pdfScanner, out DictionaryToken tokenResult))
			{
				FlattenNameTree(tokenResult, pdfScanner, valuesFactory, result);
			}
		}
	}
}
