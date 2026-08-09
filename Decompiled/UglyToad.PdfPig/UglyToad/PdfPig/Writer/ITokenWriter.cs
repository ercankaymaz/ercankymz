using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer;

public interface ITokenWriter
{
	bool WritingPageContents { get; set; }

	void WriteToken(IToken token, Stream outputStream);

	void WriteObject(long objectNumber, int generation, byte[] data, Stream outputStream);

	void WriteCrossReferenceTable(IReadOnlyDictionary<IndirectReference, long> objectOffsets, IndirectReference catalogToken, Stream outputStream, IndirectReference? documentInformationReference);
}
