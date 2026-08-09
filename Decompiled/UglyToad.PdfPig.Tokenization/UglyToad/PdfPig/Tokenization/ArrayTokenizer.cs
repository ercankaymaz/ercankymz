using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

internal sealed class ArrayTokenizer : ITokenizer
{
	private readonly bool usePdfDocEncoding;

	public bool ReadsNextByte { get; }

	public ArrayTokenizer(bool usePdfDocEncoding)
	{
		this.usePdfDocEncoding = usePdfDocEncoding;
	}

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		token = null;
		if (currentByte != 91)
		{
			return false;
		}
		CoreTokenScanner coreTokenScanner = new CoreTokenScanner(inputBytes, usePdfDocEncoding, ScannerScope.Array);
		List<IToken> list = new List<IToken>();
		IToken previousToken = null;
		while (!CurrentByteEndsCurrentArray(inputBytes, previousToken) && coreTokenScanner.MoveNext())
		{
			previousToken = coreTokenScanner.CurrentToken;
			if (!(coreTokenScanner.CurrentToken is CommentToken))
			{
				list.Add(coreTokenScanner.CurrentToken);
			}
		}
		token = new ArrayToken(list);
		return true;
	}

	private static bool CurrentByteEndsCurrentArray(IInputBytes inputBytes, IToken previousToken)
	{
		if (inputBytes.CurrentByte == 93 && !(previousToken is ArrayToken))
		{
			return true;
		}
		return false;
	}
}
