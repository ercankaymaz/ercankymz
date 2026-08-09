using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

public interface ITokenizer
{
	bool ReadsNextByte { get; }

	bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token);
}
