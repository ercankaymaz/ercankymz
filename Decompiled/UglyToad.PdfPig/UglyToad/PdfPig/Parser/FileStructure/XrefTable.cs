using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser.FileStructure;

internal sealed class XrefTable : IXrefSection
{
	public long Offset { get; }

	public IReadOnlyDictionary<IndirectReference, long> ObjectOffsets { get; }

	public DictionaryToken? Dictionary { get; }

	public XrefOffsetCorrection CorrectionType { get; }

	public long OffsetCorrection { get; }

	public XrefTable(long offset, IReadOnlyDictionary<IndirectReference, long> objectOffsets, DictionaryToken? trailer, XrefOffsetCorrection correctionType, long offsetCorrection)
	{
		Offset = offset;
		ObjectOffsets = objectOffsets;
		Dictionary = trailer;
		CorrectionType = correctionType;
		OffsetCorrection = offsetCorrection;
	}

	public long? GetPrevious()
	{
		if (Dictionary != null && Dictionary.TryGet(NameToken.Prev, out NumericToken token))
		{
			return token.Long;
		}
		return null;
	}

	public long? GetXRefStm()
	{
		if (Dictionary != null && Dictionary.TryGet(NameToken.XrefStm, out NumericToken token))
		{
			return token.Long;
		}
		return null;
	}
}
