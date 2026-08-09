using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.AdobeFontMetrics;

public class AdobeFontMetricsIndividualCharacterMetric
{
	public int CharacterCode { get; }

	public string Name { get; }

	public AdobeFontMetricsVector Width { get; }

	public AdobeFontMetricsVector WidthDirection0 { get; }

	public AdobeFontMetricsVector WidthDirection1 { get; }

	public AdobeFontMetricsVector VVector { get; }

	public PdfRectangle BoundingBox { get; }

	public AdobeFontMetricsLigature Ligature { get; }

	public AdobeFontMetricsIndividualCharacterMetric(int characterCode, string name, AdobeFontMetricsVector width, AdobeFontMetricsVector widthDirection0, AdobeFontMetricsVector widthDirection1, AdobeFontMetricsVector vVector, PdfRectangle boundingBox, AdobeFontMetricsLigature ligature)
	{
		CharacterCode = characterCode;
		Name = name;
		Width = width;
		WidthDirection0 = widthDirection0;
		WidthDirection1 = widthDirection1;
		VVector = vVector;
		BoundingBox = boundingBox;
		Ligature = ligature;
	}

	public override string ToString()
	{
		return $"[{CharacterCode}] {Name} Width: {Width}.";
	}
}
