using System;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters;

public sealed class DctDecodeFilter : IFilter
{
	public bool IsSupported { get; }

	public Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex)
	{
		throw new NotSupportedException("The DST (Discrete Cosine Transform) Filter indicates data is encoded in JPEG format. This filter is not currently supported but the raw data can be supplied to JPEG supporting libraries.");
	}
}
