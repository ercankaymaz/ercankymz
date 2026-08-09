using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization.Scanner;

internal interface IObjectLocationProvider
{
	bool TryGetOffset(IndirectReference reference, out long offset);

	void UpdateOffset(IndirectReference reference, long offset);

	bool TryGetCached(IndirectReference reference, [NotNullWhen(true)] out ObjectToken? objectToken);

	void Cache(ObjectToken objectToken, bool force = false);
}
