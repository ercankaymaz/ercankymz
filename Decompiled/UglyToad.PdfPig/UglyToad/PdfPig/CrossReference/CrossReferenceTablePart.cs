using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.CrossReference;

internal class CrossReferenceTablePart
{
	public IReadOnlyDictionary<IndirectReference, long> ObjectOffsets { get; }

	public long Offset { get; private set; }

	public long Previous { get; }

	public DictionaryToken Dictionary { get; private set; }

	public CrossReferenceType Type { get; }

	public long? TiedToXrefAtOffset { get; }

	public CrossReferenceTablePart(IReadOnlyDictionary<IndirectReference, long> objectOffsets, long offset, long previous, DictionaryToken dictionary, CrossReferenceType type, long? tiedToXrefAtOffset)
	{
		ObjectOffsets = objectOffsets;
		Offset = offset;
		Previous = previous;
		Dictionary = dictionary;
		Type = type;
		TiedToXrefAtOffset = tiedToXrefAtOffset;
	}

	public void FixOffset(long offset)
	{
		Offset = offset;
		Dictionary = Dictionary.With(NameToken.Prev, new NumericToken(offset));
	}

	public long GetPreviousOffset()
	{
		if (Dictionary.TryGet(NameToken.Prev, out var token) && token is NumericToken numericToken)
		{
			return numericToken.Long;
		}
		return -1L;
	}
}
