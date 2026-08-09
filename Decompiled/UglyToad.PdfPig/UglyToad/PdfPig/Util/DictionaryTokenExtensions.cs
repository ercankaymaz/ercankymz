using System;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Util;

public static class DictionaryTokenExtensions
{
	public static IToken? GetObjectOrDefault(this DictionaryToken dictionaryToken, NameToken name)
	{
		if (dictionaryToken.TryGet(name, out var token))
		{
			return token;
		}
		return null;
	}

	public static IToken? GetObjectOrDefault(this DictionaryToken dictionaryToken, NameToken first, NameToken second)
	{
		if (dictionaryToken.TryGet(first, out var token))
		{
			return token;
		}
		if (dictionaryToken.TryGet(second, out token))
		{
			return token;
		}
		return null;
	}

	public static int GetInt(this DictionaryToken dictionaryToken, NameToken name)
	{
		if (dictionaryToken == null)
		{
			throw new ArgumentNullException("dictionaryToken");
		}
		return ((dictionaryToken.GetObjectOrDefault(name) as NumericToken) ?? throw new PdfDocumentFormatException($"The dictionary did not contain a number with the key {name}. Dictionary way: {dictionaryToken}.")).Int;
	}

	public static int GetIntOrDefault(this DictionaryToken dictionaryToken, NameToken name, int defaultValue = 0)
	{
		if (dictionaryToken == null)
		{
			throw new ArgumentNullException("dictionaryToken");
		}
		return (dictionaryToken.GetObjectOrDefault(name) as NumericToken)?.Int ?? defaultValue;
	}

	public static int GetIntOrDefault(this DictionaryToken dictionaryToken, NameToken first, NameToken second, int defaultValue = 0)
	{
		if (dictionaryToken == null)
		{
			throw new ArgumentNullException("dictionaryToken");
		}
		return (dictionaryToken.GetObjectOrDefault(first, second) as NumericToken)?.Int ?? 0;
	}

	public static long? GetLongOrDefault(this DictionaryToken dictionaryToken, NameToken name)
	{
		if (dictionaryToken == null)
		{
			throw new ArgumentNullException("dictionaryToken");
		}
		return (dictionaryToken.GetObjectOrDefault(name) as NumericToken)?.Long;
	}

	public static bool GetBooleanOrDefault(this DictionaryToken dictionaryToken, NameToken name, bool defaultValue)
	{
		if (dictionaryToken == null)
		{
			throw new ArgumentNullException("dictionaryToken");
		}
		return (dictionaryToken.GetObjectOrDefault(name) as BooleanToken)?.Data ?? defaultValue;
	}

	public static NameToken? GetNameOrDefault(this DictionaryToken dictionaryToken, NameToken name)
	{
		if (dictionaryToken == null)
		{
			throw new ArgumentNullException("dictionaryToken");
		}
		return dictionaryToken.GetObjectOrDefault(name) as NameToken;
	}

	public static bool TryGetOptionalTokenDirect<T>(this DictionaryToken dictionaryToken, NameToken name, IPdfTokenScanner scanner, [NotNullWhen(true)] out T? result) where T : class, IToken
	{
		result = null;
		if (dictionaryToken.TryGet(name, out var token) && DirectObjectFinder.TryGet<T>(token, scanner, out T tokenResult))
		{
			result = tokenResult;
			return true;
		}
		return false;
	}

	public static bool TryGetOptionalStringDirect(this DictionaryToken dictionaryToken, NameToken name, IPdfTokenScanner scanner, [NotNullWhen(true)] out string? result)
	{
		result = null;
		if (dictionaryToken.TryGetOptionalTokenDirect<StringToken>(name, scanner, out StringToken result2))
		{
			result = result2.Data;
			return true;
		}
		if (dictionaryToken.TryGetOptionalTokenDirect<HexToken>(name, scanner, out HexToken result3))
		{
			result = result3.Data;
			return true;
		}
		return false;
	}
}
