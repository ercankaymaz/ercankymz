using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

public sealed class EndOfLineTokenizer : ITokenizer
{
	public bool ReadsNextByte { get; }

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		token = null;
		if (currentByte != 13 && currentByte != 10)
		{
			return false;
		}
		token = EndOfLineToken.Token;
		return true;
	}
}
