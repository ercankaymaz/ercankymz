using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser.FileStructure;

internal class FirstPassResults
{
	public IReadOnlyList<IXrefSection> Parts { get; }

	public IReadOnlyDictionary<IndirectReference, long>? BruteForceOffsets { get; }

	public IReadOnlyDictionary<IndirectReference, long> XrefOffsets { get; }

	public DictionaryToken? Trailer { get; }

	public FirstPassResults(IReadOnlyList<IXrefSection> parts, IReadOnlyDictionary<IndirectReference, long>? bruteForceOffsets, IReadOnlyDictionary<IndirectReference, long> xrefOffsets, DictionaryToken? trailer)
	{
		Parts = parts;
		BruteForceOffsets = bruteForceOffsets;
		XrefOffsets = xrefOffsets;
		Trailer = trailer;
	}
}
