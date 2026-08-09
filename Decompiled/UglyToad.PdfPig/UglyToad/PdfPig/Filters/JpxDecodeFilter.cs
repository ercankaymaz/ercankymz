using System;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters;

public sealed class JpxDecodeFilter : IFilter
{
	public bool IsSupported { get; }

	public Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex)
	{
		throw new NotSupportedException("The JPX Filter (JPEG2000) for image data is not currently supported. Try accessing the raw compressed data directly.");
	}
}
