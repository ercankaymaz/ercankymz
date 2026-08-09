using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer;

internal static class WriterUtil
{
	public static Dictionary<string, IToken> GetOrCreateDict<T>(this Dictionary<T, IToken> dict, T key, IPdfTokenScanner? sourceScanner = null) where T : notnull
	{
		if (dict.TryGetValue(key, out IToken value))
		{
			int num = 0;
			IToken token = value;
			while (token is IndirectReferenceToken indirectReferenceToken && num < 100 && sourceScanner != null)
			{
				token = sourceScanner.Get(indirectReferenceToken.Data);
				num++;
				if (token is ObjectToken objectToken)
				{
					token = objectToken.Data;
				}
			}
			if (!(token is DictionaryToken dictionaryToken))
			{
				throw new InvalidOperationException($"While trying to copy token called {key} which should have been a dictionary token we found a token of type {value.GetType()}");
			}
			if (dictionaryToken.Data is Dictionary<string, IToken> result)
			{
				return result;
			}
			Dictionary<string, IToken> dictionary = dictionaryToken.Data.ToDictionary((KeyValuePair<string, IToken> x) => x.Key, (KeyValuePair<string, IToken> x) => x.Value);
			dict[key] = DictionaryToken.With(dictionary);
			return dictionary;
		}
		Dictionary<string, IToken> dictionary2 = new Dictionary<string, IToken>();
		dict[key] = DictionaryToken.With(dictionary2);
		return dictionary2;
	}

	public static IToken CopyToken(IPdfStreamWriter writer, IToken tokenToCopy, IPdfTokenScanner tokenScanner, IDictionary<IndirectReference, IndirectReferenceToken> referencesFromDocument, Dictionary<IndirectReference, IndirectReferenceToken?>? callstack = null)
	{
		if (callstack == null)
		{
			callstack = new Dictionary<IndirectReference, IndirectReferenceToken>();
		}
		if (!(tokenToCopy is DictionaryToken dictionaryToken))
		{
			if (!(tokenToCopy is ArrayToken arrayToken))
			{
				if (!(tokenToCopy is IndirectReferenceToken indirectReferenceToken))
				{
					if (!(tokenToCopy is StreamToken streamToken))
					{
						if (tokenToCopy is ObjectToken)
						{
							throw new NotSupportedException("Copying a Object token is not supported");
						}
						return tokenToCopy;
					}
					DictionaryToken streamDictionary = CopyToken(writer, streamToken.StreamDictionary, tokenScanner, referencesFromDocument, callstack) as DictionaryToken;
					Memory<byte> data = streamToken.Data;
					return new StreamToken(streamDictionary, data);
				}
				if (referencesFromDocument.TryGetValue(indirectReferenceToken.Data, out IndirectReferenceToken value))
				{
					return value;
				}
				if (callstack.ContainsKey(indirectReferenceToken.Data) && callstack[indirectReferenceToken.Data] == null)
				{
					value = writer.ReserveObjectNumber();
					callstack[indirectReferenceToken.Data] = value;
					referencesFromDocument.Add(indirectReferenceToken.Data, value);
					return value;
				}
				callstack.Add(indirectReferenceToken.Data, null);
				IToken token = DirectObjectFinder.Get<IToken>(indirectReferenceToken.Data, tokenScanner);
				if (token == null)
				{
					return null;
				}
				IToken token2 = CopyToken(writer, token, tokenScanner, referencesFromDocument, callstack);
				if (callstack[indirectReferenceToken.Data] != null)
				{
					return writer.WriteToken(token2, callstack[indirectReferenceToken.Data]);
				}
				value = writer.WriteToken(token2);
				referencesFromDocument.Add(indirectReferenceToken.Data, value);
				return value;
			}
			List<IToken> list = new List<IToken>(arrayToken.Length);
			foreach (IToken datum in arrayToken.Data)
			{
				list.Add(CopyToken(writer, datum, tokenScanner, referencesFromDocument, callstack));
			}
			return new ArrayToken(list);
		}
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
		foreach (KeyValuePair<string, IToken> datum2 in dictionaryToken.Data)
		{
			string key = datum2.Key;
			IToken value2 = datum2.Value;
			dictionary.Add(NameToken.Create(key), CopyToken(writer, value2, tokenScanner, referencesFromDocument, callstack));
		}
		return new DictionaryToken(dictionary);
	}

	internal static IEnumerable<(DictionaryToken, IReadOnlyList<DictionaryToken>)> WalkTree(PageTreeNode node, List<DictionaryToken>? parents = null)
	{
		if (parents == null)
		{
			parents = new List<DictionaryToken>();
		}
		if (node.IsPage)
		{
			yield return (node.NodeDictionary, parents);
			yield break;
		}
		parents = parents.ToList();
		parents.Add(node.NodeDictionary);
		foreach (PageTreeNode child in node.Children)
		{
			foreach (var item in WalkTree(child, parents))
			{
				yield return item;
			}
		}
	}
}
