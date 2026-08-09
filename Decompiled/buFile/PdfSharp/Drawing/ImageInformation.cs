namespace PdfSharp.Drawing;

internal class ImageInformation
{
	internal enum ImageFormats
	{
		JPEG,
		JPEGGRAY,
		JPEGRGBW,
		JPEGCMYK,
		Palette1,
		Palette4,
		Palette8,
		RGB24,
		ARGB32
	}

	internal ImageFormats ImageFormat;

	internal uint Width;

	internal uint Height;

	internal decimal HorizontalDPI;

	internal decimal VerticalDPI;

	internal decimal HorizontalDPM;

	internal decimal VerticalDPM;

	internal decimal HorizontalAspectRatio;

	internal decimal VerticalAspectRatio;

	internal uint ColorsUsed;
}
