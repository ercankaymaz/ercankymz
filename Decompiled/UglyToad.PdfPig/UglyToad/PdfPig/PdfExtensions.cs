using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig;

public static class PdfExtensions
{
	public static bool TryGet<T>(this DictionaryToken dictionary, NameToken name, IPdfTokenScanner tokenScanner, [NotNullWhen(true)] out T? token) where T : class, IToken
	{
		token = null;
		if (!dictionary.TryGet(name, out var token2) || !(token2 is T val))
		{
			if (token2 is IndirectReferenceToken token3)
			{
				return DirectObjectFinder.TryGet<T>(token3, tokenScanner, out token);
			}
			return false;
		}
		token = val;
		return true;
	}

	public static T Get<T>(this DictionaryToken dictionary, NameToken name, IPdfTokenScanner scanner) where T : class, IToken
	{
		T val;
		if (dictionary.TryGet(name, out var token))
		{
			val = token as T;
			if (val != null)
			{
				goto IL_004f;
			}
		}
		val = DirectObjectFinder.Get<T>((token as IndirectReferenceToken) ?? throw new PdfDocumentFormatException($"Dictionary does not contain token with name {name} of type {typeof(T).Name}."), scanner);
		goto IL_004f;
		IL_004f:
		return val;
	}

	public static Memory<byte> Decode(this StreamToken stream, IFilterProvider filterProvider)
	{
		IReadOnlyList<IFilter> filters = filterProvider.GetFilters(stream.StreamDictionary);
		double num = stream.Data.Length * 100;
		Memory<byte> memory = stream.Data;
		for (int i = 0; i < filters.Count; i++)
		{
			IFilter filter = filters[i];
			num *= GetEstimatedSizeMultiplier(filter);
			memory = filter.Decode(memory, stream.StreamDictionary, filterProvider, i);
			if (i < filters.Count - 1 && (double)memory.Length > num)
			{
				throw new PdfDocumentFormatException($"Decoded stream size exceeds the estimated maximum size. Current decoded stream length: {memory.Length}, {i + 1} filters applied out of {filters.Count}.");
			}
		}
		return memory;
	}

	public static Memory<byte> Decode(this StreamToken stream, ILookupFilterProvider filterProvider, IPdfTokenScanner scanner)
	{
		IReadOnlyList<IFilter> filters = filterProvider.GetFilters(stream.StreamDictionary, scanner);
		double num = stream.Data.Length * 100;
		Memory<byte> memory = stream.Data;
		for (int i = 0; i < filters.Count; i++)
		{
			IFilter filter = filters[i];
			num *= GetEstimatedSizeMultiplier(filter);
			memory = filter.Decode(memory, stream.StreamDictionary, filterProvider, i);
			if (i < filters.Count - 1 && (double)memory.Length > num)
			{
				throw new PdfDocumentFormatException($"Decoded stream size exceeds the estimated maximum size. Current decoded stream length: {memory.Length}, {i + 1} filters applied out of {filters.Count}.");
			}
		}
		return memory;
	}

	private static double GetEstimatedSizeMultiplier(IFilter filter)
	{
		if (!(filter is AsciiHexDecodeFilter))
		{
			if (!(filter is Ascii85Filter))
			{
				if (!(filter is RunLengthFilter))
				{
					if (!(filter is LzwFilter))
					{
						if (filter is FlateFilter)
						{
							return 10.0;
						}
						return 1000.0;
					}
					return 2.0;
				}
				return 1.5;
			}
			return 0.8;
		}
		return 0.5;
	}

	internal static T? Resolve<T>(this T? token, IPdfTokenScanner scanner, HashSet<IndirectReference>? visited = null) where T : IToken
	{
		return (T)token.ResolveInternal(scanner, visited ?? new HashSet<IndirectReference>());
	}

	private static IToken? ResolveInternal(this IToken? token, IPdfTokenScanner scanner, HashSet<IndirectReference> visited)
	{
		if (token is StreamToken streamToken)
		{
			return new StreamToken(streamToken.StreamDictionary.Resolve(scanner, visited), streamToken.Data);
		}
		if (token is DictionaryToken dictionaryToken)
		{
			Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
			foreach (KeyValuePair<string, IToken> datum in dictionaryToken.Data)
			{
				IToken token2 = datum.Value;
				if (datum.Value is IndirectReferenceToken indirectReferenceToken)
				{
					if (visited.Contains(indirectReferenceToken.Data))
					{
						continue;
					}
					token2 = scanner.Get(indirectReferenceToken.Data)?.Data;
					visited.Add(indirectReferenceToken.Data);
				}
				dictionary[NameToken.Create(datum.Key)] = token2.ResolveInternal(scanner, visited);
			}
			if (dictionary.Count != dictionaryToken.Data.Count)
			{
				if (dictionary.Count > dictionaryToken.Data.Count)
				{
					throw new InvalidOperationException("Resolved more items than were present in the original dictionary. This should not be possible.");
				}
				foreach (string item in dictionaryToken.Data.Keys.Except(dictionary.Keys.Select((NameToken k) => k.Data), StringComparer.OrdinalIgnoreCase))
				{
					if (dictionaryToken.Data[item] is IndirectReferenceToken token3)
					{
						dictionary[NameToken.Create(item)] = token3.ResolveInternal(scanner, visited);
					}
				}
			}
			return new DictionaryToken(dictionary);
		}
		if (token is ArrayToken arrayToken)
		{
			List<IToken> list = new List<IToken>();
			for (int num = 0; num < arrayToken.Length; num++)
			{
				IToken token4 = ((arrayToken.Data[num] is IndirectReferenceToken indirectReferenceToken2) ? scanner.Get(indirectReferenceToken2.Data)?.Data : arrayToken.Data[num]);
				list.Add(token4.ResolveInternal(scanner, visited));
			}
			return new ArrayToken(list);
		}
		if (!(token is IndirectReferenceToken indirectReferenceToken3))
		{
			return token;
		}
		return scanner.Get(indirectReferenceToken3.Data)?.Data;
	}
}
