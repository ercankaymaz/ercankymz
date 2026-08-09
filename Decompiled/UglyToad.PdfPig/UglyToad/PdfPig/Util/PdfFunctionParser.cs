using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Util;

internal static class PdfFunctionParser
{
	public static PdfFunction Create(IToken function, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		StreamToken streamToken = null;
		DictionaryToken dictionaryToken;
		if (DirectObjectFinder.TryGet<StreamToken>(function, scanner, out StreamToken tokenResult))
		{
			dictionaryToken = tokenResult.StreamDictionary;
			streamToken = new StreamToken(tokenResult.StreamDictionary, tokenResult.Decode(filterProvider, scanner));
		}
		else
		{
			if (!DirectObjectFinder.TryGet<DictionaryToken>(function, scanner, out DictionaryToken tokenResult2))
			{
				throw new ArgumentException("function");
			}
			dictionaryToken = tokenResult2;
		}
		if (!dictionaryToken.TryGet<ArrayToken>(NameToken.Domain, scanner, out ArrayToken token))
		{
			throw new ArgumentNullException(NameToken.Domain);
		}
		dictionaryToken.TryGet<ArrayToken>(NameToken.Range, scanner, out ArrayToken token2);
		int num = ((NumericToken)dictionaryToken.Data[NameToken.FunctionType]).Int;
		switch (num)
		{
		case 0:
			if (streamToken == null)
			{
				throw new NotImplementedException("PdfFunctionType0 not stream");
			}
			return CreatePdfFunctionType0(streamToken, token, token2, scanner);
		case 2:
			return CreatePdfFunctionType2(dictionaryToken, token, token2, scanner);
		case 3:
			return CreatePdfFunctionType3(dictionaryToken, token, token2, scanner, filterProvider);
		case 4:
			if (streamToken == null)
			{
				throw new NotImplementedException("PdfFunctionType4 not stream");
			}
			return CreatePdfFunctionType4(streamToken, token, token2, scanner);
		default:
			throw new IOException("Error: Unknown function type " + num);
		}
	}

	private static PdfFunctionType0 CreatePdfFunctionType0(StreamToken functionStream, ArrayToken domain, ArrayToken range, IPdfTokenScanner scanner)
	{
		if (range == null)
		{
			throw new ArgumentException("Could not retrieve Range in type 0 function.");
		}
		if (!functionStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Size, scanner, out ArrayToken token))
		{
			throw new ArgumentNullException(NameToken.Size);
		}
		if (!functionStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerSample, scanner, out NumericToken token2))
		{
			throw new ArgumentNullException(NameToken.BitsPerSample);
		}
		int order = 1;
		if (functionStream.StreamDictionary.TryGet<NumericToken>(NameToken.Order, scanner, out NumericToken token3))
		{
			order = token3.Int;
		}
		if (!functionStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Encode, scanner, out ArrayToken token4) || token4 == null)
		{
			List<NumericToken> list = new List<NumericToken>();
			int length = token.Length;
			for (int i = 0; i < length; i++)
			{
				list.Add(new NumericToken(0));
				list.Add(new NumericToken(((NumericToken)token[i]).Int - 1));
			}
			token4 = new ArrayToken(list);
		}
		if (!functionStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Decode, scanner, out ArrayToken token5) || token5 == null)
		{
			token5 = range;
		}
		return new PdfFunctionType0(functionStream, domain, range, token, token2.Int, order, token4, token5);
	}

	private static PdfFunctionType2 CreatePdfFunctionType2(DictionaryToken functionDictionary, ArrayToken domain, ArrayToken? range, IPdfTokenScanner scanner)
	{
		if (!functionDictionary.TryGet<ArrayToken>(NameToken.C0, scanner, out ArrayToken token) || token.Length == 0)
		{
			token = new ArrayToken(new List<NumericToken>
			{
				new NumericToken(0)
			});
		}
		if (!functionDictionary.TryGet<ArrayToken>(NameToken.C1, scanner, out ArrayToken token2) || token2.Length == 0)
		{
			token2 = new ArrayToken(new List<NumericToken>
			{
				new NumericToken(1)
			});
		}
		if (!functionDictionary.TryGet<NumericToken>(NameToken.N, scanner, out NumericToken token3))
		{
			throw new ArgumentNullException(NameToken.N);
		}
		return new PdfFunctionType2(functionDictionary, domain, range, token, token2, token3.Double);
	}

	private static PdfFunctionType3 CreatePdfFunctionType3(DictionaryToken functionDictionary, ArrayToken domain, ArrayToken? range, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		List<PdfFunction> list = new List<PdfFunction>();
		if (functionDictionary.TryGet<ArrayToken>(NameToken.Functions, scanner, out ArrayToken token))
		{
			foreach (IToken datum in token.Data)
			{
				if (DirectObjectFinder.TryGet<StreamToken>(datum, scanner, out StreamToken tokenResult))
				{
					list.Add(Create(tokenResult, scanner, filterProvider));
					continue;
				}
				if (DirectObjectFinder.TryGet<DictionaryToken>(datum, scanner, out DictionaryToken tokenResult2))
				{
					list.Add(Create(tokenResult2, scanner, filterProvider));
					continue;
				}
				throw new ArgumentException($"Could not find function for token '{datum}' inside type 3 function.");
			}
			if (!functionDictionary.TryGet<ArrayToken>(NameToken.Bounds, scanner, out ArrayToken token2))
			{
				throw new ArgumentNullException(NameToken.Bounds);
			}
			if (!functionDictionary.TryGet<ArrayToken>(NameToken.Encode, scanner, out ArrayToken token3))
			{
				throw new ArgumentNullException(NameToken.Encode);
			}
			return new PdfFunctionType3(functionDictionary, domain, range, list, token2, token3);
		}
		throw new ArgumentNullException(NameToken.Functions);
	}

	private static PdfFunctionType4 CreatePdfFunctionType4(StreamToken functionStream, ArrayToken domain, ArrayToken range, IPdfTokenScanner scanner)
	{
		if (range == null)
		{
			throw new ArgumentException("Could not retrieve Range in type 4 function.");
		}
		return new PdfFunctionType4(functionStream, domain, range);
	}
}
