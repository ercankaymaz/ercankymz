using System;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Filters;

public interface IFilter
{
	bool IsSupported { get; }

	Memory<byte> Decode(Memory<byte> input, DictionaryToken streamDictionary, IFilterProvider filterProvider, int filterIndex);
}
