using System.Collections.Generic;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables.Kerning;

internal class KerningSubTable
{
	public int Version { get; }

	public KernCoverage Coverage { get; }

	public IReadOnlyList<KernPair> Pairs { get; }

	public KerningSubTable(int version, KernCoverage coverage, IReadOnlyList<KernPair> pairs)
	{
		Version = version;
		Coverage = coverage;
		Pairs = pairs;
	}
}
