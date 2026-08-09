using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization.Scanner;

public interface IPdfTokenScanner : ISeekableTokenScanner, ITokenScanner, IDisposable
{
	ObjectToken? Get(IndirectReference reference);

	void ReplaceToken(IndirectReference reference, IToken token);
}
