using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization.Scanner;

public interface ITokenScanner
{
	IToken CurrentToken { get; }

	bool MoveNext();

	bool TryReadToken<T>(out T token) where T : class, IToken;
}
