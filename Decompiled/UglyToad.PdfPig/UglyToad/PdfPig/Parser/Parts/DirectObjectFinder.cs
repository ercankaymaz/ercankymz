using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser.Parts;

public static class DirectObjectFinder
{
	public static bool TryGet<T>(IToken? token, IPdfTokenScanner scanner, [NotNullWhen(true)] out T? tokenResult) where T : class, IToken
	{
		tokenResult = null;
		if (token is T val)
		{
			tokenResult = val;
			return true;
		}
		if (!(token is IndirectReferenceToken indirectReferenceToken))
		{
			return false;
		}
		try
		{
			ObjectToken objectToken = scanner.Get(indirectReferenceToken.Data);
			if (objectToken == null)
			{
				return false;
			}
			if (objectToken.Data is T val2)
			{
				tokenResult = val2;
				return true;
			}
			if (objectToken.Data is IndirectReferenceToken token2)
			{
				return TryGet<T>(token2, scanner, out tokenResult);
			}
		}
		catch
		{
			return false;
		}
		return false;
	}

	public static T? Get<T>(IndirectReference reference, IPdfTokenScanner scanner) where T : class, IToken
	{
		ObjectToken objectToken = scanner.Get(reference);
		if (objectToken == null || objectToken.Data is NullToken)
		{
			return null;
		}
		if (objectToken.Data is T result)
		{
			return result;
		}
		if (objectToken.Data is IndirectReferenceToken token)
		{
			return Get<T>(token, scanner);
		}
		if (objectToken.Data is ArrayToken arrayToken && arrayToken.Data.Count == 1)
		{
			IToken token2 = arrayToken.Data[0];
			if (token2 is IndirectReferenceToken token3)
			{
				return Get<T>(token3, scanner);
			}
			if (token2 is T result2)
			{
				return result2;
			}
		}
		throw new PdfDocumentFormatException($"Could not find the object number {reference} with type {typeof(T).Name} instead, it was found with type {objectToken.GetType().Name}.");
	}

	public static T Get<T>(IToken token, IPdfTokenScanner scanner) where T : class, IToken
	{
		if (token is T result)
		{
			return result;
		}
		if (token is IndirectReferenceToken indirectReferenceToken)
		{
			return Get<T>(indirectReferenceToken.Data, scanner);
		}
		throw new PdfDocumentFormatException($"Could not find the object {token} with type {typeof(T).Name} instead, it was found with type {token.GetType().Name}.");
	}
}
