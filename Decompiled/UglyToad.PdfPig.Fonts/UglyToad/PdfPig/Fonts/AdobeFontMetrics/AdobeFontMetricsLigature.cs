namespace UglyToad.PdfPig.Fonts.AdobeFontMetrics;

public readonly struct AdobeFontMetricsLigature
{
	public string Successor { get; }

	public string Value { get; }

	public AdobeFontMetricsLigature(string successor, string value)
	{
		Successor = successor;
		Value = value;
	}

	public override string ToString()
	{
		return "Ligature: " + Value + " -> Successor: " + Successor;
	}
}
