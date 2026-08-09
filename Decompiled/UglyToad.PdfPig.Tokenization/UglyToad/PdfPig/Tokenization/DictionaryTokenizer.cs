using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

internal class DictionaryTokenizer : ITokenizer
{
	private readonly bool usePdfDocEncoding;

	private readonly IReadOnlyList<NameToken> requiredKeys;

	private readonly bool useLenientParsing;

	public bool ReadsNextByte { get; }

	public DictionaryTokenizer(bool usePdfDocEncoding, IReadOnlyList<NameToken> requiredKeys = null, bool useLenientParsing = false)
	{
		this.usePdfDocEncoding = usePdfDocEncoding;
		this.requiredKeys = requiredKeys;
		this.useLenientParsing = useLenientParsing;
	}

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		long currentOffset = inputBytes.CurrentOffset;
		try
		{
			return TryTokenizeInternal(currentByte, inputBytes, useRequiredKeys: false, out token);
		}
		catch (PdfDocumentFormatException)
		{
			if (requiredKeys == null)
			{
				throw;
			}
		}
		inputBytes.Seek(currentOffset);
		return TryTokenizeInternal(currentByte, inputBytes, useRequiredKeys: true, out token);
	}

	private bool TryTokenizeInternal(byte currentByte, IInputBytes inputBytes, bool useRequiredKeys, out IToken token)
	{
		token = null;
		if (currentByte != 60)
		{
			return false;
		}
		bool flag = false;
		while (inputBytes.MoveNext())
		{
			if (inputBytes.CurrentByte == 60)
			{
				flag = true;
				break;
			}
			if (!ReadHelper.IsWhitespace(inputBytes.CurrentByte))
			{
				break;
			}
		}
		if (!flag)
		{
			return false;
		}
		CoreTokenScanner coreTokenScanner = new CoreTokenScanner(inputBytes, usePdfDocEncoding, ScannerScope.Dictionary, null, useLenientParsing);
		List<IToken> list = new List<IToken>();
		while (coreTokenScanner.MoveNext())
		{
			if (coreTokenScanner.CurrentToken is CommentToken)
			{
				continue;
			}
			list.Add(coreTokenScanner.CurrentToken);
			if (!useRequiredKeys || list.Count < requiredKeys.Count * 2)
			{
				continue;
			}
			Dictionary<NameToken, IToken> dictionary = ConvertToDictionary(list, useLenientParsing);
			bool flag2 = true;
			foreach (NameToken requiredKey in requiredKeys)
			{
				if (!dictionary.TryGetValue(requiredKey, out var value) || value == null)
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				token = new DictionaryToken(dictionary);
				return true;
			}
		}
		Dictionary<NameToken, IToken> data = ConvertToDictionary(list, useLenientParsing);
		token = new DictionaryToken(data);
		return true;
	}

	private static Dictionary<NameToken, IToken> ConvertToDictionary(List<IToken> tokens, bool useLenientParsing)
	{
		Dictionary<NameToken, IToken> dictionary = new Dictionary<NameToken, IToken>();
		NameToken nameToken = null;
		for (int i = 0; i < tokens.Count; i++)
		{
			IToken token = tokens[i];
			if (nameToken == null)
			{
				if (token is NameToken nameToken2)
				{
					nameToken = nameToken2;
				}
				else if (!useLenientParsing)
				{
					throw new PdfDocumentFormatException("Expected name as dictionary key, instead got: " + token);
				}
				continue;
			}
			if (token is NumericToken numericToken && PeekNext(tokens, i) is NumericToken numericToken2)
			{
				if (PeekNext(tokens, i + 1) == OperatorToken.R)
				{
					dictionary[nameToken] = new IndirectReferenceToken(new IndirectReference(numericToken.Long, numericToken2.Int));
					i += 2;
				}
			}
			else
			{
				dictionary[nameToken] = token;
			}
			if (PeekNext(tokens, i) == OperatorToken.Def)
			{
				i++;
			}
			nameToken = null;
		}
		return dictionary;
	}

	private static IToken PeekNext(List<IToken> tokens, int currentIndex)
	{
		if (tokens.Count - 1 < currentIndex + 1)
		{
			return null;
		}
		return tokens[currentIndex + 1];
	}
}
