using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser.FileStructure;

internal interface IXrefSection
{
	long Offset { get; }

	IReadOnlyDictionary<IndirectReference, long> ObjectOffsets { get; }

	DictionaryToken? Dictionary { get; }

	XrefOffsetCorrection CorrectionType { get; }

	long OffsetCorrection { get; }

	long? GetPrevious();
}
