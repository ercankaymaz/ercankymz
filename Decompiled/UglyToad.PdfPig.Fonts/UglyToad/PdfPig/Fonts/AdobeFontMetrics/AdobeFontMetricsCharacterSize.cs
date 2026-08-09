namespace UglyToad.PdfPig.Fonts.AdobeFontMetrics;

public readonly struct AdobeFontMetricsCharacterSize
{
	public double X { get; }

	public double Y { get; }

	public AdobeFontMetricsCharacterSize(double x, double y)
	{
		X = x;
		Y = y;
	}

	public override string ToString()
	{
		return $"{X}, {Y}";
	}
}
