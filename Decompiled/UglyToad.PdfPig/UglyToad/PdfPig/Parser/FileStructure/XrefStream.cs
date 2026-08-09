using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser.FileStructure;

internal sealed class XrefStream : IXrefSection
{
	public long Offset { get; }

	public IReadOnlyDictionary<IndirectReference, long> ObjectOffsets { get; }

	public DictionaryToken Dictionary { get; }

	public XrefOffsetCorrection CorrectionType { get; }

	public long OffsetCorrection { get; }

	public XrefStream(long offset, IReadOnlyDictionary<IndirectReference, long> objectOffsets, DictionaryToken streamDictionary, XrefOffsetCorrection correctionType, long offsetCorrection)
	{
		Offset = offset;
		ObjectOffsets = objectOffsets;
		Dictionary = streamDictionary;
		CorrectionType = correctionType;
		OffsetCorrection = offsetCorrection;
	}

	public long? GetPrevious()
	{
		if (Dictionary.TryGet(NameToken.Prev, out NumericToken token))
		{
			return token.Long;
		}
		return null;
	}
}
