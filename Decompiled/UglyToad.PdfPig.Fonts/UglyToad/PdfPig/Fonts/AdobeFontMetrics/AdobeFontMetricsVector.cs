namespace UglyToad.PdfPig.Fonts.AdobeFontMetrics;

public readonly struct AdobeFontMetricsVector
{
	public double X { get; }

	public double Y { get; }

	public AdobeFontMetricsVector(double x, double y)
	{
		X = x;
		Y = y;
	}

	public override string ToString()
	{
		return $"{X}, {Y}";
	}
}
