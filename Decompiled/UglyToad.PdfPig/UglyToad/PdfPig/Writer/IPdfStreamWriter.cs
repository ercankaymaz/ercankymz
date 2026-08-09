using System;
using System.IO;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer;

internal interface IPdfStreamWriter : IDisposable
{
	bool AttemptDeduplication { get; set; }

	Stream Stream { get; }

	bool WritingPageContents { get; set; }

	IndirectReferenceToken WriteToken(IToken token);

	IndirectReferenceToken WriteToken(IToken token, IndirectReferenceToken indirectReference);

	IndirectReferenceToken ReserveObjectNumber();

	void InitializePdf(double version);

	void CompletePdf(IndirectReferenceToken catalogReference, IndirectReferenceToken? documentInformationReference = null);
}
