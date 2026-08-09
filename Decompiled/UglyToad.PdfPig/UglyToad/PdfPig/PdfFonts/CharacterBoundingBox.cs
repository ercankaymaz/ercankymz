using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.PdfFonts;

public sealed class CharacterBoundingBox
{
	public PdfRectangle GlyphBounds { get; }

	public double Width { get; }

	internal CharacterBoundingBox(PdfRectangle bounds, double width)
	{
		GlyphBounds = bounds;
		Width = width;
	}
}
