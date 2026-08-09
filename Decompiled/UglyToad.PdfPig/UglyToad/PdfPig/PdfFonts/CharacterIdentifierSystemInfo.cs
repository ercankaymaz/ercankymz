using System.Globalization;

namespace UglyToad.PdfPig.PdfFonts;

internal readonly struct CharacterIdentifierSystemInfo
{
	public string Registry { get; }

	public string Ordering { get; }

	public int Supplement { get; }

	public CharacterIdentifierSystemInfo(string registry, string ordering, int supplement)
	{
		Registry = registry;
		Ordering = ordering;
		Supplement = supplement;
	}

	public override string ToString()
	{
		return Registry + "-" + Ordering + "-" + Supplement.ToString(CultureInfo.InvariantCulture);
	}
}
