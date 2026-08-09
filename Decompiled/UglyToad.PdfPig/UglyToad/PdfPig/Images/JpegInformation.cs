namespace UglyToad.PdfPig.Images;

internal class JpegInformation
{
	public int Width { get; }

	public int Height { get; }

	public int BitsPerComponent { get; }

	public int NumberOfComponents { get; }

	public JpegInformation(int width, int height, int bitsPerComponent, int numberOfComponents)
	{
		Width = width;
		Height = height;
		BitsPerComponent = bitsPerComponent;
		NumberOfComponents = numberOfComponents;
	}
}
