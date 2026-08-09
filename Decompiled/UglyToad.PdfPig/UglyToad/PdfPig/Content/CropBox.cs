using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Content;

public class CropBox
{
	public PdfRectangle Bounds { get; }

	public CropBox(PdfRectangle bounds)
	{
		Bounds = bounds;
	}

	public override string ToString()
	{
		return Bounds.ToString();
	}
}
