using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.CrossReference;

internal class CrossReferenceTablePartBuilder
{
	private readonly Dictionary<IndirectReference, long> objects = new Dictionary<IndirectReference, long>();

	public long Offset { get; set; }

	public long Previous { get; set; }

	public DictionaryToken? Dictionary { get; set; }

	public CrossReferenceType XRefType { get; set; }

	public long? TiedToPreviousAtOffset { get; set; }

	public void Add(long objectId, int generationNumber, long offset)
	{
		if (generationNumber <= 65535)
		{
			IndirectReference key = new IndirectReference(objectId, generationNumber);
			if (!objects.ContainsKey(key))
			{
				objects[key] = offset;
			}
		}
	}

	public CrossReferenceTablePart Build()
	{
		return new CrossReferenceTablePart(objects, Offset, Previous, Dictionary, XRefType, TiedToPreviousAtOffset);
	}
}
